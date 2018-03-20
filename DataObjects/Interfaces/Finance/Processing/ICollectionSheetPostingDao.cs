using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Processing;

namespace DataObjects.Interfaces.Finance
{
    public interface ICollectionSheetPostingDao
    {


        object SaveCollectionSheetPosting(CollectionSheetPosting collectionSheetPosting);

        object SearchCollectionSheetPosting(CollectionSheetPosting collectionSheetPosting);


    }
}
