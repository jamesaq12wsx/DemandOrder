using DemandOrder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemandOrder.Controllers
{
    public class DemandOrderController : Controller
    {
        OrderLibrary orderLib = new OrderLibrary();

        // GET: DemandOrder
        public ActionResult Index()
        {
            OrdersCountViewModel orders = new OrdersCountViewModel();

            orders.Orders = orderLib.GetFakeData();

            return View(orders);
        }

        [HttpPost]
        public ActionResult Index(int dept)
        {

            //string dept = Request.Form["Dept"].ToString();

            //string dept = Dept;

            OrdersCountViewModel orders = new OrdersCountViewModel();

            orders.Orders = orderLib.GetFakeDataByDept(dept);

            return View(orders);
        }

        public ActionResult DrawPic()
        {
            

            return View();
        }
    }
}