using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.AccountTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.AccountTransaction
{
    public class JvDtlDetailController : ControllerBase
    {
        private static IJvDtlDetailDao jVDtlDetailDao = DataAccess.JvDtlDetailDao;



        public object SaveJvDtlDetail(JvDtlDetail jVDtlDetail)
        {
            return jVDtlDetailDao.SaveJvDtlDetail(jVDtlDetail);
        }
        public object SearchJvDtlDetail(JvDtlDetail jVDtlDetail)
        {
            return jVDtlDetailDao.SearchJvDtlDetail(jVDtlDetail);
        }

        public object GetJvDtlDetail(string VoucherNo)
        {
            return jVDtlDetailDao.GetJvDtlDetail(VoucherNo);
        }

    }
}