using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Inventory.Transaction;

namespace DataObjects.Interfaces.Inventory
{
    public interface IMemoApprovalDetailDao
    {


        object SaveMemoApprovalDetail(MemoApprovalDetail memoApprovalDetail);

        object SearchMemoApprovalDetail(MemoApprovalDetail memoApprovalDetail);



        object GetMemoApprovalDtlDetail(string ReferenceNo);

    }
}
