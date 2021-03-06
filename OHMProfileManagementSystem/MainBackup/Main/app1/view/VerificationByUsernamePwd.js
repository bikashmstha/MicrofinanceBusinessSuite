/*
 * File: app/view/VerificationByUsernamePwd.js
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

Ext.define('MyApp.view.VerificationByUsernamePwd', {
    extend: 'Ext.panel.Panel',

    frame: true,
    title: 'Verify Returns Using Username and Password',

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'form',
                    frame: true,
                    id: 'frmVerificationByUsernamePwd',
                    bodyPadding: 10,
                    frameHeader: false,
                    items: [
                        {
                            xtype: 'container',
                            layout: {
                                type: 'column'
                            },
                            items: [
                                {
                                    xtype: 'displayfield',
                                    itemId: 'lblPan',
                                    style: 'font-size:18px;color:red;',
                                    fieldLabel: 'PAN',
                                    labelStyle: 'font-size:18px;color:red;',
                                    fieldStyle: 'font-size:18px;color:red;'
                                },
                                {
                                    xtype: 'displayfield',
                                    itemId: 'lblSubmissionNo',
                                    margin: '0 0 0 200',
                                    style: 'font-size:18px;color:red;',
                                    fieldLabel: 'Submission No',
                                    labelStyle: 'font-size:18px;color:red;',
                                    labelWidth: 150,
                                    fieldStyle: 'font-size:18px;color:red;'
                                },
                                {
                                    xtype: 'hiddenfield',
                                    itemId: 'hfApplication',
                                    fieldLabel: 'Label'
                                },
                                {
                                    xtype: 'hiddenfield',
                                    itemId: 'hfModule',
                                    fieldLabel: 'Label'
                                },
                                {
                                    xtype: 'hiddenfield',
                                    itemId: 'hfAccountType',
                                    fieldLabel: 'Label'
                                },
                                {
                                    xtype: 'hiddenfield',
                                    itemId: 'hfTaxyear',
                                    fieldLabel: 'Label'
                                },
                                {
                                    xtype: 'hiddenfield',
                                    itemId: 'hfFilePer',
                                    fieldLabel: 'Label'
                                },
                                {
                                    xtype: 'hiddenfield',
                                    itemId: 'hfPeriod',
                                    fieldLabel: 'Label'
                                }
                            ]
                        },
                        {
                            xtype: 'container',
                            id: 'ContUsernamePwd',
                            items: [
                                {
                                    xtype: 'textfield',
                                    itemId: 'txtUsername',
                                    fieldLabel: 'Username',
                                    labelWidth: 150
                                },
                                {
                                    xtype: 'textfield',
                                    itemId: 'txtPassword',
                                    fieldLabel: 'Password',
                                    labelWidth: 150,
                                    inputType: 'password'
                                },
                                {
                                    xtype: 'numberfield',
                                    itemId: 'txtPreviousVatDue',
                                    fieldLabel: 'Previous Vat Due',
                                    labelWidth: 150,
                                    hideTrigger: true,
                                    keyNavEnabled: false,
                                    mouseWheelEnabled: false
                                }
                            ]
                        },
                        {
                            xtype: 'container',
                            id: '',
                            itemId: 'ContButtons',
                            items: [
                                {
                                    xtype: 'button',
                                    id: '',
                                    itemId: 'btnSubmit',
                                    margin: '0 0 0 250',
                                    padding: 5,
                                    iconCls: 'icon-ok',
                                    text: 'Verify'
                                },
                                {
                                    xtype: 'button',
                                    id: '',
                                    itemId: 'btnBack',
                                    margin: '0 0 0 5',
                                    padding: 5,
                                    iconCls: 'icon-ok',
                                    text: 'Back'
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