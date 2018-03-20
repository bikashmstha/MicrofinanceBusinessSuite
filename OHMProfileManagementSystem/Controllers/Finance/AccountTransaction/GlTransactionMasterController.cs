using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.AccountTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.AccountTransaction
{
    public class GlTransactionMasterController : ControllerBase
    {
        private static IGlTransactionMasterDao glTransactionMasterDao = DataAccess.GlTransactionMasterDao;



        public object SaveGlTransactionMaster(GlTransactionMaster glTransactionMaster)
        {
            return glTransactionMasterDao.SaveGlTransactionMaster(glTransactionMaster);
        }
        public object SearchGlTransactionMaster(GlTransactionMaster glTransactionMaster)
        {
            return glTransactionMasterDao.SearchGlTransactionMaster(glTransactionMaster);
        }
    }
}