using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Maintenance
{
    public class SubSectorController : ControllerBase
    {
        private static ISubSectorDao subSectorDao = DataAccess.SubSectorDao;

        public object Get()
        {
            return subSectorDao.Get();
        }

        public object Save(SubSector subSector)
        {
            return subSectorDao.Save(subSector);
        }
        public object Search(SubSector subSector)
        {
            return subSectorDao.Search(subSector);
        }
    }
}