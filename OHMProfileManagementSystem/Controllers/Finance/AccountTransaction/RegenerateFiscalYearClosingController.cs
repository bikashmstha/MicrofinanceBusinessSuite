using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.AccountTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.AccountTransaction
{
    public class RegenerateFiscalYearClosingController : ControllerBase
    {
        private static IRegenerateFiscalYearClosingDao regenerateFiscalYearClosingDao = DataAccess.RegenerateFiscalYearClosingDao;



        public object SaveRegenerateFiscalYearClosing(RegenerateFiscalYearClosing regenerateFiscalYearClosing)
        {
            return regenerateFiscalYearClosingDao.SaveRegenerateFiscalYearClosing(regenerateFiscalYearClosing);
        }
        public object SearchRegenerateFiscalYearClosing(RegenerateFiscalYearClosing regenerateFiscalYearClosing)
        {
            return regenerateFiscalYearClosingDao.SearchRegenerateFiscalYearClosing(regenerateFiscalYearClosing);
        }
    }
}