using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.GeneralMasterParameters;
using DataObjects;
using DataObjects.Interfaces.GeneralMasterParameters;

namespace MicrofinanceBusinessSuite.Controllers.GeneralMasterParameters.Maintenance
{
    public class DepartmentMapController : ControllerBase
    {
        private static IDepartmentMapDao departmentMapDao = DataAccess.DepartmentMapDao;

        public object Get()
        {
            return departmentMapDao.Get();
        }

        public object Save(DepartmentMap departmentMap)
        {
            return departmentMapDao.Save(departmentMap);
        }
        public object Search(DepartmentMap departmentMap)
        {
            return departmentMapDao.Search(departmentMap);
        }
        public object GetOfficeDepartment(string officeCode)
        {
            return departmentMapDao.GetOfficeDepartment(officeCode);
        }
    }
}