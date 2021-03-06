/*
 * File: app/view/SelectOfficePopUp.js
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

Ext.define('MyApp.view.SelectOfficePopUp', {
    extend: 'Ext.window.Window',

    requires: [
        'Ext.form.Panel',
        'Ext.form.field.Text',
        'Ext.button.Button',
        'Ext.grid.Panel',
        'Ext.grid.View',
        'Ext.grid.column.Column',
        'Ext.selection.RowModel',
        'Ext.toolbar.Paging'
    ],

    height: 500,
    itemId: 'SelectOfficeGroupPopup',
    width: 700,
    autoScroll: true,
    title: 'Select Office Group',

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'form',
                    frame: true,
                    bodyPadding: 10,
                    title: '',
                    items: [
                        {
                            xtype: 'container',
                            layout: 'table',
                            items: [
                                {
                                    xtype: 'textfield',
                                    itemId: 'txtSearchOfficeCode',
                                    fieldLabel: 'Office Code'
                                },
                                {
                                    xtype: 'textfield',
                                    itemId: 'txtSearchOfficeName',
                                    margin: '0 0 0 10',
                                    width: 340,
                                    fieldLabel: 'Office Name'
                                },
                                {
                                    xtype: 'button',
                                    colspan: 2,
                                    itemId: 'btnSearchOfficeGroup',
                                    margin: '0 0 0 5',
                                    text: 'Search',
                                    listeners: {
                                        click: {
                                            fn: me.onBtnSearchOfficeGroupClick,
                                            scope: me
                                        }
                                    }
                                }
                            ]
                        },
                        {
                            xtype: 'gridpanel',
                            itemId: 'grdSearchFieldAssistants',
                            title: '',
                            store: 'Office2SearchStore',
                            columns: [
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'OfficeName',
                                    text: 'Office Name'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    width: 544,
                                    dataIndex: 'OfficeCode',
                                    text: 'Office Code'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    hidden: true,
                                    dataIndex: 'OfficeTypeCode',
                                    text: 'OfficeTypeCode'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    hidden: true,
                                    dataIndex: 'OfficeTypeName',
                                    text: 'OfficeTypeName'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    hidden: true,
                                    dataIndex: 'DistrictCode',
                                    text: 'DistrictCode'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    hidden: true,
                                    dataIndex: 'DistrictName',
                                    text: 'DistrictName'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    hidden: true,
                                    dataIndex: 'VdcName',
                                    text: 'VdcName'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    hidden: true,
                                    dataIndex: 'VdcCode',
                                    text: 'VdcCode'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    hidden: true,
                                    dataIndex: 'EstablishedDate',
                                    text: 'EstablishedDate'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    hidden: true,
                                    dataIndex: 'OfficeStatus',
                                    text: 'OfficeStatus'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    hidden: true,
                                    dataIndex: 'MigrationInProcess',
                                    text: 'MigrationInProcess'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    hidden: true,
                                    dataIndex: 'BudgetAlloCationYN',
                                    text: 'BudgetAlloCationYN'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    hidden: true,
                                    dataIndex: 'AutoAdjustmentCollSht',
                                    text: 'AutoAdjustmentCollSht'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    hidden: true,
                                    dataIndex: 'AutoAcOnNonMem',
                                    text: 'AutoAcOnNonMem'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    hidden: true,
                                    dataIndex: 'ContactPerson',
                                    text: 'ContactPerson'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    hidden: true,
                                    dataIndex: 'ParentOfficeName',
                                    text: 'ParentOfficeName'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    hidden: true,
                                    dataIndex: 'ParentOfficeCode',
                                    text: 'ParentOfficeCode'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    hidden: true,
                                    dataIndex: 'MyField3',
                                    text: 'MyField3'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    hidden: true,
                                    dataIndex: 'FaxNumber',
                                    text: 'FaxNumber'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    hidden: true,
                                    dataIndex: 'PhoneNumber',
                                    text: 'PhoneNumber'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    hidden: true,
                                    dataIndex: 'Email',
                                    text: 'Email'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    hidden: true,
                                    dataIndex: 'Address',
                                    text: 'Address'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    hidden: true,
                                    dataIndex: 'InterbranchAccountHeadName',
                                    text: 'InterbranchAccountHeadName'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    hidden: true,
                                    dataIndex: 'InterbranchAccountHead',
                                    text: 'InterbranchAccountHead'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    hidden: true,
                                    dataIndex: 'AbbsAllowYN',
                                    text: 'AbbsAllowYN'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    hidden: true,
                                    dataIndex: 'TransactionDate',
                                    text: 'TransactionDate'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    hidden: true,
                                    dataIndex: 'RowID',
                                    text: 'RowID'
                                }
                            ],
                            selModel: Ext.create('Ext.selection.RowModel', {
                                listeners: {
                                    beforeselect: {
                                        fn: me.onRowModelBeforeSelect,
                                        scope: me
                                    }
                                }
                            })
                        }
                    ],
                    dockedItems: [
                        {
                            xtype: 'pagingtoolbar',
                            dock: 'bottom',
                            itemId: 'pgsliderOfficeGroup',
                            width: 360,
                            displayInfo: true
                        }
                    ]
                }
            ]
        });

        me.callParent(arguments);
    },

    onBtnSearchOfficeGroupClick: function(button, e, eOpts) {
        /*
        var officeCode=Ext.ComponentQuery.query('#txtSearchOfficeCode')[0];
        var officeName=Ext.ComponentQuery.query('#txtSearchOfficeName')[0];

        //console.log('districtCode',districtCode);
        Ext.Ajax.request({
            url: '../Handlers/GeneralMasterParameters/office/OfficeHandler.ashx',
            params: {
                method:'SearchOffice',
               officeCode:officeCode.getValue(),
                officeName: officeName.getValue()
            },
            success: function(response){


        var obj = Ext.decode(response.responseText);

                                console.log('resp',response);



              if(obj.success === "true")
                        {

                            var store=Ext.getStore('OfficeSearchStore');
                            store.removeAll();
                            store.add(obj.root);

                        }
                        else
                        {

                            msg("FAILURE",obj.message);
                        }






            }
        });
        */
    },

    onRowModelBeforeSelect: function(rowmodel, record, index, eOpts) {
        Ext.MessageBox.confirm('Select', 'Are you sure ?', function(btn){

           if(btn === 'yes'){
               console.log('record',record);

               Ext.ComponentQuery.query('#txtInsertOfficeCode')[0].setValue(record.data.OfficeCode);
               Ext.ComponentQuery.query('#txtInsertOfficeName')[0].setValue(record.data.OfficeName);


              // return true;
           }
           else
           {

           }
            var v=Ext.ComponentQuery.query('#SelectOfficePopUp')[0];

            v.close();
        });

    }

});