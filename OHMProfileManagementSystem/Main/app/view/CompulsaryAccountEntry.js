/*
 * File: app/view/CompulsaryAccountEntry.js
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

Ext.define('MyApp.view.CompulsaryAccountEntry', {
    extend: 'Ext.panel.Panel',

    requires: [
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
    title: 'CompulsaryAccountEntry',

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'form',
                    frame: true,
                    itemId: 'frmCompulsaryAccountEntry',
                    bodyPadding: 10,
                    layout: {
                        type: 'table',
                        columns: 2
                    },
                    items: [
                        {
                            xtype: 'textfield',
                            fieldLabel: 'Symbol No',
                            labelWidth: 150,
                            size: 40
                        },
                        {
                            xtype: 'combobox',
                            style: {
                                marginLeft: '40px'
                            },
                            fieldLabel: 'Product Type',
                            size: 30
                        },
                        {
                            xtype: 'textfield',
                            fieldLabel: 'Compulsary Account Desc',
                            labelWidth: 150,
                            size: 40
                        },
                        {
                            xtype: 'checkboxfield',
                            style: {
                                marginLeft: '40px'
                            },
                            fieldLabel: 'Active',
                            boxLabel: 'Box Label'
                        },
                        {
                            xtype: 'textfield',
                            fieldLabel: 'Saving Product Code',
                            labelWidth: 150,
                            size: 25
                        },
                        {
                            xtype: 'textfield',
                            style: {
                                marginLeft: '-80px'
                            },
                            fieldLabel: '',
                            size: 65
                        },
                        {
                            xtype: 'container',
                            colspan: 2,
                            suspendLayout: true,
                            layout: {
                                type: 'hbox',
                                align: 'stretch',
                                pack: 'center'
                            },
                            items: [
                                {
                                    xtype: 'button',
                                    flex: 0,
                                    itemId: 'btnCreateCompulsaryAcc',
                                    margin: 10,
                                    text: ' Create Compulsary Account',
                                    listeners: {
                                        click: {
                                            fn: me.onButtonClick,
                                            scope: me
                                        }
                                    }
                                }
                            ]
                        },
                        {
                            xtype: 'form',
                            colspan: 2,
                            frame: true,
                            bodyPadding: 10,
                            title: 'Compulsary Account Details :',
                            layout: {
                                type: 'vbox',
                                align: 'stretch'
                            },
                            items: [
                                {
                                    xtype: 'gridpanel',
                                    title: 'My Grid Panel',
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
                        }
                    ]
                }
            ]
        });

        me.callParent(arguments);
    },

    onButtonClick: function(button, e, eOpts) {
        alert('hi');
    }

});