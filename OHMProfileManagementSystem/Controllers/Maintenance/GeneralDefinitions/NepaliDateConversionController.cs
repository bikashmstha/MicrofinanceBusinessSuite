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
    public class NepaliDateConversionController:ControllerBase
    {
        private static INepaliDateConversionDao nepaliDateConversionDao = DataAccess.NepaliDateConversionDao;

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<NepaliDateConversion> GetNepaliDateConversions()
        {
            List<NepaliDateConversion> response;
            try
            {
                response = nepaliDateConversionDao.GetNepaliDateConversion();
            }
            catch (Exception ex)
            {

                throw ex;
            }


            return response;

        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public OutMessage SaveNepaliDateConversion(NepaliDateConversion nepaliDateConversion)
        {
            OutMessage response;
            try
            {
                response = nepaliDateConversionDao.SaveNepaliDateConversion(nepaliDateConversion);

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return response;

        }
    }
}