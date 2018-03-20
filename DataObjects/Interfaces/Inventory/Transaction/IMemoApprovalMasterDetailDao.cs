using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Inventory.Transaction;

namespace DataObjects.Interfaces.Inventory
{
    public interface IMemoApprovalMasterDetailDao
    {


        object SaveMemoApprovalMasterDetail(MemoApprovalMasterDetail memoApprovalMasterDetail);

        object SearchMemoApprovalMasterDetail(MemoApprovalMasterDetail memoApprovalMasterDetail);



        object GetMemoApprovalMstDetail(string OfficeCode);

    }
}
