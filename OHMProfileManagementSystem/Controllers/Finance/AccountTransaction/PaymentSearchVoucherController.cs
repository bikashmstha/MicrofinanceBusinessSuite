using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.AccountTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.AccountTransaction
{
    public class PaymentSearchVoucherController : ControllerBase
    {
        private static IPaymentSearchVoucherDao paymentSearchVoucherDao = DataAccess.PaymentSearchVoucherDao;



        public object SavePaymentSearchVoucher(PaymentSearchVoucher paymentSearchVoucher)
        {
            return paymentSearchVoucherDao.SavePaymentSearchVoucher(paymentSearchVoucher);
        }
        public object SearchPaymentSearchVoucher(PaymentSearchVoucher paymentSearchVoucher)
        {
            return paymentSearchVoucherDao.SearchPaymentSearchVoucher(paymentSearchVoucher);
        }

        public object GetPaySearchVoucher(string OfficeCode, string VoucherNo)
        {
            return paymentSearchVoucherDao.GetPaySearchVoucher(OfficeCode, VoucherNo);
        }

    }
}