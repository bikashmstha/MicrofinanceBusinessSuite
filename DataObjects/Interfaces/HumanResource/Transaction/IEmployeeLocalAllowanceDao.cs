using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.HumanResource.Transaction;

namespace DataObjects.Interfaces.HumanResource
{
    public interface IEmployeeLocalAllowanceDao
    {


        object SaveEmployeeLocalAllowance(EmployeeLocalAllowance employeeLocalAllowance);

        object SearchEmployeeLocalAllowance(EmployeeLocalAllowance employeeLocalAllowance);



    }
}
