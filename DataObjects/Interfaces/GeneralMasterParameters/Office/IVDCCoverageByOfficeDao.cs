using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.GeneralMasterParameters;

namespace DataObjects.Interfaces.GeneralMasterParameters
{
    public interface IVdcCoverageByOfficeDao
    {
        object Get();

        object Save(VdcCoverageByOffice vdcCoverageByOffice);

        object Search(VdcCoverageByOffice vdcCoverageByOffice);

    }
}
