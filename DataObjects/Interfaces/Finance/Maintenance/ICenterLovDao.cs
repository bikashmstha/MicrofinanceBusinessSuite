using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance;

namespace DataObjects.Interfaces.Finance
{
    public interface ICenterLovDao
    {
        object Get();

        object Save(CenterLov centerlov);

        object Search(CenterLov centerlov);

        object GetTransferLovList(CenterLov centerlov);

    }
}
