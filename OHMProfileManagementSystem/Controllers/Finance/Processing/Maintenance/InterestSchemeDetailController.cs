using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using BusinessObjects;
using BusinessObjects.Finance.Maintenance;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Maintenance
{
    public class InterestSchemeDetailController : ControllerBase
    {
        private static IInterestSchemeDetailDao interestSchemeDetailDao = DataAccess.InterestSchemeDetailDao;



        public object SaveInterestSchemeDetail(InterestSchemeDetail interestSchemeDetail)
        {
            return interestSchemeDetailDao.SaveInterestSchemeDetail(interestSchemeDetail);
        }
        public object SearchInterestSchemeDetail(InterestSchemeDetail interestSchemeDetail)
        {
            return interestSchemeDetailDao.SearchInterestSchemeDetail(interestSchemeDetail);
        }

        public object GetIntSchemeDtl(string IntSchemeCode)
        {
            return interestSchemeDetailDao.GetIntSchemeDtl(IntSchemeCode);
        }

    }
}