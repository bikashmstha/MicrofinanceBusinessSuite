using BusinessObjects;
using BusinessObjects.GeneralMasterParameters.References;
using DataObjects;
using DataObjects.Interfaces.GeneralMasterParameters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MicrofinanceBusinessSuite.Controllers.GeneralMasterParameters.References
{
    public class MSReferenceCodeMasterController : ControllerBase
    {
        private static IMsReferenceCodeMasterDao msReferenceCodeMasterDao = DataAccess.MsReferenceCodeMasterDao;


        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<MSReferenceCodeMaster> GetMsReferenceCodeMaster()
        {
            List<MSReferenceCodeMaster> response;
            try
            {
                response = msReferenceCodeMasterDao.GetMSReferenceCodeMaster();
            }
            catch (Exception ex)
            {

                throw ex;
            }


            return response;

        }
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public OutMessage SaveMsReferenceCodeMaster(MSReferenceCodeMaster msReferenceCodeMaster)
        {
            OutMessage response;
            try
            {
                response = msReferenceCodeMasterDao.SaveMSReferenceCodeMaster(msReferenceCodeMaster);

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return response;

        }


    }
}