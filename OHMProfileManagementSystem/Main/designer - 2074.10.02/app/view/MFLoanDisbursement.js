/*
 * File: app/view/MFLoanDisbursement.js
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

Ext.define('MyApp.view.MFLoanDisbursement', {
    extend: 'Ext.panel.Panel',

    requires: [
        'Ext.form.Panel',
        'Ext.form.field.ComboBox',
        'Ext.form.field.Checkbox',
        'Ext.button.Button',
        'Ext.form.FieldSet',
        'Ext.panel.Tool'
    ],

    autoScroll: true,
    title: 'Micro Finance Loan Disbursement',

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'form',
                    frame: true,
                    id: 'frm-MFLoanDisbursement',
                    itemId: 'frm-MFLoanDisbursement',
                    bodyPadding: 10,
                    title: '',
                    items: [
                        {
                            xtype: 'container',
                            layout: {
                                type: 'table',
                                columns: 3
                            },
                            items: [
                                {
                                    xtype: 'textfield',
                                    fieldLabel: 'Loan No.',
                                    labelWidth: 120,
                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                },
                                {
                                    xtype: 'textfield',
                                    margin: '0 0 0 5',
                                    fieldLabel: 'Deduction1',
                                    labelWidth: 125,
                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                },
                                {
                                    xtype: 'textfield',
                                    margin: '0 0 0 5',
                                    fieldLabel: 'Deduction2',
                                    labelWidth: 120,
                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
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
                                            fieldLabel: 'Loan Date(B.S.)',
                                            labelWidth: 120,
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                        },
                                        {
                                            xtype: 'textfield',
                                            fieldLabel: '(A.D.)',
                                            labelWidth: 35,
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                        },
                                        {
                                            xtype: 'textfield',
                                            fieldLabel: 'Center Code',
                                            labelWidth: 120,
                                            fieldStyle: 'background-color:#DAEBE1;background-image:none;'
                                        },
                                        {
                                            xtype: 'textfield',
                                            margin: '0 0 0 5',
                                            fieldLabel: '',
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;',
                                            size: 26
                                        },
                                        {
                                            xtype: 'textfield',
                                            fieldLabel: 'Member Code',
                                            labelWidth: 120,
                                            fieldStyle: 'background-color:#DAEBE1;background-image:none;'
                                        },
                                        {
                                            xtype: 'textfield',
                                            margin: '0 0 0 5',
                                            fieldLabel: '',
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;',
                                            size: 26
                                        }
                                    ]
                                },
                                {
                                    xtype: 'container',
                                    margin: '0 0 0 5',
                                    items: [
                                        {
                                            xtype: 'textfield',
                                            fieldLabel: 'Deduction3',
                                            labelWidth: 125,
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                        },
                                        {
                                            xtype: 'textfield',
                                            fieldLabel: 'Total Deduction',
                                            labelWidth: 125,
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                        },
                                        {
                                            xtype: 'textfield',
                                            fieldLabel: 'Net Amount Paid',
                                            labelWidth: 125,
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                        }
                                    ]
                                },
                                {
                                    xtype: 'container',
                                    margin: '0 0 0 5',
                                    items: [
                                        {
                                            xtype: 'textfield',
                                            fieldLabel: 'Deduction4',
                                            labelWidth: 120,
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                        },
                                        {
                                            xtype: 'textfield',
                                            fieldLabel: 'Loan Year',
                                            labelWidth: 120,
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                        },
                                        {
                                            xtype: 'textfield',
                                            fieldLabel: 'Transfer Date',
                                            labelWidth: 120,
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                        }
                                    ]
                                },
                                {
                                    xtype: 'textfield',
                                    fieldLabel: 'Husband Name',
                                    labelWidth: 120,
                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                },
                                {
                                    xtype: 'combobox',
                                    colspan: 2,
                                    fieldLabel: 'Interest Calc Method',
                                    labelWidth: 125,
                                    emptyText: '--- SELECT ---'
                                },
                                {
                                    xtype: 'textfield',
                                    fieldLabel: 'Father in Law\'s Name',
                                    labelWidth: 120,
                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                },
                                {
                                    xtype: 'combobox',
                                    fieldLabel: 'Interest Rate',
                                    labelWidth: 125,
                                    emptyText: '--- SELECT ---'
                                },
                                {
                                    xtype: 'combobox',
                                    margin: '0 0 0 5',
                                    fieldLabel: 'Loan Status',
                                    labelWidth: 120,
                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                },
                                {
                                    xtype: 'textfield',
                                    fieldLabel: 'Address',
                                    labelWidth: 120,
                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                },
                                {
                                    xtype: 'combobox',
                                    fieldLabel: 'Installment Frequency',
                                    labelWidth: 125
                                },
                                {
                                    xtype: 'combobox',
                                    fieldLabel: '',
                                    emptyText: '--- SELECT ---'
                                },
                                {
                                    xtype: 'textfield',
                                    fieldLabel: 'Group Name',
                                    labelWidth: 120,
                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                },
                                {
                                    xtype: 'combobox',
                                    fieldLabel: 'Loan Period in Mon/Yrs',
                                    labelWidth: 125,
                                    emptyText: '--- SELECT ---'
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
                                            fieldLabel: 'Loan Period',
                                            labelWidth: 124,
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                        },
                                        {
                                            xtype: 'textfield',
                                            margin: '0 0 0 5',
                                            fieldLabel: '',
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                        }
                                    ]
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
                                            fieldLabel: 'Field Assistant',
                                            labelWidth: 120,
                                            fieldStyle: 'background-color:#DAEBE1;background-image:none;'
                                        },
                                        {
                                            xtype: 'textfield',
                                            margin: '0 0 0 5',
                                            fieldLabel: '',
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;',
                                            size: 26
                                        },
                                        {
                                            xtype: 'textfield',
                                            fieldLabel: 'Loan Heading',
                                            labelWidth: 120,
                                            fieldStyle: 'background-color:#DAEBE1;background-image:none;'
                                        },
                                        {
                                            xtype: 'textfield',
                                            margin: '0 0 0 5',
                                            fieldLabel: '',
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;',
                                            size: 26
                                        },
                                        {
                                            xtype: 'textfield',
                                            fieldLabel: 'Loan Purpose',
                                            labelWidth: 120,
                                            fieldStyle: 'background-color:#DAEBE1;background-image:none;'
                                        },
                                        {
                                            xtype: 'textfield',
                                            margin: '0 0 0 5',
                                            fieldLabel: '',
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;',
                                            size: 26
                                        }
                                    ]
                                },
                                {
                                    xtype: 'container',
                                    margin: '0 0 0 5',
                                    items: [
                                        {
                                            xtype: 'textfield',
                                            fieldLabel: 'Grace Days',
                                            labelWidth: 125
                                        },
                                        {
                                            xtype: 'textfield',
                                            fieldLabel: '1st Intall Date(B.S.)',
                                            labelWidth: 125,
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                        },
                                        {
                                            xtype: 'textfield',
                                            fieldLabel: 'Maturity Date(B.S.)',
                                            labelWidth: 125,
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                        }
                                    ]
                                },
                                {
                                    xtype: 'container',
                                    margin: '0 0 0 5',
                                    items: [
                                        {
                                            xtype: 'textfield',
                                            fieldLabel: 'Collection Day',
                                            labelWidth: 120,
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                        },
                                        {
                                            xtype: 'textfield',
                                            fieldLabel: '1st Install Date(A.D.)',
                                            labelWidth: 120,
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                        },
                                        {
                                            xtype: 'textfield',
                                            fieldLabel: 'Maturity Date(A.D.)',
                                            labelWidth: 120,
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                        }
                                    ]
                                },
                                {
                                    xtype: 'textfield',
                                    fieldLabel: 'Loan Sector',
                                    labelWidth: 120,
                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                },
                                {
                                    xtype: 'textfield',
                                    fieldLabel: 'No. of Installment',
                                    labelWidth: 125,
                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                },
                                {
                                    xtype: 'textfield',
                                    fieldLabel: 'Installment Amt',
                                    labelWidth: 124,
                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                },
                                {
                                    xtype: 'textfield',
                                    fieldLabel: 'App. Loan Amt',
                                    labelWidth: 120
                                },
                                {
                                    xtype: 'textfield',
                                    fieldLabel: 'Fixed Principle Amt',
                                    labelWidth: 125
                                },
                                {
                                    xtype: 'textfield',
                                    fieldLabel: 'Fixed Interest Amt',
                                    labelWidth: 124,
                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                },
                                {
                                    xtype: 'textfield',
                                    fieldLabel: 'Total Loan Taken',
                                    labelWidth: 120
                                },
                                {
                                    xtype: 'textfield',
                                    fieldLabel: 'Contra Account',
                                    labelWidth: 125,
                                    fieldStyle: 'background-color:#DAEBE1;background-image:none;'
                                },
                                {
                                    xtype: 'textfield',
                                    colspan: 2,
                                    fieldLabel: '',
                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                },
                                {
                                    xtype: 'combobox',
                                    fieldLabel: 'Funding Agency',
                                    labelWidth: 120
                                },
                                {
                                    xtype: 'container',
                                    colspan: 2,
                                    layout: {
                                        type: 'table',
                                        columns: 3
                                    },
                                    items: [
                                        {
                                            xtype: 'checkboxfield',
                                            fieldLabel: 'Adjust to Saving',
                                            labelWidth: 110,
                                            boxLabel: ''
                                        },
                                        {
                                            xtype: 'textfield',
                                            margin: '0 0 0 5',
                                            fieldLabel: '',
                                            labelWidth: 125
                                        },
                                        {
                                            xtype: 'textfield',
                                            margin: '0 0 0 5',
                                            fieldLabel: '',
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                        }
                                    ]
                                },
                                {
                                    xtype: 'textfield',
                                    colspan: 3,
                                    fieldLabel: 'Policy No.',
                                    labelWidth: 120
                                },
                                {
                                    xtype: 'button',
                                    colspan: 3,
                                    style: '{',
                                    text: 'Repayment Schedule'
                                },
                                {
                                    xtype: 'container',
                                    colspan: 3,
                                    height: 30,
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
                                    xtype: 'fieldset',
                                    colspan: 3,
                                    title: 'Search',
                                    layout: {
                                        type: 'table',
                                        columns: 2
                                    },
                                    items: [
                                        {
                                            xtype: 'textfield',
                                            fieldLabel: 'Open Date From(B.S.)',
                                            labelWidth: 130
                                        },
                                        {
                                            xtype: 'textfield',
                                            margin: '0 0 0 5',
                                            fieldLabel: 'Open Date To(B.S.)',
                                            labelWidth: 130
                                        },
                                        {
                                            xtype: 'textfield',
                                            fieldLabel: 'Loan No.',
                                            labelWidth: 130,
                                            fieldStyle: 'background-color:#DAEBE1;background-image:none;',
                                            size: 50
                                        },
                                        {
                                            xtype: 'textfield',
                                            margin: '0 0 0 5',
                                            fieldLabel: 'Member Name',
                                            labelWidth: 130,
                                            size: 50
                                        },
                                        {
                                            xtype: 'container',
                                            colspan: 3,
                                            height: 30,
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
                        }
                    ]
                }
            ],
            tools: [
                {
                    xtype: 'tool',
                    handler: function(event, toolEl, owner, tool) {
                        Ext.MessageBox.confirm('Reset Form', 'Are you sure ?', function(btn){


                            if(btn === 'yes'){
                                Ext.ComponentQuery.query("#frm-MicroFinanceLoanDisbursement")[0].getForm().reset();
                            }
                            else
                            {

                            }

                        });
                    },
                    cls: 'popupTool'
                }
            ]
        });

        me.callParent(arguments);
    }

});