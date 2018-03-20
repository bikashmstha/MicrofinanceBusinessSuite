using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Inventory.Transaction;

namespace DataObjects.Interfaces.Inventory
{
    public interface IMemoReturnReferenceNoDao
    {


        object SaveMemoReturnReferenceNo(MemoReturnReferenceNo memoreturnReferenceNo);

        object SearchMemoReturnReferenceNo(MemoReturnReferenceNo memoreturnReferenceNo);



        object GetMemoReturnRefNo(string ReferenceNo);

    }
}
