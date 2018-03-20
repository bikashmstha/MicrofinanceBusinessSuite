// Decompiled with JetBrains decompiler
// Type: SPWrapper
// Assembly: nsWrapper, Version=1.0.3.6, Culture=neutral, PublicKeyToken=null
// MVID: F361227A-6D4B-45AA-942B-17294A86FE90
// Assembly location: C:\Users\Hp-pc\Desktop\MFBS\DataObjects\bin\nsWrapper.dll

using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public class SPWrapper
{
  private string _ConnectionString = string.Empty;
  private string _SPName = string.Empty;
  private Hashtable _ParamHT = new Hashtable();
  private SPWrapper.QueryMode _QMode = SPWrapper.QueryMode.ExecuteScalar;
  private const string prfOut = "#";
  private SqlParameter SPParam;
  private SqlDataReader SPDataReader;
  private SqlTransaction SPTransaction;
  private SqlCommand _SQLCmd;
  private string outputParams;

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

  public SPWrapper.QueryMode Mode
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

  public SPWrapper()
  {
    int num = 0;
    try
    {
      this._ConnectionString = ConfigurationManager.ConnectionStrings["eRemitronConnectionString"].ToString();
    }
    catch (Exception ex)
    {
      if (num + num >= 1)
        return;
      this._ConnectionString = ConfigurationManager.ConnectionStrings[""].ToString();
        //this._ConnectionString = ConfigurationManager.ConnectionStrings[nameof (ConnectionString)].ToString();
    }
  }

  public SPWrapper(string p_ConnectionString)
  {
    this._ConnectionString = p_ConnectionString;
  }

  public bool DBConnection()
  {
    try
    {
      SqlConnection sqlConnection = new SqlConnection(this._ConnectionString);
      return true;
    }
    catch (Exception ex)
    {
      ErrorLog.AddException(ex);
      return false;
    }
  }

  public object ExecuteSP()
  {
    SqlConnection connection = new SqlConnection(this._ConnectionString);
    MessageObject messageObject = new MessageObject();
    try
    {
      this._SQLCmd = new SqlCommand(this._SPName, connection);
      this._SQLCmd.CommandType = CommandType.StoredProcedure;
      string empty = string.Empty;
      bool flag = false;
      if (this._ParamHT != null && this._ParamHT.Count != 0)
      {
        Hashtable pdataType = (Hashtable) this.GetPDataType();
        foreach (object key in (IEnumerable) this._ParamHT.Keys)
        {
          string str = key.ToString();
          if (str.Substring(0, 1) == "#")
          {
            flag = true;
            str = str.Replace("#", "");
          }
          string pName = "@" + str;
          this.SetParam(pName, pdataType[(object) pName].ToString(), this._ParamHT[key].ToString(), flag);
          flag = false;
        }
      }
      this._SQLCmd.Connection.Open();
      DataSet dataSet = new DataSet();
      if (this.Mode == SPWrapper.QueryMode.ExecuteNonQuery)
      {
        this._SQLCmd.ExecuteNonQuery();
        this.SetParamHT(new SqlDataAdapter(this._SQLCmd));
        return (object) true;
      }
      if (this.Mode == SPWrapper.QueryMode.ExecuteFunction)
      {
        SqlDataReader sqlDataReader = this._SQLCmd.ExecuteReader();
        if (sqlDataReader.Read())
          return sqlDataReader[0];
        return (object) 0;
      }
      this._SQLCmd.ExecuteScalar();
      this.SetParamHT(new SqlDataAdapter(this._SQLCmd));
      return (object) true;
    }
    catch (SqlException ex)
    {
      ErrorLog.AddSqlException(ex);
      return (object) false;
    }
    catch (Exception ex)
    {
      ErrorLog.AddException(ex);
      return (object) false;
    }
    finally
    {
      if (connection != null)
      {
        connection.Close();
        connection.Dispose();
      }
    }
  }

  public MessageObject ExecuteSPN()
  {
    SqlConnection connection = new SqlConnection(this._ConnectionString);
    MessageObject messageObject = new MessageObject();
    try
    {
      this._SQLCmd = new SqlCommand(this._SPName, connection);
      this._SQLCmd.CommandType = CommandType.StoredProcedure;
      string empty = string.Empty;
      bool flag = false;
      if (this._ParamHT != null && this._ParamHT.Count != 0)
      {
        Hashtable pdataType = (Hashtable) this.GetPDataType();
        foreach (object key in (IEnumerable) this._ParamHT.Keys)
        {
          string str = key.ToString();
          if (str.Substring(0, 1) == "#")
          {
            flag = true;
            str = str.Replace("#", "");
          }
          string pName = "@" + str;
          this.SetParam(pName, pdataType[(object) pName].ToString(), this._ParamHT[key].ToString(), flag);
          flag = false;
        }
      }
      this._SQLCmd.Connection.Open();
      DataSet dataSet = new DataSet();
      if (this.Mode == SPWrapper.QueryMode.ExecuteNonQuery)
      {
        this._SQLCmd.ExecuteNonQuery();
        SqlDataAdapter sda = new SqlDataAdapter(this._SQLCmd);
        this.SetParamHT(sda);
        messageObject.ExecuteSuccess = true;
        messageObject.Result = (object) sda;
        return messageObject;
      }
      if (this.Mode == SPWrapper.QueryMode.ExecuteFunction)
      {
        SqlDataReader sqlDataReader = this._SQLCmd.ExecuteReader();
        if (!sqlDataReader.Read())
          return messageObject;
        messageObject.Result = (object) sqlDataReader[0].ToString();
        messageObject.ExecuteSuccess = true;
        return messageObject;
      }
      this._SQLCmd.ExecuteScalar();
      SqlDataAdapter sda1 = new SqlDataAdapter(this._SQLCmd);
      this.SetParamHT(sda1);
      messageObject.Result = (object) sda1;
      messageObject.ExecuteSuccess = true;
      return messageObject;
    }
    catch (SqlException ex)
    {
      messageObject.ExecuteSuccess = false;
      messageObject.OutResultCode = 6000;
      messageObject.OutResultMessage = ex.Message;
      ErrorLog.AddSqlException(ex);
      return messageObject;
    }
    catch (Exception ex)
    {
      ErrorLog.AddException(ex);
      messageObject.ExecuteSuccess = false;
      messageObject.OutResultCode = 6000;
      messageObject.OutResultMessage = ex.Message.ToString();
      return messageObject;
    }
    finally
    {
      if (connection != null)
      {
        connection.Close();
        connection.Dispose();
      }
    }
  }

  private void SetParamHT(SqlDataAdapter sda)
  {
    try
    {
      for (int index = 0; index < sda.SelectCommand.Parameters.Count; ++index)
      {
        string key = "#" + sda.SelectCommand.Parameters[index].ParameterName.Replace("@", "");
        if (this.ExistsInHT(key))
          this._ParamHT[(object) key] = (object) sda.SelectCommand.Parameters[index].Value.ToString();
      }
    }
    catch (Exception ex)
    {
      ErrorLog.AddException(ex);
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
      case "nvarchar":
        this.SPParam = this._SQLCmd.Parameters.Add(pName, SqlDbType.NVarChar, 4000);
        if (flag)
          this.SPParam.Direction = ParameterDirection.Output;
        if (pValue == "")
        {
          this.SPParam.Value = (object) DBNull.Value;
          break;
        }
        this.SPParam.Value = (object) pValue;
        break;
      case "varchar":
        this.SPParam = this._SQLCmd.Parameters.Add(pName, SqlDbType.VarChar, 4000);
        if (flag)
          this.SPParam.Direction = ParameterDirection.Output;
        if (pValue == "")
        {
          this.SPParam.Value = (object) DBNull.Value;
          break;
        }
        this.SPParam.Value = (object) pValue;
        break;
      case "text":
        this.SPParam = this._SQLCmd.Parameters.Add(pName, SqlDbType.Text);
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
        this.SPParam = this._SQLCmd.Parameters.Add(pName, SqlDbType.Char);
        if (flag)
          this.SPParam.Direction = ParameterDirection.Output;
        if (pValue == "")
        {
          this.SPParam.Value = (object) DBNull.Value;
          break;
        }
        this.SPParam.Value = (object) pValue;
        break;
      case "int":
        this.SPParam = this._SQLCmd.Parameters.Add(pName, SqlDbType.Int);
        if (flag)
          this.SPParam.Direction = ParameterDirection.Output;
        if (pValue == "")
        {
          this.SPParam.Value = (object) DBNull.Value;
          break;
        }
        this.SPParam.Value = (object) pValue;
        break;
      case "smallint":
        this.SPParam = this._SQLCmd.Parameters.Add(pName, SqlDbType.SmallInt);
        if (flag)
          this.SPParam.Direction = ParameterDirection.Output;
        if (pValue == "")
        {
          this.SPParam.Value = (object) DBNull.Value;
          break;
        }
        this.SPParam.Value = (object) pValue;
        break;
      case "bigint":
        this.SPParam = this._SQLCmd.Parameters.Add(pName, SqlDbType.BigInt);
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
        this.SPParam = this._SQLCmd.Parameters.Add(pName, SqlDbType.Decimal, 38);
        if (flag)
          this.SPParam.Direction = ParameterDirection.Output;
        if (pValue == "")
        {
          this.SPParam.Value = (object) DBNull.Value;
          break;
        }
        this.SPParam.Value = (object) Convert.ToDecimal(pValue);
        break;
      case "money":
        this.SPParam = this._SQLCmd.Parameters.Add(pName, SqlDbType.Money);
        if (flag)
          this.SPParam.Direction = ParameterDirection.Output;
        if (pValue == "")
        {
          this.SPParam.Value = (object) DBNull.Value;
          break;
        }
        this.SPParam.Value = (object) pValue;
        break;
      case "decimal":
        this.SPParam = this._SQLCmd.Parameters.Add(pName, SqlDbType.VarChar, 38);
        if (flag)
          this.SPParam.Direction = ParameterDirection.Output;
        if (pValue == "")
        {
          this.SPParam.Value = (object) DBNull.Value;
          break;
        }
        this.SPParam.Value = (object) pValue;
        break;
      case "float":
        this.SPParam = this._SQLCmd.Parameters.Add(pName, SqlDbType.Float);
        if (flag)
          this.SPParam.Direction = ParameterDirection.Output;
        if (pValue == "")
        {
          this.SPParam.Value = (object) DBNull.Value;
          break;
        }
        this.SPParam.Value = (object) Convert.ToDouble(pValue);
        break;
      case "datetime":
        this.SPParam = this._SQLCmd.Parameters.Add(pName, SqlDbType.DateTime);
        if (flag)
          this.SPParam.Direction = ParameterDirection.Output;
        if (pValue == "")
        {
          this.SPParam.Value = (object) DBNull.Value;
          break;
        }
        this.SPParam.Value = (object) pValue;
        break;
      case "date":
        this.SPParam = this._SQLCmd.Parameters.Add(pName, SqlDbType.DateTime);
        if (flag)
          this.SPParam.Direction = ParameterDirection.Output;
        if (pValue == "")
        {
          this.SPParam.Value = (object) DBNull.Value;
          break;
        }
        this.SPParam.Value = (object) pValue;
        break;
      case "bit":
        this.SPParam = this._SQLCmd.Parameters.Add(pName, SqlDbType.Bit);
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
        this.SPParam = this._SQLCmd.Parameters.Add(pName, SqlDbType.VarChar, 4000);
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
    SqlConnection sqlConnection = new SqlConnection(this._ConnectionString);
    try
    {
      SqlConnection connection = new SqlConnection(this._ConnectionString);
      SqlCommand selectCommand = new SqlCommand("select dbo.syscolumns.name,type_name(dbo.syscolumns.xusertype) as dt, dbo.syscolumns.isoutparam from dbo.sysobjects inner join dbo.syscolumns on dbo.syscolumns.id = dbo.sysobjects.id where dbo.sysobjects.name = '" + this._SPName + "'", connection);
      connection.Open();
      selectCommand.ExecuteNonQuery();
      DataTable dataTable = new DataTable();
      Hashtable hashtable = new Hashtable();
      new SqlDataAdapter(selectCommand).Fill(dataTable);
      connection.Close();
      connection.Dispose();
      if (dataTable.Rows.Count > 0)
      {
        foreach (DataRow row in (InternalDataCollectionBase) dataTable.Rows)
          hashtable.Add(row[0], row[1]);
      }
      return (object) hashtable;
    }
    catch (SqlException ex)
    {
      ErrorLog.AddSqlException(ex);
      return (object) null;
    }
    catch (Exception ex)
    {
      ErrorLog.AddException(ex);
      return (object) null;
    }
    finally
    {
      if (sqlConnection != null)
        sqlConnection.Dispose();
    }
  }

  public enum QueryMode
  {
    ExecuteNonQuery = 1,
    ExecuteReader = 2,
    ExecuteScalar = 3,
    ExecuteXmlReader = 4,
    ExecuteFunction = 5,
  }
}
