using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.HumanResource.Transaction;

namespace DataObjects.Interfaces.HumanResource
{
    public interface IEmployeeTransferDetailDao
    {


        object SaveEmployeeTransferDetail(EmployeeTransferDetail employeeTransferDetail);

        object SearchEmployeeTransferDetail(EmployeeTransferDetail employeeTransferDetail);



        object GetEmpTransferDetail(string EmpId);

    }
}
