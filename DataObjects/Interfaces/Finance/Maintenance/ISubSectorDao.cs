using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance;

namespace DataObjects.Interfaces.Finance
{
    public interface ISubSectorDao
    {
        object Get();

        object Save(SubSector subSector);

        object Search(SubSector subSector);

    }
}
