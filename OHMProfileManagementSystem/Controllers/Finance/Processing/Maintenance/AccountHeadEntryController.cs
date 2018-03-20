using BusinessObjects;
using BusinessObjects.Finance;
using DataObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Maintenance
{
    public class AccountHeadEntryController:ControllerBase
    {
        private static IAccountHeadEntryDao accountHeadEntryDao = DataAccess.AccountHeadEntryDao;

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<AccountHeadEntry> SearchAccountHead(AccountHeadEntry accountHead)
        {
            // OfficeRequest req = new OfficeRequest();


            //req.User = this.User;
            List<AccountHeadEntry> accountHeads = accountHeadEntryDao.SearchAccountHead(accountHead);

            return accountHeads;
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<AccountHeadEntry> SearchAccountEntry(string accountNo,string accountNameDesc,string groupId)
        {
            List<AccountHeadEntry> response;
            try
            {
                response = accountHeadEntryDao.GetSearchAccountHead(accountNo, accountNameDesc, groupId);
            }
            catch (Exception ex)
            {

                throw ex;
            }


            return response;

        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public OutMessage SaveAccountHeadEntry(AccountHeadEntry accountHeadEntry)
        {
            OutMessage response;
            try
            {
                response = accountHeadEntryDao.SaveAccountHeadEntry(accountHeadEntry);

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return response;

        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public object GetContraAccount(string offCode, string accountDesc)
        {
            return accountHeadEntryDao.GetContraAccount(offCode, accountDesc);
        }

       
    }
}