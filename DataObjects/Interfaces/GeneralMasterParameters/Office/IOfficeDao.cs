using BusinessObjects.GeneralMasterParameters;
using BusinessObjects.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects.Interfaces.GeneralMasterParameters
{
    public interface IOfficeDao
    {
        //List<Office> GetOffices(int? groupID);
        //string SaveOffice( Office office);
        //List<Office> SearchOffice(Office office);
        object Get();

        object Save(Office office);

        object Search(Office office);

        List<Office> GetOfficeShort();

        object GetOfficeList(string userCode, string officeName);
        
    }
}
