using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.GeneralMasterParameters.Maintenance;

namespace DataObjects.Interfaces.GeneralMasterParameters
{
    public interface IReligionDao
    {
        object Get();

        object Save(Religion religion);

        object Search(Religion religion);

    }
}
