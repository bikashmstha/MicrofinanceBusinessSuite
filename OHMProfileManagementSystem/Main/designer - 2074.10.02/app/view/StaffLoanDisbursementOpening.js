/*
 * File: app/view/StaffLoanDisbursementOpening.js
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

Ext.define('MyApp.view.StaffLoanDisbursementOpening', {
    extend: 'Ext.panel.Panel',

    requires: [
        'Ext.form.field.ComboBox',
        'Ext.form.Panel',
        'Ext.grid.Panel',
        'Ext.grid.column.Number',
        'Ext.grid.column.Date',
        'Ext.grid.column.Boolean',
        'Ext.grid.View',
        'Ext.toolbar.Toolbar',
        'Ext.button.Button'
    ],

    frame: true,
    title: 'Staff Loan Disbursement Opening',

    layout: {
        type: 'table',
        columns: 4
    },

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'textfield',
                    colspan: 2,
                    fieldLabel: 'Loan No',
                    size: 53
                },
                {
                    xtype: 'textfield',
                    margin: '0 0 0 10',
                    fieldLabel: 'Deduction 1',
                    labelWidth: 125
                },
                {
                    xtype: 'textfield',
                    margin: '0 0 0 10',
                    fieldLabel: 'Deduction 2',
                    labelWidth: 120
                },
                {
                    xtype: 'textfield',
                    fieldLabel: 'Loan Date(B.S.)'
                },
                {
                    xtype: 'textfield',
                    margin: '0 0 0 10',
                    fieldLabel: '(A.D.)',
                    labelWidth: 50
                },
                {
                    xtype: 'textfield',
                    margin: '0 0 0 10',
                    fieldLabel: 'Deduction 3',
                    labelWidth: 125
                },
                {
                    xtype: 'textfield',
                    margin: '0 0 0 10',
                    fieldLabel: 'Deduction 4',
                    labelWidth: 120
                },
                {
                    xtype: 'textfield',
                    colspan: 2,
                    fieldLabel: 'Staff Code',
                    size: 53
                },
                {
                    xtype: 'textfield',
                    margin: '0 0 0 10',
                    fieldLabel: 'Total Deduction',
                    labelWidth: 125
                },
                {
                    xtype: 'textfield',
                    margin: '0 0 0 10',
                    fieldLabel: 'Net Amount paid',
                    labelWidth: 120,
                    size: 30
                },
                {
                    xtype: 'textfield',
                    colspan: 2,
                    fieldLabel: 'Name',
                    size: 53
                },
                {
                    xtype: 'combobox',
                    colspan: 2,
                    margin: '0 0 0 10',
                    fieldLabel: 'Interest Calc Method',
                    labelWidth: 125,
                    emptyText: '---Select---',
                    size: 30
                },
                {
                    xtype: 'textfield',
                    colspan: 2,
                    fieldLabel: 'Address',
                    size: 53
                },
                {
                    xtype: 'textfield',
                    margin: '0 0 0 10',
                    fieldLabel: 'Interest Rate',
                    labelWidth: 125
                },
                {
                    xtype: 'combobox',
                    margin: '0 0 0 10',
                    fieldLabel: 'Loan Status',
                    labelWidth: 120,
                    emptyText: 'Open'
                },
                {
                    xtype: 'textfield',
                    fieldLabel: 'Manager'
                },
                {
                    xtype: 'textfield',
                    margin: '0 0 0 10',
                    fieldLabel: 'Label',
                    hideLabel: true,
                    size: 28
                },
                {
                    xtype: 'textfield',
                    margin: '0 0 0 10',
                    fieldLabel: 'Loan Period',
                    labelWidth: 125
                },
                {
                    xtype: 'combobox',
                    margin: '0 0 0 10',
                    fieldLabel: 'Loan Period Type',
                    labelWidth: 120,
                    emptyText: 'Monthly'
                },
                {
                    xtype: 'textfield',
                    fieldLabel: 'Loan Heading'
                },
                {
                    xtype: 'textfield',
                    margin: '0 0 0 10',
                    fieldLabel: 'Label',
                    hideLabel: true,
                    size: 28
                },
                {
                    xtype: 'textfield',
                    margin: '0 0 0 10',
                    fieldLabel: 'Installment Period',
                    labelWidth: 125
                },
                {
                    xtype: 'combobox',
                    margin: '0 0 0 10',
                    fieldLabel: 'Installment Type',
                    labelWidth: 120,
                    emptyText: 'Monthly'
                },
                {
                    xtype: 'textfield',
                    fieldLabel: 'Loan Purpose'
                },
                {
                    xtype: 'textfield',
                    colspan: 0,
                    margin: '0 0 0 10',
                    fieldLabel: 'Label',
                    hideLabel: true,
                    size: 28
                },
                {
                    xtype: 'container',
                    layout: {
                        type: 'table',
                        columns: 2
                    },
                    items: [
                        {
                            xtype: 'textfield',
                            margin: '0 0 0 10',
                            fieldLabel: 'Grace Days',
                            labelWidth: 125,
                            size: 15
                        },
                        {
                            xtype: 'textfield',
                            margin: '0 0 0 5',
                            fieldLabel: 'Label',
                            hideLabel: true,
                            size: 10
                        }
                    ]
                },
                {
                    xtype: 'textfield',
                    margin: '0 0 0 10',
                    fieldLabel: 'Installment Amount',
                    labelWidth: 120
                },
                {
                    xtype: 'textfield',
                    colspan: 2,
                    fieldLabel: 'Loan Sector',
                    size: 53
                },
                {
                    xtype: 'textfield',
                    margin: '0 0 0 10',
                    fieldLabel: '1st Install Date(B.S.)',
                    labelWidth: 125
                },
                {
                    xtype: 'textfield',
                    margin: '0 0 0 10',
                    fieldLabel: '1st Install Date(A.D.)',
                    labelWidth: 120,
                    size: 30
                },
                {
                    xtype: 'textfield',
                    colspan: 2,
                    fieldLabel: 'App. Loan Amt'
                },
                {
                    xtype: 'textfield',
                    margin: '0 0 0 10',
                    fieldLabel: 'Maturity Date(B.S.)',
                    labelWidth: 125
                },
                {
                    xtype: 'textfield',
                    margin: '0 0 0 10',
                    fieldLabel: 'Maturity Date(A.D.)',
                    labelWidth: 120,
                    size: 30
                },
                {
                    xtype: 'textfield',
                    colspan: 2,
                    fieldLabel: 'Total Loan Taken'
                },
                {
                    xtype: 'textfield',
                    margin: '0 0 0 10',
                    fieldLabel: 'Contra Account',
                    labelWidth: 125,
                    size: 30
                },
                {
                    xtype: 'textfield',
                    margin: '0 0 0 10',
                    fieldLabel: '',
                    hideLabel: true,
                    labelWidth: 120,
                    size: 49
                },
                {
                    xtype: 'textfield',
                    colspan: 2,
                    fieldLabel: 'Total Pri Outstand',
                    labelWidth: 104
                },
                {
                    xtype: 'textfield',
                    margin: '0 0 0 10',
                    fieldLabel: 'Last Int Paid Date(B.S.)',
                    labelWidth: 135,
                    size: 18
                },
                {
                    xtype: 'textfield',
                    margin: '0 0 0 10',
                    fieldLabel: '(A.D.)',
                    labelWidth: 120
                },
                {
                    xtype: 'textfield',
                    colspan: 2,
                    fieldLabel: 'Total Pri Paid Amt',
                    labelWidth: 104
                },
                {
                    xtype: 'textfield',
                    margin: '0 0 0 10',
                    fieldLabel: 'Old Loan Date(B.S.)',
                    labelWidth: 125
                },
                {
                    xtype: 'textfield',
                    margin: '0 0 0 10',
                    fieldLabel: '(A.D.)',
                    labelWidth: 120
                },
                {
                    xtype: 'textfield',
                    colspan: 2,
                    fieldLabel: 'Old Loan No',
                    size: 53
                },
                {
                    xtype: 'textfield',
                    margin: '0 0 0 10',
                    fieldLabel: 'Total Interest',
                    labelWidth: 125
                },
                {
                    xtype: 'textfield',
                    margin: '0 0 0 10',
                    fieldLabel: 'Total Interest Paid',
                    labelWidth: 120
                },
                {
                    xtype: 'combobox',
                    colspan: 2,
                    fieldLabel: 'Funding Agency'
                },
                {
                    xtype: 'textfield',
                    margin: '0 0 0 10',
                    fieldLabel: 'Old Office Code',
                    labelWidth: 125,
                    size: 30
                },
                {
                    xtype: 'textfield',
                    margin: '0 0 0 10',
                    fieldLabel: 'Label',
                    hideLabel: true,
                    size: 49
                },
                {
                    xtype: 'container',
                    colspan: 4,
                    layout: {
                        type: 'hbox',
                        align: 'stretch',
                        pack: 'center'
                    },
                    items: [
                        {
                            xtype: 'textfield',
                            flex: 0,
                            fieldLabel: 'Cheque No'
                        }
                    ]
                },
                {
                    xtype: 'form',
                    colspan: 4,
                    frame: true,
                    bodyPadding: 10,
                    title: 'Collateral Detail',
                    items: [
                        {
                            xtype: 'gridpanel',
                            title: 'My Grid Panel',
                            columns: [
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'string',
                                    text: 'String'
                                },
                                {
                                    xtype: 'numbercolumn',
                                    dataIndex: 'number',
                                    text: 'Number'
                                },
                                {
                                    xtype: 'datecolumn',
                                    dataIndex: 'date',
                                    text: 'Date'
                                },
                                {
                                    xtype: 'booleancolumn',
                                    dataIndex: 'bool',
                                    text: 'Boolean'
                                }
                            ],
                            dockedItems: [
                                {
                                    xtype: 'toolbar',
                                    dock: 'bottom',
                                    items: [
                                        {
                                            xtype: 'combobox',
                                            fieldLabel: 'Label',
                                            hideLabel: true
                                        },
                                        {
                                            xtype: 'textfield',
                                            fieldLabel: 'Label',
                                            hideLabel: true
                                        },
                                        {
                                            xtype: 'textfield',
                                            fieldLabel: 'Label',
                                            hideLabel: true
                                        },
                                        {
                                            xtype: 'textfield',
                                            fieldLabel: 'Label',
                                            hideLabel: true
                                        },
                                        {
                                            xtype: 'textfield',
                                            fieldLabel: 'Label',
                                            hideLabel: true
                                        },
                                        {
                                            xtype: 'textfield',
                                            fieldLabel: 'Label',
                                            hideLabel: true
                                        },
                                        {
                                            xtype: 'button',
                                            text: 'Add'
                                        }
                                    ]
                                }
                            ]
                        }
                    ]
                },
                {
                    xtype: 'container',
                    colspan: 4,
                    margin: '10 0 0 0 ',
                    layout: {
                        type: 'hbox',
                        align: 'stretch'
                    },
                    items: [
                        {
                            xtype: 'button',
                            text: 'Repayment Schedule'
                        }
                    ]
                },
                {
                    xtype: 'container',
                    colspan: 4,
                    margin: '10 0 0 0 ',
                    layout: {
                        type: 'hbox',
                        align: 'stretch',
                        pack: 'center'
                    },
                    items: [
                        {
                            xtype: 'button',
                            text: 'Disburse Loan'
                        }
                    ]
                },
                {
                    xtype: 'form',
                    colspan: 4,
                    frame: true,
                    margin: '10 0 0 0',
                    bodyPadding: 10,
                    title: 'Search',
                    layout: {
                        type: 'table',
                        columns: 2
                    },
                    items: [
                        {
                            xtype: 'textfield',
                            fieldLabel: 'Open Date From(B.S.)',
                            labelWidth: 140
                        },
                        {
                            xtype: 'textfield',
                            margin: '0 0 0 200',
                            fieldLabel: 'Open Date To(B.S.)',
                            labelWidth: 140
                        },
                        {
                            xtype: 'textfield',
                            fieldLabel: 'Loan No',
                            labelWidth: 140
                        },
                        {
                            xtype: 'textfield',
                            margin: '0 0 0 200',
                            fieldLabel: 'Member Name',
                            labelWidth: 140,
                            size: 73
                        },
                        {
                            xtype: 'container',
                            colspan: 4,
                            layout: {
                                type: 'hbox',
                                align: 'stretch',
                                pack: 'center'
                            },
                            items: [
                                {
                                    xtype: 'button',
                                    text: 'Search'
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