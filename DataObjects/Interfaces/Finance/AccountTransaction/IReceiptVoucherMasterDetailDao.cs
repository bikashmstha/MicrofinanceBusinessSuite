using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.AccountTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IReceiptVoucherMasterDetailDao
    {


        object SaveReceiptVoucherMasterDetail(ReceiptVoucherMasterDetail receiptVoucherMasterDetail);

        object SearchReceiptVoucherMasterDetail(ReceiptVoucherMasterDetail receiptVoucherMasterDetail);



        object GetReceiptVoucherMstDetail(string OfficeCode, string VoucherNo, string FromDate, string ToDate);

    }
}
