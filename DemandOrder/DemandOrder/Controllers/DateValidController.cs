using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemandOrder.Controllers
{
    public class DateValidController : Controller
    {
        // GET: StringValid
        //參數名稱必須跟property名稱一樣
        public ActionResult DateValid(DateTime SearchDate)
        {
            bool isValidate=true;
            if (SearchDate.Date >= DateTime.Now.Date || (SearchDate.Year == DateTime.Now.Year && SearchDate.Month == DateTime.Now.Month))
                isValidate = false;

            return Json(isValidate, JsonRequestBehavior.AllowGet);
        }
    }
}