using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Inventory.Transaction;

namespace DataObjects.Interfaces.Inventory
{
    public interface IGoodReceiptReturnDetailDao
    {


        object SaveGoodReceiptReturnDetail(GoodReceiptReturnDetail goodReceiptReturnDetail);

        object SearchGoodReceiptReturnDetail(GoodReceiptReturnDetail goodReceiptReturnDetail);



        object GetGoodReceiptReturnDetail(string ReferenceNo);

    }
}
