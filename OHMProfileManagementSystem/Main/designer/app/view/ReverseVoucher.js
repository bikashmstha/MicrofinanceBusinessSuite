/*
 * File: app/view/ReverseVoucher.js
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

Ext.define('MyApp.view.ReverseVoucher', {
    extend: 'Ext.panel.Panel',

    requires: [
        'Ext.form.Panel',
        'Ext.form.field.ComboBox',
        'Ext.button.Button',
        'Ext.grid.Panel',
        'Ext.grid.View',
        'Ext.grid.column.Number',
        'Ext.grid.column.Date',
        'Ext.grid.column.Boolean'
    ],

    frame: true,
    itemId: 'frmReverseVoucher',
    width: 1108,
    title: 'Reverse Voucher',

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'form',
                    frame: true,
                    width: 1097,
                    bodyPadding: 10,
                    title: 'Journal Voucher Master',
                    layout: {
                        type: 'table',
                        columns: 4
                    },
                    items: [
                        {
                            xtype: 'textfield',
                            itemId: 'txtVoucherNo',
                            fieldLabel: 'Voucher No',
                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                        },
                        {
                            xtype: 'textfield',
                            itemId: 'txtFiscalYear',
                            margin: '0 0 0 10',
                            fieldLabel: 'Fiscal Year',
                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                        },
                        {
                            xtype: 'textfield',
                            itemId: 'txtTransactionDateBS',
                            margin: '0 0 0 10',
                            fieldLabel: 'Transaction Date(B.S.)',
                            labelWidth: 130,
                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                        },
                        {
                            xtype: 'textfield',
                            itemId: 'txtTransactionDateAD',
                            margin: '0 0 0 10',
                            fieldLabel: '(A.D.)',
                            labelWidth: 80,
                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                        },
                        {
                            xtype: 'combobox',
                            colspan: 4,
                            itemId: 'ddlReserveVoucher',
                            fieldLabel: 'Reverse Voucher',
                            fieldStyle: 'background-color:#DAEBE1;background-image:none;',
                            size: 60
                        },
                        {
                            xtype: 'combobox',
                            colspan: 2,
                            fieldLabel: 'Particulars',
                            fieldStyle: 'background-color:#DAEBE1;background-image:none;',
                            size: 60,
                            displayField: 'NarrationDesc',
                            forceSelection: true,
                            queryMode: 'local',
                            store: 'RecVoucParticularStore',
                            valueField: 'NarrationCode'
                        },
                        {
                            xtype: 'textfield',
                            colspan: 4,
                            margin: '0 0 0 10',
                            fieldLabel: 'Remarks',
                            labelWidth: 130,
                            size: 60
                        },
                        {
                            xtype: 'container',
                            colspan: 4,
                            height: 30,
                            itemId: 'btnViewVoucherDetails',
                            margin: '10 0 0 0 ',
                            layout: {
                                type: 'hbox',
                                align: 'stretch',
                                pack: 'center'
                            },
                            items: [
                                {
                                    xtype: 'button',
                                    itemId: 'btnViewVoucherDetails',
                                    text: 'View Voucher Detail'
                                }
                            ]
                        }
                    ]
                },
                {
                    xtype: 'form',
                    frame: true,
                    width: 1095,
                    bodyPadding: 10,
                    title: 'Reverse Voucher Detail',
                    layout: {
                        type: 'table',
                        columns: 4
                    },
                    items: [
                        {
                            xtype: 'gridpanel',
                            colspan: 4,
                            itemId: 'grdRecVouDetails',
                            width: 1081,
                            title: 'ReserveVoucher',
                            store: 'ReserveVoucherDetailsStore',
                            columns: [
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'TransactionId',
                                    text: 'TransactionId'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'AccountCode',
                                    text: 'AccountCode'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'Particulars',
                                    text: 'Particulars'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'Amount',
                                    text: 'Amount'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'DrCrFlag',
                                    text: 'DrCrFlag'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'Remarks',
                                    text: 'Remarks'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'AccountNo',
                                    text: 'AccountNo'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'AccountDesc',
                                    text: 'AccountDesc'
                                }
                            ]
                        },
                        {
                            xtype: 'container',
                            colspan: 4,
                            margin: '10 0 0 0',
                            width: 1080,
                            layout: {
                                type: 'hbox',
                                align: 'stretch',
                                pack: 'center'
                            },
                            items: [
                                {
                                    xtype: 'button',
                                    itemId: 'btnReserveGivenVoucher',
                                    text: 'Reverse Given Voucher'
                                }
                            ]
                        }
                    ]
                },
                {
                    xtype: 'form',
                    frame: true,
                    width: 1094,
                    bodyPadding: 10,
                    title: 'Search',
                    layout: {
                        type: 'table',
                        columns: 2
                    },
                    items: [
                        {
                            xtype: 'textfield',
                            fieldLabel: 'Transaction Date From(B.S.)',
                            labelWidth: 160
                        },
                        {
                            xtype: 'textfield',
                            fieldLabel: 'Transaction Date To(B.S.)',
                            labelWidth: 160
                        },
                        {
                            xtype: 'combobox',
                            fieldLabel: 'Voucher No',
                            labelWidth: 160,
                            fieldStyle: 'background-color:#DAEBE1;background-image:none;',
                            size: 50
                        },
                        {
                            xtype: 'button',
                            margin: '0 0 0 200',
                            text: 'Search'
                        },
                        {
                            xtype: 'gridpanel',
                            colspan: 2,
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
                            ]
                        }
                    ]
                }
            ]
        });

        me.callParent(arguments);
    }

});