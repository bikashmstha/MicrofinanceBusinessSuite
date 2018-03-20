/*
 * File: app/view/DeRegistration.js
 *
 * This file was generated by Sencha Architect version 2.1.0.
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

Ext.define('MyApp.view.DeRegistration', {
    extend: 'Ext.form.Panel',

    draggable: false,
    frame: true,
    height: 536,
    id: 'frmPanDeregistration',
    itemId: 'frmPanDeregistration',
    autoScroll: true,
    layout: {
        type: 'auto'
    },
    bodyPadding: 10,
    title: 'Deregistration',

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'container',
                    style: 'text-align:center;\r\ncolor:green;',
                    items: [
                        {
                            xtype: 'label',
                            itemId: 'DR_lblMsg'
                        }
                    ]
                },
                {
                    xtype: 'form',
                    frame: true,
                    height: 500,
                    width: 800,
                    layout: {
                        columns: 7,
                        type: 'table'
                    },
                    bodyPadding: 10,
                    title: 'स्था . ले . नं .  दर्ता रद',
                    titleCollapse: false,
                    items: [
                        {
                            xtype: 'textfield',
                            colspan: 7,
                            itemId: 'PanDeReg_txtPan',
                            margin: '0 0 10',
                            width: 272,
                            tabIndex: 1,
                            fieldLabel: 'स्था. ले. नं.* ',
                            labelWidth: 75,
                            allowBlank: false,
                            emptyText: '    |    |    |    |    |    |    |    |',
                            enableKeyEvents: true,
                            enforceMaxLength: true,
                            maskRe: /[0-9]/,
                            maxLength: 9
                        },
                        {
                            xtype: 'textfield',
                            colspan: 7,
                            itemId: 'PanDeReg_txtName',
                            margin: '0 0 10',
                            width: 735,
                            readOnly: true,
                            fieldLabel: 'नाम ',
                            labelWidth: 75
                        },
                        {
                            xtype: 'textfield',
                            colspan: 7,
                            itemId: 'PanDeReg_txtPhone',
                            margin: '0 0 10',
                            width: 734,
                            readOnly: true,
                            fieldLabel: 'फोन ',
                            labelWidth: 75
                        },
                        {
                            xtype: 'label',
                            colspan: 2,
                            style: 'margin-right:20px;',
                            text: 'ठेगाना '
                        },
                        {
                            xtype: 'label',
                            margin: '70 0 0 0',
                            style: 'margin-right:10px;',
                            text: 'घर नं .'
                        },
                        {
                            xtype: 'label',
                            style: 'margin-right:30px;',
                            text: 'वार्ड नं .'
                        },
                        {
                            xtype: 'label',
                            style: 'margin-right:10px;',
                            text: 'गांउ / टोल र बाटोको नाम'
                        },
                        {
                            xtype: 'radiogroup',
                            height: 46,
                            style: 'margin-right:10px;',
                            width: 200,
                            fieldLabel: '',
                            columns: 2,
                            items: [
                                {
                                    xtype: 'radiofield',
                                    itemId: 'optbtn_PanDeReg_MNP',
                                    width: 75,
                                    name: 'loc',
                                    readOnly: true,
                                    boxLabel: 'म. न. पा.'
                                },
                                {
                                    xtype: 'radiofield',
                                    itemId: 'optbtn_PanDeReg_UMNP',
                                    name: 'loc',
                                    readOnly: true,
                                    boxLabel: 'उ. म. न. पा.'
                                },
                                {
                                    xtype: 'radiofield',
                                    itemId: 'optbtn_PanDeReg_NP',
                                    width: 75,
                                    name: 'loc',
                                    readOnly: true,
                                    fieldLabel: '',
                                    boxLabel: 'न. पा.'
                                },
                                {
                                    xtype: 'radiofield',
                                    itemId: 'optbtn_PanDeReg_GBS',
                                    name: 'loc',
                                    readOnly: true,
                                    fieldLabel: '',
                                    boxLabel: 'गा. वि. स.'
                                }
                            ]
                        },
                        {
                            xtype: 'label',
                            text: 'जिल्ला'
                        },
                        {
                            xtype: 'textfield',
                            colspan: 3,
                            itemId: 'PanDeReg_txtHouseNo',
                            style: 'margin-left:80px;\r\nmargin-right:10px;',
                            width: 60,
                            readOnly: true,
                            fieldLabel: ''
                        },
                        {
                            xtype: 'textfield',
                            itemId: 'PanDeReg_txtWardNo',
                            style: 'margin-right:10px;',
                            width: 60,
                            readOnly: true,
                            fieldLabel: ''
                        },
                        {
                            xtype: 'textfield',
                            itemId: 'PanDeReg_txtAreaName',
                            style: 'margin-right:10px;',
                            width: 158,
                            readOnly: true,
                            fieldLabel: ''
                        },
                        {
                            xtype: 'textfield',
                            itemId: 'PanDeReg_txtVDCName',
                            style: 'margin-right:10px;',
                            width: 205,
                            readOnly: true,
                            fieldLabel: ''
                        },
                        {
                            xtype: 'textfield',
                            itemId: 'PanDeReg_txtDistrictName',
                            width: 120,
                            readOnly: true,
                            fieldLabel: ''
                        },
                        {
                            xtype: 'combobox',
                            colspan: 4,
                            itemId: 'PanDeReg_ddlDeRegFrom',
                            margin: '10 0 10 0',
                            width: 256,
                            tabIndex: 2,
                            fieldLabel: 'कुन खाता बाट*',
                            labelWidth: 85,
                            allowBlank: false,
                            emptyText: '.....छान्नुहोस्.....',
                            editable: false,
                            displayField: 'AcctTypeDesc',
                            forceSelection: true,
                            queryMode: 'local',
                            store: 'AccountType',
                            typeAhead: false,
                            valueField: 'AcctType'
                        },
                        {
                            xtype: 'textfield',
                            validator: function(value) {

                                var checkValidNDate='';

                                checkValidNDate=validateNepDate(value);

                                return checkValidNDate===''?true:checkValidNDate;

                            },
                            colspan: 4,
                            itemId: 'PanDeReg_txtAppDate',
                            margin: '0 0 0 10',
                            style: 'text-align:10px;',
                            width: 215,
                            tabIndex: 3,
                            fieldLabel: 'निवेदन मिति*',
                            labelWidth: 75,
                            allowBlank: false,
                            emptyText: ' YYYY.MM.DD',
                            enableKeyEvents: true,
                            enforceMaxLength: true,
                            maskRe: /[0-9.]/,
                            maxLength: 10
                        },
                        {
                            xtype: 'displayfield',
                            colspan: 8,
                            fieldLabel: 'दर्ता रदका कारण',
                            labelWidth: 165
                        },
                        {
                            xtype: 'textareafield',
                            colspan: 8,
                            itemId: 'PanDeReg_txtDeRegReason',
                            margin: '0 0 10',
                            width: 734,
                            tabIndex: 4,
                            fieldLabel: ''
                        },
                        {
                            xtype: 'container',
                            colspan: 8,
                            margin: '20 0 ',
                            style: 'text-align:right;',
                            width: 740,
                            items: [
                                {
                                    xtype: 'button',
                                    itemId: 'PanDeReg_btnSave',
                                    margin: '0 5',
                                    width: 82,
                                    iconCls: 'icon-save',
                                    tabIndex: 5,
                                    text: 'Save'
                                },
                                {
                                    xtype: 'button',
                                    itemId: 'PanDeReg_btnEdit',
                                    margin: '0 5',
                                    width: 82,
                                    iconCls: 'icon-edit',
                                    tabIndex: 6,
                                    text: 'Edit'
                                },
                                {
                                    xtype: 'button',
                                    itemId: 'PanDeReg_btnSubmit',
                                    margin: '0 5',
                                    width: 82,
                                    iconCls: 'icon-ok',
                                    tabIndex: 7,
                                    text: 'Submit'
                                },
                                {
                                    xtype: 'button',
                                    itemId: 'PanDeReg_btnCancel',
                                    margin: '0 5',
                                    width: 82,
                                    iconCls: 'icon-cancel',
                                    tabIndex: 8,
                                    text: 'Cancel'
                                }
                            ]
                        },
                        {
                            xtype: 'hiddenfield',
                            itemId: 'hdnTranNo',
                            fieldLabel: 'Label'
                        },
                        {
                            xtype: 'hiddenfield',
                            itemId: 'hdnAction',
                            fieldLabel: 'Label'
                        },
                        {
                            xtype: 'hiddenfield',
                            itemId: 'hdnStatus',
                            fieldLabel: 'Label'
                        }
                    ]
                }
            ]
        });

        me.callParent(arguments);
    }

});