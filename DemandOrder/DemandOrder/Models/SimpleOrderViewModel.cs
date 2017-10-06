using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DemandOrder.Models
{
    public class SimpleOrderViewModel
    {
        [DisplayName("需求單編號")]
        public string OrderID { get; set; }

        [DisplayName("需求單主旨")]
        public string OrderName { get; set; }

        [DisplayName("申請人部室")]
        public string ApplyDept { get; set; }

        [DisplayName("資訊部室")]
        public string ITDept { get; set; }

        [DisplayName("狀態")]
        public string State { get; set; }

        [DisplayName("預計開始日")]
        public DateTime ExpectStartDate { get; set; }

        [DisplayName("結案日期")]
        public DateTime? CloseDate { get; set; }

        [DisplayName("分類名稱")]
        public string ClassName { get; set; }

    }
}