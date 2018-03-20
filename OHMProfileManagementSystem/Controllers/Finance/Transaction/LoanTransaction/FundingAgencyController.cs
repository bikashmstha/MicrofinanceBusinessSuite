using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.LoanTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.LoanTransaction
{
    public class FundingAgencyController : ControllerBase
    {
        private static IFundingAgencyDao fundingAgencyDao = DataAccess.FundingAgencyDao;

        public object Get()
        {
            return fundingAgencyDao.Get();
        }

        public object Save(FundingAgency fundingAgency)
        {
            return fundingAgencyDao.Save(fundingAgency);
        }
        public object Search(FundingAgency fundingAgency)
        {
            return fundingAgencyDao.Search(fundingAgency);
        }
    }
}