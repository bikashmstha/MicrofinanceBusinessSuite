/*
 * File: app/controller/OfficeSetup.js
 *
 * This file was generated by Sencha Architect version 4.2.2.
 * http://www.sencha.com/products/architect/
 *
 * This file requires use of the Ext JS 4.1.x library, under independent license.
 * License of Sencha Architect does not include license for Ext JS 4.1.x. For more
 * details see http://www.sencha.com/license or contact license@sencha.com.
 *
 * This file will be auto-generated each and everytime you save your project.
 *
 * Do NOT hand edit this file.
 */

Ext.define('MyApp.controller.OfficeSetup', {
    extend: 'Ext.app.Controller',

    stores: [
        'OfficeSearchStore',
        'OfficeActiveInactiveStore',
        'OfficeTypeSearchStore',
        'DistrictSearchStore',
        'VdcSearchStore',
        'ParentOfficeSearchStore',
        'AccountHeadSearchStore'
    ],

    onBtnInsertOfficeInfoClick: function(button, e, eOpts) {
        var strMsgCode='';
        var strMsgDesc='';
        var strOfficeCode='';

        var officeCode=Ext.ComponentQuery.query('#txtOfficeCode')[0];
        var officeName=Ext.ComponentQuery.query('#txtOfficeName')[0];
        var officeTypeCode=Ext.ComponentQuery.query('#txtOfficeTypeCode')[0];
        var parentOfficeCode=Ext.ComponentQuery.query('#txtParentOfficeCode')[0];
        var districtCode=Ext.ComponentQuery.query('#txtDistrictCode')[0];
        var contactPerson=Ext.ComponentQuery.query('#txtContactPerson')[0];
        var phoneNo=Ext.ComponentQuery.query('#txtPhoneNo')[0];
        var faxNo=Ext.ComponentQuery.query('#txtFaxNo')[0];
        var email=Ext.ComponentQuery.query('#txtEmail')[0];
        var address=Ext.ComponentQuery.query('#txtAddress')[0];
        var areaGrading='';
        var officeAccCodePrefix=Ext.ComponentQuery.query('#txtOfficeAcPrefix')[0];
        var establishedDate=Ext.ComponentQuery.query('#txtEstablishedDateAD')[0];
        var vdcCode=Ext.ComponentQuery.query('#txtVdcNpCode')[0];
        var officeStatus=Ext.ComponentQuery.query('#chkActive')[0];
        var officeInactiveDate='';
        var createdBy='demo';
        var createdOn='12/12/2017';
        var centerRange='';
        var firstLoanDisburseDay='';
        var displaySeq='';
        var currentFiscalYear='';
        var lastFiscalyear='';
        var maxPeriodAdditionalLoan='';
        var compoulsaryCollectionAmt='';
        var maxNoOfLoan='';
        var controlFromCdms='';
        var budgetControlYn=Ext.ComponentQuery.query('#chkBudgetAllocation')[0];
        var locationCode='';
        var approvalRangeControl='';
        var currentYear='';
        var branchOnMW='';
        var interBranchAccountHead=Ext.ComponentQuery.query('#txtInterBranchAccountHeadCode')[0];
        var ABBSWithdrawLimit =Ext.ComponentQuery.query('#txtAbbsWithdrawLimit')[0];
        var ABBSDepositLimit=Ext.ComponentQuery.query('#txtAbbsDepositLimit')[0];
        var ABBSAllowYN=Ext.ComponentQuery.query('#chkAbbstransaction')[0];
        var migrationInProcess=Ext.ComponentQuery.query('#chkMigrationInProcess')[0];
        var budgetAllocationYN=Ext.ComponentQuery.query('#chkBudgetAllocation')[0];
        var transactionDate=Ext.ComponentQuery.query('#txtTransactionDateBS')[0];
        var autoAdjustmentCollsht=Ext.ComponentQuery.query('#chkAutoCollnSheet')[0];
        var autoAccountOnNonMem=Ext.ComponentQuery.query('#chkCreateAcOnNonMember')[0];

        var insertUpdate='I';
        var rowId=Ext.ComponentQuery.query('#hdnRowID')[0];

        var resultCode='';
        var resultMsg='';


        var office={

            OfficeCode :officeCode.getValue(),
            OfficeName: officeName.getValue(),
            OfficeTypeCode :officeTypeCode.getValue(),
            ParentOfficeCode :parentOfficeCode.getValue(),
            DistrictCode :districtCode.getValue(),
            ContactPerson :contactPerson.getValue(),
            PhoneNumber : phoneNo.getValue(),
            FaxNumber :faxNo.getValue(),
            Email :email.getValue(),
            Address :address.getValue(),
            AreaGrading: areaGrading,
            OfficeAccCodePrefix :officeAccCodePrefix.getValue(),
            EstablishedDate :establishedDate.getValue(),
            VdcCode :vdcCode.getValue(),
            CreatedBy :createdBy,
            CreatedOn :createdOn,
            MigratedDate :'',
            ThirdPartyData :'',
            OfficeStatus :officeStatus.getValue(),
            CenterRange :centerRange,
            FirstLoanDisburseDate :firstLoanDisburseDay,
            DisplaySeq :displaySeq,
            CurrentFiscalYear :currentFiscalYear,
            LastFiscalYear :lastFiscalyear,
            MaxPeriodAdditionalLoan :maxPeriodAdditionalLoan,
            CompulsoryCollectionAmt :compoulsaryCollectionAmt,
            MaxNoOfLoan :maxNoOfLoan,
            ControlFromCdms :controlFromCdms,
            BudgetControlYN :budgetControlYn.getValue()?'Y':'N',
            LocationCode :locationCode,
            ApprovalRangeControl :approvalRangeControl,
            CurrentYear :currentYear,
            BranchOnMW :branchOnMW,
            InterbranchAccountHead :interBranchAccountHead.getValue(),
            OfficeInactiveDate :officeInactiveDate,
            MigrationInProcess :migrationInProcess.getValue()?'Y':'N',
            TransactionDate :transactionDate.getValue(),
            DefaultLocationCode :'',
            ReportingGrp :'',
            AbbsAllowYN :ABBSAllowYN.getValue()?'Y':'N',
            AbbsWithdrawLimit :ABBSWithdrawLimit.getValue(),
            AbbsDepositLimit: ABBSDepositLimit.getValue(),
            SrgEnableYN :'',
            AutoAdjustmentCollSht :autoAdjustmentCollsht.getValue()?'Y':'N',
            OpenPublicMem :'',
            AutoAcOnNonMem :autoAccountOnNonMem.getValue()?'Y':'N',
            OfficeCategory :'',
            PRAccountHead :'',
            Action :'I',
             RowID:rowId.getValue(),
            BudgetAlloCationYN :budgetAllocationYN.getValue()

        };

        var waitSave = watiMsg("Saving Office .Please wait ...");
        Ext.Ajax.request({
            url: '../Handlers/GeneralMasterParameters/office/OfficeHandler.ashx',
            params: {
                method:'Save',
                office:JSON.stringify(office)
            },
            success: function ( response, request ) {
                         waitSave.hide();
                            var out=Ext.decode(response.responseText);
                            console.log(out);

                            if(out.success==="true")
                                {
                                   msg("SUCCESS",out.message);
                              }
                                else
                                    {
                                        msg("FAILURE",out.message);
                                    }
                            },
                            failure: function ( result, request ) {
                                waitSave.hide();
                                var out=Ext.decode(response.responseText);
                                msg("FAILURE",out.message);
                            }



                });




    },

    onBtnSearchOfficeClick: function(button, e, eOpts) {
         var officeCode=Ext.ComponentQuery.query('#txtSearchOfficeCode')[0];
                var officeName=Ext.ComponentQuery.query('#txtSearchOfficeName')[0];
        var office={
            OfficeCode:officeCode.getValue(),
            OfficeName:officeName.getValue()

        };

        Ext.Ajax.request({
            url: '../Handlers/GeneralMasterParameters/office/OfficeHandler.ashx',
            params: {
                method:'Search',
                  office:JSON.stringify(office)
            },
            success: function(response){


        var obj = Ext.decode(response.responseText);

                                console.log('resp',response);



              if(obj.success === "true")
                        {

                            var store=Ext.getStore('OfficeSearchStore');
                            store.removeAll();
                            store.add(obj.root);

                        }
                        else
                        {

                            msg("FAILURE",obj.message);
                        }






            }
        });
    },

    onBtnUpdateOfficeInfoClick: function(button, e, eOpts) {
        var strMsgCode='';
        var strMsgDesc='';
        var strOfficeCode='';

        var officeCode=Ext.ComponentQuery.query('#txtOfficeCode')[0];
        var officeName=Ext.ComponentQuery.query('#txtOfficeName')[0];
        var officeTypeCode=Ext.ComponentQuery.query('#txtOfficeTypeCode')[0];
        var parentOfficeCode=Ext.ComponentQuery.query('#txtParentOfficeCode')[0];
        var districtCode=Ext.ComponentQuery.query('#txtDistrictCode')[0];
        var contactPerson=Ext.ComponentQuery.query('#txtContactPerson')[0];
        var phoneNo=Ext.ComponentQuery.query('#txtPhoneNo')[0];
        var faxNo=Ext.ComponentQuery.query('#txtFaxNo')[0];
        var email=Ext.ComponentQuery.query('#txtEmail')[0];
        var address=Ext.ComponentQuery.query('#txtAddress')[0];
        var areaGrading='';
        var officeAccCodePrefix=Ext.ComponentQuery.query('#txtOfficeAcPrefix')[0];
        var establishedDate=Ext.ComponentQuery.query('#txtEstablishedDateAD')[0];
        var vdcCode=Ext.ComponentQuery.query('#txtVdcNpCode')[0];
        var officeStatus=Ext.ComponentQuery.query('#chkActive')[0];
        var officeInactiveDate='';
        var createdBy='demo';
        var createdOn='12/12/2017';
        var centerRange='';
        var firstLoanDisburseDay='';
        var displaySeq='';
        var currentFiscalYear='';
        var lastFiscalyear='';
        var maxPeriodAdditionalLoan='';
        var compoulsaryCollectionAmt='';
        var maxNoOfLoan='';
        var controlFromCdms='';
        var budgetControlYn=Ext.ComponentQuery.query('#chkBudgetAllocation')[0];
        var locationCode='';
        var approvalRangeControl='';
        var currentYear='';
        var branchOnMW='';
        var interBranchAccountHead=Ext.ComponentQuery.query('#txtInterBranchAccountHeadCode')[0];
        var ABBSWithdrawLimit =Ext.ComponentQuery.query('#txtAbbsWithdrawLimit')[0];
        var ABBSDepositLimit=Ext.ComponentQuery.query('#txtAbbsDepositLimit')[0];
        var ABBSAllowYN=Ext.ComponentQuery.query('#chkAbbstransaction')[0];
        var migrationInProcess=Ext.ComponentQuery.query('#chkMigrationInProcess')[0];
        var budgetAllocationYN=Ext.ComponentQuery.query('#chkBudgetAllocation')[0];
        var transactionDate=Ext.ComponentQuery.query('#txtTransactionDateBS')[0];
        var autoAdjustmentCollsht=Ext.ComponentQuery.query('#chkAutoCollnSheet')[0];
        var autoAccountOnNonMem=Ext.ComponentQuery.query('#chkCreateAcOnNonMember')[0];

        var insertUpdate='I';
        var rowId=Ext.ComponentQuery.query('#hdnRowID')[0];

        var resultCode='';
        var resultMsg='';


        var office={

            OfficeCode :officeCode.getValue(),
            OfficeName: officeName.getValue(),
            OfficeTypeCode :officeTypeCode.getValue(),
            ParentOfficeCode :parentOfficeCode.getValue(),
            DistrictCode :districtCode.getValue(),
            ContactPerson :contactPerson.getValue(),
            PhoneNumber : phoneNo.getValue(),
            FaxNumber :faxNo.getValue(),
            Email :email.getValue(),
            Address :address.getValue(),
            AreaGrading: areaGrading,
            OfficeAccCodePrefix :officeAccCodePrefix.getValue(),
            EstablishedDate :establishedDate.getValue(),
            VdcCode :vdcCode.getValue(),
            CreatedBy :createdBy,
            CreatedOn :createdOn,
            MigratedDate :'',
            ThirdPartyData :'',
            OfficeStatus :officeStatus.getValue(),
            CenterRange :centerRange,
            FirstLoanDisburseDate :firstLoanDisburseDay,
            DisplaySeq :displaySeq,
            CurrentFiscalYear :currentFiscalYear,
            LastFiscalYear :lastFiscalyear,
            MaxPeriodAdditionalLoan :maxPeriodAdditionalLoan,
            CompulsoryCollectionAmt :compoulsaryCollectionAmt,
            MaxNoOfLoan :maxNoOfLoan,
            ControlFromCdms :controlFromCdms,
            BudgetControlYN :budgetControlYn.getValue()?'Y':'N',
            LocationCode :locationCode,
            ApprovalRangeControl :approvalRangeControl,
            CurrentYear :currentYear,
            BranchOnMW :branchOnMW,
            InterbranchAccountHead :interBranchAccountHead.getValue(),
            OfficeInactiveDate :officeInactiveDate,
            MigrationInProcess :migrationInProcess.getValue()?'Y':'N',
            TransactionDate :transactionDate.getValue(),
            DefaultLocationCode :'',
            ReportingGrp :'',
            AbbsAllowYN :ABBSAllowYN.getValue()?'Y':'N',
            AbbsWithdrawLimit :ABBSWithdrawLimit.getValue(),
            AbbsDepositLimit: ABBSDepositLimit.getValue(),
            SrgEnableYN :'',
            AutoAdjustmentCollSht :autoAdjustmentCollsht.getValue()?'Y':'N',
            OpenPublicMem :'',
            AutoAcOnNonMem :autoAccountOnNonMem.getValue()?'Y':'N',
            OfficeCategory :'',
            PRAccountHead :'',
            Action :'U',
            RowID:rowId.getValue(),
            BudgetAlloCationYN :budgetAllocationYN.getValue()

        };

        var waitSave = watiMsg("Updating Office .Please wait ...");

        Ext.Ajax.request({
            url: '../Handlers/GeneralMasterParameters/office/OfficeHandler.ashx',
            params: {
                method:'Save',
                office:JSON.stringify(office)
            },
            success: function ( response, request ) {
                         waitSave.hide();
                            var out=Ext.decode(response.responseText);
                            console.log(out);

                            if(out.success==="true")
                                {
                                   msg("SUCCESS",out.message);
                              }
                                else
                                    {
                                        msg("FAILURE",out.message);
                                    }
                            },
                            failure: function ( result, request ) {
                                waitSave.hide();
                                var out=Ext.decode(response.responseText);
                                msg("FAILURE",out.message);
                            }



                });

    },

    onBtnDeleteOfficeInfoClick: function(button, e, eOpts) {
        var strMsgCode='';
        var strMsgDesc='';
        var strOfficeCode='';

        var officeCode=Ext.ComponentQuery.query('#txtOfficeCode')[0];
        var officeName=Ext.ComponentQuery.query('#txtOfficeName')[0];
        var officeTypeCode=Ext.ComponentQuery.query('#txtOfficeTypeCode')[0];
        var parentOfficeCode=Ext.ComponentQuery.query('#txtParentOfficeCode')[0];
        var districtCode=Ext.ComponentQuery.query('#txtDistrictCode')[0];
        var contactPerson=Ext.ComponentQuery.query('#txtContactPerson')[0];
        var phoneNo=Ext.ComponentQuery.query('#txtPhoneNo')[0];
        var faxNo=Ext.ComponentQuery.query('#txtFaxNo')[0];
        var email=Ext.ComponentQuery.query('#txtEmail')[0];
        var address=Ext.ComponentQuery.query('#txtAddress')[0];
        var areaGrading='';
        var officeAccCodePrefix=Ext.ComponentQuery.query('#txtOfficeAcPrefix')[0];
        var establishedDate=Ext.ComponentQuery.query('#txtEstablishedDateAD')[0];
        var vdcCode=Ext.ComponentQuery.query('#txtVdcNpCode')[0];
        var officeStatus='N';
        var officeInactiveDate='';
        var createdBy='demo';
        var createdOn='12/12/2017';
        var centerRange='';
        var firstLoanDisburseDay='';
        var displaySeq='';
        var currentFiscalYear='';
        var lastFiscalyear='';
        var maxPeriodAdditionalLoan='';
        var compoulsaryCollectionAmt='';
        var maxNoOfLoan='';
        var controlFromCdms='';
        var budgetControlYn=Ext.ComponentQuery.query('#chkBudgetAllocation')[0];
        var locationCode='';
        var approvalRangeControl='';
        var currentYear='';
        var branchOnMW='';
        var interBranchAccountHead=Ext.ComponentQuery.query('#txtInterBranchAccountHeadCode')[0];
        var ABBSWithdrawLimit =Ext.ComponentQuery.query('#txtAbbsWithdrawLimit')[0];
        var ABBSDepositLimit=Ext.ComponentQuery.query('#txtAbbsDepositLimit')[0];
        var ABBSAllowYN=Ext.ComponentQuery.query('#chkAbbstransaction')[0];
        var migrationInProcess=Ext.ComponentQuery.query('#chkMigrationInProcess')[0];
        var budgetAllocationYN=Ext.ComponentQuery.query('#chkBudgetAllocation')[0];
        var transactionDate=Ext.ComponentQuery.query('#txtTransactionDateBS')[0];
        var autoAdjustmentCollsht=Ext.ComponentQuery.query('#chkAutoCollnSheet')[0];
        var autoAccountOnNonMem=Ext.ComponentQuery.query('#chkCreateAcOnNonMember')[0];

        var insertUpdate='D';
        var rowId=Ext.ComponentQuery.query('#hdnRowID')[0];

        var resultCode='';
        var resultMsg='';


        var office={

            OfficeCode :officeCode.getValue(),
            OfficeName: officeName.getValue(),
            OfficeTypeCode :officeTypeCode.getValue(),
            ParentOfficeCode :parentOfficeCode.getValue(),
            DistrictCode :districtCode.getValue(),
            ContactPerson :contactPerson.getValue(),
            PhoneNumber : phoneNo.getValue(),
            FaxNumber :faxNo.getValue(),
            Email :email.getValue(),
            Address :address.getValue(),
            AreaGrading: areaGrading,
            OfficeAccCodePrefix :officeAccCodePrefix.getValue(),
            EstablishedDate :establishedDate.getValue(),
            VdcCode :vdcCode.getValue(),
            CreatedBy :createdBy,
            CreatedOn :createdOn,
            MigratedDate :'',
            ThirdPartyData :'',
            OfficeStatus :'I',
            CenterRange :centerRange,
            FirstLoanDisburseDate :firstLoanDisburseDay,
            DisplaySeq :displaySeq,
            CurrentFiscalYear :currentFiscalYear,
            LastFiscalYear :lastFiscalyear,
            MaxPeriodAdditionalLoan :maxPeriodAdditionalLoan,
            CompulsoryCollectionAmt :compoulsaryCollectionAmt,
            MaxNoOfLoan :maxNoOfLoan,
            ControlFromCdms :controlFromCdms,
            BudgetControlYN :budgetControlYn.getValue()?'Y':'N',
            LocationCode :locationCode,
            ApprovalRangeControl :approvalRangeControl,
            CurrentYear :currentYear,
            BranchOnMW :branchOnMW,
            InterbranchAccountHead :interBranchAccountHead.getValue(),
            OfficeInactiveDate :officeInactiveDate,
            MigrationInProcess :migrationInProcess.getValue()?'Y':'N',
            TransactionDate :transactionDate.getValue(),
            DefaultLocationCode :'',
            ReportingGrp :'',
            AbbsAllowYN :ABBSAllowYN.getValue()?'Y':'N',
            AbbsWithdrawLimit :ABBSWithdrawLimit.getValue(),
            AbbsDepositLimit: ABBSDepositLimit.getValue(),
            SrgEnableYN :'',
            AutoAdjustmentCollSht :autoAdjustmentCollsht.getValue()?'Y':'N',
            OpenPublicMem :'',
            AutoAcOnNonMem :autoAccountOnNonMem.getValue()?'Y':'N',
            OfficeCategory :'',
            PRAccountHead :'',
            Action :'U',
            RowID:rowId.getValue(),
            BudgetAlloCationYN :budgetAllocationYN.getValue()

        };

        var waitSave = watiMsg("Updating Office .Please wait ...");

        Ext.Ajax.request({
            url: '../Handlers/GeneralMasterParameters/office/OfficeHandler.ashx',
            params: {
                method:'Save',
                office:JSON.stringify(office)
            },
             success: function ( response, request ) {
                         waitSave.hide();
                            var out=Ext.decode(response.responseText);
                            console.log(out);

                            if(out.success==="true")
                                {
                                   msg("SUCCESS",out.message);
                              }
                                else
                                    {
                                        msg("FAILURE",out.message);
                                    }
                            },
                            failure: function ( result, request ) {
                                waitSave.hide();
                                var out=Ext.decode(response.responseText);
                                msg("FAILURE",out.message);
                            }



                });



    },

    onTxtOfficeTypeCodeAfterRender: function(component, eOpts) {
        component.getEl().on('dblclick', function(){
             var winPopup = Ext.create('MyApp.view.SelectOfficeTypePopUp',{

                });

                winPopup.extraParam={param:null};
                winPopup.show();
          });
    },

    onTxtDistrictCodeAfterRender: function(component, eOpts) {
        component.getEl().on('dblclick', function(){
             var winPopup = Ext.create('MyApp.view.SelectDistrictPopup',{

                });

                winPopup.extraParam={param:null};
                winPopup.show();
          });

    },

    onTxtVdcNpCodeAfterRender: function(component, eOpts) {
        component.getEl().on('dblclick', function(){
             var winPopup = Ext.create('MyApp.view.SelectVdcPopup',{

                });

                winPopup.extraParam={param:null};
                winPopup.show();
          });
    },

    onTxtParentOfficeCodeAfterRender: function(component, eOpts) {
        component.getEl().on('dblclick', function(){
             var winPopup = Ext.create('MyApp.view.SearchOfficePopup',{

                });

                winPopup.extraParam={param:null};
                winPopup.show();
          });
    },

    onTxtInterBranchAccountHeadCodeAfterRender: function(component, eOpts) {
        component.getEl().on('dblclick', function(){
             var winPopup = Ext.create('MyApp.view.SelectInterBranchAccountHeadPopup',{

                });

                winPopup.extraParam={param:null};
                winPopup.show();
          });
    },

    init: function(application) {
        this.control({
            "#BtnInsertOfficeInfo": {
                click: this.onBtnInsertOfficeInfoClick
            },
            "#btnSearchOffice": {
                click: this.onBtnSearchOfficeClick
            },
            "#btnUpdateOfficeInfo": {
                click: this.onBtnUpdateOfficeInfoClick
            },
            "#btnDeleteOfficeInfo": {
                click: this.onBtnDeleteOfficeInfoClick
            },
            "#txtOfficeTypeCode": {
                afterrender: this.onTxtOfficeTypeCodeAfterRender
            },
            "#txtDistrictCode": {
                afterrender: this.onTxtDistrictCodeAfterRender
            },
            "#txtVdcNpCode": {
                afterrender: this.onTxtVdcNpCodeAfterRender
            },
            "#txtParentOfficeCode": {
                afterrender: this.onTxtParentOfficeCodeAfterRender
            },
            "#txtInterBranchAccountHeadCode": {
                afterrender: this.onTxtInterBranchAccountHeadCodeAfterRender
            }
        });
    }

});
