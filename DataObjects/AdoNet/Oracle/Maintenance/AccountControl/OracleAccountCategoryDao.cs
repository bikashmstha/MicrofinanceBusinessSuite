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
    public class OracleAccountCategoryDao:IAccountCategoryDao
    {
        private List<OracleParameter> PrepareParameterList(AccountCategory accountCategory)
        {
            List<OracleParameter> paramList = new List<OracleParameter>();
            /*p_category_no                               IN           NUMBER,
                                 p_category_desc                             IN           VARCHAR2,      
                                 p_category_initial                          IN           VARCHAR2,   
                                 p_tran_office_code                          IN           VARCHAR2,        
                                 p_created_modified_on                       IN           DATE,
                                 p_created_modified_by                       IN           VARCHAR2,
                                 p_insert_update_delete                      IN           VARCHAR2, 
                                 v_out_result_code                              OUT       VARCHAR2,
                                 v_out_result_msg      */


            paramList.Add(SqlHelper.GetOraParam(":p_category_no", accountCategory.CategoryNo, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_category_desc", accountCategory.CategoryDesc, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_category_initial", accountCategory.CategoryInitial, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_created_modified_on", accountCategory.CreatedOn, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_created_modified_by", accountCategory.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":P_INSERT_UPDATE", accountCategory.Action, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_CODE", null, OracleDbType.Varchar2, ParameterDirection.Output));
            paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_DESC", null, OracleDbType.Varchar2, ParameterDirection.Output));
            paramList[7].Size = 10;
            paramList[8].Size = 100;

            return paramList;

        }
        public List<AccountCategory> GetAccountCategory()
        {
            try
            {
                string SP = "GL_ACCOUNT_CONTROL_PKG.p_account_category_list";

                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                OracleConnection conn = new GetConnection().GetDbConn();
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, SP, paramList.ToArray());
                List<AccountCategory> lst = new List<AccountCategory>();


                AccountCategory obj;
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    obj = new AccountCategory();
                    /*CATEGORY_NO, 
                                 CATEGORY_DESC, 
                                 CATEGORY_INITIAL,
                                 MS_REF_CODE_PKG. 
                                  F_REF_DTL_NAME ('GL_CATEGORY_INITIAL', CATEGORY_INITIAL) ss
                                    CATEGORY_INITIAL_DET */
                    obj.CategoryNo = Int16.Parse(drow["CATEGORY_NO"].ToString());
                    obj.CategoryDesc = drow["CATEGORY_DESC"].ToString();
                    obj.CategoryInitial = drow["CATEGORY_INITIAL"].ToString();
                    obj.CategoryInitialDet = drow["CATEGORY_INITIAL_DET"].ToString();
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

        public OutMessage SaveAccountCategory(AccountCategory accountCategory)
        {
            string SP = "GL_ACCOUNT_CONTROL_PKG.p_account_category"; ;
            OutMessage oMsg = new OutMessage();

            List<OracleParameter> paramList = PrepareParameterList(accountCategory);

            try
            {
                OracleConnection conn = new GetConnection().GetDbConn();
                SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, SP, paramList.ToArray());

                oMsg.OutResultCode = paramList[7].Value.ToString();
                oMsg.OutResultMessage = paramList[8].Value.ToString();

                return oMsg;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}