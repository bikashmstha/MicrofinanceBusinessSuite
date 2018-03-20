using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.StaffLoanTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IEmployeeKycDetailDao
    {


        object SaveEmployeeKycDetail(EmployeeKycDetail employeeKycDetail);

        object SearchEmployeeKycDetail(EmployeeKycDetail employeeKycDetail);



        object GetEmpKycDetail(string OfficeCode, string ClientCode, string ClientName, string DateFrom, string DateTo);

    }
}
