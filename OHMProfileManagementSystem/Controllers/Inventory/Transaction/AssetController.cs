using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Inventory.Transaction;
using DataObjects;
using DataObjects.Interfaces.Inventory;
namespace MicrofinanceBusinessSuite.Controllers.Inventory.Transaction
{
    public class AssetController : ControllerBase
    {
        private static IAssetDao assetDao = DataAccess.AssetDao;



        public object SaveAsset(Asset asset)
        {
            return assetDao.SaveAsset(asset);
        }
        public object SearchAsset(Asset asset)
        {
            return assetDao.SearchAsset(asset);
        }

        public object GetAsset(string AssetCode, string Category, string AssetDesc)
        {
            return assetDao.GetAsset(AssetCode, Category, AssetDesc);
        }

        public object GetAssetSearch(string AssetDesc)
        {
            return assetDao.GetAssetSearch(AssetDesc);
        }

    }
}