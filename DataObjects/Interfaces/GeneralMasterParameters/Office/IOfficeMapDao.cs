using BusinessObjects.GeneralMasterParameters;
using BusinessObjects.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects.Interfaces.GeneralMasterParameters
{
    public interface IOfficeMapDao
    {
        object Get();

        object Save(OfficeMap officeMap);

        object Search(OfficeMap officeMap);
    }
}
