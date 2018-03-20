using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.AccountTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IPaymentVoucherMasterDetailDao
    {


        object SavePaymentVoucherMasterDetail(PaymentVoucherMasterDetail paymentVoucherMasterDetail);

        object SearchPaymentVoucherMasterDetail(PaymentVoucherMasterDetail paymentVoucherMasterDetail);



        object GetPayVoucherMstDetail(string OfficeCode, string VoucherNo, string FromDate, string ToDate);

    }
}
