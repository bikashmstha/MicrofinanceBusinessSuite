﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.CompilerServices;

using System.Configuration;

namespace MicrofinanceBusinessSuite.InfoDev.DataAccess
{
    public class DBConnection
    {

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static long executeNonQuery(string Username, string Password, string Token, string IP, string value, string CommandText)
        {
            try
            {
                int output = DataObjects.SqlHelper.ExecuteNonQueryForSesssion(Username, Password, CommandText, Token, IP, value);
            }
            catch (Exception)
            {

                throw;
            }

            return -1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static string executeTextForBlob(string CommandText, string Token, string IP)
        {
            return DataObjects.SqlHelper.executeTextForBlob("TOKEN_MANAGER", "t0kenM2n2112", "CPR_GET_SESSION", Token, IP).ToString();
        }


        [MethodImpl(MethodImplOptions.Synchronized)]
        public static long executeNonQuery(string Username, string Password, string Token, string IP, string CommandText)
        {
            try
            {
                 int output = DataObjects.SqlHelper.ExecuteNonQuery(Username, Password, CommandText, Token, IP);
            }
            catch (Exception)
            {

                throw;
            }

            return -1;
        }
    }
}