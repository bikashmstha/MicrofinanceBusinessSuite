/*
 * File: app/view/TDSWithTran.js
 *
 * This file was generated by Sencha Architect version 2.2.2.
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

Ext.define('MyApp.view.TDSWithTran', {
    extend: 'Ext.panel.Panel',

    frame: true,

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'form',
                    frame: true,
                    height: 179,
                    id: 'frmTDSWithTranForm',
                    itemId: 'frmTDSWithTranForm',
                    margin: '50 0 0 300',
                    width: 283,
                    bodyPadding: 10,
                    title: 'Withholdee Transaction Form',
                    items: [
                        {
                            xtype: 'textfield',
                            anchor: '100%',
                            id: 'txtTDSWTPan',
                            itemId: 'txtTDSWTPan',
                            maxWidth: 250,
                            fieldLabel: 'PAN No',
                            allowBlank: false,
                            maxLength: 9,
                            minLength: 9,
                            listeners: {
                                blur: {
                                    fn: me.onTxtTDSWTPanBlur,
                                    scope: me
                                }
                            }
                        },
                        {
                            xtype: 'combobox',
                            anchor: '100%',
                            id: 'cboTDSWTDateType',
                            itemId: 'cboTDSWTDateType',
                            maxWidth: 180,
                            width: 171,
                            fieldLabel: 'Select Date Type',
                            allowBlank: false,
                            displayField: 'Type',
                            queryMode: 'local',
                            store: 'TDSDateType'
                        },
                        {
                            xtype: 'textfield',
                            validator: function(value) {
                                var errDate = "";

                                errDate = validateNepDate(value);

                                return errDate === ""?true:errDate;
                            },
                            anchor: '100%',
                            id: 'txtTDSWTFromDate',
                            itemId: 'txtTDSWTFromDate',
                            maxWidth: 250,
                            fieldLabel: 'From Date',
                            allowBlank: false,
                            emptyText: 'YYYY-MM-DD',
                            listeners: {
                                blur: {
                                    fn: me.onTxtTDSWTFromDateBlur,
                                    scope: me
                                }
                            }
                        },
                        {
                            xtype: 'textfield',
                            validator: function(value) {
                                var errDate = "";

                                errDate = validateNepDate(value);

                                return errDate === ""?true:errDate;
                            },
                            anchor: '100%',
                            id: 'txtTDSWTToDate',
                            itemId: 'txtTDSWTToDate',
                            maxWidth: 250,
                            fieldLabel: 'To Date',
                            allowBlank: false,
                            emptyText: 'YYYY-MM-DD',
                            listeners: {
                                blur: {
                                    fn: me.onTxtTDSWTToDateBlur,
                                    scope: me
                                }
                            }
                        },
                        {
                            xtype: 'container',
                            margin: '0 0 0 200',
                            items: [
                                {
                                    xtype: 'button',
                                    id: 'btnTDSWTSearch',
                                    itemId: 'btnTDSWTSearch',
                                    text: 'Search'
                                }
                            ]
                        }
                    ]
                }
            ]
        });

        me.callParent(arguments);
    },

    onTxtTDSWTPanBlur: function(component, e, eOpts) {
        var txtPan = Ext.ComponentQuery.query("#txtTDSWTPan")[0];

        isValid = ValidatePan(txtPan.getValue());

        if(isValid === false)
        {
            msg('WARNING','Please enter valid PAN !!!');
            return false;
        }
    },

    onTxtTDSWTFromDateBlur: function(component, e, eOpts) {
        field.validate();
    },

    onTxtTDSWTToDateBlur: function(component, e, eOpts) {
        field.validate();
    }

});