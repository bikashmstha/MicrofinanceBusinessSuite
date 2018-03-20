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
    public class LoanPurposeController : ControllerBase
    {
        private static ILoanPurposeDao loanPurposeDao = DataAccess.LoanPurposeDao;

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<LoanPurpose> GetLoanPurpose()
        {
            List<LoanPurpose> response;
            try
            {
                response = loanPurposeDao.GetLoanPurpose();
            }
            catch (Exception ex)
            {

                throw ex;
            }


            return response;

        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public OutMessage SaveLoanPurpose(LoanPurpose loanPurpose)
        {
            OutMessage response;
            try
            {
                response = loanPurposeDao.SaveLoanPurpose(loanPurpose);

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return response;

        }

        public object GetMfLoanPurpose(string productCode, string purposeNamer)
        {
            return loanPurposeDao.GetMfLoanPurpose(productCode, purposeNamer);

        }


    }
}