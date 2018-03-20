/*
 * File: app/view/TransactionPostingOffline.js
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

Ext.define('MyApp.view.TransactionPostingOffline', {
    extend: 'Ext.panel.Panel',

    requires: [
        'Ext.form.Panel',
        'Ext.form.field.Text',
        'Ext.button.Button',
        'Ext.grid.Panel',
        'Ext.grid.View',
        'Ext.grid.column.Column',
        'Ext.form.field.Checkbox'
    ],

    frame: true,
    title: 'Collection Posting Offline',

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'form',
                    frame: true,
                    id: 'frmTransactionPostingOffline',
                    itemId: 'frmTransactionPostingOffline',
                    bodyPadding: 10,
                    title: '',
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
                                    itemId: 'txtDateBS',
                                    margin: '0 0 0 50',
                                    padding: 10,
                                    fieldLabel: 'Date(B.S.)',
                                    labelWidth: 60,
                                    fieldStyle: 'background-color:#DAEBE1;background-image:none;',
                                    listeners: {
                                        afterrender: {
                                            fn: me.onTxtDateBSAfterRender,
                                            scope: me
                                        }
                                    }
                                },
                                {
                                    xtype: 'textfield',
                                    itemId: 'txtDateAD',
                                    margin: '0 0 0 50',
                                    fieldLabel: '(A.D.)',
                                    labelWidth: 50,
                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                },
                                {
                                    xtype: 'container',
                                    colspan: 2,
                                    height: 28,
                                    margin: '10 0 10 0',
                                    layout: {
                                        type: 'hbox',
                                        align: 'stretch',
                                        pack: 'center',
                                        padding: ''
                                    },
                                    items: [
                                        {
                                            xtype: 'button',
                                            itemId: 'btnLoadData',
                                            text: 'Load Data',
                                            listeners: {
                                                click: {
                                                    fn: me.onBtnLoadDataClick,
                                                    scope: me
                                                }
                                            }
                                        }
                                    ]
                                },
                                {
                                    xtype: 'gridpanel',
                                    colspan: 2,
                                    hidden: true,
                                    itemId: 'grdCollectionPostOffline',
                                    title: '',
                                    store: 'CollectionPostingOfflineStore',
                                    columns: [
                                        {
                                            xtype: 'gridcolumn',
                                            width: 115,
                                            dataIndex: 'CollectionSheetNo',
                                            text: 'Collection Sheet No'
                                        },
                                        {
                                            xtype: 'gridcolumn',
                                            width: 116,
                                            dataIndex: 'CenterCode',
                                            text: 'Center Code'
                                        },
                                        {
                                            xtype: 'gridcolumn',
                                            width: 150,
                                            dataIndex: 'CenterName',
                                            text: 'Center Name'
                                        },
                                        {
                                            xtype: 'gridcolumn',
                                            width: 145,
                                            dataIndex: 'EmpName',
                                            text: 'Employee Name'
                                        },
                                        {
                                            xtype: 'gridcolumn',
                                            width: 120,
                                            dataIndex: 'CenterFundAccount',
                                            text: 'Center Fund Account'
                                        },
                                        {
                                            xtype: 'gridcolumn',
                                            width: 135,
                                            dataIndex: 'CenterFundAmount',
                                            text: 'Center Fund Amount'
                                        },
                                        {
                                            xtype: 'gridcolumn',
                                            dataIndex: 'TranOfficeCode',
                                            text: 'Post',
                                            editor: {
                                                xtype: 'checkboxfield'
                                            }
                                        }
                                    ]
                                },
                                {
                                    xtype: 'container',
                                    colspan: 2,
                                    layout: {
                                        type: 'table',
                                        columns: 4
                                    },
                                    items: [
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtPrinciplePaidAmount',
                                            fieldLabel: 'Principle Paid Amount',
                                            labelWidth: 125,
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtTotalPaidAmount',
                                            margin: '0 0 0 10',
                                            fieldLabel: 'Total Paid Amount',
                                            labelWidth: 110,
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtTotalMemberSaving',
                                            margin: '0 0 0 10',
                                            fieldLabel: 'Total Member Saving',
                                            labelWidth: 120,
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtAdjustForSaving',
                                            margin: '0 0 0 10',
                                            fieldLabel: 'Adjust  For Saving',
                                            labelWidth: 120,
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtInterestPaidAmount',
                                            fieldLabel: 'Interest Paid Amount ',
                                            labelWidth: 126,
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtLoanSavingAdjust',
                                            margin: '0 0 0 10',
                                            fieldLabel: 'Loan Saving Adjust',
                                            labelWidth: 110,
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtTotalCenterFund',
                                            margin: '0 0 0 10',
                                            fieldLabel: 'Total Center Fund',
                                            labelWidth: 120,
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtTotalSavingCash',
                                            margin: '0 0 0 10',
                                            fieldLabel: 'Total Saving Cash',
                                            labelWidth: 120,
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtPenaltyPaidAmount',
                                            fieldLabel: 'Penalty Paid Amount',
                                            labelWidth: 125,
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtTotalLoanCash',
                                            margin: '0 0 0 10',
                                            fieldLabel: 'Total Loan Cash',
                                            labelWidth: 110,
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtSavingWithdraw',
                                            margin: '0 0 0 10',
                                            fieldLabel: 'Saving Withdraw',
                                            labelWidth: 120,
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtTotalAdjustAmount',
                                            margin: '0 0 0 10',
                                            fieldLabel: 'Total Adjust Amount',
                                            labelWidth: 120,
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtTotalCashCollection',
                                            fieldLabel: 'Total Cash Collection',
                                            labelWidth: 125,
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                        }
                                    ]
                                },
                                {
                                    xtype: 'container',
                                    colspan: 2,
                                    height: 28,
                                    layout: {
                                        type: 'hbox',
                                        align: 'stretch',
                                        pack: 'center',
                                        padding: ''
                                    },
                                    items: [
                                        {
                                            xtype: 'button',
                                            itemId: 'btnCollectionSheetPosting',
                                            text: 'Collection Sheet Posting',
                                            listeners: {
                                                click: {
                                                    fn: me.onBtnCollectionSheetPostingClick,
                                                    scope: me
                                                }
                                            }
                                        }
                                    ]
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

    onTxtDateBSAfterRender: function(component, eOpts) {
        component.getEl().on('dblclick', function(){
             var winPopup = Ext.create('MyApp.view.SelectCollectionDatePopup',{

                });

                winPopup.extraParam={param:null};
                winPopup.show();
          });

    },

    onBtnLoadDataClick: function(button, e, eOpts) {
        Ext.Ajax.request({
            url:'../Handlers/Finance/Processing/CollectionSheetMasterOfflineHandler.ashx',
            params:{method:'GetCollectionSheetMstOffline',OfficeCode:getOfficeCode(), Date: Ext.ComponentQuery.query('#txtDateAD')[0].getValue()},
            success: function ( result, request ) {

                var obj = Ext.decode(result.responseText);
                if(obj.success === 'true'){
                    console.log("Resu",obj.root);
                    Ext.ComponentQuery.query('#grdCollectionPostOffline')[0].show();
                    var store =Ext.getStore('CollectionPostingOfflineStore');
                    store.removeAll();
                    store.add(obj.root);


                }else{msg('FAILURE','Could Not Load Data');}
            },
            failure: function(form, action) {
                msg("FAILURE","Could Not Load Data");    }
        });
    },

    onBtnCollectionSheetPostingClick: function(button, e, eOpts) {
        var objColl ={

        /*OfficeCode : Ext.ComponentQuery.query('#')[0].getValue(),
        CollectionSheetNo : Ext.ComponentQuery.query('#')[0].getValue(),
        CenterCode : Ext.ComponentQuery.query('#')[0].getValue(),
        DataEntered : Ext.ComponentQuery.query('#')[0].getValue(),
        TransactionDate : Ext.ComponentQuery.query('#')[0].getValue(),
            */
        User1 : getCurrentUser()
        };

        var waitSave = watiMsg('Saving. Please wait ...');
        Ext.Ajax.request({
             url:'../Handlers/Finance/Processing/CollectionSheetPostingHandler.ashx',
             params:{method:'SaveCollectionSheetPosting',collectionSheetPosting:JSON.stringify(objColl)},
             success: function ( result, request ) {
        waitSave.hide();
                  var out = Ext.decode(result.responseText);
        				if(out.success==='true'){
        					msg('SUCCESS',out.message);
        						}

        				else{msg('FAILURE',out.message);


                  }
             },
             failure: function(form, action) {
        waitSave.hide();var out=Ext.decode(response.responseText);msg('FAILURE',out.message);     }
        });
    },

    onPanelAfterRender: function(component, eOpts) {


    }

});