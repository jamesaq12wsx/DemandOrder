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
    
    public partial class EPMTimesheetWH
    {
        public int EPM_WORK_HOUR_ID { get; set; }
        public Nullable<System.DateTime> WORK_DATE { get; set; }
        public Nullable<int> TIMESHEET_RES_ID { get; set; }
        public string REQ_ID { get; set; }
        public string TASK_NAME { get; set; }
        public Nullable<decimal> PLAN_WH { get; set; }
        public Nullable<decimal> PLAN_WH_BS0 { get; set; }
        public Nullable<decimal> PLAN_WH_BS6 { get; set; }
        public Nullable<decimal> ACT_WH { get; set; }
        public Nullable<System.Guid> PROJ_UID { get; set; }
        public Nullable<System.Guid> SYS_UID { get; set; }
        public Nullable<System.Guid> ASSN_UID { get; set; }
        public Nullable<System.Guid> RES_UID { get; set; }
        public string TIME_CODE { get; set; }
        public Nullable<int> TIME_CODE_PUBLISHED_ID { get; set; }
    }
}
