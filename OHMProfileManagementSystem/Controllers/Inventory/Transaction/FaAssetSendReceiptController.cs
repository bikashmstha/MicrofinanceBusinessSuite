using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Inventory.Transaction;
using DataObjects;
using DataObjects.Interfaces.Inventory;
namespace MicrofinanceBusinessSuite.Controllers.Inventory.Transaction
{
    public class FaAssetSendReceiptController : ControllerBase
    {
        private static IFaAssetSendReceiptDao faAssetSendReceiptDao = DataAccess.FaAssetSendReceiptDao;



        public object SaveFaAssetSendReceipt(FaAssetSendReceipt faAssetSendReceipt)
        {
            return faAssetSendReceiptDao.SaveFaAssetSendReceipt(faAssetSendReceipt);
        }
        public object SearchFaAssetSendReceipt(FaAssetSendReceipt faAssetSendReceipt)
        {
            return faAssetSendReceiptDao.SearchFaAssetSendReceipt(faAssetSendReceipt);
        }
    }
}