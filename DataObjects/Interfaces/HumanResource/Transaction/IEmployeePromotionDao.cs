using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.HumanResource.Transaction;

namespace DataObjects.Interfaces.HumanResource
{
    public interface IEmployeePromotionDao
    {


        object SaveEmployeePromotion(EmployeePromotion employeePromotion);

        object SearchEmployeePromotion(EmployeePromotion employeePromotion);



    }
}
