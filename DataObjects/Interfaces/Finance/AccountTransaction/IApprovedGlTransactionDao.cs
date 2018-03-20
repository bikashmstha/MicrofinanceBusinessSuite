using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.AccountTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IApprovedGlTransactionDao
    {


        object SaveApprovedGlTransaction(ApprovedGlTransaction approvedGLTransaction);

        object SearchApprovedGlTransaction(ApprovedGlTransaction approvedGLTransaction);



    }
}
