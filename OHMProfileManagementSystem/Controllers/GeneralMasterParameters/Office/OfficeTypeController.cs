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


namespace MicrofinanceBusinessSuite.Controllers.GeneralMasterParameters
{
    public class OfficeTypeController : ControllerBase
    {
        private static IOfficeTypeDao officeTypeDao = DataAccess.OfficeTypeDao;
        /// <summary>
        /// Gets a list of Applications.
        /// </summary>
        /// <param name="sortExpression">Desired sort order of the customer list.</param>
        /// <returns>List of customers.</returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<OfficeType> GetOfficeTypes()
        {
            List<OfficeType> officeTypes = officeTypeDao.GetOfficeTypes();
            return officeTypes;
        }

    }
}