// Decompiled with JetBrains decompiler
// Type: ErrorLog
// Assembly: nsWrapper, Version=1.0.3.6, Culture=neutral, PublicKeyToken=null
// MVID: F361227A-6D4B-45AA-942B-17294A86FE90
// Assembly location: C:\Users\Hp-pc\Desktop\MFBS\DataObjects\bin\nsWrapper.dll

using System;
using System.Collections;
using System.Data.SqlClient;
using System.Web;

public class ErrorLog
{
  public static bool AddError(ErrorObject Ex)
  {
    string remitUserCd = Ex.Remit_user_cd;
    string parentAgentCd = Ex.Parent_agent_cd;
    string etype = Ex.EType;
    string eno = Ex.ENo;
    string ecode = Ex.ECode;
    string emessage = Ex.EMessage;
    string esource = Ex.ESource;
    string eprocedure = Ex.EProcedure;
    string estacktrace = Ex.EStacktrace;
    string eref = Ex.Eref;
    try
    {
      SPWrapper spWrapper = new SPWrapper();
      if (!spWrapper.DBConnection())
        return false;
      int num = 0;
      spWrapper.Mode = SPWrapper.QueryMode.ExecuteScalar;
      spWrapper.SPName = "p_error_log";
      spWrapper.ParamHT.Add((object) "remit_user_cd", (object) remitUserCd);
      spWrapper.ParamHT.Add((object) "parent_agent_cd", (object) parentAgentCd);
      spWrapper.ParamHT.Add((object) "error_type", (object) etype);
      spWrapper.ParamHT.Add((object) "error_no", (object) eno);
      spWrapper.ParamHT.Add((object) "error_code", (object) ecode);
      spWrapper.ParamHT.Add((object) "error_message", (object) emessage);
      spWrapper.ParamHT.Add((object) "error_source", (object) esource);
      spWrapper.ParamHT.Add((object) "error_stacktrace", (object) estacktrace);
      spWrapper.ParamHT.Add((object) "error_in_procedure", (object) eprocedure);
      spWrapper.ParamHT.Add((object) "error_ref", (object) eref);
      spWrapper.ParamHT.Add((object) "#log_state", (object) num);
      spWrapper.ExecuteSP();
      if (spWrapper.ParamHT[(object) "#log_state"].ToString() != null)
        Convert.ToInt32(spWrapper.ParamHT[(object) "#log_state"]);
      return true;
    }
    catch (Exception ex)
    {
      return false;
    }
  }

  public static bool AddError(ErrorObject Ex, string ErrorRef)
  {
    string remitUserCd = Ex.Remit_user_cd;
    string parentAgentCd = Ex.Parent_agent_cd;
    string etype = Ex.EType;
    string eno = Ex.ENo;
    string ecode = Ex.ECode;
    string emessage = Ex.EMessage;
    string esource = Ex.ESource;
    string eprocedure = Ex.EProcedure;
    string estacktrace = Ex.EStacktrace;
    string str = ErrorRef;
    try
    {
      SPWrapper spWrapper = new SPWrapper();
      if (!spWrapper.DBConnection())
        return false;
      int num = 0;
      spWrapper.Mode = SPWrapper.QueryMode.ExecuteScalar;
      spWrapper.SPName = "p_error_log";
      spWrapper.ParamHT.Add((object) "remit_user_cd", (object) remitUserCd);
      spWrapper.ParamHT.Add((object) "parent_agent_cd", (object) parentAgentCd);
      spWrapper.ParamHT.Add((object) "error_type", (object) etype);
      spWrapper.ParamHT.Add((object) "error_no", (object) eno);
      spWrapper.ParamHT.Add((object) "error_code", (object) ecode);
      spWrapper.ParamHT.Add((object) "error_message", (object) emessage);
      spWrapper.ParamHT.Add((object) "error_source", (object) esource);
      spWrapper.ParamHT.Add((object) "error_stacktrace", (object) estacktrace);
      spWrapper.ParamHT.Add((object) "error_in_procedure", (object) eprocedure);
      spWrapper.ParamHT.Add((object) "error_ref", (object) str);
      spWrapper.ParamHT.Add((object) "#log_state", (object) num);
      spWrapper.ExecuteSP();
      if (spWrapper.ParamHT[(object) "#log_state"].ToString() != null)
        Convert.ToInt32(spWrapper.ParamHT[(object) "#log_state"]);
      return true;
    }
    catch (Exception ex)
    {
      return false;
    }
  }

  public static bool AddException(Exception Ex)
  {
    string empty1 = string.Empty;
    string empty2 = string.Empty;
    try
    {
      string str1;
      string str2;
      if (HttpContext.Current.Session["userId"] != null)
      {
        str1 = HttpContext.Current.Session["userId"].ToString();
        str2 = HttpContext.Current.Session["PACode"].ToString();
      }
      else
      {
        str1 = "anonnymous";
        str2 = "00001";
      }
      string str3 = "Exception";
      string str4 = "5001";
      string str5 = "000000";
      string str6 = Ex.Message.ToString();
      string str7 = Ex.Source.ToString();
      string str8 = "-";
      string str9 = Ex.StackTrace.ToString();
      string str10 = "-";
      SPWrapper spWrapper = new SPWrapper();
      if (!spWrapper.DBConnection())
        return false;
      int num = 0;
      spWrapper.Mode = SPWrapper.QueryMode.ExecuteScalar;
      spWrapper.SPName = "p_error_log";
      spWrapper.ParamHT.Add((object) "remit_user_cd", (object) str1);
      spWrapper.ParamHT.Add((object) "parent_agent_cd", (object) str2);
      spWrapper.ParamHT.Add((object) "error_type", (object) str3);
      spWrapper.ParamHT.Add((object) "error_no", (object) str4);
      spWrapper.ParamHT.Add((object) "error_code", (object) str5);
      spWrapper.ParamHT.Add((object) "error_message", (object) str6);
      spWrapper.ParamHT.Add((object) "error_source", (object) str7);
      spWrapper.ParamHT.Add((object) "error_stacktrace", (object) str9);
      spWrapper.ParamHT.Add((object) "error_in_procedure", (object) str8);
      spWrapper.ParamHT.Add((object) "error_ref", (object) str10);
      spWrapper.ParamHT.Add((object) "#log_state", (object) num);
      spWrapper.ExecuteSP();
      if (spWrapper.ParamHT[(object) "#log_state"].ToString() != null)
        Convert.ToInt32(spWrapper.ParamHT[(object) "#log_state"]);
      return true;
    }
    catch (Exception ex)
    {
      return false;
    }
  }

  public static bool AddException(Exception Ex, string ErrorRef)
  {
    string empty1 = string.Empty;
    string empty2 = string.Empty;
    try
    {
      string str1;
      string str2;
      if (HttpContext.Current.Session["userId"] != null)
      {
        str1 = HttpContext.Current.Session["userId"].ToString();
        str2 = HttpContext.Current.Session["PACode"].ToString();
      }
      else
      {
        str1 = "anonnymous";
        str2 = "00001";
      }
      string str3 = "Exception";
      string str4 = "5001";
      string str5 = "000000";
      string str6 = Ex.Message.ToString();
      string str7 = Ex.Source.ToString();
      string str8 = "-";
      string str9 = Ex.StackTrace.ToString();
      string str10 = ErrorRef;
      SPWrapper spWrapper = new SPWrapper();
      if (!spWrapper.DBConnection())
        return false;
      int num = 0;
      spWrapper.Mode = SPWrapper.QueryMode.ExecuteScalar;
      spWrapper.SPName = "p_error_log";
      spWrapper.ParamHT.Add((object) "remit_user_cd", (object) str1);
      spWrapper.ParamHT.Add((object) "parent_agent_cd", (object) str2);
      spWrapper.ParamHT.Add((object) "error_type", (object) str3);
      spWrapper.ParamHT.Add((object) "error_no", (object) str4);
      spWrapper.ParamHT.Add((object) "error_code", (object) str5);
      spWrapper.ParamHT.Add((object) "error_message", (object) str6);
      spWrapper.ParamHT.Add((object) "error_source", (object) str7);
      spWrapper.ParamHT.Add((object) "error_stacktrace", (object) str9);
      spWrapper.ParamHT.Add((object) "error_in_procedure", (object) str8);
      spWrapper.ParamHT.Add((object) "error_ref", (object) str10);
      spWrapper.ParamHT.Add((object) "#log_state", (object) num);
      spWrapper.ExecuteSP();
      if (spWrapper.ParamHT[(object) "#log_state"].ToString() != null)
        Convert.ToInt32(spWrapper.ParamHT[(object) "#log_state"]);
      return true;
    }
    catch (Exception ex)
    {
      return false;
    }
  }

  public static bool AddSqlException(SqlException Ex)
  {
    string empty1 = string.Empty;
    string empty2 = string.Empty;
    try
    {
      string str1;
      string str2;
      if (HttpContext.Current.Session["userId"] != null)
      {
        str1 = HttpContext.Current.Session["userId"].ToString();
        str2 = HttpContext.Current.Session["PACode"].ToString();
      }
      else
      {
        str1 = "anonymous";
        str2 = "00001";
      }
      string str3 = "SqlException";
      int num1 = Ex.Number;
      string str4 = num1.ToString();
      num1 = Ex.ErrorCode;
      string str5 = num1.ToString();
      string str6 = Ex.Message.ToString();
      string str7 = Ex.Source.ToString();
      string str8 = Ex.Procedure.ToString();
      string str9 = Ex.StackTrace.ToString();
      string str10 = "-";
      SPWrapper spWrapper = new SPWrapper();
      if (!spWrapper.DBConnection())
        return false;
      int num2 = 0;
      spWrapper.Mode = SPWrapper.QueryMode.ExecuteScalar;
      spWrapper.SPName = "p_error_log";
      spWrapper.ParamHT.Add((object) "remit_user_cd", (object) str1);
      spWrapper.ParamHT.Add((object) "parent_agent_cd", (object) str2);
      spWrapper.ParamHT.Add((object) "error_type", (object) str3);
      spWrapper.ParamHT.Add((object) "error_no", (object) str4);
      spWrapper.ParamHT.Add((object) "error_code", (object) str5);
      spWrapper.ParamHT.Add((object) "error_message", (object) str6);
      spWrapper.ParamHT.Add((object) "error_source", (object) str7);
      spWrapper.ParamHT.Add((object) "error_stacktrace", (object) str9);
      spWrapper.ParamHT.Add((object) "error_in_procedure", (object) str8);
      spWrapper.ParamHT.Add((object) "error_ref", (object) str10);
      spWrapper.ParamHT.Add((object) "#log_state", (object) num2);
      spWrapper.ExecuteSP();
      if (spWrapper.ParamHT[(object) "#log_state"].ToString() != null)
        Convert.ToInt32(spWrapper.ParamHT[(object) "#log_state"]);
      return true;
    }
    catch (Exception ex)
    {
      return false;
    }
  }

  public static bool AddSqlException(SqlException Ex, string ErrorRef)
  {
    string str1 = HttpContext.Current.Session["userId"].ToString();
    string str2 = HttpContext.Current.Session["PACode"].ToString();
    string str3 = "SqlException";
    string str4 = Ex.Number.ToString();
    string str5 = Ex.ErrorCode.ToString();
    string str6 = Ex.Message.ToString();
    string str7 = Ex.Source.ToString();
    string str8 = Ex.Procedure.ToString();
    string str9 = Ex.StackTrace.ToString();
    string str10 = ErrorRef;
    try
    {
      SPWrapper spWrapper = new SPWrapper();
      if (!spWrapper.DBConnection())
        return false;
      int num = 0;
      spWrapper.Mode = SPWrapper.QueryMode.ExecuteScalar;
      spWrapper.SPName = "p_error_log";
      spWrapper.ParamHT.Add((object) "remit_user_cd", (object) str1);
      spWrapper.ParamHT.Add((object) "parent_agent_cd", (object) str2);
      spWrapper.ParamHT.Add((object) "error_type", (object) str3);
      spWrapper.ParamHT.Add((object) "error_no", (object) str4);
      spWrapper.ParamHT.Add((object) "error_code", (object) str5);
      spWrapper.ParamHT.Add((object) "error_message", (object) str6);
      spWrapper.ParamHT.Add((object) "error_source", (object) str7);
      spWrapper.ParamHT.Add((object) "error_stacktrace", (object) str9);
      spWrapper.ParamHT.Add((object) "error_in_procedure", (object) str8);
      spWrapper.ParamHT.Add((object) "error_ref", (object) str10);
      spWrapper.ParamHT.Add((object) "#log_state", (object) num);
      spWrapper.ExecuteSP();
      if (spWrapper.ParamHT[(object) "#log_state"].ToString() != null)
        Convert.ToInt32(spWrapper.ParamHT[(object) "#log_state"]);
      return true;
    }
    catch (Exception ex)
    {
      return false;
    }
  }

  public static bool IsError(string errMessage)
  {
    return errMessage.Length >= 6 && errMessage.Substring(0, 6).ToLower() == "ERROR:".ToLower();
  }

  public static string GetRef(Hashtable ParamHT)
  {
    try
    {
      if (ParamHT.Count < 1)
        return string.Empty;
      string str = string.Empty;
      foreach (string key in (IEnumerable) ParamHT.Keys)
      {
        if (str == string.Empty)
        {
          if (key.Substring(0, 1) != "#")
            str = "@" + key + " = " + ErrorLog.EncloseString(ParamHT[(object) key].ToString());
          else
            str = "@" + key + " = @" + key + " output";
        }
        else if (key.Substring(0, 1) != "#")
          str = str + ", @" + key + " = " + ErrorLog.EncloseString(ParamHT[(object) key].ToString());
        else
          str = str + ", @" + key + " = @" + key + " output";
      }
      return str.Replace("#", "");
    }
    catch (Exception ex)
    {
      return string.Empty;
    }
  }

  private static string EncloseString(string Param)
  {
    if (string.IsNullOrEmpty(Param))
      return "null";
    return "'" + Param + "'";
  }
}
