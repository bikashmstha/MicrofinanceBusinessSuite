using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Processing;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Processing
{
    public class CallAbbsAdjustmentController : ControllerBase
    {
        private static ICallAbbsAdjustmentDao callAbbsAdjustmentDao = DataAccess.CallAbbsAdjustmentDao;



        public object SaveCallAbbsAdjustment(CallAbbsAdjustment callAbbsAdjustment)
        {
            return callAbbsAdjustmentDao.SaveCallAbbsAdjustment(callAbbsAdjustment);
        }
        public object SearchCallAbbsAdjustment(CallAbbsAdjustment callAbbsAdjustment)
        {
            return callAbbsAdjustmentDao.SearchCallAbbsAdjustment(callAbbsAdjustment);
        }
    }
}