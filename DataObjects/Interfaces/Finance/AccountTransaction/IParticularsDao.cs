using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.AccountTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IParticularsDao
    {


        object SaveParticulars(Particulars particulars);

        object SearchParticulars(Particulars particulars);



        object GetParticulars(string ParticularsDesc);

    }
}
