using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects.Interfaces.GeneralMasterParameters
{
    public  interface IMsReferenceCodeDetailsDao
    {
        object GetReferenceDetailListShort(string referenceCode);
    }
}
