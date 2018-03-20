using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Supervisor;

namespace DataObjects.Interfaces.Supervisor
{
    public interface IDepartmentDao
    {
        object Get();

        object Save(Department Department);

        object Search(Department Department);

    }
}
