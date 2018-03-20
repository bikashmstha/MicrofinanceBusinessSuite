using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Inventory.Transaction;

namespace DataObjects.Interfaces.Inventory
{
    public interface IMemoReturnMasterDetailDao
    {


        object SaveMemoReturnMasterDetail(MemoReturnMasterDetail memoReturnMasterDetail);

        object SearchMemoReturnMasterDetail(MemoReturnMasterDetail memoReturnMasterDetail);



        object GetMemoReturnMstDetail(string OfficeCode, string ReferenceNo, string FiscalYear, string LocationCode, string FromDate, string ToDate);

    }
}
