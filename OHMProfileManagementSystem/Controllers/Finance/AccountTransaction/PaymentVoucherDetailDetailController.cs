using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.AccountTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;
namespace MicrofinanceBusinessSuite.Controllers.Finance.AccountTransaction
{
    public class PaymentVoucherDetailDetailController : ControllerBase
    {
        private static IPaymentVoucherDetailDetailDao paymentVoucherDetailDetailDao = DataAccess.PaymentVoucherDetailDetailDao;



        public object SavePaymentVoucherDetailDetail(PaymentVoucherDetailDetail paymentVoucherDetailDetail)
        {
            return paymentVoucherDetailDetailDao.SavePaymentVoucherDetailDetail(paymentVoucherDetailDetail);
        }
        public object SearchPaymentVoucherDetailDetail(PaymentVoucherDetailDetail paymentVoucherDetailDetail)
        {
            return paymentVoucherDetailDetailDao.SearchPaymentVoucherDetailDetail(paymentVoucherDetailDetail);
        }

        public object GetPayVoucherDtlDetail(string VoucherNo)
        {
            return paymentVoucherDetailDetailDao.GetPayVoucherDtlDetail(VoucherNo);
        }

    }
}