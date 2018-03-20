using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.LoanTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;
namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.LoanTransaction
{
    public class LnUtilizationDetailController : ControllerBase
    {
        private static ILnUtilizationDetailDao lnUtilizationDetailDao = DataAccess.LnUtilizationDetailDao;

        public object Get()
        {
            return lnUtilizationDetailDao.Get();
        }

        public object Save(LnUtilizationDetail lnUtilizationDetail)
        {
            return lnUtilizationDetailDao.Save(lnUtilizationDetail);
        }
        public object Search(LnUtilizationDetail lnUtilizationDetail)
        {
            return lnUtilizationDetailDao.Search(lnUtilizationDetail);
        }

        public object GetLnUtilizationDetail(string CenterCode)
        {
            return lnUtilizationDetailDao.GetLnUtilizationDetail(CenterCode);
        }

    }
}