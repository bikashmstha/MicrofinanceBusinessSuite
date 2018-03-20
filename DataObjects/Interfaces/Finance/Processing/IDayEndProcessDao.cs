using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Processing;

namespace DataObjects.Interfaces.Finance
{
    public interface IDayEndProcessDao
    {


        object SaveDayEndProcess(DayEndProcess dayEndProcess);

        object SearchDayEndProcess(DayEndProcess dayEndProcess);



    }
}
