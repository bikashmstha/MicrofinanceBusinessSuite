using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.PublicSavingTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IPublicSavingAccountOpenDao
    {


        object SavePublicSavingAccountOpen(PublicSavingAccountOpen publicSavingAccountOpen);

        object SearchPublicSavingAccountOpen(PublicSavingAccountOpen publicSavingAccountOpen);




    }
}
