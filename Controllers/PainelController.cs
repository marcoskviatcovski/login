using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Login.Controllers
{
    public class PainelController : Controller
    {
        // GET: Painel
        [AuthorizeCustom]
        public ActionResult Index()
        {
            return View();
        }
    }
}