//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace DemandOrder.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class EPMReportingTime
    {
        public int idx { get; set; }
        public string ReqID { get; set; }
        public string PrjID { get; set; }
        public string EmpID { get; set; }
        public string TimesheetCode { get; set; }
        public Nullable<decimal> ActualWorkHrs { get; set; }
        public Nullable<decimal> PlanWorkHrs { get; set; }
    }
}
