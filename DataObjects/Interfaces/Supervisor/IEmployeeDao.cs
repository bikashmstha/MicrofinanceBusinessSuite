using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Supervisor;

namespace DataObjects.Interfaces.Supervisor
{
    public interface IEmployeeDao
    {
        object Get();

        object Save(Employee employee);

        object Search(Employee employee);

        object GetEmployeeShort(string officeCode, string employeeName);
        object GetToEmployeeShort(string employeeName);
        object GetFieldAssistants(string officeCode, string empName);

        object GetEmployee(string OfficeName, string UserCode, string EmpName);

        object GetEmployeeLov(string OfficeCode, string PostCode, string EmpName);
    }
}
