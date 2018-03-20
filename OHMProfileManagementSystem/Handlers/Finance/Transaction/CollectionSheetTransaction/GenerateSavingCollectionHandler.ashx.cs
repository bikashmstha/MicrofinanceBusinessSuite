using App.Utilities.Web.Handlers;
using BusinessObjects;
using BusinessObjects.Finance.Transaction.CollectionSheetTransaction;
using MicrofinanceBusinessSuite.Controllers.Finance.Transaction.CollectionSheetTransaction;
using MicrofinanceBusinessSuite.Utility;
namespace MicrofinanceBusinessSuite.Handlers.Finance.Transaction.CollectionSheetTransaction
{
    /// <summary>
    /// Summary description for GenerateSavingCollectionHandler
    /// </summary>
    public class GenerateSavingCollectionHandler : BaseHandler
    {
        private static GenerateSavingCollectionController controller = new GenerateSavingCollectionController();

        public object GenerateSavingCollection(string offCode, string sheetNo, string centerCode, string collectionDate)
        {
            ExtJSResponse resp = new ExtJSResponse();
            OutMessage oMsg = (OutMessage)controller.GenerateSavingCollection( offCode, sheetNo,centerCode,collectionDate);
            resp.Success = string.IsNullOrEmpty(oMsg.OutResultMessage) ? "true" : "false";
            return resp.GetResponse(oMsg.Result, null);
        }
    }
}