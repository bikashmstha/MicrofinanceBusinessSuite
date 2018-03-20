/*
 * File: app/view/MEAdditionalLoanDisbursement.js
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

Ext.define('MyApp.view.MEAdditionalLoanDisbursement', {
    extend: 'Ext.panel.Panel',

    requires: [
        'Ext.form.Panel',
        'Ext.form.field.ComboBox',
        'Ext.form.field.Checkbox',
        'Ext.button.Button',
        'Ext.form.FieldSet',
        'Ext.grid.Panel',
        'Ext.grid.View',
        'Ext.grid.column.Column'
    ],

    frame: true,
    autoScroll: true,
    title: 'Micro Business Additional Loan Disbursement',

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'form',
                    frame: true,
                    id: 'frmMEAdditionalLoanDisbursement',
                    itemId: 'frmMEAdditionalLoanDisbursement',
                    bodyPadding: 10,
                    title: '',
                    items: [
                        {
                            xtype: 'container',
                            layout: {
                                type: 'table',
                                columns: 2
                            },
                            items: [
                                {
                                    xtype: 'textfield',
                                    itemId: 'txtDateBS',
                                    fieldLabel: 'Date(B.S.)',
                                    labelWidth: 110,
                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                },
                                {
                                    xtype: 'textfield',
                                    itemId: 'txtDateAD',
                                    fieldLabel: 'Date(A.D.)',
                                    labelWidth: 115,
                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                },
                                {
                                    xtype: 'combobox',
                                    colspan: 2,
                                    itemId: 'ddlLoanProductCode',
                                    fieldLabel: 'Loan Product Code',
                                    labelWidth: 110,
                                    fieldStyle: 'background-color:#DAEBE1;background-image:none;',
                                    size: 40,
                                    displayField: 'LoanProduct_Name',
                                    forceSelection: true,
                                    queryMode: 'local',
                                    store: 'LoanProductCodeStore',
                                    valueField: 'LoanProduct_Code'
                                },
                                {
                                    xtype: 'combobox',
                                    itemId: 'ddlLoanNo',
                                    fieldLabel: 'Loan No.',
                                    labelWidth: 110,
                                    fieldStyle: 'background-color:#DAEBE1;background-image:none;',
                                    size: 40,
                                    displayField: 'LoanNo',
                                    queryMode: 'local',
                                    store: 'LoanNoMFStore',
                                    valueField: 'LoanNo'
                                },
                                {
                                    xtype: 'textfield',
                                    itemId: 'txtNoOfDisburse',
                                    fieldLabel: 'No. of Loan Disburse',
                                    labelWidth: 115,
                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                },
                                {
                                    xtype: 'textfield',
                                    itemId: 'txtMemberName',
                                    fieldLabel: 'Member Name',
                                    labelWidth: 110,
                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;',
                                    size: 40
                                },
                                {
                                    xtype: 'textfield',
                                    itemId: 'txtRemainingNoOfInstallments',
                                    fieldLabel: 'Remaining No. of Installments',
                                    labelWidth: 115,
                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                },
                                {
                                    xtype: 'combobox',
                                    colspan: 2,
                                    itemId: 'ddlFieldAssistantCode',
                                    fieldLabel: 'Field Assistant',
                                    labelWidth: 110,
                                    fieldStyle: 'background-color:#DAEBE1;background-image:none;',
                                    size: 40,
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
                                        columns: 4
                                    },
                                    items: [
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtLoanDateBS',
                                            fieldLabel: 'Loan Date(B.S.)',
                                            labelWidth: 110,
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;',
                                            size: 12
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtLoanDateAD',
                                            margin: '0 0 0 5',
                                            fieldLabel: 'Loan Date(A.D.)',
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;',
                                            size: 12
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtMaturityDateBS',
                                            margin: '0 0 0 5',
                                            fieldLabel: 'Maturity Date(B.S.)',
                                            labelWidth: 115,
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;',
                                            size: 12
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtMaturityDateAD',
                                            margin: '0 0 0 5',
                                            fieldLabel: 'Maturity Date(A.D.)',
                                            labelWidth: 115,
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;',
                                            size: 12
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtLoanPeriod',
                                            fieldLabel: 'Loan Period',
                                            labelWidth: 110,
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;',
                                            size: 12
                                        },
                                        {
                                            xtype: 'combobox',
                                            itemId: 'ddlPeriodType',
                                            margin: '0 0 0 5',
                                            fieldLabel: 'Period Type',
                                            emptyText: '--- SELECT ---',
                                            size: 12,
                                            displayField: 'RefDtlName',
                                            queryMode: 'local',
                                            store: 'ReferenceShortStore',
                                            valueField: 'RefDtlCode'
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtInstallmentPeriod',
                                            margin: '0 0 0 5',
                                            fieldLabel: 'Installment Period',
                                            labelWidth: 115,
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;',
                                            size: 12
                                        },
                                        {
                                            xtype: 'combobox',
                                            itemId: 'ddlInstallmentType',
                                            margin: '0 0 0 5',
                                            fieldLabel: 'Installment Type',
                                            labelWidth: 115,
                                            emptyText: '--- SELECT ---',
                                            displayField: 'RefDtlName',
                                            queryMode: 'local',
                                            store: 'InstallmentTypeRefShortStore',
                                            valueField: 'RefDtlCode'
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtPrincipleBalance',
                                            fieldLabel: 'Principle Balance',
                                            labelWidth: 110,
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;',
                                            size: 14
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtInterestBalance',
                                            margin: '0 0 0 5',
                                            fieldLabel: 'Interest Balance',
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;',
                                            size: 14
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtGraceDays',
                                            margin: '0 0 0 5',
                                            fieldLabel: 'Grace Days',
                                            labelWidth: 115,
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;',
                                            size: 12
                                        },
                                        {
                                            xtype: 'combobox',
                                            itemId: 'ddlInterestRate',
                                            margin: '0 0 0 5',
                                            fieldLabel: 'Interest Rate',
                                            labelWidth: 115,
                                            emptyText: '--- SELECT ---',
                                            displayField: 'RefDtlName',
                                            queryMode: 'local',
                                            store: 'InterestRateRefShortStore',
                                            valueField: 'RefDtlCode'
                                        }
                                    ]
                                },
                                {
                                    xtype: 'container',
                                    colspan: 2,
                                    layout: {
                                        type: 'table',
                                        columns: 4
                                    },
                                    items: [
                                        {
                                            xtype: 'textfield',
                                            colspan: 2,
                                            itemId: 'txtApprovedAmt',
                                            fieldLabel: 'Approved Amt',
                                            labelWidth: 110,
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;',
                                            size: 15
                                        },
                                        {
                                            xtype: 'textfield',
                                            colspan: 2,
                                            itemId: 'txtAdditionalDisburseAmt',
                                            margin: '0 0 0 5',
                                            fieldLabel: 'Additional Disburse Amt',
                                            labelWidth: 115,
                                            size: 15
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtDeductionType1',
                                            fieldLabel: 'Deduction1',
                                            labelWidth: 110,
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;',
                                            size: 15
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtDeduction2',
                                            margin: '0 0 0 5',
                                            fieldLabel: 'Deduction2',
                                            labelWidth: 90,
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;',
                                            size: 15
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtDeduction3',
                                            margin: '0 0 0 5',
                                            fieldLabel: 'Deduction3',
                                            labelWidth: 115,
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;',
                                            size: 15
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtDeduction4',
                                            margin: '0 0 0 5',
                                            fieldLabel: 'Deduction4',
                                            labelWidth: 105,
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;',
                                            size: 15
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtTotalDeductionAmt',
                                            fieldLabel: 'Total Deduct Amt',
                                            labelWidth: 110,
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;',
                                            size: 15
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtNetPaidAmt',
                                            margin: '0 0 0 5',
                                            fieldLabel: 'Net Paid Amt',
                                            labelWidth: 90,
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;',
                                            size: 15
                                        },
                                        {
                                            xtype: 'textfield',
                                            colspan: 2,
                                            itemId: 'txtNewTotalLoanAmt',
                                            margin: '0 0 0 5',
                                            fieldLabel: 'New Total Loan Amt',
                                            labelWidth: 115,
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;',
                                            size: 15
                                        },
                                        {
                                            xtype: 'combobox',
                                            colspan: 4,
                                            itemId: 'ddlContraAccount',
                                            fieldLabel: 'Contra Account',
                                            labelWidth: 110,
                                            fieldStyle: 'background-color:#DAEBE1;background-image:none;',
                                            size: 60,
                                            displayField: 'AccountDesc',
                                            queryMode: 'local',
                                            store: 'ContraAccountStore',
                                            valueField: 'AccountCode'
                                        },
                                        {
                                            xtype: 'container',
                                            colspan: 4,
                                            layout: {
                                                type: 'table',
                                                columns: 2
                                            },
                                            items: [
                                                {
                                                    xtype: 'checkboxfield',
                                                    itemId: 'chkAdjustSaving',
                                                    fieldLabel: 'Adjust to Saving',
                                                    labelWidth: 110,
                                                    boxLabel: ''
                                                },
                                                {
                                                    xtype: 'combobox',
                                                    itemId: 'ddlAdjustSaving',
                                                    fieldLabel: '',
                                                    fieldStyle: 'background-color:#DAEBE1;background-image:none;',
                                                    size: 60,
                                                    displayField: 'SavingAccountHead',
                                                    queryMode: 'local',
                                                    store: 'AdjustToSavingStore',
                                                    valueField: 'SavingAccountNo'
                                                }
                                            ]
                                        }
                                    ]
                                },
                                {
                                    xtype: 'container',
                                    colspan: 2,
                                    height: 23,
                                    layout: {
                                        type: 'hbox',
                                        align: 'stretch',
                                        pack: 'center'
                                    },
                                    items: [
                                        {
                                            xtype: 'button',
                                            itemId: 'btnDisburseLoan',
                                            padding: 5,
                                            text: 'Disburse Loan'
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
                                            itemId: 'txtSearchDisburseDateFromBS',
                                            fieldLabel: 'Disburse Date From(B.S.)',
                                            labelWidth: 145
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtSearchDisburseDateToBS',
                                            fieldLabel: 'Disburse Date To(B.S.)',
                                            labelWidth: 130
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtSearchLoanNo',
                                            fieldLabel: 'Loan No.',
                                            labelWidth: 145,
                                            size: 53
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtSearchMemberName',
                                            margin: '0 0 0 5',
                                            fieldLabel: 'Member Name',
                                            labelWidth: 125,
                                            size: 60
                                        },
                                        {
                                            xtype: 'container',
                                            colspan: 2,
                                            height: 23,
                                            layout: {
                                                type: 'hbox',
                                                align: 'stretch',
                                                pack: 'center'
                                            },
                                            items: [
                                                {
                                                    xtype: 'button',
                                                    itemId: 'btnSearch',
                                                    padding: 5,
                                                    text: 'Search'
                                                }
                                            ]
                                        },
                                        {
                                            xtype: 'gridpanel',
                                            colspan: 2,
                                            itemId: 'grdMEAddLoanDisburse',
                                            title: '',
                                            store: 'SearchMEAddLoanDisburseStore',
                                            columns: [
                                                {
                                                    xtype: 'gridcolumn',
                                                    dataIndex: 'LoanNo',
                                                    text: 'Loan No'
                                                },
                                                {
                                                    xtype: 'gridcolumn',
                                                    dataIndex: 'ClientName',
                                                    text: 'Member Name'
                                                },
                                                {
                                                    xtype: 'gridcolumn',
                                                    dataIndex: 'CenterName',
                                                    text: 'Center/Group'
                                                },
                                                {
                                                    xtype: 'gridcolumn',
                                                    dataIndex: 'LoanProduct_Name',
                                                    text: 'Loan Heading'
                                                },
                                                {
                                                    xtype: 'gridcolumn',
                                                    dataIndex: 'LoanDate',
                                                    text: 'Loan Date'
                                                },
                                                {
                                                    xtype: 'gridcolumn',
                                                    dataIndex: 'LoanMaturity_Date',
                                                    text: 'Maturity Date'
                                                },
                                                {
                                                    xtype: 'gridcolumn',
                                                    dataIndex: 'LoanAmount',
                                                    text: 'Loan Amt'
                                                },
                                                {
                                                    xtype: 'gridcolumn',
                                                    dataIndex: 'LoanPeriod',
                                                    text: 'Loan Period'
                                                }
                                            ]
                                        }
                                    ]
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