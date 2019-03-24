using Sober.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sober.Web.Controllers
{
    public class NewsController : Controller
    {
        public IeverydaynewsService ieverydaynewsService { get; set; }
        // GET: News
        public ActionResult Index()
        {
            var bb = ieverydaynewsService.GetEntitiesByPage(5, 1, false, n => n.eid > 100, n => n.edate);
            return View();
        }
        public object GetNewsByPage (int PageIndex,int pageSize)
        {
            var bb = ieverydaynewsService.GetEntitiesByPage(pageSize, PageIndex, false, n => n.isvalid=="1", n => n.edate);
            return bb;
        }
    }
}