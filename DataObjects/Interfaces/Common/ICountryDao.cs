using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Common;

namespace DataObjects.Interfaces.Common
{
    public interface ICountryDao
    {
        object Get();

        object Save(Country country);

        object Search(Country country);

        object GetCountryShort();
        object GetCountryLov(string CountryName);
    }
}
