/*
 * File: app/view/OfficerVerification.js
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

Ext.define('MyApp.view.OfficerVerification', {
    extend: 'Ext.panel.Panel',

    frame: true,
    itemId: 'pnlOfficerVerification',
    title: 'Officer Verification',

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'form',
                    frame: true,
                    itemId: 'frmOfficerVerification',
                    bodyPadding: 10,
                    title: '',
                    items: [
                        {
                            xtype: 'container',
                            items: [
                                {
                                    xtype: 'combobox',
                                    itemId: 'cboModuleOffV',
                                    width: 400,
                                    fieldLabel: 'Module',
                                    msgTarget: 'side',
                                    allowBlank: false,
                                    emptyText: '.....छान्नुहोस्.....',
                                    displayField: 'ModuleName',
                                    forceSelection: true,
                                    queryMode: 'local',
                                    store: 'eServicesModuleOffV',
                                    typeAhead: true,
                                    valueField: 'ModuleID'
                                },
                                {
                                    xtype: 'textfield',
                                    itemId: 'txtSubmissionNoOffV',
                                    fieldLabel: 'Submission No.',
                                    msgTarget: 'side',
                                    allowBlank: false,
                                    enableKeyEvents: true
                                },
                                {
                                    xtype: 'displayfield',
                                    height: 25,
                                    hidden: true,
                                    itemId: 'lblTranNoOffV',
                                    width: 300,
                                    fieldLabel: 'Tran No'
                                }
                            ]
                        },
                        {
                            xtype: 'fieldcontainer',
                            height: 25,
                            margin: '20 0 0 0',
                            layout: {
                                align: 'stretch',
                                pack: 'center',
                                type: 'hbox'
                            },
                            fieldLabel: '',
                            items: [
                                {
                                    xtype: 'button',
                                    disabled: true,
                                    itemId: 'btnPreviewOffV',
                                    iconCls: 'icon-view',
                                    text: 'Preview'
                                },
                                {
                                    xtype: 'splitter'
                                },
                                {
                                    xtype: 'button',
                                    disabled: true,
                                    itemId: 'btnVerifyOffV',
                                    iconCls: 'icon-verify',
                                    text: 'Verify'
                                }
                            ]
                        }
                    ]
                },
                {
                    xtype: 'hiddenfield',
                    itemId: 'hdnActionOffV',
                    fieldLabel: 'Label'
                }
            ]
        });

        me.callParent(arguments);
    }

});