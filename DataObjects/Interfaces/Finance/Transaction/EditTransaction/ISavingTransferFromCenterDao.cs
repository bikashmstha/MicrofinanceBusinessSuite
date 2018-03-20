using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.EditTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface ISavingTransferFromCenterDao
    {


        object SaveSavingTransferFromCenter(SavingTransferFromCenter savingTransferFromCenter);

        object SearchSavingTransferFromCenter(SavingTransferFromCenter savingTransferFromCenter);



        object GetSavTransferFrmCenter(string OfficeCode, string CenterName);

    }
}
