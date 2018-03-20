using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Maintenance;
using BusinessObjects.Security;
using DataObjects.Interfaces.Maintenance;
using Oracle.DataAccess.Client;
namespace DataObjects.AdoNet.Oracle.Maintenance
{
    public class OracleGlTypeDao:IGLVoucherTypeDao
    {
        private List<OracleParameter> PrepareParameterList(GLVoucherType glVoucherType)
        {
            List<OracleParameter> paramList = new List<OracleParameter>();
            /*
             * p_tran_office_code   IN     VARCHAR2,
                                p_voucher_type       IN     VARCHAR2,
                                p_fiscal_year        IN     VARCHAR2,
                                p_voucher_name       IN     VARCHAR2,
                                p_last_voucher_no    IN     NUMBER,
                                p_date               IN     DATE,
                                p_user               IN     VARCHAR2,
                                p_insert_update      IN     VARCHAR2,
                                v_out_result_code       OUT VARCHAR2,
                                v_out_result_msg        OUT VARCHAR2*/

            paramList.Add(SqlHelper.GetOraParam(":p_tran_office_code", glVoucherType.TranOffCode, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_voucher_type", glVoucherType.VoucherType, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_fiscal_year", glVoucherType.FiscalYear, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_voucher_name", glVoucherType.VoucherName, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_last_voucher_no", glVoucherType.LastVoucherNo, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_date", glVoucherType.CreatedOn, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_user", glVoucherType.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":P_INSERT_UPDATE", glVoucherType.Action, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_CODE", null, OracleDbType.Varchar2, ParameterDirection.Output));
            paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_DESC", null, OracleDbType.Varchar2, ParameterDirection.Output));
            paramList[3].Size = 10;
            paramList[4].Size = 100;

            return paramList;

        }
        public List<GLVoucherType> GetGLVoucherType(string officeCode, string fiscalYear)
        {
            try
            {
                /*
                 * 
                 * p_office_code                MS_INSTITUTE.INSTITUTE_CODE%TYPE,
                                                  p_fiscal_year                  MS_NEPALI_FISCAL_YEAR.FISCAL_YEAR%TYPE,*/


                string SP = "gl_voucher_type_pkg.p_voucher_type_list";

                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_office_code", officeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_fiscal_year", fiscalYear, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));

                OracleConnection conn = new GetConnection().GetDbConn();
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, SP, paramList.ToArray());
                List<GLVoucherType> lst = new List<GLVoucherType>();


                GLVoucherType obj;
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    obj = new GLVoucherType();
                    /*GVT.VOUCHER_TYPE,
                     * GVT.VOUCHER_NAME,
                     * GVT.LAST_VOUCHER_NO,
                     * GVT.TRAN_OFFICE_CODE,
                     * GVT.FISCAL_YEAR  */

                    obj.VoucherType = drow["VOUCHER_TYPE"].ToString();//APPLICATION_ID
                    obj.VoucherName = drow["VOUCHER_NAME"].ToString();//APPLICATION_DESCRIPTION
                    if (!string.IsNullOrEmpty(drow["LAST_VOUCHER_NO"].ToString()))
                        obj.LastVoucherNo = long.Parse(drow["LAST_VOUCHER_NO"].ToString());//APPLICATION_ID
                    obj.TranOffCode = drow["TRAN_OFFICE_CODE"].ToString();//APPLICATION_DESCRIPTION
                    obj.FiscalYear = drow["FISCAL_YEAR"].ToString();//APPLICATION_ID
                    obj.Action = "U";

                    lst.Add(obj);
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public OutMessage SaveGLVoucherType(GLVoucherType glVoucherType)
        {
            string SP = "gl_voucher_type_pkg.p_gl_voucher_type"; ;
            OutMessage oMsg = new OutMessage();

            List<OracleParameter> paramList = PrepareParameterList(glVoucherType);

            try
            {
                OracleConnection conn = new GetConnection().GetDbConn();
                SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, SP, paramList.ToArray());

                oMsg.OutResultCode = paramList[3].Value.ToString();
                oMsg.OutResultMessage = paramList[4].Value.ToString();

                return oMsg;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}