using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.PublicSavingTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IGroupBasedMemberDao
    {


        object SaveGroupBasedMember(GroupBasedMember groupBasedMember);

        object SearchGroupBasedMember(GroupBasedMember groupBasedMember);



        object GetGroupBasedMem(string OfficeCode, string ClientName);

    }
}
