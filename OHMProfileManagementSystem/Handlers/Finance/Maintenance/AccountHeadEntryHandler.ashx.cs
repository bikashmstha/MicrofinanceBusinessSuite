using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.Finance;
using MicrofinanceBusinessSuite.Controllers.Finance.Maintenance;
using MicrofinanceBusinessSuite.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace MicrofinanceBusinessSuite.Handlers.Finance.Maintenance
{
    /// <summary>
    /// Summary description for AccountHeadEntryHandler
    /// </summary>
    public class AccountHeadEntryHandler : BaseHandler
    {
        AccountHeadEntryController controller = new AccountHeadEntryController();
        public object SearchAccountHead(string accountHeadDesc)
        {
            AccountHeadEntry accHead = new AccountHeadEntry();
            accHead.AccountDesc = accountHeadDesc;

            List<AccountHeadEntry> lst = controller.SearchAccountHead(accHead).ToList();
            return GetResponse(lst);
        }
        public object SearchAccountEntry(string accountNo,string accountNameDesc, string GroupId)
        {
            
            ExtJSResponse resp = new ExtJSResponse();
            string response;

            List<AccountHeadEntry> lst;

            try
            {
                lst = controller.SearchAccountEntry(accountNo, accountNameDesc, GroupId);
                resp.Success = "true";
                response = resp.GetResponse(lst, lst.Count);

            }
            catch (Exception ex)
            {
                resp.Success = "false";
                resp.Message = ex.Message;
                response = resp.GetResponse(null, 0);
            }



            SetResponseContentType(ResponseContentTypes.JSON);
            return response;
        }


        public object SaveAccountHeadEntry(string accountHeadEntry)
        {
            ExtJSResponse resp = new ExtJSResponse();
            AccountHeadEntry objAccountHeadEntry = (new JavaScriptSerializer().Deserialize(accountHeadEntry, typeof(AccountHeadEntry))) as AccountHeadEntry;
            string response = "";
            try
            {
                OutMessage obj = controller.SaveAccountHeadEntry(objAccountHeadEntry);
                resp.Success = "true";
                response = resp.GetResponse(obj, 1);

            }
            catch (Exception ex)
            {

                resp.Success = "false";
                resp.Message = ex.Message;
                response = resp.GetResponse(null, 0);
            }
            SetResponseContentType(ResponseContentTypes.JSON);
            return response;

        }

        public object GetContraAccount(string offCode, string accountDesc)
        {
            ExtJSResponse resp = new ExtJSResponse();

            OutMessage oMsg = (OutMessage)controller.GetContraAccount(offCode,accountDesc);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }

        private object GetResponse(List<AccountHeadEntry> lst)
        {
            ExtJSResponse resp = new ExtJSResponse();
            string response = resp.GetResponse(lst, lst.Count);
            SetResponseContentType(ResponseContentTypes.JSON);
            return response;
        } 

    }
}
