/*
 * File: app/view/EmployeeEducation.js
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

Ext.define('MyApp.view.EmployeeEducation', {
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
    title: 'Employee Education',

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
                    margin: '0 0 0 10',
                    fieldLabel: 'Employee',
                    labelWidth: 80,
                    fieldStyle: 'background-color:#DAEBE1;background-image:none;',
                    emptyText: '---Select---'
                },
                {
                    xtype: 'textfield',
                    margin: '0 0 0 10',
                    fieldLabel: 'Office',
                    labelWidth: 80,
                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                },
                {
                    xtype: 'textfield',
                    colspan: 2,
                    fieldLabel: 'Label',
                    hideLabel: true,
                    fieldStyle: 'background-color:#D2D2D2;background-image:none;',
                    size: 60
                },
                {
                    xtype: 'textfield',
                    margin: '0 0 0 10',
                    fieldLabel: 'Post',
                    labelWidth: 80,
                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                },
                {
                    xtype: 'textfield',
                    colspan: 2,
                    fieldLabel: 'Label',
                    hideLabel: true,
                    fieldStyle: 'background-color:#D2D2D2;background-image:none;',
                    size: 60
                },
                {
                    xtype: 'textfield',
                    margin: '0 0 0 10',
                    fieldLabel: 'Department',
                    labelWidth: 80,
                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                },
                {
                    xtype: 'textfield',
                    colspan: 2,
                    fieldLabel: 'Label',
                    hideLabel: true,
                    fieldStyle: 'background-color:#D2D2D2;background-image:none;',
                    size: 60
                },
                {
                    xtype: 'form',
                    colspan: 3,
                    frame: true,
                    bodyPadding: 10,
                    title: '',
                    layout: {
                        type: 'table',
                        columns: 3
                    },
                    items: [
                        {
                            xtype: 'label',
                            margin: '0 0 0 150',
                            text: 'Level'
                        },
                        {
                            xtype: 'label',
                            colspan: 2,
                            margin: '0 0 0 100',
                            text: 'Degree'
                        },
                        {
                            xtype: 'combobox',
                            colspan: 2,
                            fieldLabel: 'Education',
                            labelWidth: 125,
                            emptyText: '---Select---'
                        },
                        {
                            xtype: 'textfield',
                            margin: '0 0 0 10',
                            fieldLabel: 'Marks Obtained'
                        },
                        {
                            xtype: 'textfield',
                            fieldLabel: 'Passed Year (B.S.)',
                            labelWidth: 125
                        },
                        {
                            xtype: 'textfield',
                            margin: '0 0 0 10',
                            fieldLabel: '(A.D.)'
                        },
                        {
                            xtype: 'combobox',
                            margin: '0 0 0 10',
                            fieldLabel: 'Pass Division',
                            emptyText: '---Select---'
                        },
                        {
                            xtype: 'textfield',
                            colspan: 2,
                            fieldLabel: 'School/College Name',
                            labelWidth: 125,
                            size: 62
                        },
                        {
                            xtype: 'combobox',
                            margin: '0 0 0 10',
                            fieldLabel: 'Country',
                            fieldStyle: 'background-color:#DAEBE1;background-image:none;',
                            emptyText: '---Select---'
                        },
                        {
                            xtype: 'textfield',
                            colspan: 2,
                            fieldLabel: 'University Name',
                            labelWidth: 125,
                            size: 62
                        },
                        {
                            xtype: 'combobox',
                            margin: '0 0 0 10',
                            fieldLabel: 'Country',
                            fieldStyle: 'background-color:#DAEBE1;background-image:none;',
                            emptyText: '---Select---'
                        },
                        {
                            xtype: 'textfield',
                            colspan: 2,
                            fieldLabel: 'Subjects',
                            labelWidth: 125,
                            size: 62
                        },
                        {
                            xtype: 'checkboxfield',
                            colspan: 2,
                            margin: '0 0 0 10',
                            fieldLabel: 'Approved',
                            boxLabel: 'Box Label'
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
                    colspan: 2,
                    title: 'Employee Education',
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