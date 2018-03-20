using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects.Interfaces.Finance
{
    public interface ICollectionSheetMasterDao
    {
        object UnenterCollectionSheetMaster(string offCode, string collectionSheetNo, string username);
             
    }
}
