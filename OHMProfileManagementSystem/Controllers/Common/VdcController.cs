using BusinessObjects.Message;
using DataObjects;
using MicrofinanceBusinessSuite.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using BusinessObjects;
using BusinessObjects.Common;
using DataObjects.Interfaces.Common;

namespace MicrofinanceBusinessSuite.Controllers.Common
{
    public class VdcController : ControllerBase
    {
        private static IVdcDao VdcDao = DataAccess.VdcDao;
        /// <summary>
        /// Gets a list of Applications.
        /// </summary>
        /// <param name="sortExpression">Desired sort order of the customer list.</param>
        /// <returns>List of customers.</returns>

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<Vdc> SearchVdc(Vdc vdc)
        {
            // OfficeRequest req = new OfficeRequest();


            //req.User = this.User;
            List<Vdc> vdcs = VdcDao.SearchVdc(vdc);

            return vdcs;
        }
        public object Get()
        {
            return VdcDao.Get();
        }

        public object Save(Vdc Vdc)
        {
            return VdcDao.Save(Vdc);
        }
        public object Search(Vdc Vdc)
        {
            return VdcDao.Search(Vdc);
        }
        public object GetVDCShort(Vdc Vdc)
        {
            return VdcDao.GetVDCShort(Vdc);
        }

        
    } 
}