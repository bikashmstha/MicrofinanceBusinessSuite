using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.Finance;
using MicrofinanceBusinessSuite.Controllers.Finance.Maintenance;
using MicrofinanceBusinessSuite.Utility;

namespace MicrofinanceBusinessSuite.Handlers.Finance
{
    /// <summary>
    /// Summary description for SavingMidTermInterestHandler
    /// </summary>
    public class SavingMidTermInterestHandler : BaseHandler
    {

        public object GetAccountCategory()
        {
            SavingMidTermInterestController controller = new SavingMidTermInterestController();
            ExtJSResponse resp = new ExtJSResponse();
            string response;

            List<SavingMidTermInterest> lst;

            try
            {
                lst = controller.GetSavingMidTermInterest();
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

        public object SaveAccountCategory(string savingMidTermInterest)
        {
            SavingMidTermInterestController controller = new SavingMidTermInterestController();
            ExtJSResponse resp = new ExtJSResponse();

            SavingMidTermInterest objSavingMidTermInterest = (new JavaScriptSerializer().Deserialize(savingMidTermInterest, typeof(SavingMidTermInterest))) as SavingMidTermInterest;
            objSavingMidTermInterest.CreatedBy = GeneralHelper.UserId;
            objSavingMidTermInterest.CreatedOn = GeneralHelper.DateEnglish;

            string response = "";
            try
            {
                OutMessage obj = controller.SaveSavingMidTermInterest(objSavingMidTermInterest);
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
    }
}