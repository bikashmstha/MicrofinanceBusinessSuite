using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.AccountTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.AccountTransaction
{
    public class ReverseVoucherDetailDetailController : ControllerBase
    {
        private static IReverseVoucherDetailDetailDao reverseVoucherDetailDetailDao = DataAccess.ReverseVoucherDetailDetailDao;



        public object SaveReverseVoucherDetailDetail(ReverseVoucherDetailDetail reverseVoucherDetailDetail)
        {
            return reverseVoucherDetailDetailDao.SaveReverseVoucherDetailDetail(reverseVoucherDetailDetail);
        }
        public object SearchReverseVoucherDetailDetail(ReverseVoucherDetailDetail reverseVoucherDetailDetail)
        {
            return reverseVoucherDetailDetailDao.SearchReverseVoucherDetailDetail(reverseVoucherDetailDetail);
        }

        public object GetReverseVoucherDtlDetail(string VoucherNo)
        {
            return reverseVoucherDetailDetailDao.GetReverseVoucherDtlDetail(VoucherNo);
        }

    }
}