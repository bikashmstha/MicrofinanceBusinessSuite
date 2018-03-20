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
    public class ReportController:ControllerBase
    {
        private static IReportDao reportDao = DataAccess.ReportDao;
        /// <summary>
        /// Gets a list of Applications.
        /// </summary>
        /// <param name="sortExpression">Desired sort order of the customer list.</param>
        /// <returns>List of customers.</returns>

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<Report> GetReportShort(string moduleId, string tabId)
        {

            List<Report> response;
            try
            {
                response = reportDao.GetReportShort(moduleId,tabId);
            }
            catch (Exception ex)
            {

                throw ex;
            }


            return response;

        }

    }
}