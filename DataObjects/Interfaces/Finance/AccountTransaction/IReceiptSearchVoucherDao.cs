using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.AccountTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IReceiptSearchVoucherDao
    {


        object SaveReceiptSearchVoucher(ReceiptSearchVoucher receiptSearchVoucher);

        object SearchReceiptSearchVoucher(ReceiptSearchVoucher receiptSearchVoucher);



        object GetRcpSearchVoucher(string OfficeCode, string VoucherNo);

    }
}
