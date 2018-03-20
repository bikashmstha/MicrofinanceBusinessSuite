using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Security;

namespace MicrofinanceBusinessSuite.InfoDev.DataAccess
{
    public class SessionManager
    {
        //private static ISessionManagerDao userDao = DataAccess.SessionManager;
        public string SaveSession(string token, string value, string ip)
        {
            try
            {
                User user = (User)HttpContext.Current.Session["User"];

                DBConnection.executeNonQuery("TOKEN_MANAGER", "t0kenM2n2112", token, ip, value, "CPR_SAVE_SESSION");

                ///////////////////
                return "true";

            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }



        public string GetSession(string token, string ip)
        {
            string session_data = "";
            try
            {
                session_data = DBConnection.executeTextForBlob("CPR_GET_SESSION", token, ip);
                if (session_data.Length > 5000)
                {
                    DBConnection.executeNonQuery("TOKEN_MANAGER", "t0kenM2n2112", token, ip, "CPR_DELETE_SESSION");
                }

            }
            catch (Exception ex)
            {
                session_data = "Error: " + ex.Message;
            }

            return session_data;
        }
    }
}