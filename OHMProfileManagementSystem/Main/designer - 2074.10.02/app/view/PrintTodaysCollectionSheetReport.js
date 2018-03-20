/*
 * File: app/view/PrintTodaysCollectionSheetReport.js
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

Ext.define('MyApp.view.PrintTodaysCollectionSheetReport', {
    extend: 'Ext.panel.Panel',

    requires: [
        'Ext.form.Panel',
        'Ext.form.field.ComboBox',
        'Ext.form.field.Checkbox',
        'Ext.button.Button'
    ],

    frame: true,
    title: 'Print Todays Collection Sheet Report',

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'form',
                    frame: true,
                    bodyPadding: 10,
                    title: 'Report Options',
                    layout: {
                        type: 'table',
                        columns: 3
                    },
                    items: [
                        {
                            xtype: 'textfield',
                            cls: 'popup',
                            fieldLabel: 'Center Code:',
                            labelWidth: 110,
                            fieldCls: 'popup'
                        },
                        {
                            xtype: 'textfield',
                            colspan: 3,
                            cls: 'readonly',
                            margin: '0 0 0 15',
                            width: 547,
                            fieldLabel: '',
                            readOnly: true
                        },
                        {
                            xtype: 'textfield',
                            fieldLabel: 'Collection Day:',
                            labelWidth: 110,
                            readOnly: true
                        },
                        {
                            xtype: 'textfield',
                            margin: '0 0 0 15',
                            fieldLabel: 'Collection Date(B.S.):',
                            labelWidth: 120,
                            readOnly: true
                        },
                        {
                            xtype: 'textfield',
                            margin: '0 0 0 15',
                            fieldLabel: '(A.D.):',
                            readOnly: true
                        },
                        {
                            xtype: 'textfield',
                            fieldLabel: 'Field Asistant:',
                            labelWidth: 110,
                            readOnly: true
                        },
                        {
                            xtype: 'textfield',
                            colspan: 3,
                            margin: '0 0 0 15',
                            width: 547,
                            fieldLabel: '',
                            readOnly: true
                        }
                    ]
                },
                {
                    xtype: 'form',
                    frame: true,
                    bodyPadding: 10,
                    title: 'Destination',
                    layout: {
                        type: 'table',
                        columns: 2
                    },
                    items: [
                        {
                            xtype: 'combobox',
                            width: 415,
                            fieldLabel: 'Destination Format:',
                            labelWidth: 110
                        },
                        {
                            xtype: 'combobox',
                            margin: '0 0 0 15',
                            width: 395,
                            fieldLabel: 'Destination Parameter:',
                            labelWidth: 130
                        },
                        {
                            xtype: 'combobox',
                            width: 415,
                            fieldLabel: 'Destination Type:',
                            labelWidth: 110
                        },
                        {
                            xtype: 'checkboxfield',
                            margin: '0 0 0 15',
                            fieldLabel: 'Print ?',
                            boxLabel: 'Box Label'
                        },
                        {
                            xtype: 'container',
                            layout: {
                                type: 'hbox',
                                align: 'stretch',
                                pack: 'end'
                            },
                            items: [
                                {
                                    xtype: 'button',
                                    padding: 5,
                                    text: 'Saving Collection Sheet'
                                }
                            ]
                        },
                        {
                            xtype: 'container',
                            layout: {
                                type: 'hbox',
                                align: 'stretch'
                            },
                            items: [
                                {
                                    xtype: 'button',
                                    padding: 5,
                                    text: 'Loan Collection Sheet'
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