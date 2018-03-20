// Decompiled with JetBrains decompiler
// Type: General
// Assembly: nsWrapper, Version=1.0.3.6, Culture=neutral, PublicKeyToken=null
// MVID: F361227A-6D4B-45AA-942B-17294A86FE90
// Assembly location: C:\Users\Hp-pc\Desktop\MFBS\DataObjects\bin\nsWrapper.dll

using Oracle.DataAccess.Types;
using System;

public class General
{
  public static OracleDate ParseOracleDate(string InputDate)
  {
    OracleDate oracleDate = new OracleDate();
    if (string.IsNullOrEmpty(InputDate))
      return oracleDate;
    return new OracleDate(Convert.ToDateTime(InputDate));
  }

  public static string ParseCrystalDate(string InputDate)
  {
    try
    {
      DateTime dateTime = Convert.ToDateTime(InputDate);
      return dateTime.Year.ToString() + "," + (object) dateTime.Month + "," + (object) dateTime.Day + "," + (object) 0 + "," + (object) 0 + "," + (object) 0;
    }
    catch (Exception ex)
    {
      return (string) null;
    }
  }

  public static string ParseCrystalDate(string InputDate, bool IsFrom)
  {
    try
    {
      if (IsFrom)
      {
        DateTime dateTime = Convert.ToDateTime(InputDate);
        return dateTime.Year.ToString() + "," + (object) dateTime.Month + "," + (object) dateTime.Day + "," + (object) 0 + "," + (object) 0 + "," + (object) 0;
      }
      DateTime dateTime1 = Convert.ToDateTime(InputDate);
      return dateTime1.Year.ToString() + "," + (object) dateTime1.Month + "," + (object) dateTime1.Day + "," + (object) 23 + "," + (object) 59 + "," + (object) 59;
    }
    catch (Exception ex)
    {
      return (string) null;
    }
  }
}
