using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.GeneralMasterParameters;
using BusinessObjects.GeneralMasterParameters.Maintenance;
using DataObjects;
using DataObjects.Interfaces.GeneralMasterParameters;
using MicrofinanceBusinessSuite.Controllers;

namespace MicrofinanceBusinessSuite.Controllers.GeneralMasterParameters
{
    public class HolidayController:ControllerBase
    {
        private static IHolidayDao holidayDao = DataAccess.HolidayDao;

        public object Get(string startDate, string endDate)
        {
            return holidayDao.Get(startDate,endDate);
        }

        public object Save(Holiday holiday)
        {
            return holidayDao.Save(holiday);
        }
        public object Search(Holiday holiday)
        {
            return holidayDao.Search(holiday);
        }
    }
}