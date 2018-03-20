using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Security;

namespace MicrofinanceBusinessSuite.Utility
{
    public  class GeneralHelper
    {


        public static string UserName 
        {
            get { return (System.Web.HttpContext.Current.Session["User"] as User).UserName; }
            
        }
        public static string UserId
        {
            get { return (System.Web.HttpContext.Current.Session["User"] as User).UserID; }

        }
        public static string MisDateEnglish
        {
            get { return (System.Web.HttpContext.Current.Session["User"] as User).MisDateEnglish; }

        }
        public static string MisDateNepali
        {
            get { return (System.Web.HttpContext.Current.Session["User"] as User).MisDateNepali; }

        }
        public static string DateEnglish
        {
            get { return (System.Web.HttpContext.Current.Session["User"] as User).MisDateEnglish; }

        }
        public static string ReportUrl
        {
            get { return (System.Web.HttpContext.Current.Session["User"] as User).ReportUrl; }

        }
    }
        
}