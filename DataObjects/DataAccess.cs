using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using DataObjects.Security;
using DataObjects.Interfaces.Maintenance;
using DataObjects.Interfaces.Supervisor;
using DataObjects.Interfaces.GeneralMasterParameters;
using DataObjects.Interfaces.Finance;
using DataObjects.Interfaces.HumanResource;
using DataObjects.Interfaces.Common;
using DataObjects.Interfaces.Inventory;
//using DataObjects.Security;


namespace DataObjects
{
    /// <summary>
    /// This class shields the client from the details of database specific 
    /// data-access objects. It returns the appropriate data-access objects 
    /// according to the configuration in web.config.
    /// </summary>
    /// <remarks>
    /// GoF Design Patterns: Factory, Singleton, Proxy.
    /// 
    /// This class makes extensive use of the Factory pattern in determining which 
    /// database specific DAOs (Data Access Objects) to return.
    /// 
    /// This class is like a Singleton -- it is a static class (Shared in VB) and 
    /// therefore only one 'instance' will ever exist.
    /// 
    /// This class is a Proxy as it 'stands in' for the actual Data Access Object Factory.
    /// </remarks>
    public static class DataAccess
    {
        // The static field initializers below are thread safe.
        // Furthermore, they are executed in the order in which they appear
        // in the class declaration. Note: if a static constructor
        // is present you want to initialize these in that constructor.
        private static readonly string connectionStringName = ConfigurationManager.AppSettings.Get("ConnectionStringName");
        private static readonly DaoFactory factory = DaoFactories.GetFactory(connectionStringName);

        #region "COMMON"

        public static IDateDao DateDao
        {
            get { return factory.DateDao; }
        }
        public static IDistrictDao DistrictDao
        {
            get { return factory.DistrictDao; }
        }
        public static IVdcDao VdcDao
        {
            get { return factory.VdcDao; }
        }
        public static ICountryDao CountryDao
        {
            get { return factory.CountryDao; }
        }

        public static IFiscalYearDao FiscalYearDao
        {
            get { return factory.FiscalYearDao; }
        }



        #endregion 

        #region "GENERAL MASTER PARAMETERS"
        //HOLIDAY
        public static IHolidayDao HolidayDao
        {
            get { return factory.HolidayDao; }
        }
        public static IOfficeWiseHolidayDao OfficeWiseHolidayDao
        {
            get { return factory.OfficeWiseHolidayDao; }
        }

        //DEPARTMENT
        public static IDepartmentDao DepartmentDao
        {
            get { return factory.DepartmentDao; }
        }

        public static IDepartmentMapDao DepartmentMapDao
        {
            get { return factory.DepartmentMapDao; }
        }
        

        //OFFICE
        public static IOfficeDao OfficeDao
        {
            get { return factory.OfficeDao; }
        }
        public static IOfficeTypeDao OfficeTypeDao
        {
            get { return factory.OfficeTypeDao; }
        }
        public static IOfficeMapDao OfficeMapDao
        {
            get { return factory.OfficeMapDao; }
        }
        public static IVdcCoverageByOfficeDao VdcCoverageByOfficeDao
        {
            get { return factory.VdcCoverageByOfficeDao; }
        }

        //MENU
        public static IMenuEntryDao MenuEntryDao
        {
            get { return factory.MenuEntryDao; }
        }

        public static IModuleDao ModuleDao
        {
            get { return factory.ModuleDao; }
        }
        public static IReportDao ReportDao
        {
            get { return factory.ReportDao; }
        }
        public static ITabDao TabDao
        {
            get { return factory.TabDao; }
        }

        //GROUP
        public static IGroupDao GroupDao
        {
            get { return factory.GroupDao; }
        }
        

        //CONTROL REFERENCE VALUES
        public static IMsControlValuesDao MsControlValuesDao
        {
            get { return factory.MsControlValuesDao; }
        }

        public static IMsReferenceCodeMasterDao MsReferenceCodeMasterDao
        {
            get { return factory.MsReferenceCodeMasterDao; }
        }
        public static IMsReferenceCodeDetailsDao MsReferenceCodeDetailsDao
        {
            get { return factory.MsReferenceCodeDetailsDao; }
        }
        


        //CASTE /ETHINICITY/EDUCATION
        public static ICasteDetailDao CasteDetailDao
        {
            get { return factory.CasteDetailDao; }
        }
        public static IEducationDao EducationDao
        {
            get { return factory.EducationDao; }
        }
        public static IOccupationDao OccupationDao
        {
            get { return factory.OccupationDao; }
        }
        public static IEthnicityInformationDao EthnicityInformationDao
        {
            get { return factory.EthnicityInformationDao; }
        }
        public static IEthnicityCasteInformationDao EthnicityCasteInformationDao
        {
            get { return factory.EthnicityCasteInformationDao; }
        }


        public static IReligionDao ReligionDao
        {
            get { return factory.ReligionDao; }
        }
        #endregion

        #region SECURITY


        public static GenericUserDao UserDao
        {
            get { return factory.UserDao; }
        }

        

        public static ILoginDao LoginDao
        {
            get { return factory.LoginDao; }
        }
        public static IRoleDao RoleDao
        {
            get { return factory.RoleDao; }
        }

        

        #endregion

        #region "GENERAL DEFINITIONS"
        public static INarrationDao NarrationDao
        {
            get { return factory.NarrationDao; }
        }
        public static INepaliDateConversionDao NepaliDateConversionDao
        {
            get { return factory.NepaliDateConversionDao; }
        }

        public static INepaliFiscalYearDao NepaliFiscalYearDao
        {
            get { return factory.NepaliFiscalYearDao; }
        }

        public static IInstallmentPeriodDao InstallmentPeriodDao
        {
            get { return factory.InstallmentPeriodDao; }
        }

        public static ILoanInstallmentPeriodMapDao LoanInstallmentPeriodMapDao
        {
            get { return factory.LoanInstallmentPeriodMapDao; }
        }

        public static ILoanPeriodDao LoanPeriodDao
        {
            get { return factory.LoanPeriodDao; }
        }

        public static ILoanProductPeriodMapDao LoanProductPeriodMapDao
        {
            get { return factory.LoanProductPeriodMapDao; }
        }

        public static IGeneralDefinitionsUtilityDao GeneralDefinitionsUtilityDao
        {
            get { return factory.GeneralDefinitionsUtilityDao; }
        }
        #endregion

        #region "SUPERVISOR"
        public static IControlTableDao ControlTableDao
        {
            get { return factory.ControlTableDao; }
        }
        
        public static IOfficeDepartmentDao OfficeDepartmentDao
        {
            get { return factory.OfficeDepartmentDao; }
        }
        

        //EMPLOYEE
        public static IEmployeeDao EmployeeDao
        {
            get { return factory.EmployeeDao; }
        }
        #endregion

        #region "ACCOUNT CONTROL"
        public static IAccountCategoryDao AccountCategoryDao
        {
            get { return factory.AccountCategoryDao; }
        }
        public static IAccountSubCategoryDao AccountSubCategoryDao
        {
            get { return factory.AccountSubCategoryDao; }
        }
        public static IGLVoucherTypeDao GLVoucherTypeDao
        {
            get { return factory.GLVoucherTypeDao; }
        }
        public static IVoucherApprovalSecurityDao VoucherApprovalSecurityDao
        {
            get { return factory.VoucherApprovalSecurityDao; }
        }
        

        #endregion

        #region "FINANCE-MAINTENANCE"
        //MAINTENANCE
        public static ICompulsoryAccountsEntryDao CompulsoryAccountsEntryDao
        {
            get { return factory.CompulsoryAccountsEntryDao; }
        }
        public static ILoanDeductionTypeDao LoanDeductionTypeDao
        {
            get { return factory.LoanDeductionTypeDao; }
        }
        public static IMainInterestSchemeDao MainInterestSchemeDao
        {
            get { return factory.MainInterestSchemeDao; }
        }

        public static IAccountHeadEntryDao AccountHeadEntryDao
        {
            get { return factory.AccountHeadEntryDao; }
        }

        public static ISavingMidTermInterestDao SavingMidTermInterest
        {
            get
            {
                return factory.SavingMidTermInterest;
            }
        }
        public static IABBSChargeDao ABBSChargeDao
        {
            get {
                return factory.ABBSChargeDao;
            }
        }
        public static ISectorDao SectorDao
        {
            get
            {
                return factory.SectorDao;
            }
        }
        public static ISubSectorDao SubSectorDao
        {
            get
            {
                return factory.SubSectorDao;
            }

        }
        
        public static ILoanPurposeProductDetailDao LoanPurposeProductDetailDao
        {
            get
            {
                return factory.LoanPurposeProductDetailDao;
            }
        }
        public static ICenterDao CenterDao
        {
            get {
                return factory.CenterDao;
            }
        }
        public static ICenterLovDao CenterLovDao
        {
            get {
                return factory.CenterLovDao;
            }
        }

        public static IMemberDao MemberDao
        {
            get
            {
                return factory.MemberDao;
            }
        }

        public static ILoanSectorDao LoanSectorDao
        {
            get { return factory.LoanSectorDao; }
        }

        public static ILoanSubSectorDao LoanSubSectorDao
        {
            get { return factory.LoanSubSectorDao; }
        }

        public static ILoanPurposeDao LoanPurposeDao
        {
            get { return factory.LoanPurposeDao; }
        }

        public static ILoanPurposeProductsDao LoanPurposeProductsDao
        {
            get { return factory.LoanPurposeProductsDao; }
        }

        public static IInterestSchemeDao InterestSchemeDao
        {
            get { return factory.InterestSchemeDao; }
        }
        public static IInterestSchemeMasterDao InterestSchemeMasterDao
        {
            get { return factory.InterestSchemeMasterDao; }
        }
        public static IInterestSchemeDetailDao InterestSchemeDetailDao
        {
            get { return factory.InterestSchemeDetailDao; }
        }
        public static ILoanProductAccountHeadDao LoanProductAccountHeadDao
        {
            get { return factory.LoanProductAccountHeadDao; }
        }
        public static ISavingTypeDao SavingTypeDao
        {
            get { return factory.SavingTypeDao; }
        }
        public static ILoanProductDetailDao LoanProductDetailDao
        {
            get { return factory.LoanProductDetailDao; }
        }
        public static ILoanDeductionDetailDao LoanDeductionDetailDao
        {
            get { return factory.LoanDeductionDetailDao; }
        }
        public static ILoanProductDeductionDao LoanProductDeductionDao
        {
            get { return factory.LoanProductDeductionDao; }
        }
        public static ISavingProductAccountHeadDao SavingProductAccountHeadDao
        {
            get { return factory.SavingProductAccountHeadDao; }
        }
        public static ISavingProductDetailDao SavingProductDetailDao
        {
            get { return factory.SavingProductDetailDao; }
        }
        #endregion

        #region "FINANCE-TRANSACTION"
        //MEMBER TRANSACTION
        public static ITransferWithinCenterDao TransferWithinCenterDao
        {
            get { return factory.TransferWithinCenterDao; }
        }
        public static ITransferCenterToAnotherCenterDao TransferCenterToAnotherCenterDao
        {
            get { return factory.TransferCenterToAnotherCenterDao; }
        }
        public static IDropOutReasonDao DropOutReasonDao
        {
            get { return factory.DropOutReasonDao; }
        }
        public static IMemberCancellationRestoreDao MemberCancellationRestoreDao
        {
            get { return factory.MemberCancellationRestoreDao; }
        }
        public static IMemberForCancellationDao MemberForCancellationDao
        {
            get { return factory.MemberForCancellationDao; }
        }

        //COLLECTION SHEET TRANSACTION
        public static ICenterDetailsFromCodeDao CenterDetailsFromCodeDao
        {
            get { return factory.CenterDetailsFromCodeDao; }
        }
        public static IOfflineCollectionCenterDao OfflineCollectionCenterDao
        {
            get { return factory.OfflineCollectionCenterDao; }
        }
        public static IOnlineCollectionCenterDao OnlineCollectionCenterDao
        {
            get { return factory.OnlineCollectionCenterDao; }
        }
        public static IGenerateSavingCollectionDao GenerateSavingCollectionDao
        {
            get { return factory.GenerateSavingCollectionDao; }
        }
        public static ICollectionAdjustDao CollectionAdjustDao
        {
            get { return factory.CollectionAdjustDao; }
        }
        public static ISavingCollectionSheetDao SavingCollectionSheetDao
        {
            get { return factory.SavingCollectionSheetDao; }
        }
        public static ILoanCollectionDetailDao LoanCollectionDetailDao
        {
            get { return factory.LoanCollectionDetailDao; }
        }

        public static IEmployeeCenterCollectionDao EmployeeCenterCollectionDao
        {
            get { return factory.EmployeeCenterCollectionDao; }
        }
        public static IUnapprovedCollectionDao UnapprovedCollectionDao
        {
            get { return factory.UnapprovedCollectionDao; }
        }
        public static ICollectionSheetMasterDao CollectionSheetMasterDao
        {
            get { return factory.CollectionSheetMasterDao; }
        }

        //SAVING TRANSACTION
        public static ISavingProductDao SavingProductDao
        {
            get { return factory.SavingProductDao; }
        }
        public static IClientSavingAccountDao ClientSavingAccountDao
        {
            get { return factory.ClientSavingAccountDao; }
        }

        public static IAccountOpenDetailDao AccountOpenDetailDao
        {
            get { return factory.AccountOpenDetailDao; }
        }
        public static IProductForDepositDao ProductForDepositDao
        {
            get { return factory.ProductForDepositDao; }
        }
        public static IAccountForDepositDao AccountForDepositDao
        {
            get { return factory.AccountForDepositDao; }
        }
        public static IMfDepositDetailDao MfDepositDetailDao
        {
            get { return factory.MfDepositDetailDao; }
        }
        public static IMfSavingDepositDao MfSavingDepositDao
        {
            get { return factory.MfSavingDepositDao; }
        }
        public static IMfWithdrawlDetailDao MfWithdrawlDetailDao
        {
            get { return factory.MfWithdrawlDetailDao; }
        }
        public static IProductForWithdrawlDao ProductForWithdrawlDao
        {
            get { return factory.ProductForWithdrawlDao; }
        }
        public static IAccountForWithdrawlDao AccountForWithdrawlDao
        {
            get { return factory.AccountForWithdrawlDao; }
        }
        public static IMfSavingWithdrawDao MfSavingWithdrawDao
        {
            get { return factory.MfSavingWithdrawDao; }
        }
        public static IProductForAccountCloseDao ProductForAccountCloseDao
        {
            get { return factory.ProductForAccountCloseDao; }
        }

        public static IAccountForClosingDao AccountForClosingDao
        {
            get { return factory.AccountForClosingDao; }
        }
        public static IAccountCloseDetailDao AccountCloseDetailDao
        {
            get { return factory.AccountCloseDetailDao; }
        }
        public static ISavingAccountClosureDao SavingAccountClosureDao
        {
            get { return factory.SavingAccountClosureDao; }
        }
        public static IMemberAccountOpenDao MemberAccountOpenDao
        {
            get { return factory.MemberAccountOpenDao; }
        }
        public static IMemberForChequeDao MemberForChequeDao
        {
            get { return factory.MemberForChequeDao; }
        }
        public static IChequeGenerateDetailDao ChequeGenerateDetailDao
        {
            get { return factory.ChequeGenerateDetailDao; }
        }
        public static IGenerateChequeSequenceDao GenerateChequeSequenceDao
        {
            get { return factory.GenerateChequeSequenceDao; }
        }

        //LOAN TRANSACTION
        public static ILoanMemberDao LoanMemberDao
        {
            get { return factory.LoanMemberDao; }
        }
        public static ILoanProductDao LoanProductDao
        {
            get { return factory.LoanProductDao; }
        }
        public static IMfLoanPurposeDao MfLoanPurposeDao
        {
            get { return factory.MfLoanPurposeDao; }
        }
        public static IMfAdjustSavingDao MfAdjustSavingDao
        {
            get { return factory.MfAdjustSavingDao; }
        }
        public static IMfLoanSearchDao MfLoanSearchDao
        {
            get { return factory.MfLoanSearchDao; }
        }
        public static IMfLoanDetailDao MfLoanDetailDao
        {
            get { return factory.MfLoanDetailDao; }
        }
        public static IMfLoanDisbursementDao MfLoanDisbursementDao
        {
            get { return factory.MfLoanDisbursementDao; }
        }

        public static IMfLoanRepaymentDao MfLoanRepaymentDao
        {
            get { return factory.MfLoanRepaymentDao; }
        }
        public static IMfRepayAdjustSavingDao MfRepayAdjustSavingDao
        {
            get { return factory.MfRepayAdjustSavingDao; }
        }
        public static IMfRepaySearchLoanDao MfRepaySearchLoanDao
        {
            get { return factory.MfRepaySearchLoanDao; }
        }
        public static IMfRepayDetailDao MfRepayDetailDao
        {
            get { return factory.MfRepayDetailDao; }
        }
        public static IMeLoanDisbursementDao MeLoanDisbursementDao
        {
            get { return factory.MeLoanDisbursementDao; }
        }
        public static IMeLoanProductDao MeLoanProductDao
        {
            get { return factory.MeLoanProductDao; }
        }

        public static IFundingAgencyDao FundingAgencyDao
        {
            get { return factory.FundingAgencyDao; }
        }

        public static ILoanCollateralDao LoanCollateralDao
        {
            get { return factory.LoanCollateralDao; }
        }
        public static IMeLoanSearchDao MeLoanSearchDao
        {
            get { return factory.MeLoanSearchDao; }
        }
        public static IMeLoanDetailDao MeLoanDetailDao
        {
            get { return factory.MeLoanDetailDao; }
        }
        public static IMfAdditionalLoanDao MfAdditionalLoanDao
        {
            get { return factory.MfAdditionalLoanDao; }
        }
        public static IMfAdditionalLoanDetailDao MfAdditionalLoanDetailDao
        {
            get { return factory.MfAdditionalLoanDetailDao; }
        }
        public static IMfAdditionalLoanDisbursementDao MfAdditionalLoanDisbursementDao
        {
            get { return factory.MfAdditionalLoanDisbursementDao; }
        }
        public static IMeLoanRepayDao MeLoanRepayDao
        {
            get { return factory.MeLoanRepayDao; }
        }
        public static IMeLoanRepayDetailDao MeLoanRepayDetailDao
        {
            get { return factory.MeLoanRepayDetailDao; }
        }
        public static IMeAdditionalLoanDao MeAdditionalLoanDao
        {
            get { return factory.MeAdditionalLoanDao; }
        }
        public static IMeAdditionalLoanDetailDao MeAdditionalLoanDetailDao
        {
            get { return factory.MeAdditionalLoanDetailDao; }
        }
        public static IMeAdditionalLoanDisbursementDao MeAdditionalLoanDisbursementDao
        {
            get { return factory.MeAdditionalLoanDisbursementDao; }
        }
        public static ILasMemberDao LasMemberDao
        {
            get { return factory.LasMemberDao; }
        }
        public static ILoanAgainstSavingDisbursementDao LoanAgainstSavingDisbursementDao
        {
            get { return factory.LoanAgainstSavingDisbursementDao; }
        }
        public static ILoanUtilizationEntryDao LoanUtilizationEntryDao
        {
            get { return factory.LoanUtilizationEntryDao; }
        }
        public static IAdjustLoanIntPriPenNewDao AdjustLoanIntPriPenNewDao
        {
            get { return factory.AdjustLoanIntPriPenNewDao; }
        }
        public static ILoanDao LoanDao
        {
            get { return factory.LoanDao; }
        }
        public static IMfSavingDepositEditDao MfSavingDepositEditDao
        {
            get { return factory.MfSavingDepositEditDao; }
        }
        public static ILasProductDao LasProductDao
        {
            get { return factory.LasProductDao; }
        }
        public static ILoanLasSavingProductDao LoanLasSavingProductDao
        {
            get { return factory.LoanLasSavingProductDao; }
        }
        public static ILasLoanSearchDao LasLoanSearchDao
        {
            get { return factory.LasLoanSearchDao; }
        }
        public static ILasLoanDetailDao LasLoanDetailDao
        {
            get { return factory.LasLoanDetailDao; }
        }
        public static ILnUtilizationLoanDao LnUtilizationLoanDao
        {
            get { return factory.LnUtilizationLoanDao; }
        }
        public static ILnUtilizationDetailDao LnUtilizationDetailDao
        {
            get { return factory.LnUtilizationDetailDao; }
        }
        public static ILoanRepayAdjustLoanDao LoanRepayAdjustLoanDao
        {
            get { return factory.LoanRepayAdjustLoanDao; }
        }
        public static ILoanInformationDao LoanInformationDao
        {
            get { return factory.LoanInformationDao; }
        }



        //EDIT TRANSACTION
        public static ILoanRepayAdjustRepayDao LoanRepayAdjustRepayDao
        {
            get { return factory.LoanRepayAdjustRepayDao; }
        }
        public static ICalLoanBalanceStatusDao CalLoanBalanceStatusDao
        {
            get { return factory.CalLoanBalanceStatusDao; }
        }
        public static ILoanAdjustLoanDao LoanAdjustLoanDao
        {
            get { return factory.LoanAdjustLoanDao; }
        }
        public static ILoanTransferFromCenterDao LoanTransferFromCenterDao
        {
            get { return factory.LoanTransferFromCenterDao; }
        }
        public static ILoanTransferFromClientDao LoanTransferFromClientDao
        {
            get { return factory.LoanTransferFromClientDao; }
        }
        public static ILoanTransferProductDao LoanTransferProductDao
        {
            get { return factory.LoanTransferProductDao; }
        }
        public static ILoanTransferFromLoanDao LoanTransferFromLoanDao
        {
            get { return factory.LoanTransferFromLoanDao; }
        }
        public static ITransferLoanAccountDao TransferLoanAccountDao
        {
            get { return factory.TransferLoanAccountDao; }
        }
        public static ISavingTransferFromCenterDao SavingTransferFromCenterDao
        {
            get { return factory.SavingTransferFromCenterDao; }
        }
        public static ISavingTransferFromClientDao SavingTransferFromClientDao
        {
            get { return factory.SavingTransferFromClientDao; }
        }
        public static ISavingTransferFromAccountDao SavingTransferFromAccountDao
        {
            get { return factory.SavingTransferFromAccountDao; }
        }
        public static ISavingTransferProcDao SavingTransferProcDao
        {
            get { return factory.SavingTransferProcDao; }
        }
        public static ITransferSavingAccountDao TransferSavingAccountDao
        {
            get { return factory.TransferSavingAccountDao; }
        }
        public static IPubSavingProductDao PubSavingProductDao
        {
            get { return factory.PubSavingProductDao; }
        }
        public static IAdjPubSavingAccountDao AdjPubSavingAccountDao
        {
            get { return factory.AdjPubSavingAccountDao; }
        }

        public static IPubSavingAccountSearchDao PubSavingAccountSearchDao
        {
            get { return factory.PubSavingAccountSearchDao; }
        }
        public static IPubSavingDepositDetailDao PubSavingDepositDetailDao
        {
            get { return factory.PubSavingDepositDetailDao; }
        }
        public static IPublicSavingDepositDao PublicSavingDepositDao
        {
            get { return factory.PublicSavingDepositDao; }
        }
        public static IPublicSavingWithdrawDao PublicSavingWithdrawDao
        {
            get { return factory.PublicSavingWithdrawDao; }
        }
        public static IPublicSavingWithdrawProductDao PublicSavingWithdrawProductDao
        {
            get { return factory.PublicSavingWithdrawProductDao; }
        }
        public static IPublicSavingWithdrawDetailDao PublicSavingWithdrawDetailDao
        {
            get { return factory.PublicSavingWithdrawDetailDao; }
        }
        public static IAdjustmentaccountforwithdrawDao AdjustmentaccountforwithdrawDao
        {
            get { return factory.AdjustmentaccountforwithdrawDao; }
        }
        #endregion

        #region "FINANCE-TRANSACTION-II"
        //PUBLIC SAVING TRANSACTION
        public static IPublicClientDao PublicClientDao
        {
            get { return factory.PublicClientDao; }
        }
        public static IPublicClientDetailDao PublicClientDetailDao
        {
            get { return factory.PublicClientDetailDao; }
        }
        public static IPublicMemberDao PublicMemberDao
        {
            get { return factory.PublicMemberDao; }
        }
        public static IPublicReferenceAccountDao PublicReferenceAccountDao
        {
            get { return factory.PublicReferenceAccountDao; }
        }
        public static IPublicAccountDetailDao PublicAccountDetailDao
        {
            get { return factory.PublicAccountDetailDao; }
        }
        public static IPublicSavingAccountOpenDao PublicSavingAccountOpenDao
        {
            get { return factory.PublicSavingAccountOpenDao; }
        }
        public static IPublicSavingDepositAccountDao PublicSavingDepositAccountDao
        {
            get { return factory.PublicSavingDepositAccountDao; }
        }
        public static IPublicAdjustmentdepositaccountDao PublicAdjustmentdepositaccountDao
        {
            get { return factory.PublicAdjustmentdepositaccountDao; }
        }
        public static IPublicAccountChequeDao PublicAccountChequeDao
        {
            get { return factory.PublicAccountChequeDao; }
        }
        public static IPublicWithdrawWithAccountDao PublicWithdrawWithAccountDao
        {
            get { return factory.PublicWithdrawWithAccountDao; }
        }
        public static IPublicAccountCloseProductDao PublicAccountCloseProductDao
        {
            get { return factory.PublicAccountCloseProductDao; }
        }
        public static IPublicAccountCloseAccountDao PublicAccountCloseAccountDao
        {
            get { return factory.PublicAccountCloseAccountDao; }
        }
        public static IQueryOnSavingAccountCloseDao QueryOnSavingAccountCloseDao
        {
            get { return factory.QueryOnSavingAccountCloseDao; }
        }
        public static IPublicAccountCloseDetailDao PublicAccountCloseDetailDao
        {
            get { return factory.PublicAccountCloseDetailDao; }
        }
        public static IPublicSavingAccountClosureDao PublicSavingAccountClosureDao
        {
            get { return factory.PublicSavingAccountClosureDao; }
        }
        public static IPublicAccountChequeAccountDao PublicAccountChequeAccountDao
        {
            get { return factory.PublicAccountChequeAccountDao; }
        }
        public static IChequePrintDao ChequePrintDao
        {
            get { return factory.ChequePrintDao; }
        }
        public static IGroupBasedMemberDao GroupBasedMemberDao
        {
            get { return factory.GroupBasedMemberDao; }
        }
        public static IPublicChequeNoDao PublicChequeNoDao
        {
            get { return factory.PublicChequeNoDao; }
        }
        public static IPublicChequeUpdateDao PublicChequeUpdateDao
        {
            get { return factory.PublicChequeUpdateDao; }
        }


        //STAFF LOAN TRANSACTION
        public static IEmployeeKycEmployeeDao EmployeeKycEmployeeDao
        {
            get { return factory.EmployeeKycEmployeeDao; }
        }
        public static IEmployeeKycClientDao EmployeeKycClientDao
        {
            get { return factory.EmployeeKycClientDao; }
        }
        public static IEmployeeKycDetailDao EmployeeKycDetailDao
        {
            get { return factory.EmployeeKycDetailDao; }
        }
        public static IEmployeeKycInfoDao EmployeeKycInfoDao
        {
            get { return factory.EmployeeKycInfoDao; }
        }
        public static IStaffLoanDisbursementClientDao StaffLoanDisbursementClientDao
        {
            get { return factory.StaffLoanDisbursementClientDao; }
        }
        public static IStaffLoanDisbursementProductDao StaffLoanDisbursementProductDao
        {
            get { return factory.StaffLoanDisbursementProductDao; }
        }
        public static IStaffLoanDisbursementLoanDao StaffLoanDisbursementLoanDao
        {
            get { return factory.StaffLoanDisbursementLoanDao; }
        }
        public static IStaffLoanDisbursementDetailDao StaffLoanDisbursementDetailDao
        {
            get { return factory.StaffLoanDisbursementDetailDao; }
        }
        public static IStaffLoanDisbursementDao StaffLoanDisbursementDao
        {
            get { return factory.StaffLoanDisbursementDao; }
        }
        public static IStaffLoanDisbursementOpeningDao StaffLoanDisbursementOpeningDao
        {
            get { return factory.StaffLoanDisbursementOpeningDao; }
        }
        public static IStaffLoanRepayLoanDao StaffLoanRepayLoanDao
        {
            get { return factory.StaffLoanRepayLoanDao; }
        }
        public static IStaffLoanRepayAdjustmentSavingDao StaffLoanRepayAdjustmentSavingDao
        {
            get { return factory.StaffLoanRepayAdjustmentSavingDao; }
        }
        public static IStaffLoanAdjustmentDetailDao StaffLoanAdjustmentDetailDao
        {
            get { return factory.StaffLoanAdjustmentDetailDao; }
        }
        public static IStaffLoanRepayDetailDao StaffLoanRepayDetailDao
        {
            get { return factory.StaffLoanRepayDetailDao; }
        }
        public static IStaffLoanRepaymentDao StaffLoanRepaymentDao
        {
            get { return factory.StaffLoanRepaymentDao; }
        }
        public static IStaffAdditionalLoanDisbursementDao StaffAdditionalLoanDisbursementDao
        {
            get { return factory.StaffAdditionalLoanDisbursementDao; }
        }
        public static IStaffLoanAdditionalLoanDao StaffLoanAdditionalLoanDao
        {
            get { return factory.StaffLoanAdditionalLoanDao; }
        }
        public static IStaffLoanAdditionalScrLoanDao StaffLoanAdditionalScrLoanDao
        {
            get { return factory.StaffLoanAdditionalScrLoanDao; }
        }
        
        #endregion

        #region "FINANCE-ACCOUNT TRANSACTION"
        public static IContraBankAccountDao ContraBankAccountDao
        {
            get { return factory.ContraBankAccountDao; }
        }
        public static IParticularsDao ParticularsDao
        {
            get { return factory.ParticularsDao; }
        }
        public static IVoucherAccountDao VoucherAccountDao
        {
            get { return factory.VoucherAccountDao; }
        }
        public static IReceiptSearchVoucherDao ReceiptSearchVoucherDao
        {
            get { return factory.ReceiptSearchVoucherDao; }
        }
        public static IReceiptVoucherMasterDetailDao ReceiptVoucherMasterDetailDao
        {
            get { return factory.ReceiptVoucherMasterDetailDao; }
        }
        public static IReceiptVoucherDetailDetailDao ReceiptVoucherDetailDetailDao
        {
            get { return factory.ReceiptVoucherDetailDetailDao; }
        }
        public static IPaymentSearchVoucherDao PaymentSearchVoucherDao
        {
            get { return factory.PaymentSearchVoucherDao; }
        }
        public static IBudgetLimitAmtDao BudgetLimitAmtDao
        {
            get { return factory.BudgetLimitAmtDao; }
        }
        public static IPaymentVoucherMasterDetailDao PaymentVoucherMasterDetailDao
        {
            get { return factory.PaymentVoucherMasterDetailDao; }
        }
        public static IPaymentVoucherDetailDetailDao PaymentVoucherDetailDetailDao
        {
            get { return factory.PaymentVoucherDetailDetailDao; }
        }
        public static IJvSearchVoucherDao JvSearchVoucherDao
        {
            get { return factory.JvSearchVoucherDao; }
        }
        public static IJvMasterDetailDao JvMasterDetailDao
        {
            get { return factory.JvMasterDetailDao; }
        }
        public static IJvDtlDetailDao JvDtlDetailDao
        {
            get { return factory.JvDtlDetailDao; }
        }
        public static IGlTransactionMasterDao GlTransactionMasterDao
        {
            get { return factory.GlTransactionMasterDao; }
        }

        public static IGlTransactionDetailDao GlTransactionDetailDao
        {
            get { return factory.GlTransactionDetailDao; }
        }
        public static IReverseVoucherDao ReverseVoucherDao
        {
            get { return factory.ReverseVoucherDao; }
        }
        public static IReverseVoucherMasterDetailDao ReverseVoucherMasterDetailDao
        {
            get { return factory.ReverseVoucherMasterDetailDao; }
        }
        public static IReverseVoucherDetailDetailDao ReverseVoucherDetailDetailDao
        {
            get { return factory.ReverseVoucherDetailDetailDao; }
        }

        public static IVoucherApprovalMasterDao VoucherApprovalMasterDao
        {
            get { return factory.VoucherApprovalMasterDao; }
        }
        public static IVoucherApprovalDetailDao VoucherApprovalDetailDao
        {
            get { return factory.VoucherApprovalDetailDao; }
        }
        public static IApprovedGlTransactionDao ApprovedGlTransactionDao
        {
            get { return factory.ApprovedGlTransactionDao; }
        }

        public static IRegenerateFiscalYearClosingDao RegenerateFiscalYearClosingDao
        {
            get { return factory.RegenerateFiscalYearClosingDao; }
        }
        public static IBudgetAllocationAccountDao BudgetAllocationAccountDao
        {
            get { return factory.BudgetAllocationAccountDao; }
        }
        public static IBudgetAllocationDetailDetailDao BudgetAllocationDetailDetailDao
        {
            get { return factory.BudgetAllocationDetailDetailDao; }
        }
        public static IBudgetAllocationShareDetailDao BudgetAllocationShareDetailDao
        {
            get { return factory.BudgetAllocationShareDetailDao; }
        }
        public static IBudgetAllocationMasterDao BudgetAllocationMasterDao
        {
            get { return factory.BudgetAllocationMasterDao; }
        }
        public static IBudgetAllocationDetailDao BudgetAllocationDetailDao
        {
            get { return factory.BudgetAllocationDetailDao; }
        }
        public static IBudgetAllocationShareDao BudgetAllocationShareDao
        {
            get { return factory.BudgetAllocationShareDao; }
        }
        public static ILoanDisbursementDao LoanDisbursementDao
        {
            get { return factory.LoanDisbursementDao; }
        }
        public static ILoanDisbursementPostingDao LoanDisbursementPostingDao
        {
            get { return factory.LoanDisbursementPostingDao; }
        }
        public static ILoanRepaymentDao LoanRepaymentDao
        {
            get { return factory.LoanRepaymentDao; }
        }
        public static ILoanRepaymentPostingDao LoanRepaymentPostingDao
        {
            get { return factory.LoanRepaymentPostingDao; }
        }
        public static ISavingDepositDao SavingDepositDao
        {
            get { return factory.SavingDepositDao; }
        }
        public static ISavingDepositPostingDao SavingDepositPostingDao
        {
            get { return factory.SavingDepositPostingDao; }
        }
        public static IAbbsSavingDepositDao AbbsSavingDepositDao
        {
            get { return factory.AbbsSavingDepositDao; }
        }
        public static IDepositPostingPublicDao DepositPostingPublicDao
        {
            get { return factory.DepositPostingPublicDao; }
        }
        public static ISavingWithdrawlDao SavingWithdrawlDao
        {
            get { return factory.SavingWithdrawlDao; }
        }
        public static ISavingWithdrawlPostingDao SavingWithdrawlPostingDao
        {
            get { return factory.SavingWithdrawlPostingDao; }
        }
        public static IAbbsSavingWithdrawlDao AbbsSavingWithdrawlDao
        {
            get { return factory.AbbsSavingWithdrawlDao; }
        }
        public static IWithdrawlPostingPublicDao WithdrawlPostingPublicDao
        {
            get { return factory.WithdrawlPostingPublicDao; }
        }

        public static ICollectionSheetMasterOnlineDao CollectionSheetMasterOnlineDao
        {
            get { return factory.CollectionSheetMasterOnlineDao; }
        }
        public static ICollectionSheetPostingDao CollectionSheetPostingDao
        {
            get { return factory.CollectionSheetPostingDao; }
        }
        public static IMemberProtectionDepositDao MemberProtectionDepositDao
        {
            get { return factory.MemberProtectionDepositDao; }
        }
        public static IMemberProtectionDepositPostingDao MemberProtectionDepositPostingDao
        {
            get { return factory.MemberProtectionDepositPostingDao; }
        }
        public static IMemberProtectionBenefitDao MemberProtectionBenefitDao
        {
            get { return factory.MemberProtectionBenefitDao; }
        }
        public static ILiveProtectDepositDao LiveProtectDepositDao
        {
            get { return factory.LiveProtectDepositDao; }
        }
        public static ILiveProtectBenefitDao LiveProtectBenefitDao
        {
            get { return factory.LiveProtectBenefitDao; }
        }
        public static IStaffDisbursementDao StaffDisbursementDao
        {
            get { return factory.StaffDisbursementDao; }
        }
        public static IPublicSavingWithdrawlDao PublicSavingWithdrawlDao
        {
            get { return factory.PublicSavingWithdrawlDao; }
        }
        public static IPublicSavingWithdrawlPostingDao PublicSavingWithdrawlPostingDao
        {
            get { return factory.PublicSavingWithdrawlPostingDao; }
        }

        public static ILiveStockBenefitPostingDao LiveStockBenefitPostingDao
        {
            get { return factory.LiveStockBenefitPostingDao; }
        }
        public static ILiveStockDepositPostingDao LiveStockDepositPostingDao
        {
            get { return factory.LiveStockDepositPostingDao; }
        }
        public static IMemberProtectBenefitPostingDao MemberProtectBenefitPostingDao
        {
            get { return factory.MemberProtectBenefitPostingDao; }
        }
        public static ICallAbbsAdjustmentDao CallAbbsAdjustmentDao
        {
            get { return factory.CallAbbsAdjustmentDao; }
        }
        public static IDayEndProcessDao DayEndProcessDao
        {
            get { return factory.DayEndProcessDao; }
        }
        public static IDayBeginProcessDao DayBeginProcessDao
        {
            get { return factory.DayBeginProcessDao; }
        }
        public static ICollectionOfflineDateDao CollectionOfflineDateDao
        {
            get { return factory.CollectionOfflineDateDao; }
        }
        public static ICollectionSheetMasterOfflineDao CollectionSheetMasterOfflineDao
        {
            get { return factory.CollectionSheetMasterOfflineDao; }
        }
        #endregion


        #region "INVENTORY-TRANSACTION"

        public static ILocationDao LocationDao
        {
            get { return factory.LocationDao; }
        }

        public static ISupplierDao SupplierDao
        {
            get { return factory.SupplierDao; }
        }

        public static IOsItemDao OsItemDao
        {
            get { return factory.OsItemDao; }
        }
        public static IOpeningStockMasterDetailDao OpeningStockMasterDetailDao
        {
            get { return factory.OpeningStockMasterDetailDao; }
        }
        public static IInItemTransactionMasterDao InItemTransactionMasterDao
        {
            get { return factory.InItemTransactionMasterDao; }
        }
        public static IItemTransactionDetailDao ItemTransactionDetailDao
        {
            get { return factory.ItemTransactionDetailDao; }
        }

        public static IGoodReceiptSearchDao GoodReceiptSearchDao
        {
            get { return factory.GoodReceiptSearchDao; }
        }
        public static IGoodReceiptMasterDetailDao GoodReceiptMasterDetailDao
        {
            get { return factory.GoodReceiptMasterDetailDao; }
        }
        public static IGoodReceiptDetailDetailDao GoodReceiptDetailDetailDao
        {
            get { return factory.GoodReceiptDetailDetailDao; }
        }
        public static IGoodReceiptReturnDao GoodReceiptReturnDao
        {
            get { return factory.GoodReceiptReturnDao; }
        }
        public static IGoodReceiptReturnItemDao GoodReceiptReturnItemDao
        {
            get { return factory.GoodReceiptReturnItemDao; }
        }
        public static IGoodReceiptReturnMasterDetailDao GoodReceiptReturnMasterDetailDao
        {
            get { return factory.GoodReceiptReturnMasterDetailDao; }
        }
        public static IGoodReceiptReturnDetailDao GoodReceiptReturnDetailDao
        {
            get { return factory.GoodReceiptReturnDetailDao; }
        }
        public static IGoodReceiptEmployeeDao GoodReceiptEmployeeDao
        {
            get { return factory.GoodReceiptEmployeeDao; }
        }
        public static IMemoMasterDetailDao MemoMasterDetailDao
        {
            get { return factory.MemoMasterDetailDao; }
        }
        public static IMemoDetailDetailDao MemoDetailDetailDao
        {
            get { return factory.MemoDetailDetailDao; }
        }
        public static IMemoReturnReferenceNoDao MemoReturnReferenceNoDao
        {
            get { return factory.MemoReturnReferenceNoDao; }
        }
        public static IMemoReturnMasterDetailDao MemoReturnMasterDetailDao
        {
            get { return factory.MemoReturnMasterDetailDao; }
        }
        public static IMemoReturnDetailDetailDao MemoReturnDetailDetailDao
        {
            get { return factory.MemoReturnDetailDetailDao; }
        }
        public static IDamageLostMasterDetailDao DamageLostMasterDetailDao
        {
            get { return factory.DamageLostMasterDetailDao; }
        }
        public static IDamageLostDetailDetailDao DamageLostDetailDetailDao
        {
            get { return factory.DamageLostDetailDetailDao; }
        }
        public static IAssetItemDao AssetItemDao
        {
            get { return factory.AssetItemDao; }
        }
        public static IUserOfficeDao UserOfficeDao
        {
            get { return factory.UserOfficeDao; }
        }
        public static IInfFaAssetDao InfFaAssetDao
        {
            get { return factory.InfFaAssetDao; }
        }
        public static IDepreciationDao DepreciationDao
        {
            get { return factory.DepreciationDao; }
        }
        public static IDepreciationDetailDao DepreciationDetailDao
        {
            get { return factory.DepreciationDetailDao; }
        }
        public static IAssetMaintenanceDetailDao AssetMaintenanceDetailDao
        {
            get { return factory.AssetMaintenanceDetailDao; }
        }
        public static IAssetDao AssetDao
        {
            get { return factory.AssetDao; }
        }
        public static IFaAssetSendReceiptDao FaAssetSendReceiptDao
        {
            get { return factory.FaAssetSendReceiptDao; }
        }
        public static IAssetDetailDao AssetDetailDao
        {
            get { return factory.AssetDetailDao; }
        }
        public static IMemoApprovalDetailDao MemoApprovalDetailDao
        {
            get { return factory.MemoApprovalDetailDao; }
        }

        public static IOpeningStockDetailDetailDao OpeningStockDetailDetailDao
        {
            get { return factory.OpeningStockDetailDetailDao; }
        }
        public static IFaMaintenanceDao FaMaintenanceDao
        {
            get { return factory.FaMaintenanceDao; }
        }
        public static IMemoApprovalMasterDetailDao MemoApprovalMasterDetailDao
        {
            get { return factory.MemoApprovalMasterDetailDao; }
        }
        public static ILoanTransferToClientDao LoanTransferToClientDao
        {
            get { return factory.LoanTransferToClientDao; }
        }
        public static IMemoApprovalDao MemoApprovalDao
        {
            get { return factory.MemoApprovalDao; }
        }
        public static IAssetSendReceiptDetailDao AssetSendReceiptDetailDao
        {
            get { return factory.AssetSendReceiptDetailDao; }
        }
       
        #endregion

        #region "HUMAN RESOURCE"

        public static IDesignationDao DesignationDao
        {
            get
            {
                return factory.DesignationDao;
            }
        }

        public static IPostDao PostDao
        {
            get
            {
                return factory.PostDao;
            }
        }




        //TRANSACTION
        public static IEmployeeAllowanceAmountDao EmployeeAllowanceAmountDao
        {
            get { return factory.EmployeeAllowanceAmountDao; }
        }
        public static IEmployeeAllowanceDetailDao EmployeeAllowanceDetailDao
        {
            get { return factory.EmployeeAllowanceDetailDao; }
        }
        public static IEmployeeLocalAllowanceDao EmployeeLocalAllowanceDao
        {
            get { return factory.EmployeeLocalAllowanceDao; }
        }
        public static IEmployeeEducationDetailDao EmployeeEducationDetailDao
        {
            get { return factory.EmployeeEducationDetailDao; }
        }
        public static IEmployeeEducationDao EmployeeEducationDao
        {
            get { return factory.EmployeeEducationDao; }
        }
        public static IEmployeeTrainingDetailDao EmployeeTrainingDetailDao
        {
            get { return factory.EmployeeTrainingDetailDao; }
        }
        public static IEmployeeTrainingReceivedDao EmployeeTrainingReceivedDao
        {
            get { return factory.EmployeeTrainingReceivedDao; }
        }
        public static IEmployeeTransferDetailDao EmployeeTransferDetailDao
        {
            get { return factory.EmployeeTransferDetailDao; }
        }

        public static IEmployeeTransferDao EmployeeTransferDao
        {
            get { return factory.EmployeeTransferDao; }
        }
        public static IEmployeePromotionDetailDao EmployeePromotionDetailDao
        {
            get { return factory.EmployeePromotionDetailDao; }
        }
        public static IEmployeePromotionDao EmployeePromotionDao
        {
            get { return factory.EmployeePromotionDao; }
        }
        #endregion


    }
}
