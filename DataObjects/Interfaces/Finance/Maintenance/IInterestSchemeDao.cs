using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Finance.Maintenance;

namespace DataObjects.Interfaces.Finance
{
    public interface IInterestSchemeDao
    {


        object SaveInterestScheme(InterestScheme interestScheme);

        object SearchInterestScheme(InterestScheme interestScheme);



        object GetInterestScheme(string IntSchemeDesc);

    }
}
