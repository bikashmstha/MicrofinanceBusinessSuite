using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.Finance.Transaction.CollectionSheetTransaction;
using MicrofinanceBusinessSuite.Controllers.Finance.Transaction.CollectionSheetTransaction;
using MicrofinanceBusinessSuite.Utility;

namespace MicrofinanceBusinessSuite.Handlers.Finance.Transaction.CollectionSheetTransaction
{
    /// <summary>
    /// Summary description for EmployeeCenterCollectionHandler
    /// </summary>
    public class EmployeeCenterCollectionHandler : BaseHandler
    {
        private static EmployeeCenterCollectionController controller = new EmployeeCenterCollectionController();
        public object Get()
        {
            ExtJSResponse resp = new ExtJSResponse();

            OutMessage oMsg = (OutMessage)controller.Get();
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }

        public object Save(string employeeCenterCollection)
        {
            ExtJSResponse resp = new ExtJSResponse();
            EmployeeCenterCollection obj = (new JavaScriptSerializer().Deserialize(employeeCenterCollection, typeof(EmployeeCenterCollection))) as EmployeeCenterCollection;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.Save(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object Search(string employeeCenterCollection)
        {
            ExtJSResponse resp = new ExtJSResponse();
            EmployeeCenterCollection search = (new JavaScriptSerializer().Deserialize(employeeCenterCollection, typeof(EmployeeCenterCollection))) as EmployeeCenterCollection;
            OutMessage oMsg = (OutMessage)controller.Search(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }
        public object RegenerateCollectionList(string offCode)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.RegenerateCollectionList(offCode);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }

        /*public object DeleteCollectionSheetMaster(string collectionSheetNo)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.DeleteCollectionSheetMaster(collectionSheetNo);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }*/

        public object DeleteCollectionSheetMaster(string collectionSheetNos)
        {
            ExtJSResponse resp = new ExtJSResponse();

            List<string> obj = (new JavaScriptSerializer().Deserialize(collectionSheetNos, typeof(List<string>)) as List<string>);

            OutMessage oMsg = (OutMessage)controller.DeleteCollectionSheetMaster(obj);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}