using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Security;
using DataObjects;
using DataObjects.Interfaces.GeneralMasterParameters;
using MicrofinanceBusinessSuite.Utility;
using BusinessObjects.Messages;
using BusinessObjects.Message;
using System.ComponentModel;
using BusinessObjects.GeneralMasterParameters;
using BusinessObjects;

namespace MicrofinanceBusinessSuite.Controllers.Maintenance
{
    public class EthnicityInformationController : ControllerBase
    {
        private static IEthnicityInformationDao ethnicityInformationDao = DataAccess.EthnicityInformationDao;

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<EthnicityInformation> GetEthnicityInformations()
        {
            List<EthnicityInformation> response;
            try
            {
                response = ethnicityInformationDao.GetEthnicityInformations();
            }
            catch (Exception ex)
            {

                throw ex;
            }


            return response;

        }
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public OutMessage SaveEthnicityInformation(EthnicityInformation ethnicityInformation)
        {
            OutMessage response;
            try
            {
                response = ethnicityInformationDao.SaveEthnicityInformation(ethnicityInformation);

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return response;

        }
    }
}