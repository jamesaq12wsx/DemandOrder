using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemandOrder.Models
{
    public class OrderLibrary
    {
        public string[] deptName = new string[] { "資訊中心", "數位資訊部", "資訊系統部", "投資資訊部", "壽險資訊部" };

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
                State = "完成",
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
                State = "完成",
                ClassName = "分類一",
                ExpectStartDate = DateTime.Now.AddMonths(-8)
            });

            orderList.Add(new SimpleOrderViewModel
            {
                OrderID = string.Format("{0}", 1007),
                ITDept = "資訊規劃部",
                ApplyDept = "人資部",
                State = "完成",
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

        public List<SimpleOrderViewModel> GetFakeDataByDept(int deptCode)
        {
            string dept = deptName[deptCode];

            var orderList = GetFakeData();

            if (dept != "資訊中心")
                return orderList.Where(m => m.ITDept == dept).ToList();
            else
                return orderList;
        }
    }
}