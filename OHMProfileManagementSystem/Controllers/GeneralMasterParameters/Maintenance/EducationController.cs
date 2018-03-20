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
    public class EducationController : ControllerBase
    {
        private static IEducationDao educationDao = DataAccess.EducationDao;

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Education> GetEducations()
        {
            List<Education> response;
            try
            {
                response = educationDao.GetEducations();
            }
            catch (Exception ex)
            {

                throw ex;
            }


            return response;

        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Education> GetEducationLov(string educationDesc)
        {
            List<Education> response;
            try
            {
                response = educationDao.GetEducationLov(educationDesc);
            }
            catch (Exception ex)
            {

                throw ex;
            }


            return response;

        }
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public OutMessage SaveEducation(Education education)
        {
            OutMessage response;
            try
            {
                response = educationDao.SaveEducation(education);

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return response;

        }
    }
}