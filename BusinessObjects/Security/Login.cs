using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using BusinessObjects.BusinessRules;

namespace BusinessObjects.Security
{
    /// <summary>
    /// Class that holds information about a Login Table.
    /// </summary>
    /// <remarks>
    /// Enterprise Design Pattern: Domain Model, Identity Field.
    /// 
    /// This is also the place where business rules are established.
    /// 
    /// The Domain Model Design Pattern states that domain objects incorporate 
    /// both behavior and data. Behavior may include simple or complex business logic.
    /// 
    /// The Identity Field Design Pattern saves the ID field in an object to maintain
    /// identity between an in-memory business object and that database rows.
    /// </remarks>
    public class Login : BusinessObject
    {
        public Login()
        { }

        public GenericUser user { get; set; }
        //public string SubmissionNo { get; set; }
        //public string SubmissionDate { get; set; }
        //public string UserName { get; set; }
        //public string Password { get; set; }
        //public string SubmissionFor { get; set; }
        //public string Email { get; set; }
        //public string Phone { get; set; }
        //public string Address { get; set; }
    }   
}
