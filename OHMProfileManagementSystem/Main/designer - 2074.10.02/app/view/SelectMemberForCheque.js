/*
 * File: app/view/SelectMemberForCheque.js
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

Ext.define('MyApp.view.SelectMemberForCheque', {
    extend: 'Ext.window.Window',

    requires: [
        'Ext.button.Button',
        'Ext.grid.Panel',
        'Ext.grid.View',
        'Ext.grid.column.Column',
        'Ext.selection.RowModel'
    ],

    height: 500,
    itemId: 'SelectMemberForCheque',
    width: 700,
    autoScroll: true,
    resizable: false,
    title: 'Select Member For Cheque',
    maximizable: true,
    minimizable: true,
    modal: true,

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'container',
                    items: [
                        {
                            xtype: 'button',
                            itemId: 'btnMemberForChequeSearch',
                            padding: 5,
                            text: 'Search',
                            listeners: {
                                click: {
                                    fn: me.onBtnMemberForChequeSearchClick,
                                    scope: me
                                }
                            }
                        }
                    ]
                },
                {
                    xtype: 'container',
                    items: [
                        {
                            xtype: 'gridpanel',
                            itemId: 'grdMemberForCheque',
                            title: 'Members',
                            store: 'MemberForChequeStore',
                            columns: [
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'ClientCode',
                                    text: 'Client Code'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    width: 194,
                                    dataIndex: 'ClientName',
                                    text: 'Client Name'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'CenterCode',
                                    text: 'Center Code'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'CenterName',
                                    text: 'Center Name'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'ClientNo',
                                    text: 'Client No'
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
                    ]
                }
            ]
        });

        me.callParent(arguments);
    },

    onBtnMemberForChequeSearchClick: function(button, e, eOpts) {
        var offCode=Ext.ComponentQuery.query('#ddlOffice')[0].getValue();
        var centerCode=Ext.ComponentQuery.query('#ddlCenter')[0].getValue();
        var memberName=null;//Ext.ComponentQuery.query('#ddlOffCode')[0].getValue();

        var store=Ext.getStore('MemberForChequeStore');
        store.removeAll();

        Ext.Ajax.request({
            url: '../Handlers/Finance/Transaction/SavingTransaction/MemberForChequeHandler.ashx',
            params: {
                method:'GetMemberForCheque',
                offCode:offCode,
                centerCode:centerCode,
                memberName:memberName
            },
            success: function(response){

            var data=Ext.decode(response.responseText);
            store.removeAll();
            store.add(data.root);


        }
        });
    },

    onRowModelBeforeSelect: function(rowmodel, record, index, eOpts) {
        Ext.MessageBox.confirm('Select', 'Are you sure ?', function(btn){

            if(btn === 'yes'){
                console.log('record',record);

                Ext.ComponentQuery.query('#txtMemberCode')[0].setValue(record.data.ClientNo);
                Ext.ComponentQuery.query('#txtMemberName')[0].setValue(record.data.ClientName);


                // return true;
            }
            else
            {

            }
            var v=Ext.ComponentQuery.query('#SelectMemberForCheque')[0];

            v.close();
        });

    }

});