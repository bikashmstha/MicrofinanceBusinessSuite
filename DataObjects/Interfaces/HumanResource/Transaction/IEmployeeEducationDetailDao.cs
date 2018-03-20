using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.HumanResource.Transaction;

namespace DataObjects.Interfaces.HumanResource
{
    public interface IEmployeeEducationDetailDao
    {


        object SaveEmployeeEducationDetail(EmployeeEducationDetail employeeEducationDetail);

        object SearchEmployeeEducationDetail(EmployeeEducationDetail employeeEducationDetail);



        object GetEmpEducationDetail(string EmpId);

    }
}
