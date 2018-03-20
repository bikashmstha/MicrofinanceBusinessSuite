using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Supervisor;
using BusinessObjects.Security;


namespace DataObjects.Interfaces.Supervisor
{
    public interface IControlTableDao
    {
        List<ControlTable> GetControlTable();
        OutMessage SaveControlTable(ControlTable controlTable);
    }
}
