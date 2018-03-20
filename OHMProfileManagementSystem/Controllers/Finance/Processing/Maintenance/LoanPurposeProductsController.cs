using BusinessObjects;
using BusinessObjects.Finance;
using DataObjects;
using DataObjects.Interfaces.Finance;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MicrofinanceBusinessSuite.Controllers.Finance
{
    public class LoanPurposeProductsController: ControllerBase
    {
        private static ILoanPurposeProductsDao loanPurposeProductsDao = DataAccess.LoanPurposeProductsDao;

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<LoanPurposeProducts> GetLoanPurposeProducts(string LoanProductCode)
        {
            List<LoanPurposeProducts> response;
            try
            {
                response = loanPurposeProductsDao.GetLoanPurposeProducts(LoanProductCode);
            }
            catch (Exception ex)
            {

                throw ex;
            }


            return response;

        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public OutMessage SaveLoanPurposeProducts(LoanPurposeProducts loanPurposeProducts)
        {
            OutMessage response;
            try
            {
                response = loanPurposeProductsDao.SaveLoanPurposeProducts(loanPurposeProducts);

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return response;

        }


    }
}