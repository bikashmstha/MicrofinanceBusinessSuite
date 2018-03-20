using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance;

namespace DataObjects.Interfaces.Finance
{
    public interface ISectorDao
    {
        object Get();

        object Save(Sector sector);

        object Search(Sector sector);

    }
}
