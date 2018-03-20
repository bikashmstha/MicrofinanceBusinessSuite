using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.EditTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IPubSavingProductDao
    {


        object SavePubSavingProduct(PubSavingProduct pubSavingProduct);

        object SearchPubSavingProduct(PubSavingProduct pubSavingProduct);



        object GetPubSavingProd(string ProductName);

    }
}
