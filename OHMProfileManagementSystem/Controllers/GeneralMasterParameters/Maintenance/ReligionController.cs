using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.GeneralMasterParameters.Maintenance;
using DataObjects;
using DataObjects.Interfaces.GeneralMasterParameters;
using MicrofinanceBusinessSuite.Controllers;

namespace MicrofinanceBusinessSuite.Controllers.Maintenance
{
    public class ReligionController : ControllerBase
    {
        private static IReligionDao religionDao = DataAccess.ReligionDao;

        public object Get()
        {
            return religionDao.Get();
        }

        public object Save(Religion religion)
        {
            return religionDao.Save(religion);
        }
        public object Search(Religion religion)
        {
            return religionDao.Search(religion);
        }
    }
}