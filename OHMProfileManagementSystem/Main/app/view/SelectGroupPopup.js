/*
 * File: app/view/SelectGroupPopup.js
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

Ext.define('MyApp.view.SelectGroupPopup', {
    extend: 'Ext.window.Window',

    requires: [
        'Ext.form.Panel',
        'Ext.form.field.Text',
        'Ext.button.Button',
        'Ext.grid.Panel',
        'Ext.grid.View',
        'Ext.grid.column.Column'
    ],

    height: 500,
    width: 700,
    autoScroll: true,
    title: 'Select Group',

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'form',
                    frame: true,
                    height: 600,
                    bodyPadding: 10,
                    title: '',
                    items: [
                        {
                            xtype: 'container',
                            layout: 'table',
                            items: [
                                {
                                    xtype: 'textfield',
                                    itemId: 'txtSearchGroup',
                                    fieldLabel: 'Search'
                                },
                                {
                                    xtype: 'button',
                                    colspan: 2,
                                    itemId: 'btnSearchGroup',
                                    margin: '0 0 0 5',
                                    text: 'Search'
                                }
                            ]
                        },
                        {
                            xtype: 'gridpanel',
                            itemId: 'grdSearchGroup',
                            title: '',
                            columns: [
                                {
                                    xtype: 'gridcolumn',
                                    text: ''
                                },
                                {
                                    xtype: 'gridcolumn',
                                    text: 'Group Code'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    text: 'GroupName'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    text: 'Center Code'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    text: 'Center Name'
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