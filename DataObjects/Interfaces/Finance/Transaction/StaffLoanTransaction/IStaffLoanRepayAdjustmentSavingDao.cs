using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.StaffLoanTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IStaffLoanRepayAdjustmentSavingDao
    {


        object SaveStaffLoanRepayAdjustmentSaving(StaffLoanRepayAdjustmentSaving staffLoanRepayAdjustmentSaving);

        object SearchStaffLoanRepayAdjustmentSaving(StaffLoanRepayAdjustmentSaving staffLoanRepayAdjustmentSaving);



        object GetStaffLoanRepayAdjSav(string OfficeCode, string ClientNo);

    }
}
