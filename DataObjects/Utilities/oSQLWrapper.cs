// Decompiled with JetBrains decompiler
// Type: oSQLWrapper
// Assembly: nsWrapper, Version=1.0.3.6, Culture=neutral, PublicKeyToken=null
// MVID: F361227A-6D4B-45AA-942B-17294A86FE90
// Assembly location: C:\Users\Hp-pc\Desktop\MFBS\DataObjects\bin\nsWrapper.dll

using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System;
using System.Collections;
using System.Configuration;
using System.Data;

public class oSQLWrapper : oQueryParser
{
  private string strConnectionString = string.Empty;
  private bool _GridViewCompatible = false;
  private OracleConnection _sqlConn;

  public string QrySelect
  {
    get
    {
      this.QueryType = oQueryParser.QryType.SelectQuery;
      return this.ToString();
    }
    set
    {
      this.SelectString = value;
    }
  }

  public bool GridViewCompatible
  {
    get
    {
      return this._GridViewCompatible;
    }
    set
    {
      this._GridViewCompatible = value;
    }
  }

  public oSQLWrapper()
  {
    this.strConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
  }

  public oSQLWrapper(string pConnectionString)
  {
    this.strConnectionString = pConnectionString;
  }

  public MessageObject ExecSQL(string query)
  {
    MessageObject messageObject = new MessageObject();
    if (this._sqlConn == null)
      this._sqlConn = new OracleConnection(this.strConnectionString);
    if (!this.IsPreparedSQL)
    {
      messageObject.ExecuteSuccess = false;
      messageObject.OutResultMessage = "ExecSQL is used only for Prepared SQL !!";
      return messageObject;
    }
    DataSet dataSet = new DataSet();
    if (!this._sqlConn.State.ToString().Equals("Open"))
      this._sqlConn.Open();
    OracleTransaction oracleTransaction = this._sqlConn.BeginTransaction(IsolationLevel.ReadCommitted);
    OracleDataAdapter oracleDataAdapter = new OracleDataAdapter();
    OracleCommand oracleCommand = new OracleCommand();
    if (this.QueryType == oQueryParser.QryType.SelectQuery)
    {
      oracleDataAdapter = new OracleDataAdapter(query, this._sqlConn);
      oracleDataAdapter.SelectCommand.BindByName = true;
    }
    else
    {
      oracleCommand = this._sqlConn.CreateCommand();
      oracleCommand.CommandText = query;
      oracleCommand.Transaction = oracleTransaction;
      oracleCommand.BindByName = true;
    }
    try
    {
      if (this.ParamHT.Count > 0)
      {
        foreach (string key in (IEnumerable) this.ParamHT.Keys)
        {
          OracleParameter oracleParameter = new OracleParameter();
          oracleParameter.ParameterName = ":" + key;
          oracleParameter.OracleDbType = OracleDbType.Varchar2;
          oracleParameter.Size = 4000;
          oracleParameter.Direction = ParameterDirection.Input;
          oracleParameter.DbType = DbType.String;
          oracleParameter.Value = this.ParamHT[(object) key];
          if (this.QueryType == oQueryParser.QryType.SelectQuery)
            oracleDataAdapter.SelectCommand.Parameters.Add(oracleParameter);
          else
            oracleCommand.Parameters.Add(oracleParameter);
        }
      }
      if (this.QueryType == oQueryParser.QryType.SelectQuery)
      {
        oracleDataAdapter.Fill(dataSet);
        oracleTransaction.Commit();
        messageObject.ExecuteSuccess = true;
        switch (this.ExpectedResult)
        {
          case oQueryParser.ReturnType.DataSet:
            if (this._GridViewCompatible && dataSet != null && dataSet.Tables[0].Rows.Count == 0)
              dataSet.Tables[0].Rows.Add(dataSet.Tables[0].NewRow());
            messageObject.Result = (object) dataSet;
            break;
          case oQueryParser.ReturnType.SingleRecord:
            if (dataSet != null)
            {
              messageObject.Result = dataSet.Tables[0] == null ? (object) "" : (object) dataSet.Tables[0].Rows[0][0].ToString();
              break;
            }
            break;
          case oQueryParser.ReturnType.Boolean:
            messageObject.Result = (object) true;
            break;
          default:
            messageObject.Result = (object) "";
            break;
        }
        return messageObject;
      }
      oracleCommand.ExecuteNonQuery();
      oracleTransaction.Commit();
      messageObject.ExecuteSuccess = true;
      return messageObject;
    }
    catch (Exception ex)
    {
      oracleTransaction.Rollback();
      messageObject.ExecuteSuccess = false;
      messageObject.OutResultMessage = "Error Occured:" + ex.Message;
      return messageObject;
    }
    finally
    {
      if (oracleDataAdapter != null)
        oracleDataAdapter.Dispose();
      if (oracleCommand != null)
        oracleCommand.Dispose();
      this._sqlConn.Close();
      this._sqlConn.Dispose();
    }
  }

  public MessageObject ExecSQL(string query, OracleConnection oCon)
  {
    MessageObject messageObject = new MessageObject();
    if (!this.IsPreparedSQL)
    {
      messageObject.ExecuteSuccess = false;
      messageObject.OutResultMessage = "ExecSQL is used only for Prepared SQL !!";
      return messageObject;
    }
    DataSet dataSet = new DataSet();
    if (!oCon.State.ToString().Equals("Open"))
      oCon.Open();
    OracleDataAdapter oracleDataAdapter = new OracleDataAdapter();
    OracleCommand oracleCommand = new OracleCommand();
    if (this.QueryType == oQueryParser.QryType.SelectQuery)
    {
      oracleDataAdapter = new OracleDataAdapter(query, oCon);
      oracleDataAdapter.SelectCommand.BindByName = true;
    }
    else
    {
      oracleCommand = this._sqlConn.CreateCommand();
      oracleCommand.CommandText = query;
      oracleCommand.BindByName = true;
    }
    try
    {
      if (this.ParamHT.Count > 0)
      {
        foreach (string key in (IEnumerable) this.ParamHT.Keys)
        {
          OracleParameter oracleParameter = new OracleParameter();
          oracleParameter.ParameterName = ":" + key;
          oracleParameter.OracleDbType = OracleDbType.Varchar2;
          oracleParameter.Size = 4000;
          oracleParameter.Direction = ParameterDirection.Input;
          oracleParameter.DbType = DbType.String;
          oracleParameter.Value = this.ParamHT[(object) key];
          if (this.QueryType == oQueryParser.QryType.SelectQuery)
            oracleDataAdapter.SelectCommand.Parameters.Add(oracleParameter);
          else
            oracleCommand.Parameters.Add(oracleParameter);
        }
      }
      if (this.QueryType == oQueryParser.QryType.SelectQuery)
      {
        oracleDataAdapter.Fill(dataSet);
        messageObject.ExecuteSuccess = true;
        switch (this.ExpectedResult)
        {
          case oQueryParser.ReturnType.DataSet:
            messageObject.Result = (object) dataSet;
            break;
          case oQueryParser.ReturnType.SingleRecord:
            if (dataSet != null)
            {
              messageObject.Result = dataSet.Tables[0] == null ? (object) "" : (object) dataSet.Tables[0].Rows[0][0].ToString();
              break;
            }
            break;
          case oQueryParser.ReturnType.Boolean:
            messageObject.Result = (object) true;
            break;
          default:
            messageObject.Result = (object) "";
            break;
        }
        return messageObject;
      }
      oracleCommand.ExecuteNonQuery();
      messageObject.ExecuteSuccess = true;
      return messageObject;
    }
    catch (Exception ex)
    {
      messageObject.ExecuteSuccess = false;
      messageObject.OutResultMessage = "Error Occured:" + ex.Message;
      return messageObject;
    }
    finally
    {
      if (oracleDataAdapter != null)
        oracleDataAdapter.Dispose();
      if (oracleCommand != null)
        oracleCommand.Dispose();
    }
  }

  public OracleDataReader select()
  {
    this.SelectString = this.ToString();
    OracleConnection conn = new OracleConnection(this.strConnectionString);
    OracleCommand oracleCommand = new OracleCommand(this.SelectString, conn);
    if (!conn.State.ToString().Equals("Open"))
      conn.Open();
    if (this.WhereHT.Count > 0)
    {
      Hashtable dsDataType = this.GetDSDataType();
      foreach (string key in (IEnumerable) this.WhereHT.Keys)
      {
        OracleParameter oracleParameter = new OracleParameter();
        oracleParameter.ParameterName = ":" + key;
        oracleParameter.OracleDbType = this.GetType(dsDataType[(object) key].ToString());
        oracleParameter.Value = this.WhereHT[(object) key];
        oracleCommand.Parameters.Add(oracleParameter);
      }
    }
    return oracleCommand.ExecuteReader();
  }

  public object ExecFunction()
  {
    OracleConnection oracleConnection = new OracleConnection(this.strConnectionString);
    try
    {
      this.QueryType = oQueryParser.QryType.FunctionQuery;
      string str = this.ToString();
      oracleConnection.Open();
      OracleCommand oracleCommand = new OracleCommand(str, oracleConnection);
      if (!oracleConnection.State.ToString().Equals("Open"))
        oracleConnection.Open();
      OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(str, oracleConnection);
      DataSet dataSet = new DataSet();
      oracleDataAdapter.Fill(dataSet);
      DataTable table = dataSet.Tables[0];
      if (table.Rows.Count > 0)
        return table.Rows[0]["Result"];
      return (object) null;
    }
    catch (OracleException ex)
    {
      return (object) null;
    }
    catch (Exception ex)
    {
      return (object) null;
    }
    finally
    {
      if (oracleConnection != null)
      {
        oracleConnection.Close();
        oracleConnection.Dispose();
      }
    }
  }

  public object QuickSelect()
  {
    OracleConnection selectConnection = new OracleConnection(this.strConnectionString);
    DataSet dataSet = new DataSet();
    Hashtable dsDataType = this.GetDSDataType();
    try
    {
      string qrySelect = this.QrySelect;
      selectConnection.Open();
      OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(qrySelect, selectConnection);
      if (this.WhereHT.Count > 0)
      {
        foreach (string key in (IEnumerable) this.WhereHT.Keys)
        {
          OracleParameter oracleParameter = new OracleParameter();
          oracleParameter.ParameterName = ":" + key;
          oracleParameter.OracleDbType = this.GetType(dsDataType[(object) key].ToString());
          oracleParameter.Value = this.WhereHT[(object) key];
          oracleDataAdapter.SelectCommand.Parameters.Add(oracleParameter);
        }
      }
      oracleDataAdapter.Fill(dataSet);
      switch (this.ExpectedResult)
      {
        case oQueryParser.ReturnType.DataSet:
          if (dataSet.Tables[0].Rows.Count == 0 && this.AddEmptyRow)
          {
            DataRow row = dataSet.Tables[0].NewRow();
            dataSet.Tables[0].Rows.Add(row);
          }
          return (object) dataSet;
        case oQueryParser.ReturnType.SingleRecord:
          if (dataSet != null && dataSet.Tables[0] != null)
            return (object) dataSet.Tables[0].Rows[0][0].ToString();
          return (object) "";
        case oQueryParser.ReturnType.Boolean:
          return (object) true;
        default:
          return (object) null;
      }
    }
    catch (OracleException ex)
    {
      return (object) null;
    }
    catch (Exception ex)
    {
      return (object) null;
    }
    finally
    {
      if (selectConnection != null)
      {
        selectConnection.Close();
        selectConnection.Dispose();
      }
    }
  }

  public object QuickInsertUpdate()
  {
    string str = this.ToString();
    OracleConnection oracleConnection = new OracleConnection(this.strConnectionString);
    try
    {
      Hashtable dsDataType = this.GetDSDataType();
      oracleConnection.Open();
      OracleCommand oracleCommand = new OracleCommand();
      oracleCommand.CommandText = str;
      oracleCommand.Connection = oracleConnection;
      foreach (string key in (IEnumerable) this.UpdateInsertFieldsHT.Keys)
      {
        if (this.DataKeyField != key)
        {
          OracleParameter oracleParameter = new OracleParameter();
          oracleParameter.ParameterName = ":ui" + key;
          OracleDbType type = this.GetType(dsDataType[(object) key].ToString());
          oracleParameter.OracleDbType = type;
          oracleParameter.Value = (object) this.UpdateInsertFieldsHT[(object) key].ToString();
          oracleCommand.Parameters.Add(oracleParameter);
        }
      }
      if (this.WhereHT.Count > 0 && this.QueryType == oQueryParser.QryType.UpdateQuery)
      {
        foreach (string key in (IEnumerable) this.WhereHT.Keys)
        {
          OracleParameter oracleParameter = new OracleParameter();
          oracleParameter.ParameterName = ":w" + key;
          OracleDbType type = this.GetType(dsDataType[(object) key].ToString());
          oracleParameter.OracleDbType = type;
          if (type == OracleDbType.Date)
          {
            OracleDate oracleDate = new OracleDate(Convert.ToDateTime(this.WhereHT[(object) key].ToString()));
            oracleParameter.Value = (object) oracleDate;
          }
          else
            oracleParameter.Value = (object) this.WhereHT[(object) key].ToString();
          oracleCommand.Parameters.Add(oracleParameter);
        }
      }
      oracleCommand.ExecuteNonQuery();
      oracleConnection.Close();
      oracleConnection.Dispose();
      return (object) true;
    }
    catch (OracleException ex)
    {
      return (object) false;
    }
    catch (Exception ex)
    {
      return (object) false;
    }
    finally
    {
      if (oracleConnection != null)
        oracleConnection.Dispose();
    }
  }

  private OracleDbType GetType(string strType)
  {
    switch (strType.ToLower())
    {
      case "nvarchar2":
        return OracleDbType.NVarchar2;
      case "varchar2":
        return OracleDbType.Varchar2;
      case "char":
        return OracleDbType.Char;
      case "int32":
        return OracleDbType.Int32;
      case "decimal":
        return OracleDbType.Decimal;
      case "numeric":
        return OracleDbType.Int32;
      case "long":
        return OracleDbType.Long;
      case "date":
        return OracleDbType.Date;
      case "number":
        return OracleDbType.Int32;
      default:
        return OracleDbType.Varchar2;
    }
  }

  private Hashtable GetDSDataType()
  {
    OracleConnection conn = new OracleConnection(this.strConnectionString);
    try
    {
      Hashtable hashtable = new Hashtable();
      if (this.TableName == null)
        return (Hashtable) null;
      string cmdText = "SELECT a.column_name, a.data_type, a.data_length, a.data_precision, a.data_scale FROM user_tab_columns a WHERE a.table_name = UPPER ('" + this.TableName + "')";
      conn.Open();
      OracleDataReader oracleDataReader = new OracleCommand(cmdText, conn).ExecuteReader();
      while (oracleDataReader.Read())
        hashtable[(object) oracleDataReader.GetString(0)] = (object) oracleDataReader.GetString(1);
      conn.Close();
      conn.Dispose();
      return hashtable;
    }
    catch (OracleException ex)
    {
      return (Hashtable) null;
    }
    catch (Exception ex)
    {
      return (Hashtable) null;
    }
    finally
    {
      if ((object) conn != null)
        conn.Dispose();
    }
  }

  public bool IsEmpty()
  {
    OracleConnection selectConnection = new OracleConnection(this.strConnectionString);
    DataSet dataSet = new DataSet();
    Hashtable dsDataType = this.GetDSDataType();
    try
    {
      string qrySelect = this.QrySelect;
      selectConnection.Open();
      OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(qrySelect, selectConnection);
      if (this.WhereHT.Count > 0)
      {
        foreach (string key in (IEnumerable) this.WhereHT.Keys)
        {
          OracleParameter oracleParameter = new OracleParameter();
          oracleParameter.ParameterName = ":" + key;
          oracleParameter.OracleDbType = this.GetType(dsDataType[(object) key].ToString());
          oracleParameter.Value = this.WhereHT[(object) key];
          oracleDataAdapter.SelectCommand.Parameters.Add(oracleParameter);
        }
      }
      oracleDataAdapter.Fill(dataSet);
      bool flag = dataSet.Tables[0] == null || dataSet.Tables[0].Rows.Count <= 0;
      selectConnection.Close();
      selectConnection.Dispose();
      return flag;
    }
    catch (OracleException ex)
    {
      return true;
    }
    catch (Exception ex)
    {
      return true;
    }
    finally
    {
      if (selectConnection != null)
        selectConnection.Dispose();
    }
  }
}
