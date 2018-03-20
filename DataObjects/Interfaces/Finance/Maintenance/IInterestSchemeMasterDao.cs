using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Finance.Maintenance;

namespace DataObjects.Interfaces.Finance
{
    public interface IInterestSchemeMasterDao
    {


        object SaveInterestSchemeMaster(InterestSchemeMaster interestSchemeMaster);

        object SearchInterestSchemeMaster(InterestSchemeMaster interestSchemeMaster);



        object GetIntSchemeMasterList(string IntSchemeCode, string IntSchemeDesc, string SchemeFor);

    }
}
