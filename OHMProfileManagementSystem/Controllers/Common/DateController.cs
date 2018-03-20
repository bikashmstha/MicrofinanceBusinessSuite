using BusinessObjects;
using BusinessObjects.GeneralMasterParameters.References;
using BusinessObjects.Messages;
using BusinessObjects.Security;
using DataObjects;
using DataObjects.Interfaces.GeneralMasterParameters;
using MicrofinanceBusinessSuite.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using DataObjects.Interfaces.Common;

namespace MicrofinanceBusinessSuite.Controllers.Common
{
    public class DateController: ControllerBase
    {
        private static IDateDao dateDao = DataAccess.DateDao;

        public object GetNepDate(string engDate)
        {
            return dateDao.GetNepDate(engDate);
        }

        public object GetEngDate(string nepDate)
        {
            return dateDao.GetEngDate(nepDate);
        }
        


    }
}