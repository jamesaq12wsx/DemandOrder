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
    
    public partial class TimesheetRes
    {
        public int TIMESHEET_RES_ID { get; set; }
        public string DEPT_NAME { get; set; }
        public string DEPT_CODE { get; set; }
        public string SECTION_NAME { get; set; }
        public string SECTION_CODE { get; set; }
        public string EMP_NAME { get; set; }
        public string EMP_ID { get; set; }
        public string EMP_NO { get; set; }
        public string EMP_AD_ACCT { get; set; }
        public System.DateTime EMP_DATE { get; set; }
        public Nullable<System.Guid> RES_UID { get; set; }
    }
}