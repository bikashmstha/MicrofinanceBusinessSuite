using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.AccountTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IGlTransactionMasterDao
    {


        object SaveGlTransactionMaster(GlTransactionMaster glTransactionMaster);

        object SearchGlTransactionMaster(GlTransactionMaster glTransactionMaster);



    }
}
