using Sober.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Sober.Web.Controllers
{
    public class NewsController : Controller
    {
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
            var bb= System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile("16位MD5加密（取32位加密的9~25字符）", "MD5").ToLower();
            return View();
        }
        public object GetNewsDetails(int id)
        {
            RespondModel result = new RespondModel();
            result.Status = Codestatus.OK;
            try
            {
                var list = ieverydaynewsService.GetEntity(n => n.eid == id);
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