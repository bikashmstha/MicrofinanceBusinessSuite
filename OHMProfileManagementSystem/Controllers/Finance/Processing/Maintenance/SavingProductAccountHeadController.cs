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
    public class SavingProductAccountHeadController : ControllerBase
    {
        private static ISavingProductAccountHeadDao savingProductAccountHeadDao = DataAccess.SavingProductAccountHeadDao;



        public object SaveSavingProductAccountHead(SavingProductAccountHead savingProductAccountHead)
        {
            return savingProductAccountHeadDao.SaveSavingProductAccountHead(savingProductAccountHead);
        }
        public object SearchSavingProductAccountHead(SavingProductAccountHead savingProductAccountHead)
        {
            return savingProductAccountHeadDao.SearchSavingProductAccountHead(savingProductAccountHead);
        }

        public object GetSavingProAccHead(string AccountDesc)
        {
            return savingProductAccountHeadDao.GetSavingProAccHead(AccountDesc);
        }

    }
}