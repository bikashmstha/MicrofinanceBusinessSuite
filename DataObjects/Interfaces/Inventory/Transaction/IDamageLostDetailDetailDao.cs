using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Inventory.Transaction;

namespace DataObjects.Interfaces.Inventory
{
    public interface IDamageLostDetailDetailDao
    {


        object SaveDamageLostDetailDetail(DamageLostDetailDetail damageLostDetailDetail);

        object SearchDamageLostDetailDetail(DamageLostDetailDetail damageLostDetailDetail);



        object GetDamageLostDtlDetail(string ReferenceNo);

    }
}
