using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Maintenance;
using BusinessObjects.MessageBase;

namespace BusinessObjects.Message
{
    public class NarrationResponse:ResponseBase
    {
        public IList<Narration> Narrations;
    }
}
