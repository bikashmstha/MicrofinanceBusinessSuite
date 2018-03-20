using System;
using System.Collections.Generic;
using System.Text;
using DataObjects.Security;

using DataObjects.AdoNet.Oracle.Security;
using DataObjects.AdoNet.Oracle.Maintenance;
using DataObjects.Interfaces.Maintenance;
using DataObjects.Interfaces.Supervisor;
using DataObjects.AdoNet.Oracle.Supervisor;
using DataObjects.Interfaces.GeneralMasterParameters;
using DataObjects.AdoNet.Oracle.GeneralMasterParameters;
using DataObjects.Interfaces.Finance;
using DataObjects.AdoNet.Oracle.Finance;
using DataObjects.Interfaces.HumanResource;
using DataObjects.AdoNet.Oracle.HumanResource;
using DataObjects.Interfaces.Common;
using DataObjects.AdoNet.Oracle.Common;
using DataObjects.Interfaces.Inventory;
using DataObjects.AdoNet.Oracle.Inventory;


namespace DataObjects.AdoNet.Oracle
{
    /// <summary>
    /// Oracle specific factory that creates Oracle specific data access objects.
    /// 
    /// GoF Design Pattern: Factory.
    /// </summary>
    public class OracleDaoFactory : DaoFactory
    {

        #region COMMON
        public override IDateDao DateDao
        {
            get { return new OracleDateDao(); }
        }
        public override IDistrictDao DistrictDao
        {
            get { return new OracleDistrictDao(); }
        }
        public override IVdcDao VdcDao
        {
            get { return new OracleVdcDao(); }
        }
        public override ICountryDao CountryDao
        {
            get { return new OracleCountryDao(); }
        }

        public override IFiscalYearDao FiscalYearDao
        {
            get { return new OracleFiscalYearDao(); }
        }
        #endregion

        #region SECURITY



        public override ILoginDao LoginDao
        {
            get { return new OracleLoginDao(); }
        }
        public override GenericUserDao UserDao
        {
            get { return new OracleUserDao(); }
        }

        public override IRoleDao RoleDao
        {
            get { return new OracleRoleDao(); }
        }

        #endregion

        #region GENERAL MASTER PARAMETERS
        //HOLIDAY
        public override IHolidayDao HolidayDao
        {
            get
            {
                return new OracleHolidayDao();
            }
            
        }
        public override IOfficeWiseHolidayDao OfficeWiseHolidayDao
        {
            get { return new OracleOfficeWiseHolidayDao(); }
        }
        //DEPARTMENT
        public override IDepartmentDao DepartmentDao
        {
            get { return new OracleDepartmentDao(); }
        }
        public override IDepartmentMapDao DepartmentMapDao
        {
            get { return new OracleDepartmentMapDao(); }
        }
        //OFFICE
        public override IOfficeDao OfficeDao
        {
            get { return new OracleOfficeDao(); }
        }
        public override IOfficeTypeDao OfficeTypeDao
        {
            get { return new OracleOfficeTypeDao(); }
        }
        public override IOfficeMapDao OfficeMapDao
        {
            get { return new OracleOfficeMapDao(); }
        }
        public override IVdcCoverageByOfficeDao VdcCoverageByOfficeDao
        {
            get { return new OracleVdcCoverageByOfficeDao(); }
        }

        //MENU
        public override IMenuEntryDao MenuEntryDao
        {
            get { return new OracleMenuEntryDao(); }
        }
        public override IModuleDao ModuleDao
        {
            get { return new OracleModuleDao(); }
        }
        public override ITabDao TabDao
        {
            get { return new OracleTabDao(); }
        }
        public override IReportDao ReportDao
        {
            get { return new OracleReportDao(); }
        }

        //GROUP
        public override IGroupDao GroupDao
        {
            get { return new OracleGroupDao(); }
        }

        //CONTROL REFERENCE VALUES
        public override IMsControlValuesDao MsControlValuesDao
        {
            get { return new OracleMsControlValuesDao(); }
        }

        public override IMsReferenceCodeMasterDao MsReferenceCodeMasterDao
        {
            get { return new OracleMsReferenceCodeMasterDao(); }
        }

        public override IMsReferenceCodeDetailsDao MsReferenceCodeDetailsDao
        {
            get { return new OracleMsReferenceCodeDetailsDao(); }
        }


        //CASTE / ETHINCITY
        public override ICasteDetailDao CasteDetailDao
        {
            get { return new OracleCasteDetailDao(); }
        }
        public override IEducationDao EducationDao
        {
            get { return new OracleEducationDao(); }
        }
        public override IOccupationDao OccupationDao
        {
            get { return new OracleOccupationDao(); }
        }
        public override IEthnicityInformationDao EthnicityInformationDao
        {
            get { return new OracleEthnicityInformationDao(); }
        }
        public override IEthnicityCasteInformationDao EthnicityCasteInformationDao
        {
            get { return new OracleEthnicityCasteInformationDao(); }
        }
        public override IReligionDao ReligionDao
        {
            get { return new OracleReligionDao(); }
        }
        #endregion

        #region "GENERAL DEFINITIONS"
        public override INarrationDao NarrationDao
        {
            get { return new OracleNarrationDao(); }
        }
        public override INepaliDateConversionDao NepaliDateConversionDao
        {
            get { return new OracleNepaliDateConversionDao(); }
        }

        public override INepaliFiscalYearDao NepaliFiscalYearDao
        {
            get { return new OracleNepaliFiscalYearDao(); }
        }

        public override IInstallmentPeriodDao InstallmentPeriodDao
        {
            get { return new OracleInstallmentPeriodDao(); }
        }

        public override ILoanInstallmentPeriodMapDao LoanInstallmentPeriodMapDao
        {
            get { return  new OracleLoanInstallmentPeriodMapDao(); }
        }

        public override ILoanPeriodDao LoanPeriodDao
        {
            get { return new OracleLoanPeriodDao(); }
        }

        public override ILoanProductPeriodMapDao LoanProductPeriodMapDao
        {
            get { return  new OracleLoanProductPeriodMapDao(); }
        }
        public override IGeneralDefinitionsUtilityDao GeneralDefinitionsUtilityDao
        {
            get
            {
                return  new OracleGeneralDefinitionsUtilityDao();
            }
        }
        #endregion


        #region "SUPERVISOR"
        public override IControlTableDao ControlTableDao
        {
            get { return new OracleControlTableDao(); }
        }
        
        public override IOfficeDepartmentDao OfficeDepartmentDao
        {
            get { return new OracleOfficeDepartmentDao(); }
        }
        public override IEmployeeDao EmployeeDao
        {
            get { return new OracleEmployeeDao(); }
        }
        #endregion

        #region "ACCOUNT CONTROL"
        public override IAccountCategoryDao AccountCategoryDao
        {
            get { return new OracleAccountCategoryDao(); }
        }
        public override IAccountSubCategoryDao AccountSubCategoryDao
        {
            get { return new OracleAccountSubCategoryDao(); }
        }
        public override IGLVoucherTypeDao GLVoucherTypeDao
        {
            get { return new OracleGlTypeDao(); }
        }
        public override IVoucherApprovalSecurityDao VoucherApprovalSecurityDao
        {
            get { return new OracleVoucherApprovalSecurityDao(); }
        }
        #endregion

        #region "FINANCE-MAINTENANCE"
        //MAINTENANCE
        public override ICompulsoryAccountsEntryDao CompulsoryAccountsEntryDao
        {
            get { return new OracleCompulsoryAccountsEntryDao(); }
        }
        public override ILoanDeductionTypeDao LoanDeductionTypeDao
        {
            get { return new OracleLoanDeductionTypeDao(); }
        }
        public override IMainInterestSchemeDao MainInterestSchemeDao
        {
            get { return new OracleMainInterestSchemeDao(); }
        }
        public override IAccountHeadEntryDao AccountHeadEntryDao
        {
            get { return new OracleAccountHeadEntryDao(); }
        }

        public override ISavingMidTermInterestDao SavingMidTermInterest
        {
            get { return  new OracleSavingMidTermInterestDao(); }
        }

        public override IABBSChargeDao ABBSChargeDao
        {
            get { return new OracleABBSChargeDao(); }
        }
        public override ISectorDao SectorDao
        {
            get { return new OracleSectorDao(); }
        }
        public override ISubSectorDao SubSectorDao
        {
            get { return new OracleSubSectorDao(); }
        }
        
        public override ILoanPurposeProductDetailDao LoanPurposeProductDetailDao
        {
            get { return new OracleLoanPurposeProductDetailDao(); }
        }
        public override ICenterDao CenterDao
        {
            get { return new OracleCenterDao(); }
        }
        public override ICenterLovDao CenterLovDao
        {
            get { return new OracleCenterLovDao(); }
        }
        public override IMemberDao MemberDao
        {
            get { return new OracleMemberDao(); }
        }
        public override ILoanSectorDao LoanSectorDao
        {
            get { return new OracleLoanSectorDao(); }
        }

        public override ILoanSubSectorDao LoanSubSectorDao
        {
            get { return new OracleLoanSubSectorDao(); }
        }
        public override ILoanPurposeDao LoanPurposeDao
        {
            get { return new OracleLoanPurposeDao(); }
        }
        public override ILoanPurposeProductsDao LoanPurposeProductsDao
        {
            get { return new OracleLoanPurposeProductsDao(); }
        }
        public override IInterestSchemeDao InterestSchemeDao
        {
            get { return new OracleInterestSchemeDao(); }
        }
        public override IInterestSchemeMasterDao InterestSchemeMasterDao
        {
            get { return new OracleInterestSchemeMasterDao(); }
        }
        public override IInterestSchemeDetailDao InterestSchemeDetailDao
        {
            get { return new OracleInterestSchemeDetailDao(); }
        }
        public override ILoanProductAccountHeadDao LoanProductAccountHeadDao
        {
            get { return new OracleLoanProductAccountHeadDao(); }
        }
        public override ISavingTypeDao SavingTypeDao
        {
            get { return new OracleSavingTypeDao(); }
        }
        public override ILoanProductDetailDao LoanProductDetailDao
        {
            get { return new OracleLoanProductDetailDao(); }
        }
        public override ILoanDeductionDetailDao LoanDeductionDetailDao
        {
            get { return new OracleLoanDeductionDetailDao(); }
        }
        public override ISavingProductAccountHeadDao SavingProductAccountHeadDao
        {
            get { return new OracleSavingProductAccountHeadDao(); }
        }
        public override ISavingProductDetailDao SavingProductDetailDao
        {
            get { return new OracleSavingProductDetailDao(); }
        }
        #endregion

        #region "FINANCE-TRANSACTION"
        //MEMBER TRANSACTION
        public override ITransferWithinCenterDao TransferWithinCenterDao
        {
            get { return new OracleTransferWithinCenterDao(); }
        }
        public override ITransferCenterToAnotherCenterDao TransferCenterToAnotherCenterDao
        {
            get { return new OracleTransferCenterToAnotherCenterDao(); }
        }
        public override IDropOutReasonDao DropOutReasonDao
        {
            get
            {
                return new OracleDropOutReasonsDao();
            }
            
        }
        public override IMemberCancellationRestoreDao MemberCancellationRestoreDao
        {
            get { return new OracleMemberCancellationRestoreDao(); }
        }
        public override IMemberForCancellationDao MemberForCancellationDao
        {
            get { return new OracleMemberForCancellationDao(); }
        }

        //COLLECTION SHEET TRANSACTION
        public override ICenterDetailsFromCodeDao CenterDetailsFromCodeDao
        {
            get { return new OracleCenterDetailsFromCodeDao(); }
        }
        public override IOfflineCollectionCenterDao OfflineCollectionCenterDao
        {
            get { return new OracleOfflineCollectionCenterDao(); }
        }
        public override IOnlineCollectionCenterDao OnlineCollectionCenterDao
        {
            get { return new OracleOnlineCollectionCenterDao(); }
        }
        public override IGenerateSavingCollectionDao GenerateSavingCollectionDao
        {
            get { return new OracleGenerateSavingCollectionDao(); }
        }
        public override ICollectionAdjustDao CollectionAdjustDao
        {
            get { return new OracleCollectionAdjustDao(); }
        }
        public override ISavingCollectionSheetDao SavingCollectionSheetDao
        {
            get { return new OracleSavingCollectionSheetDao(); }
        }
        public override ILoanCollectionDetailDao LoanCollectionDetailDao
        {
            get { return new OracleLoanCollectionDetailDao(); }
        }
        public override IEmployeeCenterCollectionDao EmployeeCenterCollectionDao
        {
            get { return new OracleEmployeeCenterCollectionDao(); }
        }
        public override IUnapprovedCollectionDao UnapprovedCollectionDao
        {
            get { return new OracleUnapprovedCollectionDao(); }
        }
        public override ICollectionSheetMasterDao CollectionSheetMasterDao
        {
            get { return new OracleCollectionSheetMasterDao(); }
        }

        //SAVING TRANSACTION
        public override ISavingProductDao SavingProductDao
        {
            get { return new OracleSavingProductDao(); }
        }
        public override IClientSavingAccountDao ClientSavingAccountDao
        {
            get { return new OracleClientSavingAccountDao(); }
        }
        public override IAccountOpenDetailDao AccountOpenDetailDao
        {
            get { return new OracleAccountOpenDetailDao(); }
        }
        public override IProductForDepositDao ProductForDepositDao
        {
            get { return new OracleProductForDepositDao(); }
        }
        public override IAccountForDepositDao AccountForDepositDao
        {
            get { return new OracleAccountForDepositDao(); }
        }
        public override IMfDepositDetailDao MfDepositDetailDao
        {
            get { return new OracleMfDepositDetailDao(); }
        }
        public override IMfSavingDepositDao MfSavingDepositDao
        {
            get { return new OracleMfSavingDepositDao(); }
        }
        public override IMfWithdrawlDetailDao MfWithdrawlDetailDao
        {
            get { return new OracleMfWithdrawlDetailDao(); }
        }
        public override IProductForWithdrawlDao ProductForWithdrawlDao
        {
            get { return new OracleProductForWithdrawlDao(); }
        }
        public override IAccountForWithdrawlDao AccountForWithdrawlDao
        {
            get { return new OracleAccountForWithdrawlDao(); }
        }
        public override IMfSavingWithdrawDao MfSavingWithdrawDao
        {
            get { return new OracleMfSavingWithdrawDao(); }
        }

        public override IProductForAccountCloseDao ProductForAccountCloseDao
        {
            get { return new OracleProductForAccountCloseDao(); }
        }

        public override IAccountForClosingDao AccountForClosingDao
        {
            get { return new OracleAccountForClosingDao(); }
        }

        public override IAccountCloseDetailDao AccountCloseDetailDao
        {
            get { return new OracleAccountCloseDetailDao(); }
        }
        public override ISavingAccountClosureDao SavingAccountClosureDao
        {
            get { return new OracleSavingAccountClosureDao(); }
        }
        public override IMemberAccountOpenDao MemberAccountOpenDao
        {
            get { return new OracleMemberAccountOpenDao(); }
        }

        public override IMemberForChequeDao MemberForChequeDao
        {
            get { return new OracleMemberForChequeDao(); }
        }
        public override IChequeGenerateDetailDao ChequeGenerateDetailDao
        {
            get { return new OracleChequeGenerateDetailDao(); }
        }
        public override IGenerateChequeSequenceDao GenerateChequeSequenceDao
        {
            get { return new OracleGenerateChequeSequenceDao(); }
        }

        //LOAN TRANSACTION
        public override ILoanMemberDao LoanMemberDao
        {
            get { return new OracleLoanMemberDao(); }
        }
        public override ILoanProductDao LoanProductDao
        {
            get { return new OracleLoanProductDao(); }
        }
        public override IMfLoanPurposeDao MfLoanPurposeDao
        {
            get { return new OracleMfLoanPurposeDao(); }
        }
        public override IMfAdjustSavingDao MfAdjustSavingDao
        {
            get { return new OracleMfAdjustSavingDao(); }
        }
        public override IMfLoanSearchDao MfLoanSearchDao
        {
            get { return new OracleMfLoanSearchDao(); }
        }
        public override IMfLoanDetailDao MfLoanDetailDao
        {
            get { return new OracleMfLoanDetailDao(); }
        }
        public override IMfLoanDisbursementDao MfLoanDisbursementDao
        {
            get { return new OracleMfLoanDisbursementDao(); }
        }
        public override IMfLoanRepaymentDao MfLoanRepaymentDao
        {
            get { return new OracleMfLoanRepaymentDao(); }
        }
        public override IMfRepayAdjustSavingDao MfRepayAdjustSavingDao
        {
            get { return new OracleMfRepayAdjustSavingDao(); }
        }
        public override IMfRepaySearchLoanDao MfRepaySearchLoanDao
        {
            get { return new OracleMfRepaySearchLoanDao(); }
        }
        public override IMfRepayDetailDao MfRepayDetailDao
        {
            get { return new OracleMfRepayDetailDao(); }
        }
        public override IMeLoanDisbursementDao MeLoanDisbursementDao
        {
            get { return new OracleMeLoanDisbursementDao(); }
        }
        public override IMeLoanProductDao MeLoanProductDao
        {
            get { return new OracleMeLoanProductDao(); }
        }
        public override IFundingAgencyDao FundingAgencyDao
        {
            get { return new OracleFundingAgencyDao(); }
        }
        public override ILoanCollateralDao LoanCollateralDao
        {
            get { return new OracleLoanCollateralDao(); }
        }
        public override IMeLoanSearchDao MeLoanSearchDao
        {
            get { return new OracleMeLoanSearchDao(); }
        }
        public override IMeLoanDetailDao MeLoanDetailDao
        {
            get { return new OracleMeLoanDetailDao(); }
        }
        public override IMfAdditionalLoanDao MfAdditionalLoanDao
        {
            get { return new OracleMfAdditionalLoanDao(); }
        }
        public override IMfAdditionalLoanDetailDao MfAdditionalLoanDetailDao
        {
            get { return new OracleMfAdditionalLoanDetailDao(); }
        }
        public override IMfAdditionalLoanDisbursementDao MfAdditionalLoanDisbursementDao
        {
            get { return new OracleMfAdditionalLoanDisbursementDao(); }
        }
        public override IMeLoanRepayDao MeLoanRepayDao
        {
            get { return new OracleMeLoanRepayDao(); }
        }
        public override IMeLoanRepayDetailDao MeLoanRepayDetailDao
        {
            get { return new OracleMeLoanRepayDetailDao(); }
        }
        public override IMeAdditionalLoanDao MeAdditionalLoanDao
        {
            get { return new OracleMeAdditionalLoanDao(); }
        }
        public override IMeAdditionalLoanDetailDao MeAdditionalLoanDetailDao
        {
            get { return new OracleMeAdditionalLoanDetailDao(); }
        }
        public override IMeAdditionalLoanDisbursementDao MeAdditionalLoanDisbursementDao
        {
            get { return new OracleMeAdditionalLoanDisbursementDao(); }
        }
        public override ILasMemberDao LasMemberDao
        {
            get { return new OracleLasMemberDao(); }
        }
        public override ILoanAgainstSavingDisbursementDao LoanAgainstSavingDisbursementDao
        {
            get { return new OracleLoanAgainstSavingDisbursementDao(); }
        }
        public override ILoanUtilizationEntryDao LoanUtilizationEntryDao
        {
            get { return new OracleLoanUtilizationEntryDao(); }
        }
        public override IAdjustLoanIntPriPenNewDao AdjustLoanIntPriPenNewDao
        {
            get { return new OracleAdjustLoanIntPriPenNewDao(); }
        }
        public override ILoanDao LoanDao
        {
            get { return new OracleLoanDao(); }
        }
        public override IMfSavingDepositEditDao MfSavingDepositEditDao
        {
            get { return new OracleMfSavingDepositEditDao(); }
        }
        public override ILasProductDao LasProductDao
        {
            get { return new OracleLasProductDao(); }
        }
        public override ILoanLasSavingProductDao LoanLasSavingProductDao
        {
            get { return new OracleLoanLasSavingProductDao(); }
        }
        public override ILasLoanSearchDao LasLoanSearchDao
        {
            get { return new OracleLasLoanSearchDao(); }
        }
        public override ILasLoanDetailDao LasLoanDetailDao
        {
            get { return new OracleLasLoanDetailDao(); }
        }
        public override ILnUtilizationLoanDao LnUtilizationLoanDao
        {
            get { return new OracleLnUtilizationLoanDao(); }
        }
        public override ILnUtilizationDetailDao LnUtilizationDetailDao
        {
            get { return new OracleLnUtilizationDetailDao(); }
        }
        public override ILoanRepayAdjustLoanDao LoanRepayAdjustLoanDao
        {
            get { return new OracleLoanRepayAdjustLoanDao(); }
        }
        public override ILoanProductDeductionDao LoanProductDeductionDao
        {
            get { return new OracleLoanProductDeductionDao(); }
        }


        //EDIT TRANSACTION
        public override ILoanRepayAdjustRepayDao LoanRepayAdjustRepayDao
        {
            get { return new OracleLoanRepayAdjustRepayDao(); }
        }

        public override ICalLoanBalanceStatusDao CalLoanBalanceStatusDao
        {
            get { return new OracleCalLoanBalanceStatusDao(); }
        }
        public override ILoanAdjustLoanDao LoanAdjustLoanDao
        {
            get { return new OracleLoanAdjustLoanDao(); }
        }
        public override ILoanTransferFromCenterDao LoanTransferFromCenterDao
        {
            get { return new OracleLoanTransferFromCenterDao(); }
        }
        public override ILoanTransferFromClientDao LoanTransferFromClientDao
        {
            get { return new OracleLoanTransferFromClientDao(); }
        }
        public override ILoanTransferProductDao LoanTransferProductDao
        {
            get { return new OracleLoanTransferProductDao(); }
        }
        public override ILoanTransferFromLoanDao LoanTransferFromLoanDao
        {
            get { return new OracleLoanTransferFromLoanDao(); }
        }
        public override ITransferLoanAccountDao TransferLoanAccountDao
        {
            get { return new OracleTransferLoanAccountDao(); }
        }
        public override ISavingTransferFromCenterDao SavingTransferFromCenterDao
        {
            get { return new OracleSavingTransferFromCenterDao(); }
        }
        public override ISavingTransferFromClientDao SavingTransferFromClientDao
        {
            get { return new OracleSavingTransferFromClientDao(); }
        }
        public override ISavingTransferFromAccountDao SavingTransferFromAccountDao
        {
            get { return new OracleSavingTransferFromAccountDao(); }
        }
        public override ISavingTransferProcDao SavingTransferProcDao
        {
            get { return new OracleSavingTransferProcDao(); }
        }
        public override ITransferSavingAccountDao TransferSavingAccountDao
        {
            get { return new OracleTransferSavingAccountDao(); }
        }
        public override IPubSavingProductDao PubSavingProductDao
        {
            get { return new OraclePubSavingProductDao(); }
        }
        public override IAdjPubSavingAccountDao AdjPubSavingAccountDao
        {
            get { return new OracleAdjPubSavingAccountDao(); }
        }
        public override IPubSavingAccountSearchDao PubSavingAccountSearchDao
        {
            get { return new OraclePubSavingAccountSearchDao(); }
        }
        public override IPubSavingDepositDetailDao PubSavingDepositDetailDao
        {
            get { return new OraclePubSavingDepositDetailDao(); }
        }
        public override IPublicSavingDepositDao PublicSavingDepositDao
        {
            get { return new OraclePublicSavingDepositDao(); }
        }
        public override IPublicSavingWithdrawDao PublicSavingWithdrawDao
        {
            get { return new OraclePublicSavingWithdrawDao(); }
        }
        public override IPublicSavingWithdrawProductDao PublicSavingWithdrawProductDao
        {
            get { return new OraclePublicSavingWithdrawProductDao(); }
        }
        public override IPublicSavingWithdrawDetailDao PublicSavingWithdrawDetailDao
        {
            get { return new OraclePublicSavingWithdrawDetailDao(); }
        }
        public override IAdjustmentaccountforwithdrawDao AdjustmentaccountforwithdrawDao
        {
            get { return new OracleAdjustmentaccountforwithdrawDao(); }
        }
        public override ILoanInformationDao LoanInformationDao
        {
            get { return new OracleLoanInformationDao(); }
        }

        #endregion


        #region "FINANCE-TRANSACTION-II"
        //PUBLIC SAVING TRANSACTION
        public override IPublicClientDao PublicClientDao
        {
            get { return new OraclePublicClientDao(); }
        }
        public override IPublicClientDetailDao PublicClientDetailDao
        {
            get { return new OraclePublicClientDetailDao(); }
        }
        public override IPublicMemberDao PublicMemberDao
        {
            get { return new OraclePublicMemberDao(); }
        }
        public override IPublicReferenceAccountDao PublicReferenceAccountDao
        {
            get { return new OraclePublicReferenceAccountDao(); }
        }
        public override IPublicAccountDetailDao PublicAccountDetailDao
        {
            get { return new OraclePublicAccountDetailDao(); }
        }
        public override IPublicSavingAccountOpenDao PublicSavingAccountOpenDao
        {
            get { return new OraclePublicSavingAccountOpenDao(); }
        }
        public override IPublicSavingDepositAccountDao PublicSavingDepositAccountDao
        {
            get { return new OraclePublicSavingDepositAccountDao(); }
        }
        public override IPublicAdjustmentdepositaccountDao PublicAdjustmentdepositaccountDao
        {
            get { return new OraclePublicAdjustmentdepositaccountDao(); }
        }
        public override IPublicAccountChequeDao PublicAccountChequeDao
        {
            get { return new OraclePublicAccountChequeDao(); }
        }
        public override IPublicWithdrawWithAccountDao PublicWithdrawWithAccountDao
        {
            get { return new OraclePublicWithdrawWithAccountDao(); }
        }
        public override IPublicAccountCloseProductDao PublicAccountCloseProductDao
        {
            get { return new OraclePublicAccountCloseProductDao(); }
        }
        public override IPublicAccountCloseAccountDao PublicAccountCloseAccountDao
        {
            get { return new OraclePublicAccountCloseAccountDao(); }
        }
        public override IQueryOnSavingAccountCloseDao QueryOnSavingAccountCloseDao
        {
            get { return new OracleQueryOnSavingAccountCloseDao(); }
        }
        public override IPublicAccountCloseDetailDao PublicAccountCloseDetailDao
        {
            get { return new OraclePublicAccountCloseDetailDao(); }
        }
        public override IPublicSavingAccountClosureDao PublicSavingAccountClosureDao
        {
            get { return new OraclePublicSavingAccountClosureDao(); }
        }
        public override IPublicAccountChequeAccountDao PublicAccountChequeAccountDao
        {
            get { return new OraclePublicAccountChequeAccountDao(); }
        }
        public override IChequePrintDao ChequePrintDao
        {
            get { return new OracleChequePrintDao(); }
        }
        public override IGroupBasedMemberDao GroupBasedMemberDao
        {
            get { return new OracleGroupBasedMemberDao(); }
        }

        //STAFF LOAN TRANSACTION
        public override IEmployeeKycEmployeeDao EmployeeKycEmployeeDao
        {
            get { return new OracleEmployeeKycEmployeeDao(); }
        }
        public override IEmployeeKycClientDao EmployeeKycClientDao
        {
            get { return new OracleEmployeeKycClientDao(); }
        }
        public override IEmployeeKycDetailDao EmployeeKycDetailDao
        {
            get { return new OracleEmployeeKycDetailDao(); }
        }
        public override IEmployeeKycInfoDao EmployeeKycInfoDao
        {
            get { return new OracleEmployeeKycInfoDao(); }
        }
        public override IStaffLoanDisbursementClientDao StaffLoanDisbursementClientDao
        {
            get { return new OracleStaffLoanDisbursementClientDao(); }
        }
        public override IStaffLoanDisbursementProductDao StaffLoanDisbursementProductDao
        {
            get { return new OracleStaffLoanDisbursementProductDao(); }
        }
        public override IStaffLoanDisbursementLoanDao StaffLoanDisbursementLoanDao
        {
            get { return new OracleStaffLoanDisbursementLoanDao(); }
        }
        public override IStaffLoanDisbursementDetailDao StaffLoanDisbursementDetailDao
        {
            get { return new OracleStaffLoanDisbursementDetailDao(); }
        }
        public override IStaffLoanDisbursementDao StaffLoanDisbursementDao
        {
            get { return new OracleStaffLoanDisbursementDao(); }
        }
        public override IStaffLoanDisbursementOpeningDao StaffLoanDisbursementOpeningDao
        {
            get { return new OracleStaffLoanDisbursementOpeningDao(); }
        }
        public override IStaffLoanRepayLoanDao StaffLoanRepayLoanDao
        {
            get { return new OracleStaffLoanRepayLoanDao(); }
        }
        public override IStaffLoanRepayAdjustmentSavingDao StaffLoanRepayAdjustmentSavingDao
        {
            get { return new OracleStaffLoanRepayAdjustmentSavingDao(); }
        }
        public override IStaffLoanAdjustmentDetailDao StaffLoanAdjustmentDetailDao
        {
            get { return new OracleStaffLoanAdjustmentDetailDao(); }
        }
        public override IStaffLoanRepaymentDao StaffLoanRepaymentDao
        {
            get { return new OracleStaffLoanRepaymentDao(); }
        }
        public override IStaffLoanRepayDetailDao StaffLoanRepayDetailDao
        {
            get { return new OracleStaffLoanRepayDetailDao(); }
        }
        public override IStaffAdditionalLoanDisbursementDao StaffAdditionalLoanDisbursementDao
        {
            get { return new OracleStaffAdditionalLoanDisbursementDao(); }
        }
        public override IStaffLoanAdditionalLoanDao StaffLoanAdditionalLoanDao
        {
            get { return new OracleStaffLoanAdditionalLoanDao(); }
        }
        public override IStaffLoanAdditionalScrLoanDao StaffLoanAdditionalScrLoanDao
        {
            get { return new OracleStaffLoanAdditionalScrLoanDao(); }
        }
        #endregion

        #region "TRANSACtION- ACCOUNT TRANSACTION"
        public override IContraBankAccountDao ContraBankAccountDao
        {
            get { return new OracleContraBankAccountDao(); }
        }
        public override IParticularsDao ParticularsDao
        {
            get { return new OracleParticularsDao(); }
        }
        public override IVoucherAccountDao VoucherAccountDao
        {
            get { return new OracleVoucherAccountDao(); }
        }
        public override IReceiptSearchVoucherDao ReceiptSearchVoucherDao
        {
            get { return new OracleReceiptSearchVoucherDao(); }
        }
        public override IReceiptVoucherMasterDetailDao ReceiptVoucherMasterDetailDao
        {
            get { return new OracleReceiptVoucherMasterDetailDao(); }
        }
        public override IReceiptVoucherDetailDetailDao ReceiptVoucherDetailDetailDao
        {
            get { return new OracleReceiptVoucherDetailDetailDao(); }
        }
        public override IPaymentSearchVoucherDao PaymentSearchVoucherDao
        {
            get { return new OraclePaymentSearchVoucherDao(); }
        }
        public override IBudgetLimitAmtDao BudgetLimitAmtDao
        {
            get { return new OracleBudgetLimitAmtDao(); }
        }
        public override IPaymentVoucherMasterDetailDao PaymentVoucherMasterDetailDao
        {
            get { return new OraclePaymentVoucherMasterDetailDao(); }
        }
        public override IPaymentVoucherDetailDetailDao PaymentVoucherDetailDetailDao
        {
            get { return new OraclePaymentVoucherDetailDetailDao(); }
        }
        public override IJvSearchVoucherDao JvSearchVoucherDao
        {
            get { return new OracleJvSearchVoucherDao(); }
        }
        public override IJvMasterDetailDao JvMasterDetailDao
        {
            get { return new OracleJvMasterDetailDao(); }
        }
        public override IJvDtlDetailDao JvDtlDetailDao
        {
            get { return new OracleJvDtlDetailDao(); }
        }
        public override IGlTransactionMasterDao GlTransactionMasterDao
        {
            get { return new OracleGlTransactionMasterDao(); }
        }
        public override IGlTransactionDetailDao GlTransactionDetailDao
        {
            get { return new OracleGlTransactionDetailDao(); }
        }
        public override IReverseVoucherDao ReverseVoucherDao
        {
            get { return new OracleReverseVoucherDao(); }
        }
        public override IReverseVoucherMasterDetailDao ReverseVoucherMasterDetailDao
        {
            get { return new OracleReverseVoucherMasterDetailDao(); }
        }
        public override IReverseVoucherDetailDetailDao ReverseVoucherDetailDetailDao
        {
            get { return new OracleReverseVoucherDetailDetailDao(); }
        }
        public override IVoucherApprovalMasterDao VoucherApprovalMasterDao
        {
            get { return new OracleVoucherApprovalMasterDao(); }
        }
        public override IVoucherApprovalDetailDao VoucherApprovalDetailDao
        {
            get { return new OracleVoucherApprovalDetailDao(); }
        }
        public override IApprovedGlTransactionDao ApprovedGlTransactionDao
        {
            get { return new OracleApprovedGlTransactionDao(); }
        }
        public override IRegenerateFiscalYearClosingDao RegenerateFiscalYearClosingDao
        {
            get { return new OracleRegenerateFiscalYearClosingDao(); }
        }
        public override IBudgetAllocationAccountDao BudgetAllocationAccountDao
        {
            get { return new OracleBudgetAllocationAccountDao(); }
        }
        public override IBudgetAllocationDetailDetailDao BudgetAllocationDetailDetailDao
        {
            get { return new OracleBudgetAllocationDetailDetailDao(); }
        }
        public override IBudgetAllocationShareDetailDao BudgetAllocationShareDetailDao
        {
            get { return new OracleBudgetAllocationShareDetailDao(); }
        }
        public override IBudgetAllocationMasterDao BudgetAllocationMasterDao
        {
            get { return new OracleBudgetAllocationMasterDao(); }
        }
        public override IBudgetAllocationDetailDao BudgetAllocationDetailDao
        {
            get { return new OracleBudgetAllocationDetailDao(); }
        }
        public override IBudgetAllocationShareDao BudgetAllocationShareDao
        {
            get { return new OracleBudgetAllocationShareDao(); }
        }
        public override ILoanDisbursementDao LoanDisbursementDao
        {
            get { return new OracleLoanDisbursementDao(); }
        }
        public override ILoanDisbursementPostingDao LoanDisbursementPostingDao
        {
            get { return new OracleLoanDisbursementPostingDao(); }
        }
        public override ILoanRepaymentDao LoanRepaymentDao
        {
            get { return new OracleLoanRepaymentDao(); }
        }
        public override ILoanRepaymentPostingDao LoanRepaymentPostingDao
        {
            get { return new OracleLoanRepaymentPostingDao(); }
        }
        public override ISavingDepositDao SavingDepositDao
        {
            get { return new OracleSavingDepositDao(); }
        }
        public override ISavingDepositPostingDao SavingDepositPostingDao
        {
            get { return new OracleSavingDepositPostingDao(); }
        }
        public override IAbbsSavingDepositDao AbbsSavingDepositDao
        {
            get { return new OracleAbbsSavingDepositDao(); }
        }
        public override IDepositPostingPublicDao DepositPostingPublicDao
        {
            get { return new OracleDepositPostingPublicDao(); }
        }
        public override ISavingWithdrawlDao SavingWithdrawlDao
        {
            get { return new OracleSavingWithdrawlDao(); }
        }
        public override ISavingWithdrawlPostingDao SavingWithdrawlPostingDao
        {
            get { return new OracleSavingWithdrawlPostingDao(); }
        }
        public override IAbbsSavingWithdrawlDao AbbsSavingWithdrawlDao
        {
            get { return new OracleAbbsSavingWithdrawlDao(); }
        }
        public override IWithdrawlPostingPublicDao WithdrawlPostingPublicDao
        {
            get { return new OracleWithdrawlPostingPublicDao(); }
        }
        public override ICollectionSheetMasterOnlineDao CollectionSheetMasterOnlineDao
        {
            get { return new OracleCollectionSheetMasterOnlineDao(); }
        }
        public override ICollectionSheetPostingDao CollectionSheetPostingDao
        {
            get { return new OracleCollectionSheetPostingDao(); }
        }
        public override IMemberProtectionDepositDao MemberProtectionDepositDao
        {
            get { return new OracleMemberProtectionDepositDao(); }
        }
        public override IMemberProtectionDepositPostingDao MemberProtectionDepositPostingDao
        {
            get { return new OracleMemberProtectionDepositPostingDao(); }
        }
        public override IMemberProtectionBenefitDao MemberProtectionBenefitDao
        {
            get { return new OracleMemberProtectionBenefitDao(); }
        }
        public override ILiveProtectDepositDao LiveProtectDepositDao
        {
            get { return new OracleLiveProtectDepositDao(); }
        }
        public override ILiveProtectBenefitDao LiveProtectBenefitDao
        {
            get { return new OracleLiveProtectBenefitDao(); }
        }
        public override IStaffDisbursementDao StaffDisbursementDao
        {
            get { return new OracleStaffDisbursementDao(); }
        }
        public override IPublicSavingWithdrawlDao PublicSavingWithdrawlDao
        {
            get { return new OraclePublicSavingWithdrawlDao(); }
        }
        public override IPublicSavingWithdrawlPostingDao PublicSavingWithdrawlPostingDao
        {
            get { return new OraclePublicSavingWithdrawlPostingDao(); }
        }
        public override ILiveStockBenefitPostingDao LiveStockBenefitPostingDao
        {
            get { return new OracleLiveStockBenefitPostingDao(); }
        }
        public override ILiveStockDepositPostingDao LiveStockDepositPostingDao
        {
            get { return new OracleLiveStockDepositPostingDao(); }
        }
        public override IMemberProtectBenefitPostingDao MemberProtectBenefitPostingDao
        {
            get { return new OracleMemberProtectBenefitPostingDao(); }
        }
        public override ICallAbbsAdjustmentDao CallAbbsAdjustmentDao
        {
            get { return new OracleCallAbbsAdjustmentDao(); }
        }
        public override IDayEndProcessDao DayEndProcessDao
        {
            get { return new OracleDayEndProcessDao(); }
        }
        public override IDayBeginProcessDao DayBeginProcessDao
        {
            get { return new OracleDayBeginProcessDao(); }
        }
        public override ICollectionOfflineDateDao CollectionOfflineDateDao
        {
            get { return new OracleCollectionOfflineDateDao(); }
        }
        public override ICollectionSheetMasterOfflineDao CollectionSheetMasterOfflineDao
        {
            get { return new OracleCollectionSheetMasterOfflineDao(); }
        }
        #endregion


        #region "INVENTORY-TRANSACTION"

        public override ILocationDao LocationDao
        {
            get { return new OracleLocationDao(); }
        }
        public override ISupplierDao SupplierDao
        {
            get { return new OracleSupplierDao(); }
        }
        public override IOsItemDao OsItemDao
        {
            get { return new OracleOsItemDao(); }
        }
        public override IOpeningStockMasterDetailDao OpeningStockMasterDetailDao
        {
            get { return new OracleOpeningStockMasterDetailDao(); }
        }
        public override IInItemTransactionMasterDao InItemTransactionMasterDao
        {
            get { return new OracleInItemTransactionMasterDao(); }
        }
        public override IItemTransactionDetailDao ItemTransactionDetailDao
        {
            get { return new OracleItemTransactionDetailDao(); }
        }
        public override IGoodReceiptSearchDao GoodReceiptSearchDao
        {
            get { return new OracleGoodReceiptSearchDao(); }
        }
        public override IGoodReceiptMasterDetailDao GoodReceiptMasterDetailDao
        {
            get { return new OracleGoodReceiptMasterDetailDao(); }
        }
        public override IGoodReceiptDetailDetailDao GoodReceiptDetailDetailDao
        {
            get { return new OracleGoodReceiptDetailDetailDao(); }
        }
        public override IGoodReceiptReturnDao GoodReceiptReturnDao
        {
            get { return new OracleGoodReceiptReturnDao(); }
        }
        public override IGoodReceiptReturnItemDao GoodReceiptReturnItemDao
        {
            get { return new OracleGoodReceiptReturnItemDao(); }
        }
        public override IGoodReceiptReturnMasterDetailDao GoodReceiptReturnMasterDetailDao
        {
            get { return new OracleGoodReceiptReturnMasterDetailDao(); }
        }
        public override IGoodReceiptReturnDetailDao GoodReceiptReturnDetailDao
        {
            get { return new OracleGoodReceiptReturnDetailDao(); }
        }
        public override IGoodReceiptEmployeeDao GoodReceiptEmployeeDao
        {
            get { return new OracleGoodReceiptEmployeeDao(); }
        }
        public override IMemoMasterDetailDao MemoMasterDetailDao
        {
            get { return new OracleMemoMasterDetailDao(); }
        }
        public override IMemoDetailDetailDao MemoDetailDetailDao
        {
            get { return new OracleMemoDetailDetailDao(); }
        }
        public override IMemoReturnReferenceNoDao MemoReturnReferenceNoDao
        {
            get { return new OracleMemoReturnReferenceNoDao(); }
        }
        public override IMemoReturnMasterDetailDao MemoReturnMasterDetailDao
        {
            get { return new OracleMemoReturnMasterDetailDao(); }
        }
        public override IMemoReturnDetailDetailDao MemoReturnDetailDetailDao
        {
            get { return new OracleMemoReturnDetailDetailDao(); }
        }
        public override IDamageLostMasterDetailDao DamageLostMasterDetailDao
        {
            get { return new OracleDamageLostMasterDetailDao(); }
        }
        public override IDamageLostDetailDetailDao DamageLostDetailDetailDao
        {
            get { return new OracleDamageLostDetailDetailDao(); }
        }
        public override IAssetItemDao AssetItemDao
        {
            get { return new OracleAssetItemDao(); }
        }
        public override IUserOfficeDao UserOfficeDao
        {
            get { return new OracleUserOfficeDao(); }
        }
        public override IInfFaAssetDao InfFaAssetDao
        {
            get { return new OracleInfFaAssetDao(); }
        }
        public override IDepreciationDao DepreciationDao
        {
            get { return new OracleDepreciationDao(); }
        }
        public override IDepreciationDetailDao DepreciationDetailDao
        {
            get { return new OracleDepreciationDetailDao(); }
        }
        public override IAssetMaintenanceDetailDao AssetMaintenanceDetailDao
        {
            get { return new OracleAssetMaintenanceDetailDao(); }
        }
        public override IAssetDao AssetDao
        {
            get { return new OracleAssetDao(); }
        }
        public override IFaAssetSendReceiptDao FaAssetSendReceiptDao
        {
            get { return new OracleFaAssetSendReceiptDao(); }
        }
        public override IAssetDetailDao AssetDetailDao
        {
            get { return new OracleAssetDetailDao(); }
        }
        public override IMemoApprovalDetailDao MemoApprovalDetailDao
        {
            get { return new OracleMemoApprovalDetailDao(); }
        }
        public override IOpeningStockDetailDetailDao OpeningStockDetailDetailDao
        {
            get { return new OracleOpeningStockDetailDetailDao(); }
        }
        public override IFaMaintenanceDao FaMaintenanceDao
        {
            get { return new OracleFaMaintenanceDao(); }
        }
        public override IMemoApprovalMasterDetailDao MemoApprovalMasterDetailDao
        {
            get { return new OracleMemoApprovalMasterDetailDao(); }
        }
        public override ILoanTransferToClientDao LoanTransferToClientDao
        {
            get { return new OracleLoanTransferToClientDao(); }
        }
        public override IMemoApprovalDao MemoApprovalDao
        {
            get { return new OracleMemoApprovalDao(); }
        }
        public override IAssetSendReceiptDetailDao AssetSendReceiptDetailDao
        {
            get { return new OracleAssetSendReceiptDetailDao(); }
        }
        
        
        #endregion

        #region "HUMAN RESOURCE"

        public override IDesignationDao DesignationDao
        {
            get { return new OracleDesignationDao(); }
        }

        public override IPostDao PostDao
        {
            get { return new OraclePostDao(); }
        }


        //TRANSACTION
        public override IEmployeeAllowanceAmountDao EmployeeAllowanceAmountDao
        {
            get { return new OracleEmployeeAllowanceAmountDao(); }
        }
        public override IEmployeeAllowanceDetailDao EmployeeAllowanceDetailDao
        {
            get { return new OracleEmployeeAllowanceDetailDao(); }
        }
        public override IEmployeeLocalAllowanceDao EmployeeLocalAllowanceDao
        {
            get { return new OracleEmployeeLocalAllowanceDao(); }
        }
        public override IEmployeeEducationDetailDao EmployeeEducationDetailDao
        {
            get { return new OracleEmployeeEducationDetailDao(); }
        }
        public override IEmployeeEducationDao EmployeeEducationDao
        {
            get { return new OracleEmployeeEducationDao(); }
        }
        public override IEmployeeTrainingDetailDao EmployeeTrainingDetailDao
        {
            get { return new OracleEmployeeTrainingDetailDao(); }
        }
        public override IEmployeeTrainingReceivedDao EmployeeTrainingReceivedDao
        {
            get { return new OracleEmployeeTrainingReceivedDao(); }
        }
        public override IEmployeeTransferDetailDao EmployeeTransferDetailDao
        {
            get { return new OracleEmployeeTransferDetailDao(); }
        }
        public override IEmployeeTransferDao EmployeeTransferDao
        {
            get { return new OracleEmployeeTransferDao(); }
        }
        public override IEmployeePromotionDetailDao EmployeePromotionDetailDao
        {
            get { return new OracleEmployeePromotionDetailDao(); }
        }
        public override IEmployeePromotionDao EmployeePromotionDao
        {
            get { return new OracleEmployeePromotionDao(); }
        }
        public override IPublicChequeNoDao PublicChequeNoDao
        {
            get { return new OraclePublicChequeNoDao(); }
        }
        public override IPublicChequeUpdateDao PublicChequeUpdateDao
        {
            get { return new OraclePublicChequeUpdateDao(); }
        }
        #endregion


    }
}

