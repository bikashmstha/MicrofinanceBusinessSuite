/*
 * File: app/view/MFLoanRepayment.js
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

Ext.define('MyApp.view.MFLoanRepayment', {
    extend: 'Ext.panel.Panel',

    requires: [
        'Ext.form.Panel',
        'Ext.form.field.ComboBox',
        'Ext.form.FieldSet',
        'Ext.button.Button',
        'Ext.form.Label',
        'Ext.form.field.Checkbox'
    ],

    frame: true,
    autoScroll: true,
    title: 'Micro Finance Loan Repayment',

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'form',
                    frame: true,
                    id: 'frm-MFLoanRepayment',
                    itemId: 'frm-MFLoanRepayment',
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
                                    fieldLabel: 'Payment Date(B.S.)',
                                    labelWidth: 160,
                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                },
                                {
                                    xtype: 'textfield',
                                    fieldLabel: 'Payment Date(A.D.)',
                                    labelWidth: 115,
                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                },
                                {
                                    xtype: 'combobox',
                                    colspan: 2,
                                    fieldLabel: 'Center Code',
                                    labelWidth: 160,
                                    fieldStyle: 'background-color:#DAEBE1;background-image:none;',
                                    size: 62
                                },
                                {
                                    xtype: 'combobox',
                                    colspan: 2,
                                    fieldLabel: 'Loan Product',
                                    labelWidth: 160,
                                    fieldStyle: 'background-color:#DAEBE1;background-image:none;',
                                    size: 62
                                },
                                {
                                    xtype: 'combobox',
                                    colspan: 1,
                                    fieldLabel: 'Loan No.',
                                    labelWidth: 160,
                                    fieldStyle: 'background-color:#DAEBE1;background-image:none;',
                                    size: 62
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
                                            labelWidth: 115,
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                        },
                                        {
                                            xtype: 'textfield',
                                            fieldLabel: '',
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                        }
                                    ]
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
                                                    fieldLabel: 'Past Principle',
                                                    labelWidth: 150,
                                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                                },
                                                {
                                                    xtype: 'textfield',
                                                    margin: '0 0 0 5',
                                                    fieldLabel: 'Current Principle',
                                                    labelWidth: 115,
                                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                                },
                                                {
                                                    xtype: 'textfield',
                                                    fieldLabel: 'Past Interest',
                                                    labelWidth: 150,
                                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                                },
                                                {
                                                    xtype: 'textfield',
                                                    margin: '0 0 0 5',
                                                    fieldLabel: 'Current Interest',
                                                    labelWidth: 115,
                                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                                },
                                                {
                                                    xtype: 'textfield',
                                                    fieldLabel: 'Penalty On Interest',
                                                    labelWidth: 150,
                                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                                },
                                                {
                                                    xtype: 'textfield',
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
                                                    fieldLabel: 'Principal Balance',
                                                    labelWidth: 110,
                                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                                },
                                                {
                                                    xtype: 'textfield',
                                                    margin: '0 0 0 5',
                                                    fieldLabel: 'Interest Balance',
                                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                                },
                                                {
                                                    xtype: 'textfield',
                                                    fieldLabel: 'Penalty Balance',
                                                    labelWidth: 110,
                                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                                },
                                                {
                                                    xtype: 'textfield',
                                                    margin: '0 0 0 5',
                                                    fieldLabel: 'Total Balance',
                                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                                }
                                            ]
                                        }
                                    ]
                                },
                                {
                                    xtype: 'fieldset',
                                    colspan: 2,
                                    title: '',
                                    layout: {
                                        type: 'table',
                                        columns: 5
                                    },
                                    items: [
                                        {
                                            xtype: 'textfield',
                                            colspan: 1,
                                            fieldLabel: 'Interest Recover on Mid Term Loan Close',
                                            labelWidth: 150,
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                        },
                                        {
                                            xtype: 'button',
                                            margin: '0 0 0 100',
                                            text: 'Generate int'
                                        },
                                        {
                                            xtype: 'label',
                                            margin: '0 0 0 100',
                                            text: 'Generate Offline Int.:'
                                        },
                                        {
                                            xtype: 'button',
                                            margin: '0 0 0 5',
                                            text: 'Before Coll Date'
                                        },
                                        {
                                            xtype: 'button',
                                            margin: '0 0 0 100',
                                            text: 'After Coll Date'
                                        }
                                    ]
                                },
                                {
                                    xtype: 'textfield',
                                    colspan: 2,
                                    fieldLabel: 'Received Amount',
                                    labelWidth: 160
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
                                            fieldLabel: 'Principle Received',
                                            labelWidth: 150,
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                        },
                                        {
                                            xtype: 'textfield',
                                            margin: '0 0 0 5',
                                            fieldLabel: 'Interest Received',
                                            labelWidth: 115,
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                        },
                                        {
                                            xtype: 'checkboxfield',
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
                                            fieldLabel: 'Penalty Received',
                                            labelWidth: 150,
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                        },
                                        {
                                            xtype: 'textfield',
                                            margin: '0 0 0 5',
                                            fieldLabel: 'Total Received',
                                            labelWidth: 115,
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                        },
                                        {
                                            xtype: 'textfield',
                                            margin: '0 0 0 5',
                                            fieldLabel: 'Current Saving Balance',
                                            labelWidth: 130,
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                        },
                                        {
                                            xtype: 'textfield',
                                            margin: '0 0 0 5',
                                            fieldLabel: 'Cheque No.'
                                        },
                                        {
                                            xtype: 'combobox',
                                            colspan: 4,
                                            fieldLabel: 'Contra Account',
                                            labelWidth: 150,
                                            fieldStyle: 'background-color:#DAEBE1;background-image:none;'
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
                                            fieldLabel: 'Payment Date From(B.S.)',
                                            labelWidth: 150
                                        },
                                        {
                                            xtype: 'textfield',
                                            fieldLabel: 'Payment Date From(A.D.)',
                                            labelWidth: 150
                                        },
                                        {
                                            xtype: 'combobox',
                                            fieldLabel: 'Loan No.',
                                            labelWidth: 150,
                                            fieldStyle: 'background-color:#DAEBE1;background-image:none;',
                                            size: 62
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
            ]
        });

        me.callParent(arguments);
    }

});