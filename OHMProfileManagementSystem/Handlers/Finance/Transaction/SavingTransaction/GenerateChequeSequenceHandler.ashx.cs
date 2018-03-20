using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.Finance.Transaction.SavingTransaction;
using MicrofinanceBusinessSuite.Controllers.Finance.Transaction.SavingTransaction;
using MicrofinanceBusinessSuite.Utility;


namespace MicrofinanceBusinessSuite.Handlers.Finance.Transaction.SavingTransaction
{
    /// <summary>
    /// Summary description for GenerateChequeSequenceHandler
    /// </summary>
    public class GenerateChequeSequenceHandler : BaseHandler
    {
        private static GenerateChequeSequenceController controller = new GenerateChequeSequenceController();
        public object Get()
        {
            ExtJSResponse resp = new ExtJSResponse();

            OutMessage oMsg = (OutMessage)controller.Get();
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object Save(string generateChequeSequence)
        {
            ExtJSResponse resp = new ExtJSResponse();
            GenerateChequeSequence obj = (new JavaScriptSerializer().Deserialize(generateChequeSequence, typeof(GenerateChequeSequence))) as GenerateChequeSequence;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.Save(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object Search(string generateChequeSequence)
        {
            ExtJSResponse resp = new ExtJSResponse();
            GenerateChequeSequence search = (new JavaScriptSerializer().Deserialize(generateChequeSequence, typeof(GenerateChequeSequence))) as GenerateChequeSequence;
            OutMessage oMsg = (OutMessage)controller.Search(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        public object GenerateChequeSequence(string generateChequeSequence)
        {
            ExtJSResponse resp = new ExtJSResponse();
            GenerateChequeSequence search = (new JavaScriptSerializer().Deserialize(generateChequeSequence, typeof(GenerateChequeSequence))) as GenerateChequeSequence;
            OutMessage oMsg = (OutMessage)controller.GenerateChequeSequence(search);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}