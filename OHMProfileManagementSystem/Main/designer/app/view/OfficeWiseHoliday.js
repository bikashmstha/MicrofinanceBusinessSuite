/*
 * File: app/view/OfficeWiseHoliday.js
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

Ext.define('MyApp.view.OfficeWiseHoliday', {
    extend: 'Ext.panel.Panel',

    requires: [
        'Ext.form.Panel',
        'Ext.form.field.ComboBox',
        'Ext.grid.Panel',
        'Ext.grid.View',
        'Ext.form.field.Checkbox',
        'Ext.grid.column.Action',
        'Ext.selection.RowModel',
        'Ext.grid.plugin.RowEditing'
    ],

    frame: true,
    title: 'Office Wise Holiday',

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'form',
                    frame: true,
                    itemId: 'frmOfficeWiseHoliday',
                    bodyPadding: 10,
                    title: 'Daily Calender',
                    items: [
                        {
                            xtype: 'combobox',
                            anchor: '100%',
                            itemId: 'ddlOffice',
                            maxWidth: 400,
                            width: 400,
                            fieldLabel: 'Office Code',
                            emptyText: '- - -Select - - - ',
                            displayField: 'OfficeName',
                            queryMode: 'local',
                            store: 'OfficeShortStore',
                            valueField: 'OfficeCode'
                        },
                        {
                            xtype: 'combobox',
                            anchor: '100%',
                            itemId: 'ddlFiscalYear',
                            maxWidth: 250,
                            width: 250,
                            fieldLabel: 'Fiscal Year',
                            emptyText: '- - -Select - - - ',
                            displayField: 'FiscalYearCode',
                            queryMode: 'local',
                            store: 'FiscalYearShortStore',
                            valueField: 'FiscalYearCode',
                            listeners: {
                                change: {
                                    fn: me.onDdlFiscalYearChange,
                                    scope: me
                                }
                            }
                        },
                        {
                            xtype: 'gridpanel',
                            itemId: 'grdOfficeWiseHoliday',
                            title: 'Holidays',
                            store: 'OfficeWiseHolidayStore',
                            columns: [
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'OfficeCode',
                                    text: 'OfficeCode'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'EnglishDate',
                                    text: 'English Date',
                                    editor: {
                                        xtype: 'textfield',
                                        itemId: 'txtEnglishDate'
                                    }
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'NepaliDate',
                                    text: 'Nepali Date',
                                    editor: {
                                        xtype: 'textfield',
                                        itemId: 'txtNepaliDate'
                                    }
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'Holiday',
                                    text: 'Holiday',
                                    editor: {
                                        xtype: 'checkboxfield',
                                        itemId: 'chkHoliday'
                                    }
                                },
                                {
                                    xtype: 'gridcolumn',
                                    width: 116,
                                    dataIndex: 'HolidayDesc',
                                    text: 'Holiday Description',
                                    editor: {
                                        xtype: 'textfield',
                                        itemId: 'txtHolidayDesc'
                                    }
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'LoanHoliday',
                                    text: 'Loan Holiday',
                                    editor: {
                                        xtype: 'checkboxfield',
                                        itemId: 'chkLoanHoliday'
                                    }
                                },
                                {
                                    xtype: 'gridcolumn',
                                    width: 148,
                                    dataIndex: 'LoanHolidayDesc',
                                    text: 'Loan Holiday Description',
                                    editor: {
                                        xtype: 'textfield',
                                        itemId: 'txtLoanHolidayDesc'
                                    }
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'Action',
                                    text: 'Action',
                                    editor: {
                                        xtype: 'textfield',
                                        itemId: 'txtAction'
                                    }
                                },
                                {
                                    xtype: 'actioncolumn',
                                    hidden: true,
                                    itemId: 'delOfficeWiseHoliday',
                                    items: [
                                        {
                                            handler: function(view, rowIndex, colIndex, item, e, record, row) {

                                            }
                                        }
                                    ]
                                }
                            ],
                            selModel: Ext.create('Ext.selection.RowModel', {

                            }),
                            plugins: [
                                Ext.create('Ext.grid.plugin.RowEditing', {
                                    listeners: {
                                        validateedit: {
                                            fn: me.onRowEditingValidateedit,
                                            scope: me
                                        },
                                        canceledit: {
                                            fn: me.onRowEditingCanceledit,
                                            scope: me
                                        }
                                    }
                                })
                            ]
                        }
                    ],
                    listeners: {
                        afterrender: {
                            fn: me.onFrmOfficeWiseHolidayAfterRender,
                            scope: me
                        }
                    }
                }
            ]
        });

        me.callParent(arguments);
    },

    onDdlFiscalYearChange: function(field, newValue, oldValue, eOpts) {
        var office=Ext.ComponentQuery.query('#ddlOffice')[0];
        var fiscalYear=Ext.ComponentQuery.query('#ddlFiscalYear')[0];

        var officeWiseHolidayStore=Ext.getStore('OfficeWiseHoliday');
        officeWiseHolidayStore.removeAll();

        Ext.Ajax.request({
            url: '../Handlers/GeneralMasterParameters/Miantenance/OfficeWiseHolidayHandler.ashx',
            params: {
                method:'GetOfficeShort'
            },
            success: function(response){

            var data=Ext.decode(response.responseText);
            officeWiseHolidayStore.removeAll();
            officeWiseHolidayStore.add(data.root);


        }
        });

    },

    onRowEditingValidateedit: function(editor, e, eOpts) {

    },

    onRowEditingCanceledit: function(editor, e, eOpts) {

    },

    onFrmOfficeWiseHolidayAfterRender: function(component, eOpts) {
        var officeShortStore=Ext.getStore('OfficeShortStore');
        officeShortStore.removeAll();

        Ext.Ajax.request({
            url: '../Handlers/GeneralMasterParameters/Office/OfficeHandler.ashx',
            params: {
                method:'GetOfficeShort'
            },
            success: function(response){

            var data=Ext.decode(response.responseText);
            officeShortStore.removeAll();
            officeShortStore.add(data.root);


        }
        });

        var fiscalYearShortStore=Ext.getStore('FiscalYearShortStore');
        fiscalYearShortStore.removeAll();

        Ext.Ajax.request({
            url: '../Handlers/Common/FiscalYearHandler.ashx',
            params: {
                method:'GetFiscalYearShort'
            },
            success: function(response){

            var data=Ext.decode(response.responseText);
            fiscalYearShortStore.removeAll();
            fiscalYearShortStore.add(data.root);


        }
        });
    }

});