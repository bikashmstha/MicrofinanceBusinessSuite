using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.LoanTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;
namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.LoanTransaction
{
    public class LasMemberController : ControllerBase
    {
        private static ILasMemberDao lasMemberDao = DataAccess.LasMemberDao;

        public object Get()
        {
            return lasMemberDao.Get();
        }

        public object Save(LasMember lasMember)
        {
            return lasMemberDao.Save(lasMember);
        }
        public object Search(LasMember lasMember)
        {
            return lasMemberDao.Search(lasMember);
        }
        public object GetLasMember( string offCode, string clientName, string centerCode, string productCode)
        {
            return lasMemberDao.GetLasMember(offCode,clientName,centerCode,productCode);
        }
    }
}