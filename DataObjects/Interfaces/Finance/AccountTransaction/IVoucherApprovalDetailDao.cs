using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.AccountTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IVoucherApprovalDetailDao
    {


        object SaveVoucherApprovalDetail(VoucherApprovalDetail VoucherApprovalDetail);

        object SearchVoucherApprovalDetail(VoucherApprovalDetail VoucherApprovalDetail);



        object GetVouApprovalDet(string VoucherNo);

    }
}
