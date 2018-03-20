using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction;
namespace DataObjects.Interfaces.Finance
{
    public interface IDropOutReasonDao
    {
        object Get();

        object Save(DropOutReasons DropOutReasons);

        object Search(DropOutReasons DropOutReasons);

        object GetCDReason(string reasonDesc);

    }
}
