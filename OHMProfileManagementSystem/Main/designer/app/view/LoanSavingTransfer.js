/*
 * File: app/view/LoanSavingTransfer.js
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

Ext.define('MyApp.view.LoanSavingTransfer', {
    extend: 'Ext.panel.Panel',

    requires: [
        'Ext.tab.Panel',
        'Ext.tab.Tab',
        'Ext.form.Panel',
        'Ext.form.field.ComboBox'
    ],

    frame: true,
    title: 'Loan Saving Transfer',

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'tabpanel',
                    hidden: true,
                    activeTab: 0,
                    items: [
                        {
                            xtype: 'panel',
                            frame: true,
                            itemId: 'tabLoanTransfer',
                            title: 'Loan Transfer',
                            layout: {
                                type: 'table',
                                columns: 2
                            }
                        },
                        {
                            xtype: 'panel',
                            frame: true,
                            itemId: '',
                            title: 'Saving Transfer',
                            layout: {
                                type: 'table',
                                columns: 1
                            },
                            tabConfig: {
                                xtype: 'tab',
                                itemId: 'tabSavingTransfer'
                            }
                        }
                    ]
                },
                {
                    xtype: 'tabpanel',
                    activeTab: 0,
                    items: [
                        {
                            xtype: 'panel',
                            title: 'Loan Transfer',
                            items: [
                                {
                                    xtype: 'form',
                                    frame: true,
                                    bodyPadding: 10,
                                    title: 'From',
                                    layout: {
                                        type: 'table',
                                        columns: 2
                                    },
                                    items: [
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtFromCenterCode',
                                            fieldLabel: 'Center Code',
                                            fieldStyle: 'background-color:#DAEBE1;background-image:none;'
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtFromCenterDesc',
                                            margin: '0 0 0 010',
                                            fieldLabel: '',
                                            fieldStyle: ' background-color:#D2D2D2;background-image:none;',
                                            size: 70
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtFromMemberCode',
                                            fieldLabel: 'Member Code',
                                            fieldStyle: 'background-color:#DAEBE1;background-image:none;'
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtFromMemberDesc',
                                            margin: '0 0 0 010',
                                            fieldLabel: 'Label',
                                            hideLabel: true,
                                            fieldStyle: ' background-color:#D2D2D2;background-image:none;',
                                            size: 70
                                        },
                                        {
                                            xtype: 'combobox',
                                            colspan: 2,
                                            itemId: 'ddlFromLoanType',
                                            fieldLabel: 'Loan Type',
                                            fieldStyle: 'background-color:#DAEBE1;background-image:none;',
                                            size: 50,
                                            displayField: 'LoanProduct_Name',
                                            queryMode: 'local',
                                            store: 'LoanProductCodeStore',
                                            valueField: 'LoanProduct_Code'
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtFromLoanNo',
                                            fieldLabel: 'Loan No',
                                            fieldStyle: 'background-color:#DAEBE1;background-image:none;'
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtFromLoanNoDesc',
                                            margin: '0 0 0 10',
                                            fieldLabel: 'Label',
                                            hideLabel: true,
                                            fieldStyle: ' background-color:#D2D2D2;background-image:none;',
                                            size: 70
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtFromLoanDateBS',
                                            fieldLabel: 'Loan Date(B.S.)',
                                            fieldStyle: ' background-color:#D2D2D2;background-image:none;'
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtFromLoanDateAD',
                                            margin: '0 0 0 10',
                                            fieldLabel: 'Loan Date(A.D.)',
                                            fieldStyle: ' background-color:#D2D2D2;background-image:none;'
                                        }
                                    ]
                                },
                                {
                                    xtype: 'form',
                                    frame: true,
                                    bodyPadding: 10,
                                    title: 'To',
                                    layout: {
                                        type: 'table',
                                        columns: 3
                                    },
                                    items: [
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtToCenterCode',
                                            fieldLabel: 'Center Code',
                                            fieldStyle: 'background-color:#DAEBE1;background-image:none;'
                                        },
                                        {
                                            xtype: 'textfield',
                                            colspan: 2,
                                            itemId: 'txtToCenterDesc',
                                            margin: '0 0 0 10',
                                            fieldLabel: 'Label',
                                            hideLabel: true,
                                            fieldStyle: ' background-color:#D2D2D2;background-image:none;',
                                            size: 70
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtToMemberCode',
                                            fieldLabel: 'Member Code',
                                            fieldStyle: 'background-color:#DAEBE1;background-image:none;'
                                        },
                                        {
                                            xtype: 'textfield',
                                            colspan: 2,
                                            itemId: 'txtToMemberDesc',
                                            margin: '0 0 0 10',
                                            fieldLabel: 'Member Code',
                                            hideLabel: true,
                                            fieldStyle: ' background-color:#D2D2D2;background-image:none;',
                                            size: 70
                                        },
                                        {
                                            xtype: 'combobox',
                                            colspan: 3,
                                            itemId: 'ddlToLoanType',
                                            fieldLabel: 'Loan Type',
                                            fieldStyle: 'background-color:#DAEBE1;background-image:none;',
                                            size: 50,
                                            displayField: 'LoanProduct_Name',
                                            queryMode: 'local',
                                            store: 'LoanProductCodeStore',
                                            valueField: 'LoanProduct_Code'
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtToLoanPurposeCode',
                                            fieldLabel: 'Loan Purpose',
                                            fieldStyle: 'background-color:#DAEBE1;background-image:none;'
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtToLoanPurposeDesc',
                                            margin: '0 0 0 10',
                                            fieldLabel: 'Label',
                                            hideLabel: true,
                                            fieldStyle: ' background-color:#D2D2D2;background-image:none;',
                                            size: 30
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtToLoanDateBS',
                                            margin: '0 0 0 10',
                                            fieldLabel: 'Loan Date(B.S.)',
                                            fieldStyle: ' background-color:#D2D2D2;background-image:none;'
                                        },
                                        {
                                            xtype: 'textfield',
                                            colspan: 2,
                                            itemId: 'txtToLoanNo',
                                            fieldLabel: 'Loan No',
                                            fieldStyle: ' background-color:#D2D2D2;background-image:none;',
                                            size: 55
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtToLoanDateAD',
                                            margin: '0 0 0 10',
                                            fieldLabel: 'Loan Date(A.D.)',
                                            fieldStyle: ' background-color:#D2D2D2;background-image:none;'
                                        },
                                        {
                                            xtype: 'button',
                                            itemId: 'btnLoanTransfer',
                                            text: 'Transfer'
                                        }
                                    ]
                                }
                            ]
                        },
                        {
                            xtype: 'panel',
                            title: 'Saving Transfer',
                            items: [
                                {
                                    xtype: 'form',
                                    frame: true,
                                    bodyPadding: 10,
                                    title: 'From',
                                    layout: {
                                        type: 'table',
                                        columns: 3
                                    },
                                    items: [
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtSavingFromCenterCode',
                                            fieldLabel: 'Center Code',
                                            fieldStyle: 'background-color:#DAEBE1;background-image:none;'
                                        },
                                        {
                                            xtype: 'textfield',
                                            colspan: 2,
                                            itemId: 'txtSavingFromCenterDesc',
                                            margin: '0 0 0 10',
                                            fieldLabel: 'Label',
                                            hideLabel: true,
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;',
                                            size: 70
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtSavingFromMemberCode',
                                            fieldLabel: 'Member Code',
                                            fieldStyle: 'background-color:#DAEBE1;background-image:none;'
                                        },
                                        {
                                            xtype: 'textfield',
                                            colspan: 2,
                                            itemId: 'txtSavingFromMemberDesc',
                                            margin: '0 0 0 10',
                                            fieldLabel: 'Member Code',
                                            hideLabel: true,
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;',
                                            size: 70
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtFromSavingTypeCode',
                                            fieldLabel: 'Saving Type',
                                            fieldStyle: 'background-color:#DAEBE1;background-image:none;'
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtFromSavingTypeDesc',
                                            fieldLabel: '',
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;',
                                            size: 30
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtFromOpenDateBS',
                                            margin: '0 0 0 10',
                                            fieldLabel: 'Open Date(B.S.)',
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                        },
                                        {
                                            xtype: 'textfield',
                                            colspan: 2,
                                            itemId: 'txtFromAccNo',
                                            fieldLabel: 'Account No',
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;',
                                            size: 55
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtFromOpenDateAD',
                                            margin: '0 0 0 10',
                                            fieldLabel: 'Open Date(A.D.)',
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                        }
                                    ]
                                },
                                {
                                    xtype: 'form',
                                    frame: true,
                                    bodyPadding: 10,
                                    title: 'To',
                                    layout: {
                                        type: 'table',
                                        columns: 3
                                    },
                                    items: [
                                        {
                                            xtype: 'container',
                                            colspan: 3,
                                            layout: {
                                                type: 'table',
                                                columns: 2
                                            },
                                            items: [
                                                {
                                                    xtype: 'textfield',
                                                    itemId: 'txtSavingToCenterCode',
                                                    fieldLabel: 'Center Code',
                                                    fieldStyle: 'background-color:#DAEBE1;background-image:none;'
                                                },
                                                {
                                                    xtype: 'textfield',
                                                    colspan: 2,
                                                    itemId: 'txtSavingToCenterDesc',
                                                    margin: '0 0 0 10',
                                                    fieldLabel: 'Label',
                                                    hideLabel: true,
                                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;',
                                                    size: 70
                                                },
                                                {
                                                    xtype: 'textfield',
                                                    itemId: 'txtSavingToMemberCode',
                                                    fieldLabel: 'Member Code',
                                                    fieldStyle: 'background-color:#DAEBE1;background-image:none;'
                                                },
                                                {
                                                    xtype: 'textfield',
                                                    colspan: 2,
                                                    itemId: 'txtSavingToMemberDesc',
                                                    margin: '0 0 0 10',
                                                    fieldLabel: 'Member Code',
                                                    hideLabel: true,
                                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;',
                                                    size: 70
                                                }
                                            ]
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtSavingTypeToCode',
                                            fieldLabel: 'Saving Type',
                                            fieldStyle: 'background-color:#DAEBE1;background-image:none;'
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtSavingTypeToDesc',
                                            fieldLabel: '',
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;',
                                            size: 30
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtSavingToOpenDateBS',
                                            margin: '0 0 0 10',
                                            fieldLabel: 'Open Date(B.S.)',
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                        },
                                        {
                                            xtype: 'textfield',
                                            colspan: 2,
                                            itemId: 'txtSavingToAccNo',
                                            fieldLabel: 'Account No',
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;',
                                            size: 55
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtSavingToOpenDateAD',
                                            margin: '0 0 0 10',
                                            fieldLabel: 'Open Date(A.D.)',
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                        },
                                        {
                                            xtype: 'button',
                                            itemId: 'btnSavingTransfer',
                                            text: 'Transfer'
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