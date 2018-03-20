using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.GeneralMasterParameters;
using BusinessObjects.GeneralMasterParameters.Maintenance;
using DataObjects;
using DataObjects.Interfaces.GeneralMasterParameters;
using MicrofinanceBusinessSuite.Controllers;
namespace MicrofinanceBusinessSuite.Controllers.GeneralMasterParameters.Maintenance
{
    public class OfficeWiseHolidayController:ControllerBase
    {
        private static IOfficeWiseHolidayDao officeWiseHolidayDao = DataAccess.OfficeWiseHolidayDao;

        public object Get(string offCode,string startDate, string endDate)
        {
            return officeWiseHolidayDao.Get(offCode,startDate, endDate);
        }

        public object Save(OfficeWiseHoliday officeWiseHoliday)
        {
            return officeWiseHolidayDao.Save(officeWiseHoliday);
        }
        public object Search(OfficeWiseHoliday officeWiseHoliday)
        {
            return officeWiseHolidayDao.Search(officeWiseHoliday);
        }
    }
}