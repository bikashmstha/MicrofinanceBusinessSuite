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
    public class ABBSChargeController
    {
        private static IABBSChargeDao savingABBSChargeDao = DataAccess.ABBSChargeDao;

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<ABBSCharge> GetABBSCharge(string office, string toOffice, string abbsType)
        {
            List<ABBSCharge> response;
            try
            {
                response = savingABBSChargeDao.GetABBSCharge(office,toOffice,abbsType);
            }
            catch (Exception ex)
            {

                throw ex;
            }


            return response;

        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public OutMessage SaveABBSCharge(ABBSCharge aBBSCharge)
        {
            OutMessage response;
            try
            {
                response = savingABBSChargeDao.SaveABBSCharge(aBBSCharge);

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return response;

        }
    }
}