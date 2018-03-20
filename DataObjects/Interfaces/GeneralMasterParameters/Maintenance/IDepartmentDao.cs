using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.GeneralMasterParameters;

namespace DataObjects.Interfaces.GeneralMasterParameters
{
    public interface IDepartmentDao
    {
        object Get();

        object Save(Department department);

        object Search(Department department);

        object GetDepartmentShort();

        object GetDepartment(string OfficeCode);

    }
}
