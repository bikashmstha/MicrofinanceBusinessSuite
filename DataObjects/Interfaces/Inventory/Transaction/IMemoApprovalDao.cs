using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Inventory.Transaction;

namespace DataObjects.Interfaces.Inventory
{
    public interface IMemoApprovalDao
    {


        object SaveMemoApproval(MemoApproval memoApproval);

        object SearchMemoApproval(MemoApproval memoApproval);



    }
}
