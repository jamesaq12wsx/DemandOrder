using DemandOrder.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemandOrder.Models
{
    public class OrderLibrary
    {
        public string[] deptName = new string[] { "資訊中心", "數位資訊部", "資訊系統部", "投資資訊部", "壽險資訊部", "資訊規劃部" };

        public List<OrderViewModel> GetData()
        {

            DBService _db = new DBService();

            return _db.getSummaryTable().ToList();

        }

        public List<SimpleOrderViewModel> TransDataToSimple(List<OrderViewModel> list)
        {
            List<SimpleOrderViewModel> simpleList = new List<SimpleOrderViewModel>();

            foreach(var item in list)
            {
                SimpleOrderViewModel simple = new SimpleOrderViewModel();

                simple.OrderID = item.OrderID;

                simple.OrderName = item.OrderName;

                simple.ITDept = item.ITDept;

                simple.ApplyDept = item.ApplyDept;

                simple.State = item.State;

                //ExpectStartDate 要改成 預計接收日
                simple.ExpectStartDate = item.ExpectRecieveDate.Value;

                simple.CloseDate = item.CaseCloseDate;

                simple.ClassName = item.ClassName;

                simpleList.Add(simple);
            }

            return simpleList;
        }

        public List<SimpleOrderViewModel> GetSimpleData()
        {
            return TransDataToSimple(GetData());
        }

        public List<SimpleOrderViewModel> GetSimpleDataByDept(int deptCode, DateTime searchdate)
        {
            string dept = deptName[deptCode];

            var orderList = GetSimpleData();

            if (dept != "資訊中心")
                return orderList.Where(m => m.ITDept == dept)
                                .Where(m => (m.ExpectStartDate.Date < searchdate.AddYears(1).Date || (m.ExpectStartDate.Year == searchdate.AddYears(1).Year && m.ExpectStartDate.Month == searchdate.AddYears(1).Month)))
                                .ToList();
            else
                return orderList.Where(m => (m.ExpectStartDate.Date < searchdate.AddYears(1).Date || (m.ExpectStartDate.Year == searchdate.AddYears(1).Year && m.ExpectStartDate.Month == searchdate.AddYears(1).Month)))
                                .ToList();

            //return orderList;
        }

        public List<SimpleOrderViewModel> GetSimpleDataSearchDate(DateTime searchdate)
        {
            var orderList = GetSimpleData();

            return orderList.Where(m => (m.ExpectStartDate.Date < searchdate.AddYears(1).Date || (m.ExpectStartDate.Year == searchdate.AddYears(1).Year && m.ExpectStartDate.Month == searchdate.AddYears(1).Month)))
                            .ToList();
        }

        public List<SimpleOrderViewModel> GetSimpleDataByDeptAndMonth(int deptCode, DateTime searchdate)
        {
            string dept = deptName[deptCode];

            var orderList = GetSimpleData();

            if (dept != "資訊中心")
                return orderList.Where(m => m.ITDept == dept)
                                .Where(m => (m.ExpectStartDate.Year == searchdate.Year && m.ExpectStartDate.Month == searchdate.Month))
                                .ToList();
            else
                return orderList.Where(m => (m.ExpectStartDate.Year == searchdate.Year && m.ExpectStartDate.Month == searchdate.Month))
                                .ToList();
        }

        public List<SimpleOrderViewModel> GetFakeData()
        {
            List<SimpleOrderViewModel> orderList = new List<SimpleOrderViewModel>();

            orderList.Add(new SimpleOrderViewModel
            {
                OrderID = string.Format("{0}", 1000),
                ITDept = "資訊規劃部",
                ApplyDept = "人資部",
                State = "受理",
                ClassName = "分類一",
                ExpectStartDate = DateTime.Now
            });

            orderList.Add(new SimpleOrderViewModel
            {
                OrderID = string.Format("{0}", 1001),
                ITDept = "數位資訊部",
                ApplyDept = "人資部",
                State = "受理",
                ClassName = "分類一",
                ExpectStartDate = DateTime.Now.AddMonths(-3)
            });

            orderList.Add(new SimpleOrderViewModel
            {
                OrderID = string.Format("{0}", 1002),
                ITDept = "壽險資訊部",
                ApplyDept = "人資部",
                State = "受理",
                ClassName = "分類一",
                ExpectStartDate = DateTime.Now.AddMonths(-3)
            });

            orderList.Add(new SimpleOrderViewModel
            {
                OrderID = string.Format("{0}", 1003),
                ITDept = "投資資訊部",
                ApplyDept = "人資部",
                State = "結案",
                ClassName = "分類一",
                ExpectStartDate = DateTime.Now
            });

            orderList.Add(new SimpleOrderViewModel
            {
                OrderID = string.Format("{0}", 1004),
                ITDept = "資訊規劃部",
                ApplyDept = "人資部",
                State = "受理",
                ClassName = "分類一",
                ExpectStartDate = DateTime.Now
            });

            orderList.Add(new SimpleOrderViewModel
            {
                OrderID = string.Format("{0}", 1005),
                ITDept = "資訊規劃部",
                ApplyDept = "人資部",
                State = "受理",
                ClassName = "分類一",
                ExpectStartDate = DateTime.Now.AddMonths(-5)
            });

            orderList.Add(new SimpleOrderViewModel
            {
                OrderID = string.Format("{0}", 1006),
                ITDept = "資訊規劃部",
                ApplyDept = "人資部",
                State = "結案",
                ClassName = "分類一",
                ExpectStartDate = DateTime.Now.AddMonths(-8)
            });

            orderList.Add(new SimpleOrderViewModel
            {
                OrderID = string.Format("{0}", 1007),
                ITDept = "資訊規劃部",
                ApplyDept = "人資部",
                State = "結案",
                ClassName = "分類一",
                ExpectStartDate = DateTime.Now.AddMonths(-7)
            });

            orderList.Add(new SimpleOrderViewModel
            {
                OrderID = string.Format("{0}", 1008),
                ITDept = "資訊規劃部",
                ApplyDept = "人資部",
                State = "受理",
                ClassName = "分類一",
                ExpectStartDate = DateTime.Now
            });

            orderList.Add(new SimpleOrderViewModel
            {
                OrderID = string.Format("{0}", 1009),
                ITDept = "資訊規劃部",
                ApplyDept = "人資部",
                State = "受理",
                ClassName = "分類一",
                ExpectStartDate = DateTime.Now
            });

            orderList.Add(new SimpleOrderViewModel
            {
                OrderID = string.Format("{0}", 1010),
                ITDept = "壽險資訊部",
                ApplyDept = "人資部",
                State = "受理",
                ClassName = "分類一",
                ExpectStartDate = DateTime.Now.AddMonths(-7)
            });

            orderList.Add(new SimpleOrderViewModel
            {
                OrderID = string.Format("{0}", 1011),
                ITDept = "壽險資訊部",
                ApplyDept = "人資部",
                State = "受理",
                ClassName = "分類一",
                ExpectStartDate = DateTime.Now.AddMonths(-7)
            });

            orderList.Add(new SimpleOrderViewModel
            {
                OrderID = string.Format("{0}", 1012),
                ITDept = "壽險資訊部",
                ApplyDept = "人資部",
                State = "受理",
                ClassName = "分類一",
                ExpectStartDate = DateTime.Now.AddMonths(-7)
            });

            return orderList;
        }

        public List<SimpleOrderViewModel> GetDatasByMonth(DateTime fromdate, DateTime searchdate, string state)
        {
            List<SimpleOrderViewModel> dataList;

            switch (state)
            {
                case "受理":
                    dataList = GetSimpleData().Where(model => (model.ExpectStartDate.Year == searchdate.Year && model.ExpectStartDate.Month == searchdate.Month))
                                            .OrderBy(model => model.ExpectStartDate)
                                            .ToList();
                    break;
                case "結案":
                    dataList = GetSimpleData().Where(model => (model.ExpectStartDate.Year == searchdate.Year && model.ExpectStartDate.Month == searchdate.Month))
                                            .Where(model => model.State == "結案")
                                            .OrderBy(model => model.ExpectStartDate)
                                            .ToList();

                    break;
                case "未完成":
                    dataList = GetSimpleData().Where(model => (model.ExpectStartDate.Year == searchdate.Year && model.ExpectStartDate.Month == searchdate.Month))
                                            .Where(model => model.State != "結案")
                                            .OrderBy(model => model.ExpectStartDate)
                                            .ToList();

                    break;
                case "累計未完成":
                    dataList = GetSimpleData().Where(model => model.ExpectStartDate.Date < searchdate.Date || (model.ExpectStartDate.Month == fromdate.Month && model.ExpectStartDate.Year == fromdate.Year))
                                              .Where(model => (model.ExpectStartDate.Date > fromdate.Date || (model.ExpectStartDate.Month == fromdate.Month && model.ExpectStartDate.Year == fromdate.Year)))
                                              .Where(model => model.State != "結案")
                                              .OrderBy(model => model.ExpectStartDate)
                                              .ToList();

                    break;
                default:
                    dataList = GetSimpleData().Where(model => (model.ExpectStartDate.Year == searchdate.Year && model.ExpectStartDate.Month == searchdate.Month))
                                              .OrderBy(model => model.ExpectStartDate)
                                              .ToList();
                    break;
            }

            return dataList;
            //return null;
        }

        //月份 狀態 部門
        public List<SimpleOrderViewModel> GetDatasByMonthAndStateAndDept(DateTime searchdate, string state, int deptcode)
        {
            List<SimpleOrderViewModel> dataList = GetSimpleData();

            string dept = deptName[deptcode];

            switch (state)
            {
                case "受理":
                    dataList = dataList.Where(model => (model.ExpectStartDate.Year == searchdate.Year && model.ExpectStartDate.Month == searchdate.Month))
                                            .OrderBy(model => model.ExpectStartDate)
                                            .ToList();
                    break;
                case "結案":
                    dataList = dataList.Where(model => (model.ExpectStartDate.Year == searchdate.Year && model.ExpectStartDate.Month == searchdate.Month))
                                            .Where(model => model.State == "結案")
                                            .OrderBy(model => model.ExpectStartDate)
                                            .ToList();

                    break;
                case "未完成":
                    dataList = dataList.Where(model => (model.ExpectStartDate.Year == searchdate.Year && model.ExpectStartDate.Month == searchdate.Month))
                                            .Where(model => model.State != "結案")
                                            .OrderBy(model => model.ExpectStartDate)
                                            .ToList();

                    break;
                //從以前到現在的資料
                case "累計未完成":
                    dataList = dataList.Where(model => model.ExpectStartDate.Date < searchdate.Date || (model.ExpectStartDate.Year == searchdate.Year && model.ExpectStartDate.Month == searchdate.Month))
                                              .Where(model => model.State != "結案")
                                              .OrderBy(model => model.ExpectStartDate)
                                              .ToList();

                    break;
                default:
                    dataList = dataList.Where(model => (model.ExpectStartDate.Year == searchdate.Year && model.ExpectStartDate.Month == searchdate.Month))
                                              .OrderBy(model => model.ExpectStartDate)
                                              .ToList();
                    break;
            }

            //沒有資訊中心這個分類
            if(dept != "資訊中心")
            {
                dataList = dataList.Where(model => model.ITDept == dept).ToList();
            }
            

            return dataList;
            //return null;
        }

        public OrderViewModel FindOrderById(string orderId)
        {
            DBService _db = new DBService();

            var order = _db.FindOrderById(orderId);

            var orderDetail = order;

            return orderDetail;
        }

        public bool OrderUpdate(OrderViewModel order)
        {
            DBService _db = new DBService();

            _db.OrderUpdate(order);

            return true;
        }

        public List<SimpleOrderViewModel> GetDatasByMonth(DateTime searchdate)
        {
            List<SimpleOrderViewModel> dataList;

            dataList = GetSimpleData().Where(model => (model.ExpectStartDate.Year == searchdate.Year && model.ExpectStartDate.Month == searchdate.Month)).ToList();

            return dataList;
            //return null;
        }

        public List<StateCountViewModel> GetStateList()
        {
            List<StateCountViewModel> list = new List<StateCountViewModel>();

            var orderList = GetFakeData().OrderBy(model => model.ExpectStartDate);

            for(int i=0;i<4; i++)
            {
                string state="";
                for(int j = -11; j <= 0; j++)
                {
                    StateCountViewModel tempStateCount = new StateCountViewModel();

                    switch (i)
                    {
                        case 0:
                            state = "受理";

                            tempStateCount.state = state;

                            tempStateCount.count = orderList.Where(model => model.ExpectStartDate.Month == DateTime.Now.AddMonths(j).Month)
                                                            .Count();

                            break;
                        case 1:
                            state = "結案";

                            tempStateCount.state = state;

                            tempStateCount.count = orderList.Where(model => model.State == state)
                                                            .Where(model => model.ExpectStartDate.Month == DateTime.Now.AddMonths(j).Month)
                                                            .Count();

                            break;
                        case 2:
                            state = "未完成";

                            tempStateCount.state = state;

                            tempStateCount.count = orderList.Where(model => model.State != "結案")
                                                            .Where(model => model.ExpectStartDate.Month == DateTime.Now.AddMonths(j).Month)
                                                            .Count();

                            break;
                        case 3:
                            state = "累計未完成";

                            tempStateCount.state = state;

                            tempStateCount.count = orderList.Where(model => model.State != "結案")
                                                            .Where(model => model.ExpectStartDate.Date < DateTime.Now.AddMonths(i).Date)
                                                            .Count();

                            break;
                    }

                    tempStateCount.month = DateTime.Now.AddMonths(j).Month;

                    list.Add(tempStateCount);
                }
            }

            return list;

        }

        public List<SimpleOrderViewModel> GetFakeDataByDept(int deptCode, DateTime searchdate)
        {
            string dept = deptName[deptCode];

            var orderList = GetFakeData();

            var overAYear = (DateTime.Now - searchdate).Days > 365 ? true : false;

            if (dept != "資訊中心")
                return orderList.Where(m => m.ITDept == dept)
                                .Where(m => (m.ExpectStartDate.Ticks >= searchdate.Ticks || (m.ExpectStartDate.Year == searchdate.Year && m.ExpectStartDate.Month == searchdate.Month)))
                                .ToList();
            else
                return orderList.Where(m => (m.ExpectStartDate.Ticks >= searchdate.Ticks || (m.ExpectStartDate.Year == searchdate.Year && m.ExpectStartDate.Month == searchdate.Month)))
                                .ToList();

            //if (!overAYear)
            //{
            //    if (dept != "資訊中心")
            //        return orderList.Where(m => m.ITDept == dept)
            //                        .Where(m => (m.ExpectStartDate.Ticks >= searchdate.Ticks || (m.ExpectStartDate.Year == searchdate.Year && m.ExpectStartDate.Month == searchdate.Month)))
            //                        .ToList();
            //    else
            //        return orderList.Where(m => (m.ExpectStartDate.Ticks >= searchdate.Ticks || (m.ExpectStartDate.Year == searchdate.Year && m.ExpectStartDate.Month == searchdate.Month)))
            //                        .ToList();
            //}
            //else
            //{
            //    if (dept != "資訊中心")
            //    {
            //        return orderList.Where(m => m.ITDept == dept)
            //                        .Where(m => (m.ExpectStartDate.Ticks >= searchdate.Ticks || (m.ExpectStartDate.Year == searchdate.Year && m.ExpectStartDate.Month == searchdate.Month)))
            //                        .Where(m => (m.ExpectStartDate.Date < searchdate.AddYears(1).Date && (m.ExpectStartDate.Year != searchdate.AddYears(1).Year && m.ExpectStartDate.Month != searchdate.AddYears(1).Month)))
            //                        .ToList();
            //    }
            //    else
            //    {
            //        return orderList.Where(m => (m.ExpectStartDate.Ticks >= searchdate.Ticks || (m.ExpectStartDate.Year == searchdate.Year && m.ExpectStartDate.Month == searchdate.Month)))
            //                        .Where(m => (m.ExpectStartDate.Date < searchdate.AddYears(1).Date && (m.ExpectStartDate.Year != searchdate.AddYears(1).Year && m.ExpectStartDate.Month != searchdate.AddYears(1).Month)))
            //                        .ToList();
            //    }
            //}
        }

        public List<StateCountViewModel> GetFakeStateByDept(int deptCode, DateTime searchdate)
        {
            string dept = deptName[deptCode];

            var orderList = GetFakeData();

            List<StateCountViewModel> stateList = new List<StateCountViewModel>();

            for(int i = 0; i < 4; i++)
            {
                string state = "";

                StateCountViewModel tempStateCount = new StateCountViewModel();

                for(int j = -11; j <= 0; j++)
                {
                    switch (i)
                    {
                        case 0:
                            state = "受理";

                            tempStateCount.state = state;

                            tempStateCount.count = orderList.Where(model => model.ITDept == dept)
                                                            .Where(model => model.ExpectStartDate.Month == DateTime.Now.AddMonths(j).Month)
                                                            .Count();

                            break;
                        case 1:
                            state = "結案";

                            tempStateCount.state = state;

                            tempStateCount.count = orderList.Where(model => model.ITDept == dept)
                                                            .Where(model => model.State == state)
                                                            .Where(model => model.ExpectStartDate.Month == DateTime.Now.AddMonths(j).Month)
                                                            .Count();

                            break;
                        case 2:
                            state = "未完成";

                            tempStateCount.state = state;

                            tempStateCount.count = orderList.Where(model => model.ITDept == dept)
                                                            .Where(model => model.State != "結案")
                                                            .Where(model => model.ExpectStartDate.Month == DateTime.Now.AddMonths(j).Month)
                                                            .Count();

                            break;
                        case 3:
                            state = "累計未完成";

                            tempStateCount.state = state;

                            tempStateCount.count = orderList.Where(model => model.ITDept == dept)
                                                            .Where(model => model.State != "結案")
                                                            .Where(model => model.ExpectStartDate.Date < DateTime.Now.AddMonths(i).Date)
                                                            .Count();

                            break;
                    }

                    tempStateCount.month = DateTime.Now.AddMonths(j).Month;

                }

                stateList.Add(tempStateCount);

            }

            return stateList;

        }
    }
}