using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.CollectionSheetTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface ICollectionAdjustDao
    {
        object Get();

        object Save(CollectionAdjust collectionAdjust);

        object Search(CollectionAdjust collectionAdjust);

        object GetCollectionAdjust(string  clientCode);

    }
}
