using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.HumanResource.Transaction;

namespace DataObjects.Interfaces.HumanResource
{
    public interface IEmployeeTrainingReceivedDao
    {


        object SaveEmployeeTrainingReceived(EmployeeTrainingReceived employeeTrainingReceived);

        object SearchEmployeeTrainingReceived(EmployeeTrainingReceived employeeTrainingReceived);



    }
}
