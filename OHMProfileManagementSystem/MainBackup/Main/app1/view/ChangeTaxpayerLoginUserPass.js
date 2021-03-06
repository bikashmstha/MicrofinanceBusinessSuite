/*
 * File: app/view/ChangeTaxpayerLoginUserPass.js
 *
 * This file was generated by Sencha Architect version 2.1.0.
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

Ext.define('MyApp.view.ChangeTaxpayerLoginUserPass', {
    extend: 'Ext.panel.Panel',

    frame: true,
    height: 400,
    id: '',
    itemId: 'pnlChangeTaxpayerLoginUser',
    title: 'करदाताको प्रयोगकर्ताको पासवर्ड  परिवर्तन गर्ने  फाराम ',

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'form',
                    frame: true,
                    height: 323,
                    itemId: 'frmChangeTaxpayerLoginUser',
                    bodyPadding: 10,
                    title: '',
                    items: [
                        {
                            xtype: 'container',
                            layout: {
                                columns: 2,
                                type: 'table'
                            },
                            items: [
                                {
                                    xtype: 'container',
                                    padding: 5,
                                    width: 286,
                                    layout: {
                                        columns: 1,
                                        type: 'table'
                                    },
                                    items: [
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtChangeTaxpayerLoginPan',
                                            fieldLabel: 'स्थायी लेखा नम्बर *',
                                            labelWidth: 120,
                                            allowBlank: false,
                                            enforceMaxLength: true,
                                            maskRe: /[0-9]/,
                                            maxLength: 9,
                                            minLength: 9,
                                            size: 9
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtChangeTaxpayerLoginUserName',
                                            fieldLabel: 'प्रयोगकर्ताको नाम  *',
                                            labelWidth: 120,
                                            allowBlank: false,
                                            blankText: 'Username Can\'t Be Left Blank',
                                            maxLength: 25,
                                            minLength: 5
                                        },
                                        {
                                            xtype: 'textfield',
                                            hidden: false,
                                            id: '',
                                            itemId: 'txtChangeTaxpayerLoginOldPassWord',
                                            inputType: 'password',
                                            fieldLabel: 'पुरानो पासवर्ड *',
                                            labelWidth: 120,
                                            allowBlank: false,
                                            enforceMaxLength: true,
                                            maxLength: 10,
                                            minLength: 5
                                        },
                                        {
                                            xtype: 'textfield',
                                            id: '',
                                            itemId: 'txtChangeTaxpayerLoginNewPassword',
                                            inputType: 'password',
                                            fieldLabel: 'नयाँ पासवर्ड *',
                                            labelWidth: 120,
                                            allowBlank: false,
                                            enforceMaxLength: true,
                                            maxLength: 10,
                                            minLength: 5
                                        },
                                        {
                                            xtype: 'textfield',
                                            id: '',
                                            itemId: 'txtChangeTaxpayerLoginConformPassword',
                                            inputType: 'password',
                                            fieldLabel: 'कनफर्रम पासवर्ड *',
                                            labelWidth: 120,
                                            allowBlank: false,
                                            enforceMaxLength: true,
                                            maxLength: 10,
                                            minLength: 5
                                        }
                                    ]
                                },
                                {
                                    xtype: 'container',
                                    items: [
                                        {
                                            xtype: 'container',
                                            itemId: 'cntTaxpayerLogin',
                                            margin: '-50 20 0 20',
                                            width: 293,
                                            layout: {
                                                columns: 1,
                                                type: 'table'
                                            },
                                            items: [
                                                {
                                                    xtype: 'label',
                                                    margin: '5 0 5 10',
                                                    text: ' करदाताको प्रयोगकर्ताको पासवर्ड  परिवर्तन गर्ने  तरिका'
                                                },
                                                {
                                                    xtype: 'label',
                                                    margin: '5 0 15 0',
                                                    text: '१. स्थायी लेखा नम्बर भर्नुहोस्'
                                                },
                                                {
                                                    xtype: 'label',
                                                    margin: '5 0 5 0',
                                                    width: 310,
                                                    text: '२.प्रयोगकर्ताको नाम भर्नुहोस्'
                                                },
                                                {
                                                    xtype: 'label',
                                                    hidden: false,
                                                    margin: '5 0 5 0',
                                                    text: '३. पुरानो पासवर्ड भर्नुहोस् '
                                                },
                                                {
                                                    xtype: 'label',
                                                    margin: '5 0 5 0',
                                                    text: '४. नयाँ पासवर्ड  भर्नुहोस्  '
                                                },
                                                {
                                                    xtype: 'label',
                                                    margin: '5 0 5 0',
                                                    text: '५. कनफर्रम पासवर्ड भर्नुहोस् '
                                                }
                                            ]
                                        }
                                    ]
                                }
                            ]
                        },
                        {
                            xtype: 'container',
                            padding: '0 0 0 150',
                            layout: {
                                type: 'column'
                            },
                            items: [
                                {
                                    xtype: 'button',
                                    id: '',
                                    itemId: 'btnChangeTaxpayerLoginPassword',
                                    icon: '',
                                    iconCls: 'icon-ok',
                                    text: 'Change'
                                },
                                {
                                    xtype: 'button',
                                    id: '',
                                    itemId: 'btnChangeTaxpayerLoginReset',
                                    margin: '0 0 0 10',
                                    icon: '',
                                    iconCls: 'icon-cancel',
                                    text: 'Reset'
                                },
                                {
                                    xtype: 'hiddenfield',
                                    itemId: 'hdnChangeTaxpayerAction',
                                    fieldLabel: 'Label'
                                },
                                {
                                    xtype: 'label',
                                    margin: '10  20 0 10',
                                    text: '* चिन्ह भएको सबै कोष्ठहरु भर्न जरुरी छ ।'
                                }
                            ]
                        },
                        {
                            xtype: 'hiddenfield',
                            anchor: '100%',
                            itemId: 'hdnChangeTaxpayerLoginOffice',
                            fieldLabel: 'Label'
                        }
                    ]
                }
            ]
        });

        me.callParent(arguments);
    }

});