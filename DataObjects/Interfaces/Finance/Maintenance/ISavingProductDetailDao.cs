using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Finance;
using BusinessObjects.Finance.Maintenance;

namespace DataObjects.Interfaces.Finance
{
    public interface ISavingProductDetailDao
    {


        object SaveSavingProductDetail(SavingProductDetail savingProductDetail);

        object SearchSavingProductDetail(SavingProductDetail savingProductDetail);



        object GetSavingProductDetail();

    }
}
