using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects.Interfaces.Finance
{
    public interface IGenerateSavingCollectionDao
    {
        object GenerateSavingCollection(string offCode, string sheetNo, string centerCode, string collectionDate);
    }
}
