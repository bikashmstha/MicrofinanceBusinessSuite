using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Security;

namespace DataObjects.Security
{
    public interface IRoleDao
    {
        object Get();

        object Save(Role role);

        object Search(Role role);

    }
}
