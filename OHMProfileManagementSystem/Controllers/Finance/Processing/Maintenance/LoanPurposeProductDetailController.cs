using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Maintenance
{
    public class LoanPurposeProductDetailController : ControllerBase
    {
        private static ILoanPurposeProductDetailDao LoanPurposeProductDetailDao = DataAccess.LoanPurposeProductDetailDao;

        public object Get()
        {
            return LoanPurposeProductDetailDao.Get();
        }

        public object Save(LoanPurposeProductDetail LoanPurposeProductDetail)
        {
            return LoanPurposeProductDetailDao.Save(LoanPurposeProductDetail);
        }
        public object Search(LoanPurposeProductDetail LoanPurposeProductDetail)
        {
            return LoanPurposeProductDetailDao.Search(LoanPurposeProductDetail);
        }
    }
}