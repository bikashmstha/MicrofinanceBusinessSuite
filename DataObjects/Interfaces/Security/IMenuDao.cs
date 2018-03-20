using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BusinessObjects.Security;

namespace DataObjects.Security
{
    /// <summary>
    /// Defines methods to access and maintain customer data.
    /// This is a database-independent interface. 
    /// The implementations will be database specific.
    /// </summary>
    public interface IMenuDao
    {
        List<Menu> GetMenuListByUser(GenericUser user);

    }
}
