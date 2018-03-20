using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Processing;

namespace DataObjects.Interfaces.Finance
{
    public interface IStaffDisbursementDao
    {


        object SaveStaffDisbursement(StaffDisbursement staffDisbursement);

        object SearchStaffDisbursement(StaffDisbursement staffDisbursement);



        object GetStaffDisbursement(string OfficeCode, string UserCode);

    }
}
