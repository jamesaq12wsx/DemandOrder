﻿using DemandOrder.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DemandOrder.Service
{
    public class DBService
    {
        //private RequireSystemEntities _db = new RequireSystemEntities();

        public IQueryable<OrderViewModel> getSummaryTable()
        {
            RequireSystemEntities _db = new RequireSystemEntities();

            var viewREQ = from rh in _db.RequestHandler
                          join ite in _db.ITEmployee on rh.EmpID equals ite.EmpID into rh2
                          from ite in rh2.DefaultIfEmpty()
                          where string.Compare(rh.ReqID, "RE2009") > 0 && rh.IsRequestOwner == "1" && rh.IsEnabled == "1"
                          select new
                          {
                              ReqID = rh.ReqID,
                              EmpID = rh.EmpID,
                              EmpChiName = ite.EmpChiName,
                              UnitChiName = ite.UnitChiName,
                              DeptChiName = ite.DeptChiName,
                              IsRequestOwner = rh.IsRequestOwner,
                              IsEnabled = rh.IsEnabled
                          };
            string[] not_in = { "RE200900036", "RE200900102", "RE200900107", "RE200900167", "RE200900176", "RE200900245", "RE200900357",
                                "RE200900387", "RE200900452", "RE200900467", "RE200900496", "RE200900503", "RE200900588", "RE200900682",
                                "RE200900699", "RE200900803", "RE200900892", "RE200900895", "RE200901023", "RE200901076", "RE200901096",
                                "RE200901135","RE200901202","RE200901256","RE200901533","RE200901541","RE200901547","RE200901640",
                                "RE200901702","RE200901761","RE200901771","RE200901828","RE200901834","RE200901847","RE200901881",
                                "RE200902066","RE200902156","RE200902189","RE200902205","RE200902309","RE200902330","RE200902373",
                                "RE200902385","RE200902400","RE200902551","RE200902617","RE200902753","RE200902829","RE200903136",
                                "RE201002639"
            };


            IQueryable<OrderViewModel> queryable = from REQ in _db.Request
                                                   join p in _db.Project on REQ.MAProjectID equals p.PrjID into REQ2
                                                   from p in REQ2.DefaultIfEmpty()
                                                   join app in _db.ApplicantInfo on REQ.ReqID equals app.ReqID into REQ3
                                                   from app in REQ3.DefaultIfEmpty()
                                                   join rt in _db.RequestType on REQ.AcceptType equals rt.TypeSN into REQ4
                                                   from rt in REQ4.DefaultIfEmpty()
                                                   join vREQ in viewREQ on REQ.ReqID equals vREQ.ReqID into REQ5
                                                   from vREQ in REQ5.DefaultIfEmpty()
                                                   where REQ.EstimateAcceptDate.HasValue && string.Compare(REQ.ReqID, "RE200900000") > 0 && (REQ.ReqStatus.Substring(0,1)=="3"
                                                   || (new string[] { "4", "5", "7" }).Contains(REQ.ReqStatus)) && REQ.FormType == "1" 
                                                   && REQ.ITDept != "11J000" && !not_in.Contains(REQ.ReqID)
                                                   orderby app.DeptChiName, app.UnitChiName, app.EmpChiName
                                                   select new OrderViewModel()
                                                   {
                                                       ApplyDept = app.DeptChiName,
                                                       ApplySec = app.UnitChiName,
                                                       Applicant = app.EmpChiName,
                                                       OrderID = REQ.ReqID,
                                                       OrderName = REQ.ReqSubject,
                                                       ITDept =
                                                       (
                                                          REQ.ITDept == "106000" ? "壽險資訊部" :
                                                          REQ.ITDept == "12D000" ? "投資資訊部" :
                                                          REQ.ITDept == "11L000" ? "數位資訊部" :
                                                          REQ.ITDept == "13D000" ? "資訊規劃部" :
                                                          REQ.ITDept == "11J000" ? "資訊系統部" : ""

                                                       ),
                                                       State =
                                                       (
                                                          (DbFunctions.Left(REQ.ReqStatus, 1)) == "5" ? "結案" :
                                                          (DbFunctions.Left(REQ.ReqStatus, 1)) == "3" ? "受理" :
                                                          (DbFunctions.Left(REQ.ReqStatus, 1)) == "4" ? "驗收" :
                                                          (DbFunctions.Left(REQ.ReqStatus, 1)) == "7" ? "收件完成" : ""
                                                       ),
                                                       ExpectCompleteDate = REQ.ExpectedFinishedDate,
                                                       ExpectRecieveDate = REQ.EstimateAcceptDate,
                                                       ExpectStartDate = REQ.PlannedStartDate,
                                                       ExpectFinishDate = REQ.PlannedEndDate,
                                                       AcceptionTestStartDate = REQ.AcceptStartDate,
                                                       AcceptionTestFinishDate = REQ.AcceptEndDate,
                                                       CaseCloseDate = REQ.ReqCloseDate,
                                                       MaintainLine = p.PrjName,
                                                       MaintainITDept = vREQ.DeptChiName,
                                                       MaintainITSec = vREQ.UnitChiName,
                                                       DemandDutyPerson = vREQ.EmpChiName,
                                                       ClassNo = rt.TypeID,
                                                       ClassName = rt.TypeLable
                                                   };





            return queryable;


        }

        public OrderViewModel FindOrderById(string orderId)
        {
            RequireSystemEntities _db = new RequireSystemEntities();

            var viewREQ = from rh in _db.RequestHandler
                          join ite in _db.ITEmployee on rh.EmpID equals ite.EmpID into rh2
                          from ite in rh2.DefaultIfEmpty()
                          where string.Compare(rh.ReqID, "RE2009") > 0 && rh.IsRequestOwner == "1" && rh.IsEnabled == "1"
                          select new
                          {
                              ReqID = rh.ReqID,
                              EmpID = rh.EmpID,
                              EmpChiName = ite.EmpChiName,
                              UnitChiName = ite.UnitChiName,
                              DeptChiName = ite.DeptChiName,
                              IsRequestOwner = rh.IsRequestOwner,
                              IsEnabled = rh.IsEnabled
                          };
            string[] not_in = { "RE200900036", "RE200900102", "RE200900107", "RE200900167", "RE200900176", "RE200900245", "RE200900357",
                                "RE200900387", "RE200900452", "RE200900467", "RE200900496", "RE200900503", "RE200900588", "RE200900682",
                                "RE200900699", "RE200900803", "RE200900892", "RE200900895", "RE200901023", "RE200901076", "RE200901096",
                                "RE200901135","RE200901202","RE200901256","RE200901533","RE200901541","RE200901547","RE200901640",
                                "RE200901702","RE200901761","RE200901771","RE200901828","RE200901834","RE200901847","RE200901881",
                                "RE200902066","RE200902156","RE200902189","RE200902205","RE200902309","RE200902330","RE200902373",
                                "RE200902385","RE200902400","RE200902551","RE200902617","RE200902753","RE200902829","RE200903136",
                                "RE201002639"
            };


            IQueryable<OrderViewModel> queryable = from REQ in _db.Request
                                                   join p in _db.Project on REQ.MAProjectID equals p.PrjID into REQ2
                                                   from p in REQ2.DefaultIfEmpty()
                                                   join app in _db.ApplicantInfo on REQ.ReqID equals app.ReqID into REQ3
                                                   from app in REQ3.DefaultIfEmpty()
                                                   join rt in _db.RequestType on REQ.AcceptType equals rt.TypeSN into REQ4
                                                   from rt in REQ4.DefaultIfEmpty()
                                                   join vREQ in viewREQ on REQ.ReqID equals vREQ.ReqID into REQ5
                                                   from vREQ in REQ5.DefaultIfEmpty()
                                                   where REQ.EstimateAcceptDate.HasValue && string.Compare(REQ.ReqID, "RE200900000") > 0 && (REQ.ReqStatus.Substring(0, 1) == "3"
                                                   || (new string[] { "4", "5", "7" }).Contains(REQ.ReqStatus)) && REQ.FormType == "1"
                                                   && REQ.ITDept != "11J000" && !not_in.Contains(REQ.ReqID)
                                                   orderby app.DeptChiName, app.UnitChiName, app.EmpChiName
                                                   select new OrderViewModel()
                                                   {
                                                       ApplyDept = app.DeptChiName,
                                                       ApplySec = app.UnitChiName,
                                                       Applicant = app.EmpChiName,
                                                       OrderID = REQ.ReqID,
                                                       OrderName = REQ.ReqSubject,
                                                       ITDept =
                                                       (
                                                          REQ.ITDept == "106000" ? "壽險資訊部" :
                                                          REQ.ITDept == "12D000" ? "投資資訊部" :
                                                          REQ.ITDept == "11L000" ? "數位資訊部" :
                                                          REQ.ITDept == "13D000" ? "資訊規劃部" :
                                                          REQ.ITDept == "11J000" ? "資訊系統部" : ""

                                                       ),
                                                       State =
                                                       (
                                                          (DbFunctions.Left(REQ.ReqStatus, 1)) == "5" ? "結案" :
                                                          (DbFunctions.Left(REQ.ReqStatus, 1)) == "3" ? "受理" :
                                                          (DbFunctions.Left(REQ.ReqStatus, 1)) == "4" ? "驗收" :
                                                          (DbFunctions.Left(REQ.ReqStatus, 1)) == "7" ? "收件完成" : ""
                                                       ),
                                                       ExpectCompleteDate = REQ.ExpectedFinishedDate,
                                                       ExpectRecieveDate = REQ.EstimateAcceptDate,
                                                       ExpectStartDate = REQ.PlannedStartDate,
                                                       ExpectFinishDate = REQ.PlannedEndDate,
                                                       AcceptionTestStartDate = REQ.AcceptStartDate,
                                                       AcceptionTestFinishDate = REQ.AcceptEndDate,
                                                       CaseCloseDate = REQ.ReqCloseDate,
                                                       MaintainLine = p.PrjName,
                                                       MaintainITDept = vREQ.DeptChiName,
                                                       MaintainITSec = vREQ.UnitChiName,
                                                       DemandDutyPerson = vREQ.EmpChiName,
                                                       ClassNo = rt.TypeID,
                                                       ClassName = rt.TypeLable
                                                   };





            //return queryable.Where(model => string.Compare(model.OrderID,orderId) == 0).ToList();

            return queryable.SingleOrDefault(model => string.Compare(model.OrderID, orderId) == 0);
        }

        public bool OrderUpdate(OrderViewModel order)
        {
            RequireSystemEntities _db = new RequireSystemEntities();

            Request reqDetail = _db.Request.SingleOrDefault(model => string.Compare(model.ReqID, order.OrderID) == 0);

            string state = string.Compare(order.State, "結案") == 0 ? "5" :
                           string.Compare(order.State, "受理") == 0 ? "3" :
                           string.Compare(order.State, "驗收") == 0 ? "4" :
                           string.Compare(order.State, "受理完成") == 0 ? "7" : "3";

            reqDetail.ReqStatus = state;

            if(state == "5")
            {
                reqDetail.ReqCloseDate = DateTime.Now.Date;
            }
            else if(state != "5")
            {
                reqDetail.ReqCloseDate = null;
            }

            //_db.Entry(reqDetail).State = EntityState.Modified;

            _db.SaveChanges();

            _db.Dispose();

            return true;
        }

        
    }
}