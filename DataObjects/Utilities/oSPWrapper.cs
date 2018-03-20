// Decompiled with JetBrains decompiler
// Type: oSPWrapper
// Assembly: nsWrapper, Version=1.0.3.6, Culture=neutral, PublicKeyToken=null
// MVID: F361227A-6D4B-45AA-942B-17294A86FE90
// Assembly location: C:\Users\Hp-pc\Desktop\MFBS\DataObjects\bin\nsWrapper.dll

using Oracle.DataAccess.Client;
using System;
using System.Collections;
using System.Configuration;
using System.Data;

public class oSPWrapper
{
  private string _ConnectionString = string.Empty;
  private string _SPName = string.Empty;
  private string _PackageName = string.Empty;
  private Hashtable _ParamHT = new Hashtable();
  private ArrayList _ParamAL = new ArrayList();
  private oSPWrapper.QueryMode _QMode = oSPWrapper.QueryMode.ExecuteScalar;
  private int _CommandTimeout = 60;
  private bool _IsMultipleTxn = false;
  private const string prfOut = "#";
  private OracleParameter SPParam;
  private OracleCommand _SQLCmd;
  private OracleTransaction sqlTxnM;
  private OracleConnection _SQLConnM;

  public string ConnectionString
  {
    get
    {
      return this._ConnectionString;
    }
    set
    {
      this._ConnectionString = value;
    }
  }

  public string SPName
  {
    get
    {
      return this._SPName;
    }
    set
    {
      this._SPName = value;
    }
  }

  public Hashtable ParamHT
  {
    get
    {
      return this._ParamHT;
    }
    set
    {
      this._ParamHT = value;
    }
  }

  public oSPWrapper.QueryMode Mode
  {
    get
    {
      return this._QMode;
    }
    set
    {
      this._QMode = value;
    }
  }

  public string PackageName
  {
    get
    {
      return this._PackageName;
    }
    set
    {
      this._PackageName = value;
    }
  }

  public int CommandTimeout
  {
    get
    {
      return this._CommandTimeout;
    }
    set
    {
      this._CommandTimeout = value;
    }
  }

  public bool IsMultipleTxn
  {
    get
    {
      return this._IsMultipleTxn;
    }
    set
    {
      this._IsMultipleTxn = value;
    }
  }

  public OracleConnection SQLConnM
  {
    get
    {
      return this._SQLConnM;
    }
    set
    {
      this._SQLConnM = value;
    }
  }

  public oSPWrapper()
  {
    try
    {
        this._ConnectionString ="Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=10.100.199.18)(PORT=1521)))(CONNECT_DATA=(SERVICE_NAME=testdev)));User ID=mfbs;Password=mtpl123;" ;
//      this._ConnectionString = ConfigurationManager.ConnectionStrings[nameof (ConnectionString)].ToString();
    }
    catch (Exception ex)
    {
      throw new ApplicationException(ex.Message, ex);
    }
  }

  public oSPWrapper(string p_ConnectionString)
  {
    this._ConnectionString = p_ConnectionString;
  }

  public bool DBConnection()
  {
    try
    {
      OracleConnection oracleConnection = new OracleConnection(this._ConnectionString);
      return true;
    }
    catch (Exception ex)
    {
      return false;
    }
  }

  private string SPPackage()
  {
    if (string.IsNullOrEmpty(this.PackageName))
      return this._SPName;
    return this.PackageName + "." + this._SPName;
  }

  public MessageObject ExecuteSP()
  {
    if (this.IsMultipleTxn)
      throw new Exception("For Multiple Txn, use ExecuteSPM method!!");
    MessageObject messageObject = new MessageObject();
    OracleConnection conn = new OracleConnection(this._ConnectionString);
    this._SQLCmd = new OracleCommand(this.SPPackage(), conn);
    this._SQLCmd.CommandType = CommandType.StoredProcedure;
    this._SQLCmd.BindByName = true;
    this._SQLCmd.CommandTimeout = this.CommandTimeout;
    this._SQLCmd.Connection.Open();
    OracleTransaction oracleTransaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
    try
    {
      string empty = string.Empty;
      bool flag = false;
      if (this._ParamHT != null && this._ParamHT.Count != 0)
      {
        Hashtable pdataType = (Hashtable) this.GetPDataType();
        foreach (object obj in this._ParamAL)
        {
          string pName = obj.ToString();
          string key = "#" + pName;
          if (this.ExistsInHT(key))
            flag = true;
          else
            key = pName;
          if (!this._ParamHT.ContainsKey((object) key))
            throw new Exception("Check Parameter : '" + key + "' and confirm if it exists !!");
          this.SetParam(pName, pdataType[(object) pName].ToString(), this._ParamHT[(object) key].ToString(), flag);
          flag = false;
        }
      }
      if (this.Mode == oSPWrapper.QueryMode.ExecuteNonQuery)
      {
        this._SQLCmd.ExecuteNonQuery();
        this.SetParamHT(this._SQLCmd);
        messageObject.ExecuteSuccess = true;
        oracleTransaction.Commit();
      }
      else if (this.Mode == oSPWrapper.QueryMode.ExecuteReader)
      {
        messageObject.Result = (object) this._SQLCmd.ExecuteReader();
        this.SetParamHT(this._SQLCmd);
        messageObject.ExecuteSuccess = true;
        oracleTransaction.Commit();
      }
      else if (this.Mode == oSPWrapper.QueryMode.ExecuteScalar)
      {
        messageObject.Result = this._SQLCmd.ExecuteScalar();
        this.SetParamHT(this._SQLCmd);
        messageObject.ExecuteSuccess = true;
        oracleTransaction.Commit();
      }
      else
      {
        this._SQLCmd.ExecuteNonQuery();
        this.SetParamHT(this._SQLCmd);
        messageObject.ExecuteSuccess = true;
        oracleTransaction.Commit();
      }
      return messageObject;
    }
    catch (OracleException ex)
    {
      oracleTransaction.Rollback();
      messageObject.ExecuteSuccess = false;
      messageObject.OutResultCode = ex.ErrorCode;
      messageObject.OutResultMessage = ex.Message;
      return messageObject;
    }
    catch (Exception ex)
    {
      oracleTransaction.Rollback();
      messageObject.ExecuteSuccess = false;
      messageObject.OutResultCode = 6000;
      messageObject.OutResultMessage = ex.Message;
      return messageObject;
    }
    finally
    {
      if (conn != null)
      {
        conn.Close();
        conn.Dispose();
      }
    }
  }

  public MessageObject ExecuteSPM()
  {
    if (!this.IsMultipleTxn)
      throw new Exception("ExecuteSPM method is used for Multiple Txn only !!");
    MessageObject messageObject = new MessageObject();
    if (this._SQLConnM == null)
      this._SQLConnM = new OracleConnection(this._ConnectionString);
    this._SQLCmd = new OracleCommand(this.SPPackage(), this._SQLConnM);
    this._SQLCmd.CommandType = CommandType.StoredProcedure;
    this._SQLCmd.BindByName = true;
    this._SQLCmd.CommandTimeout = this.CommandTimeout;
    if (this._SQLCmd.Connection.State != ConnectionState.Open)
      this._SQLCmd.Connection.Open();
    if (this.sqlTxnM == null)
      this.sqlTxnM = this._SQLConnM.BeginTransaction(IsolationLevel.ReadCommitted);
    try
    {
      string empty = string.Empty;
      bool flag = false;
      if (this._ParamHT != null && this._ParamHT.Count != 0)
      {
        Hashtable pdataType = (Hashtable) this.GetPDataType();
        foreach (object obj in this._ParamAL)
        {
          string pName = obj.ToString();
          string key = "#" + pName;
          if (this.ExistsInHT(key))
            flag = true;
          else
            key = pName;
          if (!this._ParamHT.ContainsKey((object) key))
            throw new Exception("Check Parameter : '" + key + "' and confirm if it exists !!");
          this.SetParam(pName, pdataType[(object) pName].ToString(), this._ParamHT[(object) key].ToString(), flag);
          flag = false;
        }
      }
      if (this.Mode == oSPWrapper.QueryMode.ExecuteNonQuery)
      {
        this._SQLCmd.ExecuteNonQuery();
        this.SetParamHT(this._SQLCmd);
        messageObject.ExecuteSuccess = true;
      }
      else if (this.Mode == oSPWrapper.QueryMode.ExecuteReader)
      {
        messageObject.Result = (object) this._SQLCmd.ExecuteReader();
        this.SetParamHT(this._SQLCmd);
        messageObject.ExecuteSuccess = true;
      }
      else if (this.Mode == oSPWrapper.QueryMode.ExecuteScalar)
      {
        messageObject.Result = this._SQLCmd.ExecuteScalar();
        this.SetParamHT(this._SQLCmd);
        messageObject.ExecuteSuccess = true;
      }
      else
      {
        this._SQLCmd.ExecuteNonQuery();
        this.SetParamHT(this._SQLCmd);
        messageObject.ExecuteSuccess = true;
      }
      return messageObject;
    }
    catch (OracleException ex)
    {
      this.sqlTxnM.Rollback();
      messageObject.ExecuteSuccess = false;
      messageObject.OutResultCode = ex.ErrorCode;
      messageObject.OutResultMessage = ex.Message;
      return messageObject;
    }
    catch (Exception ex)
    {
      this.sqlTxnM.Rollback();
      messageObject.ExecuteSuccess = false;
      messageObject.OutResultCode = 6000;
      messageObject.OutResultMessage = ex.Message;
      return messageObject;
    }
  }

  public void Commit()
  {
    try
    {
      this.sqlTxnM.Commit();
      this.oDispose();
    }
    catch (Exception ex)
    {
      throw new Exception("Transaction were not committed !!");
    }
  }

  public void RollBack()
  {
    try
    {
      this.sqlTxnM.Rollback();
      this.oDispose();
    }
    catch (Exception ex)
    {
    }
  }

  private void oDispose()
  {
    if (this._SQLConnM == null)
      return;
    this._SQLCmd.Dispose();
    this._SQLConnM.Close();
    this._SQLConnM.Dispose();
  }

  private void SetParamHT(OracleCommand _OCmd)
  {
    try
    {
      for (int index = 0; index < _OCmd.Parameters.Count; ++index)
      {
        string key = "#" + _OCmd.Parameters[index].ParameterName.Replace(":", "");
        if (this.ExistsInHT(key))
          this._ParamHT[(object) key] = (object) _OCmd.Parameters[index].Value.ToString();
      }
    }
    catch (Exception ex)
    {
    }
  }

  private bool ExistsInHT(string key)
  {
    return this._ParamHT.ContainsKey((object) key);
  }

  public void SetParam(string pName, string pDataType, string pValue, bool flag)
  {
    switch (pDataType.ToLower())
    {
      case "nvarchar2":
        this.SPParam = this._SQLCmd.Parameters.Add(pName, OracleDbType.NVarchar2);
        if (flag)
        {
          this.SPParam.Direction = ParameterDirection.Output;
          this.SPParam.Size = 4000;
        }
        if (pValue == "")
        {
          this.SPParam.Value = (object) DBNull.Value;
          break;
        }
        this.SPParam.Value = (object) pValue;
        break;
      case "TIMESTAMP WITH TIME ZONE":
        this.SPParam = this._SQLCmd.Parameters.Add(pName, OracleDbType.Varchar2);
        if (flag)
          this.SPParam.Direction = ParameterDirection.Output;
        if (pValue == "")
        {
          this.SPParam.Value = (object) DBNull.Value;
          break;
        }
        this.SPParam.Value = (object) pValue;
        break;
      case "varchar2":
        this.SPParam = this._SQLCmd.Parameters.Add(pName, OracleDbType.Varchar2);
        this.SPParam.Size = 4000;
        if (flag)
          this.SPParam.Direction = ParameterDirection.Output;
        if (pValue == "")
        {
          this.SPParam.Value = (object) DBNull.Value;
          break;
        }
        this.SPParam.Value = (object) pValue;
        break;
      case "char":
        this.SPParam = this._SQLCmd.Parameters.Add(pName, OracleDbType.Char);
        this.SPParam.Size = 1;
        if (flag)
          this.SPParam.Direction = ParameterDirection.Output;
        if (pValue == "")
        {
          this.SPParam.Value = (object) DBNull.Value;
          break;
        }
        this.SPParam.Value = (object) pValue;
        break;
      case "number":
        this.SPParam = this._SQLCmd.Parameters.Add(pName, OracleDbType.Decimal);
        if (flag)
          this.SPParam.Direction = ParameterDirection.Output;
        if (pValue == "")
        {
          this.SPParam.Value = (object) DBNull.Value;
          break;
        }
        this.SPParam.Value = (object) pValue;
        break;
      case "int32":
        this.SPParam = this._SQLCmd.Parameters.Add(pName, OracleDbType.Int32);
        if (flag)
          this.SPParam.Direction = ParameterDirection.Output;
        if (pValue == "")
        {
          this.SPParam.Value = (object) DBNull.Value;
          break;
        }
        this.SPParam.Value = (object) pValue;
        break;
      case "numeric":
        this.SPParam = this._SQLCmd.Parameters.Add(pName, OracleDbType.Decimal);
        if (flag)
        {
          this.SPParam.Direction = ParameterDirection.Output;
          this.SPParam.Size = 38;
        }
        if (pValue == "")
        {
          this.SPParam.Value = (object) DBNull.Value;
          break;
        }
        this.SPParam.Value = (object) Convert.ToDecimal(pValue);
        break;
      case "decimal":
        this.SPParam = this._SQLCmd.Parameters.Add(pName, OracleDbType.Varchar2);
        this.SPParam.Size = 38;
        if (flag)
          this.SPParam.Direction = ParameterDirection.Output;
        if (pValue == "")
        {
          this.SPParam.Value = (object) DBNull.Value;
          break;
        }
        this.SPParam.Value = (object) pValue;
        break;
      case "long":
        this.SPParam = this._SQLCmd.Parameters.Add(pName, OracleDbType.Long);
        if (flag)
          this.SPParam.Direction = ParameterDirection.Output;
        if (pValue == "")
        {
          this.SPParam.Value = (object) DBNull.Value;
          break;
        }
        this.SPParam.Value = (object) Convert.ToDouble(pValue);
        break;
      case "date":
        this.SPParam = this._SQLCmd.Parameters.Add(pName, OracleDbType.Date);
        if (flag)
          this.SPParam.Direction = ParameterDirection.Output;
        if (pValue == "")
        {
          this.SPParam.Value = (object) DBNull.Value;
          break;
        }
        this.SPParam.Value = (object) pValue;
        break;
      default:
        this.SPParam = this._SQLCmd.Parameters.Add(pName, OracleDbType.Varchar2);
        this.SPParam.Size = 4000;
        if (flag)
          this.SPParam.Direction = ParameterDirection.Output;
        if (pValue == "")
        {
          this.SPParam.Value = (object) DBNull.Value;
          break;
        }
        this.SPParam.Value = (object) pValue;
        break;
    }
  }

  public object GetPDataType()
  {
    OracleConnection oracleConnection = new OracleConnection(this._ConnectionString);
    try
    {
      OracleConnection conn = new OracleConnection(this._ConnectionString);
      string empty = string.Empty;
      string cmdText;
      if (string.IsNullOrEmpty(this.PackageName))
        cmdText = "SELECT a.argument_name AS name, a.data_type AS dt, a.in_out AS isoutparam FROM user_arguments a WHERE 1=1 AND object_name = UPPER ('" + this.SPName + "') AND a.package_name IS NULL ORDER BY object_name, a.sequence";
      else
        cmdText = "SELECT a.argument_name AS name, a.data_type AS dt, a.in_out AS isoutparam FROM user_arguments a WHERE 1=1 AND object_name = UPPER ('" + this.SPName + "') AND a.package_name = UPPER ('" + this.PackageName + "') ORDER BY object_name, a.sequence";
      OracleCommand selectCommand = new OracleCommand(cmdText, conn);
      conn.Open();
      selectCommand.ExecuteNonQuery();
      DataTable dataTable = new DataTable();
      Hashtable hashtable = new Hashtable();
      new OracleDataAdapter(selectCommand).Fill(dataTable);
      conn.Close();
      conn.Dispose();
      this._ParamAL.Clear();
      if (dataTable.Rows.Count > 0)
      {
        foreach (DataRow row in (InternalDataCollectionBase) dataTable.Rows)
        {
          hashtable.Add(row[0], row[1]);
          this._ParamAL.Add(row[0]);
        }
      }
      return (object) hashtable;
    }
    catch (OracleException ex)
    {
      return (object) null;
    }
    catch (Exception ex)
    {
      ErrorLog.AddException(ex);
      return (object) null;
    }
    finally
    {
      if (oracleConnection != null)
        oracleConnection.Dispose();
    }
  }

  public enum QueryMode
  {
    ExecuteNonQuery = 1,
    ExecuteReader = 2,
    ExecuteScalar = 3,
  }
}
