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
    public class MSReferenceCodeDetailsController : ControllerBase
    {
        private static IMsReferenceCodeDetailsDao msReferenceCodeMasterDao = DataAccess.MsReferenceCodeDetailsDao;


        public object GetReferenceDetailListShort(string referenceCode)
        {
            return msReferenceCodeMasterDao.GetReferenceDetailListShort(referenceCode);
        }


    }
}