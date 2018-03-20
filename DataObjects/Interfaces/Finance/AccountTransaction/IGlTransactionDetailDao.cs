using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.AccountTransaction;
using Oracle.DataAccess.Client;

namespace DataObjects.Interfaces.Finance
{
    public interface IGlTransactionDetailDao
    {


        object SaveGlTransactionDetail(List<GlTransactionDetail> glTransactionDetails,OracleTransaction tran,string voucherNo);

        object SearchGlTransactionDetail(GlTransactionDetail glTransactionDetail);
    }
}
