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
    public class InstallmentPeriodController:ControllerBase
    {
        private static IInstallmentPeriodDao installmentPeriodDao = DataAccess.InstallmentPeriodDao;

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<InstallmentPeriod> GetInstallmentPeriod()
        {
            List<InstallmentPeriod> response;
            try
            {
                response = installmentPeriodDao.GetInstallmentPeriod();
            }
            catch (Exception ex)
            {

                throw ex;
            }


            return response;

        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public OutMessage SaveInstallmentPeriod(InstallmentPeriod installmentPeriod)
        {
            OutMessage response;
            try
            {
                response = installmentPeriodDao.SaveInstallmentPeriod(installmentPeriod);

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return response;

        }
    }

}