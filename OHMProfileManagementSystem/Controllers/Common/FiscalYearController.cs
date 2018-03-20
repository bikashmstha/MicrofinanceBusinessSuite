using BusinessObjects.Message;
using DataObjects;
using MicrofinanceBusinessSuite.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using BusinessObjects;
using BusinessObjects.Common;
using DataObjects.Interfaces.Common;

namespace MicrofinanceBusinessSuite.Controllers.Common
{
    public class FiscalYearController:ControllerBase
    {
        private static IFiscalYearDao fiscalYearDao = DataAccess.FiscalYearDao;
        /// <summary>
        /// Gets a list of Applications.
        /// </summary>
        /// <param name="sortExpression">Desired sort order of the customer list.</param>
        /// <returns>List of customers.</returns>

        [DataObjectMethod(DataObjectMethodType.Select)]

        public object Get(string fiscalYear)
        {
            return fiscalYearDao.Get(fiscalYear);
        }

        public object Save(FiscalYear fiscalYear)
        {
            return fiscalYearDao.Save(fiscalYear);
        }
        public object Search(FiscalYear fiscalYear)
        {
            return fiscalYearDao.Search(fiscalYear);
        }
        public object GetFiscalYearShort(string fiscalYear)
        {
            return fiscalYearDao.GetFiscalYearShort(fiscalYear);
        }

        public object GetLastFiscalYearList(string offCode)
        {
            return fiscalYearDao.GetFiscalYearShort(offCode);
        }

        public object GetFiscalYear(string FiscalYear)
        {
            return fiscalYearDao.GetFiscalYear(FiscalYear);
        }

        public object GetFiscalYearByDate(string date)
        {
            return fiscalYearDao.GetFiscalYearByDate(date);
        }
        public object GetNextFiscalYear(string FiscalYear)
        {
            return fiscalYearDao.GetNextFiscalYear(FiscalYear);
        }
    }
}