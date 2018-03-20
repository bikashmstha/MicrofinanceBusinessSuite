using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.AccountTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.AccountTransaction
{
    public class JvSearchVoucherController : ControllerBase
    {
        private static IJvSearchVoucherDao jVSearchVoucherDao = DataAccess.JvSearchVoucherDao;



        public object SaveJvSearchVoucher(JvSearchVoucher jVSearchVoucher)
        {
            return jVSearchVoucherDao.SaveJvSearchVoucher(jVSearchVoucher);
        }
        public object SearchJvSearchVoucher(JvSearchVoucher jVSearchVoucher)
        {
            return jVSearchVoucherDao.SearchJvSearchVoucher(jVSearchVoucher);
        }

        public object GetJvSearchVoucher(string OfficeCode, string VoucherNo)
        {
            return jVSearchVoucherDao.GetJvSearchVoucher(OfficeCode, VoucherNo);
        }

    }
}