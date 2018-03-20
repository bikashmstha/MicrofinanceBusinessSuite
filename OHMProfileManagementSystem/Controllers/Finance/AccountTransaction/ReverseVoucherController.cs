using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.AccountTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.AccountTransaction
{
    public class ReverseVoucherController : ControllerBase
    {
        private static IReverseVoucherDao reverseVoucherDao = DataAccess.ReverseVoucherDao;



        public object SaveReverseVoucher(ReverseVoucher reverseVoucher)
        {
            return reverseVoucherDao.SaveReverseVoucher(reverseVoucher);
        }
        public object SearchReverseVoucher(ReverseVoucher reverseVoucher)
        {
            return reverseVoucherDao.SearchReverseVoucher(reverseVoucher);
        }

        public object GetReverseVoucher(string OfficeCode, string FiscalYear, string Particulars)
        {
            return reverseVoucherDao.GetReverseVoucher(OfficeCode, FiscalYear, Particulars);
        }

    }
}