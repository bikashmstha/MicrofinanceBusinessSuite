using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Inventory.Transaction;

namespace DataObjects.Interfaces.Inventory
{
    public interface IGoodReceiptDetailDetailDao
    {


        object SaveGoodReceiptDetailDetail(GoodReceiptDetailDetail goodReceiptDetailDetail);

        object SearchGoodReceiptDetailDetail(GoodReceiptDetailDetail goodReceiptDetailDetail);



        object GetGoodReceiptDtlDetail(string ReferenceNo);

    }
}
