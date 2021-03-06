/*
 * File: app/view/SelectTransferToCenterPopup.js
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

Ext.define('MyApp.view.SelectTransferToCenterPopup', {
    extend: 'Ext.window.Window',

    requires: [
        'Ext.form.field.Text',
        'Ext.button.Button',
        'Ext.grid.Panel',
        'Ext.grid.View',
        'Ext.selection.RowModel',
        'Ext.grid.column.Column'
    ],

    height: 500,
    itemId: 'SelectTransferToCenterPopup',
    width: 700,
    title: 'Select Centers',
    maximizable: true,
    minimizable: true,
    modal: true,

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'container',
                    layout: {
                        type: 'table',
                        columns: 2
                    },
                    items: [
                        {
                            xtype: 'textfield',
                            itemId: 'txtSearchCenter',
                            fieldLabel: 'Search'
                        },
                        {
                            xtype: 'button',
                            itemId: 'btnSearchCenter',
                            text: 'Search',
                            listeners: {
                                click: {
                                    fn: me.onBtnSearchCenterClick,
                                    scope: me
                                }
                            }
                        },
                        {
                            xtype: 'gridpanel',
                            colspan: 2,
                            itemId: 'grdSearchCenter',
                            width: 606,
                            title: '',
                            store: 'CenterShortStore',
                            selModel: Ext.create('Ext.selection.RowModel', {
                                listeners: {
                                    beforeselect: {
                                        fn: me.onRowModelBeforeSelect,
                                        scope: me
                                    }
                                }
                            }),
                            columns: [
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'CenterCode',
                                    text: 'Center Code'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    width: 245,
                                    dataIndex: 'CenterName',
                                    text: 'Center Name'
                                }
                            ]
                        }
                    ]
                }
            ],
            listeners: {
                afterrender: {
                    fn: me.onSelectTransferToCenterPopupAfterRender,
                    scope: me
                }
            }
        });

        me.callParent(arguments);
    },

    onBtnSearchCenterClick: function(button, e, eOpts) {
        var waitSave = watiMsg('Loading Data. Please wait ...');
        Ext.Ajax.request({
            url:'../Handlers/Finance/Transaction/EditTransaction/LoanTransferFromCenterHandler.ashx',
            params:{method:'GetLoanTransferFrmCenter', OfficeCode:getOfficeCode(),
                    CenterName:Ext.ComponentQuery.query('#txtSearchCenter')[0].getValue()
                   },
            success: function ( result, request ) {

                var obj = Ext.decode(result.responseText);
                if(obj.success === 'true'){
                    //console.log("Resu",obj.root);
                    var store =Ext.getStore('CenterShort1Store');
                    store.removeAll();
                    store.add(obj.root);


                }else{msg('FAILURE','Could Not Load Data');}

                waitSave.hide();
            },
            failure: function(form, action) {
                msg("FAILURE","Could Not Load Data"); waitSave.hide();   }
        });

    },

    onRowModelBeforeSelect: function(rowmodel, record, index, eOpts) {
        Ext.MessageBox.confirm('Select', 'Are you sure ?', function(btn){

           if(btn === 'yes'){


               Ext.ComponentQuery.query('#txtToCenterCode')[0].setValue(record.data.CenterCode);
               Ext.ComponentQuery.query('#txtToCenterDesc')[0].setValue(record.data.CenterName);

           }

           else
           {

           }
            var v=Ext.ComponentQuery.query('#SelectTransferToCenterPopup')[0];

            v.close();
        });





    },

    onSelectTransferToCenterPopupAfterRender: function(component, eOpts) {
        Ext.Ajax.request({
            url:'../Handlers/Finance/Transaction/EditTransaction/LoanTransferFromCenterHandler.ashx',
            params:{method:'GetLoanTransferFrmCenter', OfficeCode:getOfficeCode(), CenterName:null
                   },
            success: function ( result, request ) {

                var obj = Ext.decode(result.responseText);
                if(obj.success === 'true'){
                    //console.log("Resu",obj.root);
                    var store =Ext.getStore('CenterShort1Store');
                    store.removeAll();
                    store.add(obj.root);


                }else{msg('FAILURE','Could Not Load Data');}
            },
            failure: function(form, action) {
                msg("FAILURE","Could Not Load Data");    }
        });

    }

});