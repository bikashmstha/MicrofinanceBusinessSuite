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
    public class LoanInstallmentPeriodMapController:ControllerBase
    {
        private static ILoanInstallmentPeriodMapDao loanInstallmentPeriodMapDao = DataAccess.LoanInstallmentPeriodMapDao;

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<LoanInstallmentPeriodMap> GetLoanInstallmentPeriodMap()
        {
            List<LoanInstallmentPeriodMap> response;
            try
            {
                response = loanInstallmentPeriodMapDao.GetLoanInstallmentPeriodMap();
            }
            catch (Exception ex)
            {

                throw ex;
            }


            return response;

        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public OutMessage SaveLoanInstallmentPeriodMap(LoanInstallmentPeriodMap loanInstallmentPeriodMap)
        {
            OutMessage response;
            try
            {
                response = loanInstallmentPeriodMapDao.SaveLoanInstallmentPeriodMap(loanInstallmentPeriodMap);

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return response;

        }
    }
}