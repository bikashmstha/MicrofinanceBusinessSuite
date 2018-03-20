using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataObjects.Interfaces.Finance;
using BusinessObjects.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance
{
    public class MemberController : ControllerBase
    {
        private static IMemberDao memberDao = DataAccess.MemberDao;

        public object Get()
        {
            return memberDao.Get();
        }

        public object Save(Member member)
        {
            return memberDao.Save(member);
        }
        public object Search(Member member)
        {
            return memberDao.Search(member);
        }
        public object GetMemberList(string offCode, string centerCode, string memberName)
        {
            return memberDao.GetMemberList(offCode,centerCode,memberName);
        }

        public object GetMemberLovList(string offCode, string centerCode, string memberName)
        {
            return memberDao.GetMemberLovList(offCode, centerCode, memberName);
        }

       public object GetMemberForAccOpen(string offCode, string centerCode, string memberName)
        {
            return memberDao.GetMemberForAccOpen(offCode, centerCode, memberName);
        }
    }
}