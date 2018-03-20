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
    public class NepaliFiscalYearController:ControllerBase
    {
        private static INepaliFiscalYearDao nepaliFiscalYearDao = DataAccess.NepaliFiscalYearDao;

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<NepaliFiscalYear> GetNepaliFiscalYear()
        {
            List<NepaliFiscalYear> response;
            try
            {
                response = nepaliFiscalYearDao.GetNepaliFiscalYear();
            }
            catch (Exception ex)
            {

                throw ex;
            }


            return response;

        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public OutMessage SaveNepaliFiscalYear(NepaliFiscalYear nepaliFiscalYear)
        {
            OutMessage response;
            try
            {
                response = nepaliFiscalYearDao.SaveNepaliFiscalYear(nepaliFiscalYear);

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return response;

        }
    }
}