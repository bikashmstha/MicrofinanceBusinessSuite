
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using BusinessObjects.Security;
using Oracle.DataAccess.Client;
using BusinessObjects.BusinessRules;
using DataObjects.Security;

namespace DataObjects.AdoNet.Oracle.Security

{
    /// <summary>
    /// Oracle specific data access object that handles data access
    /// of table Login_TB. The details are stubbed out (in a crude way) but should be 
    /// relatively easy to implement as they are similar to MS Access and 
    /// Sql Server Data access objects.
    ///
    /// Enterprise Design Pattern: Service Stub.
    /// </summary>
    public class OracleLoginDao : ILoginDao
    {
        public GenericUser LogIn(GenericUser user)
        {
            try
            {
                GenericUserDao dao;
                Type t = user.GetType();

                switch (t.Name)
                {
                    //IRD Officer
                    case "User":
                        dao = new OracleUserDao();
                        break;
                    default:
                        dao = new OracleUserDao();
                        break;
                }

                //string str = System.Web.HttpContext.Current.Session["User"].ToString();
                user = dao.LogIn(user);
                //   System.Web.HttpContext.Current.Session["User"] = success ? user : null;
                return user;
            }
            catch (Exception ex)
            {
                return user;
            }
        }

        
    }
}
