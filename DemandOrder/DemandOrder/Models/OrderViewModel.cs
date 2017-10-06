using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DemandOrder.Models
{
    public class OrderViewModel
    {
        [DisplayName("需求單編號")]
        public string OrderID { get; set; }

        [DisplayName("申請人部室")]
        public string ApplyDept { get; set; }

        [DisplayName("申請人課別")]
        public string ApplySec { get; set; }

        [DisplayName("申請人")]
        public string Applicant { get; set; }

        [DisplayName("需求單主旨")]
        public string OrderName { get; set; }

        [DisplayName("資訊部室")]
        public string ITDept { get; set; }

        [DisplayName("狀態")]
        public string State { get; set; }

        [DisplayName("期望完成日")]
        public DateTime? ExpectCompleteDate { get; set; }

        [DisplayName("評估收件日")]
        public DateTime? ExpectRecieveDate { get; set; }

        [DisplayName("預計開始日")]
        public DateTime? ExpectStartDate { get; set; }

        [DisplayName("預計結束日")]
        public DateTime? ExpectFinishDate { get; set; }

        [DisplayName("驗收開始日")]
        public DateTime? AcceptionTestStartDate { get; set; }

        [DisplayName("驗收結束日")]
        public DateTime? AcceptionTestFinishDate { get; set; }

        [DisplayName("結案日")]
        public DateTime? CaseCloseDate { get; set; }

        [DisplayName("維護案或業務線別")]
        public string MaintainLine { get; set; }

        [DisplayName("維護資訊室")]
        public string MaintainITDept { get; set; }

        [DisplayName("資訊課")]
        public string MaintainITSec { get; set; }

        [DisplayName("需求單負責人")]
        public string DemandDutyPerson { get; set; }

        [DisplayName("分類名稱(編號)")]
        public string ClassNo { get; set; }

        [DisplayName("分類中文(名稱)")]
        public string ClassName { get; set; }

    }
}