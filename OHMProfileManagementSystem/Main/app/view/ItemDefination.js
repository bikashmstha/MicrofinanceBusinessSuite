/*
 * File: app/view/ItemDefination.js
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

Ext.define('MyApp.view.ItemDefination', {
    extend: 'Ext.panel.Panel',

    requires: [
        'Ext.form.Label',
        'Ext.form.Panel',
        'Ext.form.field.ComboBox',
        'Ext.form.field.Checkbox',
        'Ext.button.Button',
        'Ext.grid.Panel',
        'Ext.grid.column.Number',
        'Ext.grid.column.Date',
        'Ext.grid.column.Boolean',
        'Ext.grid.View'
    ],

    frame: true,
    width: 1143,
    title: 'Item Defination',

    layout: {
        type: 'table',
        columns: 2
    },

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'label',
                    colspan: 2,
                    rowspan: 1,
                    text: 'Item'
                },
                {
                    xtype: 'form',
                    colspan: 1,
                    rowspan: 2,
                    frame: true,
                    margin: '10 0 0 0',
                    width: 811,
                    bodyPadding: 10,
                    title: 'Defination',
                    layout: {
                        type: 'table',
                        columns: 2
                    },
                    items: [
                        {
                            xtype: 'textfield',
                            fieldLabel: 'Code',
                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                        },
                        {
                            xtype: 'textfield',
                            margin: '0 0 0 50',
                            fieldLabel: 'MSS Code',
                            size: 55
                        },
                        {
                            xtype: 'textfield',
                            colspan: 2,
                            fieldLabel: 'Name',
                            size: 102
                        },
                        {
                            xtype: 'textfield',
                            fieldLabel: 'Model No'
                        },
                        {
                            xtype: 'textfield',
                            margin: '0 0 0 50',
                            fieldLabel: 'Description',
                            size: 55
                        },
                        {
                            xtype: 'combobox',
                            colspan: 2,
                            fieldLabel: 'Category',
                            fieldStyle: 'background-color:#DAEBE1;background-image:none;',
                            emptyText: '---Select---'
                        },
                        {
                            xtype: 'combobox',
                            colspan: 2,
                            fieldLabel: 'Manufacturer',
                            fieldStyle: 'background-color:#DAEBE1;background-image:none;',
                            emptyText: '---Select---'
                        }
                    ]
                },
                {
                    xtype: 'checkboxfield',
                    colspan: 1,
                    rowspan: 1,
                    margin: '15 0 0 10',
                    fieldLabel: 'Active',
                    boxLabel: 'Box Label'
                },
                {
                    xtype: 'form',
                    colspan: 1,
                    rowspan: 1,
                    frame: true,
                    margin: '15 0 0 10',
                    bodyPadding: 10,
                    title: '',
                    layout: {
                        type: 'table',
                        columns: 1
                    },
                    items: [
                        {
                            xtype: 'combobox',
                            fieldLabel: 'Class',
                            emptyText: '---Select---'
                        },
                        {
                            xtype: 'combobox',
                            fieldLabel: 'Costing Type',
                            emptyText: '---Select---'
                        },
                        {
                            xtype: 'textfield',
                            fieldLabel: 'Unit Cost'
                        },
                        {
                            xtype: 'textfield',
                            fieldLabel: 'Unit Price'
                        }
                    ]
                },
                {
                    xtype: 'form',
                    colspan: 1,
                    frame: true,
                    margin: '10 0 0 0 ',
                    bodyPadding: 10,
                    title: 'Stock',
                    layout: {
                        type: 'table',
                        columns: 3
                    },
                    items: [
                        {
                            xtype: 'textfield',
                            fieldLabel: 'Minimum Stock'
                        },
                        {
                            xtype: 'textfield',
                            margin: '0 0 0 10',
                            fieldLabel: 'Maximum Stock'
                        },
                        {
                            xtype: 'textfield',
                            margin: '0 0 0 10',
                            fieldLabel: 'Stock Quantity'
                        },
                        {
                            xtype: 'textfield',
                            fieldLabel: 'Recorder Level'
                        },
                        {
                            xtype: 'textfield',
                            margin: '0 0 0 10',
                            fieldLabel: 'Reorder Quantity'
                        },
                        {
                            xtype: 'textfield',
                            margin: '0 0 0 10',
                            fieldLabel: 'Weight'
                        }
                    ]
                },
                {
                    xtype: 'form',
                    colspan: 1,
                    frame: true,
                    margin: '10 0 0 10',
                    bodyPadding: 10,
                    title: 'Unit',
                    layout: {
                        type: 'table',
                        columns: 1
                    },
                    items: [
                        {
                            xtype: 'combobox',
                            fieldLabel: 'Stock Unit',
                            emptyText: '---Select---'
                        },
                        {
                            xtype: 'combobox',
                            fieldLabel: 'Issue/Sale Unit',
                            emptyText: '---Select---'
                        }
                    ]
                },
                {
                    xtype: 'container',
                    colspan: 2,
                    height: 35,
                    margin: '10 0 0 0',
                    layout: {
                        type: 'hbox',
                        align: 'stretch',
                        pack: 'center'
                    },
                    items: [
                        {
                            xtype: 'button',
                            padding: 5,
                            text: 'Insert'
                        }
                    ]
                },
                {
                    xtype: 'form',
                    colspan: 2,
                    frame: true,
                    margin: '10 0 0 0 ',
                    bodyPadding: 10,
                    title: 'Search',
                    layout: {
                        type: 'table',
                        columns: 2
                    },
                    items: [
                        {
                            xtype: 'textfield',
                            fieldLabel: 'Item Code',
                            labelWidth: 110
                        },
                        {
                            xtype: 'textfield',
                            margin: '0 0 0 170',
                            fieldLabel: 'Item Name',
                            size: 80
                        },
                        {
                            xtype: 'combobox',
                            colspan: 2,
                            fieldLabel: 'Category Code',
                            labelWidth: 110,
                            fieldStyle: 'background-color:#DAEBE1;background-image:none;',
                            emptyText: '---Select---'
                        },
                        {
                            xtype: 'combobox',
                            colspan: 2,
                            fieldLabel: 'Manufacturer Code',
                            labelWidth: 110,
                            fieldStyle: 'background-color:#DAEBE1;background-image:none;',
                            emptyText: '---Select---'
                        }
                    ]
                },
                {
                    xtype: 'container',
                    colspan: 2,
                    height: 28,
                    margin: '10 0 0 0 ',
                    layout: {
                        type: 'hbox',
                        align: 'stretch',
                        pack: 'center'
                    },
                    items: [
                        {
                            xtype: 'button',
                            padding: 5,
                            text: 'Search'
                        }
                    ]
                },
                {
                    xtype: 'gridpanel',
                    colspan: 2,
                    margin: '10 0 0 0',
                    title: '',
                    columns: [
                        {
                            xtype: 'gridcolumn',
                            dataIndex: 'string',
                            text: 'String'
                        },
                        {
                            xtype: 'numbercolumn',
                            dataIndex: 'number',
                            text: 'Number'
                        },
                        {
                            xtype: 'datecolumn',
                            dataIndex: 'date',
                            text: 'Date'
                        },
                        {
                            xtype: 'booleancolumn',
                            dataIndex: 'bool',
                            text: 'Boolean'
                        }
                    ]
                }
            ]
        });

        me.callParent(arguments);
    }

});