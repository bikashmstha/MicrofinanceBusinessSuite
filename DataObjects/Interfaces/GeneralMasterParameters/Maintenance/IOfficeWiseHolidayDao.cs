using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.GeneralMasterParameters;
using BusinessObjects.GeneralMasterParameters.Maintenance;

namespace DataObjects.Interfaces.GeneralMasterParameters
{
    public interface IOfficeWiseHolidayDao
    {
        object Get(string offCode, string startDate, string endDate);

        object Save(OfficeWiseHoliday officeWiseHoliday);

        object Search(OfficeWiseHoliday officeWiseHoliday);

        object GetOfficeWiseHolidayShort(string offCode,string startDate, string endDate);
    }
}
