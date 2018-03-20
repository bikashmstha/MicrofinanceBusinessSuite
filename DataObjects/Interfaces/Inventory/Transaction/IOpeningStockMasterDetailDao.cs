using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Inventory.Transaction;

namespace DataObjects.Interfaces.Inventory
{
    public interface IOpeningStockMasterDetailDao
    {


        object SaveOpeningStockMasterDetail(OpeningStockMasterDetail openingStockMasterDetail);

        object SearchOpeningStockMasterDetail(OpeningStockMasterDetail openingStockMasterDetail);



        object GetOpeningStockMstDetail(string OfficeCode, string ReferenceNo, string FiscalYear, string LocationCode, string FromDate, string ToDate);

    }
}
