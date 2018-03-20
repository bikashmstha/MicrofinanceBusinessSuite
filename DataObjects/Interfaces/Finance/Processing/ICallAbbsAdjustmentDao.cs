using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Processing;

namespace DataObjects.Interfaces.Finance
{
    public interface ICallAbbsAdjustmentDao
    {


        object SaveCallAbbsAdjustment(CallAbbsAdjustment callAbbsAdjustment);

        object SearchCallAbbsAdjustment(CallAbbsAdjustment callAbbsAdjustment);



    }
}
