/*
 * File: app/controller/MELoanRepayment.js
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

Ext.define('MyApp.controller.MELoanRepayment', {
    extend: 'Ext.app.Controller',

    stores: [
        'MELoanProductStore',
        'MeLoanRepayStore',
        'MEFieldAssistantStore',
        'ContraAccountStore',
        'MELoanSearchStore',
        'MeLoanRepaymentDetailsStore'
    ],

    onFrmMELoanRepaymentAfterRender: function(component, eOpts) {
        Ext.ComponentQuery.query('#txtPaymentDateAD')[0].setValue(getMisDateAD());
        Ext.ComponentQuery.query('#txtPaymentDateBS')[0].setValue(getMisDateBS());
        var productName ='';

                Ext.Ajax.request({
                    url: '../Handlers/Finance/Transaction/LoanTransaction/MeLoanProductHandler.ashx',
                    params: {
                        method:'GetMeLoanProduct'
                    },
                    success: function(response){

                    var data=Ext.decode(response.responseText);
                    var meLoanProductStore=Ext.getStore('MELoanProductStore');
                    meLoanProductStore.removeAll();
                    meLoanProductStore.add(data.root);


                }
                });
        var empName ='';


                Ext.Ajax.request({
                    url: '../Handlers/Supervisor/EmployeeHandler.ashx',
                    params: {
                        method:'GetFieldAssistants',
                        officeCode:getOfficeCode(),empName:empName
                    },
                    success: function(response){

                    var data=Ext.decode(response.responseText);
                    var meFieldAssistantStore=Ext.getStore('MEFieldAssistantStore');
                    meFieldAssistantStore.removeAll();
                    meFieldAssistantStore.add(data.root);


                }
                });
         Ext.Ajax.request({
                             url: '../Handlers/Finance/Maintenance/AccountHeadEntryHandler.ashx',
                            params: {
                                method:'GetContraAccount',
                                 offCode:getOfficeCode()

                            },
                            success: function(response){

                                var data=Ext.decode(response.responseText);
                                var contraAccountStore =Ext.getStore('ContraAccountStore');
                                contraAccountStore.removeAll();
                                contraAccountStore.add(data.root);

                            }
                        });

        Ext.Ajax.request({
                             url: '../Handlers/Finance/Transaction/LoanTransaction/MeLoanRepayHandler.ashx',
                            params: {
                                method:'GetMeLoanRepaySearch',
                                 offCode:getOfficeCode(),clientName:''

                            },
                            success: function(response){

                                var data=Ext.decode(response.responseText);
                                var meLoanSearchStore =Ext.getStore('MELoanSearchStore');
                                meLoanSearchStore.removeAll();
                                meLoanSearchStore.add(data.root);

                            }
                        });





    },

    onDdlLoanProductCodeChange: function(field, newValue, oldValue, eOpts) {
        var productCode = Ext.ComponentQuery.query("#ddlLoanProductCode")[0].getValue();
        var clientName='';

        Ext.Ajax.request({
                            url: '../Handlers/Finance/Transaction/LoanTransaction/MeLoanRepayHandler.ashx',
                            params: {
                                method:'GetMeLoanRepay',
                                offCode:getOfficeCode(),productCode:productCode,clientName:clientName
                            },
                            success: function(response){

                            var data=Ext.decode(response.responseText);
                            var meLoanRepayStore=Ext.getStore('MeLoanRepayStore');
                            meLoanRepayStore.removeAll();
                            meLoanRepayStore.add(data.root);
                            }
        });


    },

    onBtnSearchClick: function(button, e, eOpts) {
        var repaymentNo = Ext.ComponentQuery.query("#ddlLoanProductCode")[0].getValue();
        var clientName='';
        var loanDno=Ext.ComponentQuery.query("#ddlLoanNoS")[0].getValue();
        var dateFrom=Ext.ComponentQuery.query("#txtPaymentDateBSS")[0].getValue();
        var dateTo='';


                Ext.Ajax.request({
                                    url: '../Handlers/Finance/Transaction/LoanTransaction/MeLoanRepayDetailHandler.ashx',
                                    params: {
                                        method:'GetMeLoanRepayDetail',
                                        offCode:getOfficeCode(),clientName:clientName,loanDno:loanDno,dateFrom:dateFrom,dateTo:dateTo
                                    },
                                    success: function(response){

                                    var data=Ext.decode(response.responseText);
                                    var meLoanRepaymentDetailsStore=Ext.getStore('MeLoanRepaymentDetailsStore');
                                    meLoanRepaymentDetailsStore.removeAll();
                                    meLoanRepaymentDetailsStore.add(data.root);
                                    }
                });
    },

    onBtnLoanRepaymentClick: function(button, e, eOpts) {
        var loanNo=Ext.ComponentQuery.query('#ddlLoanNo')[0].getValue();
        var paymentDate=Ext.ComponentQuery.query('#txtPaymentDateBS')[0].getValue();
        var paidAmt=Ext.ComponentQuery.query('#txtPastPrinciple')[0].getValue();
        var totalBalance=Ext.ComponentQuery.query('#ddlLoanNo')[0].getValue();
        var totalPrincileOutStanding=Ext.ComponentQuery.query('#ddlLoanNo')[0].getValue();
        var pastPrincipalDue=Ext.ComponentQuery.query('#ddlLoanNo')[0].getValue();
        var currentPrincipalSchedule=Ext.ComponentQuery.query('#ddlLoanNo')[0].getValue();
        var pastInterestDue=Ext.ComponentQuery.query('#ddlLoanNo')[0].getValue();
        var interestAmt=Ext.ComponentQuery.query('#txtCurrentInterest')[0].getValue();
        var penaltyAmt=Ext.ComponentQuery.query('#ddlLoanNo')[0].getValue();
        var principalPaidAmt=Ext.ComponentQuery.query('#ddlLoanNo')[0].getValue();
        var interestPaidAmt=Ext.ComponentQuery.query('#ddlLoanNo')[0].getValue();
        var penaltyPaidAmt=Ext.ComponentQuery.query('#ddlLoanNo')[0].getValue();
        var adjustFromSaving=Ext.ComponentQuery.query('#ddlLoanNo')[0].getValue();
        var savingAccountNo=Ext.ComponentQuery.query('#ddlLoanNo')[0].getValue();
        var contralAccount=Ext.ComponentQuery.query('#ddlContraAccount')[0].getValue();
        var voucherNo=Ext.ComponentQuery.query('#txtChequeNo')[0].getValue();
        var employeeId=Ext.ComponentQuery.query('#ddlLoanNo')[0].getValue();
        var totalPrincipalPaidAmt=Ext.ComponentQuery.query('#ddlLoanNo')[0].getValue();
        var totalInterestPaidAmt=Ext.ComponentQuery.query('#ddlLoanNo')[0].getValue();
        var totalInterestPaidAmt=Ext.ComponentQuery.query('#ddlLoanNo')[0].getValue();
        var remarks=Ext.ComponentQuery.query('#ddlLoanNo')[0].getValue();
        var tranOfficeCode=Ext.ComponentQuery.query('#ddlLoanNo')[0].getValue();
        var user=Ext.ComponentQuery.query('#ddlLoanNo')[0].getValue();
        var fiscalYear=Ext.ComponentQuery.query('#ddlLoanNo')[0].getValue();
        var loanRepaymentNo=Ext.ComponentQuery.query('#ddlLoanNo')[0].getValue();

         var objmeLoanRepayment={
                		        LoanNo:loanNo,
                                PaymentDate:paymentDate,
                                PaidAmount:paidAmt,
                                TotalBalance:totalBalance,
                                TotalPrincipalOutstanding:totalPrincileOutStanding,
                                PastPrincipalDue:loanNo,
                                CurrentPrincipalSchedule:loanNo,
                                PastInterestDue:loanNo,
                                InterestAmount:loanNo,
                                PenaltyAmount:loanNo,
                                PrincipalPaidAmount:loanNo,
                                InterestPaidAmount:loanNo,
                                PenaltyPaidAmount:loanNo,
                                AdjustFromSaving:loanNo,
                                SavingAccountNo:loanNo,
                                ContraAccount:loanNo,
                                VoucherNo:voucherNo,
                                EmployeeId:loanNo,
                                TotalPrincipalPaidAmount:loanNo,
                				TotalInterestPaidAmount:loanNo,
                                TotalPenaltyPaidAmount:loanNo,
                                Remarks:loanNo,
                                TranOfficeCode:tranOfficeCode,
                                User1:user,
                                Action:loanNo,
                                OutFiscalYear:fiscalYear,
                                OutLoanRepaymentNo:loanRepaymentNo};
                 Ext.Ajax.request
                        ({
                            method: 'POST',
                            url: '../Handlers/Finance/Transaction/LoanTransaction/MfLoanRepaymentHandler.ashx?method=SaveLoanRepayment',
                            params:{mfLoanRepayment:JSON.stringify(objmeLoanRepayment)},

                            waitMsg: 'Please wait',
                            success: function(result, request) {
                                wait.hide();
                                var obj = Ext.decode(result.responseText);
                                if (obj.success != "true")
                                {
                                    showMessage('ERROR OCURRED !!!',obj.message);
                                }
                                else
                                {
                                    showMessage('INFO','Saved successfully ');


                                }
                            },
                            failure: function(result, request) {
                                wait.hide();
                                var obj = Ext.decode(result.responseText);

                                msg("FAILURE","Cannot be saved successfully");
                                return;
                            }
                        });







    },

    init: function(application) {
        this.control({
            "#frm-MELoanRepayment": {
                afterrender: this.onFrmMELoanRepaymentAfterRender
            },
            "#ddlLoanProductCode": {
                change: this.onDdlLoanProductCodeChange
            },
            "#btnSearch": {
                click: this.onBtnSearchClick
            },
            "#btnLoanRepayment": {
                click: this.onBtnLoanRepaymentClick
            }
        });
    }

});