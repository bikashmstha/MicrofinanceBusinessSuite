using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.AccountTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IJvDtlDetailDao
    {


        object SaveJvDtlDetail(JvDtlDetail jVDtlDetail);

        object SearchJvDtlDetail(JvDtlDetail jVDtlDetail);



        object GetJvDtlDetail(string VoucherNo);

    }
}
