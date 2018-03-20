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
    public class GeneralDefinitionsUtilityController:ControllerBase
    {
        private static IGeneralDefinitionsUtilityDao generalDifinitionUtilityDao = DataAccess.GeneralDefinitionsUtilityDao;

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public OutMessage GenerateDateOfNepaliFiscalYear(string fiscalYear)
        {
            OutMessage response;
            try
            {
                response = generalDifinitionUtilityDao.GenerateDateOfNepaliFiscalYear(fiscalYear);

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return response;

        }
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public OutMessage GenerateDateOfEnglishFiscalYear(string fiscalYear)
        {
            OutMessage response;
            try
            {
                response = generalDifinitionUtilityDao.GenerateDateOfEnglishFiscalYear(fiscalYear);

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return response;

        }
    }
}