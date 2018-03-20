using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.GeneralMasterParameters;

namespace DataObjects.Interfaces.GeneralMasterParameters
{
    public interface IDepartmentMapDao
    {
        object Get();

        object Save(DepartmentMap departmentMap);

        object Search(DepartmentMap departmentMap);

        object GetOfficeDepartment(string officeCode);

    }
}
