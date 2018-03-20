using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.AccountTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IRegenerateFiscalYearClosingDao
    {


        object SaveRegenerateFiscalYearClosing(RegenerateFiscalYearClosing regenerateFiscalYearClosing);

        object SearchRegenerateFiscalYearClosing(RegenerateFiscalYearClosing regenerateFiscalYearClosing);


    }
}
