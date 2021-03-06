/*
 * File: app/view/SelectDistrictPopup.js
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

Ext.define('MyApp.view.SelectDistrictPopup', {
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

    frame: true,
    height: 500,
    itemId: 'SelectDistrictPopup',
    width: 700,
    autoScroll: true,
    resizable: false,
    title: 'Select District Code',
    modal: true,

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'form',
                    frame: true,
                    itemId: 'frmSelectDistrictPopup',
                    autoScroll: true,
                    bodyPadding: 10,
                    title: '',
                    items: [
                        {
                            xtype: 'container',
                            layout: 'table',
                            items: [
                                {
                                    xtype: 'textfield',
                                    itemId: 'txtDistrictCodeSearch',
                                    fieldLabel: 'District Code'
                                },
                                {
                                    xtype: 'textfield',
                                    itemId: 'txtDistrictNameSearch',
                                    margin: '0 0 0 5',
                                    width: 340,
                                    fieldLabel: 'District Name'
                                },
                                {
                                    xtype: 'button',
                                    colspan: 2,
                                    itemId: 'btnSearchDistrict',
                                    margin: '0 0 0 5',
                                    text: 'Search',
                                    listeners: {
                                        click: {
                                            fn: me.onBtnSearchDistrictClick,
                                            scope: me
                                        }
                                    }
                                }
                            ]
                        },
                        {
                            xtype: 'gridpanel',
                            itemId: 'grdSearchDistrictCode',
                            title: '',
                            store: 'DistrictSearchStore',
                            columns: [
                                {
                                    xtype: 'gridcolumn',
                                    hidden: true,
                                    dataIndex: 'CIBCode',
                                    text: 'CIBCode'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'DistrictCode',
                                    text: 'District Code'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    width: 549,
                                    dataIndex: 'DistrictDesc',
                                    text: 'District Description'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    hidden: true,
                                    dataIndex: 'ZoneCode',
                                    text: 'ZoneCode'
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
                            itemId: 'pgsliderDistrictCode',
                            width: 360,
                            displayInfo: true
                        }
                    ]
                }
            ]
        });

        me.callParent(arguments);
    },

    onBtnSearchDistrictClick: function(button, e, eOpts) {
        var waitSave = watiMsg('Loading Data. Please wait ...');
        var districtCode=Ext.ComponentQuery.query('#txtDistrictCodeSearch')[0];
                var districtName=Ext.ComponentQuery.query('#txtDistrictNameSearch')[0];
        //console.log('districtCode',districtCode);
        Ext.Ajax.request({
            url: '../Handlers/Common/DistrictHandler.ashx',
            params: {
                method:'SearchDistrict',
                districtCode:districtCode.getValue(),
                districtName: districtName.getValue()
            },
            success: function(response){


                var obj = Ext.decode(response.responseText);

                if(obj.success === "true")
                {

                  var store=Ext.getStore('DistrictSearchStore');
                  store.removeAll();
                  store.add(obj.root);

                }
                else
                {

                    msg("FAILURE",obj.message);
                }


            waitSave.hide();



            }
        });
    },

    onRowModelBeforeSelect: function(rowmodel, record, index, eOpts) {
        Ext.MessageBox.confirm('Select', 'Are you sure ?', function(btn){

           if(btn === 'yes'){
               console.log('record',record);

               Ext.ComponentQuery.query('#txtDistrictCode')[0].setValue(record.data.DistrictCode);
               Ext.ComponentQuery.query('#txtDistrictName')[0].setValue(record.data.DistrictDesc);


              // return true;
           }
           else
           {

           }
            var v=Ext.ComponentQuery.query('#SelectDistrictPopup')[0];

            v.close();
        });

    }

});