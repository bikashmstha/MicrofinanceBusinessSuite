using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.CollectionSheetTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IUnapprovedCollectionDao
    {


        object SaveUnapprovedCollection(UnapprovedCollection unapprovedCollection);

        object SearchUnapprovedCollection(UnapprovedCollection unapprovedCollection);



        object GetGetUnapprovedColl(string OfficeCode);

    }
}
