using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Inventory.Transaction;

namespace DataObjects.Interfaces.Inventory
{
    public interface IAssetMaintenanceDetailDao
    {


        object SaveAssetMaintenanceDetail(AssetMaintenanceDetail assetMaintenanceDetail);

        object SearchAssetMaintenanceDetail(AssetMaintenanceDetail assetMaintenanceDetail);



        object GetAssetMaintenanceDtl(string AssetCode);

    }
}
