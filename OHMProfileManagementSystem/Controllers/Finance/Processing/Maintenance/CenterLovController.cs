using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance;
using DataObjects;
using DataObjects.Interfaces.Finance;
namespace MicrofinanceBusinessSuite.Controllers.Finance.Maintenance
{
    public class CenterLovController : ControllerBase
    {
        private static ICenterLovDao centerlovDao = DataAccess.CenterLovDao;

        public object Get()
        {
            return centerlovDao.Get();
        }

        public object Save(CenterLov centerlov)
        {
            return centerlovDao.Save(centerlov);
        }
        public object Search(CenterLov centerlov)
        {
            return centerlovDao.Search(centerlov);
        }

        public object GetTransferLovList(CenterLov centerlov)
        {
            return centerlovDao.GetTransferLovList(centerlov);
        }

    }
}