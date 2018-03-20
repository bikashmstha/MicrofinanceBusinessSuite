using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.PublicSavingTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IPublicMemberDao
    {

        object SavePublicMember(PublicMember publicMember);

        object SearchPublicMember(PublicMember publicMember);

    }
}
