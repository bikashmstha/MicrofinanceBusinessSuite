using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Processing;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Processing
{
    public class SavingDepositPostingController : ControllerBase
    {
        private static ISavingDepositPostingDao savingDepositPostingDao = DataAccess.SavingDepositPostingDao;



        public object SaveSavingDepositPosting(List<SavingDepositPosting> savingDepositPosting)
        {
            return savingDepositPostingDao.SaveSavingDepositPosting(savingDepositPosting);
        }
        public object SearchSavingDepositPosting(SavingDepositPosting savingDepositPosting)
        {
            return savingDepositPostingDao.SearchSavingDepositPosting(savingDepositPosting);
        }
    }
}