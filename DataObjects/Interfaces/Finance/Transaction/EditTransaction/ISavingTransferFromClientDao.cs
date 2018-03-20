using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.EditTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface ISavingTransferFromClientDao
    {


        object SaveSavingTransferFromClient(SavingTransferFromClient savingTransferFromClient);

        object SearchSavingTransferFromClient(SavingTransferFromClient savingTransferFromClient);



        object GetSavTransferFrmClient(string OfficeCode, string CenterCode, string ClientName);

    }
}
