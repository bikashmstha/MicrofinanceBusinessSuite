using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Supervisor;
using DataObjects;
using DataObjects.Interfaces.Supervisor;
namespace MicrofinanceBusinessSuite.Controllers.Supervisor
{
    public class EmployeeController:ControllerBase
    {
        private static IEmployeeDao employeeDao = DataAccess.EmployeeDao;


        public object Get()
        {
            return employeeDao.Get();
        }

        public object Save(Employee employee)
        {
            return employeeDao.Save(employee);
        }
        public object Search(Employee employee)
        {
            return employeeDao.Search(employee);
        }
        public object GetEmployeeShort(string officeCode, string employeeName)
        {
            return employeeDao.GetEmployeeShort(officeCode,employeeName);
        }
        public object GetToEmployeeShort(string employeeName)
        {
            return employeeDao.GetToEmployeeShort(employeeName);
        }
        public object GetFieldAssistants(string officeCode, string empName)
        {
            return employeeDao.GetFieldAssistants(officeCode, empName);
        }

        public object GetEmployee(string OfficeName, string UserCode, string EmpName)
        {
            return employeeDao.GetEmployee(OfficeName, UserCode, EmpName);
        }


        public object GetEmployeeLov(string OfficeCode, string PostCode, string EmpName)
        {
            return employeeDao.GetEmployeeLov(OfficeCode, PostCode, EmpName);
        }
    }
}