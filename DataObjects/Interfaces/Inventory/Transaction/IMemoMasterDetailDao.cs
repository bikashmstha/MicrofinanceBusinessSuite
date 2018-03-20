using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Inventory.Transaction;

namespace DataObjects.Interfaces.Inventory
{
    public interface IMemoMasterDetailDao
    {


        object SaveMemoMasterDetail(MemoMasterDetail memoMasterDetail);

        object SearchMemoMasterDetail(MemoMasterDetail memoMasterDetail);



        object GetMemoMstDetail(string OfficeCode, string ReferenceNo, string FiscalYear, string LocationCode, string FromDate, string ToDate);

    }
}
