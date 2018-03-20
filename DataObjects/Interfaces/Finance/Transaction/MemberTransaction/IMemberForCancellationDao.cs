using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance;

namespace DataObjects.Interfaces.Finance
{
    public interface IMemberForCancellationDao
    {
        object Get();

        object Save(MemberForCancellation memberforcancellation);

        object Search(MemberForCancellation memberforcancellation);

        object GetMemberForCancelList(string offCode, string centerCode, string memberName, string clientNo);

    }
}
