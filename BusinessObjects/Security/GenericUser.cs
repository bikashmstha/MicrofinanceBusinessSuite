using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using BusinessObjects.BusinessRules;
using BusinessObjects.Enumerations;

namespace BusinessObjects.Security
{
    public abstract class GenericUser : BusinessObject
    {
        public abstract bool LoggedIn { get; set; }
        public abstract string DatabaseAccessUserName { get; }
        public abstract string DatabaseAccessUserPassword { get; }

    }
    //public interface GenericUser
    //{

    //     string DatabaseAccessUserName { get; set; }
    //     string DatabaseAccessUserPassword { get; set; }

    //}
}
