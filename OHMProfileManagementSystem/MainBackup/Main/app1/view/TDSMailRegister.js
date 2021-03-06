/*
 * File: app/view/TDSMailRegister.js
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

Ext.define('MyApp.view.TDSMailRegister', {
    extend: 'Ext.panel.Panel',

    frame: true,

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'form',
                    frame: true,
                    height: 213,
                    id: 'frmMRTDSform',
                    itemId: 'frmMRTDSform',
                    margin: '50 0 0 300',
                    width: 444,
                    bodyPadding: 10,
                    title: 'Email Registration Form',
                    items: [
                        {
                            xtype: 'container',
                            margin: '0 0 0 30',
                            items: [
                                {
                                    xtype: 'textfield',
                                    id: 'txtMRTDSPan',
                                    itemId: 'txtMRTDSPan',
                                    width: 275,
                                    fieldLabel: 'PAN No',
                                    labelWidth: 150,
                                    allowBlank: false,
                                    enforceMaxLength: true,
                                    maxLength: 9,
                                    minLength: 9,
                                    listeners: {
                                        blur: {
                                            fn: me.onTxtMRTDSPanBlur,
                                            scope: me
                                        }
                                    }
                                },
                                {
                                    xtype: 'textfield',
                                    id: 'txtMRTDSPhone',
                                    itemId: 'txtMRTDSPhone',
                                    width: 275,
                                    fieldLabel: 'Contact No',
                                    labelWidth: 150,
                                    allowBlank: false,
                                    enforceMaxLength: false
                                },
                                {
                                    xtype: 'textfield',
                                    id: 'txtMRTDSAddress',
                                    itemId: 'txtMRTDSAddress',
                                    width: 366,
                                    fieldLabel: 'Contact Address',
                                    labelWidth: 150,
                                    allowBlank: false,
                                    enforceMaxLength: false
                                },
                                {
                                    xtype: 'textfield',
                                    id: 'txtMRTDSEmailAdd',
                                    itemId: 'txtMRTDSEmailAdd',
                                    width: 365,
                                    fieldLabel: 'Email Address',
                                    labelWidth: 150,
                                    allowBlank: false,
                                    enforceMaxLength: false
                                },
                                {
                                    xtype: 'combobox',
                                    id: 'cboMRTDSStatus',
                                    itemId: 'cboMRTDSStatus',
                                    width: 251,
                                    fieldLabel: 'Status',
                                    labelWidth: 150,
                                    allowBlank: false,
                                    displayField: 'status',
                                    queryMode: 'local',
                                    store: 'TDSRegStatus',
                                    valueField: 'id'
                                }
                            ]
                        },
                        {
                            xtype: 'container',
                            height: 20,
                            margin: '0 0 0 185',
                            layout: {
                                align: 'stretch',
                                type: 'hbox'
                            },
                            items: [
                                {
                                    xtype: 'button',
                                    id: 'btnMRTDSRegister',
                                    itemId: 'btnMRTDSRegister',
                                    width: 97,
                                    text: 'Register Email'
                                },
                                {
                                    xtype: 'button',
                                    id: 'btnMRTDSReset',
                                    itemId: 'btnMRTDSReset',
                                    width: 54,
                                    text: 'Reset'
                                },
                                {
                                    xtype: 'button',
                                    id: 'btnMRTDSRequestKey',
                                    itemId: 'btnMRTDSRequestKey',
                                    width: 88,
                                    text: 'Request Key'
                                }
                            ]
                        }
                    ]
                },
                {
                    xtype: 'container',
                    height: 50,
                    margin: '5 0 0 300',
                    items: [
                        {
                            xtype: 'displayfield',
                            id: 'dpMRTDSmsg',
                            itemId: 'dpMRTDSmsg',
                            width: 650
                        }
                    ]
                },
                {
                    xtype: 'hiddenfield',
                    id: 'hdnMRTDSPan',
                    itemId: 'hdnMRTDSPan',
                    fieldLabel: 'Label'
                },
                {
                    xtype: 'hiddenfield',
                    id: 'hdnMRTDSMail',
                    itemId: 'hdnMRTDSMail',
                    fieldLabel: 'Label'
                }
            ]
        });

        me.callParent(arguments);
    },

    onTxtMRTDSPanBlur: function(component, e, eOpts) {
        if(field.getValue()!=="")
        {

            isValid = ValidatePan(field.getValue());

            if(isValid===false)
            {
                msg("WARNING","Please enter valid PAN");

                // var txtPan = Ext.ComponentQuery.query("#txtMRTDSPan")[0];
                //   txtPan.focus(true);
                return false;
            }
        }
    }

});