using BusinessObjects.GeneralMasterParameters;
using BusinessObjects.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects.Interfaces.GeneralMasterParameters
{
    public interface IHolidayListDao
    {
        
        List<HolidayList> GetHolidayList(string FiscalYear,string StartDate,string EndDate, GenericUser User);
    }
}
