using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using BusinessObjects;
using BusinessObjects.Finance;
using BusinessObjects.Finance.Maintenance;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Maintenance
{
    public class SavingProductDetailController : ControllerBase
    {
        private static ISavingProductDetailDao savingProductDetailDao = DataAccess.SavingProductDetailDao;



        public object SaveSavingProductDetail(SavingProductDetail savingProductDetail)
        {
            return savingProductDetailDao.SaveSavingProductDetail(savingProductDetail);
        }
        public object SearchSavingProductDetail(SavingProductDetail savingProductDetail)
        {
            return savingProductDetailDao.SearchSavingProductDetail(savingProductDetail);
        }

        public object GetSavingProductDetail()
        {
            return savingProductDetailDao.GetSavingProductDetail();
        }

    }
}