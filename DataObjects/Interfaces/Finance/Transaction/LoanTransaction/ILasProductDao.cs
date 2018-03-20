using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.LoanTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface ILasProductDao
    {
        object Get();

        object Save(LasProduct lasProduct);

        object Search(LasProduct lasProduct);



        object GetLasProduct(string ProductCodeType, string ProductName);

    }
}
