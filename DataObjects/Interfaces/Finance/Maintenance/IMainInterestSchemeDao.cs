using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Maintenance;

namespace DataObjects.Interfaces.Finance
{
    public interface IMainInterestSchemeDao
    {
        object Get();

        object Save(MainInterestScheme mainInterestScheme);

        object Search(MainInterestScheme mainInterestScheme);

    }
}
