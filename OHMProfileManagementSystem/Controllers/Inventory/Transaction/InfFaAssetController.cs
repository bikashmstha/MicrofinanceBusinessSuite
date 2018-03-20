using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Inventory.Transaction;
using DataObjects;
using DataObjects.Interfaces.Inventory;

namespace MicrofinanceBusinessSuite.Controllers.Inventory.Transaction
{
    public class InfFaAssetController : ControllerBase
    {
        private static IInfFaAssetDao infFaAssetDao = DataAccess.InfFaAssetDao;



        public object SaveInfFaAsset(InfFaAsset infFaAsset)
        {
            return infFaAssetDao.SaveInfFaAsset(infFaAsset);
        }
        public object SearchInfFaAsset(InfFaAsset infFaAsset)
        {
            return infFaAssetDao.SearchInfFaAsset(infFaAsset);
        }
    }
}