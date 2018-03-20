using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Processing;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Processing
{
    public class DayEndProcessController : ControllerBase
    {
        private static IDayEndProcessDao dayEndProcessDao = DataAccess.DayEndProcessDao;



        public object SaveDayEndProcess(DayEndProcess dayEndProcess)
        {
            return dayEndProcessDao.SaveDayEndProcess(dayEndProcess);
        }
        public object SearchDayEndProcess(DayEndProcess dayEndProcess)
        {
            return dayEndProcessDao.SearchDayEndProcess(dayEndProcess);
        }
    }
}