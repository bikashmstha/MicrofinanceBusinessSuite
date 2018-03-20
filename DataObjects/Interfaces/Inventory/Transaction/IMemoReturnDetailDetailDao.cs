using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Inventory.Transaction;

namespace DataObjects.Interfaces.Inventory
{
    public interface IMemoReturnDetailDetailDao
    {


        object SaveMemoReturnDetailDetail(MemoReturnDetailDetail memoReturnDetailDetail);

        object SearchMemoReturnDetailDetail(MemoReturnDetailDetail memoReturnDetailDetail);



        object GetMemoReturnDetailDtl(string ReferenceNo);

    }
}
