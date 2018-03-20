using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.AccountTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IPaymentVoucherDetailDetailDao
    {


        object SavePaymentVoucherDetailDetail(PaymentVoucherDetailDetail paymentVoucherDetailDetail);

        object SearchPaymentVoucherDetailDetail(PaymentVoucherDetailDetail paymentVoucherDetailDetail);



        object GetPayVoucherDtlDetail(string VoucherNo);

    }
}
