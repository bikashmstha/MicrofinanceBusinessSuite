using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.HumanResource.Transaction;

namespace DataObjects.Interfaces.HumanResource
{
    public interface IEmployeeEducationDao
    {


        object SaveEmployeeEducation(EmployeeEducation employeeEducation);

        object SearchEmployeeEducation(EmployeeEducation employeeEducation);



    }
}
