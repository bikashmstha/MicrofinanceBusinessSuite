using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Common;
using DataObjects;
using DataObjects.Interfaces.Common;

namespace MicrofinanceBusinessSuite.Controllers.Common
{
    public class CountryController : ControllerBase
    {
        private static ICountryDao countryDao = DataAccess.CountryDao;

        public object Get()
        {
            return countryDao.Get();
        }

        public object Save(Country country)
        {
            return countryDao.Save(country);
        }
        public object Search(Country country)
        {
            return countryDao.Search(country);
        }

        public object GetCountryShort()
        {
            return countryDao.GetCountryShort();
        }

        public object GetCountryLov(string CountryName)
        {
            return countryDao.GetCountryLov(CountryName);
        }
    }
}