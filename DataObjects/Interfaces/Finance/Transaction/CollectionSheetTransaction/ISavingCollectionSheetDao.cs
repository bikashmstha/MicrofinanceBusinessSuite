using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.CollectionSheetTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface ISavingCollectionSheetDao
    {
        object Get();

        object Save(SavingCollectionSheet savingCollectionSheet);

        object Search(SavingCollectionSheet savingCollectionSheet);

        object Delete(string sheetNo, string user);

        object Update(string sheetNo, string dataEntered, string dataEnteredDate, string welfareFundAmount, string user);


        

    }
}
