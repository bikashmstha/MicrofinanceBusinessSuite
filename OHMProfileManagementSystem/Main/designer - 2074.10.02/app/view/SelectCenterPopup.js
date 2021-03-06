/*
 * File: app/view/SelectCenterPopup.js
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

Ext.define('MyApp.view.SelectCenterPopup', {
    extend: 'Ext.window.Window',

    requires: [
        'Ext.form.Panel',
        'Ext.form.field.Text',
        'Ext.button.Button',
        'Ext.grid.Panel',
        'Ext.grid.View',
        'Ext.grid.column.Column'
    ],

    frame: true,
    itemId: 'SelectCenterPopup',
    title: 'Select Center',

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'form',
                    frame: true,
                    bodyPadding: 10,
                    title: '',
                    items: [
                        {
                            xtype: 'container',
                            layout: 'table',
                            items: [
                                {
                                    xtype: 'textfield',
                                    itemId: 'txtSearchCenter',
                                    fieldLabel: 'Search'
                                },
                                {
                                    xtype: 'button',
                                    colspan: 2,
                                    itemId: 'btnSearchCenter',
                                    margin: '0 0 0 5',
                                    text: 'Search'
                                }
                            ]
                        },
                        {
                            xtype: 'gridpanel',
                            itemId: 'grdSearchCenter',
                            title: '',
                            columns: [
                                {
                                    xtype: 'gridcolumn',
                                    text: ''
                                },
                                {
                                    xtype: 'gridcolumn',
                                    text: 'Center Code'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    text: 'Center Name'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    text: 'Emp Id'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    text: 'Emp Name'
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