using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.CollectionSheetTransaction;


namespace DataObjects.Interfaces.Finance
{
    public interface IOnlineCollectionCenterDao
    {
        object Get();

        object Save(OnlineCollectionCenter onlineCollectionCenter);

        object Search(OnlineCollectionCenter onlineCollectionCenter);

       object GetOnlineCenters(string date, string offCode, string centerName);

       object GetOnlineCenterList(string offCode, string centerName);

    }
}
