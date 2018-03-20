using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Security;
using DataObjects;
using DataObjects.Interfaces.GeneralMasterParameters;
using MicrofinanceBusinessSuite.Utility;
using BusinessObjects.Messages;
using BusinessObjects.Message;
using System.ComponentModel;
using BusinessObjects.GeneralMasterParameters;
using BusinessObjects;

namespace MicrofinanceBusinessSuite.Controllers.Maintenance
{
    public class MenuEntryController : ControllerBase
    {
        private static IMenuEntryDao menuEntryDao = DataAccess.MenuEntryDao;

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<MenuEntry> GetMenuLists(string moduleid,string tabid)
        {
            List<MenuEntry> response;
            try
            {
                response = menuEntryDao.GetMenuLists(moduleid, tabid);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return response;

        }
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public OutMessage SaveMenuEntry(MenuEntry menuEntry)
        {
            OutMessage response;
            try
            {
                response = menuEntryDao.SaveMenuEntry(menuEntry);

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return response;

        }
    }
}