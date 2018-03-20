using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.PublicSavingTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IPublicAccountCloseProductDao
    {


        object SavePublicAccountCloseProduct(PublicAccountCloseProduct publicAccountCloseProduct);

        object SearchPublicAccountCloseProduct(PublicAccountCloseProduct publicAccountCloseProduct);



        object GetPubAccCloseProd(string ProductName);

    }
}
