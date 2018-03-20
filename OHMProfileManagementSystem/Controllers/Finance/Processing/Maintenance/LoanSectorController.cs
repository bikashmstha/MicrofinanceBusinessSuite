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
    public class LoanSectorController : ControllerBase
    {
        private static ILoanSectorDao loanSectorDao = DataAccess.LoanSectorDao;

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<LoanSector> GetLoanSector()
        {
            List<LoanSector> response;
            try
            {
                response = loanSectorDao.GetLoanSector();
            }
            catch (Exception ex)
            {

                throw ex;
            }


            return response;

        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public OutMessage SaveLoanSector(LoanSector loanSector)
        {
            OutMessage response;
            try
            {
                response = loanSectorDao.SaveLoanSector(loanSector);

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return response;

        }


    }
}