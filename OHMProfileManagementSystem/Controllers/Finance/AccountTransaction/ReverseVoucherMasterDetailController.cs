using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.AccountTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.AccountTransaction
{
    public class ReverseVoucherMasterDetailController : ControllerBase
    {
        private static IReverseVoucherMasterDetailDao reverseVoucherMasterDetailDao = DataAccess.ReverseVoucherMasterDetailDao;



        public object SaveReverseVoucherMasterDetail(ReverseVoucherMasterDetail reverseVoucherMasterDetail)
        {
            return reverseVoucherMasterDetailDao.SaveReverseVoucherMasterDetail(reverseVoucherMasterDetail);
        }
        public object SearchReverseVoucherMasterDetail(ReverseVoucherMasterDetail reverseVoucherMasterDetail)
        {
            return reverseVoucherMasterDetailDao.SearchReverseVoucherMasterDetail(reverseVoucherMasterDetail);
        }

        public object GetReverseVoucherMstDtl()
        {
            return reverseVoucherMasterDetailDao.GetReverseVoucherMstDtl();
        }

    }
}