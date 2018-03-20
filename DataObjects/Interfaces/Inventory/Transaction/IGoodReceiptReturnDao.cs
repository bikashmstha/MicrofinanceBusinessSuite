using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Inventory.Transaction;

namespace DataObjects.Interfaces.Inventory
{
    public interface IGoodReceiptReturnDao
    {


        object SaveGoodReceiptReturn(GoodReceiptReturn goodReceiptReturn);

        object SearchGoodReceiptReturn(GoodReceiptReturn goodReceiptReturn);



        object GetGoodReceiptReturn(string ReferenceNo);

    }
}
