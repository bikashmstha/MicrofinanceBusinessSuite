using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.GeneralMasterParameters;
using DataObjects;
using DataObjects.Interfaces.GeneralMasterParameters;

namespace MicrofinanceBusinessSuite.Controllers.GeneralMasterParameters.Maintenance
{
    public class DepartmentController : ControllerBase
    {
        private static IDepartmentDao departmentDao = DataAccess.DepartmentDao;

        public object Get()
        {
            return departmentDao.Get();
        }

        public object Save(Department department)
        {
            return departmentDao.Save(department);
        }
        public object Search(Department department)
        {
            return departmentDao.Search(department);
        }
        public object GetDepartmentShort()
        {
            return departmentDao.GetDepartmentShort();
        }
        public object GetDepartment(string OfficeCode)
        {
            return departmentDao.GetDepartment(OfficeCode);
        }
    }
}
     