/*
 * File: app/view/OfficeMap.js
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

Ext.define('MyApp.view.OfficeMap', {
    extend: 'Ext.panel.Panel',

    requires: [
        'Ext.form.Panel',
        'Ext.form.field.ComboBox',
        'Ext.grid.Panel',
        'Ext.grid.View',
        'Ext.grid.column.Action',
        'Ext.selection.RowModel',
        'Ext.button.Button'
    ],

    frame: true,
    title: 'Office Map',

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'form',
                    frame: true,
                    height: 2000,
                    bodyPadding: 10,
                    title: '',
                    layout: {
                        type: 'table',
                        columns: 2
                    },
                    items: [
                        {
                            xtype: 'combobox',
                            colspan: 2,
                            itemId: 'ddlOfficeGroup',
                            fieldLabel: 'Office Group',
                            size: 40,
                            displayField: 'OfficeName',
                            queryMode: 'local',
                            store: 'OfficeMapGroupSearchStore',
                            valueField: 'OfficeCode',
                            listeners: {
                                afterrender: {
                                    fn: me.onDdlOfficeGroupAfterRender,
                                    scope: me
                                },
                                select: {
                                    fn: me.onDdlOfficeGroupSelect,
                                    scope: me
                                }
                            }
                        },
                        {
                            xtype: 'gridpanel',
                            colspan: 2,
                            itemId: 'grdOfficeMap',
                            width: 601,
                            title: '',
                            store: 'OfficeMapStore',
                            columns: [
                                {
                                    xtype: 'gridcolumn',
                                    width: 96,
                                    dataIndex: 'OfficeCode',
                                    text: 'Office Code'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    width: 342,
                                    dataIndex: 'OfficeName',
                                    text: 'Office Name'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    hidden: true,
                                    dataIndex: 'OfficeGrpCode',
                                    text: 'OfficeGrpCode'
                                },
                                {
                                    xtype: 'actioncolumn',
                                    items: [
                                        {
                                            handler: function(view, rowIndex, colIndex, item, e, record, row) {
                                                Ext.ComponentQuery.query('#grdOfficeMap')[0].getSelectionModel().select(rowIndex);
                                                //get reference of store
                                                var store = Ext.getStore('OfficeMapStore');

                                                //get selected row using rowindex
                                                var row = store.getAt(rowIndex).data;



                                                // set values
                                                var officeCode=row.OfficeCode;
                                                var officeGrpCode=row.OfficeGrpCode;

                                                var obj={
                                                    OfficeCode:officeCode,
                                                    OfficeGrpCode:officeGrpCode,
                                                    Action:'D'
                                                };
                                                Ext.Ajax.request({
                                                    url: '../Handlers/GeneralMasterParameters/office/OfficeMapHandler.ashx',
                                                    params: {
                                                        method:'Save',
                                                        officeMap:JSON.stringify(obj)
                                                    },
                                                    success: function(response){


                                                        var out = Ext.decode(response.responseText);

                                                        console.log('resp',response);
                                                        if(out.success == "true")
                                                        {
                                                            msg("SUCCESS",out.message,function () {
                                                                store.removeAt(rowIndex);
                                                            });
                                                        }
                                                        else
                                                        {
                                                            msg("FAILURE",out.message);
                                                        }
                                                    }
                                                });
                                            },
                                            icon: '../ITS/resources/images/icons/cancel.png'
                                        }
                                    ]
                                }
                            ],
                            selModel: Ext.create('Ext.selection.RowModel', {

                            })
                        },
                        {
                            xtype: 'combobox',
                            itemId: 'ddlOffice',
                            margin: '10 0 0 0',
                            fieldLabel: 'Office',
                            size: 40,
                            displayField: 'OfficeName',
                            queryMode: 'local',
                            store: 'OfficeMapCodeSearchStore',
                            valueField: 'OfficeCode',
                            listeners: {
                                afterrender: {
                                    fn: me.onDdlOfficeAfterRender,
                                    scope: me
                                }
                            }
                        },
                        {
                            xtype: 'container',
                            colspan: 2,
                            layout: {
                                type: 'table',
                                columns: 3
                            },
                            items: [
                                {
                                    xtype: 'button',
                                    itemId: 'btnInsertOfficeGroup',
                                    margin: '10 0 0 5',
                                    text: 'Insert'
                                }
                            ]
                        }
                    ]
                }
            ],
            listeners: {
                afterrender: {
                    fn: me.onPanelAfterRender,
                    scope: me
                }
            }
        });

        me.callParent(arguments);
    },

    onDdlOfficeGroupAfterRender: function(component, eOpts) {

        var officeObj={
                OfficeCode:'',
                OfficeName:''


        };
        //console.log('districtCode',districtCode);
        Ext.Ajax.request({
            url: '../Handlers/GeneralMasterParameters/office/OfficeHandler.ashx',
            params: {
                method:'Search',
                office:JSON.stringify(officeObj)
            },
            success: function(response){


        var obj = Ext.decode(response.responseText);

                                console.log('resp',response);



              if(obj.success === "true")
                        {

                            var store=Ext.getStore('OfficeMapGroupSearchStore');
                            store.removeAll();
                            store.add(obj.root);

                        }
                        else
                        {

                            msg("FAILURE",obj.message);
                        }
            }
        });
    },

    onDdlOfficeGroupSelect: function(combo, records, eOpts) {
        var officeCode=Ext.ComponentQuery.query('#ddlOfficeGroup')[0];
        var officeMapObj={
                OfficeGrpCode:officeCode.getValue()
        };
        //console.log('districtCode',districtCode);
        Ext.Ajax.request({
            url: '../Handlers/GeneralMasterParameters/office/OfficeMapHandler.ashx',
            params: {
                method:'Search',
                officeMap:JSON.stringify(officeMapObj)
            },
            success: function(response){


        var obj = Ext.decode(response.responseText);

                                console.log('resp',response);



              if(obj.success === "true")
                        {

                            var store=Ext.getStore('OfficeMapStore');
                            store.removeAll();
                            store.add(obj.root);

                        }
                        else
                        {

                            msg("FAILURE",obj.message);
                        }
            }
        });
    },

    onDdlOfficeAfterRender: function(component, eOpts) {
        var officeObj={
                OfficeCode:'',
                OfficeName:''


        };
        //console.log('districtCode',districtCode);
        Ext.Ajax.request({
            url: '../Handlers/GeneralMasterParameters/office/OfficeHandler.ashx',
            params: {
                method:'Search',
                office:JSON.stringify(officeObj)
            },
            success: function(response){


        var obj = Ext.decode(response.responseText);

                                console.log('resp',response);



              if(obj.success === "true")
                        {

                            var store=Ext.getStore('OfficeMapCodeSearchStore');
                            store.removeAll();
                            store.add(obj.root);

                        }
                        else
                        {

                            msg("FAILURE",obj.message);
                        }
            }
        });
    },

    onPanelAfterRender: function(component, eOpts) {
         var store=Ext.getStore('OfficeMapStore');
         store.removeAll();

    }

});