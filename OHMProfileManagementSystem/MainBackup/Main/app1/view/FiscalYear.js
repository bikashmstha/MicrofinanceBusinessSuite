/*
 * File: app/view/FiscalYear.js
 *
 * This file was generated by Sencha Architect version 2.2.2.
 * http://www.sencha.com/products/architect/
 *
 * This file requires use of the Ext JS 4.0.x library, under independent license.
 * License of Sencha Architect does not include license for Ext JS 4.0.x. For more
 * details see http://www.sencha.com/license or contact license@sencha.com.
 *
 * This file will be auto-generated each and everytime you save your project.
 *
 * Do NOT hand edit this file.
 */

Ext.define('MyApp.view.FiscalYear', {
    extend: 'Ext.panel.Panel',

    frame: true,
    layout: {
        align: 'stretch',
        type: 'hbox'
    },
    title: 'Fiscal Year',

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'panel',
                    frame: true,
                    margin: '0 5 0 0',
                    width: 200,
                    title: 'Fiscal Year List',
                    items: [
                        {
                            xtype: 'gridpanel',
                            height: 380,
                            id: 'gridFiscalYear',
                            itemId: 'gridFiscalYear',
                            store: 'FiscalYear',
                            columns: [
                                {
                                    xtype: 'gridcolumn',
                                    hidden: true,
                                    width: 190,
                                    dataIndex: 'fiscalYear',
                                    text: 'Fiscal Year'
                                }
                            ]
                        }
                    ]
                },
                {
                    xtype: 'container',
                    flex: 1,
                    layout: {
                        align: 'stretch',
                        type: 'vbox'
                    },
                    items: [
                        {
                            xtype: 'panel',
                            flex: 7,
                            frame: true,
                            title: 'Fiscal Year Fields',
                            items: [
                                {
                                    xtype: 'fieldset',
                                    height: 300,
                                    margin: '20 10 10 10',
                                    padding: '35 20 20 30',
                                    items: [
                                        {
                                            xtype: 'textfield',
                                            anchor: '100%',
                                            id: 'txtFiscalYrFY',
                                            itemId: 'txtFiscalYrFY',
                                            maxWidth: 300,
                                            fieldLabel: 'Fiscal Year',
                                            labelWidth: 180
                                        },
                                        {
                                            xtype: 'textfield',
                                            anchor: '100%',
                                            id: 'txtStartDtFY',
                                            itemId: 'txtStartDtFY',
                                            fieldLabel: 'Start Date',
                                            labelWidth: 180
                                        },
                                        {
                                            xtype: 'textfield',
                                            anchor: '100%',
                                            id: 'txtEndDateFY',
                                            itemId: 'txtEndDateFY',
                                            fieldLabel: 'End Date',
                                            labelWidth: 180
                                        },
                                        {
                                            xtype: 'textfield',
                                            anchor: '100%',
                                            id: 'txtLstFiscalYearFY',
                                            itemId: 'txtLstFiscalYearFY',
                                            fieldLabel: 'Last Fiscal Year',
                                            labelWidth: 180
                                        },
                                        {
                                            xtype: 'textfield',
                                            anchor: '100%',
                                            id: 'txtCurrentFY',
                                            itemId: 'txtCurrentFY',
                                            fieldLabel: 'Current Fiscal Year',
                                            labelWidth: 180
                                        },
                                        {
                                            xtype: 'textfield',
                                            anchor: '100%',
                                            id: 'txtTerminalFY',
                                            itemId: 'txtTerminalFY',
                                            fieldLabel: 'Terminal',
                                            labelWidth: 180
                                        },
                                        {
                                            xtype: 'datefield',
                                            anchor: '100%',
                                            id: 'txtTransDateFY',
                                            itemId: 'txtTransDateFY',
                                            fieldLabel: 'Trans Date',
                                            labelWidth: 180
                                        },
                                        {
                                            xtype: 'textfield',
                                            anchor: '100%',
                                            id: 'txtUsernameFY',
                                            itemId: 'txtUsernameFY',
                                            fieldLabel: 'User Name',
                                            labelWidth: 180
                                        },
                                        {
                                            xtype: 'textfield',
                                            anchor: '100%',
                                            id: 'txtActiveYnFY',
                                            itemId: 'txtActiveYnFY',
                                            fieldLabel: 'Active YN',
                                            labelWidth: 180
                                        }
                                    ]
                                },
                                {
                                    xtype: 'fieldset',
                                    height: 30,
                                    margin: '1 10 01 10',
                                    padding: '3 0 0 150',
                                    items: [
                                        {
                                            xtype: 'button',
                                            itemId: 'btnCancel',
                                            margin: '0 0 0 10',
                                            text: 'Cancel'
                                        },
                                        {
                                            xtype: 'button',
                                            id: 'btnFiscalYearSubmit',
                                            itemId: 'btnFiscalYearSubmit',
                                            text: 'Submit'
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