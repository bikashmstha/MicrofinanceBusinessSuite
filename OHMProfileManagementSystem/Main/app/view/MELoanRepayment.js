/*
 * File: app/view/MELoanRepayment.js
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

Ext.define('MyApp.view.MELoanRepayment', {
    extend: 'Ext.panel.Panel',

    requires: [
        'Ext.form.Panel',
        'Ext.form.field.ComboBox',
        'Ext.form.FieldSet',
        'Ext.form.field.Checkbox',
        'Ext.button.Button',
        'Ext.grid.Panel',
        'Ext.grid.View',
        'Ext.grid.column.Column'
    ],

    frame: true,
    autoScroll: true,
    title: 'Micro Business Loan Repayment',

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'form',
                    frame: true,
                    id: 'frm-MELoanRepayment',
                    itemId: 'frm-MELoanRepayment',
                    bodyPadding: 10,
                    title: '',
                    items: [
                        {
                            xtype: 'container',
                            itemId: 'ddlLoanNo',
                            layout: {
                                type: 'table',
                                columns: 2
                            },
                            items: [
                                {
                                    xtype: 'textfield',
                                    itemId: 'txtPaymentDateBS',
                                    fieldLabel: 'Payment Date(B.S.)',
                                    labelWidth: 160,
                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                },
                                {
                                    xtype: 'textfield',
                                    itemId: 'txtPaymentDateAD',
                                    fieldLabel: 'Payment Date(A.D.)',
                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                },
                                {
                                    xtype: 'combobox',
                                    colspan: 2,
                                    itemId: 'ddlLoanProductCode',
                                    fieldLabel: 'Loan Product Code',
                                    labelWidth: 160,
                                    fieldStyle: 'background-color:#DAEBE1;background-image:none;',
                                    size: 62,
                                    displayField: 'LoanProduct_Name',
                                    forceSelection: true,
                                    queryMode: 'local',
                                    store: 'MELoanProductStore',
                                    valueField: 'LoanProduct_Code'
                                },
                                {
                                    xtype: 'combobox',
                                    colspan: 2,
                                    fieldLabel: 'Loan No.',
                                    labelWidth: 160,
                                    fieldStyle: 'background-color:#DAEBE1;background-image:none;',
                                    size: 62,
                                    displayField: 'ClientDesc',
                                    forceSelection: true,
                                    store: 'MeLoanRepayStore',
                                    valueField: 'LoanNo'
                                },
                                {
                                    xtype: 'combobox',
                                    colspan: 2,
                                    fieldLabel: 'Field Assistant',
                                    labelWidth: 160,
                                    fieldStyle: 'background-color:#DAEBE1;background-image:none;',
                                    size: 62,
                                    displayField: 'EmpName',
                                    forceSelection: true,
                                    queryMode: 'local',
                                    store: 'MEFieldAssistantStore',
                                    valueField: 'EmpId'
                                },
                                {
                                    xtype: 'container',
                                    colspan: 2,
                                    layout: {
                                        type: 'table',
                                        columns: 2
                                    },
                                    items: [
                                        {
                                            xtype: 'fieldset',
                                            colspan: 1,
                                            title: 'Due',
                                            layout: {
                                                type: 'table',
                                                columns: 2
                                            },
                                            items: [
                                                {
                                                    xtype: 'textfield',
                                                    itemId: 'txtPastPrinciple',
                                                    fieldLabel: 'Past Principle',
                                                    labelWidth: 150,
                                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                                },
                                                {
                                                    xtype: 'textfield',
                                                    itemId: 'txtCurrentPrinciple',
                                                    margin: '0 0 0 5',
                                                    fieldLabel: 'Current Principle',
                                                    labelWidth: 115,
                                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                                },
                                                {
                                                    xtype: 'textfield',
                                                    itemId: 'txtPastInterest',
                                                    fieldLabel: 'Past Interest',
                                                    labelWidth: 150,
                                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                                },
                                                {
                                                    xtype: 'textfield',
                                                    itemId: 'txtCurrentInterest',
                                                    margin: '0 0 0 5',
                                                    fieldLabel: 'Current Interest',
                                                    labelWidth: 115,
                                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                                },
                                                {
                                                    xtype: 'textfield',
                                                    itemId: 'txtPenaltyOnInterest',
                                                    fieldLabel: 'Penalty On Interest',
                                                    labelWidth: 150,
                                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                                },
                                                {
                                                    xtype: 'textfield',
                                                    itemId: 'txtInstallmentAmt',
                                                    margin: '0 0 0 5',
                                                    fieldLabel: 'Installment Amount',
                                                    labelWidth: 115,
                                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                                }
                                            ]
                                        },
                                        {
                                            xtype: 'fieldset',
                                            colspan: 1,
                                            rowspan: 3,
                                            title: 'Balance',
                                            layout: {
                                                type: 'table',
                                                columns: 2
                                            },
                                            items: [
                                                {
                                                    xtype: 'textfield',
                                                    itemId: 'txtPrincipalBalance',
                                                    fieldLabel: 'Principal Balance',
                                                    labelWidth: 110,
                                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                                },
                                                {
                                                    xtype: 'textfield',
                                                    itemId: 'txtInterestBal',
                                                    margin: '0 0 0 5',
                                                    fieldLabel: 'Interest Balance',
                                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                                },
                                                {
                                                    xtype: 'textfield',
                                                    itemId: 'txtPenaltyBalance',
                                                    fieldLabel: 'Penalty Balance',
                                                    labelWidth: 110,
                                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                                },
                                                {
                                                    xtype: 'textfield',
                                                    itemId: 'txtTotalBalance',
                                                    margin: '0 0 0 5',
                                                    fieldLabel: 'Total Balance',
                                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                                }
                                            ]
                                        }
                                    ]
                                },
                                {
                                    xtype: 'textfield',
                                    colspan: 2,
                                    fieldLabel: 'Received Amount',
                                    labelWidth: 160,
                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                },
                                {
                                    xtype: 'fieldset',
                                    colspan: 2,
                                    title: '',
                                    layout: {
                                        type: 'table',
                                        columns: 4
                                    },
                                    items: [
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtPrincipleReceived',
                                            fieldLabel: 'Principle Received',
                                            labelWidth: 150,
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtInterestReceived',
                                            margin: '0 0 0 5',
                                            fieldLabel: 'Interest Received',
                                            labelWidth: 115,
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                        },
                                        {
                                            xtype: 'checkboxfield',
                                            itemId: 'chkTransferForSaving',
                                            margin: '0 0 0 5',
                                            fieldLabel: 'Transfer for Saving',
                                            labelWidth: 130,
                                            boxLabel: ''
                                        },
                                        {
                                            xtype: 'textfield',
                                            margin: '0 0 0 5',
                                            fieldLabel: 'Saving Account',
                                            fieldStyle: 'background-color:#DAEBE1;background-image:none;'
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtPenaltyReceived',
                                            fieldLabel: 'Penalty Received',
                                            labelWidth: 150,
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtTotalReceived',
                                            margin: '0 0 0 5',
                                            fieldLabel: 'Total Received',
                                            labelWidth: 115,
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtCurrentSavingBal',
                                            margin: '0 0 0 5',
                                            fieldLabel: 'Current Saving Balance',
                                            labelWidth: 130,
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtChequeNo',
                                            margin: '0 0 0 5',
                                            fieldLabel: 'Cheque No.'
                                        },
                                        {
                                            xtype: 'combobox',
                                            colspan: 4,
                                            itemId: 'ddlContraAccount',
                                            fieldLabel: 'Contra Account',
                                            labelWidth: 150,
                                            fieldStyle: 'background-color:#DAEBE1;background-image:none;',
                                            displayField: 'AccountDesc',
                                            forceSelection: true,
                                            queryMode: 'local',
                                            store: 'ContraAccountStore',
                                            valueField: 'AccountCode'
                                        }
                                    ]
                                },
                                {
                                    xtype: 'button',
                                    colspan: 2,
                                    text: 'Repayment Slip'
                                },
                                {
                                    xtype: 'container',
                                    colspan: 2,
                                    height: 25,
                                    layout: {
                                        type: 'hbox',
                                        align: 'stretch',
                                        pack: 'center'
                                    },
                                    items: [
                                        {
                                            xtype: 'button',
                                            itemId: 'btnLoanRepayment',
                                            text: 'Loan Repayment'
                                        }
                                    ]
                                },
                                {
                                    xtype: 'fieldset',
                                    colspan: 2,
                                    title: 'Search:',
                                    layout: {
                                        type: 'table',
                                        columns: 2
                                    },
                                    items: [
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtPaymentDateBSS',
                                            fieldLabel: 'Payment Date From(B.S.)',
                                            labelWidth: 150
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtPaymentDateADS',
                                            fieldLabel: 'Payment Date From(A.D.)',
                                            labelWidth: 150
                                        },
                                        {
                                            xtype: 'combobox',
                                            itemId: 'ddlLoanNoS',
                                            fieldLabel: 'Loan No.',
                                            labelWidth: 150,
                                            fieldStyle: 'background-color:#DAEBE1;background-image:none;',
                                            size: 62,
                                            displayField: 'ClientDesc',
                                            forceSelection: true,
                                            store: 'MELoanSearchStore',
                                            valueField: 'LoanNo'
                                        },
                                        {
                                            xtype: 'textfield',
                                            fieldLabel: 'Member Name',
                                            labelWidth: 150,
                                            size: 65
                                        },
                                        {
                                            xtype: 'container',
                                            colspan: 2,
                                            height: 25,
                                            layout: {
                                                type: 'hbox',
                                                align: 'stretch',
                                                pack: 'center'
                                            },
                                            items: [
                                                {
                                                    xtype: 'button',
                                                    itemId: 'btnSearch',
                                                    text: 'Search'
                                                }
                                            ]
                                        }
                                    ]
                                }
                            ]
                        },
                        {
                            xtype: 'gridpanel',
                            title: '',
                            store: 'MeLoanRepaymentDetailsStore',
                            columns: [
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'PaymentDate',
                                    text: 'PaymentDate'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'LoanNo',
                                    text: 'LoanNo'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'CenterName',
                                    text: 'CenterName'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'TotalPrincipal_Outstanding',
                                    text: 'TotalPrincipal_Outstanding'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'InstallmentAmount',
                                    text: 'InstallmentAmount'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'PaidAmount',
                                    text: 'PaidAmount'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'PrincipalPaid_Amount',
                                    text: 'PrincipalPaid_Amount'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'InterestPaid_Amount',
                                    text: 'InterestPaid_Amount'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'PenaltyPaid_Amount',
                                    text: 'PenaltyPaid_Amount'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'VoucherNo',
                                    text: 'VoucherNo'
                                }
                            ]
                        }
                    ]
                }
            ]
        });

        me.callParent(arguments);
    }

});