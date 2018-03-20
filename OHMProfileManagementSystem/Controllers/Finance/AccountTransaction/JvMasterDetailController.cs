using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.AccountTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;
namespace MicrofinanceBusinessSuite.Controllers.Finance.AccountTransaction
{
    public class JvMasterDetailController : ControllerBase
    {
        private static IJvMasterDetailDao jVMasterDetailDao = DataAccess.JvMasterDetailDao;



        public object SaveJvMasterDetail(JvMasterDetail jVMasterDetail)
        {
            return jVMasterDetailDao.SaveJvMasterDetail(jVMasterDetail);
        }
        public object SearchJvMasterDetail(JvMasterDetail jVMasterDetail)
        {
            return jVMasterDetailDao.SearchJvMasterDetail(jVMasterDetail);
        }

        public object GetJvMstDetail(string OfficeCode, string VoucherNo, string FromDate, string ToDate)
        {
            return jVMasterDetailDao.GetJvMstDetail(OfficeCode, VoucherNo, FromDate, ToDate);
        }

    }
}