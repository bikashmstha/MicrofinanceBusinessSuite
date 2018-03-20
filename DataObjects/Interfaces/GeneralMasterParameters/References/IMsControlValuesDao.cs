using BusinessObjects;
using BusinessObjects.GeneralMasterParameters.References;
using BusinessObjects.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects.Interfaces.GeneralMasterParameters
{
    public interface IMsControlValuesDao
    {
        List<MsControlValues> GetMsControlValues();
        OutMessage SaveMsControlValues(MsControlValues msControlValues);
        
    }
}
