using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.AccountTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.AccountTransaction
{
    public class VoucherAccountController : ControllerBase
    {
        private static IVoucherAccountDao voucherAccountDao = DataAccess.VoucherAccountDao;



        public object SaveVoucherAccount(VoucherAccount voucherAccount)
        {
            return voucherAccountDao.SaveVoucherAccount(voucherAccount);
        }
        public object SearchVoucherAccount(VoucherAccount voucherAccount)
        {
            return voucherAccountDao.SearchVoucherAccount(voucherAccount);
        }

        public object GetVoucherAcc(string OfficeCode, string AccountDesc)
        {
            return voucherAccountDao.GetVoucherAcc(OfficeCode, AccountDesc);
        }

    }
}