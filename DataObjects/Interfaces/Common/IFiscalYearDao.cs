using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Common;

namespace DataObjects.Interfaces.Common
{
    public interface IFiscalYearDao
    {
        object Get(string fiscalYear);

        object Save(FiscalYear fiscalYear);

        object Search(FiscalYear fiscalYear);

        object GetFiscalYearShort(string fiscalYear);

        object GetLastFiscalYearList(string offCode);

        object GetFiscalYear(string FiscalYear);

        object GetFiscalYearByDate(string date);

        object GetNextFiscalYear(string FiscalYear);
    }
}
