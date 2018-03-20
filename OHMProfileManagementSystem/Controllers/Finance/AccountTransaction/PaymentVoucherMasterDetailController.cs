using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.AccountTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;
namespace MicrofinanceBusinessSuite.Controllers.Finance.AccountTransaction
{
    public class PaymentVoucherMasterDetailController : ControllerBase
    {
        private static IPaymentVoucherMasterDetailDao paymentVoucherMasterDetailDao = DataAccess.PaymentVoucherMasterDetailDao;



        public object SavePaymentVoucherMasterDetail(PaymentVoucherMasterDetail paymentVoucherMasterDetail)
        {
            return paymentVoucherMasterDetailDao.SavePaymentVoucherMasterDetail(paymentVoucherMasterDetail);
        }
        public object SearchPaymentVoucherMasterDetail(PaymentVoucherMasterDetail paymentVoucherMasterDetail)
        {
            return paymentVoucherMasterDetailDao.SearchPaymentVoucherMasterDetail(paymentVoucherMasterDetail);
        }

        public object GetPayVoucherMstDetail(string OfficeCode, string VoucherNo, string FromDate, string ToDate)
        {
            return paymentVoucherMasterDetailDao.GetPayVoucherMstDetail(OfficeCode, VoucherNo, FromDate, ToDate);
        }

    }
}