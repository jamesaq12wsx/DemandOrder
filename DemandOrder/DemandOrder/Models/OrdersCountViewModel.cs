using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemandOrder.Models
{
    public class OrdersCountViewModel
    {
        private readonly List<DepartmentName> _deptName = new List<DepartmentName>{
        new DepartmentName { Id = 0, Name = "資訊中心" },
        new DepartmentName { Id =1, Name ="數位資訊部"},
        new DepartmentName{Id=2, Name="資訊系統部" },
        new DepartmentName{Id=3, Name="投資資訊部" },
        new DepartmentName{ Id=4, Name="壽險資訊部"} };

        public List<SimpleOrderViewModel> Orders;

        public IEnumerable<SelectListItem> DeptList
        {
            get { return new SelectList(_deptName, "Id", "Name"); }
        }
    }

    public class DepartmentName
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}