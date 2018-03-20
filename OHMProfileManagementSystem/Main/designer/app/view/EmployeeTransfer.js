/*
 * File: app/view/EmployeeTransfer.js
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

Ext.define('MyApp.view.EmployeeTransfer', {
    extend: 'Ext.panel.Panel',

    requires: [
        'Ext.form.Label',
        'Ext.form.field.ComboBox',
        'Ext.form.Panel',
        'Ext.form.field.Checkbox',
        'Ext.button.Button',
        'Ext.grid.Panel',
        'Ext.grid.column.Number',
        'Ext.grid.column.Date',
        'Ext.grid.column.Boolean',
        'Ext.grid.View'
    ],

    frame: true,
    title: 'Employee Transfer',

    layout: {
        type: 'table',
        columns: 3
    },

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'label',
                    margin: '0 0 0 150',
                    text: 'Id'
                },
                {
                    xtype: 'label',
                    colspan: 2,
                    margin: '0 0 0 50',
                    text: 'Name'
                },
                {
                    xtype: 'combobox',
                    colspan: 3,
                    margin: '10 0 0 10',
                    fieldLabel: 'Employee',
                    labelWidth: 80,
                    fieldStyle: 'background-color:#DAEBE1;background-image:none;',
                    emptyText: '---Select---'
                },
                {
                    xtype: 'textfield',
                    margin: '5 0 0 10',
                    fieldLabel: 'Office',
                    labelWidth: 80,
                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                },
                {
                    xtype: 'textfield',
                    colspan: 2,
                    margin: '0 0 0 10',
                    fieldLabel: 'Label',
                    hideLabel: true,
                    fieldStyle: 'background-color:#D2D2D2;background-image:none;',
                    size: 40
                },
                {
                    xtype: 'textfield',
                    margin: '5 0 0 10',
                    fieldLabel: 'Post',
                    labelWidth: 80,
                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                },
                {
                    xtype: 'textfield',
                    colspan: 2,
                    margin: '0 0 0 10',
                    fieldLabel: 'Label',
                    hideLabel: true,
                    fieldStyle: 'background-color:#D2D2D2;background-image:none;',
                    size: 40
                },
                {
                    xtype: 'textfield',
                    margin: '5 0 0 10',
                    fieldLabel: 'Department',
                    labelWidth: 80,
                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                },
                {
                    xtype: 'textfield',
                    colspan: 2,
                    margin: '0 0 0 10',
                    fieldLabel: 'Label',
                    hideLabel: true,
                    fieldStyle: 'background-color:#D2D2D2;background-image:none;',
                    size: 40
                },
                {
                    xtype: 'form',
                    colspan: 3,
                    frame: true,
                    margin: '5 0 0 0',
                    bodyPadding: 10,
                    title: '',
                    layout: {
                        type: 'table',
                        columns: 4
                    },
                    items: [
                        {
                            xtype: 'textfield',
                            colspan: 1,
                            fieldLabel: 'Transfer Date(B.S.)',
                            labelWidth: 140
                        },
                        {
                            xtype: 'textfield',
                            colspan: 1,
                            margin: '0 0 0 10',
                            fieldLabel: '(A.D.)',
                            labelWidth: 60,
                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                        },
                        {
                            xtype: 'textfield',
                            colspan: 1,
                            margin: '0 0 0 10',
                            fieldLabel: 'Join Date(B.S.)',
                            labelWidth: 90
                        },
                        {
                            xtype: 'textfield',
                            colspan: 1,
                            margin: '0 0 0 10',
                            fieldLabel: '(A.D.)',
                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                        },
                        {
                            xtype: 'textfield',
                            colspan: 1,
                            fieldLabel: 'From Office',
                            labelWidth: 140,
                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                        },
                        {
                            xtype: 'textfield',
                            colspan: 2,
                            margin: '0 0 0 10',
                            fieldLabel: 'From Office',
                            hideLabel: true,
                            labelWidth: 140,
                            fieldStyle: 'background-color:#D2D2D2;background-image:none;',
                            size: 30
                        },
                        {
                            xtype: 'combobox',
                            colspan: 1,
                            margin: '0 0 0 10',
                            fieldLabel: 'To Office',
                            fieldStyle: 'background-color:#DAEBE1;background-image:none;',
                            emptyText: '---Select---'
                        },
                        {
                            xtype: 'textfield',
                            colspan: 1,
                            fieldLabel: 'Old Department',
                            labelWidth: 140,
                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                        },
                        {
                            xtype: 'textfield',
                            colspan: 2,
                            margin: '0 0 0 10',
                            fieldLabel: 'From Office',
                            hideLabel: true,
                            labelWidth: 140,
                            fieldStyle: 'background-color:#D2D2D2;background-image:none;',
                            size: 30
                        },
                        {
                            xtype: 'combobox',
                            colspan: 1,
                            margin: '0 0 0 10',
                            fieldLabel: 'New Department',
                            fieldStyle: 'background-color:#DAEBE1;background-image:none;',
                            emptyText: '---Select---'
                        },
                        {
                            xtype: 'textfield',
                            colspan: 1,
                            fieldLabel: 'From Designation',
                            labelWidth: 140,
                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                        },
                        {
                            xtype: 'textfield',
                            colspan: 2,
                            margin: '0 0 0 10',
                            fieldLabel: 'From Office',
                            hideLabel: true,
                            labelWidth: 140,
                            fieldStyle: 'background-color:#D2D2D2;background-image:none;',
                            size: 30
                        },
                        {
                            xtype: 'combobox',
                            colspan: 1,
                            margin: '0 0 0 10',
                            fieldLabel: 'To Designation',
                            fieldStyle: 'background-color:#DAEBE1;background-image:none;',
                            emptyText: '---Select---'
                        },
                        {
                            xtype: 'container',
                            colspan: 4,
                            layout: 'table',
                            items: [
                                {
                                    xtype: 'textfield',
                                    margin: '0 0 0 10',
                                    fieldLabel: 'Remarks',
                                    labelWidth: 130
                                },
                                {
                                    xtype: 'checkboxfield',
                                    margin: '0 0 0 10',
                                    fieldLabel: 'Approved',
                                    boxLabel: 'Box Label'
                                }
                            ]
                        },
                        {
                            xtype: 'container',
                            colspan: 3,
                            height: 28,
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
                                    text: 'Save'
                                }
                            ]
                        }
                    ]
                },
                {
                    xtype: 'gridpanel',
                    colspan: 3,
                    title: 'Employee Transfer',
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