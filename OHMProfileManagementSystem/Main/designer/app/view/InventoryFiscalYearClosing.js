/*
 * File: app/view/InventoryFiscalYearClosing.js
 *
 * This file was generated by Sencha Architect version 4.2.2.
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

Ext.define('MyApp.view.InventoryFiscalYearClosing', {
    extend: 'Ext.panel.Panel',

    requires: [
        'Ext.form.field.Text',
        'Ext.container.Container',
        'Ext.button.Button'
    ],

    frame: true,
    title: 'Inventory Fiscal Year Closing',

    layout: {
        type: 'table',
        columns: 2
    },

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'textfield',
                    colspan: 2,
                    fieldLabel: 'Old Fiscal Year',
                    labelWidth: 150
                },
                {
                    xtype: 'textfield',
                    colspan: 2,
                    fieldLabel: 'New Fiscal Year',
                    labelWidth: 150
                },
                {
                    xtype: 'textfield',
                    fieldLabel: 'New Fiscal Year Start Date',
                    labelWidth: 150
                },
                {
                    xtype: 'textfield',
                    margin: '0 0 0 10',
                    fieldLabel: 'Label',
                    hideLabel: true,
                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                },
                {
                    xtype: 'container',
                    colspan: 2,
                    height: 28,
                    layout: {
                        type: 'hbox',
                        align: 'stretch',
                        pack: 'center'
                    },
                    items: [
                        {
                            xtype: 'button',
                            text: 'Inventory Fiscal Year Closing'
                        }
                    ]
                }
            ]
        });

        me.callParent(arguments);
    }

});