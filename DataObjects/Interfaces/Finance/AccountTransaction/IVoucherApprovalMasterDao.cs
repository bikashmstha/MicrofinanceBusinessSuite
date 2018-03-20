using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.AccountTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IVoucherApprovalMasterDao
    {


        object SaveVoucherApprovalMaster(VoucherApprovalMaster VoucherApprovalMaster);

        object SearchVoucherApprovalMaster(VoucherApprovalMaster VoucherApprovalMaster);



        object GetVouApprovalMst(string OfficeCode);

    }
}
