using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicrofinanceBusinessSuite.Utility
{    
    public class MenuData
    {
        public string text;

        private List<Node> _children = new List<Node>();
        public List<Node> children
        {
            get { return _children; }
            set { _children = value; }
        }

        public bool expanded { get; set; }
    }
}