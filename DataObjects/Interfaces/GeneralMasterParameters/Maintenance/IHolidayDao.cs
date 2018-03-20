using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.GeneralMasterParameters;
using BusinessObjects.GeneralMasterParameters.Maintenance;

namespace DataObjects.Interfaces.GeneralMasterParameters
{
    public interface IHolidayDao
    {
        object Get(string startDate, string endDate);

        object Save(Holiday holiday);

        object Search(Holiday holiday);

        object GetHolidayShort(string startDate, string endDate);
    }
}
