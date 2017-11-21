using DemandOrder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using PagedList;

namespace DemandOrder.Controllers
{
    public class DemandOrderController : Controller
    {
        OrderLibrary orderLib = new OrderLibrary();

        private int pageSize = 10;

        private int pageSizeFor2 = 4;

        // GET: DemandOrder
        public ActionResult Index()
        {
            OrdersCountViewModel orders = new OrdersCountViewModel();

            //orders.Orders = orderLib.GetSimpleData();

            //orders.Orders = orderLib.GetSimpleData().Where(model => (model.ExpectStartDate.Date > DateTime.Now.AddYears(-1).Date || (model.ExpectStartDate.Year == DateTime.Now.AddYears(-1).Year && model.ExpectStartDate.Month == DateTime.Now.AddYears(-1).Month))).ToList();
            orders.Orders = orderLib.GetSimpleData();

            orders.StateList = orderLib.GetStateList();

            orders.SearchDate = DateTime.Now.AddYears(-1);

            //預設為資訊中心
            orders.selectedDept = 0;

            return View(orders);
        }

        [HttpPost]
        public ActionResult Index(int dept, DateTime SearchDate)
        {

            OrdersCountViewModel orders = new OrdersCountViewModel();

            //orders.Orders = orderLib.GetFakeDataByDept(dept,SearchDate);

            orders.Orders = orderLib.GetSimpleDataByDept(dept, SearchDate);

            orders.StateList = orderLib.GetFakeStateByDept(dept, SearchDate);

            orders.SearchDate = SearchDate;

            orders.selectedDept = dept;

            return View(orders);
        }


        public ActionResult Index2(int page = 1)
        {
            OrdersCountViewModel orders = new OrdersCountViewModel();

            //orders.Orders = orderLib.GetSimpleData();

            //orders.Orders = orderLib.GetSimpleData().Where(model => (model.ExpectStartDate.Date > DateTime.Now.AddYears(-1).Date || (model.ExpectStartDate.Year == DateTime.Now.AddYears(-1).Year && model.ExpectStartDate.Month == DateTime.Now.AddYears(-1).Month))).ToList();
            orders.Orders = orderLib.GetSimpleData();

            orders.StateList = orderLib.GetStateList();

            orders.SearchDate = DateTime.Now.AddYears(-1);

            var currentPage = page < 1 ? 1 : page;

            var group = orders.Orders.GroupBy(model => model.ApplyDept);

            var orderGroup = group.Skip((page - 1) * pageSizeFor2).Take(pageSizeFor2);

            //orders.Orders = orderList.First();

            //var result = orders.Orders.ToPagedList(currentPage, pageSizeFor2);



            return View(orders);
        }

        //public ActionResult Index2(int page = 1)
        //{
        //    OrdersCountViewModel orders = new OrdersCountViewModel();

        //    Index2ViewModel orderGroup = new Index2ViewModel();

        //    //orders.Orders = orderLib.GetSimpleData();

        //    //orders.Orders = orderLib.GetSimpleData().Where(model => (model.ExpectStartDate.Date > DateTime.Now.AddYears(-1).Date || (model.ExpectStartDate.Year == DateTime.Now.AddYears(-1).Year && model.ExpectStartDate.Month == DateTime.Now.AddYears(-1).Month))).ToList();

        //    orders.SearchDate = DateTime.Now.AddYears(-1);

        //    var currentPage = page < 1 ? 1 : page;

        //    var group = orders.Orders.GroupBy(model => model.ApplyDept);

        //    group = group.Skip((page - 1) * pageSizeFor2).Take(pageSizeFor2);

        //    orderGroup.OrderGroups = group;

        //    orderGroup.Searchdate = DateTime.Now.AddYears(-1);

        //    //orders.Orders = orderList.First();

        //    //var result = orders.Orders.ToPagedList(currentPage, pageSizeFor2);



        //    return View(orders);
        //}

        [HttpPost]
        public ActionResult Index2(DateTime SearchDate)
        {

            OrdersCountViewModel orders = new OrdersCountViewModel();

            //var currentPage = page < 1 ? 1 : page;



            //orders.Orders = orderLib.GetFakeDataByDept(dept,SearchDate);

            orders.Orders = orderLib.GetSimpleDataSearchDate(SearchDate);

            //orders.StateList = orderLib.GetFakeStateByDept(dept, SearchDate);

            var group = orders.Orders.GroupBy(model => model.ApplyDept);

            orders.SearchDate = SearchDate;

            //orders.SearchDate = DateTime.Now.AddYears(-1);

            //orders.selectedDept = dept;

            return View(orders);


        }

        public ActionResult MonthDatas(DateTime fromDate, DateTime detailDate, string state, int dept, int page=1)
        {
            if (detailDate == null || state == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //var dataList = orderLib.GetSimpleDataByDeptAndMonth(deptcode, detailDate).Where(model => model.State == state).ToList();

            //var dataList = orderLib.GetSimpleDataByDeptAndMonth(dept,detailDate).Where(model => model.State == state).ToList();

            var dataList = orderLib.GetDatasByMonthAndStateAndDept(detailDate,state,dept);

            //pagelist 增加
            int currentPage = page < 1 ? 1 : page;
            //pagelist 增加
            var result = dataList.ToPagedList(currentPage, pageSize);

            ViewData["deptName"] = orderLib.deptName[dept];

            ViewData["state"] = state;

            ViewData["dataDate"] = detailDate;

            ViewBag.date = detailDate;

            return View(dataList);

            //pagelist 增加
            //return View(result);
        }

        [HttpPost]
        public ActionResult MonthDatas(DateTime dataMonth, string state, string deptName, string orderSeq, string orderBy, string searchString)
        {
            OrderLibrary orderLib = new OrderLibrary();

            //var orders = orderLib.GetSimpleData().Where(model => (model.ExpectStartDate.Year == expectStartDate.Year && model.ExpectStartDate.Month == expectStartDate.Month)).ToList();

            int deptCode = Array.IndexOf(orderLib.deptName, deptName);

            var orders = orderLib.GetDatasByMonthAndStateAndDept(dataMonth, state, deptCode);

            if (!String.IsNullOrEmpty(searchString))
            {
                orders = orders.Where(model => model.OrderName.Contains(searchString)).ToList();
            }

            ViewData["deptName"] = deptName;

            ViewData["state"] = state;

            ViewData["dataDate"] = dataMonth;

            ViewBag.date = dataMonth;

            switch (orderSeq)
            {
                case "Seq":
                    switch (orderBy)
                    {
                        case "OrderID":
                            return View(orders.OrderBy(o => o.OrderID).ToList());
                        case "OrderName":
                            return View(orders.OrderBy(o => o.OrderName).ToList());
                        case "Date":
                            return View(orders.OrderBy(o => o.ExpectStartDate).ToList());
                        default:
                            return View(orders.OrderBy(o => o.OrderID).ToList());
                    }

                case "Dec":
                    switch (orderBy)
                    {
                        case "OrderID":
                            return View(orders.OrderByDescending(o => o.OrderID).ToList());
                        case "OrderName":
                            return View(orders.OrderByDescending(o => o.OrderName).ToList());
                        case "Date":
                            return View(orders.OrderByDescending(o => o.ExpectStartDate).ToList());
                        default:
                            return View(orders.OrderByDescending(o => o.OrderID).ToList());
                    }
            }

            return View(orders.OrderBy(o => o.OrderID).ToList());
        }

        public ActionResult Detail(string orderId)
        {
            if(orderId == "")
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var order = orderLib.FindOrderById(orderId);

            if (order == null)
            {
                return HttpNotFound();
            }

            return View(order);
        }

        public ActionResult Edit(string orderId)
        {
            if (orderId == "")
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var order = orderLib.FindOrderById(orderId);

            if (order == null)
            {
                return HttpNotFound();
            }

            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OrderViewModel order)
        {
            if (ModelState.IsValid)
            {
                OrderLibrary orderLib = new OrderLibrary();

                orderLib.OrderUpdate(order);

                return RedirectToAction("Index");
            }
            return View(order);
        }

    }
}