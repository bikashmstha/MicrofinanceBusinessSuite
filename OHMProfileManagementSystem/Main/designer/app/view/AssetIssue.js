/*
 * File: app/view/AssetIssue.js
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

Ext.define('MyApp.view.AssetIssue', {
    extend: 'Ext.panel.Panel',

    requires: [
        'Ext.form.Panel',
        'Ext.form.field.ComboBox',
        'Ext.form.field.Checkbox',
        'Ext.grid.Panel',
        'Ext.grid.View',
        'Ext.grid.column.Column',
        'Ext.grid.plugin.RowEditing',
        'Ext.selection.RowModel',
        'Ext.button.Button'
    ],

    frame: true,
    title: 'Asset Issue',

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'form',
                    frame: true,
                    itemId: 'frmAssetIssue',
                    width: 1203,
                    autoScroll: true,
                    title: '',
                    layout: {
                        type: 'table',
                        columns: 5
                    },
                    items: [
                        {
                            xtype: 'combobox',
                            colspan: 2,
                            itemId: 'ddlAsset',
                            fieldLabel: 'Asset',
                            labelWidth: 110,
                            fieldStyle: 'background-color:#DAEBE1;background-image:none;',
                            emptyText: '---Select---',
                            displayField: 'AssetDesc',
                            forceSelection: true,
                            queryMode: 'local',
                            store: 'AssetShortStore',
                            valueField: 'AssetCode',
                            listeners: {
                                change: {
                                    fn: me.onDdlAssetChange,
                                    scope: me
                                }
                            }
                        },
                        {
                            xtype: 'textfield',
                            colspan: 1,
                            itemId: 'txtItemCode',
                            margin: '0 0 0 10',
                            fieldLabel: 'Item',
                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                        },
                        {
                            xtype: 'textfield',
                            colspan: 2,
                            itemId: 'txtItemDesc',
                            margin: '0 0 0 -130',
                            fieldLabel: 'Label',
                            hideLabel: true,
                            fieldStyle: 'background-color:#D2D2D2;background-image:none;',
                            size: 52
                        },
                        {
                            xtype: 'textfield',
                            itemId: 'txtCurrentDeptCode',
                            fieldLabel: 'Current Dept',
                            labelWidth: 110,
                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                        },
                        {
                            xtype: 'textfield',
                            itemId: 'txtCurrentDeptDesc',
                            margin: '0 0 0 10',
                            fieldLabel: 'Label',
                            hideLabel: true,
                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                        },
                        {
                            xtype: 'textfield',
                            colspan: 1,
                            itemId: 'txtPurchaseDateBS',
                            margin: '0 0 0 10',
                            fieldLabel: 'Purchase Date',
                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                        },
                        {
                            xtype: 'textfield',
                            colspan: 2,
                            itemId: 'txtPurchaseDateAD',
                            margin: '0 0 0 -130',
                            fieldLabel: 'Label',
                            hideLabel: true,
                            fieldStyle: 'background-color:#D2D2D2;background-image:none;',
                            size: 17
                        },
                        {
                            xtype: 'textfield',
                            itemId: 'txtDepriciationPer',
                            fieldLabel: 'Depr(%)',
                            labelWidth: 110,
                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                        },
                        {
                            xtype: 'checkboxfield',
                            itemId: 'chkTransferred',
                            margin: '0 0 0 10',
                            fieldLabel: 'Transfered(Yes/No)',
                            boxLabel: ''
                        },
                        {
                            xtype: 'textfield',
                            colspan: 2,
                            itemId: 'txtLastDepeDateBS',
                            margin: '0 0 0 150',
                            fieldLabel: 'Last Depe Date',
                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                        },
                        {
                            xtype: 'textfield',
                            itemId: 'txtLastDepeDateAD',
                            margin: '0 0 0 10',
                            fieldLabel: 'Label',
                            hideLabel: true,
                            fieldStyle: 'background-color:#D2D2D2;background-image:none;',
                            size: 30
                        },
                        {
                            xtype: 'textfield',
                            itemId: 'txtLastDeprAmt',
                            fieldLabel: 'Last Depr Amount',
                            labelWidth: 110,
                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                        },
                        {
                            xtype: 'textfield',
                            colspan: 1,
                            itemId: 'txtCurrentValue',
                            margin: '0 0 0 40',
                            fieldLabel: 'Current Value',
                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                        },
                        {
                            xtype: 'textfield',
                            colspan: 3,
                            itemId: 'txtPurchasePrice',
                            margin: '0 0 0 150',
                            fieldLabel: 'Purchase Price',
                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                        },
                        {
                            xtype: 'textfield',
                            itemId: 'txtTotalMaintenance',
                            fieldLabel: 'Total Maintenance',
                            labelWidth: 110,
                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                        },
                        {
                            xtype: 'textfield',
                            colspan: 1,
                            itemId: 'txtTotalDepr',
                            margin: '0 0 0 40',
                            fieldLabel: 'Total Depr',
                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                        },
                        {
                            xtype: 'textfield',
                            colspan: 2,
                            itemId: 'txtCurrentOfficeCode',
                            margin: '0 0 0 150',
                            fieldLabel: 'Current Office',
                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                        },
                        {
                            xtype: 'textfield',
                            itemId: 'txtCurrentOfficeDesc',
                            margin: '0 0 0 10',
                            fieldLabel: 'Label',
                            hideLabel: true,
                            fieldStyle: 'background-color:#D2D2D2;background-image:none;',
                            size: 30
                        },
                        {
                            xtype: 'container',
                            colspan: 6,
                            items: [
                                {
                                    xtype: 'gridpanel',
                                    height: 100,
                                    itemId: 'grdAssetIssue',
                                    width: 1200,
                                    autoScroll: true,
                                    title: '',
                                    store: 'AssetIssueGridStore',
                                    columns: [
                                        {
                                            xtype: 'gridcolumn',
                                            dataIndex: 'Sno',
                                            text: 'S No'
                                        },
                                        {
                                            xtype: 'gridcolumn',
                                            dataIndex: 'ToTranOfficeCode',
                                            text: 'Office Code',
                                            editor: {
                                                xtype: 'textfield',
                                                itemId: 'txtGrdOfficeCode'
                                            }
                                        },
                                        {
                                            xtype: 'gridcolumn',
                                            dataIndex: 'ToTranOfficeName',
                                            text: 'Office Name',
                                            editor: {
                                                xtype: 'textfield',
                                                itemId: 'txtGrdOfficeDesc'
                                            }
                                        },
                                        {
                                            xtype: 'gridcolumn',
                                            dataIndex: 'ToDeptCode',
                                            text: 'Dept Code',
                                            editor: {
                                                xtype: 'textfield',
                                                itemId: 'txtGrdDeptCode'
                                            }
                                        },
                                        {
                                            xtype: 'gridcolumn',
                                            dataIndex: 'ToDeptName',
                                            text: 'Dept Name',
                                            editor: {
                                                xtype: 'textfield',
                                                itemId: 'txtGrdDeptDesc'
                                            }
                                        },
                                        {
                                            xtype: 'gridcolumn',
                                            dataIndex: 'TranDateBs',
                                            text: 'Date BS',
                                            editor: {
                                                xtype: 'textfield',
                                                itemId: 'txtGrdDateBS'
                                            }
                                        },
                                        {
                                            xtype: 'gridcolumn',
                                            dataIndex: 'TranDate',
                                            text: 'Date AD',
                                            editor: {
                                                xtype: 'textfield',
                                                itemId: 'txtGrdDateAD'
                                            }
                                        },
                                        {
                                            xtype: 'gridcolumn',
                                            dataIndex: 'Uncalcdepr',
                                            text: 'UnCalc Depr',
                                            editor: {
                                                xtype: 'textfield',
                                                itemId: 'txtGrdUncalcDepr'
                                            }
                                        },
                                        {
                                            xtype: 'gridcolumn',
                                            dataIndex: 'CurrentValue',
                                            text: 'Current Value',
                                            editor: {
                                                xtype: 'textfield',
                                                itemId: 'txtGrdCurrentValue'
                                            }
                                        },
                                        {
                                            xtype: 'gridcolumn',
                                            dataIndex: 'Remarks',
                                            text: 'Remarks',
                                            editor: {
                                                xtype: 'textfield',
                                                itemId: 'txtGrdRemarks'
                                            }
                                        },
                                        {
                                            xtype: 'gridcolumn',
                                            dataIndex: 'DeprCalcYN',
                                            text: 'Depr Calc',
                                            editor: {
                                                xtype: 'checkboxfield',
                                                itemId: 'chkGrdDeprCalc'
                                            }
                                        },
                                        {
                                            xtype: 'gridcolumn',
                                            dataIndex: 'TransferYN',
                                            text: 'Trn',
                                            editor: {
                                                xtype: 'checkboxfield',
                                                itemId: 'chkGrdTrn'
                                            }
                                        }
                                    ],
                                    plugins: [
                                        Ext.create('Ext.grid.plugin.RowEditing', {
                                            pluginId: 'p1',
                                            triggerEvent: 'rowfocus',
                                            listeners: {
                                                validateedit: {
                                                    fn: me.onRowEditingValidateedit,
                                                    scope: me
                                                }
                                            }
                                        })
                                    ],
                                    selModel: Ext.create('Ext.selection.RowModel', {

                                    })
                                }
                            ]
                        },
                        {
                            xtype: 'container',
                            colspan: 6,
                            height: 28,
                            margin: '10 0 0 0',
                            layout: {
                                type: 'table',
                                columns: 1
                            },
                            items: [
                                {
                                    xtype: 'button',
                                    itemId: 'btnAddToGrid',
                                    text: 'Add',
                                    listeners: {
                                        click: {
                                            fn: me.onBtnAddToGridClick,
                                            scope: me
                                        }
                                    }
                                },
                                {
                                    xtype: 'combobox',
                                    itemId: 'ddlAssetGivenTo',
                                    fieldLabel: 'Asset Given To',
                                    fieldStyle: 'background-color:#DAEBE1;background-image:none;',
                                    displayField: 'EmpName',
                                    forceSelection: true,
                                    queryMode: 'local',
                                    store: 'AssetGivenToStore',
                                    valueField: 'EmpId'
                                }
                            ]
                        },
                        {
                            xtype: 'container',
                            colspan: 6,
                            height: 28,
                            layout: {
                                type: 'hbox',
                                align: 'stretch',
                                pack: 'center'
                            },
                            items: [
                                {
                                    xtype: 'button',
                                    itemId: 'btnSave',
                                    text: 'Save',
                                    listeners: {
                                        click: {
                                            fn: me.onBtnSaveClick,
                                            scope: me
                                        }
                                    }
                                }
                            ]
                        },
                        {
                            xtype: 'form',
                            colspan: 6,
                            frame: true,
                            bodyPadding: 10,
                            title: 'Destination',
                            layout: {
                                type: 'table',
                                columns: 2
                            },
                            items: [
                                {
                                    xtype: 'combobox',
                                    itemId: 'ddlDestinationFormat',
                                    fieldLabel: 'Destination Format',
                                    labelWidth: 120,
                                    emptyText: '---Select---',
                                    forceSelection: true,
                                    queryMode: 'local'
                                },
                                {
                                    xtype: 'combobox',
                                    itemId: 'ddlDestinationParameter',
                                    margin: '0 0 0 200',
                                    fieldLabel: 'Destination Parameter',
                                    labelWidth: 130,
                                    emptyText: '---Select---',
                                    forceSelection: true,
                                    queryMode: 'local'
                                },
                                {
                                    xtype: 'combobox',
                                    itemId: 'ddlDestinationType',
                                    fieldLabel: 'Destination Type',
                                    labelWidth: 120,
                                    emptyText: '---Select---',
                                    forceSelection: true,
                                    queryMode: 'local'
                                },
                                {
                                    xtype: 'checkboxfield',
                                    itemId: 'chkPrint',
                                    margin: '0 0 0 200',
                                    fieldLabel: 'Print',
                                    labelWidth: 130,
                                    boxLabel: ''
                                },
                                {
                                    xtype: 'container',
                                    colspan: 2,
                                    height: 28,
                                    margin: '10 0 0 0',
                                    layout: {
                                        type: 'hbox',
                                        align: 'stretch',
                                        pack: 'center'
                                    },
                                    items: [
                                        {
                                            xtype: 'button',
                                            itemId: 'btnOk',
                                            padding: 5,
                                            text: 'Ok'
                                        }
                                    ]
                                }
                            ]
                        }
                    ],
                    listeners: {
                        afterrender: {
                            fn: me.onFrmAssetIssueAfterRender,
                            scope: me
                        }
                    }
                }
            ]
        });

        me.callParent(arguments);
    },

    onDdlAssetChange: function(field, newValue, oldValue, eOpts) {
        //GET FOR ASSET GRID


        Ext.Ajax.request({
            url:'../Handlers/Inventory/Transaction/AssetSendReceiptDetailHandler.ashx',
            params:{method:'GetAssetSendReceiptDetail',AssetCode:newValue,
                    ReceiveSendDrop:'S',

                   },
            success: function ( result, request ) {

                var obj = Ext.decode(result.responseText);
                if(obj.success === 'true'){
                    //console.log("Resu",obj.root);
                    var store =Ext.getStore('AssetIssueGridStore');
                    store.removeAll();
                    store.add(obj.root);
                    var deptFill = obj.root[0].data;
                    Ext.ComponentQuery.query('#txtCurrentDeptCode')[0].setValue(deptFill.ToDeptCode);
                    Ext.ComponentQuery.query('#txtCurrentDeptDesc')[0].setValue(deptFill.ToDeptName);
                    Ext.ComponentQuery.query('#chkTransferred')[0].setValue(deptFill.TransferYN==='Y'?true:false);
                    //Ext.ComponentQuery.query('#chkGrdTrn')[0].setValue(deptFill.TransferYN==='Y'?true:false);
                    //Ext.ComponentQuery.query('#chkGrdDeprCalc')[0].setValue(deptFill.DeprCalcY_N==='Y'?true:false);



                }else{msg('FAILURE','Could Not Load Data');}
            },
            failure: function(form, action) {
                msg("FAILURE","Could Not Load Data");    }
        });

        //GET FOR ASSET GET
        var astCode ={
            TranOfficeCode:getOfficeCode(),
            AssetCode:newValue,//Ext.ComponentQuery.query('#ddlAsset')[0].AssetCode,
            CategoryCode:'',
            AssetCategory:'',
            Donar:'',
        };
        Ext.Ajax.request({
            url:'../Handlers/Inventory/Transaction/AssetDetailHandler.ashx',
            params:{method:'GetAssetDetail',assetDetail:JSON.stringify(astCode)


                   },
            success: function ( result, request ) {

                var obj = Ext.decode(result.responseText);
                if(obj.success === 'true'){
                    console.log("Resu",obj.root);
                    var store =Ext.getStore('AssetDetailStore');
                    store.removeAll();
                    store.add(obj.root);
                    var fillData = obj.root[0].data;

                    console.log(fillData);
                    Ext.ComponentQuery.query('#txtItemCode')[0].setValue(fillData.ItemCode);
                    Ext.ComponentQuery.query('#txtItemDesc')[0].setValue(fillData.ItemName);
                    Ext.ComponentQuery.query('#txtPurchasePrice')[0].setValue(fillData.PurchasePrice);
                    Ext.ComponentQuery.query('#txtDepriciationPer')[0].setValue(fillData.DepreciablePercentage);
                    Ext.ComponentQuery.query('#txtLastDepeDateAD')[0].setValue(fillData.CalcDeprFrom);
                    Ext.ComponentQuery.query('#txtLastDepeDateBS')[0].setValue(fillData.CalcDeprFrom_Bs);
                    Ext.ComponentQuery.query('#txtPurchaseDateAD')[0].setValue(fillData.DateAquired);
                    Ext.ComponentQuery.query('#txtPurchaseDateBS')[0].setValue(fillData.DateAquiredBs);
                    Ext.ComponentQuery.query('#txtCurrentValue')[0].setValue(fillData.CurrentValue);
                    Ext.ComponentQuery.query('#txtLastDeprAmt')[0].setValue(fillData.LastDeprAmt);
                    Ext.ComponentQuery.query('#txtTotalMaintenance')[0].setValue(fillData.TotalMaintenance);
                    Ext.ComponentQuery.query('#txtTotalDepr')[0].setValue(fillData.TotalDepreciation);
                    Ext.ComponentQuery.query('#txtCurrentOfficeCode')[0].setValue(fillData.TranOfficeCode);
                    Ext.ComponentQuery.query('#txtCurrentOfficeCode')[0].EmpId= fillData.EmpId;
                    //Ext.ComponentQuery.query('#txtCurrentOfficeDesc')[0].setValue(deptFill.ToTranOffice_Name);



                }else{msg('FAILURE','Could Not Load Data');}
            },
            failure: function(form, action) {
                msg("FAILURE","Could Not Load Data");    }
        });

        var assetIssueGridStore=Ext.getStore('AssetIssueGridStore');
        assetIssueGridStore.add({Action:'I'});
        //Ext.ComponentQuery.query('#grdAssetIssue')[0].getPlugin('p1').startEdit( 0, 0 ); ;

    },

    onRowEditingValidateedit: function(editor, e, eOpts) {

    },

    onBtnAddToGridClick: function(button, e, eOpts) {

    },

    onBtnSaveClick: function(button, e, eOpts) {
        var objAI={
        TranOfficeCode: getOfficeCode,
        AssetCode: Ext.ComponentQuery.query('#ddlAsset')[0].getValue(),
        ReceiveSendDrop: 'S',
        FromTranOffice_Code:Ext.ComponentQuery.query('#txtCurrentOfficeCode')[0].getValue(),
        ToTranOffice_Code: Ext.ComponentQuery.query('#txtGrdOfficeCode')[0].getValue(),
        FromDeptCode:'',// Ext.ComponentQuery.query('#')[0].getValue(),
        ToDeptCode: Ext.ComponentQuery.query('#txtGrdDeptCode')[0].getValue(),
        DeprCalcY_N: Ext.ComponentQuery.query('#chkGrdDeprCalc')[0].getValue()?'Y':'N',
        CurrentValue: Ext.ComponentQuery.query('#txtGrdCurrentValue')[0].getValue(),
        TranDate: Ext.ComponentQuery.query('#txtGrdDateAD')[0].getValue(),
        TranDateBs: Ext.ComponentQuery.query('#txtGrdDateBS')[0].getValue(),
        TransferYN: Ext.ComponentQuery.query('#chkTransferred')[0].getValue()?'Y':'N',
        Remarks: Ext.ComponentQuery.query('#txtGrdRemarks')[0].getValue(),
        Uncalcdepr: Ext.ComponentQuery.query('#txtGrdUncalcDepr')[0].getValue(),
        EmployeeId:  Ext.ComponentQuery.query('#ddlAssetGivenTo')[0].getValue(),
        Username: getCurrentUser(),
        InsertUpdate:'I',
        //OutSno: '',
        };
        var waitSave = watiMsg('Saving. Please wait ...');
        Ext.Ajax.request({
             url:'../Handlers/Inventory/Transaction/FaAssetSendReceiptHandler.ashx',
             params:{method:'SaveFaAssetSendReceipt',faAssetSendReceipt:JSON.stringify(objAI)},
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

    onFrmAssetIssueAfterRender: function(component, eOpts) {
        //GET FOR ASSET
        Ext.Ajax.request({
            url:'../Handlers/Inventory/Transaction/AssetHandler.ashx',
            params:{method:'GetAsset',AssetCode:null,
                    Category:null,
                    AssetDesc:null
                   },
            success: function ( result, request ) {

                var obj = Ext.decode(result.responseText);
                if(obj.success === 'true'){
                    //console.log("Resu",obj.root);
                    var store =Ext.getStore('AssetShortStore');
                    store.removeAll();
                    store.add(obj.root);


                }else{msg('FAILURE','Could Not Load Data');}
            },
            failure: function(form, action) {
                msg("FAILURE","Could Not Load Data");    }
        });

        //GET FOR Asset Given To

        Ext.Ajax.request({
            url:'../Handlers/Supervisor/EmployeeHandler.ashx',
            params:{method:'GetEmployee',OfficeName:null,
                    UserCode:getCurrentUser(),
                    EmpName:null
                   },
            success: function ( result, request ) {

                var obj = Ext.decode(result.responseText);
                if(obj.success === 'true'){
                    //console.log("Resu",obj.root);
                    var store =Ext.getStore('AssetGivenToStore');
                    store.removeAll();
                    store.add(obj.root);


                }else{msg('FAILURE','Could Not Load Data');}
            },
            failure: function(form, action) {
                msg("FAILURE","Could Not Load Data");    }
        });




    }

});