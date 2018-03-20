using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.AccountTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.AccountTransaction
{
    public class ReceiptVoucherMasterDetailController : ControllerBase
    {
        private static IReceiptVoucherMasterDetailDao receiptVoucherMasterDetailDao = DataAccess.ReceiptVoucherMasterDetailDao;



        public object SaveReceiptVoucherMasterDetail(ReceiptVoucherMasterDetail receiptVoucherMasterDetail)
        {
            return receiptVoucherMasterDetailDao.SaveReceiptVoucherMasterDetail(receiptVoucherMasterDetail);
        }
        public object SearchReceiptVoucherMasterDetail(ReceiptVoucherMasterDetail receiptVoucherMasterDetail)
        {
            return receiptVoucherMasterDetailDao.SearchReceiptVoucherMasterDetail(receiptVoucherMasterDetail);
        }

        public object GetReceiptVoucherMstDetail(string OfficeCode, string VoucherNo, string FromDate, string ToDate)
        {
            return receiptVoucherMasterDetailDao.GetReceiptVoucherMstDetail(OfficeCode, VoucherNo, FromDate, ToDate);
        }

    }
}