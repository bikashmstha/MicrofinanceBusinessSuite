using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Inventory.Transaction;
using Oracle.DataAccess.Client;

namespace DataObjects.Interfaces.Inventory
{
    public interface IItemTransactionDetailDao
    {


        object SaveItemTransactionDetail(List<ItemTransactionDetail> itemTransactionDetails,OracleTransaction tran,string referenceNo);

        object SearchItemTransactionDetail(ItemTransactionDetail itemTransactionDetail);



    }
}
