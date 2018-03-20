using System;
using System.Data;
using System.Configuration;
using System.Runtime.Serialization;

using BusinessObjects.MessageBase;
using BusinessObjects.Criteria;
using BusinessObjects.Security;
//using BusinessObjects.DataTransferObjects;

namespace BusinessObjects.Messages
{
    public class UserRequest : RequestBase
    {
        //public GenericUser User;

        public string OfficeCode;


        public string UserID;
        public string Status;
    }
}
