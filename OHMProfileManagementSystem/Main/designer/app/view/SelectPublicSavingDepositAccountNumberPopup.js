/*
 * File: app/view/SelectPublicSavingDepositAccountNumberPopup.js
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

Ext.define('MyApp.view.SelectPublicSavingDepositAccountNumberPopup', {
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
    itemId: 'SelectPublicSavingDepositAccountNumberPopup',
    width: 900,
    autoScroll: true,
    title: 'Select Saving Account Number',

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'form',
                    frame: true,
                    itemId: 'frmSelectVdcPopup',
                    autoScroll: true,
                    bodyPadding: 10,
                    items: [
                        {
                            xtype: 'container',
                            layout: 'table',
                            items: [
                                {
                                    xtype: 'textfield',
                                    itemId: 'txtSearchSavingAccountNumber',
                                    fieldLabel: 'Search ACC No.'
                                },
                                {
                                    xtype: 'button',
                                    colspan: 2,
                                    itemId: 'btnSearchSavingAccountNumber',
                                    margin: '0 0 0 5',
                                    text: 'Search',
                                    listeners: {
                                        click: {
                                            fn: me.onBtnSearchSavingAccountNumberClick,
                                            scope: me
                                        }
                                    }
                                }
                            ]
                        },
                        {
                            xtype: 'gridpanel',
                            itemId: 'grdSearchSavingAccountNo',
                            title: '',
                            store: 'SavingAccountNumberSearchStore',
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
                                    dataIndex: 'SavingAccountNo',
                                    text: 'Saving Account No'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'ClientDesc',
                                    text: 'Member Name'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    width: 120,
                                    dataIndex: 'FixedCollectAmount',
                                    text: 'Fixed Collect Amount'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'Address',
                                    text: 'Address'
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
                                    dataIndex: 'ProductCode',
                                    text: 'Product Code'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'ProductName',
                                    text: 'Product Name'
                                }
                            ]
                        }
                    ],
                    listeners: {
                        afterrender: {
                            fn: me.onFrmSelectVdcPopupAfterRender,
                            scope: me
                        }
                    }
                }
            ]
        });

        me.callParent(arguments);
    },

    onBtnSearchSavingAccountNumberClick: function(button, e, eOpts) {
        var productcode=Ext.ComponentQuery.query('#ddlSavingProduct')[0].getValue();

        var savingAccountNumber=Ext.ComponentQuery.query('#txtSearchSavingAccountNumber')[0].getValue();

        var waitSave = watiMsg("Searching..Please wait ...");
            Ext.Ajax.request({
            url: '../Handlers/Finance/Transaction/PublicSavingTransaction/PublicSavingDepositAccountHandler.ashx',
            params: {
                method:'GetPubSavingDepoAcc',
                OfficeCode:getOfficeCode(),
                ProductCode:productcode,
                SavingAccountNo:savingAccountNumber,

            },
            success: function(response){


                var obj = Ext.decode(response.responseText);



                if(obj.success === "true")
                {
                    waitSave.hide();
                    var store=Ext.getStore('SavingAccountNumberSearchStore');
                    store.removeAll();
                    store.add(obj.root);


                }
                else
                {
                    waitSave.hide();
                    msg("FAILURE",obj.message);
                }
            },
                failure: function(response){
                                waitSave.hide();
                    alert('failed',response);

                }
        });



    },

    onRowModelBeforeSelect: function(rowmodel, record, index, eOpts) {
        Ext.MessageBox.confirm('Select', 'Are you sure ?', function(btn){

           if(btn === 'yes'){
               console.log('record',record);

               Ext.ComponentQuery.query('#txtSavingAccountNo')[0].setValue(record.data.SavingAccountNo);
               Ext.ComponentQuery.query('#txtMemberName')[0].setValue(record.data.ClientDesc);
               Ext.ComponentQuery.query('#hdnAccountNo')[0].setValue(record.data.AccountNo);
               Ext.ComponentQuery.query('#txtFixedCollectionAmount')[0].setValue(record.data.FixedCollectAmount);
               //Ext.ComponentQuery.query('#ddlCenter')[0].setValue(record.data.CenterCode);
              // Ext.ComponentQuery.query('#hdnAccountNumber')[0].setValue(record.data.AccountNo);





              // return true;
           }
           else
           {

           }
            var v=Ext.ComponentQuery.query('#SelectPublicSavingDepositAccountNumberPopup')[0];

            v.close();
        });

    },

    onFrmSelectVdcPopupAfterRender: function(component, eOpts) {
        var store=Ext.getStore('SavingAccountNumberSearchStore');
        store.removeAll();
    }

});