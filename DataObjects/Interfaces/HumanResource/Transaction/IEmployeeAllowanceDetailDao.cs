using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.HumanResource.Transaction;

namespace DataObjects.Interfaces.HumanResource
{
    public interface IEmployeeAllowanceDetailDao
    {


        object SaveEmployeeAllowanceDetail(EmployeeAllowanceDetail employeeAllowanceDetail);

        object SearchEmployeeAllowanceDetail(EmployeeAllowanceDetail employeeAllowanceDetail);



        object GetEmpAllowanceDetail(string EmpId, long? Sno, string FiscalYear);

    }
}
