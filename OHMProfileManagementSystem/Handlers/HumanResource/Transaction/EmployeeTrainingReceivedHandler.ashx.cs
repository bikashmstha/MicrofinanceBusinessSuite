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
    /// Summary description for EmployeeTrainingReceivedHandler
    /// </summary>
    public class EmployeeTrainingReceivedHandler : BaseHandler
    {
        private static EmployeeTrainingReceivedController controller = new EmployeeTrainingReceivedController();


        public object SaveEmployeeTrainingReceived(string employeeTrainingReceived)
        {
            ExtJSResponse resp = new ExtJSResponse();
            EmployeeTrainingReceived obj = (new JavaScriptSerializer().Deserialize(employeeTrainingReceived, typeof(EmployeeTrainingReceived))) as EmployeeTrainingReceived;
            obj.CreatedBy = GeneralHelper.UserId;
            obj.CreatedOn = GeneralHelper.MisDateNepali;
            OutMessage oMsg = (OutMessage)controller.SaveEmployeeTrainingReceived(obj);
            resp.Success = oMsg.OutResultCode == "SUCCESS" ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
        public object SearchEmployeeTrainingReceived(string employeeTrainingReceived)
        {
            ExtJSResponse resp = new ExtJSResponse();
            EmployeeTrainingReceived search = (new JavaScriptSerializer().Deserialize(employeeTrainingReceived, typeof(EmployeeTrainingReceived))) as EmployeeTrainingReceived;
            OutMessage oMsg = (OutMessage)controller.SearchEmployeeTrainingReceived(search);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            resp.Message = oMsg.OutResultMessage;
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}