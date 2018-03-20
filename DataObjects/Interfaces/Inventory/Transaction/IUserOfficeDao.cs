using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Inventory.Transaction;

namespace DataObjects.Interfaces.Inventory
{
    public interface IUserOfficeDao
    {


        object SaveUserOffice(UserOffice userOffice);

        object SearchUserOffice(UserOffice userOffice);



        object GetUserOffice(string UserCode, string OfficeName);

    }
}
