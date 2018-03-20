using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Processing;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Processing
{
    public class StaffDisbursementController : ControllerBase
    {
        private static IStaffDisbursementDao staffDisbursementDao = DataAccess.StaffDisbursementDao;



        public object SaveStaffDisbursement(StaffDisbursement staffDisbursement)
        {
            return staffDisbursementDao.SaveStaffDisbursement(staffDisbursement);
        }
        public object SearchStaffDisbursement(StaffDisbursement staffDisbursement)
        {
            return staffDisbursementDao.SearchStaffDisbursement(staffDisbursement);
        }

        public object GetStaffDisbursement(string OfficeCode, string UserCode)
        {
            return staffDisbursementDao.GetStaffDisbursement(OfficeCode, UserCode);
        }

    }
}