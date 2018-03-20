using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Finance;

namespace DataObjects.Interfaces.Finance
{
    public interface IABBSChargeDao
    {
        List<ABBSCharge> GetABBSCharge(string office, string toOffice, string abbsType);
        OutMessage SaveABBSCharge(ABBSCharge aBBSCharge);
    }
}
