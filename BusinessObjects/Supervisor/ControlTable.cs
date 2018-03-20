using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Supervisor
{
    public class ControlTable : BusinessObject
    {
        /*CURRENT_FISCAL_YEAR             VARCHAR2(10 BYTE),
  LAST_FISCAL_YEAR                VARCHAR2(10 BYTE),
  PL_ACCOUNT_HEAD                 VARCHAR2(20 BYTE),
  COMPANY_NAME                    VARCHAR2(255 BYTE),
  COMPANY_ADDRESS1                VARCHAR2(255 BYTE),
  COMPANY_ADDRESS2                VARCHAR2(255 BYTE),*/
        public string CurrentFiscalYear { get; set; }
        public string LastFiscalYear { get; set; }
        public string PLAccountHead { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress1 { get; set; }
        public string CompanyAddress2 { get; set; }


        /*
          MAX_PERIOD_ADDITIONAL_LOAN      NUMBER(2),
          BASIC_SALARY_CODE               VARCHAR2(3 BYTE),
          GRADE_SALARY_CODE               VARCHAR2(3 BYTE),
          PF_CODE                         VARCHAR2(3 BYTE),
          OVERTIME_CODE                   VARCHAR2(3 BYTE),
          OVERTIME_ALLOWED                CHAR(1 BYTE),*/
        public Int16 ?MaxPeriodAdditionalLoan { get; set; }
        public string BasicSalaryCode { get; set; }
        public string GradeSalaryCode { get; set; }
        public string PFCode { get; set; }
        public string OvertimeCode { get; set; }
        public string OvertimeAllowed { get; set; }


        /*
  COMPULSORY_COLLECTION_AMT       NUMBER(17,2),
  MANDATORY_DED_TYPE_CODE         VARCHAR2(3 BYTE),
  PF_PERCENTAGE                   NUMBER(6,4),
  CASH_ACCOUNT_CODE               VARCHAR2(20 BYTE),
  PERIOD_TO_TAKE_PAID_AMT_MON     NUMBER(2),
  MISS_MON_TO_TAKE_PAID_AMT       NUMBER(2),*/

        public double? CompulsoryCollectionAmt { get; set; }
        public string MandatoryDedTypeCode { get; set; }
        public double ?PFPercentage { get; set; }
        public string CashAccountCode { get; set; }
        public Int16? PeriodToTakePaidAmtMon { get; set; }
        public Int16? MissMonToTakePaidAmt { get; set; }

        /*
  GENERAL_LOAN_PRODUCT_CODE       VARCHAR2(2 BYTE),
  DEFAULT_CURRENCY_CODE           VARCHAR2(3 BYTE),
  SUB_CATEGORY_NO                 NUMBER(3),
  DONATION_SUB_CATEGORY_NO        NUMBER(3),
  MF_MANDATORY_FUND_ACC_CODE      VARCHAR2(10 BYTE),
  MF_PER_FUND_ACC_CODE            VARCHAR2(10 BYTE),*/
        public string LoanProductCode { get; set; }
        public string DefaultCurrencyCode { get; set; }
        public Int16? SubCategoryNo { get; set; }
        public Int16? DonationSubCategoryNo { get; set; }
        public string MFMandatoryFundAccCode { get; set; }
        public string MFPerFundAccCode { get; set; }


        /*
  CENTER_FUND_ACC_CODE            VARCHAR2(15 BYTE),
  MF_GEN_LOAN_ACC_CODE            VARCHAR2(10 BYTE),
  MF_PENALTY_ACC_CODE             VARCHAR2(10 BYTE),
  MF_ENTERPRISE_ACC_CODE          VARCHAR2(10 BYTE),
  MF_ENTER_INT_ACC_CODE           VARCHAR2(10 BYTE),
  INT_GEN_LOAN_ACC_CODE           VARCHAR2(10 BYTE),*/

        public string CenterFundAccCode { get; set; }
        public string MFGenLoanAccCode { get; set; }
        public string MFPenaltyAccCode { get; set; }
        public string MFEnterpriseAccCode { get; set; }
        public string MFEnterIntAccCode { get; set; }
        public string IntGenLoanAccCode { get; set; }
        /*
  MANDATORY_SAVING_PRODUCT        VARCHAR2(4 BYTE),
  VOLUNTARY_SAVING_PRODUCT        VARCHAR2(4 BYTE),
  MAX_NO_OF_LOAN                  NUMBER(2),
  STAFF_LOAN_PRODUCT_CODE         VARCHAR2(2 BYTE),
  CENTER_SAVING_PRODUCT           VARCHAR2(4 BYTE),
  MANDATORY_ALLOW_YEARS           NUMBER(3),*/
        public string MandatorySavingProduct { get; set; }
        public string VoluntarySavingProduct { get; set; }
        public Int16? MaxNoOfLoan { get; set; }
        public string StaffLoanProductCode { get; set; }
        public string CenterSavingProduct { get; set; }
        public Int16? MandatoryAllowYears { get; set; }



        /*
  GEN_LOAN_PRODUCT_CODE           VARCHAR2(2 BYTE),
  EXPORT_FILE_PATH                VARCHAR2(60 BYTE),
  IMPORT_FILE_PATH                VARCHAR2(60 BYTE),
  INSTALLATION_DATE               DATE,
  IMPORT_LOG_PATH                 VARCHAR2(60 BYTE),
  EXPORT_LOG_PATH                 VARCHAR2(60 BYTE),*/

        public string GenLoanProductCode { get; set; }
        public string ExportFilePath { get; set; }
        public string ImportFilePath { get; set; }
        public string InstallationDate { get; set; }
        public string ImportLogPath { get; set; }
        public string ExportLogpath { get; set; }


        /*
  EARNING_DEDUCTION_CODE          VARCHAR2(3 BYTE),
  MIN_MEDICAL_ALLOWANCE           NUMBER(17,2),
  MEDICAL_ALLOWANCE_CODE          VARCHAR2(3 BYTE),
  BONUS_CODE                      VARCHAR2(3 BYTE),
  BONUS_DAYS                      NUMBER(6,2),
  CIT_CODE                        VARCHAR2(3 BYTE),*/
        public string EarningDeductionCode { get; set; }
        public double? MinMedicalAllowance { get; set; }
        public string MedicalAllowanceCode { get; set; }
        public string BonusCode { get; set; }
        public string BonusDays { get; set; }
        public string CitCode { get; set; }

        /*
  CONTROL_FROM_CDMS               CHAR(1 BYTE),
  BUDGET_CONTROL_Y_N              VARCHAR2(1 BYTE),
  LOCATION_CODE                   VARCHAR2(4 BYTE),
  SALES_LOCATION                  VARCHAR2(4 BYTE),
  SICK_LEAVE_CODE                 VARCHAR2(3 BYTE),
  HOUSE_LEAVE_CODE                VARCHAR2(3 BYTE),*/

        public string ControlFromCDMS { get; set; }
        public string BudgetControlYN { get; set; }
        public string LocationCode { get; set; }
        public string SalesLocation { get; set; }
        public string SickLeaveCode { get; set; }
        public string HouseLeaveCode { get; set; }



        /*
  CASH_BALANCE_GROUP_NO           NUMBER(3),
  FIXED_SAVING_COL_AMT_Y_N        VARCHAR2(1 BYTE) DEFAULT 'Y',
  APPROVAL_RANGE_CONTROL          VARCHAR2(1 BYTE) DEFAULT 'N',
  CURRENT_YEAR                    NUMBER(4),
  MF_MEMBER_TYPE                  VARCHAR2(5 BYTE),
  INV_SUB_CATEGORY_NO             NUMBER(3),*/

        public Int16? CashBalanceGroupNo { get; set; }
        public string FixdSavingColAmtYN { get; set; }
        public string ApprovalRangeControl { get; set; }
        public Int16? CurrentYear { get; set; }
        public string MFMemberType { get; set; }
        public Int16? InvSubCategoryNo { get; set; }


        /*
  MANDATORY_LOAN_PRODUCT          VARCHAR2(3 BYTE),
  WELFARE_SAVING_PRODUCT_CODE     VARCHAR2(4 BYTE),
  PENSION_SAVING_PRODUCT_CODE     VARCHAR2(4 BYTE),
  FESTIVAL_SAVING_PRODUCT_CODE    VARCHAR2(4 BYTE),
  LIFE_PRO_SCHEME_CODE            VARCHAR2(10 BYTE),
  BRANCH_ON_M_W                   CHAR(1 BYTE),*/

        public string MandatoryLoanProduct { get; set; }
        public string WelFareSavingProductCode { get; set; }
        public string PensionSavingProductCode { get; set; }
        public string FestivalSavingProductCode { get; set; }
        public string LifeProSchemeCode { get; set; }
        public string BranchOnMW { get; set; }

        /*
  MEM_PRO_BASE_AMOUNT             NUMBER(10),
  MEM_PRO_REGULAR_AMOUNT          NUMBER(10),
  MID_TERM_INT_FOR_PENSION        NUMBER(5),
  OTHER_INCOME_HEAD               VARCHAR2(20 BYTE),
  INTEREST_EXP_ON_PENSION_HEAD    VARCHAR2(20 BYTE),
  FULL_TERM_INT_FOR_PENSION       VARCHAR2(20 BYTE),*/
        public long? MemProBaseAmount { get; set; }
        public long? MemProRegularAmount { get; set; }
        public long? MidTermIntForPension { get; set; }
        public string OtherIncomeHead { get; set; }
        public string InterestExpOnPensionHead { get; set; }
        public string FullTermIntForPension { get; set; }


        /*
  UNIT_FUND_COLLECTION_AMT        NUMBER(17,2),
  MANDATORY_CENTRAL_CONTROL       CHAR(1 BYTE),
  UNIT_FUND_CENTRAL_CONTROL       CHAR(1 BYTE),
  ADV_REC_ON_CENTER_DATE          CHAR(1 BYTE),
  UNIT_FUND_SAVING_PRODUCT_CODE   VARCHAR2(10 BYTE),
  GENERATE_WELFARE_FUND_AC_AUTO   CHAR(1 BYTE),*/

        public double? UnitFundCollectionAmt { get; set; }
        public string MandatoryCentralControl { get; set; }
        public string UnitFundCentralControl { get; set; }
        public string AdvRecOnCenterDate { get; set; }
        public string UnitFundSavingProductCode { get; set; }
        public string GenerateWelFareFundAcAuto { get; set; }


        /*
  XX_INT_CAL_METHOD               VARCHAR2(5 BYTE),
  ADV_DEDUCTION_ORDER             VARCHAR2(1 BYTE),
  CLIENT_PHOTO_PATH               VARCHAR2(500 BYTE),
  JOINT_CLIENT_PHOTO_PATH         VARCHAR2(500 BYTE),
  NORMAL_SAV_PRODUCT_CODE         VARCHAR2(20 BYTE),
  SIGNATURE2_PATH                 VARCHAR2(500 BYTE),*/

        public string XXIntCalMethod { get; set; }
        public string AdvDeductionOrder { get; set; }
        public string ClientPhotoPath { get; set; }
        public string JointClientPhotoPath { get; set; }
        public string NormalSavProductCode { get; set; }
        public string Signature2Path { get; set; }

        /*
  SIGNATURE1_PATH                 VARCHAR2(500 BYTE),
  OTHER_EXPENSE_HEAD              VARCHAR2(20 BYTE),
  FINGER_PRINT_RIGHT_PATH         VARCHAR2(500 BYTE),
  FINGER_PRINT_LEFT_PATH          VARCHAR2(500 BYTE),
  LOAN_INT_IN_DAYS_OR_FIXED       VARCHAR2(1 BYTE),
  LOAN_INT_CALC_DAYS              NUMBER(10,4),*/

        public string Signature1Path { get; set; }
        public string OtherExpenseHead { get; set; }
        public string FingerPrintRightPath { get; set; }
        public string FingerPrintLeftPath { get; set; }
        public string LoanIntInDaysOrFixed { get; set; }
        public double? LoanIntCalcDays { get; set; }



        /*
  EMPLOYEE_PHOTO_PATH             VARCHAR2(500 BYTE),
  XX_LIVESTOCK_IMG_PATH           VARCHAR2(600 BYTE),
  PENSION_SAVING_PERIOD           NUMBER(10,2),
  NON_TREAT_SAVING_AC_ON_COLLSHT  VARCHAR2(20 BYTE),
  CIB_PATH                        VARCHAR2(60 BYTE),
  CIB_DPI_NUM                     VARCHAR2(20 BYTE),*/

        public string EmployeePhotoPath { get; set; }
        public string XXLiveStockImgPath { get; set; }
        public double? PensionSavingPeriod { get; set; }
        public string NonTreatSavingAcOnCollsht { get; set; }
        public string CIBPath { get; set; }
        public string CIBDPINum { get; set; }


        /*
  CIB_CONSUMER_IIF_VERSION_ID     VARCHAR2(10 BYTE),
  CIB_MEMBER_IIF_VERSION_ID       VARCHAR2(10 BYTE),
  CIB_CONSUMER_NATURE_OF_DATA     VARCHAR2(10 BYTE),
  CIB_MEMBER_NATURE_OF_DATA       VARCHAR2(10 BYTE),
  INT_CALC_ON_COLLECTION_DATE     VARCHAR2(5 BYTE),
  INCHARGE_SHIP_CODE              VARCHAR2(10 BYTE),*/


        public string CIBConsumerIIFVersionId { get; set; }
        public string CIBMemberIIFVersionId { get; set; }
        public string CIBConsumerNatureOfData { get; set; }
        public string CIBMemberNatureOfData { get; set; }
        public string IntCalcOnCollectionDate { get; set; }
        public string InchargeShipCode { get; set; }

        /*
  CIT_FUND_CODE                   VARCHAR2(10 BYTE),
  ACCOUNTANT_EARNING_CODE         VARCHAR2(10 BYTE),
  ACCOUNTANT_EARNING_AMT          NUMBER(34,2),
  ACCOUNTANT_DESIGNATION_CODE     VARCHAR2(10 BYTE),
  DURGAM_EARNING_CODE_A           VARCHAR2(10 BYTE),
  DURGAM_EARNING_CODE_AA          VARCHAR2(10 BYTE),*/

        public string CITFundCode { get; set; }
        public string AccountantEarningCode { get; set; }
        public double? AccountEarningAmt { get; set; }
        public string AccountantDesignationCode { get; set; }
        public string DurgamEarningCodeA { get; set; }
        public string DurgamEarningCodeAA { get; set; }


        /*
  HOUSE_RENT_ALLOWANCE_CODE       VARCHAR2(10 BYTE),
  CAPITAL_HOUSE_RENT_PC           NUMBER,
  UNIFORM_EXPENSES_CODE           VARCHAR2(10 BYTE),
  WARM_UNIFORM_EXPENSES_CODE      VARCHAR2(10 BYTE),
  REMOTE_ALLOWANCE_CODE           VARCHAR2(10 BYTE),
  PAYROLL_OFFICE_CODE             VARCHAR2(20 BYTE),
  STAFF_BENIFIT_PROV_AC_HEAD      VARCHAR2(20 BYTE),
  MEDICAL_EXP_AC_HEAD             VARCHAR2(20 BYTE),
  LEAVE_ENCASH_EXP_AC_HEAD        VARCHAR2(20 BYTE),
  FESTIVAL_EXP_AC_HEAD            VARCHAR2(20 BYTE)*/

        public string HouseRentAllowanceCode { get; set; }
        public double? CapitalHouseRentPC { get; set; }
        public string UniformExpensesCode { get; set; }
        public string WarmUniformExpensesCode { get; set; }
        public string RemoteAllowanceCode { get; set; }
        public string PayrollOfficeCode { get; set; }
        public string StaffBenefitProvAcHead { get; set; }
        public string MedicalExpAcHead { get; set; }
        public string LeaveEncashExpAcHead { get; set; }
        public string FestivalExpAcHead { get; set; }

    }
}
