using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Inventory.Transaction;

namespace DataObjects.Interfaces.Inventory
{
    public interface IGoodReceiptEmployeeDao
    {


        object SaveGoodReceiptEmployee(GoodReceiptEmployee goodReceiptEmployee);

        object SearchGoodReceiptEmployee(GoodReceiptEmployee goodReceiptEmployee);



        object GetGoodReceiptEmp();

    }
}
