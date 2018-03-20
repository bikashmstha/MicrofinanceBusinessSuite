using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Processing;

namespace DataObjects.Interfaces.Finance
{
    public interface IDayBeginProcessDao
    {


        object SaveDayBeginProcess(DayBeginProcess dayBeginProcess);

        object SearchDayBeginProcess(DayBeginProcess dayBeginProcess);



    }
}
