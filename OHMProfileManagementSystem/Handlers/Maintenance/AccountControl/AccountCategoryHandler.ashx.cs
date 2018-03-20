using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.Maintenance;
using MicrofinanceBusinessSuite.Controllers.Maintenance.AccountControl;
using MicrofinanceBusinessSuite.Utility;


namespace MicrofinanceBusinessSuite.Handlers.Maintenance.AccountControl
{
    /// <summary>
    /// Summary description for AccountCategoryHandler
    /// </summary>
    public class AccountCategoryHandler : BaseHandler
    {

        public object GetAccountCategory()
        {
            AccountCategoryController controller = new AccountCategoryController();
            ExtJSResponse resp = new ExtJSResponse();
            string response;

            List<AccountCategory> lst;

            try
            {
                lst = controller.GetAccountCategory();
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

        public object SaveAccountCategory(string accountCategory)
        {
            AccountCategoryController controller = new AccountCategoryController();
            ExtJSResponse resp = new ExtJSResponse();

            AccountCategory objAccountCategory = (new JavaScriptSerializer().Deserialize(accountCategory, typeof(AccountCategory))) as AccountCategory;
            objAccountCategory.CreatedBy = GeneralHelper.UserId;
            objAccountCategory.CreatedOn = GeneralHelper.DateEnglish;

            string response = "";
            try
            {
                OutMessage obj = controller.SaveAccountCategory(objAccountCategory);
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