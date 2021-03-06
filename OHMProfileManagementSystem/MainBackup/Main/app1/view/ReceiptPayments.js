/*
 * File: app/view/ReceiptPayments.js
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

Ext.define('MyApp.view.ReceiptPayments', {
    extend: 'Ext.panel.Panel',

    frame: true,
    itemId: 'pnlReceiptPayments',
    autoScroll: true,
    title: 'Receipt Payments',

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'displayfield',
                    height: 25,
                    hidden: true,
                    itemId: 'lblActionRP',
                    width: 800,
                    fieldStyle: '{color:red;}'
                },
                {
                    xtype: 'form',
                    frame: true,
                    itemId: 'frmReceiptPayments',
                    style: 'border:none',
                    layout: {
                        columns: 2,
                        type: 'table'
                    },
                    bodyPadding: 10,
                    title: '',
                    items: [
                        {
                            xtype: 'textfield',
                            itemId: 'txtOfficeCodeRP',
                            width: 180,
                            fieldLabel: 'कार्यलय कोड',
                            labelWidth: 130,
                            msgTarget: 'side',
                            readOnly: true,
                            maskRe: /[0-9]/,
                            maxLength: 4
                        },
                        {
                            xtype: 'textfield',
                            itemId: 'txtAcctTypeRP',
                            margin: '0 0 0 50',
                            width: 140,
                            fieldLabel: 'खाता किसिम',
                            msgTarget: 'side',
                            allowBlank: false,
                            maskRe: /[0-9]/
                        },
                        {
                            xtype: 'textfield',
                            itemId: 'txtPanRP',
                            width: 230,
                            fieldLabel: 'स्था.ले.नं.',
                            labelWidth: 130,
                            msgTarget: 'side',
                            allowBlank: false,
                            enableKeyEvents: true,
                            enforceMaxLength: true,
                            maskRe: /[0-9]/,
                            maxLength: 9,
                            minLength: 9
                        },
                        {
                            xtype: 'textfield',
                            hidden: true,
                            margin: '0 0 0 50',
                            fieldLabel: 'Label'
                        },
                        {
                            xtype: 'textfield',
                            itemId: 'txtTaxPayerNameRP',
                            width: 460,
                            fieldLabel: 'करदाताको नाम',
                            labelWidth: 130,
                            readOnly: true
                        },
                        {
                            xtype: 'textfield',
                            hidden: true,
                            margin: '0 0 0 50',
                            fieldLabel: 'Label'
                        },
                        {
                            xtype: 'textfield',
                            itemId: 'txtTaxPayerAddressRP',
                            width: 460,
                            fieldLabel: 'करदाताको ठेगाना',
                            labelWidth: 130,
                            readOnly: true
                        },
                        {
                            xtype: 'textfield',
                            hidden: true,
                            margin: '0 0 0 50',
                            fieldLabel: 'Label'
                        },
                        {
                            xtype: 'textfield',
                            itemId: 'txtReceiptDateRP',
                            width: 230,
                            fieldLabel: 'बुझाएको मिति',
                            labelWidth: 130,
                            msgTarget: 'side',
                            allowBlank: false,
                            emptyText: 'YYYY.MM.DD'
                        },
                        {
                            xtype: 'textfield',
                            disabled: true,
                            itemId: 'txtSeqNoRP',
                            margin: '0 0 0 50',
                            width: 155,
                            fieldLabel: 'सि. नं.',
                            msgTarget: 'side',
                            readOnly: true,
                            allowBlank: false,
                            enableKeyEvents: true,
                            maskRe: /[0-9]/,
                            maxLength: 6
                        },
                        {
                            xtype: 'combobox',
                            itemId: 'cboPaymentTypeRP',
                            width: 380,
                            fieldLabel: 'पेमेन्ट किसिम',
                            labelWidth: 130,
                            msgTarget: 'side',
                            emptyText: '.....छान्नुहोस्.....',
                            displayField: 'PMTypeDescNep',
                            forceSelection: true,
                            queryMode: 'local',
                            store: 'PaymentTypeStore',
                            typeAhead: true,
                            valueField: 'PMTypeCode'
                        },
                        {
                            xtype: 'label',
                            hidden: true,
                            text: 'My Label'
                        },
                        {
                            xtype: 'fieldcontainer',
                            height: 23,
                            itemId: 'fCntVoucherNoRP',
                            width: 400,
                            layout: {
                                align: 'stretch',
                                type: 'hbox'
                            },
                            fieldLabel: '',
                            items: [
                                {
                                    xtype: 'label',
                                    itemId: 'lbl',
                                    width: 100,
                                    text: 'भौचर नं.'
                                },
                                {
                                    xtype: 'textfield',
                                    itemId: 'txtVoucherNoRP',
                                    margin: '0 0 0 18',
                                    fieldLabel: ''
                                }
                            ]
                        },
                        {
                            xtype: 'label',
                            hidden: true,
                            text: 'My Label'
                        },
                        {
                            xtype: 'combobox',
                            itemId: 'cboBankCodeRP',
                            width: 380,
                            fieldLabel: 'बैंक कोड',
                            labelWidth: 130,
                            msgTarget: 'side',
                            emptyText: '.....छान्नुहोस्.....',
                            displayField: 'BankName',
                            forceSelection: true,
                            queryMode: 'local',
                            store: 'OfficeBankInfo',
                            typeAhead: true,
                            valueField: 'BankBr'
                        },
                        {
                            xtype: 'textfield',
                            itemId: 'txtBranchCodeRP',
                            margin: '0 0 0 50',
                            fieldLabel: 'बैंक शाखा कोड',
                            msgTarget: 'side',
                            readOnly: true
                        },
                        {
                            xtype: 'combobox',
                            itemId: 'cboRevenueAcctNoRP',
                            width: 380,
                            fieldLabel: 'राजस्व खाता नं',
                            labelWidth: 130,
                            msgTarget: 'side',
                            emptyText: '.....छान्नुहोस्.....',
                            displayField: 'AccountDescEng',
                            forceSelection: true,
                            queryMode: 'local',
                            store: 'RevenueAccountStore',
                            typeAhead: true,
                            valueField: 'AccountCode'
                        },
                        {
                            xtype: 'textfield',
                            itemId: 'txtAmountRP',
                            margin: '0 0 0 50',
                            fieldLabel: 'रकम',
                            msgTarget: 'side',
                            fieldStyle: 'text-align:right',
                            maskRe: /[0-9]/,
                            maxLength: 14
                        }
                    ]
                },
                {
                    xtype: 'fieldcontainer',
                    border: 0,
                    itemId: 'fCntRemarksRP',
                    width: 750,
                    fieldLabel: '',
                    items: [
                        {
                            xtype: 'textareafield',
                            height: 80,
                            itemId: 'txtRemarksRP',
                            margin: '0 0 0 15',
                            width: 590,
                            fieldLabel: 'कैफियत',
                            labelWidth: 130,
                            msgTarget: 'side',
                            enableKeyEvents: true
                        }
                    ]
                },
                {
                    xtype: 'fieldcontainer',
                    height: 25,
                    itemId: 'fCntButtonRP',
                    margin: '120 0 0 0',
                    width: 950,
                    layout: {
                        align: 'stretch',
                        pack: 'end',
                        type: 'hbox'
                    },
                    fieldLabel: '',
                    items: [
                        {
                            xtype: 'button',
                            itemId: 'btnSaveRP',
                            iconCls: 'icon-save',
                            text: 'Save'
                        },
                        {
                            xtype: 'splitter'
                        },
                        {
                            xtype: 'button',
                            itemId: 'btnEditRP',
                            iconCls: 'icon-edit',
                            text: 'Edit'
                        },
                        {
                            xtype: 'splitter'
                        },
                        {
                            xtype: 'button',
                            itemId: 'btnDeleteRP',
                            iconCls: 'icon-delete',
                            text: 'Delete'
                        },
                        {
                            xtype: 'splitter'
                        },
                        {
                            xtype: 'button',
                            itemId: 'btnSubmitRP',
                            iconCls: 'icon-submit',
                            text: 'Submit'
                        },
                        {
                            xtype: 'splitter'
                        },
                        {
                            xtype: 'button',
                            itemId: 'btnCancelRP',
                            iconCls: 'icon-cancel',
                            text: 'Cancel'
                        }
                    ]
                },
                {
                    xtype: 'fieldcontainer',
                    height: 25,
                    hidden: true,
                    itemId: 'fCntBtnBackRP',
                    width: 950,
                    layout: {
                        align: 'stretch',
                        pack: 'end',
                        type: 'hbox'
                    },
                    fieldLabel: '',
                    items: [
                        {
                            xtype: 'button',
                            itemId: 'btnBackRP',
                            iconCls: 'icon-back',
                            text: 'Back'
                        }
                    ]
                },
                {
                    xtype: 'hiddenfield',
                    itemId: 'hdnActionRP',
                    fieldLabel: 'Label'
                },
                {
                    xtype: 'hiddenfield',
                    itemId: 'hdnTranNoRP',
                    fieldLabel: 'Label'
                }
            ]
        });

        me.callParent(arguments);
    }

});