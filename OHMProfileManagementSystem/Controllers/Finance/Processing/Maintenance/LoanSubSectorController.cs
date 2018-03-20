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
    public class LoanSubSectorController : ControllerBase
    {
        private static ILoanSubSectorDao loanSubSectorDao = DataAccess.LoanSubSectorDao;

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<LoanSubSector> GetSubLoanSector()
        {
            List<LoanSubSector> response;
            try
            {
                response = loanSubSectorDao.GetLoanSubSector();
            }
            catch (Exception ex)
            {

                throw ex;
            }


            return response;

        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public OutMessage SaveLoanSubSector(LoanSubSector loanSubSector)
        {
            OutMessage response;
            try
            {
                response = loanSubSectorDao.SaveLoanSubSector(loanSubSector);

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return response;

        }


    }
}