using BusinessObjects.GeneralMasterParameters;
using BusinessObjects.Message;
using DataObjects;
using DataObjects.Interfaces.GeneralMasterParameters;
using MicrofinanceBusinessSuite.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MicrofinanceBusinessSuite.Controllers.Common
{
    public class TabController : ControllerBase
    {
        private static ITabDao tabDao = DataAccess.TabDao;
        /// <summary>
        /// Gets a list of Applications.
        /// </summary>
        /// <param name="sortExpression">Desired sort order of the customer list.</param>
        /// <returns>List of customers.</returns>

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<Tab> SearchTab(Tab tab)
        {

            List<Tab> response;
            try
            {
                response = tabDao.SearchTab(tab);
            }
            catch (Exception ex)
            {

                throw ex;
            }


            return response;

        }


    }
}