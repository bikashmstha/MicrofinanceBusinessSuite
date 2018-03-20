/*
 * File: app/view/ReturnDetails.js
 *
 * This file was generated by Sencha Architect version 2.2.2.
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

Ext.define('MyApp.view.ReturnDetails', {
    extend: 'Ext.panel.Panel',

    frame: true,
    height: 250,
    id: 'VTB_RETURNS',
    itemId: 'VTB_RETURNS',
    title: 'Return Details',

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'textfield',
                    id: 'txtRDPan',
                    itemId: 'txtRDPan',
                    fieldLabel: 'PAN'
                },
                {
                    xtype: 'textfield',
                    id: 'txtRDAccttype',
                    itemId: 'txtRDAccttype',
                    fieldLabel: 'Account Type',
                    maxLength: 2
                },
                {
                    xtype: 'container',
                    layout: {
                        type: 'table'
                    },
                    items: [
                        {
                            xtype: 'textfield',
                            id: 'txtRDFromDate',
                            itemId: 'txtRDFromDate',
                            fieldLabel: 'From Date'
                        },
                        {
                            xtype: 'textfield',
                            id: 'txtRDToDate',
                            itemId: 'txtRDToDate',
                            margin: 10.2,
                            fieldLabel: 'To Date'
                        }
                    ]
                },
                {
                    xtype: 'button',
                    id: 'btnGenratePrint',
                    itemId: 'btnGenratePrint',
                    iconCls: 'icon-print',
                    text: 'Generate Print'
                },
                {
                    xtype: 'button',
                    id: 'btnCancel',
                    itemId: 'btnCancel',
                    margin: 10.2,
                    iconCls: 'icon-cancel',
                    text: 'Cancel'
                }
            ]
        });

        me.callParent(arguments);
    }

});