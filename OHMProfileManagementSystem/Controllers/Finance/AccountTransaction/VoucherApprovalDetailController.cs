using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.AccountTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;
namespace MicrofinanceBusinessSuite.Controllers.Finance.AccountTransaction
{
    public class VoucherApprovalDetailController : ControllerBase
    {
        private static IVoucherApprovalDetailDao VoucherApprovalDetailDao = DataAccess.VoucherApprovalDetailDao;



        public object SaveVoucherApprovalDetail(VoucherApprovalDetail VoucherApprovalDetail)
        {
            return VoucherApprovalDetailDao.SaveVoucherApprovalDetail(VoucherApprovalDetail);
        }
        public object SearchVoucherApprovalDetail(VoucherApprovalDetail VoucherApprovalDetail)
        {
            return VoucherApprovalDetailDao.SearchVoucherApprovalDetail(VoucherApprovalDetail);
        }

        public object GetVouApprovalDet(string VoucherNo)
        {
            return VoucherApprovalDetailDao.GetVouApprovalDet(VoucherNo);
        }

    }
}