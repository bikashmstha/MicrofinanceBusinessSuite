using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance;
using DataObjects;
using DataObjects.Interfaces.Finance;
namespace MicrofinanceBusinessSuite.Controllers.Finance
{
    public class CenterController:ControllerBase
    {
        
        private static ICenterDao centerDao = DataAccess.CenterDao;
        public object Get()
        {
            return centerDao.Get();
        }

        public object Save(Center center)
        {
            return centerDao.Save(center);
        }
        public object Search(Center center)
        {
            return centerDao.Search(center);
        }
        public object GetCenterChief(string centerCode, string memberName)
        {
            return centerDao.GetCenterChief(centerCode,memberName);
        }

        public object GetCenterListLov(string offCode, string centerName)
        {
            return centerDao.GetCenterListLov(offCode, centerName);
        }
        public object GetCenterList(string offCode, string centerName)
        {
            return centerDao.GetCenterList(offCode, centerName);
        }

        public object GetTransferCenterList(string offCode, string centerName,string oldCenterCode)
        {
            return centerDao.GetTransferCenterList(offCode, centerName,oldCenterCode);
        }
    }
}