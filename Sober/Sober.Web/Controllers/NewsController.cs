using Sober.IService;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Sober.Web.Controllers
{
    public class NewsController : Controller
    {

        private static string Conn = ConfigurationManager.ConnectionStrings["newsDBConn"].ToString();
        //string sql = "select * from  everydaynews where eid=@RecordID ";
        //SqlParameter[] parameter = new SqlParameter[]{
        //            new SqlParameter("@RecordID", "1")
        //        };
        //DataTable dt1 = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sql, parameter).Tables[0];
        Common zjk = new Common();
        public IeverydaynewsService ieverydaynewsService { get; set; }
        public IV_everydaynewsService iv_everydaynewsService { get; set; }
        RespondModel result = new RespondModel();
        // GET: News
        public ActionResult Index()
        {
            return View();
        }
        public object GetNewsByPage(int PageIndex, int pageSize, string KeyWord)
        {

            int recc = 0;
            RespondModel result = new RespondModel();
            result.Status = Codestatus.OK;
            try
            {
                var list = iv_everydaynewsService.GetEntitiesByPage(pageSize, PageIndex, false, n => n.isvalid == "1" && (n.etitle.Contains(KeyWord) || n.eauthor.Contains(KeyWord)), n => n.edate, ref recc);
                if (list == null)
                {
                    result.Status = Codestatus.NO;
                    result.Recc = recc;
                    return result;
                }
                result.Data = list;
                result.Recc = recc;

                JavaScriptSerializer jss = new JavaScriptSerializer();
                string myJson = jss.Serialize(result);
                return myJson;

            }
            catch (Exception ex)
            {
                result.Status = Codestatus.Error;
                result.Recc = -1;
                result.Msg = ex.Message;
            }
            return result;
        }
        public ActionResult NewsDetaile()
        {
            return View();
        }
        public ActionResult aa()
        {
            string sql = "select distinct(eauthor) from everydaynews";
            DataTable dt1 = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sql).Tables[0];
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                SqlHelper.ExecuteNonQuery(Conn, CommandType.Text, "insert into Users (UserName,Password) values('"+dt1.Rows[i][0]+"','0000')");
            }
            return View();
        }
        public object GetNewsDetails(string id)//
        {
            var sssd = Convert.ToInt32(Convert.ToString(Convert.ToInt32(id, 16), 10));
            RespondModel result = new RespondModel();
            result.Status = Codestatus.OK;
            try
            {
                var list = ieverydaynewsService.GetEntity(n => n.eid == Convert.ToInt32(Convert.ToString(Convert.ToInt32(id, 16), 10)));
                if (list == null)
                {
                    result.Status = Codestatus.NO;
                    result.Recc = 0;
                    return result;
                }
                result.Data = list;
                result.Recc = 0;

                JavaScriptSerializer jss = new JavaScriptSerializer();
                string myJson = jss.Serialize(result);
                return myJson;
            }
            catch (Exception ex)
            {
                result.Status = Codestatus.Error;
                result.Recc = -1;
                result.Msg = ex.Message;
            }
            return result;
        }
    }
}