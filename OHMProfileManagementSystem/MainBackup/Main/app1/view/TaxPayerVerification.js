/*
 * File: app/view/TaxPayerVerification.js
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

Ext.define('MyApp.view.TaxPayerVerification', {
    extend: 'Ext.panel.Panel',

    frame: true,
    padding: 20,
    title: 'Tax Payer Verification',

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'form',
                    frame: true,
                    height: 178,
                    itemId: 'frmTaxPayerVerification',
                    margin: '0 150',
                    width: 391,
                    bodyPadding: 10,
                    title: 'Tax Payer Verification',
                    items: [
                        {
                            xtype: 'fieldset',
                            height: 122,
                            padding: 10,
                            width: 361,
                            title: '',
                            items: [
                                {
                                    xtype: 'container',
                                    margin: '0 0 10 0',
                                    items: [
                                        {
                                            xtype: 'combobox',
                                            itemId: 'TPV_cmbModuls',
                                            margin: '0 0 10 0',
                                            width: 338,
                                            fieldLabel: 'Moduls',
                                            allowBlank: false,
                                            displayField: 'ModulName',
                                            queryMode: 'local',
                                            store: 'strTPVModuls',
                                            valueField: 'ModulID'
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'TPV_txtSubmissionNo',
                                            width: 337,
                                            fieldLabel: 'Submission No.',
                                            allowBlank: false
                                        },
                                        {
                                            xtype: 'hiddenfield',
                                            itemId: 'TPV_hdnTranNo',
                                            fieldLabel: 'Label'
                                        }
                                    ]
                                },
                                {
                                    xtype: 'container',
                                    style: 'text-align:right;',
                                    items: [
                                        {
                                            xtype: 'button',
                                            itemId: 'TPV_btnPreview',
                                            margin: '0 10',
                                            width: 75,
                                            text: 'Preview'
                                        },
                                        {
                                            xtype: 'button',
                                            itemId: 'TPV_btnVerify',
                                            width: 75,
                                            text: 'Verify'
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