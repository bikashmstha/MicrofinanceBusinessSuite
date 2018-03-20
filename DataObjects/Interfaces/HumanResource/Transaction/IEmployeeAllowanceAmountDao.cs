using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.HumanResource.Transaction;

namespace DataObjects.Interfaces.HumanResource
{
    public interface IEmployeeAllowanceAmountDao
    {


        object SaveEmployeeAllowanceAmount(EmployeeAllowanceAmount employeeAllowanceAmount);

        object SearchEmployeeAllowanceAmount(EmployeeAllowanceAmount employeeAllowanceAmount);



        object GetEmpAllowanceAmt(long Sno, string FiscalYear, string PostCode);

    }
}
