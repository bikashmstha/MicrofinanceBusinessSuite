/*
 * File: app/view/DocLoc.js
 *
 * This file was generated by Sencha Architect version 2.2.2.
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

Ext.define('MyApp.view.DocLoc', {
    extend: 'Ext.panel.Panel',

    frame: true,
    itemId: 'cboTest',
    layout: {
        align: 'stretch',
        type: 'vbox'
    },
    title: 'Physical Location Setup',

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'container',
                    flex: 1,
                    layout: {
                        align: 'stretch',
                        type: 'hbox'
                    },
                    items: [
                        {
                            xtype: 'panel',
                            flex: 1,
                            frame: true,
                            maxWidth: 215,
                            title: 'Office',
                            items: [
                                {
                                    xtype: 'combobox',
                                    id: 'cboOffice',
                                    itemId: 'cboOffice',
                                    fieldLabel: 'Office',
                                    labelWidth: 37,
                                    emptyText: 'select ...',
                                    displayField: 'OfficeNameEnglish',
                                    forceSelection: true,
                                    store: 'Office',
                                    valueField: 'OfficeCode'
                                }
                            ]
                        },
                        {
                            xtype: 'panel',
                            flex: 1,
                            frame: true,
                            layout: {
                                align: 'stretch',
                                type: 'vbox'
                            },
                            title: 'Building',
                            items: [
                                {
                                    xtype: 'gridpanel',
                                    height: 200,
                                    id: 'grdBuilding',
                                    itemId: 'grdBuilding',
                                    title: '',
                                    store: 'strDMlBuilding',
                                    columns: [
                                        {
                                            xtype: 'gridcolumn',
                                            hidden: true,
                                            dataIndex: 'OFFCODE',
                                            text: 'OFFCODE'
                                        },
                                        {
                                            xtype: 'gridcolumn',
                                            hidden: true,
                                            dataIndex: 'BUILDING_ID',
                                            text: 'BUILDING_ID'
                                        },
                                        {
                                            xtype: 'gridcolumn',
                                            maxWidth: 180,
                                            minWidth: 180,
                                            width: 180,
                                            dataIndex: 'BUILDING_DESC',
                                            text: 'BUILDING_DESC'
                                        },
                                        {
                                            xtype: 'gridcolumn',
                                            hidden: true,
                                            dataIndex: 'ENTRY_BY',
                                            text: 'ENTRY_BY'
                                        },
                                        {
                                            xtype: 'gridcolumn',
                                            hidden: true,
                                            dataIndex: 'ENTRY_DATE',
                                            text: 'ENTRY_DATE'
                                        }
                                    ]
                                },
                                {
                                    xtype: 'container',
                                    flex: 1,
                                    items: [
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtBuildingId',
                                            fieldLabel: 'Building ID'
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtBuilding',
                                            fieldLabel: 'Building Desc'
                                        },
                                        {
                                            xtype: 'checkboxfield',
                                            itemId: 'chkBuilding',
                                            fieldLabel: 'Status',
                                            boxLabel: '',
                                            checked: true
                                        },
                                        {
                                            xtype: 'hiddenfield',
                                            itemId: 'hdnOffcode',
                                            fieldLabel: 'Label'
                                        },
                                        {
                                            xtype: 'hiddenfield',
                                            itemId: 'hdnBuildingid',
                                            fieldLabel: 'Label'
                                        },
                                        {
                                            xtype: 'hiddenfield',
                                            itemId: 'hdnAction',
                                            fieldLabel: 'Label'
                                        },
                                        {
                                            xtype: 'button',
                                            itemId: 'btnUpdateBuilding',
                                            margin: '0 0 0 105',
                                            padding: '',
                                            text: 'Update'
                                        }
                                    ]
                                }
                            ]
                        },
                        {
                            xtype: 'panel',
                            flex: 1,
                            frame: true,
                            layout: {
                                align: 'stretch',
                                type: 'vbox'
                            },
                            title: 'Room',
                            items: [
                                {
                                    xtype: 'gridpanel',
                                    height: 200,
                                    itemId: 'grdRoom',
                                    title: '',
                                    store: 'strDMRoom',
                                    columns: [
                                        {
                                            xtype: 'gridcolumn',
                                            hidden: true,
                                            dataIndex: 'OFFCODE',
                                            text: 'OFFCODE'
                                        },
                                        {
                                            xtype: 'gridcolumn',
                                            hidden: true,
                                            dataIndex: 'BUILDING_ID',
                                            text: 'BUILDING_ID'
                                        },
                                        {
                                            xtype: 'gridcolumn',
                                            hidden: true,
                                            dataIndex: 'ROOM_NO',
                                            text: 'ROOM_NO'
                                        },
                                        {
                                            xtype: 'gridcolumn',
                                            maxWidth: 180,
                                            minWidth: 180,
                                            width: 180,
                                            dataIndex: 'ROOM_DESC',
                                            text: 'ROOM_DESC'
                                        },
                                        {
                                            xtype: 'gridcolumn',
                                            hidden: true,
                                            dataIndex: 'ENTRY_BY',
                                            text: 'ENTRY_BY'
                                        },
                                        {
                                            xtype: 'gridcolumn',
                                            hidden: true,
                                            dataIndex: 'ENTRY_DATE',
                                            text: 'ENTRY_DATE'
                                        }
                                    ],
                                    listeners: {
                                        beforerender: {
                                            fn: me.onGrdRoomBeforeRender,
                                            scope: me
                                        }
                                    }
                                },
                                {
                                    xtype: 'container',
                                    height: 50,
                                    items: [
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtRoomNo',
                                            fieldLabel: 'Room No',
                                            labelWidth: 65
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtRoomDesc',
                                            fieldLabel: 'Room Desc',
                                            labelWidth: 65
                                        },
                                        {
                                            xtype: 'checkboxfield',
                                            itemId: 'chkRoom',
                                            fieldLabel: 'Status',
                                            labelWidth: 65,
                                            boxLabel: '',
                                            checked: true
                                        },
                                        {
                                            xtype: 'button',
                                            itemId: 'btnUpdateRoom',
                                            margin: '0 0 0 105',
                                            text: 'Update'
                                        },
                                        {
                                            xtype: 'hiddenfield',
                                            itemId: 'hdnActionRoom',
                                            fieldLabel: 'Label'
                                        }
                                    ]
                                }
                            ]
                        },
                        {
                            xtype: 'panel',
                            flex: 1,
                            frame: true,
                            layout: {
                                align: 'stretch',
                                type: 'vbox'
                            },
                            title: 'Rack',
                            items: [
                                {
                                    xtype: 'gridpanel',
                                    height: 200,
                                    itemId: 'grdRack',
                                    title: '',
                                    store: 'strDMRack',
                                    columns: [
                                        {
                                            xtype: 'gridcolumn',
                                            hidden: true,
                                            dataIndex: 'OFFCODE',
                                            text: 'OFFCODE'
                                        },
                                        {
                                            xtype: 'gridcolumn',
                                            hidden: true,
                                            dataIndex: 'BUILDING_ID',
                                            text: 'BUILDING_ID'
                                        },
                                        {
                                            xtype: 'gridcolumn',
                                            hidden: true,
                                            dataIndex: 'ROOM_NO',
                                            text: 'ROOM_NO'
                                        },
                                        {
                                            xtype: 'gridcolumn',
                                            hidden: true,
                                            dataIndex: 'RACK_NO',
                                            text: 'RACK_NO'
                                        },
                                        {
                                            xtype: 'gridcolumn',
                                            maxWidth: 250,
                                            minWidth: 250,
                                            width: 250,
                                            dataIndex: 'RACK_DESC',
                                            text: 'RACK_DESC'
                                        },
                                        {
                                            xtype: 'gridcolumn',
                                            hidden: true,
                                            dataIndex: 'ENTRY_BY',
                                            text: 'ENTRY_BY'
                                        },
                                        {
                                            xtype: 'gridcolumn',
                                            hidden: true,
                                            dataIndex: 'ENTRY_DATE',
                                            text: 'ENTRY_DATE'
                                        }
                                    ]
                                },
                                {
                                    xtype: 'container',
                                    height: 100,
                                    items: [
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtRackNo',
                                            fieldLabel: 'Rack No',
                                            labelWidth: 65
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtRackDesc',
                                            fieldLabel: 'Rack Desc',
                                            labelWidth: 65
                                        },
                                        {
                                            xtype: 'checkboxfield',
                                            itemId: 'chkRack',
                                            fieldLabel: 'Status',
                                            labelWidth: 65,
                                            boxLabel: '',
                                            checked: true
                                        },
                                        {
                                            xtype: 'button',
                                            itemId: 'btnUpdateRack',
                                            margin: '0 0 0 105',
                                            text: 'Update'
                                        },
                                        {
                                            xtype: 'hiddenfield',
                                            itemId: 'hdnActionRack',
                                            fieldLabel: 'Label'
                                        }
                                    ]
                                }
                            ]
                        }
                    ]
                },
                {
                    xtype: 'container',
                    flex: 1,
                    height: 30,
                    maxHeight: 30,
                    minHeight: 30,
                    items: [
                        {
                            xtype: 'button',
                            itemId: 'BtnSubmitDL',
                            margin: '0 10 0 0',
                            iconCls: 'icon-ok',
                            text: 'Submit'
                        },
                        {
                            xtype: 'button',
                            iconCls: 'icon-cancel',
                            text: 'Cancel'
                        }
                    ]
                }
            ]
        });

        me.callParent(arguments);
    },

    onGrdRoomBeforeRender: function(component, eOpts) {
        /*
        var grid=Ext.ComponentQuery.query('#grdRoom')[0];



        grid.columns[3].renderer = function(value, metaData, record, rowIndex, colIndex, store, view) {
        var temp="";    


        var items = Ext.getStore('strDMRoom').data.items;

        //console.log("bankInfo",items);
        // alert("value>>"+value);

        //alert("len " + items.length);
        for(var i=0;i<items.length;i++)
        {  
            //alert("bank>>" + items[i].data.BankBr);







            if(items[i].data.BUILDING_DESC === value)
            {   

                //temp=items[i].data.BankName;
                alert('User already exist');

                break;
            }        
        }



    };
    */
    }

});