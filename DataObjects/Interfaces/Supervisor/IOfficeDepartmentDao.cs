using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Supervisor;

namespace DataObjects.Interfaces.Supervisor
{
    public interface IOfficeDepartmentDao
    {
        object Get();

        object Save(OfficeDepartment OfficeDepartment);

        object Search(OfficeDepartment OfficeDepartment);

    }
}
