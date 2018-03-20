// Decompiled with JetBrains decompiler
// Type: oQueryParser
// Assembly: nsWrapper, Version=1.0.3.6, Culture=neutral, PublicKeyToken=null
// MVID: F361227A-6D4B-45AA-942B-17294A86FE90
// Assembly location: C:\Users\Hp-pc\Desktop\MFBS\DataObjects\bin\nsWrapper.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class oQueryParser
{
  private oQueryParser.QryType _QueryType = oQueryParser.QryType.SelectQuery;
  private oQueryParser.FuncType _FunctionType = oQueryParser.FuncType.ScalarValued;
  private string _SelectQuery = string.Empty;
  private string _InsertQuery = string.Empty;
  private string _UpdateQuery = string.Empty;
  private string _WhereQuery = string.Empty;
  private string _TableName = string.Empty;
  private bool _IsPreparedSQL = false;
  private string _FunctionName = string.Empty;
  private string _query = string.Empty;
  private string _DataKeyField = string.Empty;
  private oQueryParser.ReturnType _ExpectedResult = oQueryParser.ReturnType.DataSet;
  private int _intID = -1;
  private int _rownum = 0;
  private Hashtable _SelectFields = new Hashtable();
  private Hashtable _UpdateInsertFieldsHT = new Hashtable();
  private Hashtable _UpdateInsertDBTypeHT = new Hashtable();
  private Hashtable _whereHT = new Hashtable();
  private Hashtable _paramHT = new Hashtable();
  private Hashtable _OrderByHT = new Hashtable();
  private SortedDictionary<int, string> _paramD = new SortedDictionary<int, string>();
  private oQueryParser.OrderType _Order = oQueryParser.OrderType.ASC;
  private string connectionString = string.Empty;
  private string RegStr = "['=-]";
  private bool _AddEmptyRow = false;

  public string SelectString
  {
    get
    {
      return this._SelectQuery;
    }
    set
    {
      this._SelectQuery = value;
    }
  }

  public string TableName
  {
    get
    {
      if (this._TableName == null || this._TableName.Trim() == string.Empty)
        throw new ArgumentNullException("Parameter Table Name may not be null or blank.");
      return this._TableName;
    }
    set
    {
      if (value == null || value.Trim() == string.Empty)
        throw new ArgumentNullException("Parameter Table Name may not be null or blank.");
      if (Regex.IsMatch(value, this.RegStr))
        throw new ArgumentNullException("Invalid Table Name!");
      this._TableName = value;
    }
  }

  public string DataKeyField
  {
    get
    {
      return this._DataKeyField;
    }
    set
    {
      this._DataKeyField = value;
    }
  }

  public Hashtable WhereHT
  {
    get
    {
      return this._whereHT;
    }
    set
    {
      this._whereHT = value;
    }
  }

  public Hashtable UpdateInsertFieldsHT
  {
    get
    {
      return this._UpdateInsertFieldsHT;
    }
    set
    {
      this._UpdateInsertFieldsHT = value;
    }
  }

  public string InsertQuery
  {
    get
    {
      return this._InsertQuery;
    }
    set
    {
      this._InsertQuery = value;
    }
  }

  public string UpdateQuery
  {
    get
    {
      return this._UpdateQuery;
    }
    set
    {
      this._UpdateQuery = value;
    }
  }

  public oQueryParser.QryType QueryType
  {
    get
    {
      return this._QueryType;
    }
    set
    {
      this._QueryType = value;
    }
  }

  public string WhereQuery
  {
    get
    {
      return this._WhereQuery;
    }
    set
    {
      this._WhereQuery = value;
    }
  }

  public int rownum
  {
    get
    {
      return this._rownum;
    }
    set
    {
      this._rownum = value;
    }
  }

  public Hashtable SelectFieldsHT
  {
    get
    {
      foreach (string input in (IEnumerable) this._SelectFields.Values)
      {
        if (Regex.IsMatch(input, this.RegStr))
          throw new ArgumentNullException("Invalid Select Field:'" + input + "'");
        if (string.IsNullOrEmpty(input))
          throw new ArgumentNullException("Empty Select Field!");
      }
      return this._SelectFields;
    }
    set
    {
      this._SelectFields = value;
    }
  }

  public Hashtable OrderBy
  {
    get
    {
      foreach (string input in (IEnumerable) this._OrderByHT.Values)
      {
        if (Regex.IsMatch(input, this.RegStr))
          throw new ArgumentNullException("Invalid OrderBy Field:'" + input + "'");
        if (string.IsNullOrEmpty(input))
          throw new ArgumentNullException("Empty OrderBy Field!");
      }
      return this._OrderByHT;
    }
    set
    {
      if (value.ToString().Trim() == string.Empty)
        throw new ArgumentNullException("Parameter Order By may not be null or blank.");
      this._OrderByHT = value;
    }
  }

  public oQueryParser.OrderType Order
  {
    get
    {
      return this._Order;
    }
    set
    {
      if (value.ToString().Trim() == string.Empty)
        throw new ArgumentNullException("Parameter Order Type may not be null or blank.");
      this._Order = value;
    }
  }

  public SortedDictionary<int, string> ParamD
  {
    get
    {
      return this._paramD;
    }
    set
    {
      this._paramD = value;
    }
  }

  public string FunctionName
  {
    get
    {
      if (this._FunctionName == null || this._FunctionName.Trim() == string.Empty)
        throw new ArgumentNullException("Null Function Name!!");
      return this._FunctionName;
    }
    set
    {
      if (value == null || value.Trim() == string.Empty)
        throw new ArgumentNullException("Parameter Function Name may not be null or blank.");
      if (Regex.IsMatch(value, this.RegStr))
        throw new ArgumentNullException("Invalid Function Name!");
      this._FunctionName = value;
    }
  }

  public oQueryParser.FuncType FunctionType
  {
    get
    {
      return this._FunctionType;
    }
    set
    {
      if (value.ToString().Trim() == string.Empty)
        throw new ArgumentNullException("Parameter Function Type may not be null or blank.");
      this._FunctionType = value;
    }
  }

  public bool IsPreparedSQL
  {
    get
    {
      return this._IsPreparedSQL;
    }
    set
    {
      this._IsPreparedSQL = value;
    }
  }

  public Hashtable ParamHT
  {
    get
    {
      return this._paramHT;
    }
    set
    {
      this._paramHT = value;
    }
  }

  public oQueryParser.ReturnType ExpectedResult
  {
    get
    {
      return this._ExpectedResult;
    }
    set
    {
      this._ExpectedResult = value;
    }
  }

  public bool AddEmptyRow
  {
    get
    {
      return this._AddEmptyRow;
    }
    set
    {
      this._AddEmptyRow = value;
    }
  }

  private string BuildSelectQuery()
  {
    string str1 = this._SelectQuery;
    string str2 = " where 1=1 ";
    if (str1 == string.Empty)
    {
      if (this.SelectFieldsHT.Count > 0)
      {
        string str3 = string.Empty;
        foreach (string str4 in (IEnumerable) this.SelectFieldsHT.Values)
          str3 = !(str3 == string.Empty) ? str3 + ", " + str4 : str4;
        str1 = "Select " + str3 + " from " + this.TableName;
      }
      else
        str1 = "Select * from " + this.TableName;
    }
    if (this._whereHT.Count > 0)
    {
      foreach (string key in (IEnumerable) this._whereHT.Keys)
        str2 += this.ParseWhere(key, this._whereHT[(object) key].ToString());
    }
    else if (this._WhereQuery != string.Empty)
      str2 = this._WhereQuery;
    string str5 = str1 + str2 + this.rownumNo().ToString();
    string str6 = string.Empty;
    if (this._OrderByHT.Count > 0)
    {
      foreach (string input in (IEnumerable) this.OrderBy.Values)
      {
        if (Regex.IsMatch(input, this.RegStr))
          throw new ArgumentNullException("Invalid OrderBy Field:'" + input + "'");
        str6 = !(str6 == string.Empty) ? str6 + ", " + input : " Order by " + input;
      }
      if (this._Order == oQueryParser.OrderType.ASC)
        str6 += " ASC";
      else if (this._Order == oQueryParser.OrderType.DESC)
        str6 += " DESC";
    }
    string str7 = str5 + str6;
    if (str7.Trim() == string.Empty)
      return (string) null;
    return str7;
  }

  private string BuidUpdateQuery()
  {
    if (string.IsNullOrEmpty(this._TableName) || this._UpdateInsertFieldsHT == null || this._whereHT == null)
      return "";
    string str1 = "Update " + this._TableName;
    string str2 = !(this.WhereQuery.ToString().Trim() == "") ? " " + this.WhereQuery : " where 1=1 ";
    foreach (string key in (IEnumerable) this._UpdateInsertFieldsHT.Keys)
    {
      if (this._DataKeyField != key)
      {
        if (str1.IndexOf(" Set ") > 0)
          str1 = str1 + " , " + key + " = :ui" + key;
        else
          str1 = str1 + " Set " + key + " = :ui" + key;
      }
    }
    foreach (string key in (IEnumerable) this._whereHT.Keys)
      str2 = str2 + " and " + key + " = :w" + key;
    return str1 + str2;
  }

  private string BuidInsertQuery()
  {
    string str1 = string.Empty;
    string str2 = string.Empty;
    if (string.IsNullOrEmpty(this.TableName) && string.IsNullOrEmpty(this.InsertQuery) || string.IsNullOrEmpty(this.TableName) && this.UpdateInsertFieldsHT.Count <= 0)
      return (string) null;
    string empty = string.Empty;
    string str3;
    if (!string.IsNullOrEmpty(this.TableName))
    {
      string str4 = "Insert into " + this.TableName;
      foreach (string key in (IEnumerable) this.UpdateInsertFieldsHT.Keys)
      {
        if (string.IsNullOrEmpty(str1))
        {
          str1 = key;
          str2 = ":ui" + key;
        }
        else
        {
          str1 = str1 + ", " + key;
          str2 = str2 + ", :ui" + key;
        }
      }
      str3 = str4 + "(" + str1 + ") values(" + str2 + ")";
    }
    else
      str3 = this.InsertQuery;
    return str3;
  }

  private string BuildFunctionQuery()
  {
    if (string.IsNullOrEmpty(this._FunctionName) || this._FunctionType != oQueryParser.FuncType.ScalarValued)
      return string.Empty;
    string str1 = "Select " + this._FunctionName;
    string str2;
    if (this._paramD.Count > 0)
    {
      string str3 = string.Empty;
      foreach (KeyValuePair<int, string> keyValuePair in this._paramD)
        str3 = !(str3 == string.Empty) ? str3 + ", '" + keyValuePair.Value + "'" : "('" + keyValuePair.Value + "'";
      string str4 = str3 + ") as Result";
      str2 = str1 + str4;
    }
    else
      str2 = str1 + " as Result";
    return str2 + " from dual";
  }

  private string BuildDeleteQuery()
  {
    string str1 = " where 1=1 ";
    string str2 = "Delete from " + this.TableName;
    if (this._whereHT.Count <= 0)
      throw new Exception("You're only allowed to delete single record at a time!!");
    foreach (string key in (IEnumerable) this._whereHT.Keys)
      str1 += this.ParseWhere(key, this._whereHT[(object) key].ToString());
    return str2 + str1;
  }

  private string ParseWhere(string SKey, string SValue)
  {
    if (string.IsNullOrEmpty(SKey))
      throw new ArgumentException("Empty FieldName!");
    if (string.IsNullOrEmpty(SValue))
      return string.Empty;
    if (Regex.IsMatch(SKey, "'"))
      throw new ArgumentException("Invalid Character!");
    string empty = string.Empty;
    int startIndex = SValue.Length - 1;
    string str;
    if (SValue.Substring(startIndex, 1).Equals("%") && SValue.Substring(0, 1).Equals("%"))
      str = " AND " + SKey + " like '%'+ :" + SKey + "+'%'";
    else if (SValue.Substring(startIndex, 1).Equals("%"))
      str = " AND " + SKey + " like :" + SKey + "+'%'";
    else
      str = !SValue.Substring(0, 1).Equals("%") ? " AND " + SKey + "= :" + SKey : " AND " + SKey + " like '%' + :" + SKey;
    if (SValue.Substring(0, 1).Equals("!"))
      str = " AND " + SKey + " != :" + SKey;
    return str;
  }

  public override string ToString()
  {
    switch (this._QueryType)
    {
      case oQueryParser.QryType.SelectQuery:
        return this.BuildSelectQuery();
      case oQueryParser.QryType.UpdateQuery:
        return this.BuidUpdateQuery();
      case oQueryParser.QryType.InsertQuery:
        return this.BuidInsertQuery();
      case oQueryParser.QryType.FunctionQuery:
        return this.BuildFunctionQuery();
      default:
        return (string) null;
    }
  }

  private string rownumNo()
  {
    if (this._rownum != 0)
      return " and rownum <=" + this._rownum.ToString() + " ";
    return string.Empty;
  }

  public enum QryType
  {
    SelectQuery = 1,
    UpdateQuery = 2,
    InsertQuery = 3,
    DeleteQuery = 4,
    FunctionQuery = 5,
  }

  public enum OrderType
  {
    ASC = 1,
    DESC = 2,
  }

  public enum FuncType
  {
    TableValued = 1,
    ScalarValued = 2,
    Aggregate = 3,
    System = 4,
  }

  public enum ReturnType
  {
    DataSet = 1,
    SingleRecord = 2,
    Boolean = 3,
  }
}
