using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Inventory.Transaction;

namespace DataObjects.Interfaces.Inventory
{
    public interface IAssetItemDao
    {


        object SaveAssetItem(AssetItem assetItem);

        object SearchAssetItem(AssetItem assetItem);



        object GetAssetItem(string ItemDesc);

    }
}
