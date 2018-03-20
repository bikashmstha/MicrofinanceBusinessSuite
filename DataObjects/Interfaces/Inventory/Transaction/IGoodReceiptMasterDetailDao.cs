using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Inventory.Transaction;

namespace DataObjects.Interfaces.Inventory
{
    public interface IGoodReceiptMasterDetailDao
    {


        object SaveGoodReceiptMasterDetail(GoodReceiptMasterDetail goodReceiptMasterDetail);

        object SearchGoodReceiptMasterDetail(GoodReceiptMasterDetail goodReceiptMasterDetail);



        object GetGoodReceiptMstDetail(string OfficeCode, string ReferenceNo, string FiscalYear, string LocationCode, string FromDate, string ToDate);

    }
}
