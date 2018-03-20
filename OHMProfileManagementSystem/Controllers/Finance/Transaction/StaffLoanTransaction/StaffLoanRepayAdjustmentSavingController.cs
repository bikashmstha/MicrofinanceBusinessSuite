using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.StaffLoanTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.StaffLoanTransaction
{
    public class StaffLoanRepayAdjustmentSavingController : ControllerBase
    {
        private static IStaffLoanRepayAdjustmentSavingDao staffLoanRepayAdjustmentSavingDao = DataAccess.StaffLoanRepayAdjustmentSavingDao;



        public object SaveStaffLoanRepayAdjustmentSaving(StaffLoanRepayAdjustmentSaving staffLoanRepayAdjustmentSaving)
        {
            return staffLoanRepayAdjustmentSavingDao.SaveStaffLoanRepayAdjustmentSaving(staffLoanRepayAdjustmentSaving);
        }
        public object SearchStaffLoanRepayAdjustmentSaving(StaffLoanRepayAdjustmentSaving staffLoanRepayAdjustmentSaving)
        {
            return staffLoanRepayAdjustmentSavingDao.SearchStaffLoanRepayAdjustmentSaving(staffLoanRepayAdjustmentSaving);
        }

        public object GetStaffLoanRepayAdjSav(string OfficeCode, string ClientNo)
        {
            return staffLoanRepayAdjustmentSavingDao.GetStaffLoanRepayAdjSav(OfficeCode, ClientNo);
        }

    }
}