using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Inventory.Transaction;

namespace DataObjects.Interfaces.Inventory
{
    public interface IGoodReceiptReturnItemDao
    {


        object SaveGoodReceiptReturnItem(GoodReceiptReturnItem goodReceiptReturnItem);

        object SearchGoodReceiptReturnItem(GoodReceiptReturnItem goodReceiptReturnItem);



        object GetGoodReceiptReturnItem(string ItemDesc, string ReferenceNo);

    }
}
