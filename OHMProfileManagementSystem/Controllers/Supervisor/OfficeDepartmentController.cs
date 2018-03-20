using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Supervisor;
using DataObjects;
using DataObjects.Interfaces.Supervisor;

namespace MicrofinanceBusinessSuite.Controllers.Supervisor
{
    public class OfficeDepartmentController : ControllerBase
    {
        private static IOfficeDepartmentDao OfficeDepartmentDao = DataAccess.OfficeDepartmentDao;

        public object Get()
        {
            return OfficeDepartmentDao.Get();
        }

        public object Save(OfficeDepartment OfficeDepartment)
        {
            return OfficeDepartmentDao.Save(OfficeDepartment);
        }
        public object Search(OfficeDepartment OfficeDepartment)
        {
            return OfficeDepartmentDao.Search(OfficeDepartment);
        }
    }
}