using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.AccountTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IJvSearchVoucherDao
    {


        object SaveJvSearchVoucher(JvSearchVoucher jVSearchVoucher);

        object SearchJvSearchVoucher(JvSearchVoucher jVSearchVoucher);



        object GetJvSearchVoucher(string OfficeCode, string VoucherNo);

    }
}
