using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.StaffLoanTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IEmployeeKycClientDao
    {


        object SaveEmployeeKycClient(EmployeeKycClient employeeKycClient);

        object SearchEmployeeKycClient(EmployeeKycClient employeeKycClient);



        object GetEmpKycClientSearch(string OfficeCode, string EmpName);

    }
}
