using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Inventory.Transaction;

namespace DataObjects.Interfaces.Inventory
{
    public interface IAssetDao
    {


        object SaveAsset(Asset asset);

        object SearchAsset(Asset asset);

        object GetAsset(string AssetCode, string Category, string AssetDesc);

        object GetAssetSearch(string AssetDesc);

    }
}
