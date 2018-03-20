using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Inventory.Transaction;

namespace DataObjects.Interfaces.Inventory
{
    public interface IMemoDetailDetailDao
    {


        object SaveMemoDetailDetail(MemoDetailDetail memoDetailDetail);

        object SearchMemoDetailDetail(MemoDetailDetail memoDetailDetail);



        object GetMemoDtlDetail(string ReferenceNo);

    }
}
