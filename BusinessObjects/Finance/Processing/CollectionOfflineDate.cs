using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Processing
{
    public class CollectionOfflineDate : BusinessObject
    {
        public CollectionOfflineDate() { }

        public string CollectionDateAd { get; set; }
        public string CollectionDateBs { get; set; }
    }
}
