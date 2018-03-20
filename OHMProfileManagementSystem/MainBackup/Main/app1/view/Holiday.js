/*
 * File: app/view/Holiday.js
 *
 * This file was generated by Sencha Architect version 2.1.0.
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

Ext.define('MyApp.view.Holiday', {
    extend: 'Ext.panel.Panel',

    frame: true,
    width: 900,
    layout: {
        align: 'stretch',
        type: 'hbox'
    },
    title: 'Holiday',

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'panel',
                    frame: true,
                    margin: '0 5 0 0',
                    width: 200,
                    autoScroll: false,
                    title: 'Holiday List',
                    items: [
                        {
                            xtype: 'gridpanel',
                            height: 200,
                            id: 'grdHoliday',
                            itemId: 'grdHoliday',
                            title: 'My Grid Panel',
                            store: 'Holiday',
                            viewConfig: {

                            },
                            columns: [
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'HolidayDesc',
                                    text: 'HolidayDesc'
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
                            title: 'Holiday Fields',
                            items: [
                                {
                                    xtype: 'fieldset',
                                    height: 190,
                                    margin: '20 10 10 10',
                                    padding: '35 20 20 30',
                                    items: [
                                        {
                                            xtype: 'textfield',
                                            anchor: '100%',
                                            id: 'txtoffcodeHoliday',
                                            itemId: 'txtoffcodeHoliday',
                                            maxWidth: 300,
                                            fieldLabel: 'Office Code',
                                            labelWidth: 180
                                        },
                                        {
                                            xtype: 'textfield',
                                            anchor: '100%',
                                            id: 'txtTaxYrHoliday',
                                            itemId: 'txtTaxYrHoliday',
                                            fieldLabel: 'Tax Year',
                                            labelWidth: 180
                                        },
                                        {
                                            xtype: 'textfield',
                                            anchor: '100%',
                                            id: 'datefldStartDateHoliday',
                                            itemId: 'datefldStartDateHoliday',
                                            fieldLabel: 'Start Date',
                                            labelWidth: 180
                                        },
                                        {
                                            xtype: 'textfield',
                                            anchor: '100%',
                                            id: 'datefldEndDateHoliday',
                                            itemId: 'datefldEndDateHoliday',
                                            fieldLabel: 'End Date',
                                            labelWidth: 180
                                        },
                                        {
                                            xtype: 'textfield',
                                            anchor: '100%',
                                            id: 'txtHolidayDescHoliday',
                                            itemId: 'txtHolidayDescHoliday',
                                            fieldLabel: 'Holiday Description',
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
                                            id: 'btnHolidaySubmit',
                                            itemId: 'btnHolidaySubmit',
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