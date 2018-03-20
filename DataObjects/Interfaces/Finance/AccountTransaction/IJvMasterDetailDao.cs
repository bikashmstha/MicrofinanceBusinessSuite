using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.AccountTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IJvMasterDetailDao
    {


        object SaveJvMasterDetail(JvMasterDetail jVMasterDetail);

        object SearchJvMasterDetail(JvMasterDetail jVMasterDetail);



        object GetJvMstDetail(string OfficeCode, string VoucherNo, string FromDate, string ToDate);

    }
}
