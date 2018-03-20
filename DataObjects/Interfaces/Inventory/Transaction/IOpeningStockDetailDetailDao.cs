using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Inventory.Transaction;

namespace DataObjects.Interfaces.Inventory
{
    public interface IOpeningStockDetailDetailDao
    {


        object SaveOpeningStockDetailDetail(OpeningStockDetailDetail openingStockDetailDetail);

        object SearchOpeningStockDetailDetail(OpeningStockDetailDetail openingStockDetailDetail);



        object GetOpeningStockDtlDetail(string ReferenceNo);

    }
}
