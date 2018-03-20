
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance;

namespace DataObjects.Interfaces.Finance
{
    public interface IMemberDao
    {
        object Get();

        object Save(Member member);

        object Search(Member member);

        object GetMemberList(string offCode, string centerCode, string memberName);

        object GetMemberLovList(string offCode, string centerCode, string memberName);

        object GetMemberForAccOpen(string offCode, string centerCode, string memberName);

        

    }
}
