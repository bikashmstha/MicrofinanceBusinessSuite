/*
 * File: app/controller/MFLoanDisbursement.js
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

Ext.define('MyApp.controller.MFLoanDisbursement', {
    extend: 'Ext.app.Controller',

    stores: [
        'CenterShortStore',
        'MFLoanEditMemberCodeStore',
        'LoanHeadingPopupStore',
        'LoanPurposePopupStore',
        'ContraAccountStore',
        'AdjustToSavingStore',
        'InstallmentTypeRefShortStore',
        'ReferenceShortStore',
        'InterestRateRefShortStore',
        'InterestCalcMethodStore',
        'LoanStatusStore',
        'MFLoanNoSearchStore',
        'MFLoanDisbursementSearchStore',
        'FundingAgencyStore'
    ],

    onTxtMemberCodeAfterRender: function(component, eOpts) {
         component.getEl().on('dblclick', function(){
             var winPopup = Ext.create('MyApp.view.SelectMemberMFPopup',{

                });

                winPopup.extraParam={param:null};
                winPopup.show();
          });

    },

    onTxtLoanHeadingCodeAfterRender: function(component, eOpts) {
          component.getEl().on('dblclick', function(){
             var winPopup = Ext.create('MyApp.view.SelectLoanHeadingPopup',{

                });

                winPopup.extraParam={param:null};
                winPopup.show();
          });

    },

    onTxtLoanPurposeCodeAfterRender: function(component, eOpts) {

          component.getEl().on('dblclick', function(){
             var winPopup = Ext.create('MyApp.view.SelectLoanPurposePopup',{

                });

                winPopup.extraParam={param:null};
                winPopup.show();
          });

    },

    onDdlAdjustSavingSelect: function(combo, records, eOpts) {
        //console.log(records);
        Ext.ComponentQuery.query('#ddlContraAcc')[0].setValue(records[0].data.AacountCode);
        Ext.ComponentQuery.query('#ddlContraAcc')[0].AccountNo= records[0].data.AccountNo;
    },

    onBtnDisburseLoanClick: function(button, e, eOpts) {
        var objLD={
            LoanDate:Ext.ComponentQuery.query('#txtLoanDateAD')[0].getValue(),
        LoanMaturityDate:Ext.ComponentQuery.query('#txtMaturityDateAD')[0].getValue(),
        LoanProductCode:Ext.ComponentQuery.query('#txtLoanHeadingCode')[0].getValue(),
        ClientNo:Ext.ComponentQuery.query('#txtMemberCode')[0].ClientNo,
        LoanPurposeCode:Ext.ComponentQuery.query('#txtLoanPurposeCode')[0].getValue(),
        ApprovedLoanAmount:Ext.ComponentQuery.query('#txtAppLoanAmt')[0].getValue(),
        TotalLoanAmount:Ext.ComponentQuery.query('#txtTotalLoanTaken')[0].getValue(),
        LoanPeriodType:Ext.ComponentQuery.query('#ddlLoanPeriodYM')[0].getValue(),
        LoanPeriod:Ext.ComponentQuery.query('#txtLoanPeriod')[0].getValue(),
        GraceDays:Ext.ComponentQuery.query('#txtGraceDays')[0].getValue(),
        EmployeeId:Ext.ComponentQuery.query('#txtFieldAssistantCode')[0].getValue(),
        InterestRate:Ext.ComponentQuery.query('#ddlInterestRate')[0].getValue(),
        InterestCalcMethod:Ext.ComponentQuery.query('#ddlInterestCalcMethod')[0].getValue(),
        LoanCloseDate:'',//Ext.ComponentQuery.query('#')[0].getValue(),
        LoanStatus:Ext.ComponentQuery.query('#ddlLoanStatus')[0].getValue(),
        Rating:'',//Ext.ComponentQuery.query('#')[0].getValue(),
        InstallmentAmount:Ext.ComponentQuery.query('#txtInstallmentAmt')[0].getValue(),
        RefAccountNo:'',//Ext.ComponentQuery.query('#')[0].getValue(),
        InstallmentPeriodType:Ext.ComponentQuery.query('#ddlInstallmentFrequency')[0].getValue(),
        InstallmentPeriod:Ext.ComponentQuery.query('#txtInstallmentFrequency')[0].getValue(),
        PrincipalArrear:'0',//Ext.ComponentQuery.query('#')[0].getValue(),
        PrincipalAmount:'0',//Ext.ComponentQuery.query('#')[0].getValue(),
        YearNo:Ext.ComponentQuery.query('#txtLoanYear')[0].getValue(),
        WithdrawalNo:'',//Ext.ComponentQuery.query('#')[0].getValue(),
        ChkAdjustSaving:Ext.ComponentQuery.query('#chkAdjustSaving')[0].getValue()?'Y':'N',
        SavingAccountNo:Ext.ComponentQuery.query('#ddlContraAcc')[0].AccountNo,
        InsurancePolicyNo:Ext.ComponentQuery.query('#txtPolicyNo')[0].getValue(),
        TranOfficeCode:getOfficeCode(),
        FixedPrincipalAmount:Ext.ComponentQuery.query('#txtFixedPrincipleAmt')[0].getValue(),
        FirstInstallDate:Ext.ComponentQuery.query('#txt1stInstallDateAD')[0].getValue(),
        ClientCenter:'C',//Ext.ComponentQuery.query('#')[0].getValue(),
        FixedInterestAmount:Ext.ComponentQuery.query('#txtFixedInterestAmt')[0].getValue(),
        ContraAccount:Ext.ComponentQuery.query('#ddlContraAcc')[0].getValue(),
        Deduction1Code:'',//Ext.ComponentQuery.query('#')[0].getValue(),
        Deduction1Desc:'Deduction1',//Ext.ComponentQuery.query('#')[0].getValue(),
        DeductionAmount1:'',//Ext.ComponentQuery.query('#')[0].getValue(),
        Deduction2Code:'',//Ext.ComponentQuery.query('#')[0].getValue(),
        Deduction2Desc:'Deduction2',//Ext.ComponentQuery.query('#')[0].getValue(),
        DeductionAmount2:'',//Ext.ComponentQuery.query('#')[0].getValue(),
        Deduction3Code:'',//Ext.ComponentQuery.query('#')[0].getValue(),
        Deduction3Desc:'Deduction3',//Ext.ComponentQuery.query('#')[0].getValue(),
        DeductionAmount3:'',//Ext.ComponentQuery.query('#')[0].getValue(),
        Deduction4Code:'',//Ext.ComponentQuery.query('#')[0].getValue(),
        Deduction4Desc:'Deduction4',//Ext.ComponentQuery.query('#')[0].getValue(),
        DeductionAmount4:'',//Ext.ComponentQuery.query('#')[0].getValue(),
        NoOfInstallment:Ext.ComponentQuery.query('#txtNoOfInstallment')[0].getValue(),
        FundingAgencyCode:Ext.ComponentQuery.query('#ddlFundingAgency')[0].getValue(),
        User1:getCurrentUser(),
        InsertUpdate:'I',
        OutFiscalYear:getFiscalYear(),
        OutLoanNo:'',
        OutLoanDno:''
        };


         var waitSave = watiMsg('Saving. Please wait ...');
        Ext.Ajax.request({
             url:'../Handlers/Finance/Transaction/LoanTransaction/MfLoanDisbursementHandler.ashx',
             params:{method:'Save',mfLoanDisbursement:JSON.stringify(objLD)},
             success: function ( result, request ) {
        waitSave.hide();
                  var out = Ext.decode(result.responseText);
        				if(out.success==='true'){
        					msg('SUCCESS',out.message);
        						}

        				else{msg('FAILURE',out.message);


                  }
             },
             failure: function(form, action) {
        waitSave.hide();var out=Ext.decode(response.responseText);msg('FAILURE',out.message);     }
        });
    },

    onBtnDeleteClick: function(button, e, eOpts) {
        var objLD={
        LoanDate:Ext.ComponentQuery.query('#txtLoanDateAD')[0].getValue(),
        LoanMaturityDate:Ext.ComponentQuery.query('#txtMaturityDateAD')[0].getValue(),
        LoanProductCode:Ext.ComponentQuery.query('#txtLoanHeadingCode')[0].getValue(),
        ClientNo:Ext.ComponentQuery.query('#grdMFLoanDisbursement')[0].ClientNo,
        LoanPurposeCode:Ext.ComponentQuery.query('#txtLoanPurposeCode')[0].getValue(),
        ApprovedLoanAmount:Ext.ComponentQuery.query('#txtAppLoanAmt')[0].getValue(),
        TotalLoanAmount:Ext.ComponentQuery.query('#txtTotalLoanTaken')[0].getValue(),
        LoanPeriodType:Ext.ComponentQuery.query('#ddlLoanPeriodYM')[0].getValue(),
        LoanPeriod:Ext.ComponentQuery.query('#txtLoanPeriod')[0].getValue(),
        GraceDays:Ext.ComponentQuery.query('#txtGraceDays')[0].getValue(),
        EmployeeId:Ext.ComponentQuery.query('#txtFieldAssistantCode')[0].getValue(),
        InterestRate:Ext.ComponentQuery.query('#ddlInterestRate')[0].getValue(),
        InterestCalcMethod:Ext.ComponentQuery.query('#ddlInterestCalcMethod')[0].getValue(),
        LoanCloseDate:'',//Ext.ComponentQuery.query('#')[0].getValue(),
        LoanStatus:Ext.ComponentQuery.query('#ddlLoanStatus')[0].getValue(),
        Rating:'',//Ext.ComponentQuery.query('#')[0].getValue(),
        InstallmentAmount:Ext.ComponentQuery.query('#txtInstallmentAmt')[0].getValue(),
        RefAccountNo:'',//Ext.ComponentQuery.query('#')[0].getValue(),
        InstallmentPeriodType:Ext.ComponentQuery.query('#ddlInstallmentFrequency')[0].getValue(),
        InstallmentPeriod:Ext.ComponentQuery.query('#txtInstallmentFrequency')[0].getValue(),
        PrincipalArrear:'0',//Ext.ComponentQuery.query('#')[0].getValue(),
        PrincipalAmount:'0',//Ext.ComponentQuery.query('#')[0].getValue(),
        YearNo:Ext.ComponentQuery.query('#txtLoanYear')[0].getValue(),
        WithdrawalNo:'',//Ext.ComponentQuery.query('#')[0].getValue(),
        ChkAdjustSaving:Ext.ComponentQuery.query('#chkAdjustSaving')[0].getValue()?'Y':'N',
        SavingAccountNo:Ext.ComponentQuery.query('#ddlContraAcc')[0].AccountNo,
        InsurancePolicyNo:Ext.ComponentQuery.query('#txtPolicyNo')[0].getValue(),
        TranOfficeCode:getOfficeCode(),
        FixedPrincipalAmount:Ext.ComponentQuery.query('#txtFixedPrincipleAmt')[0].getValue(),
        FirstInstallDate:Ext.ComponentQuery.query('#txt1stInstallDateAD')[0].getValue(),
        ClientCenter:'C',//Ext.ComponentQuery.query('#')[0].getValue(),
        FixedInterestAmount:Ext.ComponentQuery.query('#txtFixedInterestAmt')[0].getValue(),
        ContraAccount:Ext.ComponentQuery.query('#ddlContraAcc')[0].getValue(),
        Deduction1Code:'',//Ext.ComponentQuery.query('#')[0].getValue(),
        Deduction1Desc:'Deduction1',//Ext.ComponentQuery.query('#')[0].getValue(),
        DeductionAmount1:'',//Ext.ComponentQuery.query('#')[0].getValue(),
        Deduction2Code:'',//Ext.ComponentQuery.query('#')[0].getValue(),
        Deduction2Desc:'Deduction2',//Ext.ComponentQuery.query('#')[0].getValue(),
        DeductionAmount2:'',//Ext.ComponentQuery.query('#')[0].getValue(),
        Deduction3Code:'',//Ext.ComponentQuery.query('#')[0].getValue(),
        Deduction3Desc:'Deduction3',//Ext.ComponentQuery.query('#')[0].getValue(),
        DeductionAmount3:'',//Ext.ComponentQuery.query('#')[0].getValue(),
        Deduction4Code:'',//Ext.ComponentQuery.query('#')[0].getValue(),
        Deduction4Desc:'Deduction4',//Ext.ComponentQuery.query('#')[0].getValue(),
        DeductionAmount4:'',//Ext.ComponentQuery.query('#')[0].getValue(),
        NoOfInstallment:Ext.ComponentQuery.query('#txtNoOfInstallment')[0].getValue(),
        FundingAgencyCode:Ext.ComponentQuery.query('#ddlFundingAgency')[0].getValue(),
        User1:getCurrentUser(),
        InsertUpdate:'D',
        OutFiscalYear:getFiscalYear(),
        OutLoanNo:Ext.ComponentQuery.query('#grdMFLoanDisbursement')[0].LoanNo,
        OutLoanDno:Ext.ComponentQuery.query('#txtLoanNo')[0].getValue()
        };


         var waitSave = watiMsg('Saving. Please wait ...');
        Ext.Ajax.request({
             url:'../Handlers/Finance/Transaction/LoanTransaction/MfLoanDisbursementHandler.ashx',
             params:{method:'Save',mfLoanDisbursement:JSON.stringify(objLD)},
             success: function ( result, request ) {
        waitSave.hide();
                  var out = Ext.decode(result.responseText);
        				if(out.success==='true'){
        					msg('SUCCESS',out.message);
        						}

        				else{msg('FAILURE',out.message);


                  }
             },
             failure: function(form, action) {
        waitSave.hide();var out=Ext.decode(response.responseText);msg('FAILURE',out.message);     }
        });
    },

    onTxtSearchLoanNoAfterRender: function(component, eOpts) {
        component.getEl().on('dblclick', function(){
             var winPopup = Ext.create('MyApp.view.SelectMFLoanNoPopup',{

                });

                winPopup.extraParam={param:null};
                winPopup.show();
          });

    },

    onBtnSearchClick: function(button, e, eOpts) {
        var waitSave = watiMsg('Loading Data. Please wait ...');
        Ext.Ajax.request({
            url:'../Handlers/Finance/Transaction/LoanTransaction/MfLoanDetailHandler.ashx',
            params:{method:'GetMfLoanDetail',offCode:getOfficeCode(),
                    clientName:null,//Ext.ComponentQuery.query('#txtMemberName')[0].getValue(),
                    loanNo : Ext.ComponentQuery.query('#txtSearchLoanNo')[0].getValue(),
                    loanDateFrom :Ext.ComponentQuery.query('#txtOpenDateFromBS')[0].getValue(),
                    loanDateTo :Ext.ComponentQuery.query('#txtOpenDateToBS')[0].getValue()
                   },
            success: function ( result, request ) {

                var obj = Ext.decode(result.responseText);
                if(obj.success === 'true'){
                    //console.log("Resu",obj.root);
                    var store =Ext.getStore('MFLoanDisbursementSearchStore');
                    store.removeAll();
                    store.add(obj.root);


                }else{msg('FAILURE','Could Not Load Data');}
                waitSave.hide();
            },
            failure: function(form, action) {
                msg("FAILURE","Could Not Load Data");
                waitSave.hide();
            }

        });
    },

    onFrmMFLoanDisbursementAfterRender: function(component, eOpts) {
        Ext.ComponentQuery.query('#txtLoanDateAD')[0].setValue(getMisDateAD());
        Ext.ComponentQuery.query('#txtLoanDateBS')[0].setValue(getMisDateBS());
        Ext.ComponentQuery.query('#txtOpenDateFromBS')[0].setValue(getMisDateBS());
        Ext.ComponentQuery.query('#txtOpenDateToBS')[0].setValue(getMisDateBS());

        //GET FOR CENTER CODE
        Ext.Ajax.request({
            url:'../Handlers/Finance/Maintenance/CenterHandler.ashx',
            params:{method:'GetTransferCenterList',offCode:getOfficeCode(),centerName:null,oldCenterCode:null
                   },
            success: function ( result, request ) {

                var obj = Ext.decode(result.responseText);
                if(obj.success === 'true'){
                    //console.log("Resu",obj.root);
                    var store =Ext.getStore('CenterShortStore');
                    store.removeAll();
                    store.add(obj.root);


                }else{msg('FAILURE','Could Not Load Data');}
            },
            failure: function(form, action) {
                msg("FAILURE","Could Not Load Data");    }
        });

        //get for contra account
        Ext.Ajax.request({
                            url:'../Handlers/Finance/Maintenance/AccountHeadEntryHandler.ashx',
                            params:{method:'GetContraAccount',offCode:getOfficeCode(), accountDesc:null
                },
                            success: function ( result, request ) {

                                var obj = Ext.decode(result.responseText);
                                if(obj.success === 'true'){
                                    //console.log("Resu",obj.root);
                                    var store =Ext.getStore('ContraAccountStore');
                                    store.removeAll();
                                    store.add(obj.root);
                                    Ext.ComponentQuery.query('#ddlContraAcc')[0].select('100000021000002');



                                }else{msg('FAILURE','Could Not Load Data');}
                            },
                            failure: function(form, action) {
                                msg("FAILURE","Could Not Load Data");    }
                        });


        //get for installment type

        Ext.Ajax.request({
                            url:'../Handlers/GeneralMasterParameters/References/MsRefrenceCodeDetailsHandler.ashx',
                            params:{method:'GetReferenceDetailListShort',referenceCode:'INSTALLMENT_PERIOD_TYPE'
                },
                            success: function ( result, request ) {

                                var obj = Ext.decode(result.responseText);
                                if(obj.success === 'true'){
                                    //console.log("Resu",obj.root);
                                    var store =Ext.getStore('InstallmentTypeRefShortStore');
                                    store.removeAll();
                                    store.add(obj.root);



                                }else{msg('FAILURE','Could Not Load Data');}
                            },
                            failure: function(form, action) {
                                msg("FAILURE","Could Not Load Data");    }
                        });
        //GET FOR LOAN PERIOD TYPE
        Ext.Ajax.request({
                            url:'../Handlers/GeneralMasterParameters/References/MsRefrenceCodeDetailsHandler.ashx',
                            params:{method:'GetReferenceDetailListShort',referenceCode:'LOAN_PERIOD_TYPE'
                },
                            success: function ( result, request ) {

                                var obj = Ext.decode(result.responseText);
                                if(obj.success === 'true'){
                                   // console.log("Resu",obj.root);
                                    var store =Ext.getStore('ReferenceShortStore');
                                    store.removeAll();
                                    store.add(obj.root);



                                }else{msg('FAILURE','Could Not Load Data');}
                            },
                            failure: function(form, action) {
                                msg("FAILURE","Could Not Load Data");    }
                        });

        //get for interest rate
        Ext.Ajax.request({
                            url:'../Handlers/GeneralMasterParameters/References/MsRefrenceCodeDetailsHandler.ashx',
                            params:{method:'GetReferenceDetailListShort',referenceCode:'MF_INTEREST_RATE'
                },
                            success: function ( result, request ) {

                                var obj = Ext.decode(result.responseText);
                                if(obj.success === 'true'){
                                    //console.log("Resu",obj.root);
                                    var store =Ext.getStore('InterestRateRefShortStore');
                                    store.removeAll();
                                    store.add(obj.root);



                                }else{msg('FAILURE','Could Not Load Data');}
                            },
                            failure: function(form, action) {
                                msg("FAILURE","Could Not Load Data");    }
                        });
        //GET FOR Interest calc Method

                Ext.Ajax.request({
                                    url:'../Handlers/GeneralMasterParameters/References/MsRefrenceCodeDetailsHandler.ashx',
                                    params:{method:'GetReferenceDetailListShort',referenceCode:'LOAN_INTEREST_CALC_METHOD'
                        },
                                    success: function ( result, request ) {

                                        var obj = Ext.decode(result.responseText);
                                        if(obj.success === 'true'){
                                           // console.log("Resu",obj.root);
                                            var store =Ext.getStore('InterestCalcMethodStore');
                                            store.removeAll();
                                            store.add(obj.root);



                                        }else{msg('FAILURE','Could Not Load Data');}
                                    },
                                    failure: function(form, action) {
                                        msg("FAILURE","Could Not Load Data");    }
                    });


                    //GET FOR Loan Status
                Ext.Ajax.request({
                                    url:'../Handlers/GeneralMasterParameters/References/MsRefrenceCodeDetailsHandler.ashx',
                                    params:{method:'GetReferenceDetailListShort',referenceCode:'LOAN_STATUS'
                        },
                                    success: function ( result, request ) {

                                        var obj = Ext.decode(result.responseText);
                                        if(obj.success === 'true'){
                                            //console.log("Resu",obj.root);
                                            var store =Ext.getStore('LoanStatusStore');
                                            store.removeAll();
                                            store.add(obj.root);



                                        }else{msg('FAILURE','Could Not Load Data');}
                                    },
                                    failure: function(form, action) {
                                        msg("FAILURE","Could Not Load Data");    }
                    });
        //get for funding agency

        var fundingAgencyStore=Ext.getStore('FundingAgencyStore');
                getFundingAgencies(function(data){
                    fundingAgencyStore.removeAll();
                    fundingAgencyStore.add(data.root);
                });
    },

    init: function(application) {
        this.control({
            "#txtMemberCode": {
                afterrender: this.onTxtMemberCodeAfterRender
            },
            "#txtLoanHeadingCode": {
                afterrender: this.onTxtLoanHeadingCodeAfterRender
            },
            "#txtLoanPurposeCode": {
                afterrender: this.onTxtLoanPurposeCodeAfterRender
            },
            "#ddlAdjustSaving": {
                select: this.onDdlAdjustSavingSelect
            },
            "#btnDisburseLoan": {
                click: this.onBtnDisburseLoanClick
            },
            "#btnDelete": {
                click: this.onBtnDeleteClick
            },
            "#txtSearchLoanNo": {
                afterrender: this.onTxtSearchLoanNoAfterRender
            },
            "#btnSearch": {
                click: this.onBtnSearchClick
            },
            "#frmMFLoanDisbursement": {
                afterrender: this.onFrmMFLoanDisbursementAfterRender
            }
        });
    }

});
