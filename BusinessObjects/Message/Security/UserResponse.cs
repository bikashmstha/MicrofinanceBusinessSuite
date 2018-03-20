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
//using BusinessObjects.DataTransferObjects;

namespace BusinessObjects.Messages
{
    public class UserResponse:ResponseBase
    {
        public IList<User> LstUsers;

        public User User;

        public bool Status;

    }
}
