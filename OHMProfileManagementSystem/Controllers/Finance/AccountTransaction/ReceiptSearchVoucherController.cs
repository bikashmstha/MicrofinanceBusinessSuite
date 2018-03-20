using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.AccountTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.AccountTransaction
{
    public class ReceiptSearchVoucherController : ControllerBase
    {
        private static IReceiptSearchVoucherDao receiptSearchVoucherDao = DataAccess.ReceiptSearchVoucherDao;



        public object SaveReceiptSearchVoucher(ReceiptSearchVoucher receiptSearchVoucher)
        {
            return receiptSearchVoucherDao.SaveReceiptSearchVoucher(receiptSearchVoucher);
        }
        public object SearchReceiptSearchVoucher(ReceiptSearchVoucher receiptSearchVoucher)
        {
            return receiptSearchVoucherDao.SearchReceiptSearchVoucher(receiptSearchVoucher);
        }

        public object GetRcpSearchVoucher(string OfficeCode, string VoucherNo)
        {
            return receiptSearchVoucherDao.GetRcpSearchVoucher(OfficeCode, VoucherNo);
        }

    }
}