using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Security;

namespace DataObjects.Security
{
    /// <summary>
    /// Defines methods to access and maintain customer data.
    /// This is a database-independent interface. 
    /// The implementations will be database specific.
    /// </summary>
    public interface GenericUserDao
    {


        GenericUser LogIn(GenericUser user);

        object GetUserShort();
        object ResetUserPassword(string officeCode, string userCode, string newPwd, string cNewPwd, string changeByOfficeCode, string changeByUserCode);


        object Get();

        object Save(User user);

        object Search(User user);


    }
}
