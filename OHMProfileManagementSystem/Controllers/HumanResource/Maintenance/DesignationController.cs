using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.HumanResource;
using DataObjects;
using DataObjects.Interfaces.HumanResource;

namespace MicrofinanceBusinessSuite.Controllers.HumanResource.Maintenance
{
    public class DesignationController : ControllerBase
    {
        private static IDesignationDao designationDao = DataAccess.DesignationDao;

        public object Get()
        {
            return designationDao.Get();
        }

        public object Save(Designation designation)
        {
            return designationDao.Save(designation);
        }
        public object Search(Designation designation)
        {
            return designationDao.Search(designation);
        }

        public object GetDesignationShort()
        {
            return designationDao.GetDesignationShort();
        }

        public object GetEmpDesignation(string DesignationDesc)
        {
            return designationDao.GetEmpDesignation(DesignationDesc);
        }
    }
}