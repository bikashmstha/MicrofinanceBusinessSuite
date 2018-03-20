using BusinessObjects.GeneralMasterParameters;
using BusinessObjects.Message;
using DataObjects;
using DataObjects.Interfaces.GeneralMasterParameters;
using MicrofinanceBusinessSuite.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MicrofinanceBusinessSuite.Controllers.GeneralMasterParameters
{
    public class OfficeMapController : ControllerBase
    {
        private static IOfficeMapDao officeMapDao = DataAccess.OfficeMapDao;

        public object Get()
        {
            return officeMapDao.Get();
        }

        public object Save(OfficeMap officeMap)
        {
            return officeMapDao.Save(officeMap);
        }
        public object Search(OfficeMap officeMap)
        {
            return officeMapDao.Search(officeMap);
        }

    }
}