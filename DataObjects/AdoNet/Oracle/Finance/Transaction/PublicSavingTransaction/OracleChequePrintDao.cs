using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Finance.Transaction.PublicSavingTransaction;
using DataObjects.Interfaces.Finance;
using Oracle.DataAccess.Client;

namespace DataObjects.AdoNet.Oracle.Finance
{
    public class OracleChequePrintDao:IChequePrintDao
    {

        public object GetNoOfChequePrint(string offCode, string savingProductCode)
        {
            string sp = "fn_saving_pkg.p_no_of_cheque_print";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                /*
                 * p_office_code               IN  MS_INSTITUTE.INSTITUTE_CODE%TYPE,
                                                        p_saving_product_code IN VARCHAR2, 
                                                        v_no_of_cheque_print OUT NUMBER,
                                                        v_from_cheque_no     OUT NUMBER,
                                                        v_to_cheque_no         OUT NUMBER,
                                                        v_from_display_no      OUT VARCHAR2,
                                                        v_to_display_no          OUT VARCHAR2*/
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_office_code", offCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_saving_product_code", savingProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_no_of_cheque_print", null, OracleDbType.Int16, ParameterDirection.Output));
                paramList.Add(SqlHelper.GetOraParam(":v_from_cheque_no", null, OracleDbType.Long, ParameterDirection.Output));
                paramList.Add(SqlHelper.GetOraParam(":v_to_cheque_no", null, OracleDbType.Long, ParameterDirection.Output));
                paramList.Add(SqlHelper.GetOraParam(":v_from_display_no", null, OracleDbType.Long, ParameterDirection.Output));
                paramList.Add(SqlHelper.GetOraParam(":v_to_display_no", null, OracleDbType.Long, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 100;

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                //List<ChequePrint> lst = new List<ChequePrint>();
                //foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                //{
                ChequePrint obj = new ChequePrint();

                obj.NoOfChequePrint = int.Parse(OracleUtilityDao.ConvertNullToNumber(paramList[2].Value.ToString()));
                obj.FromChequeNo = int.Parse(OracleUtilityDao.ConvertNullToNumber(paramList[3].Value.ToString()));
                obj.ToChequeNo = int.Parse(OracleUtilityDao.ConvertNullToNumber(paramList[4].Value.ToString()));
                obj.FromDisplayNo = paramList[5].Value.ToString();
                obj.ToDisplayNo = paramList[6].Value.ToString();

                // lst.Add(obj);
                //}
                oMsg.Result = obj;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetAccountChequeList(string accountNo, int? fromChequeNo, int? toChequeNo)
        {
            string sp = "fn_saving_utility_pkg.p_pub_acc_cheque_search_dtl";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_account_no", accountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_from_Cheque_No", fromChequeNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_to_Cheque_No", toChequeNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 100;
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());

                List<AccountChequeList> lst = new List<AccountChequeList>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    AccountChequeList obj = new AccountChequeList();
                    obj.DisplayNo = dr["DISPLAY_NO"].ToString();
                    obj.Status = dr["STATUS"].ToString();
                    obj.ReasonForCancel = dr["REASON_FOR_CANCEL"].ToString();
                    //obj.PrintedBy = dr["PRINTED_BY"].ToString();
                    obj.CreatedOn = dr["PRINTED_BY_ON"].ToString();
                    obj.ChequeNo = dr["CHEQUE_NO"].ToString();



                    lst.Add(obj);



                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

    }
}
