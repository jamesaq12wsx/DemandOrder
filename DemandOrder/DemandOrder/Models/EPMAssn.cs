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
    
    public partial class EPMAssn
    {
        public System.Guid EPM_ASSN_UID { get; set; }
        public string EPM_ASSN_NAME { get; set; }
        public string EPM_ASSN_WBS { get; set; }
        public Nullable<System.DateTime> EPM_ASSN_START { get; set; }
        public Nullable<System.DateTime> EPM_ASSN_FINISH { get; set; }
        public string EPM_TIME_CODE { get; set; }
        public System.Guid RES_UID { get; set; }
        public System.Guid PROJ_UID { get; set; }
        public Nullable<decimal> PLAN_WH { get; set; }
        public Nullable<decimal> PLAN_WH_BS0 { get; set; }
        public Nullable<decimal> PLAN_WH_BS6 { get; set; }
        public Nullable<System.DateTime> PLAN_START_BS6 { get; set; }
        public Nullable<System.DateTime> PLAN_FINISH_BS6 { get; set; }
        public Nullable<System.DateTime> ACT_START { get; set; }
        public Nullable<System.DateTime> ACT_FINISH { get; set; }
        public Nullable<bool> DELETED_IN_PROJ { get; set; }
    }
}
