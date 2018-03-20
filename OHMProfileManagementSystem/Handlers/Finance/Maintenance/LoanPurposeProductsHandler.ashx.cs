using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.Finance;
using MicrofinanceBusinessSuite.Controllers.Finance;
using MicrofinanceBusinessSuite.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace MicrofinanceBusinessSuite.Handlers.Finance.Loan
{
    /// <summary>
    /// Summary description for LoanPurposeProductsHandler
    /// </summary>
    public class LoanPurposeProductsHandler : BaseHandler
    {
        public object GetLoanPurposeProducts(string LoanProductCode)
        {
            LoanPurposeProductsController controller = new LoanPurposeProductsController();
            ExtJSResponse resp = new ExtJSResponse();
            string response;

            List<LoanPurposeProducts> lst;

            try
            {
                lst = controller.GetLoanPurposeProducts(LoanProductCode);
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

        public object SaveLoanPurposeProducts(string loanPurposeProducts)
        {
            LoanPurposeProductsController controller = new LoanPurposeProductsController();
            ExtJSResponse resp = new ExtJSResponse();
            LoanPurposeProducts objLoanPurposeProducts = (new JavaScriptSerializer().Deserialize(loanPurposeProducts, typeof(LoanPurposeProducts))) as LoanPurposeProducts;
            string response = "";
            try
            {
                OutMessage obj = controller.SaveLoanPurposeProducts(objLoanPurposeProducts);
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