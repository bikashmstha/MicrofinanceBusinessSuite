using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using BusinessObjects;
using BusinessObjects.Finance;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Maintenance
{
    public class SavingMidTermInterestController:ControllerBase
    {
        private static ISavingMidTermInterestDao savingMidTermInterestDao = DataAccess.SavingMidTermInterest;

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<SavingMidTermInterest> GetSavingMidTermInterest()
        {
            List<SavingMidTermInterest> response;
            try
            {
                response = savingMidTermInterestDao.GetSavingMidTermInterest();
            }
            catch (Exception ex)
            {

                throw ex;
            }


            return response;

        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public OutMessage SaveSavingMidTermInterest(SavingMidTermInterest savingMidTermInterest)
        {
            OutMessage response;
            try
            {
                response = savingMidTermInterestDao.SaveSavingMidTermInterest(savingMidTermInterest);

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return response;

        }
    }
}