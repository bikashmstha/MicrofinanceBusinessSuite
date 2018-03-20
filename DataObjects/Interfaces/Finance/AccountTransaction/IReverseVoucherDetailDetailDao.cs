using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.AccountTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IReverseVoucherDetailDetailDao
    {


        object SaveReverseVoucherDetailDetail(ReverseVoucherDetailDetail reverseVoucherDetailDetail);

        object SearchReverseVoucherDetailDetail(ReverseVoucherDetailDetail reverseVoucherDetailDetail);



        object GetReverseVoucherDtlDetail(string VoucherNo);

    }
}
