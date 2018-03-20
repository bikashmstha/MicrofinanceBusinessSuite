using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Inventory.Transaction;
using DataObjects;
using DataObjects.Interfaces.Inventory;

namespace MicrofinanceBusinessSuite.Controllers.Inventory.Transaction
{
    public class AssetItemController : ControllerBase
    {
        private static IAssetItemDao assetItemDao = DataAccess.AssetItemDao;



        public object SaveAssetItem(AssetItem assetItem)
        {
            return assetItemDao.SaveAssetItem(assetItem);
        }
        public object SearchAssetItem(AssetItem assetItem)
        {
            return assetItemDao.SearchAssetItem(assetItem);
        }

        public object GetAssetItem(string ItemDesc)
        {
            return assetItemDao.GetAssetItem(ItemDesc);
        }

    }
}