using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Inventory.Transaction;

namespace DataObjects.Interfaces.Inventory
{
    public interface IGoodReceiptSearchDao
    {


        object SaveGoodReceiptSearch(GoodReceiptSearch goodReceiptSearch);

        object SearchGoodReceiptSearch(GoodReceiptSearch goodReceiptSearch);



        object GetGoodReceiptSearch(string ReferenceNo);

    }
}
