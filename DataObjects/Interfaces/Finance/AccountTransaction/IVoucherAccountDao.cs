using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.AccountTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IVoucherAccountDao
    {


        object SaveVoucherAccount(VoucherAccount voucherAccount);

        object SearchVoucherAccount(VoucherAccount voucherAccount);



        object GetVoucherAcc(string OfficeCode, string AccountDesc);

    }
}
