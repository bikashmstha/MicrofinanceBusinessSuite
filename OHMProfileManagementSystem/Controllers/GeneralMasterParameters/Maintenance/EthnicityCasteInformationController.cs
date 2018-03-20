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
    public class EthnicityCasteInformationController : ControllerBase
    {
        private static IEthnicityCasteInformationDao ethnicityCasteInformationDao = DataAccess.EthnicityCasteInformationDao;

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<EthnicityCasteInformation> GetEthnicityCasteInformations(string ethnicityCasteCode)
        {
            List<EthnicityCasteInformation> response;
            try
            {
                response = ethnicityCasteInformationDao.GetEthnicityCasteInformations(ethnicityCasteCode);
            }
            catch (Exception ex)
            {

                throw ex;
            }


            return response;

        }
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public OutMessage SaveEthnicityCasteInformation(EthnicityCasteInformation ethnicityCasteInformation)
        {
            OutMessage response;
            try
            {
                response = ethnicityCasteInformationDao.SaveEthnicityCasteInformation(ethnicityCasteInformation);

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return response;

        }
    }
}