using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.HumanResource.Transaction;

namespace DataObjects.Interfaces.HumanResource
{
    public interface IEmployeeTrainingDetailDao
    {


        object SaveEmployeeTrainingDetail(EmployeeTrainingDetail employeeTrainingDetail);

        object SearchEmployeeTrainingDetail(EmployeeTrainingDetail employeeTrainingDetail);



        object GetEmpTrainingDetail(string EmpId);

    }
}
