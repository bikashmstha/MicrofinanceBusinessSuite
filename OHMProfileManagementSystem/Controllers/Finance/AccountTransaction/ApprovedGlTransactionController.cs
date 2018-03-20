using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.AccountTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.AccountTransaction
{
    public class ApprovedGlTransactionController : ControllerBase
    {
        private static IApprovedGlTransactionDao approvedGLTransactionDao = DataAccess.ApprovedGlTransactionDao;



        public object SaveApprovedGlTransaction(ApprovedGlTransaction approvedGLTransaction)
        {
            return approvedGLTransactionDao.SaveApprovedGlTransaction(approvedGLTransaction);
        }
        public object SearchApprovedGlTransaction(ApprovedGlTransaction approvedGLTransaction)
        {
            return approvedGLTransactionDao.SearchApprovedGlTransaction(approvedGLTransaction);
        }
    }
}