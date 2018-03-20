using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Security;
using DataObjects;
using DataObjects.Interfaces.Maintenance;
using MicrofinanceBusinessSuite.Utility;
using BusinessObjects.Messages;
using BusinessObjects.Message;
using System.ComponentModel;
using BusinessObjects.Maintenance;
using BusinessObjects;

namespace MicrofinanceBusinessSuite.Controllers.Maintenance.GeneralDefinitions
{
    public class LoanProductPeriodMapController:ControllerBase
    {
        private static ILoanProductPeriodMapDao loanProductPeriodMapDao = DataAccess.LoanProductPeriodMapDao;

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<LoanProductPeriodMap> GetLoanProductPeriodMap(string loanProductCode)
        {
            List<LoanProductPeriodMap> response;
            try
            {
                response = loanProductPeriodMapDao.GetLoanProductPeriodMap(loanProductCode);
            }
            catch (Exception ex)
            {

                throw ex;
            }


            return response;

        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public OutMessage SaveLoanProductPeriodMap(LoanProductPeriodMap loanProductPeriodMap)
        {
            OutMessage response;
            try
            {
                response = loanProductPeriodMapDao.SaveLoanProductPeriodMap(loanProductPeriodMap);

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return response;

        }
    }
}