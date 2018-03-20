using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.AccountTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IContraBankAccountDao
    {


        object SaveContraBankAccount(ContraBankAccount contraBankAccount);

        object SearchContraBankAccount(ContraBankAccount contraBankAccount);



        object GetContraBnkAcc(string AccountDesc);

    }
}
