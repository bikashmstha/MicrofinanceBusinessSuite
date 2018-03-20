/*
 * File: app/view/AccountChequeBook.js
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

Ext.define('MyApp.view.AccountChequeBook', {
    extend: 'Ext.panel.Panel',

    requires: [
        'Ext.form.Panel',
        'Ext.form.field.ComboBox',
        'Ext.button.Button',
        'Ext.form.FieldSet',
        'Ext.grid.Panel',
        'Ext.grid.column.Number',
        'Ext.grid.column.Date',
        'Ext.grid.column.Boolean',
        'Ext.grid.View',
        'Ext.form.field.Checkbox'
    ],

    frame: true,
    autoScroll: true,
    title: 'Saving Account Cheque List',

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'form',
                    frame: true,
                    id: 'frm-AccountChequeBook',
                    itemId: 'frm-AccountChequeBook',
                    bodyPadding: 10,
                    title: '',
                    items: [
                        {
                            xtype: 'container',
                            layout: {
                                type: 'table',
                                columns: 4
                            },
                            items: [
                                {
                                    xtype: 'textfield',
                                    colspan: 4,
                                    fieldLabel: 'Account Code',
                                    labelWidth: 115,
                                    size: 65
                                },
                                {
                                    xtype: 'combobox',
                                    colspan: 4,
                                    fieldLabel: 'Saving Product Code',
                                    labelWidth: 115,
                                    size: 65
                                },
                                {
                                    xtype: 'combobox',
                                    colspan: 4,
                                    fieldLabel: 'Member Name',
                                    labelWidth: 115,
                                    size: 65
                                },
                                {
                                    xtype: 'textfield',
                                    colspan: 2,
                                    fieldLabel: 'No. Of Leaf Issue',
                                    labelWidth: 115
                                },
                                {
                                    xtype: 'textfield',
                                    colspan: 2,
                                    fieldLabel: 'Cheque No. From'
                                },
                                {
                                    xtype: 'button',
                                    colspan: 2,
                                    text: 'Generate Cheque Book'
                                },
                                {
                                    xtype: 'textfield',
                                    colspan: 2,
                                    fieldLabel: 'Cheque No. To'
                                },
                                {
                                    xtype: 'fieldset',
                                    colspan: 4,
                                    title: 'Account Cheque List',
                                    layout: {
                                        type: 'table',
                                        columns: 4
                                    },
                                    items: [
                                        {
                                            xtype: 'combobox',
                                            fieldLabel: 'Cheque No. From'
                                        },
                                        {
                                            xtype: 'combobox',
                                            margin: '0 0 0 5',
                                            fieldLabel: 'Cheque No. To',
                                            labelWidth: 90
                                        },
                                        {
                                            xtype: 'combobox',
                                            margin: '0 0 0 5',
                                            fieldLabel: 'Cheque Status',
                                            labelWidth: 90,
                                            emptyText: '--- SELECT ---'
                                        },
                                        {
                                            xtype: 'button',
                                            margin: '0 0 0 5',
                                            text: 'Search Cheque'
                                        }
                                    ]
                                },
                                {
                                    xtype: 'gridpanel',
                                    colspan: 4,
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
                                },
                                {
                                    xtype: 'fieldset',
                                    colspan: 4,
                                    title: 'Destination',
                                    layout: {
                                        type: 'table',
                                        columns: 2
                                    },
                                    items: [
                                        {
                                            xtype: 'combobox',
                                            colspan: 1,
                                            fieldLabel: 'Cheque No. From',
                                            labelWidth: 120
                                        },
                                        {
                                            xtype: 'combobox',
                                            colspan: 2,
                                            margin: '0 0 0 100',
                                            fieldLabel: 'Cheque No. To'
                                        },
                                        {
                                            xtype: 'combobox',
                                            colspan: 1,
                                            fieldLabel: 'Destination Format',
                                            labelWidth: 120,
                                            size: 30
                                        },
                                        {
                                            xtype: 'combobox',
                                            colspan: 1,
                                            margin: '0 0 0 100',
                                            fieldLabel: 'Destination Parameter',
                                            size: 30
                                        },
                                        {
                                            xtype: 'combobox',
                                            colspan: 1,
                                            fieldLabel: 'Destination Type',
                                            labelWidth: 120,
                                            size: 35
                                        },
                                        {
                                            xtype: 'checkboxfield',
                                            colspan: 1,
                                            margin: '0 0 0 100',
                                            fieldLabel: 'Print : ?',
                                            boxLabel: ''
                                        },
                                        {
                                            xtype: 'container',
                                            colspan: 2,
                                            height: 23,
                                            layout: {
                                                type: 'hbox',
                                                align: 'stretch',
                                                pack: 'center'
                                            },
                                            items: [
                                                {
                                                    xtype: 'button',
                                                    text: 'Print Cheque Book'
                                                }
                                            ]
                                        }
                                    ]
                                },
                                {
                                    xtype: 'fieldset',
                                    colspan: 4,
                                    height: 23,
                                    title: '',
                                    layout: {
                                        type: 'hbox',
                                        align: 'stretch',
                                        pack: 'center'
                                    },
                                    items: [
                                        {
                                            xtype: 'button',
                                            text: 'Account Info'
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