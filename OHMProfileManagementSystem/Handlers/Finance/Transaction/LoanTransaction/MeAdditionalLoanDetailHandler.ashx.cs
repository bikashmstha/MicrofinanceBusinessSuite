﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.Finance.Transaction.LoanTransaction;
using MicrofinanceBusinessSuite.Controllers.Finance.Transaction.LoanTransaction;
using MicrofinanceBusinessSuite.Utility;

namespace MicrofinanceBusinessSuite.Handlers.Finance.Transaction.LoanTransaction
{
    /// <summary>
    /// Summary description for MeAdditionalLoanDetailHandler
    /// </summary>
    public class MeAdditionalLoanDetailHandler : BaseHandler
    {
        private static MeAdditionalLoanDetailController controller = new MeAdditionalLoanDetailController();
        public object Get()
        {
            ExtJSResponse resp = new ExtJSResponse();

            OutMessage oMsg = (OutMessage)controller.Get();
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object Save(string meAdditionalLoanDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            MeAdditionalLoanDetail obj = (new JavaScriptSerializer().Deserialize(meAdditionalLoanDetail, typeof(MeAdditionalLoanDetail))) as MeAdditionalLoanDetail;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.Save(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object Search(string meAdditionalLoanDetail)
        {
            ExtJSResponse resp = new ExtJSResponse();
            MeAdditionalLoanDetail search = (new JavaScriptSerializer().Deserialize(meAdditionalLoanDetail, typeof(MeAdditionalLoanDetail))) as MeAdditionalLoanDetail;
            OutMessage oMsg = (OutMessage)controller.Search(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object GetMeAdditionalLoanDetail(string offCode, string clientName, string loanNo, string dateFrom, string dateTo)
        {

            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetMeAdditionalLoanDetail(offCode, clientName, loanNo, dateFrom, dateTo);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);

        }
    }
}