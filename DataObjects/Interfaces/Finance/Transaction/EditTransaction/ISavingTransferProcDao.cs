using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.EditTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface ISavingTransferProcDao
    {


        object SaveSavingTransferProc(SavingTransferProc savingTransferProc);

        object SearchSavingTransferProc(SavingTransferProc savingTransferProc);



        object GetSavTransferProc(string ProductName);

    }
}
