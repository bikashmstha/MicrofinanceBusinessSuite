using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Inventory.Transaction;

namespace DataObjects.Interfaces.Inventory
{
    public interface IFaAssetSendReceiptDao
    {


        object SaveFaAssetSendReceipt(FaAssetSendReceipt faAssetSendReceipt);

        object SearchFaAssetSendReceipt(FaAssetSendReceipt faAssetSendReceipt);



    }
}
