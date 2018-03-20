using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.StaffLoanTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IEmployeeKycEmployeeDao
    {


        object SaveEmployeeKycEmployee(EmployeeKycEmployee employeeKycEmployee);

        object SearchEmployeeKycEmployee(EmployeeKycEmployee employeeKycEmployee);



        object GetEmpKycEmp(string OfficeCode, string EmpName);

    }
}
