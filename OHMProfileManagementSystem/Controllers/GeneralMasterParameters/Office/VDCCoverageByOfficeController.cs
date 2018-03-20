using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.GeneralMasterParameters;
using DataObjects;
using DataObjects.Interfaces.GeneralMasterParameters;

namespace MicrofinanceBusinessSuite.Controllers.GeneralMasterParameters.Offices
{
    public class VdcCoverageByOfficeController : ControllerBase
    {
        private static IVdcCoverageByOfficeDao vdcCoverageByOfficeDao = DataAccess.VdcCoverageByOfficeDao;

        public object Get()
        {
            return vdcCoverageByOfficeDao.Get();
        }

        public object Save(VdcCoverageByOffice vdcCoverageByOffice)
        {
            return vdcCoverageByOfficeDao.Save(vdcCoverageByOffice);
        }
        public object Search(VdcCoverageByOffice vdcCoverageByOffice)
        {
            return vdcCoverageByOfficeDao.Search(vdcCoverageByOffice);
        }
    }
}