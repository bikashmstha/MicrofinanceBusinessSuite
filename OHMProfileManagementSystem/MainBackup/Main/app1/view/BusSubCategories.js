/*
 * File: app/view/BusSubCategories.js
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

Ext.define('MyApp.view.BusSubCategories', {
    extend: 'Ext.panel.Panel',

    frame: true,
    id: 'BusSubCategories',
    itemId: 'BusSubCategories',
    layout: {
        align: 'stretch',
        type: 'hbox'
    },
    title: 'Business Sub Categories',

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'panel',
                    flex: 1,
                    frame: true,
                    maxWidth: 200,
                    title: '',
                    items: [
                        {
                            xtype: 'gridpanel',
                            frame: true,
                            height: 445,
                            id: 'grdBusSubCat',
                            itemId: 'grdBusSubCat',
                            margin: '5 5 0 5',
                            autoScroll: true,
                            title: 'List of Business Sub Categories',
                            store: 'strBusSubCat',
                            viewConfig: {

                            },
                            columns: [
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'BusCategoryID',
                                    text: 'BusCategoryID'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'BusSubCategoryId',
                                    text: 'BusSubCategoryId'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'BusSubCategoryDescEng',
                                    text: 'BusSubCategoryDescEng'
                                }
                            ]
                        }
                    ]
                },
                {
                    xtype: 'panel',
                    flex: 1,
                    frame: true,
                    margin: '5 0 0 5',
                    title: '',
                    items: [
                        {
                            xtype: 'textfield',
                            id: 'txtBusCatId_bsc',
                            itemId: 'txtBusCatId_bsc',
                            fieldLabel: 'Business Category Id',
                            labelWidth: 200
                        },
                        {
                            xtype: 'textfield',
                            id: 'txtBusSubCatID_bsc',
                            itemId: 'txtBusSubCatID_bsc',
                            fieldLabel: 'Business SubCategory Id',
                            labelWidth: 200
                        },
                        {
                            xtype: 'textareafield',
                            height: 22,
                            id: 'txtBusSubCatEng_bsc',
                            itemId: 'txtBusSubCatEng_bsc',
                            fieldLabel: 'Business SubCategory English',
                            labelWidth: 200
                        },
                        {
                            xtype: 'textareafield',
                            height: 22,
                            id: 'txtBusSubCatNep_bsc',
                            itemId: 'txtBusSubCatNep_bsc',
                            fieldLabel: 'Busines SubCategory Nepali',
                            labelWidth: 200
                        },
                        {
                            xtype: 'checkboxfield',
                            id: 'chkStatus_bsc',
                            itemId: 'chkStatus_bsc',
                            fieldLabel: 'Status',
                            labelWidth: 200,
                            boxLabel: ''
                        },
                        {
                            xtype: 'button',
                            id: 'btnSave_bsc',
                            itemId: 'btnSave_bsc',
                            margin: '15 0 0 205',
                            width: 70,
                            text: 'Save'
                        },
                        {
                            xtype: 'button',
                            id: 'btnCancel_bsc',
                            itemId: 'btnCancel_bsc',
                            margin: '15 0 0 10',
                            width: 70,
                            text: 'Cancel'
                        }
                    ]
                }
            ]
        });

        me.callParent(arguments);
    }

});