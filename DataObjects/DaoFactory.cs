using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects.Interfaces.Common;
using DataObjects.Interfaces.Finance;
using DataObjects.Interfaces.GeneralMasterParameters;
using DataObjects.Interfaces.HumanResource;
using DataObjects.Interfaces.Inventory;
using DataObjects.Interfaces.Maintenance;
using DataObjects.Interfaces.Supervisor;
using DataObjects.Security;



namespace DataObjects
{
    /// <summary>
    /// Abstract factory class that creates data access objects.
    /// </summary>
    /// <remarks>
    /// GoF Design Pattern: Factory.
    /// </remarks>
    public abstract class DaoFactory
    {

        #region "COMMON"
        public abstract IDateDao DateDao { get; }
        public abstract ICountryDao CountryDao { get; } 
        public abstract IDistrictDao DistrictDao { get; }
        public abstract IVdcDao VdcDao { get; }
        public abstract IFiscalYearDao FiscalYearDao { get; }


        #endregion

        #region "GENERAL MASTER PARAMETERS"
        //HOLIDAY
        public abstract IHolidayDao HolidayDao { get;  }
        public abstract IOfficeWiseHolidayDao OfficeWiseHolidayDao { get; } 

        //DEPARTMENT
        public abstract IDepartmentDao DepartmentDao { get; }
        public abstract IDepartmentMapDao DepartmentMapDao { get; }

        //OFFICE
        public abstract IOfficeDao OfficeDao { get; }
        public abstract IOfficeTypeDao OfficeTypeDao { get; }
        public abstract IOfficeMapDao OfficeMapDao { get; }
        public abstract IVdcCoverageByOfficeDao VdcCoverageByOfficeDao { get; }

        //MENU
        public abstract IMenuEntryDao MenuEntryDao { get; }
        public abstract IModuleDao ModuleDao { get; }
        public abstract ITabDao TabDao { get; }
        public abstract IReportDao ReportDao { get; }
 

        
        //CONTROL REFERENCE VALUES
        public abstract IMsControlValuesDao MsControlValuesDao { get; }
        public abstract IMsReferenceCodeMasterDao MsReferenceCodeMasterDao { get; }
        public abstract IMsReferenceCodeDetailsDao MsReferenceCodeDetailsDao { get; } 

        //CASTE/EDUCATION/OCCUPATION/ETHINCITY
        public abstract ICasteDetailDao CasteDetailDao { get; }
        public abstract IEducationDao EducationDao { get; }
        public abstract IOccupationDao OccupationDao { get; }
        public abstract IEthnicityInformationDao EthnicityInformationDao { get; }
        public abstract IEthnicityCasteInformationDao EthnicityCasteInformationDao { get; }

        public abstract IReligionDao ReligionDao { get; }

        #endregion

        #region SECURITY

        public abstract ILoginDao LoginDao { get; }
        public abstract GenericUserDao UserDao { get; }
        public abstract IRoleDao RoleDao { get; }
        
        #endregion

        #region "GENERAL DEFINITIONS"
        public abstract INarrationDao NarrationDao { get; }

        public abstract INepaliDateConversionDao NepaliDateConversionDao { get; }

        public abstract INepaliFiscalYearDao NepaliFiscalYearDao { get; }

        public abstract IInstallmentPeriodDao InstallmentPeriodDao { get; }

        public abstract ILoanInstallmentPeriodMapDao LoanInstallmentPeriodMapDao { get; }

        public abstract ILoanPeriodDao LoanPeriodDao { get; }

        public abstract ILoanProductPeriodMapDao LoanProductPeriodMapDao { get; }

        public abstract IGeneralDefinitionsUtilityDao GeneralDefinitionsUtilityDao { get; }


        #endregion

        #region "SUPERVISOR"
        public abstract IControlTableDao ControlTableDao { get; }
        //public abstract IDepartmentDao DepartmentDao { get; }
        public abstract IOfficeDepartmentDao OfficeDepartmentDao { get; }

        //EMPLOYEE
        public abstract IEmployeeDao EmployeeDao { get; }
        #endregion

        #region "ACCOUNT CONTROL"
        public abstract IAccountCategoryDao AccountCategoryDao { get; }
        public abstract IAccountSubCategoryDao AccountSubCategoryDao { get; }
        public abstract IGLVoucherTypeDao GLVoucherTypeDao { get; }
        public abstract IVoucherApprovalSecurityDao VoucherApprovalSecurityDao { get; } 
        #endregion

        #region "FINANCE-MAINTENANCE"
        //MAINTENANCE
        public abstract IAccountHeadEntryDao AccountHeadEntryDao { get; }
        public abstract ILoanDeductionTypeDao LoanDeductionTypeDao { get; }
        public abstract IMainInterestSchemeDao MainInterestSchemeDao { get; }
        public abstract ISavingMidTermInterestDao SavingMidTermInterest { get; }
        public abstract IABBSChargeDao ABBSChargeDao { get; }
        public abstract ICompulsoryAccountsEntryDao CompulsoryAccountsEntryDao { get; }
        public abstract IGroupDao GroupDao { get; }
        public abstract ISectorDao SectorDao { get; }
        public abstract ISubSectorDao SubSectorDao { get; }
        public abstract ILoanPurposeProductDetailDao LoanPurposeProductDetailDao { get; }
        public abstract ICenterDao CenterDao { get; }
        public abstract ICenterLovDao CenterLovDao { get; }
        public abstract IMemberDao MemberDao { get; }
        public abstract ILoanSectorDao LoanSectorDao { get; }
        public abstract ILoanSubSectorDao LoanSubSectorDao { get; }
        public abstract ILoanPurposeDao LoanPurposeDao { get; }
        public abstract ILoanPurposeProductsDao LoanPurposeProductsDao { get; }
        public abstract IInterestSchemeDao InterestSchemeDao { get; }
        public abstract IInterestSchemeMasterDao InterestSchemeMasterDao { get; }
        public abstract IInterestSchemeDetailDao InterestSchemeDetailDao { get; }
        public abstract ILoanProductAccountHeadDao LoanProductAccountHeadDao { get; }
        public abstract ISavingTypeDao SavingTypeDao { get; }
        public abstract ILoanProductDetailDao LoanProductDetailDao { get; }
        public abstract ILoanDeductionDetailDao LoanDeductionDetailDao { get; }
        public abstract ISavingProductAccountHeadDao SavingProductAccountHeadDao { get; }
        public abstract ISavingProductDetailDao SavingProductDetailDao { get; }



        #endregion

        #region "FINANCE-TRANSACTION"
        //MEMBER TRANSACTION
        public abstract ITransferWithinCenterDao TransferWithinCenterDao { get; }
        public abstract ITransferCenterToAnotherCenterDao TransferCenterToAnotherCenterDao { get; }
        public abstract IDropOutReasonDao DropOutReasonDao { get;  }
        public abstract IMemberCancellationRestoreDao MemberCancellationRestoreDao { get; }
        public abstract IMemberForCancellationDao MemberForCancellationDao { get; }

        //COLLECTION SHEET TRANSACTION
        public abstract ICenterDetailsFromCodeDao CenterDetailsFromCodeDao { get; }
        public abstract IOfflineCollectionCenterDao OfflineCollectionCenterDao { get; }
        public abstract IOnlineCollectionCenterDao OnlineCollectionCenterDao { get; }
        public abstract IGenerateSavingCollectionDao GenerateSavingCollectionDao { get; }
        public abstract ICollectionAdjustDao CollectionAdjustDao { get; }
        public abstract ISavingCollectionSheetDao SavingCollectionSheetDao { get; }
        public abstract ILoanCollectionDetailDao LoanCollectionDetailDao { get; }
        public abstract IEmployeeCenterCollectionDao EmployeeCenterCollectionDao { get; }
        public abstract IUnapprovedCollectionDao UnapprovedCollectionDao { get; }
        public abstract ICollectionSheetMasterDao CollectionSheetMasterDao { get; }
        

        //SAVING TRANSACTION
        public abstract ISavingProductDao SavingProductDao { get; }
        public abstract IClientSavingAccountDao ClientSavingAccountDao { get; }
        public abstract IAccountOpenDetailDao AccountOpenDetailDao { get; }
        public abstract IProductForDepositDao ProductForDepositDao { get; }
        public abstract IAccountForDepositDao AccountForDepositDao { get; }
        public abstract IMfDepositDetailDao MfDepositDetailDao { get; }
        public abstract IMfSavingDepositDao MfSavingDepositDao { get; }
        public abstract IMfWithdrawlDetailDao MfWithdrawlDetailDao { get; }
        public abstract IProductForWithdrawlDao ProductForWithdrawlDao { get; }
        public abstract IAccountForWithdrawlDao AccountForWithdrawlDao { get; }
        public abstract IMfSavingWithdrawDao MfSavingWithdrawDao { get; }
        public abstract IProductForAccountCloseDao ProductForAccountCloseDao { get; }
        public abstract IAccountForClosingDao AccountForClosingDao { get; }
        public abstract IAccountCloseDetailDao AccountCloseDetailDao { get; }
        public abstract ISavingAccountClosureDao SavingAccountClosureDao { get; }
        public abstract IMemberAccountOpenDao MemberAccountOpenDao { get; }
        public abstract IMemberForChequeDao MemberForChequeDao { get; }
        public abstract IChequeGenerateDetailDao ChequeGenerateDetailDao { get; }
        public abstract IGenerateChequeSequenceDao GenerateChequeSequenceDao { get; }


        //LOAN TRANSACTION
        public abstract ILoanMemberDao LoanMemberDao { get; }
        public abstract ILoanProductDao LoanProductDao { get; }
        public abstract IMfLoanPurposeDao MfLoanPurposeDao { get; }
        public abstract IMfAdjustSavingDao MfAdjustSavingDao { get; }
        public abstract IMfLoanSearchDao MfLoanSearchDao { get; }
        public abstract IMfLoanDetailDao MfLoanDetailDao { get; }
        public abstract IMfLoanDisbursementDao MfLoanDisbursementDao { get; }
        public abstract IMfLoanRepaymentDao MfLoanRepaymentDao { get; }
        public abstract IMfRepayAdjustSavingDao MfRepayAdjustSavingDao { get; }
        public abstract IMfRepaySearchLoanDao MfRepaySearchLoanDao { get; }
        public abstract IMfRepayDetailDao MfRepayDetailDao { get; }
        public abstract IMeLoanDisbursementDao MeLoanDisbursementDao { get; }
        public abstract IMeLoanProductDao MeLoanProductDao { get; }
        public abstract IFundingAgencyDao FundingAgencyDao { get; }
        public abstract ILoanCollateralDao LoanCollateralDao { get; }
        public abstract IMeLoanSearchDao MeLoanSearchDao { get; }
        public abstract IMeLoanDetailDao MeLoanDetailDao { get; }
        public abstract IMfAdditionalLoanDao MfAdditionalLoanDao { get; }
        public abstract IMfAdditionalLoanDetailDao MfAdditionalLoanDetailDao { get; }
        public abstract IMfAdditionalLoanDisbursementDao MfAdditionalLoanDisbursementDao { get; }
        public abstract IMeLoanRepayDao MeLoanRepayDao { get; }
        public abstract IMeLoanRepayDetailDao MeLoanRepayDetailDao { get; }
        public abstract IMeAdditionalLoanDao MeAdditionalLoanDao { get; }
        public abstract IMeAdditionalLoanDetailDao MeAdditionalLoanDetailDao { get; }
        public abstract IMeAdditionalLoanDisbursementDao MeAdditionalLoanDisbursementDao { get; }
        public abstract ILasMemberDao LasMemberDao { get; }
        public abstract ILoanAgainstSavingDisbursementDao LoanAgainstSavingDisbursementDao { get; }
        public abstract ILoanUtilizationEntryDao LoanUtilizationEntryDao { get; }
        public abstract IAdjustLoanIntPriPenNewDao AdjustLoanIntPriPenNewDao { get; }
        public abstract ILoanDao LoanDao { get; }
        public abstract IMfSavingDepositEditDao MfSavingDepositEditDao { get; }
        public abstract ILasProductDao LasProductDao { get; }
        public abstract ILoanLasSavingProductDao LoanLasSavingProductDao { get; }
        public abstract ILasLoanSearchDao LasLoanSearchDao { get; }
        public abstract ILasLoanDetailDao LasLoanDetailDao { get; }
        public abstract ILnUtilizationLoanDao LnUtilizationLoanDao { get; }
        public abstract ILnUtilizationDetailDao LnUtilizationDetailDao { get; }
        public abstract ILoanRepayAdjustLoanDao LoanRepayAdjustLoanDao { get; }
        public abstract ILoanProductDeductionDao LoanProductDeductionDao { get; }
        public abstract ILoanTransferToClientDao LoanTransferToClientDao { get; }
        public abstract ILoanInformationDao LoanInformationDao { get; }
        

        //EDIT TRANSACTION
        public abstract ILoanRepayAdjustRepayDao LoanRepayAdjustRepayDao { get; }
        public abstract ICalLoanBalanceStatusDao CalLoanBalanceStatusDao { get; }
        public abstract ILoanAdjustLoanDao LoanAdjustLoanDao { get; }
        public abstract ILoanTransferFromCenterDao LoanTransferFromCenterDao { get; }
        public abstract ILoanTransferFromClientDao LoanTransferFromClientDao { get; }
        public abstract ILoanTransferProductDao LoanTransferProductDao { get; }
        public abstract ILoanTransferFromLoanDao LoanTransferFromLoanDao { get; }
        public abstract ITransferLoanAccountDao TransferLoanAccountDao { get; }
        public abstract ISavingTransferFromCenterDao SavingTransferFromCenterDao { get; }
        public abstract ISavingTransferFromClientDao SavingTransferFromClientDao { get; }
        public abstract ISavingTransferFromAccountDao SavingTransferFromAccountDao { get; }
        public abstract ISavingTransferProcDao SavingTransferProcDao { get; }
        public abstract ITransferSavingAccountDao TransferSavingAccountDao { get; }
        public abstract IPubSavingProductDao PubSavingProductDao { get; }
        public abstract IAdjPubSavingAccountDao AdjPubSavingAccountDao { get; }
        public abstract IPubSavingAccountSearchDao PubSavingAccountSearchDao { get; }
        public abstract IPubSavingDepositDetailDao PubSavingDepositDetailDao { get; }
        public abstract IPublicSavingDepositDao PublicSavingDepositDao { get; }
        public abstract IPublicSavingWithdrawDao PublicSavingWithdrawDao { get; }
        public abstract IPublicSavingWithdrawProductDao PublicSavingWithdrawProductDao { get; }
        public abstract IPublicSavingWithdrawDetailDao PublicSavingWithdrawDetailDao { get; }
        public abstract IAdjustmentaccountforwithdrawDao AdjustmentaccountforwithdrawDao { get; }
        
        




        #endregion

        #region "FINANCE-TRANSACTION-II"
        //PUBLIC SAVING TRANSACTION
        public abstract IPublicClientDao PublicClientDao { get; }
        public abstract IPublicClientDetailDao PublicClientDetailDao { get; }
        public abstract IPublicMemberDao PublicMemberDao { get; }
        public abstract IPublicReferenceAccountDao PublicReferenceAccountDao { get; }
        public abstract IPublicAccountDetailDao PublicAccountDetailDao { get; }
        public abstract IPublicSavingAccountOpenDao PublicSavingAccountOpenDao { get; }
        public abstract IPublicSavingDepositAccountDao PublicSavingDepositAccountDao { get; }
        public abstract IPublicAdjustmentdepositaccountDao PublicAdjustmentdepositaccountDao { get; }
        public abstract IPublicAccountChequeDao PublicAccountChequeDao { get; }
        public abstract IPublicWithdrawWithAccountDao PublicWithdrawWithAccountDao { get; }
        public abstract IPublicAccountCloseProductDao PublicAccountCloseProductDao { get; }
        public abstract IPublicAccountCloseAccountDao PublicAccountCloseAccountDao { get; }
        public abstract IQueryOnSavingAccountCloseDao QueryOnSavingAccountCloseDao { get; }
        public abstract IPublicAccountCloseDetailDao PublicAccountCloseDetailDao { get; }
        public abstract IPublicSavingAccountClosureDao PublicSavingAccountClosureDao { get; }
        public abstract IPublicAccountChequeAccountDao PublicAccountChequeAccountDao { get; }
        public abstract IChequePrintDao ChequePrintDao { get; }
        public abstract IGroupBasedMemberDao GroupBasedMemberDao { get; }
        public abstract IPublicChequeNoDao PublicChequeNoDao { get; }
        public abstract IPublicChequeUpdateDao PublicChequeUpdateDao { get; }

        
        

        //STAFF LOAN TRANSACTION
        public abstract IEmployeeKycEmployeeDao EmployeeKycEmployeeDao { get; }
        public abstract IEmployeeKycClientDao EmployeeKycClientDao { get; }
        public abstract IEmployeeKycDetailDao EmployeeKycDetailDao { get; }
        public abstract IEmployeeKycInfoDao EmployeeKycInfoDao { get; }
        public abstract IStaffLoanDisbursementClientDao StaffLoanDisbursementClientDao { get; }
        public abstract IStaffLoanDisbursementProductDao StaffLoanDisbursementProductDao { get; }
        public abstract IStaffLoanDisbursementLoanDao StaffLoanDisbursementLoanDao { get; }
        public abstract IStaffLoanDisbursementDetailDao StaffLoanDisbursementDetailDao { get; }
        public abstract IStaffLoanDisbursementDao StaffLoanDisbursementDao { get; }
        public abstract IStaffLoanDisbursementOpeningDao StaffLoanDisbursementOpeningDao { get; }
        public abstract IStaffLoanRepayLoanDao StaffLoanRepayLoanDao { get; }
        public abstract IStaffLoanRepayAdjustmentSavingDao StaffLoanRepayAdjustmentSavingDao { get; }
        public abstract IStaffLoanAdjustmentDetailDao StaffLoanAdjustmentDetailDao { get; }
        public abstract IStaffLoanRepayDetailDao StaffLoanRepayDetailDao { get; }
        public abstract IStaffLoanRepaymentDao StaffLoanRepaymentDao { get; }
        public abstract IStaffAdditionalLoanDisbursementDao StaffAdditionalLoanDisbursementDao { get; }
        public abstract IStaffLoanAdditionalLoanDao StaffLoanAdditionalLoanDao { get; }
        public abstract IStaffLoanAdditionalScrLoanDao StaffLoanAdditionalScrLoanDao { get; }
        
        #endregion

        #region "FINANCE-ACCOUNT TRANSACTION"
        public abstract IContraBankAccountDao ContraBankAccountDao { get; }
        public abstract IParticularsDao ParticularsDao { get; }
        public abstract IVoucherAccountDao VoucherAccountDao { get; }
        public abstract IReceiptSearchVoucherDao ReceiptSearchVoucherDao { get; }
        public abstract IReceiptVoucherMasterDetailDao ReceiptVoucherMasterDetailDao { get; }
        public abstract IReceiptVoucherDetailDetailDao ReceiptVoucherDetailDetailDao { get; }
        public abstract IPaymentSearchVoucherDao PaymentSearchVoucherDao { get; }
        public abstract IBudgetLimitAmtDao BudgetLimitAmtDao { get; }
        public abstract IPaymentVoucherMasterDetailDao PaymentVoucherMasterDetailDao { get; }
        public abstract IPaymentVoucherDetailDetailDao PaymentVoucherDetailDetailDao { get; }
        public abstract IJvSearchVoucherDao JvSearchVoucherDao { get; }
        public abstract IJvMasterDetailDao JvMasterDetailDao { get; }
        public abstract IJvDtlDetailDao JvDtlDetailDao { get; }
        public abstract IGlTransactionMasterDao GlTransactionMasterDao { get; }
        public abstract IGlTransactionDetailDao GlTransactionDetailDao { get; }
        public abstract IReverseVoucherDao ReverseVoucherDao { get; }
        public abstract IReverseVoucherMasterDetailDao ReverseVoucherMasterDetailDao { get; }
        public abstract IReverseVoucherDetailDetailDao ReverseVoucherDetailDetailDao { get; }
        public abstract IVoucherApprovalMasterDao VoucherApprovalMasterDao { get; }
        public abstract IVoucherApprovalDetailDao VoucherApprovalDetailDao { get; }
        public abstract IApprovedGlTransactionDao ApprovedGlTransactionDao { get; }
        public abstract IRegenerateFiscalYearClosingDao RegenerateFiscalYearClosingDao { get; }
        public abstract IBudgetAllocationAccountDao BudgetAllocationAccountDao { get; }
        public abstract IBudgetAllocationDetailDetailDao BudgetAllocationDetailDetailDao { get; }
        public abstract IBudgetAllocationShareDetailDao BudgetAllocationShareDetailDao { get; }
        public abstract IBudgetAllocationMasterDao BudgetAllocationMasterDao { get; }
        public abstract IBudgetAllocationDetailDao BudgetAllocationDetailDao { get; }
        public abstract IBudgetAllocationShareDao BudgetAllocationShareDao { get; }
        
        //PROCESSING
        public abstract ILoanDisbursementDao LoanDisbursementDao { get; }
        public abstract ILoanDisbursementPostingDao LoanDisbursementPostingDao { get; }
        public abstract ILoanRepaymentDao LoanRepaymentDao { get; }
        public abstract ILoanRepaymentPostingDao LoanRepaymentPostingDao { get; }
        public abstract ISavingDepositDao SavingDepositDao { get; }
        public abstract ISavingDepositPostingDao SavingDepositPostingDao { get; }
        public abstract IAbbsSavingDepositDao AbbsSavingDepositDao { get; }
        public abstract IDepositPostingPublicDao DepositPostingPublicDao { get; }
        public abstract ISavingWithdrawlDao SavingWithdrawlDao { get; }
        public abstract ISavingWithdrawlPostingDao SavingWithdrawlPostingDao { get; }
        public abstract IAbbsSavingWithdrawlDao AbbsSavingWithdrawlDao { get; }
        public abstract IWithdrawlPostingPublicDao WithdrawlPostingPublicDao { get; }
        public abstract ICollectionSheetMasterOnlineDao CollectionSheetMasterOnlineDao { get; }
        public abstract ICollectionSheetPostingDao CollectionSheetPostingDao { get; }
        public abstract IMemberProtectionDepositDao MemberProtectionDepositDao { get; }
        public abstract IMemberProtectionDepositPostingDao MemberProtectionDepositPostingDao { get; }
        public abstract IMemberProtectionBenefitDao MemberProtectionBenefitDao { get; }
        public abstract ILiveProtectDepositDao LiveProtectDepositDao { get; }
        public abstract ILiveProtectBenefitDao LiveProtectBenefitDao { get; }
        public abstract IStaffDisbursementDao StaffDisbursementDao { get; }
        public abstract IPublicSavingWithdrawlDao PublicSavingWithdrawlDao { get; }
        public abstract IPublicSavingWithdrawlPostingDao PublicSavingWithdrawlPostingDao { get; }
        public abstract ILiveStockBenefitPostingDao LiveStockBenefitPostingDao { get; }
        public abstract ILiveStockDepositPostingDao LiveStockDepositPostingDao { get; }
        public abstract IMemberProtectBenefitPostingDao MemberProtectBenefitPostingDao { get; }
        public abstract ICallAbbsAdjustmentDao CallAbbsAdjustmentDao { get; }
        public abstract IDayEndProcessDao DayEndProcessDao { get; }
        public abstract IDayBeginProcessDao DayBeginProcessDao { get; }
        public abstract ICollectionOfflineDateDao CollectionOfflineDateDao { get; }
        public abstract ICollectionSheetMasterOfflineDao CollectionSheetMasterOfflineDao { get; }
        
        #endregion

        #region "INVENTORY"

        public abstract ILocationDao LocationDao { get; }
        public abstract ISupplierDao SupplierDao { get; }
        public abstract IOsItemDao OsItemDao { get; }
        public abstract IOpeningStockMasterDetailDao OpeningStockMasterDetailDao { get; }
        public abstract IInItemTransactionMasterDao InItemTransactionMasterDao { get; }
        public abstract IItemTransactionDetailDao ItemTransactionDetailDao { get; }
        public abstract IGoodReceiptSearchDao GoodReceiptSearchDao { get; }
        public abstract IGoodReceiptMasterDetailDao GoodReceiptMasterDetailDao { get; }
        public abstract IGoodReceiptDetailDetailDao GoodReceiptDetailDetailDao { get; }
        public abstract IGoodReceiptReturnDao GoodReceiptReturnDao { get; }
        public abstract IGoodReceiptReturnItemDao GoodReceiptReturnItemDao { get; }
        public abstract IGoodReceiptReturnMasterDetailDao GoodReceiptReturnMasterDetailDao { get; }
        public abstract IGoodReceiptReturnDetailDao GoodReceiptReturnDetailDao { get; }
        public abstract IGoodReceiptEmployeeDao GoodReceiptEmployeeDao { get; }
        public abstract IMemoMasterDetailDao MemoMasterDetailDao { get; }
        public abstract IMemoDetailDetailDao MemoDetailDetailDao { get; }
        public abstract IMemoReturnReferenceNoDao MemoReturnReferenceNoDao { get; }
        public abstract IMemoReturnMasterDetailDao MemoReturnMasterDetailDao { get; }
        public abstract IMemoReturnDetailDetailDao MemoReturnDetailDetailDao { get; }
        public abstract IDamageLostMasterDetailDao DamageLostMasterDetailDao { get; }
        public abstract IDamageLostDetailDetailDao DamageLostDetailDetailDao { get; }
        public abstract IAssetItemDao AssetItemDao { get; }
        public abstract IUserOfficeDao UserOfficeDao { get; }
        public abstract IInfFaAssetDao InfFaAssetDao { get; }
        public abstract IDepreciationDao DepreciationDao { get; }
        public abstract IDepreciationDetailDao DepreciationDetailDao { get; }
        public abstract IAssetMaintenanceDetailDao AssetMaintenanceDetailDao { get; }
        public abstract IAssetDao AssetDao { get; }
        public abstract IFaAssetSendReceiptDao FaAssetSendReceiptDao { get; }
        public abstract IAssetDetailDao AssetDetailDao { get; }
        public abstract IMemoApprovalDetailDao MemoApprovalDetailDao { get; }
        public abstract IOpeningStockDetailDetailDao OpeningStockDetailDetailDao { get; }
        public abstract IFaMaintenanceDao FaMaintenanceDao { get; }
        public abstract IMemoApprovalMasterDetailDao MemoApprovalMasterDetailDao { get; }
        public abstract IMemoApprovalDao MemoApprovalDao { get; }
        public abstract IAssetSendReceiptDetailDao AssetSendReceiptDetailDao { get; } 

        #endregion

        #region "HUMAN RESOURCE"
        public abstract IDesignationDao DesignationDao { get; }
        public abstract IPostDao PostDao { get; }



        //TRANSACTION
        public abstract IEmployeeAllowanceAmountDao EmployeeAllowanceAmountDao { get; }
        public abstract IEmployeeAllowanceDetailDao EmployeeAllowanceDetailDao { get; }
        public abstract IEmployeeLocalAllowanceDao EmployeeLocalAllowanceDao { get; }
        public abstract IEmployeeEducationDetailDao EmployeeEducationDetailDao { get; }
        public abstract IEmployeeEducationDao EmployeeEducationDao { get; }
        public abstract IEmployeeTrainingDetailDao EmployeeTrainingDetailDao { get; }
        public abstract IEmployeeTrainingReceivedDao EmployeeTrainingReceivedDao { get; }
        public abstract IEmployeeTransferDetailDao EmployeeTransferDetailDao { get; }
        public abstract IEmployeeTransferDao EmployeeTransferDao { get; }
        public abstract IEmployeePromotionDetailDao EmployeePromotionDetailDao { get; }
        public abstract IEmployeePromotionDao EmployeePromotionDao { get; }

        #endregion
    }

    
}
