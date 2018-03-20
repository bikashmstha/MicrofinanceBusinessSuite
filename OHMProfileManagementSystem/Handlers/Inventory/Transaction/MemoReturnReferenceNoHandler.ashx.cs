using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.Inventory.Transaction;
using MicrofinanceBusinessSuite.Controllers.Inventory.Transaction;
using MicrofinanceBusinessSuite.Utility;


namespace MicrofinanceBusinessSuite.Handlers.Inventory.Transaction
{
    /// <summary>
    /// Summary description for MemoReturnReferenceNoHandler
    /// </summary>
    public class MemoReturnReferenceNoHandler : BaseHandler
    {
        private static MemoReturnReferenceNoController controller = new MemoReturnReferenceNoController();


        public object SaveMemoReturnReferenceNo(string memoreturnReferenceNo)
        {
            ExtJSResponse resp = new ExtJSResponse();
            MemoReturnReferenceNo obj = (new JavaScriptSerializer().Deserialize(memoreturnReferenceNo, typeof(MemoReturnReferenceNo))) as MemoReturnReferenceNo;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveMemoReturnReferenceNo(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchMemoReturnReferenceNo(string memoreturnReferenceNo)
        {
            ExtJSResponse resp = new ExtJSResponse();
            MemoReturnReferenceNo search = (new JavaScriptSerializer().Deserialize(memoreturnReferenceNo, typeof(MemoReturnReferenceNo))) as MemoReturnReferenceNo;
            OutMessage oMsg = (OutMessage)controller.SearchMemoReturnReferenceNo(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GetMemoReturnRefNo(string ReferenceNo)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GetMemoReturnRefNo(ReferenceNo);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}