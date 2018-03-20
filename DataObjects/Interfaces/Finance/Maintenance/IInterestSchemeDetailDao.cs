using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Finance.Maintenance;

namespace DataObjects.Interfaces.Finance
{
    public interface IInterestSchemeDetailDao
    {


        object SaveInterestSchemeDetail(InterestSchemeDetail interestSchemeDetail);

        object SearchInterestSchemeDetail(InterestSchemeDetail interestSchemeDetail);



        object GetIntSchemeDtl(string IntSchemeCode);

    }
}
