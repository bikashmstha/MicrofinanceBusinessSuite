using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.EditTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface ISavingTransferFromAccountDao
    {


        object SaveSavingTransferFromAccount(SavingTransferFromAccount savingTransferFromAccount);

        object SearchSavingTransferFromAccount(SavingTransferFromAccount savingTransferFromAccount);



        object GetSavTransferFrmAcc(string OfficeCode, string CenterCode, string ClientNo);

    }
}
