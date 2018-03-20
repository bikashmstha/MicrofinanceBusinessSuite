using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Inventory.Transaction;
using DataObjects;
using DataObjects.Interfaces.Inventory;
namespace MicrofinanceBusinessSuite.Controllers.Inventory.Transaction
{
    public class AssetSendReceiptDetailController : ControllerBase
    {
        private static IAssetSendReceiptDetailDao assetSendReceiptDetailDao = DataAccess.AssetSendReceiptDetailDao;



        

        public object GetAssetSendReceiptDetail(string AssetCode, string ReceiveSendDrop)
        {
            return assetSendReceiptDetailDao.GetAssetSendReceiptDetail(AssetCode, ReceiveSendDrop);
        }

    }
}