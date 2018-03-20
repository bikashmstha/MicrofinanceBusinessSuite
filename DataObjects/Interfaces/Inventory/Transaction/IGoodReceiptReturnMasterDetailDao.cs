using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Inventory.Transaction;

namespace DataObjects.Interfaces.Inventory
{
    public interface IGoodReceiptReturnMasterDetailDao
    {


        object SaveGoodReceiptReturnMasterDetail(GoodReceiptReturnMasterDetail goodReceiptReturnMasterDetail);

        object SearchGoodReceiptReturnMasterDetail(GoodReceiptReturnMasterDetail goodReceiptReturnMasterDetail);



        object GetGoodReceiptReturnMstDtl(string OfficeCode, string ReferenceNo, string FiscalYear, string LocationCode, string FromDate, string ToDate);

    }
}
