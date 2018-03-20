using BusinessObjects;
using BusinessObjects.GeneralMasterParameters.References;
using BusinessObjects.Messages;
using BusinessObjects.Security;
using DataObjects;
using DataObjects.Interfaces.GeneralMasterParameters;
using MicrofinanceBusinessSuite.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MicrofinanceBusinessSuite.Controllers.GeneralMasterParameters.References
{
    public class MsControlValuesController: ControllerBase
    {
        private static IMsControlValuesDao msControlValuesDao = DataAccess.MsControlValuesDao;
       
       
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<MsControlValues> GetMsControlValues()
        {
            List<MsControlValues> response;
            try
            {
                response = msControlValuesDao.GetMsControlValues();
            }
            catch (Exception ex)
            {

                throw ex;
            }


            return response;

        }
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public OutMessage SaveMsControlValues(MsControlValues msControlValues)
        {
            OutMessage response;
            try
            {
                response = msControlValuesDao.SaveMsControlValues(msControlValues);

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return response;

        }


    }
}