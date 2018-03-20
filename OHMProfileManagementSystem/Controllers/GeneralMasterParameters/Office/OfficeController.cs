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
using Oracle.DataAccess.Client;
using System.Data;


namespace MicrofinanceBusinessSuite.Controllers.GeneralMasterParameters
{
    public class OfficeController :ControllerBase
    {
        private static IOfficeDao officeDao = DataAccess.OfficeDao;
        /// <summary>
        /// Gets a list of Applications.
        /// </summary>
        /// <param name="sortExpression">Desired sort order of the customer list.</param>
        /// <returns>List of customers.</returns>
        /// 
        public object Get()
        {
            return officeDao.Get();
        }
        
        public object Search(Office office)
        {
            return officeDao.Search(office);
        }

        public object Save(Office office)
        {
            return officeDao.Save(office);
        }
            

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<Office> GetOfficeShort()
        {
            List<Office> officeTypes;
            try
            {
                officeTypes = officeDao.GetOfficeShort();
            }
            catch (Exception ex)
            {

                throw ex;
            }


            return officeTypes;
        }

        public object GetOfficeList(string userCode,string officeName)
        {
            return officeDao.GetOfficeList(userCode, officeName);
        }
        

        
    }
}