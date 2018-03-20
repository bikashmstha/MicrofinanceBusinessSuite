/*
 * File: app/view/VatReason.js
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

Ext.define('MyApp.view.VatReason', {
    extend: 'Ext.panel.Panel',

    frame: true,
    id: 'pnlReason',
    itemId: 'pnlReason',
    layout: {
        align: 'stretch',
        type: 'hbox'
    },
    title: 'Reason',

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'panel',
                    flex: 1,
                    frame: true,
                    id: 'pnlList',
                    itemId: 'pnlList',
                    title: 'List of Reasons',
                    items: [
                        {
                            xtype: 'container',
                            id: 'contList',
                            itemId: 'contList',
                            margin: '0 5 0 0 ',
                            items: [
                                {
                                    xtype: 'gridpanel',
                                    height: 336,
                                    id: 'gridList',
                                    itemId: 'gridList',
                                    width: 200,
                                    hideHeaders: true,
                                    store: 'MaReason',
                                    columns: [
                                        {
                                            xtype: 'gridcolumn',
                                            dataIndex: 'ReasonDescEng'
                                        }
                                    ]
                                }
                            ]
                        }
                    ]
                },
                {
                    xtype: 'panel',
                    flex: 7,
                    margins: '0 0 0 10',
                    frame: true,
                    id: 'pnlFields',
                    itemId: 'pnlFields',
                    title: 'Fields',
                    items: [
                        {
                            xtype: 'form',
                            frame: true,
                            height: 269,
                            id: '',
                            itemId: '',
                            margin: '20 20 20 20',
                            maxHeight: 600,
                            layout: {
                                align: 'stretch',
                                type: 'hbox'
                            },
                            bodyPadding: 10,
                            items: [
                                {
                                    xtype: 'container',
                                    frame: true,
                                    height: 289,
                                    id: 'contDisplay',
                                    itemId: 'contDisplay',
                                    items: [
                                        {
                                            xtype: 'textfield',
                                            id: 'txtCode',
                                            itemId: 'txtCode',
                                            width: 355,
                                            fieldLabel: 'Reason Code',
                                            labelWidth: 200,
                                            allowBlank: false
                                        },
                                        {
                                            xtype: 'textareafield',
                                            height: 40,
                                            id: 'txtDescEng',
                                            itemId: 'txtDescEng',
                                            width: 600,
                                            fieldLabel: 'Description in English',
                                            labelWidth: 200,
                                            allowBlank: false
                                        },
                                        {
                                            xtype: 'textareafield',
                                            height: 40,
                                            id: 'txtDescNep',
                                            itemId: 'txtDescNep',
                                            width: 600,
                                            fieldLabel: 'Description in Nepali (नेपाली मा विवरण)',
                                            labelWidth: 200,
                                            allowBlank: false,
                                            enableKeyEvents: true,
                                            listeners: {
                                                keyup: {
                                                    fn: me.onTxtDescNepKeyup,
                                                    scope: me
                                                }
                                            }
                                        },
                                        {
                                            xtype: 'container',
                                            id: 'contButton',
                                            itemId: 'contButton',
                                            margin: '50 210',
                                            width: 119,
                                            items: [
                                                {
                                                    xtype: 'button',
                                                    id: 'btnRnSubmit',
                                                    itemId: 'btnRnSubmit',
                                                    width: 50,
                                                    text: 'Submit'
                                                },
                                                {
                                                    xtype: 'button',
                                                    id: 'btnRnCancel',
                                                    itemId: 'btnRnCancel',
                                                    width: 50,
                                                    text: 'Cancel'
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
    },

    onTxtDescNepKeyup: function(textfield, e, eOpts) {
        //unicodefunc(e,textfield);
    }

});