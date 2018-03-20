using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.AccountTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IReverseVoucherMasterDetailDao
    {


        object SaveReverseVoucherMasterDetail(ReverseVoucherMasterDetail reverseVoucherMasterDetail);

        object SearchReverseVoucherMasterDetail(ReverseVoucherMasterDetail reverseVoucherMasterDetail);



        object GetReverseVoucherMstDtl();

    }
}
