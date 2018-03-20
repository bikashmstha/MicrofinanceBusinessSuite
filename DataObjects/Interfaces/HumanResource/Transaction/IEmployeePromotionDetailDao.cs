using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.HumanResource.Transaction;

namespace DataObjects.Interfaces.HumanResource
{
    public interface IEmployeePromotionDetailDao
    {


        object SaveEmployeePromotionDetail(EmployeePromotionDetail employeePromotionDetail);

        object SearchEmployeePromotionDetail(EmployeePromotionDetail employeePromotionDetail);



        object GetEmpPromotionDetail(string EmpId);

    }
}
