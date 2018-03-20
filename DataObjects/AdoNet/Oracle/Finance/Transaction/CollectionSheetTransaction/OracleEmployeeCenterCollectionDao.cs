using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Finance.Transaction.CollectionSheetTransaction;
using DataObjects.Interfaces.Finance;
using Oracle.DataAccess.Client;


namespace DataObjects.AdoNet.Oracle.Finance
{
    public class OracleEmployeeCenterCollectionDao : IEmployeeCenterCollectionDao
    {
        public object Get()
        {
            string sp = "employeeCenterCollection_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<EmployeeCenterCollection> lst = new List<EmployeeCenterCollection>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    EmployeeCenterCollection obj = new EmployeeCenterCollection();
                    obj.CollectionSheetNo = drow["CollectionSheetNo"].ToString();
                    obj.CenterCode = drow["CenterCode"].ToString();
                    obj.CenterName = drow["CenterName"].ToString();
                    obj.DataEntered = drow["DataEntered"].ToString();
                    obj.EmpName = drow["EmpName"].ToString();
                    obj.CollnDate = drow["CollnDate"].ToString();

                    obj.Action = "U";
                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object Save(EmployeeCenterCollection employeeCenterCollection)
        {
            string sp = "employeeCenterCollection_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_CollectionSheetNo", employeeCenterCollection.CollectionSheetNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CenterCode", employeeCenterCollection.CenterCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CenterName", employeeCenterCollection.CenterName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DataEntered", employeeCenterCollection.DataEntered, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EmpName", employeeCenterCollection.EmpName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CollnDate", employeeCenterCollection.CollnDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", employeeCenterCollection.Action, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_CODE", null, OracleDbType.Varchar2, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 20;
                paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_DESC", null, OracleDbType.Varchar2, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 20;
                SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, sp, paramList.ToArray());
                tran.Commit();
                oMsg.OutResultCode = paramList[paramList.Count - 2].Value.ToString(); oMsg.OutResultMessage = paramList[paramList.Count - 1].Value.ToString();
                return oMsg;
            }
            catch (Exception ex) { tran.Rollback(); oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object Search(EmployeeCenterCollection employeeCenterCollection)
        {
            string sp = "employeeCenterCollection_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_CollectionSheetNo", employeeCenterCollection.CollectionSheetNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CenterCode", employeeCenterCollection.CenterCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CenterName", employeeCenterCollection.CenterName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DataEntered", employeeCenterCollection.DataEntered, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EmpName", employeeCenterCollection.EmpName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CollnDate", employeeCenterCollection.CollnDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<EmployeeCenterCollection> lst = new List<EmployeeCenterCollection>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    EmployeeCenterCollection obj = new EmployeeCenterCollection();
                    obj.CollectionSheetNo = drow["CollectionSheetNo"].ToString();
                    obj.CenterCode = drow["CenterCode"].ToString();
                    obj.CenterName = drow["CenterName"].ToString();
                    obj.DataEntered = drow["DataEntered"].ToString();
                    obj.EmpName = drow["EmpName"].ToString();
                    obj.CollnDate = drow["CollnDate"].ToString();

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }


        public object RegenerateCollectionList(string offCode)
        {
            string sp = "collection_sheet_generate_pkg.p_regent_coll_list";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_CollectionSheetNo", offCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<EmployeeCenterCollection> lst = new List<EmployeeCenterCollection>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    EmployeeCenterCollection obj = new EmployeeCenterCollection();
                    obj.CollectionSheetNo = drow["COLLECTION_SHEET_NO"].ToString();
                    obj.CenterCode = drow["CENTER_CODE"].ToString();
                    obj.CollectionSheetNo = drow["CENTER_NAME"].ToString();
                    obj.CenterCode = drow["DATA_ENTERED"].ToString();
                    obj.CenterName = drow["EMP_NAME"].ToString();
                    obj.DataEntered = drow["COLLN_DATE"].ToString();
                    
                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }


        public object DeleteCollectionSheetMaster(string collectionSheetNo)
        {
            string sp = "collection_sheet_generate_pkg.p_collect_sheet_mst_delete";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_coll_sheet_no", collectionSheetNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_CODE", null, OracleDbType.Varchar2, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 20;
                paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_DESC", null, OracleDbType.Varchar2, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 20;
                SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, sp, paramList.ToArray());

                oMsg.OutResultMessage = paramList[2].Value.ToString();
                oMsg.OutResultCode = paramList[1].Value.ToString();
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object DeleteCollectionSheetMaster(List<string> collectionSheetNos)
        {
            string sp = "collection_sheet_generate_pkg.p_collect_sheet_mst_delete";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();

                List<OracleParameter> paramList = new List<OracleParameter>();
                foreach (string collectionSheetNo in collectionSheetNos)
                {
                    paramList.Add(SqlHelper.GetOraParam(":p_coll_sheet_no", collectionSheetNo, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_CODE", null, OracleDbType.Varchar2, ParameterDirection.Output));
                    paramList[paramList.Count - 1].Size = 100;
                    paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_DESC", null, OracleDbType.Varchar2, ParameterDirection.Output));
                    paramList[paramList.Count - 1].Size = 100;
                    SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, sp, paramList.ToArray());
                    oMsg.OutResultMessage = paramList[2].Value.ToString();
                    oMsg.OutResultCode = paramList[1].Value.ToString();

                    if (oMsg.OutResultCode != "SUCCESS")
                    {
                        tran.Rollback();
                        return oMsg;
                    }
                }
                tran.Commit();



                return oMsg;
            }
            catch (Exception ex) { tran.Rollback(); oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }
    }
}
