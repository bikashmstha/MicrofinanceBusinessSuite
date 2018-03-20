using System;
using System.Collections.Generic;
using System.Text;
using BusinessObjects.Security;
using System.Web;
using System.Web.SessionState;

namespace DataObjects
{
    public class CredentialManager : IRequiresSessionState
    {
        public static string TNSName
        {
           // get { return "TESTDEV"; } //irddbdev
            get { return "ORCL"; } //irddbdev

        }

        public static string ServiceName
        {
            // get { return "itsdb"; } //itsdb
            get { return "ORCL"; } //itsdb

        }

        public static string Host
        {
            
            get { return "localhost"; }

          //  get { return "10.100.199.18"; }

        }

        public static int PortNo
        {
            get { return 1521; }
        }

        /// <summary>
        /// This procedure store password lisr
        /// </summary>
        /// <param name="ModuleID">ApplicationID stored in database</param>
        /// <returns>Database username for application</returns>
        public static string GetApplicationUserName()
        {
            //return "mfbs"; //remote connect
            return "MFBS";
            //GenericUser user = ((GenericUser)HttpContext.Current.Session["UserWeb"]);
            //return user.DatabaseAccessUserName;



        }

        /// <summary>
        /// This procedure store password lisr
        /// </summary>
        /// <param name="ModuleID">ApplicationID stored in database</param>
        /// <returns>Database username for application</returns>
        public static string GetApplicationUserPassword()
        {
            //return "mtpl123"; //remote connect
            return "MFBS";
            //GenericUser user = ((GenericUser)HttpContext.Current.Session["UserWeb"]);
            //return user.DatabaseAccessUserPassword;

        }

        #region for future consideration
        /// <summary>
        /// This procedure store user lisr
        /// </summary>
        /// <param name="ModuleID">ApplicationID stored in database</param>
        /// <returns>Database username for application</returns>
        //public static string GetApplicationUserName(GenericUser user)
        //{

        //    string username=string.Empty;

        //    return username;
        //}

        /// <summary>
        /// This procedure store password lisr
        /// </summary>
        /// <param name="ModuleID">ApplicationID stored in database</param>
        /// <returns>Database username for application</returns>
        //public static string GetApplicationUserPassword(GenericUser user)
        //{
        //    string password = "";
        //    switch (ModuleID)
        //    {
        //        //CMS
        //        case 1:
        //            password = "CMS_ADMIN";
        //            break;
        //        //LJMS
        //        case 2:
        //            password = "LJMS_ADMIN";
        //            break;
        //        //PMS
        //        case 3:
        //            //password = "pmsadm1npa$$";
        //            password = "PMS_ADMIN";
        //            break;
        //        //LIS
        //        case 4:
        //            password = "LIS_ADMIN";
        //            break;
        //        //OAS
        //        case 5:
        //            password = "OAS_ADMIN";
        //            //password = "oasadm1npa$$";
        //            break;
        //        //PMES
        //        case 6:
        //            password = "PMES_ADMIN";
        //            break;
        //        //OSS
        //        case 7:
        //            password = "OSS_ADMIN";
        //            break;
        //        //Security
        //        case 8:
        //            //password = "secadm1npa$$";
        //            password = "COMMON_OWNER";
        //            break;
        //        //PDIS
        //        case 9:
        //            password = "PDIS_ADMIN";
        //            break;
        //        //DLPDS
        //        case 10:
        //            password = "DLPDS_ADMIN";
        //            break;
        //    }
        //    return password;
        //}

        #endregion
    }
}