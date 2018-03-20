/*
 * File: app/view/DocRequest.js
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

Ext.define('MyApp.view.DocRequest', {
    extend: 'Ext.panel.Panel',

    frame: true,
    height: 450,
    itemId: 'DocRequest',
    padding: '35 0 10 280',
    bodyPadding: '',
    title: 'Document Request',

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'combobox',
                    itemId: 'cboRequestOffice',
                    width: 400,
                    fieldLabel: 'Request Office',
                    emptyText: 'Select ...',
                    displayField: 'OFF_NAME_ENGLISH',
                    queryMode: 'local',
                    store: 'strRequestOffice',
                    valueField: 'OFFICE_CODE'
                },
                {
                    xtype: 'textfield',
                    itemId: 'txtPAN',
                    width: 193,
                    fieldLabel: 'PAN',
                    enforceMaxLength: true,
                    maskRe: /[0-9]/,
                    maxLength: 9,
                    minLength: 9
                },
                {
                    xtype: 'textareafield',
                    height: 80,
                    itemId: 'txtDocumentKeyword',
                    fieldLabel: 'Document Keyword',
                    fieldStyle: ''
                },
                {
                    xtype: 'container',
                    height: 30,
                    maxWidth: 420,
                    minWidth: 420,
                    width: 420,
                    layout: {
                        align: 'stretch',
                        type: 'hbox'
                    },
                    items: [
                        {
                            xtype: 'label',
                            flex: 1,
                            maxWidth: 100,
                            text: 'Request Type'
                        },
                        {
                            xtype: 'radiofield',
                            flex: 1,
                            itemId: 'rbdView',
                            maxWidth: 60,
                            fieldLabel: '',
                            boxLabel: 'View',
                            checked: true,
                            listeners: {
                                focus: {
                                    fn: me.onRbdViewFocus,
                                    scope: me
                                }
                            }
                        },
                        {
                            xtype: 'radiofield',
                            flex: 1,
                            itemId: 'rbdDTransfer',
                            maxWidth: 110,
                            fieldLabel: '',
                            boxLabel: 'Digital Transfer',
                            listeners: {
                                focus: {
                                    fn: me.onRbdDTransferFocus,
                                    scope: me
                                }
                            }
                        },
                        {
                            xtype: 'radiofield',
                            flex: 1,
                            itemId: 'rbdPTransfer',
                            maxWidth: 120,
                            fieldLabel: '',
                            boxLabel: 'Physical Transfer',
                            listeners: {
                                focus: {
                                    fn: me.onRbdPTransferFocus,
                                    scope: me
                                }
                            }
                        }
                    ]
                },
                {
                    xtype: 'container',
                    height: 30,
                    layout: {
                        align: 'stretch',
                        type: 'hbox'
                    },
                    items: [
                        {
                            xtype: 'checkboxfield',
                            flex: 1,
                            hidden: true,
                            itemId: 'chkRequestFor',
                            maxWidth: 200,
                            fieldLabel: 'Request For',
                            boxLabel: 'All',
                            checked: true
                        }
                    ]
                },
                {
                    xtype: 'textfield',
                    itemId: 'txtReqDate',
                    width: 207,
                    fieldLabel: 'Request Date',
                    enableKeyEvents: true,
                    maskRe: /[0-9.]/,
                    listeners: {
                        blur: {
                            fn: me.onTxtReqDateBlur,
                            scope: me
                        }
                    }
                },
                {
                    xtype: 'container',
                    margin: '10 0 0 0',
                    maxWidth: 420,
                    minWidth: 420,
                    padding: '0 0 0 105',
                    width: 420,
                    items: [
                        {
                            xtype: 'button',
                            itemId: 'btnSubmit',
                            iconCls: 'icon-ok',
                            text: 'Submit'
                        },
                        {
                            xtype: 'button',
                            itemId: 'btnCancelDR',
                            margin: '0 0 0 10',
                            iconCls: 'icon-cancel',
                            text: 'Cancel'
                        },
                        {
                            xtype: 'hiddenfield',
                            itemId: 'hdnReqFromDate',
                            fieldLabel: 'Label'
                        }
                    ]
                }
            ]
        });

        me.callParent(arguments);
    },

    onRbdViewFocus: function(component, e, eOpts) {
        Ext.ComponentQuery.query('#rbdDTransfer')[0].setValue(false);
        Ext.ComponentQuery.query('#rbdPTransfer')[0].setValue(false);


    },

    onRbdDTransferFocus: function(component, e, eOpts) {
        Ext.ComponentQuery.query('#rbdView')[0].setValue(false);
        Ext.ComponentQuery.query('#rbdPTransfer')[0].setValue(false);


        Ext.ComponentQuery.query('#rbdDTransfer')[0].setValue(false);
        Ext.ComponentQuery.query('#rbdPTransfer')[0].setValue(false);

    },

    onRbdPTransferFocus: function(component, e, eOpts) {
        Ext.ComponentQuery.query('#rbdDTransfer')[0].setValue(false);
        Ext.ComponentQuery.query('#rbdView')[0].setValue(false);
    },

    onTxtReqDateBlur: function(component, e, eOpts) {

        return validateFutureDate(field.getValue(),"Y",function(){ field.focus();});
    }

});