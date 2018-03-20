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
    /// Summary description for AccountSubCategory
    /// </summary>
    public class AccountSubCategoryHandler : BaseHandler
    {

        public object GetAccountSubCategory()
        {
            AccountSubCategoryController controller = new AccountSubCategoryController();
            ExtJSResponse resp = new ExtJSResponse();
            string response;

            List<AccountSubCategory> lst;

            try
            {
                lst = controller.GetAccountSubCategory();
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

        public object SaveAccountSubCategory(string accountSubCategory)
        {
            AccountSubCategoryController controller = new AccountSubCategoryController();
            ExtJSResponse resp = new ExtJSResponse();

            AccountSubCategory objAccountSubCategory = (new JavaScriptSerializer().Deserialize(accountSubCategory, typeof(AccountSubCategory))) as AccountSubCategory;
            objAccountSubCategory.CreatedBy = GeneralHelper.UserId;
            objAccountSubCategory.CreatedOn = GeneralHelper.DateEnglish;

            string response = "";
            try
            {
                OutMessage obj = controller.SaveAccountSubCategory(objAccountSubCategory);
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