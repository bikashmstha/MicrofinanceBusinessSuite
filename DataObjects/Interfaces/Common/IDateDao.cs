using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects.Interfaces.Common
{
    public interface IDateDao
    {
         object GetEngDate(string nepDate);
         object GetNepDate(string engDate);

    }
}
