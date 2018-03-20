using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Processing;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Processing
{
    public class DayBeginProcessController : ControllerBase
    {
        private static IDayBeginProcessDao dayBeginProcessDao = DataAccess.DayBeginProcessDao;



        public object SaveDayBeginProcess(DayBeginProcess dayBeginProcess)
        {
            return dayBeginProcessDao.SaveDayBeginProcess(dayBeginProcess);
        }
        public object SearchDayBeginProcess(DayBeginProcess dayBeginProcess)
        {
            return dayBeginProcessDao.SearchDayBeginProcess(dayBeginProcess);
        }
    }
}