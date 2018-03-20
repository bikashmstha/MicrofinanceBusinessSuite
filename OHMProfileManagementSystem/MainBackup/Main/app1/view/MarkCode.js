/*
 * File: app/view/MarkCode.js
 *
 * This file was generated by Sencha Architect version 2.2.2.
 * http://www.sencha.com/products/architect/
 *
 * This file requires use of the Ext JS 4.0.x library, under independent license.
 * License of Sencha Architect does not include license for Ext JS 4.0.x. For more
 * details see http://www.sencha.com/license or contact license@sencha.com.
 *
 * This file will be auto-generated each and everytime you save your project.
 *
 * Do NOT hand edit this file.
 */

Ext.define('MyApp.view.MarkCode', {
    extend: 'Ext.panel.Panel',

    frame: true,
    id: 'MarkCode',
    itemId: 'MarkCode',
    layout: {
        align: 'stretch',
        type: 'hbox'
    },
    title: 'Mark Code',

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'panel',
                    flex: 1,
                    frame: true,
                    maxWidth: 160,
                    title: 'Mark Code List',
                    items: [
                        {
                            xtype: 'container',
                            id: 'contMCList',
                            itemId: 'contMCList',
                            margin: '0 5 0 0 ',
                            items: [
                                {
                                    xtype: 'gridpanel',
                                    height: 350,
                                    id: 'grdMarkCodeLIst',
                                    itemId: 'grdMarkCodeLIst',
                                    maxHeight: 350,
                                    minHeight: 200,
                                    width: 150,
                                    autoScroll: true,
                                    store: 'MarkCodes',
                                    columns: [
                                        {
                                            xtype: 'rownumberer'
                                        },
                                        {
                                            xtype: 'gridcolumn',
                                            hidden: true,
                                            dataIndex: 'MarkCode',
                                            text: 'MarkCode'
                                        },
                                        {
                                            xtype: 'gridcolumn',
                                            width: 130,
                                            dataIndex: 'MarkDesc',
                                            text: 'Mark Description'
                                        },
                                        {
                                            xtype: 'gridcolumn',
                                            hidden: true,
                                            dataIndex: 'AcctType',
                                            text: 'AcctType'
                                        }
                                    ]
                                }
                            ]
                        }
                    ]
                },
                {
                    xtype: 'panel',
                    flex: 2,
                    margins: '0 0 0 10',
                    frame: true,
                    id: 'MarkCodeFields',
                    itemId: 'MarkCodeFields',
                    items: [
                        {
                            xtype: 'container',
                            margin: '40 70 70 40 ',
                            items: [
                                {
                                    xtype: 'container',
                                    items: [
                                        {
                                            xtype: 'textfield',
                                            id: 'txtMarkCode',
                                            itemId: 'txtMarkCode',
                                            fieldLabel: 'Mark Code',
                                            labelWidth: 150,
                                            enforceMaxLength: true,
                                            maxLength: 2,
                                            maxLengthText: 'The maximum length for this field is {2}'
                                        },
                                        {
                                            xtype: 'textfield',
                                            id: 'txtMarkCodeDescEng',
                                            itemId: 'txtMarkCodeDescEng',
                                            fieldLabel: 'Mark Code Desc Eng',
                                            labelWidth: 150,
                                            enforceMaxLength: true,
                                            maxLength: 20
                                        },
                                        {
                                            xtype: 'textfield',
                                            id: 'txtMarkCodeDescNep',
                                            itemId: 'txtMarkCodeDescNep',
                                            fieldLabel: 'Mark Code Desc Nep',
                                            labelWidth: 150,
                                            enforceMaxLength: true,
                                            maxLength: 20
                                        },
                                        {
                                            xtype: 'checkboxgroup',
                                            id: 'chkAccType',
                                            itemId: 'chkAccType',
                                            width: 450,
                                            fieldLabel: 'Account Type',
                                            labelWidth: 150,
                                            items: [
                                                {
                                                    xtype: 'checkboxfield',
                                                    frame: false,
                                                    id: 'chkITAX',
                                                    itemId: 'chkITAX',
                                                    boxLabel: 'Income Tax'
                                                },
                                                {
                                                    xtype: 'checkboxfield',
                                                    id: 'chkEXCISE',
                                                    itemId: 'chkEXCISE',
                                                    boxLabel: 'Excise'
                                                },
                                                {
                                                    xtype: 'checkboxfield',
                                                    id: 'chkVAT',
                                                    itemId: 'chkVAT',
                                                    boxLabel: 'Vat'
                                                }
                                            ]
                                        }
                                    ]
                                },
                                {
                                    xtype: 'container',
                                    items: [
                                        {
                                            xtype: 'button',
                                            id: 'btnSaveMC',
                                            itemId: 'btnSaveMC',
                                            margin: '10 0 0 120',
                                            iconCls: 'icon-save',
                                            text: 'Save'
                                        },
                                        {
                                            xtype: 'button',
                                            id: 'btnCancellMC',
                                            itemId: 'btnCancellMC',
                                            margin: '10 0 0 5',
                                            iconCls: 'icon-cancel',
                                            text: 'Cancel'
                                        },
                                        {
                                            xtype: 'button',
                                            id: 'btnDeleteMC',
                                            itemId: 'btnDeleteMC',
                                            margin: '10 0 0 5',
                                            iconCls: 'icon-delete',
                                            text: 'Delete'
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