using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.GeneralMasterParameters;
using DataObjects;
using DataObjects.Interfaces.GeneralMasterParameters;

namespace MicrofinanceBusinessSuite.Controllers.Supervisor
{
    public class DepartmentController : ControllerBase
    {
        private static IDepartmentDao DepartmentDao = DataAccess.DepartmentDao;

        public object Get()
        {
            return DepartmentDao.Get();
        }

        public object Save(Department Department)
        {
            return DepartmentDao.Save(Department);
        }
        public object Search(Department Department)
        {
            return DepartmentDao.Search(Department);
        }
        public object GetDepartmentShort()
        {
            return DepartmentDao.GetDepartmentShort();
        }

    }
}