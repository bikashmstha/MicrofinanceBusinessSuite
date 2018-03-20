using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using BusinessObjects;
using BusinessObjects.Finance.Maintenance;
using DataObjects;
using DataObjects.Interfaces.Finance;
namespace MicrofinanceBusinessSuite.Controllers.Finance.Maintenance
{
    public class LoanProductDetailController : ControllerBase
    {
        private static ILoanProductDetailDao loanProductDetailDao = DataAccess.LoanProductDetailDao;



        public object SaveLoanProductDetail(LoanProductDetail loanProductDetail)
        {
            return loanProductDetailDao.SaveLoanProductDetail(loanProductDetail);
        }
        public object SearchLoanProductDetail(LoanProductDetail loanProductDetail)
        {
            return loanProductDetailDao.SearchLoanProductDetail(loanProductDetail);
        }

        public object GetLoanProductDetailList(string LoanProductCode, string LoanType)
        {
            return loanProductDetailDao.GetLoanProductDetailList(LoanProductCode, LoanType);
        }

    }
}