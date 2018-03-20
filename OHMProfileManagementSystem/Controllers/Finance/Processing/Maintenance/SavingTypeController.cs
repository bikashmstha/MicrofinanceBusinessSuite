using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using BusinessObjects;
using BusinessObjects.Finance.Maintenance;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Maintenance
{
    public class SavingTypeController : ControllerBase
    {
        private static ISavingTypeDao savingTypeDao = DataAccess.SavingTypeDao;



        public object SaveSavingType(SavingType savingType)
        {
            return savingTypeDao.SaveSavingType(savingType);
        }
        public object SearchSavingType(SavingType savingType)
        {
            return savingTypeDao.SearchSavingType(savingType);
        }

        public object GetSavingType(string SavingProductType)
        {
            return savingTypeDao.GetSavingType(SavingProductType);
        }

    }
}