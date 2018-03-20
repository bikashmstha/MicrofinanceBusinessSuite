using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicrofinanceBusinessSuite.Handlers.Inventory.Transaction
{
    /// <summary>
    /// Summary description for GoodReceiptItemHandler
    /// </summary>
    public class GoodReceiptItemHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}