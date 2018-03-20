using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Inventory.Transaction;

namespace DataObjects.Interfaces.Inventory
{
    public interface IDamageLostMasterDetailDao
    {


        object SaveDamageLostMasterDetail(DamageLostMasterDetail damageLostMasterDetail);

        object SearchDamageLostMasterDetail(DamageLostMasterDetail damageLostMasterDetail);



        object GetDamageLostMstDetail(string OfficeCode, string ReferenceNo, string FiscalYear, string LocationCode, string FromDate, string ToDate);

    }
}
