using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.HumanResource.Transaction;
using MicrofinanceBusinessSuite.Controllers.HumanResource.Transaction;
using MicrofinanceBusinessSuite.Utility;

namespace MicrofinanceBusinessSuite.Handlers.HumanResource.Transaction
{
    /// <summary>
    /// Summary description for EmployeeTransferHandler
    /// </summary>
    public class EmployeeTransferHandler : BaseHandler
    {
        private static EmployeeTransferController controller = new EmployeeTransferController();


        public object SaveEmployeeTransfer(string employeeTransfer)
        {
            ExtJSResponse resp = new ExtJSResponse();
            EmployeeTransfer obj = (new JavaScriptSerializer().Deserialize(employeeTransfer, typeof(EmployeeTransfer))) as EmployeeTransfer;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveEmployeeTransfer(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchEmployeeTransfer(string employeeTransfer)
        {
            ExtJSResponse resp = new ExtJSResponse();
            EmployeeTransfer search = (new JavaScriptSerializer().Deserialize(employeeTransfer, typeof(EmployeeTransfer))) as EmployeeTransfer;
            OutMessage oMsg = (OutMessage)controller.SearchEmployeeTransfer(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}