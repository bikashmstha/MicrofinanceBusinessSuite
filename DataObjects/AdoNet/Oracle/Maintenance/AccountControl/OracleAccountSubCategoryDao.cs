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
    public class OracleAccountSubCategoryDao:IAccountSubCategoryDao
    {
        private List<OracleParameter> PrepareParameterList(AccountSubCategory accountSubCategory)
        {
            List<OracleParameter> paramList = new List<OracleParameter>();

            /*p_category_no                          IN           NUMBER,
                                     p_display_seq                          IN           VARCHAR2,      
                                     p_rationum                             IN           VARCHAR2,   
                                     p_sub_category_desc                    IN           VARCHAR2,     
                                     p_sub_category_no                      IN           VARCHAR2,    
                                     p_insert_update_delete                 IN           VARCHAR2, 
                                     v_out_result_code                        OUT        VARCHAR2,
                                     v_out_result_msg                         OUT        VARCHAR2*/
            paramList.Add(SqlHelper.GetOraParam(":p_category_no", accountSubCategory.CategoryNo, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_display_seq", accountSubCategory.DisplaySeq, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_rationum", accountSubCategory.RatioNum, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_sub_category_desc", accountSubCategory.SubCategoryDesc, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_sub_category_no", accountSubCategory.SubCategoryNo, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_insert_update_delete", accountSubCategory.Action, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_CODE", null, OracleDbType.Varchar2, ParameterDirection.Output));
            paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_DESC", null, OracleDbType.Varchar2, ParameterDirection.Output));
            paramList[7].Size = 10;
            paramList[8].Size = 100;

            return paramList;

        }
        public List<AccountSubCategory> GetAccountSubCategory()
        {
            try
            {
                
                string SP = "GL_ACCOUNT_CONTROL_PKG.p_account_sub_category_list";

                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                
                OracleConnection conn = new GetConnection().GetDbConn();
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, SP, paramList.ToArray());
                List<AccountSubCategory> lst = new List<AccountSubCategory>();


                AccountSubCategory obj;
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    obj = new AccountSubCategory();
                    /*SUB_CATEGORY_NO, 
                           SUB_CATEGORY_DESC, 
                           CATEGORY_NO, 
                           F_GET_CATEGORY_DESCRIPTION (CATEGORY_NO) CATEGORY_DESC, 
                           F_GET_INITIAL_CATEGORY_NAME ( 
                              F_GET_INITIAL_CATEGORY (CATEGORY_NO, 'C')) 
                              CATEGORY_INITIAL_DESC, 
                           RATIONUM, 
                           DISPLAY_SEQ */
                    if (!string.IsNullOrEmpty(drow["SUB_CATEGORY_NO"].ToString()))
                    obj.SubCategoryNo = Int16.Parse(drow["SUB_CATEGORY_NO"].ToString());
                    obj.SubCategoryDesc = drow["SUB_CATEGORY_DESC"].ToString();
                    if (!string.IsNullOrEmpty(drow["CATEGORY_NO"].ToString())) 
                        obj.CategoryNo = Int16.Parse(drow["CATEGORY_NO"].ToString());
                    obj.CategoryInitialDesc = drow["CATEGORY_INITIAL_DESC"].ToString();
                    if (!string.IsNullOrEmpty(drow["RATIONUM"].ToString())) 
                        obj.RatioNum = Int16.Parse(drow["RATIONUM"].ToString());
                    if (!string.IsNullOrEmpty(drow["DISPLAY_SEQ"].ToString()))
                    obj.DisplaySeq = long.Parse(drow["DISPLAY_SEQ"].ToString());
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

        public OutMessage SaveAccountSubCategory(AccountSubCategory accountSubCategory)
        {
            string SP = "GL_ACCOUNT_CONTROL_PKG.p_account_sub_category"; ;
            OutMessage oMsg = new OutMessage();

            List<OracleParameter> paramList = PrepareParameterList(accountSubCategory);

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