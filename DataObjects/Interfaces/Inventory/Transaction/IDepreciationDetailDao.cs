using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Inventory.Transaction;

namespace DataObjects.Interfaces.Inventory
{
    public interface IDepreciationDetailDao
    {


        object SaveDepreciationDetail(DepreciationDetail depreciationDetail);

        object SearchDepreciationDetail(DepreciationDetail depreciationDetail);



        object GetDepreciationDetail(string AssetCode);

    }
}
