using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

using System.Collections.Generic;
using BusinessObjects;
using System.Runtime.Serialization;

using BusinessObjects.MessageBase;
using BusinessObjects.Security;

namespace BusinessObjects.Messages
{
    /// <summary>
    /// Represents a customer response message to client
    /// </summary>    
    public class LoginResponse : ResponseBase
    {
        public GenericUser User;

        
    }
}
