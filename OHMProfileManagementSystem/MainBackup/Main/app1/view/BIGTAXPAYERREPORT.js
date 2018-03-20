/*
 * File: app/view/BIGTAXPAYERREPORT.js
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

Ext.define('MyApp.view.BIGTAXPAYERREPORT', {
    extend: 'Ext.panel.Panel',

    frame: true,
    height: 445,
    width: 792,
    title: 'Big Taxpayer Report:',

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'container',
                    height: 54,
                    items: [
                        {
                            xtype: 'textfield',
                            itemId: 'txtOffCode',
                            width: 248,
                            fieldLabel: 'office code'
                        },
                        {
                            xtype: 'checkboxgroup',
                            width: 526,
                            fieldLabel: 'Include Turnover from',
                            labelWidth: 150,
                            items: [
                                {
                                    xtype: 'checkboxfield',
                                    itemId: 'chkTax',
                                    boxLabel: 'Sales'
                                },
                                {
                                    xtype: 'checkboxfield',
                                    itemId: 'chkExempt',
                                    boxLabel: 'Exempt Sales'
                                },
                                {
                                    xtype: 'checkboxfield',
                                    itemId: 'chkExport',
                                    fieldLabel: '',
                                    boxLabel: 'Export'
                                }
                            ]
                        }
                    ]
                },
                {
                    xtype: 'container',
                    height: 24,
                    layout: {
                        type: 'column'
                    },
                    items: [
                        {
                            xtype: 'textfield',
                            itemId: 'txtLBound',
                            width: 351,
                            fieldLabel: 'Turnover Number between',
                            labelWidth: 180
                        },
                        {
                            xtype: 'textfield',
                            itemId: 'txtUBound',
                            fieldLabel: ''
                        }
                    ]
                },
                {
                    xtype: 'container',
                    layout: {
                        type: 'column'
                    },
                    items: [
                        {
                            xtype: 'textfield',
                            itemId: 'txtFDate',
                            fieldLabel: 'From Date'
                        },
                        {
                            xtype: 'textfield',
                            itemId: 'txtTDate',
                            fieldLabel: 'To Date'
                        }
                    ]
                },
                {
                    xtype: 'button',
                    itemId: 'btnPrint',
                    text: 'Print Report'
                }
            ]
        });

        me.callParent(arguments);
    }

});