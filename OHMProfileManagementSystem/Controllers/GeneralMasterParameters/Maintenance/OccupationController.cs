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
    public class OccupationController : ControllerBase
    {
        private static IOccupationDao occupationDao = DataAccess.OccupationDao;

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Occupation> GetOccupations()
        {
            List<Occupation> response;
            try
            {
                response = occupationDao.GetOccupations();
            }
            catch (Exception ex)
            {

                throw ex;
            }


            return response;

        }
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public OutMessage SaveOccupation(Occupation occupation)
        {
            OutMessage response;
            try
            {
                response = occupationDao.SaveOccupation(occupation);

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return response;

        }

        public object GetOccupationLov(string OccupationDesc)
        {
            return occupationDao.GetOccupationLov(OccupationDesc);
        }
    }
}