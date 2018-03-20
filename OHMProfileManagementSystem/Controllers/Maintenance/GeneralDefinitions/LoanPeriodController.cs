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
    public class LoanPeriodController:ControllerBase
    {
        private static ILoanPeriodDao loanPeriodDao = DataAccess.LoanPeriodDao;

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<LoanPeriod> GetLoanPeriod()
        {
            List<LoanPeriod> response;
            try
            {
                response = loanPeriodDao.GetLoanPeriod();
            }
            catch (Exception ex)
            {

                throw ex;
            }


            return response;

        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public OutMessage SaveLoanPeriod(LoanPeriod loanPeriod)
        {
            OutMessage response;
            try
            {
                response = loanPeriodDao.SaveLoanPeriod(loanPeriod);

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return response;

        }
    }
}