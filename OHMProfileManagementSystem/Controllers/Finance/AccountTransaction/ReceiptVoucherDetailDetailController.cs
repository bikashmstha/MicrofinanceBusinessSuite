using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.AccountTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.AccountTransaction
{
    public class ReceiptVoucherDetailDetailController : ControllerBase
    {
        private static IReceiptVoucherDetailDetailDao receiptVoucherDetailDetailDao = DataAccess.ReceiptVoucherDetailDetailDao;



        public object SaveReceiptVoucherDetailDetail(ReceiptVoucherDetailDetail receiptVoucherDetailDetail)
        {
            return receiptVoucherDetailDetailDao.SaveReceiptVoucherDetailDetail(receiptVoucherDetailDetail);
        }
        public object SearchReceiptVoucherDetailDetail(ReceiptVoucherDetailDetail receiptVoucherDetailDetail)
        {
            return receiptVoucherDetailDetailDao.SearchReceiptVoucherDetailDetail(receiptVoucherDetailDetail);
        }

        public object GetReceiptVoucherDtlDetail(string VoucherNo)
        {
            return receiptVoucherDetailDetailDao.GetReceiptVoucherDtlDetail(VoucherNo);
        }

    }
}