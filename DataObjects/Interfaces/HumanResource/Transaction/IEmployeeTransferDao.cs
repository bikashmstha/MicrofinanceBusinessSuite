using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.HumanResource.Transaction;

namespace DataObjects.Interfaces.HumanResource
{
    public interface IEmployeeTransferDao
    {


        object SaveEmployeeTransfer(EmployeeTransfer employeeTransfer);

        object SearchEmployeeTransfer(EmployeeTransfer employeeTransfer);



    }
}
