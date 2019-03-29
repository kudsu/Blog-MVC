using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sober.IService;


namespace Sober.Web.Controllers
{
    public class HomeController : Controller
    {
        public IeverydaynewsService NoticeService { get; set; }
        public ActionResult Index()
        {
            int recc = 0;
            //var aa = NoticeService.GetCount(n => true);
            var bb = NoticeService.GetEntitiesByPage(3, 1, true, n => n.eid > 100, n => n.elook,ref recc);
            var cc = NoticeService.GetEntity(b => b.eid == 1);
            

            return View();
        }
    }
}