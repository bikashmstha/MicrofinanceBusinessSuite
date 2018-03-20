using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.AccountTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IReceiptVoucherDetailDetailDao
    {


        object SaveReceiptVoucherDetailDetail(ReceiptVoucherDetailDetail receiptVoucherDetailDetail);

        object SearchReceiptVoucherDetailDetail(ReceiptVoucherDetailDetail receiptVoucherDetailDetail);



        object GetReceiptVoucherDtlDetail(string VoucherNo);

    }
}
