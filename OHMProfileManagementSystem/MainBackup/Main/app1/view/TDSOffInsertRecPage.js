/*
 * File: app/view/TDSOffInsertRecPage.js
 *
 * This file was generated by Sencha Architect version 2.2.3.
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

Ext.define('MyApp.view.TDSOffInsertRecPage', {
    extend: 'Ext.panel.Panel',

    frame: true,
    height: 500,
    autoScroll: true,
    title: 'Transaction Information',

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'container',
                    height: 80,
                    margin: '10 0 0 0',
                    layout: {
                        align: 'stretch',
                        type: 'hbox'
                    },
                    items: [
                        {
                            xtype: 'displayfield',
                            id: 'dpfOffIRPTDSTran',
                            itemId: 'dpfOffIRPTDSTran',
                            maxHeight: 25,
                            style: '{font-weight:bold;}',
                            width: 243,
                            fieldLabel: 'Transaction Number',
                            labelWidth: 130
                        },
                        {
                            xtype: 'displayfield',
                            id: 'dpfOffIRPTDSWithPan',
                            itemId: 'dpfOffIRPTDSWithPan',
                            maxHeight: 25,
                            style: '{font-weight:bold;}',
                            width: 260,
                            fieldLabel: 'Witholder PAN Number',
                            labelWidth: 150
                        },
                        {
                            xtype: 'displayfield',
                            id: 'dpfOffIRPTDSWithName',
                            itemId: 'dpfOffIRPTDSWithName',
                            maxHeight: 25,
                            style: '{font-weight:bold;}',
                            width: 300,
                            fieldLabel: 'Witholder Name',
                            labelWidth: 110
                        },
                        {
                            xtype: 'label',
                            margin: '2 0 0 50',
                            maxHeight: 20,
                            style: '{font-weight:bold;}',
                            text: 'TDS Collection Period :'
                        },
                        {
                            xtype: 'displayfield',
                            id: 'dpfOffIRPTDSFrom',
                            itemId: 'dpfOffIRPTDSFrom',
                            margin: '0 0 0 5',
                            maxHeight: 25,
                            fieldLabel: 'From',
                            labelWidth: 40,
                            value: 'Display Field'
                        },
                        {
                            xtype: 'displayfield',
                            margins: '0 0 0 5',
                            id: 'dpfOffIRPTDSTo',
                            itemId: 'dpfOffIRPTDSTo',
                            maxHeight: 25,
                            fieldLabel: 'To',
                            labelWidth: 35,
                            value: 'Display Field'
                        },
                        {
                            xtype: 'displayfield',
                            id: 'dpfOffIRPTDSType',
                            itemId: 'dpfOffIRPTDSType',
                            maxHeight: 25,
                            style: '{font-weight:bold;}',
                            labelWidth: 50,
                            value: 'Display Field'
                        }
                    ]
                },
                {
                    xtype: 'form',
                    frame: true,
                    hidden: true,
                    id: 'frmOffIRPTDSValid',
                    itemId: 'frmOffIRPTDSValid',
                    margin: '0 110 0 10',
                    bodyPadding: 10,
                    items: [
                        {
                            xtype: 'container',
                            height: 49,
                            layout: {
                                align: 'stretch',
                                type: 'hbox'
                            },
                            items: [
                                {
                                    xtype: 'label',
                                    id: 'lblOffIRPTDSPanNo',
                                    itemId: 'lblOffIRPTDSPanNo',
                                    margin: '15 0 0 0',
                                    text: 'PAN Number'
                                },
                                {
                                    xtype: 'label',
                                    id: 'lblOffIRPTDSName',
                                    itemId: 'lblOffIRPTDSName',
                                    margin: '15 0 0 30',
                                    text: 'Name'
                                },
                                {
                                    xtype: 'container',
                                    flex: 1,
                                    margin: '0 0 0 97',
                                    maxWidth: 90,
                                    items: [
                                        {
                                            xtype: 'checkboxgroup',
                                            height: 21,
                                            width: 87,
                                            fieldLabel: 'Payment Date'
                                        },
                                        {
                                            xtype: 'container',
                                            height: 25,
                                            layout: {
                                                align: 'stretch',
                                                type: 'hbox'
                                            },
                                            items: [
                                                {
                                                    xtype: 'checkboxfield',
                                                    flex: 1,
                                                    id: 'chkOffIRPTDSBS',
                                                    itemId: 'chkOffIRPTDSBS',
                                                    boxLabel: 'BS',
                                                    checked: true
                                                },
                                                {
                                                    xtype: 'checkboxfield',
                                                    flex: 1,
                                                    id: 'chkOffIRPTDSAD',
                                                    itemId: 'chkOffIRPTDSAD',
                                                    boxLabel: 'AD'
                                                }
                                            ]
                                        }
                                    ]
                                },
                                {
                                    xtype: 'label',
                                    margin: '15 0 0 5',
                                    text: 'Payment Amount'
                                },
                                {
                                    xtype: 'label',
                                    margin: '15 0 0 5',
                                    text: 'TDS Amount'
                                },
                                {
                                    xtype: 'label',
                                    margin: '15 0 0 20',
                                    text: 'TDS Type'
                                }
                            ]
                        },
                        {
                            xtype: 'container',
                            height: 27,
                            layout: {
                                align: 'stretch',
                                type: 'hbox'
                            },
                            items: [
                                {
                                    xtype: 'textfield',
                                    id: 'txtOffIRPTDSPan',
                                    itemId: 'txtOffIRPTDSPan',
                                    width: 106,
                                    allowBlank: false
                                },
                                {
                                    xtype: 'textfield',
                                    id: 'txtOffIRPTDSName',
                                    itemId: 'txtOffIRPTDSName',
                                    width: 255,
                                    allowBlank: false
                                },
                                {
                                    xtype: 'textfield',
                                    id: 'txtOffIRPTDSPayDate',
                                    itemId: 'txtOffIRPTDSPayDate',
                                    width: 101,
                                    allowBlank: false
                                },
                                {
                                    xtype: 'textfield',
                                    id: 'txtOffIRPTDSPayAmt',
                                    itemId: 'txtOffIRPTDSPayAmt',
                                    width: 107,
                                    allowBlank: false
                                },
                                {
                                    xtype: 'textfield',
                                    id: 'txtOffIRPTDSAmt',
                                    itemId: 'txtOffIRPTDSAmt',
                                    width: 106,
                                    allowBlank: false
                                },
                                {
                                    xtype: 'combobox',
                                    id: 'txtOffIRPTDSType',
                                    itemId: 'txtOffIRPTDSType',
                                    width: 250,
                                    allowBlank: false,
                                    emptyText: '----Select TDS Type----',
                                    enableKeyEvents: true,
                                    displayField: 'TypeDesc',
                                    queryMode: 'local',
                                    store: 'TDSType',
                                    valueField: 'ID'
                                }
                            ]
                        }
                    ]
                },
                {
                    xtype: 'container',
                    height: 26,
                    margin: '5 0 0 10',
                    layout: {
                        align: 'stretch',
                        type: 'hbox'
                    },
                    items: [
                        {
                            xtype: 'toolbar',
                            flex: 1,
                            margin: '0 100 0 0',
                            items: [
                                {
                                    xtype: 'tbseparator'
                                },
                                {
                                    xtype: 'tbseparator'
                                },
                                {
                                    xtype: 'button',
                                    id: 'btnOffIRPTDSInsertVoucher',
                                    itemId: 'btnOffIRPTDSInsertVoucher',
                                    maxWidth: 200,
                                    text: 'Go to Voucher Information'
                                },
                                {
                                    xtype: 'tbseparator'
                                },
                                {
                                    xtype: 'tbseparator'
                                },
                                {
                                    xtype: 'button',
                                    id: 'btnOffIRPTDSPrint',
                                    itemId: 'btnOffIRPTDSPrint',
                                    maxWidth: 80,
                                    text: 'Print Preview'
                                },
                                {
                                    xtype: 'tbseparator'
                                },
                                {
                                    xtype: 'tbseparator'
                                }
                            ]
                        }
                    ]
                },
                {
                    xtype: 'gridpanel',
                    height: 300,
                    id: 'grdOffIRPTDSTranList',
                    itemId: 'grdOffIRPTDSTranList',
                    margin: '0 200 0 10',
                    title: 'List of All Transactions',
                    store: 'TDSTranList',
                    viewConfig: {
                        height: 280
                    },
                    columns: [
                        {
                            xtype: 'gridcolumn',
                            width: 120,
                            dataIndex: 'Pan',
                            text: 'Pan'
                        },
                        {
                            xtype: 'gridcolumn',
                            width: 300,
                            dataIndex: 'Name',
                            text: 'Name'
                        },
                        {
                            xtype: 'gridcolumn',
                            dataIndex: 'TDate',
                            text: 'T Date'
                        },
                        {
                            xtype: 'gridcolumn',
                            width: 150,
                            dataIndex: 'PaymentAmt',
                            text: 'Payment Amount'
                        },
                        {
                            xtype: 'gridcolumn',
                            width: 150,
                            dataIndex: 'TDSAmt',
                            text: 'TDS Amount'
                        },
                        {
                            xtype: 'gridcolumn',
                            width: 150,
                            dataIndex: 'TDSTypeName',
                            text: 'TDS Type'
                        }
                    ]
                },
                {
                    xtype: 'hiddenfield',
                    id: 'hdnOffIRPTDSvdate',
                    itemId: 'hdnOffIRPTDSvdate',
                    fieldLabel: 'Label'
                },
                {
                    xtype: 'hiddenfield',
                    id: 'hdnOffIRPTDSuser',
                    itemId: 'hdnOffIRPTDSuser',
                    fieldLabel: 'Label'
                },
                {
                    xtype: 'hiddenfield',
                    id: 'hdnOffIRPTDSpwd',
                    itemId: 'hdnOffIRPTDSpwd',
                    fieldLabel: 'Label'
                },
                {
                    xtype: 'hiddenfield',
                    id: 'hdnOffIRPTDSsubdate',
                    itemId: 'hdnOffIRPTDSsubdate',
                    fieldLabel: 'Label'
                },
                {
                    xtype: 'hiddenfield',
                    id: 'hdnOffIRPTDSmail',
                    itemId: 'hdnOffIRPTDSmail',
                    fieldLabel: 'Label'
                },
                {
                    xtype: 'hiddenfield',
                    id: 'hdnOffIRPTDSphone',
                    itemId: 'hdnOffIRPTDSphone',
                    fieldLabel: 'Label'
                },
                {
                    xtype: 'hiddenfield',
                    id: 'hdnOffIRPTDSadd',
                    itemId: 'hdnOffIRPTDSadd',
                    fieldLabel: 'Label'
                },
                {
                    xtype: 'hiddenfield',
                    id: 'hdnOffIRPTDStso',
                    itemId: 'hdnOffIRPTDStso',
                    fieldLabel: 'Label'
                },
                {
                    xtype: 'hiddenfield',
                    id: 'hdnOffIRPTDSird',
                    itemId: 'hdnOffIRPTDSird',
                    fieldLabel: 'Label'
                }
            ]
        });

        me.callParent(arguments);
    }

});