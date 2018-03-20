using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.AccountTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.AccountTransaction
{
    public class VoucherApprovalMasterController : ControllerBase
    {
        private static IVoucherApprovalMasterDao VoucherApprovalMasterDao = DataAccess.VoucherApprovalMasterDao;



        public object SaveVoucherApprovalMaster(VoucherApprovalMaster VoucherApprovalMaster)
        {
            return VoucherApprovalMasterDao.SaveVoucherApprovalMaster(VoucherApprovalMaster);
        }
        public object SearchVoucherApprovalMaster(VoucherApprovalMaster VoucherApprovalMaster)
        {
            return VoucherApprovalMasterDao.SearchVoucherApprovalMaster(VoucherApprovalMaster);
        }

        public object GetVouApprovalMst(string OfficeCode)
        {
            return VoucherApprovalMasterDao.GetVouApprovalMst(OfficeCode);
        }

    }
}