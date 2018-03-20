/*
 * File: app/view/SelectCollectionSheetNo.js
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

Ext.define('MyApp.view.SelectCollectionSheetNo', {
    extend: 'Ext.window.Window',

    requires: [
        'Ext.form.Panel',
        'Ext.form.field.Text',
        'Ext.button.Button',
        'Ext.grid.Panel',
        'Ext.grid.View',
        'Ext.selection.RowModel',
        'Ext.grid.column.Column'
    ],

    height: 500,
    itemId: 'SelectCollectionSheetNo',
    width: 1000,
    autoScroll: true,
    title: 'Select Collection Sheet No',

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'form',
                    frame: true,
                    itemId: 'frmSelectLoanNoPopup',
                    bodyPadding: 10,
                    items: [
                        {
                            xtype: 'container',
                            layout: 'table',
                            items: [
                                {
                                    xtype: 'textfield',
                                    itemId: 'txtSearchRepaymentNo',
                                    fieldLabel: 'Repayment No',
                                    labelWidth: 130
                                },
                                {
                                    xtype: 'button',
                                    colspan: 2,
                                    itemId: 'btnSearchRepayment',
                                    margin: '0 0 0 5',
                                    text: 'Search',
                                    listeners: {
                                        click: {
                                            fn: me.onBtnSearchRepaymentClick,
                                            scope: me
                                        }
                                    }
                                }
                            ]
                        },
                        {
                            xtype: 'gridpanel',
                            itemId: 'grdSearchRepayment',
                            width: 910,
                            title: '',
                            store: 'LoanRePaymentStore',
                            selModel: Ext.create('Ext.selection.RowModel', {
                                listeners: {
                                    beforeselect: {
                                        fn: me.onRowModelBeforeSelect,
                                        scope: me
                                    }
                                }
                            }),
                            columns: [
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'CollectionSheetNo',
                                    text: 'Coll Sheet No'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'RepaymentNo',
                                    text: 'Repayment No'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    width: 106,
                                    dataIndex: 'PaymentDateNep',
                                    text: 'Payment Date Nep'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'PaymentDate',
                                    text: 'Payment Date'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'LoanDno',
                                    text: 'Loan Dno'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'TotalReceived',
                                    text: 'Total Received'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'PrincipalReceived',
                                    text: 'Principal Received'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'InterestReceived',
                                    text: 'Interest Received'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'PenaltyReceived',
                                    text: 'Penalty Received'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'ChequeNo',
                                    text: 'Cheque No'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'SavingAccountDno',
                                    text: 'Saving Account Dno'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'AdjustFromSaving',
                                    text: 'Adjust From Saving'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'SavingAccountNo',
                                    text: 'Saving Account No'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'ContraAccount',
                                    text: 'Contra Account'
                                }
                            ]
                        }
                    ]
                }
            ]
        });

        me.callParent(arguments);
    },

    onBtnSearchRepaymentClick: function(button, e, eOpts) {
        var loanNo=Ext.ComponentQuery.query('#hdnLoanNo')[0];
        var repaymentNo=Ext.ComponentQuery.query('#txtSearchRepaymentNo')[0];
        var waitSave = watiMsg('Loading Data. Please wait ...');

        Ext.Ajax.request({
            url: '../Handlers/Finance/Transaction/EditTransaction/LoanRepayAdjustRepayHandler.ashx',
            params: {
                method:'GetLoanRepayAdjustRepay',
                OfficeCode:getOfficeCode(),
                LoanNo: loanNo.getValue(),
                RepaymentNo:repaymentNo.getValue(),
                FromDate:null,
                ToDate:null
            },
            success: function(response){


        var obj = Ext.decode(response.responseText);

              if(obj.success === "true")
              {
                  var store=Ext.getStore('LoanRePaymentStore');
                  store.removeAll();
                  store.add(obj.root);
              }
                else
                {

                    msg("FAILURE",obj.message);
                }


            waitSave.hide();


            }
        });
    },

    onRowModelBeforeSelect: function(rowmodel, record, index, eOpts) {
        Ext.MessageBox.confirm('Select', 'Are you sure ?', function(btn){

           if(btn === 'yes'){


               Ext.ComponentQuery.query('#txtRepaymentDate')[0].setValue(record.data.PaymentDate);
               Ext.ComponentQuery.query('#txtLoanRepayment')[0].setValue(record.data.RepaymentNo);


                Ext.ComponentQuery.query('#txtPrincipleReceived')[0].setValue(record.data.PrincipalReceived);
               Ext.ComponentQuery.query('#txtInterestReceived')[0].setValue(record.data.InterestReceived);
               Ext.ComponentQuery.query('#txtSavingAccount')[0].setValue(record.data.SavingAccountNo);
        Ext.ComponentQuery.query('#txtChequeNo')[0].setValue(record.data.ChequeNo);
               Ext.ComponentQuery.query('#txtTotalReceived')[0].setValue(record.data.TotalReceived);


               var myForm=Ext.ComponentQuery.query('#frmMFMERepaymentAdjust')[0];
               myForm.PaymentDateAD=record.data.PaymentDateAD;

               var loanRePaymentStore= Ext.getStore('LoanRePaymentStore');
                loanRePaymentStore.removeAll();

              // return true;
           }
           else
           {

           }
            var v=Ext.ComponentQuery.query('#SelectCollectionSheetNo')[0];

            v.close();
        });

    }

});