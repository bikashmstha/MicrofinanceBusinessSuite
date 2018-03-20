using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.AccountTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IReverseVoucherDao
    {


        object SaveReverseVoucher(ReverseVoucher reverseVoucher);

        object SearchReverseVoucher(ReverseVoucher reverseVoucher);



        object GetReverseVoucher(string OfficeCode, string FiscalYear, string Particulars);

    }
}
