using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using BusinessObjects.BusinessRules;


namespace BusinessObjects.Security
{
    /// <summary>
    /// Encapsulates Application Information
    /// </summary>
    /// <remarks>ramarksssssssssssss</remarks>
    public class Menu : BusinessObject
    {
        public Menu()
        {

        }
        public string AppID { get; set; }
        public string AppDesc { get; set; }

        public string ModuleID { get; set; }
        public string ModuleDesc { get; set; }

        public string SubModuleID { get; set; }
        public string SubModuleDesc { get; set; }

        public string FuncCD { get; set; }
        public string FuncDesc { get; set; }

        public string MenuName { get; set; }

    }
}