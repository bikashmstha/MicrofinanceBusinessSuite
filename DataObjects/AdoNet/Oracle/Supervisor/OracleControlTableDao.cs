using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Security;
using BusinessObjects.Supervisor;
using DataObjects.Interfaces.Supervisor;
using Oracle.DataAccess.Client;

namespace DataObjects.AdoNet.Oracle.Supervisor
{
    public class OracleControlTableDao:IControlTableDao
    {
        private List<OracleParameter> PrepareParameterList(ControlTable controlTable)
        {


            List<OracleParameter> paramList = new List<OracleParameter>();
            
            /*p_current_fiscal_year            IN     VARCHAR2,
      p_last_fiscal_year               IN     VARCHAR2,
      p_pl_account_head                IN     VARCHAR2,
      p_company_name                   IN     VARCHAR2,
      p_company_address1               IN     VARCHAR2,
      p_company_address2               IN     VARCHAR2,
      p_max_period_additional_loan     IN     NUMBER,
      p_basic_salary_code              IN     VARCHAR2,*/

            paramList.Add(SqlHelper.GetOraParam(":p_current_fiscal_year", controlTable.CurrentFiscalYear, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_last_fiscal_year", controlTable.LastFiscalYear, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_pl_account_head", controlTable.PLAccountHead, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_company_name", controlTable.CompanyName, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_company_address1", controlTable.CompanyAddress1, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_company_address2", controlTable.CompanyAddress2, OracleDbType.Long, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_max_period_additional_loan", controlTable.MaxPeriodAdditionalLoan, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_basic_salary_code", controlTable.BasicSalaryCode, OracleDbType.Varchar2, ParameterDirection.Input));
            


            /*
      p_grade_salary_code              IN     VARCHAR2,
      p_pf_code                        IN     VARCHAR2,
      p_overtime_code                  IN     VARCHAR2,
      p_overtime_allowed               IN     VARCHAR2,
      p_compulsory_collection_amt      IN     NUMBER,
      p_mandatory_ded_type_code        IN     VARCHAR2,
      p_pf_percentage                  IN     NUMBER,
      p_cash_account_code              IN     VARCHAR2,*/

            paramList.Add(SqlHelper.GetOraParam(":p_grade_salary_code", controlTable.GradeSalaryCode, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_pf_code", controlTable.PFCode, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_overtime_code", controlTable.OvertimeCode, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_overtime_allowed", controlTable.OvertimeAllowed, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_compulsory_collection_amt", controlTable.CompulsoryCollectionAmt, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_mandatory_ded_type_code", controlTable.MandatoryDedTypeCode, OracleDbType.Long, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_pf_percentage", controlTable.PFPercentage, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_cash_account_code", controlTable.CashAccountCode, OracleDbType.Varchar2, ParameterDirection.Input));
            

            /*
      p_period_to_take_paid_amt_mon    IN     NUMBER,
      p_miss_mon_to_take_paid_amt      IN     NUMBER,
      p_general_loan_product_code      IN     VARCHAR2,
      p_default_currency_code          IN     VARCHAR2,
      p_sub_category_no                IN     NUMBER,
      p_donation_sub_category_no       IN     NUMBER,
      p_mf_mandatory_fund_acc_code     IN     VARCHAR2,
      p_mf_per_fund_acc_code           IN     VARCHAR2,*/

            paramList.Add(SqlHelper.GetOraParam(":p_period_to_take_paid_amt_mon", controlTable.PeriodToTakePaidAmtMon, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_miss_mon_to_take_paid_amt", controlTable.MissMonToTakePaidAmt, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_general_loan_product_code", controlTable.GenLoanProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_default_currency_code", controlTable.DefaultCurrencyCode, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_sub_category_no", controlTable.SubCategoryNo, OracleDbType.Varchar2, ParameterDirection.Input));
            //paramList.Add(SqlHelper.GetOraParam(":p_donation_sub_category_no", controlTable.DonationSubCategoryNo, OracleDbType.Long, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_mf_mandatory_fund_acc_code", controlTable.MFMandatoryFundAccCode, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_mf_per_fund_acc_code", controlTable.MFPerFundAccCode, OracleDbType.Varchar2, ParameterDirection.Input));
            

            /*
      p_center_fund_acc_code           IN     VARCHAR2,
      p_mf_gen_loan_acc_code           IN     VARCHAR2,
      p_mf_penalty_acc_code            IN     VARCHAR2,
      p_mf_enterprise_acc_code         IN     VARCHAR2,
      p_mf_enter_int_acc_code          IN     VARCHAR2,
      p_int_gen_loan_acc_code          IN     VARCHAR2,
      p_mandatory_saving_product       IN     VARCHAR2,
      p_voluntary_saving_product       IN     VARCHAR2,*/

            paramList.Add(SqlHelper.GetOraParam(":p_center_fund_acc_code", controlTable.CenterFundAccCode, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_mf_gen_loan_acc_code", controlTable.MFGenLoanAccCode, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_mf_penalty_acc_code", controlTable.MFPenaltyAccCode, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_mf_enterprise_acc_code", controlTable.MFEnterpriseAccCode, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_mf_enter_int_acc_code", controlTable.MFEnterIntAccCode, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_int_gen_loan_acc_code", controlTable.IntGenLoanAccCode, OracleDbType.Long, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_mandatory_saving_product", controlTable.MandatorySavingProduct, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_voluntary_saving_product", controlTable.VoluntarySavingProduct, OracleDbType.Varchar2, ParameterDirection.Input));
            

            /*
      p_max_no_of_loan                 IN     NUMBER,
      p_staff_loan_product_code        IN     VARCHAR2,
      p_center_saving_product          IN     VARCHAR2,
      p_mandatory_allow_years          IN     NUMBER,
      p_gen_loan_product_code          IN     VARCHAR2,
      p_export_file_path               IN     VARCHAR2,
      p_import_file_path               IN     VARCHAR2,
      p_installation_date              IN     DATE,*/

            paramList.Add(SqlHelper.GetOraParam(":p_max_no_of_loan", controlTable.MaxNoOfLoan, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_staff_loan_product_code", controlTable.StaffLoanProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_center_saving_product", controlTable.CenterSavingProduct, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_mandatory_allow_years", controlTable.MandatoryAllowYears, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_gen_loan_product_code", controlTable.GenLoanProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_export_file_path", controlTable.ExportFilePath, OracleDbType.Long, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_import_file_path", controlTable.ImportFilePath, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_installation_date", controlTable.InstallationDate, OracleDbType.Varchar2, ParameterDirection.Input));
            

            /*
      p_import_log_path                IN     VARCHAR2,
      p_export_log_path                IN     VARCHAR2,
      p_earning_deduction_code         IN     VARCHAR2,
      p_min_medical_allowance          IN     NUMBER,
      p_medical_allowance_code         IN     VARCHAR2,
      p_bonus_code                     IN     VARCHAR2,
      p_bonus_days                     IN     NUMBER,
      p_cit_code                       IN     VARCHAR2,*/


            paramList.Add(SqlHelper.GetOraParam(":p_import_log_path", controlTable.ImportLogPath, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_export_log_path", controlTable.ExportLogpath, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_earning_deduction_code", controlTable.EarningDeductionCode, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_min_medical_allowance", controlTable.MinMedicalAllowance, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_medical_allowance_code", controlTable.MedicalAllowanceCode, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_bonus_code", controlTable.BonusCode, OracleDbType.Long, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_bonus_days", controlTable.BonusDays, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_cit_code", controlTable.CitCode, OracleDbType.Varchar2, ParameterDirection.Input));
            

            /*
      p_control_from_cdms              IN     VARCHAR2,
      p_budget_control_y_n             IN     VARCHAR2,
      p_location_code                  IN     VARCHAR2,
      p_sales_location                 IN     VARCHAR2,
      p_sick_leave_code                IN     VARCHAR2,
      p_house_leave_code               IN     VARCHAR2,
      p_cash_balance_group_no          IN     NUMBER,
      p_fixed_saving_col_amt_y_n       IN     VARCHAR2,*/

            paramList.Add(SqlHelper.GetOraParam(":p_control_from_cdms", controlTable.ControlFromCDMS, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_budget_control_y_n", controlTable.BudgetControlYN, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_location_code", controlTable.LocationCode, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_sales_location", controlTable.SalesLocation, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_sick_leave_code", controlTable.SickLeaveCode, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_house_leave_code", controlTable.HouseLeaveCode, OracleDbType.Long, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_cash_balance_group_no", controlTable.CashBalanceGroupNo, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_fixed_saving_col_amt_y_n", controlTable.FixdSavingColAmtYN, OracleDbType.Varchar2, ParameterDirection.Input));
            

            /*
      p_approval_range_control         IN     VARCHAR2,
      p_current_year                   IN     NUMBER,
      p_mf_member_type                 IN     VARCHAR2,
      p_inv_sub_category_no            IN     NUMBER,
      p_mandatory_loan_product         IN     VARCHAR2,
      p_welfare_saving_product_code    IN     VARCHAR2,
      p_pension_saving_product_code    IN     VARCHAR2,
      p_festival_saving_product_code   IN     VARCHAR2,*/

            paramList.Add(SqlHelper.GetOraParam(":p_approval_range_control", controlTable.ApprovalRangeControl, OracleDbType.Varchar2, ParameterDirection.Input));
            //paramList.Add(SqlHelper.GetOraParam(":p_current_year", controlTable.CurrentYear, OracleDbType.Varchar2, ParameterDirection.Input));
            //paramList.Add(SqlHelper.GetOraParam(":p_mf_member_type", controlTable.MFMemberType, OracleDbType.Varchar2, ParameterDirection.Input));
            //paramList.Add(SqlHelper.GetOraParam(":p_inv_sub_category_no", controlTable.InvSubCategoryNo, OracleDbType.Varchar2, ParameterDirection.Input));
            //paramList.Add(SqlHelper.GetOraParam(":p_mandatory_loan_product", controlTable.MandatoryLoanProduct, OracleDbType.Varchar2, ParameterDirection.Input));
            //paramList.Add(SqlHelper.GetOraParam(":p_welfare_saving_product_code", controlTable.WelFareSavingProductCode, OracleDbType.Long, ParameterDirection.Input));
            //paramList.Add(SqlHelper.GetOraParam(":p_pension_saving_product_code", controlTable.PensionSavingProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
            //paramList.Add(SqlHelper.GetOraParam(":p_festival_saving_product_code", controlTable.FestivalSavingProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
            

            /*
      p_life_pro_scheme_code           IN     VARCHAR2,
      p_branch_on_m_w                  IN     VARCHAR2,
      p_mem_pro_base_amount            IN     NUMBER,
      p_mem_pro_regular_amount         IN     NUMBER,
      p_mid_term_int_for_pension       IN     NUMBER,
      p_other_income_head              IN     VARCHAR2,
      p_interest_exp_on_pension_head   IN     VARCHAR2,
      p_full_term_int_for_pension      IN     VARCHAR2,*/

            //paramList.Add(SqlHelper.GetOraParam(":p_life_pro_scheme_code", controlTable.LifeProSchemeCode, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_branch_on_m_w", controlTable.BranchOnMW, OracleDbType.Varchar2, ParameterDirection.Input));
            //paramList.Add(SqlHelper.GetOraParam(":p_mem_pro_base_amount", controlTable.MemProBaseAmount, OracleDbType.Varchar2, ParameterDirection.Input));
            //paramList.Add(SqlHelper.GetOraParam(":p_mem_pro_regular_amount", controlTable.MemProRegularAmount, OracleDbType.Varchar2, ParameterDirection.Input));
            //paramList.Add(SqlHelper.GetOraParam(":p_mid_term_int_for_pension", controlTable.MidTermIntForPension, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_other_income_head", controlTable.OtherIncomeHead, OracleDbType.Long, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_interest_exp_on_pension_head", controlTable.InterestExpOnPensionHead, OracleDbType.Varchar2, ParameterDirection.Input));
            //paramList.Add(SqlHelper.GetOraParam(":p_full_term_int_for_pension", controlTable.FullTermIntForPension, OracleDbType.Varchar2, ParameterDirection.Input));
            

            /*
      p_unit_fund_collection_amt       IN     NUMBER,
      p_mandatory_central_control      IN     VARCHAR2,
      p_unit_fund_central_control      IN     VARCHAR2,
      p_adv_rec_on_center_date         IN     VARCHAR2,
      p_unit_fund_saving_product       IN     VARCHAR2,
      p_generate_welfare_fund_ac       IN     VARCHAR2,
      p_int_cal_method                 IN     VARCHAR2,
      p_adv_deduction_order            IN     VARCHAR2,*/

            paramList.Add(SqlHelper.GetOraParam(":p_unit_fund_collection_amt", controlTable.UnitFundCollectionAmt, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_mandatory_central_control", controlTable.MandatoryCentralControl, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_unit_fund_central_control", controlTable.UnitFundCentralControl, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_adv_rec_on_center_date", controlTable.AdvRecOnCenterDate, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_unit_fund_saving_product", controlTable.UnitFundSavingProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_generate_welfare_fund_ac", controlTable.GenerateWelFareFundAcAuto, OracleDbType.Long, ParameterDirection.Input));
            //paramList.Add(SqlHelper.GetOraParam(":p_int_cal_method", controlTable.XXIntCalMethod, OracleDbType.Varchar2, ParameterDirection.Input));
            //paramList.Add(SqlHelper.GetOraParam(":p_adv_deduction_order", controlTable.AdvDeductionOrder, OracleDbType.Varchar2, ParameterDirection.Input));
            

            /*
      p_client_photo_path              IN     VARCHAR2,
      p_joint_client_photo_path        IN     VARCHAR2,
      p_normal_sav_product_code        IN     VARCHAR2,
      p_signature2_path                IN     VARCHAR2,
      p_signature1_path                IN     VARCHAR2,
      p_other_expense_head             IN     VARCHAR2,
      p_finger_print_right_path        IN     VARCHAR2,
      p_finger_print_left_path         IN     VARCHAR2,*/

            paramList.Add(SqlHelper.GetOraParam(":p_client_photo_path", controlTable.ClientPhotoPath, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_joint_client_photo_path", controlTable.JointClientPhotoPath, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_normal_sav_product_code", controlTable.NormalSavProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_signature2_path", controlTable.Signature2Path, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_signature1_path", controlTable.Signature1Path, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_other_expense_head", controlTable.OtherExpenseHead, OracleDbType.Long, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_finger_print_right_path", controlTable.FingerPrintRightPath, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_finger_print_left_path", controlTable.FingerPrintLeftPath, OracleDbType.Varchar2, ParameterDirection.Input));
            

            /*
      p_loan_int_in_days_or_fixed      IN     VARCHAR2,
      p_loan_int_calc_days             IN     VARCHAR2,
      p_employee_photo_path            IN     VARCHAR2
             */

            paramList.Add(SqlHelper.GetOraParam(":p_loan_int_in_days_or_fixed", controlTable.LoanIntInDaysOrFixed, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_loan_int_calc_days", controlTable.LoanIntCalcDays, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_employee_photo_path", controlTable.EmployeePhotoPath, OracleDbType.Varchar2, ParameterDirection.Input));
            

            paramList.Add(SqlHelper.GetOraParam(":P_INSERT_UPDATE", controlTable.Action, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_CODE", null, OracleDbType.Varchar2, ParameterDirection.Output));
            paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_DESC", null, OracleDbType.Varchar2, ParameterDirection.Output));
            paramList[77].Size = 10;
            paramList[78].Size = 100;

            return paramList;

        }
        public List<ControlTable> GetControlTable()
        {
            try
            {
                string SP = "security_pkg.p_control_table_detail_list";

                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));

                OracleConnection conn = new GetConnection().GetDbConn();

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, SP, paramList.ToArray());
                List<ControlTable> lst = new List<ControlTable>();


                ControlTable obj;
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    obj = new ControlTable();
                    /*CURRENT_FISCAL_YEAR,
       LAST_FISCAL_YEAR,
       PL_ACCOUNT_HEAD,
       COMPANY_NAME,
       COMPANY_ADDRESS1,
       COMPANY_ADDRESS2,
       MAX_PERIOD_ADDITIONAL_LOAN,
       BASIC_SALARY_CODE,*/

                    obj.CurrentFiscalYear = drow["CURRENT_FISCAL_YEAR"].ToString();
                    obj.LastFiscalYear = drow["LAST_FISCAL_YEAR"].ToString();
                    obj.PLAccountHead = drow["PL_ACCOUNT_HEAD"].ToString();
                    obj.CompanyName = drow["COMPANY_NAME"].ToString();
                    obj.CompanyAddress1 = drow["COMPANY_ADDRESS1"].ToString();
                    obj.CompanyAddress2 = drow["COMPANY_ADDRESS2"].ToString();
                    obj.MaxPeriodAdditionalLoan = Int16.Parse(drow["MAX_PERIOD_ADDITIONAL_LOAN"].ToString());
                    obj.BasicSalaryCode = drow["BASIC_SALARY_CODE"].ToString();


                    /*
       GRADE_SALARY_CODE,
       PF_CODE,
       OVERTIME_CODE,
       OVERTIME_ALLOWED,
       COMPULSORY_COLLECTION_AMT,
       MANDATORY_DED_TYPE_CODE,
       PF_PERCENTAGE,
       CASH_ACCOUNT_CODE,*/

                    obj.GradeSalaryCode = drow["GRADE_SALARY_CODE"].ToString();
                    obj.PFCode = drow["PF_CODE"].ToString();
                    obj.OvertimeCode = drow["OVERTIME_CODE"].ToString();
                    obj.OvertimeAllowed = drow["OVERTIME_ALLOWED"].ToString();
                    obj.CompulsoryCollectionAmt = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["COMPULSORY_COLLECTION_AMT"].ToString()));
                    obj.MandatoryDedTypeCode = drow["MANDATORY_DED_TYPE_CODE"].ToString();
                    obj.PFPercentage = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PF_PERCENTAGE"].ToString()));
                    obj.CashAccountCode = drow["CASH_ACCOUNT_CODE"].ToString();

                    /*
       PERIOD_TO_TAKE_PAID_AMT_MON,
       MISS_MON_TO_TAKE_PAID_AMT,
       GENERAL_LOAN_PRODUCT_CODE,
       DEFAULT_CURRENCY_CODE,
       SUB_CATEGORY_NO,
       DONATION_SUB_CATEGORY_NO,
       MF_MANDATORY_FUND_ACC_CODE,
       MF_PER_FUND_ACC_CODE,*/

                    obj.PeriodToTakePaidAmtMon = Int16.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PERIOD_TO_TAKE_PAID_AMT_MON"].ToString()));
                    obj.MissMonToTakePaidAmt = Int16.Parse(OracleUtilityDao.ConvertNullToNumber(drow["MISS_MON_TO_TAKE_PAID_AMT"].ToString()));
                    obj.GenLoanProductCode = drow["GENERAL_LOAN_PRODUCT_CODE"].ToString();
                    obj.DefaultCurrencyCode = drow["DEFAULT_CURRENCY_CODE"].ToString();
                    obj.SubCategoryNo = Int16.Parse(OracleUtilityDao.ConvertNullToNumber(drow["SUB_CATEGORY_NO"].ToString()));
                    obj.DonationSubCategoryNo = Int16.Parse(OracleUtilityDao.ConvertNullToNumber(drow["DONATION_SUB_CATEGORY_NO"].ToString()));
                    obj.MFMandatoryFundAccCode = drow["MF_MANDATORY_FUND_ACC_CODE"].ToString();
                    obj.MFPerFundAccCode = drow["MF_PER_FUND_ACC_CODE"].ToString();


                    /*
       CENTER_FUND_ACC_CODE,
       MF_GEN_LOAN_ACC_CODE,
       MF_PENALTY_ACC_CODE,
       MF_ENTERPRISE_ACC_CODE,
       MF_ENTER_INT_ACC_CODE,
       INT_GEN_LOAN_ACC_CODE,
       MANDATORY_SAVING_PRODUCT,
       VOLUNTARY_SAVING_PRODUCT,*/

                    obj.CenterFundAccCode = drow["CENTER_FUND_ACC_CODE"].ToString();
                    obj.MFGenLoanAccCode = drow["MF_GEN_LOAN_ACC_CODE"].ToString();
                    obj.MFPenaltyAccCode = drow["MF_PENALTY_ACC_CODE"].ToString();
                    obj.MFEnterpriseAccCode = drow["MF_ENTERPRISE_ACC_CODE"].ToString();
                    obj.MFEnterIntAccCode = drow["MF_ENTER_INT_ACC_CODE"].ToString();
                    obj.IntGenLoanAccCode = drow["INT_GEN_LOAN_ACC_CODE"].ToString();
                    obj.MandatorySavingProduct = drow["MANDATORY_SAVING_PRODUCT"].ToString();
                    obj.VoluntarySavingProduct = drow["VOLUNTARY_SAVING_PRODUCT"].ToString();


                    /*
       MAX_NO_OF_LOAN,
       STAFF_LOAN_PRODUCT_CODE,
       CENTER_SAVING_PRODUCT,
       MANDATORY_ALLOW_YEARS,
       GEN_LOAN_PRODUCT_CODE,
       EXPORT_FILE_PATH,
       IMPORT_FILE_PATH,
       INSTALLATION_DATE,*/

                    obj.MaxNoOfLoan = Int16.Parse(OracleUtilityDao.ConvertNullToNumber(drow["MAX_NO_OF_LOAN"].ToString()));
                    obj.StaffLoanProductCode = drow["STAFF_LOAN_PRODUCT_CODE"].ToString();
                    obj.CenterSavingProduct = drow["CENTER_SAVING_PRODUCT"].ToString();
                    obj.MandatoryAllowYears = Int16.Parse(OracleUtilityDao.ConvertNullToNumber(drow["MANDATORY_ALLOW_YEARS"].ToString()));
                    obj.GenLoanProductCode = drow["GEN_LOAN_PRODUCT_CODE"].ToString();
                    obj.ExportFilePath = drow["EXPORT_FILE_PATH"].ToString();
                    obj.ImportFilePath = drow["IMPORT_FILE_PATH"].ToString();
                    obj.InstallationDate = drow["INSTALLATION_DATE"].ToString();


                    /*
       IMPORT_LOG_PATH,
       EXPORT_LOG_PATH,
       EARNING_DEDUCTION_CODE,
       MIN_MEDICAL_ALLOWANCE,
       MEDICAL_ALLOWANCE_CODE,
       BONUS_CODE,
       BONUS_DAYS,
       CIT_CODE,*/

                    obj.ImportLogPath = drow["IMPORT_LOG_PATH"].ToString();
                    obj.ExportLogpath = drow["EXPORT_LOG_PATH"].ToString();
                    obj.EarningDeductionCode = drow["EARNING_DEDUCTION_CODE"].ToString();
                    obj.MinMedicalAllowance = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["MIN_MEDICAL_ALLOWANCE"].ToString()));
                    obj.MedicalAllowanceCode = drow["MEDICAL_ALLOWANCE_CODE"].ToString();
                    obj.BonusCode = drow["BONUS_CODE"].ToString();
                    obj.BonusDays = drow["BONUS_DAYS"].ToString();
                    obj.CitCode = drow["CIT_CODE"].ToString();


                    /*
       CONTROL_FROM_CDMS,
       BUDGET_CONTROL_Y_N,
       LOCATION_CODE,
       SALES_LOCATION,
       SICK_LEAVE_CODE,
       HOUSE_LEAVE_CODE,
       CASH_BALANCE_GROUP_NO,
       FIXED_SAVING_COL_AMT_Y_N,*/

                    obj.ControlFromCDMS = drow["CONTROL_FROM_CDMS"].ToString();
                    obj.BudgetControlYN = drow["BUDGET_CONTROL_Y_N"].ToString();
                    obj.LocationCode = drow["LOCATION_CODE"].ToString();
                    obj.SalesLocation = drow["SALES_LOCATION"].ToString();
                    obj.SickLeaveCode = drow["SICK_LEAVE_CODE"].ToString();
                    obj.HouseLeaveCode = drow["HOUSE_LEAVE_CODE"].ToString();
                    obj.CashBalanceGroupNo = Int16.Parse(OracleUtilityDao.ConvertNullToNumber(drow["CASH_BALANCE_GROUP_NO"].ToString()));
                    obj.FixdSavingColAmtYN = drow["FIXED_SAVING_COL_AMT_Y_N"].ToString();


                    /*
       APPROVAL_RANGE_CONTROL,
       CURRENT_YEAR,
       MF_MEMBER_TYPE,
       INV_SUB_CATEGORY_NO,
       MANDATORY_LOAN_PRODUCT,
       WELFARE_SAVING_PRODUCT_CODE,
       PENSION_SAVING_PRODUCT_CODE,
       FESTIVAL_SAVING_PRODUCT_CODE,*/

                    obj.ApprovalRangeControl = drow["APPROVAL_RANGE_CONTROL"].ToString();
                    obj.CurrentYear = Int16.Parse(OracleUtilityDao.ConvertNullToNumber(drow["CURRENT_YEAR"].ToString()));
                    obj.MFMemberType = drow["MF_MEMBER_TYPE"].ToString();
                    obj.InvSubCategoryNo = Int16.Parse(OracleUtilityDao.ConvertNullToNumber(drow["INV_SUB_CATEGORY_NO"].ToString()));
                    obj.MandatoryLoanProduct = drow["MANDATORY_LOAN_PRODUCT"].ToString();
                    obj.WelFareSavingProductCode = drow["WELFARE_SAVING_PRODUCT_CODE"].ToString();
                    obj.PensionSavingProductCode = drow["PENSION_SAVING_PRODUCT_CODE"].ToString();
                    obj.FestivalSavingProductCode = drow["FESTIVAL_SAVING_PRODUCT_CODE"].ToString();


                    /*
       LIFE_PRO_SCHEME_CODE,
       BRANCH_ON_M_W,
       MEM_PRO_BASE_AMOUNT,
       MEM_PRO_REGULAR_AMOUNT,
       MID_TERM_INT_FOR_PENSION,
       OTHER_INCOME_HEAD,
       INTEREST_EXP_ON_PENSION_HEAD,
       FULL_TERM_INT_FOR_PENSION,*/

                    obj.LifeProSchemeCode = drow["LIFE_PRO_SCHEME_CODE"].ToString();
                    obj.BranchOnMW = drow["BRANCH_ON_M_W"].ToString();
                    obj.MemProBaseAmount = Int16.Parse(OracleUtilityDao.ConvertNullToNumber(drow["MEM_PRO_BASE_AMOUNT"].ToString()));
                    obj.MemProRegularAmount = Int16.Parse(OracleUtilityDao.ConvertNullToNumber(drow["MEM_PRO_REGULAR_AMOUNT"].ToString()));
                    obj.MidTermIntForPension = Int16.Parse(OracleUtilityDao.ConvertNullToNumber(drow["MID_TERM_INT_FOR_PENSION"].ToString()));
                    obj.OtherIncomeHead = drow["OTHER_INCOME_HEAD"].ToString();
                    obj.InterestExpOnPensionHead = drow["INTEREST_EXP_ON_PENSION_HEAD"].ToString();
                    obj.FullTermIntForPension = drow["FULL_TERM_INT_FOR_PENSION"].ToString();


                    /*
       UNIT_FUND_COLLECTION_AMT,
       MANDATORY_CENTRAL_CONTROL,
       UNIT_FUND_CENTRAL_CONTROL,
       ADV_REC_ON_CENTER_DATE,
       UNIT_FUND_SAVING_PRODUCT_CODE,
       GENERATE_WELFARE_FUND_AC_AUTO,
       ADV_DEDUCTION_ORDER,
       CLIENT_PHOTO_PATH,*/

                    obj.UnitFundCollectionAmt = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["UNIT_FUND_COLLECTION_AMT"].ToString()));
                    obj.MandatoryCentralControl = drow["MANDATORY_CENTRAL_CONTROL"].ToString();
                    obj.UnitFundCentralControl = drow["UNIT_FUND_CENTRAL_CONTROL"].ToString();
                    obj.AdvRecOnCenterDate = drow["ADV_REC_ON_CENTER_DATE"].ToString();
                    obj.UnitFundSavingProductCode = drow["UNIT_FUND_SAVING_PRODUCT_CODE"].ToString();
                    obj.GenerateWelFareFundAcAuto = drow["GENERATE_WELFARE_FUND_AC_AUTO"].ToString();
                    obj.AdvDeductionOrder = drow["ADV_DEDUCTION_ORDER"].ToString();
                    obj.ClientPhotoPath = drow["CLIENT_PHOTO_PATH"].ToString();


                    /*
       JOINT_CLIENT_PHOTO_PATH,
       NORMAL_SAV_PRODUCT_CODE,
       SIGNATURE2_PATH,
       SIGNATURE1_PATH,
       OTHER_EXPENSE_HEAD,
       FINGER_PRINT_RIGHT_PATH,
       FINGER_PRINT_LEFT_PATH,
       LOAN_INT_IN_DAYS_OR_FIXED,*/

                    obj.JointClientPhotoPath = drow["JOINT_CLIENT_PHOTO_PATH"].ToString();
                    obj.NormalSavProductCode = drow["NORMAL_SAV_PRODUCT_CODE"].ToString();
                    obj.Signature2Path = drow["SIGNATURE2_PATH"].ToString();
                    obj.Signature1Path = drow["SIGNATURE1_PATH"].ToString();
                    obj.OtherExpenseHead = drow["OTHER_EXPENSE_HEAD"].ToString();
                    obj.FingerPrintRightPath = drow["FINGER_PRINT_RIGHT_PATH"].ToString();
                    obj.FingerPrintLeftPath = drow["FINGER_PRINT_LEFT_PATH"].ToString();
                    obj.LoanIntInDaysOrFixed = drow["LOAN_INT_IN_DAYS_OR_FIXED"].ToString();


                    /*
       LOAN_INT_CALC_DAYS,
       EMPLOYEE_PHOTO_PATH,
       PENSION_SAVING_PERIOD,
       NON_TREAT_SAVING_AC_ON_COLLSHT,
       CIB_PATH,
       CIB_DPI_NUM,
       CIB_CONSUMER_IIF_VERSION_ID,
       CIB_MEMBER_IIF_VERSION_ID,*/

                    obj.LoanIntCalcDays = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["LOAN_INT_CALC_DAYS"].ToString()));
                    obj.EmployeePhotoPath = drow["EMPLOYEE_PHOTO_PATH"].ToString();
                    obj.PensionSavingPeriod = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PENSION_SAVING_PERIOD"].ToString()));
                    obj.NonTreatSavingAcOnCollsht = drow["NON_TREAT_SAVING_AC_ON_COLLSHT"].ToString();
                    obj.CIBPath = drow["CIB_PATH"].ToString();
                    obj.CIBDPINum = drow["CIB_DPI_NUM"].ToString();
                    obj.CIBConsumerIIFVersionId = drow["CIB_CONSUMER_IIF_VERSION_ID"].ToString();
                    obj.CIBMemberIIFVersionId = drow["CIB_MEMBER_IIF_VERSION_ID"].ToString();


                    /*
       CIB_CONSUMER_NATURE_OF_DATA,
       CIB_MEMBER_NATURE_OF_DATA,
       INT_CALC_ON_COLLECTION_DATE,
       INCHARGE_SHIP_CODE,
       CIT_FUND_CODE,
       ACCOUNTANT_EARNING_CODE,
       ACCOUNTANT_EARNING_AMT,
       ACCOUNTANT_DESIGNATION_CODE,*/

                    obj.CIBConsumerNatureOfData = drow["CIB_CONSUMER_NATURE_OF_DATA"].ToString();
                    obj.CIBMemberNatureOfData = drow["CIB_MEMBER_NATURE_OF_DATA"].ToString();
                    obj.IntCalcOnCollectionDate = drow["INT_CALC_ON_COLLECTION_DATE"].ToString();
                    obj.InchargeShipCode = drow["INCHARGE_SHIP_CODE"].ToString();
                    obj.CITFundCode = drow["CIT_FUND_CODE"].ToString();
                    obj.AccountantEarningCode = drow["ACCOUNTANT_EARNING_CODE"].ToString();
                    obj.AccountEarningAmt = Int16.Parse(OracleUtilityDao.ConvertNullToNumber(drow["ACCOUNTANT_EARNING_AMT"].ToString()));
                    obj.AccountantDesignationCode = drow["ACCOUNTANT_DESIGNATION_CODE"].ToString();


                    /*
       DURGAM_EARNING_CODE_A,
       DURGAM_EARNING_CODE_AA,
       HOUSE_RENT_ALLOWANCE_CODE,
       CAPITAL_HOUSE_RENT_PC,
       UNIFORM_EXPENSES_CODE,
       WARM_UNIFORM_EXPENSES_CODE,
       REMOTE_ALLOWANCE_CODE,
       PAYROLL_OFFICE_CODE,*/

                    obj.DurgamEarningCodeA = drow["DURGAM_EARNING_CODE_A"].ToString();
                    obj.DurgamEarningCodeAA = drow["DURGAM_EARNING_CODE_AA"].ToString();
                    obj.HouseRentAllowanceCode = drow["HOUSE_RENT_ALLOWANCE_CODE"].ToString();
                    obj.CapitalHouseRentPC = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["CAPITAL_HOUSE_RENT_PC"].ToString()));
                    obj.UniformExpensesCode = drow["UNIFORM_EXPENSES_CODE"].ToString();
                    obj.WarmUniformExpensesCode = drow["WARM_UNIFORM_EXPENSES_CODE"].ToString();
                    obj.RemoteAllowanceCode = drow["REMOTE_ALLOWANCE_CODE"].ToString();
                    obj.PayrollOfficeCode = drow["PAYROLL_OFFICE_CODE"].ToString();


                    /*
       STAFF_BENIFIT_PROV_AC_HEAD,
       MEDICAL_EXP_AC_HEAD,
       LEAVE_ENCASH_EXP_AC_HEAD,
       FESTIVAL_EXP_AC_HEAD*/
                    obj.StaffBenefitProvAcHead = drow["STAFF_BENIFIT_PROV_AC_HEAD"].ToString();
                    obj.MedicalExpAcHead = drow["MEDICAL_EXP_AC_HEAD"].ToString();
                    obj.LeaveEncashExpAcHead = drow["LEAVE_ENCASH_EXP_AC_HEAD"].ToString();
                    obj.FestivalExpAcHead = drow["FESTIVAL_EXP_AC_HEAD"].ToString();

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

        public OutMessage SaveControlTable(ControlTable controlTable)
        {
            string SP = "security_pkg.p_control_table"; ;
            OutMessage oMsg = new OutMessage();

            List<OracleParameter> paramList = PrepareParameterList(controlTable);

            try
            {
                OracleConnection conn = new GetConnection().GetDbConn();
                SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, SP, paramList.ToArray());

                oMsg.OutResultCode = paramList[77].Value.ToString();
                oMsg.OutResultMessage = paramList[78].Value.ToString();

                return oMsg;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
