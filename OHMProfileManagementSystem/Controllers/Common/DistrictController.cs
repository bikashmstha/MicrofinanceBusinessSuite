using BusinessObjects.Message;
using DataObjects;
using MicrofinanceBusinessSuite.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using DataObjects.Interfaces.Common;
using BusinessObjects.Common;

namespace MicrofinanceBusinessSuite.Controllers.Common
{
    public class DistrictController : ControllerBase
    {
        private static IDistrictDao districtDao = DataAccess.DistrictDao;
        /// <summary>
        /// Gets a list of Applications.
        /// </summary>
        /// <param name="sortExpression">Desired sort order of the customer list.</param>
        /// <returns>List of customers.</returns>
      
        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<District> SearchDistrict(District district)
        {

            List<District> response;
            try
            {
                response = districtDao.SearchDistrict(district);
            }
            catch (Exception ex)
            {

                throw ex;
            }


            return response;

        }
        public object GetDistrictList(string districtName)
        {
            return districtDao.GetDistrictList(districtName);
        }
       
    }
}