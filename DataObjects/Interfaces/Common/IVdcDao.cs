using BusinessObjects.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Common;

namespace DataObjects.Interfaces.Common
{
    public interface IVdcDao
    {
        List<Vdc> SearchVdc(Vdc vdc);

        object Get();

        object Save(Vdc Vdc);

        object Search(Vdc Vdc);

        object GetVDCShort(Vdc Vdc);
       
        
    }
}
