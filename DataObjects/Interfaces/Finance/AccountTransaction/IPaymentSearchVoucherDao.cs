using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.AccountTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IPaymentSearchVoucherDao
    {


        object SavePaymentSearchVoucher(PaymentSearchVoucher paymentSearchVoucher);

        object SearchPaymentSearchVoucher(PaymentSearchVoucher paymentSearchVoucher);



        object GetPaySearchVoucher(string OfficeCode, string VoucherNo);

    }
}
