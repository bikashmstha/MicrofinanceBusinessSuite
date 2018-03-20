using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance;
namespace DataObjects.Interfaces.Finance
{
    public interface ICenterDao
    {
        object Get();

        object Save(Center center);

        object Search(Center center);

        object GetCenterChief(string centerCode, string memberName);

        object GetCenterListLov(string offCode, string centerName);
        object GetCenterList(string offCode, string centerName);

        object GetTransferCenterList(string offCode, string centerName, string oldCenterCode);
    }
}
