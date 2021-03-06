/*
 * File: app/view/SelectMemberMFPopup.js
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

Ext.define('MyApp.view.SelectMemberMFPopup', {
    extend: 'Ext.window.Window',

    requires: [
        'Ext.form.Panel',
        'Ext.form.field.Text',
        'Ext.button.Button',
        'Ext.grid.Panel',
        'Ext.grid.View',
        'Ext.selection.RowModel',
        'Ext.grid.column.Column'
    ],

    height: 500,
    itemId: 'SelectMemberMFPopup',
    width: 1100,
    autoScroll: true,
    layout: 'fit',
    title: 'Select Member',
    maximizable: true,
    minimizable: true,
    modal: true,
    y: 80,

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'form',
                    frame: true,
                    id: 'frmSelectMemberLoanEditPopup1',
                    itemId: 'frmSelectMemberLoanEditPopup',
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
                                    itemId: 'txtSearchMemberName',
                                    fieldLabel: 'Search'
                                },
                                {
                                    xtype: 'button',
                                    colspan: 2,
                                    itemId: 'btnSearchMemberCode',
                                    margin: '0 0 0 5',
                                    text: 'Search',
                                    listeners: {
                                        click: {
                                            fn: me.onBtnSearchMemberCodeClick,
                                            scope: me
                                        }
                                    }
                                }
                            ]
                        },
                        {
                            xtype: 'gridpanel',
                            itemId: 'grdSearchMember',
                            title: '',
                            store: 'MFLoanEditMemberCodeStore',
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
                                    width: 156,
                                    dataIndex: 'ClientCode',
                                    text: 'Member Code'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    width: 246,
                                    dataIndex: 'Name',
                                    text: 'Member Name'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    width: 169,
                                    dataIndex: 'GroupName',
                                    text: 'Group Name'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    width: 140,
                                    dataIndex: 'CenterCode',
                                    text: 'Center Code'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    width: 146,
                                    dataIndex: 'CenterName',
                                    text: 'Center Name'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    width: 119,
                                    dataIndex: 'Address',
                                    text: 'Address'
                                }
                            ]
                        }
                    ],
                    listeners: {
                        afterrender: {
                            fn: me.onFrmSelectMemberLoanEditPopupAfterRender,
                            scope: me
                        }
                    }
                }
            ]
        });

        me.callParent(arguments);
    },

    onBtnSearchMemberCodeClick: function(button, e, eOpts) {
        var waitSave = watiMsg('Loading Data. Please wait ...');
        Ext.Ajax.request({
            url:'../Handlers/Finance/Transaction/LoanTransaction/LoanMemberHandler.ashx',
            params:{method:'GetLoanMember',offCode:getOfficeCode(),
                    centerCode: Ext.ComponentQuery.query('#ddlCenterCode')[0].getValue(),
                   memberName:Ext.ComponentQuery.query('#txtSearchMemberName')[0].getValue()},
            success: function ( result, request ) {

                var obj = Ext.decode(result.responseText);
                if(obj.success === 'true'){
                    //console.log("Resu",obj.root);
                    var store =Ext.getStore('MFLoanEditMemberCodeStore');
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
               //console.log('record',record);


               Ext.ComponentQuery.query('#ddlCenterCode')[0].setValue(record.data.CenterCode);
               Ext.ComponentQuery.query('#txtMemberCode')[0].setValue(record.data.ClientCode);
               Ext.ComponentQuery.query('#txtMemberDesc')[0].setValue(record.data.Name);
               Ext.ComponentQuery.query('#txtGroupName')[0].setValue(record.data.GroupName);
               Ext.ComponentQuery.query('#txtAddress')[0].setValue(record.data.Address);
               Ext.ComponentQuery.query('#txtGroupName')[0].setValue(record.data.GroupName);
               Ext.ComponentQuery.query('#txtMemberCode')[0].ClientNo = record.data.ClientNo;
           }
           else
           {

           }
            var v=Ext.ComponentQuery.query('#SelectMemberMFPopup')[0];
            v.close();

        //get for adjust saving

        Ext.Ajax.request({
                            url:'../Handlers/Finance/Transaction/LoanTransaction/MfAdjustSavingHandler.ashx',
                            params:{method:'GetMfAdjustSaving',offCode:getOfficeCode(),
                                    clientNo:Ext.ComponentQuery.query('#txtMemberCode')[0].ClientNo,
                                    productName :null
                },
                            success: function ( result, request ) {

                                var obj = Ext.decode(result.responseText);
                                if(obj.success === 'true'){
                                    console.log("Resu",obj.root);
                                    var store =Ext.getStore('AdjustToSavingStore');
                                    store.removeAll();
                                    store.add(obj.root);



                                }else{msg('FAILURE','Could Not Load Data');}
                            },
                            failure: function(form, action) {
                                msg("FAILURE","Could Not Load Data");    }
                        });


        });

    },

    onFrmSelectMemberLoanEditPopupAfterRender: function(component, eOpts) {
        Ext.Ajax.request({
            url:'../Handlers/Finance/Transaction/LoanTransaction/LoanMemberHandler.ashx',
            params:{method:'GetLoanMember',offCode:getOfficeCode(),
                    centerCode: Ext.ComponentQuery.query('#ddlCenterCode')[0].getValue(),
                   memberName:null},
            success: function ( result, request ) {

                var obj = Ext.decode(result.responseText);
                if(obj.success === 'true'){
                    //console.log("Resu",obj.root);
                    var store =Ext.getStore('MFLoanEditMemberCodeStore');
                    store.removeAll();
                    store.add(obj.root);


                }else{msg('FAILURE','Could Not Load Data');}
            },
            failure: function(form, action) {
                msg("FAILURE","Could Not Load Data");    }
        });
    }

});