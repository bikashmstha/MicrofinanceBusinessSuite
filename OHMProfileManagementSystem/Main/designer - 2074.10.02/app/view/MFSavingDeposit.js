/*
 * File: app/view/MFSavingDeposit.js
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

Ext.define('MyApp.view.MFSavingDeposit', {
    extend: 'Ext.panel.Panel',

    requires: [
        'Ext.form.Panel',
        'Ext.form.field.ComboBox',
        'Ext.form.Label',
        'Ext.button.Button',
        'Ext.form.FieldSet',
        'Ext.grid.Panel',
        'Ext.grid.View',
        'Ext.grid.column.Column'
    ],

    frame: true,
    title: 'MF Saving Deposit',

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'form',
                    frame: true,
                    itemId: 'frmSavingDeposit',
                    bodyPadding: 10,
                    layout: {
                        type: 'table',
                        columns: 3
                    },
                    items: [
                        {
                            xtype: 'textfield',
                            colspan: 2,
                            itemId: 'txtDepositDateBS',
                            fieldLabel: 'Deposit Date (B.S)',
                            labelWidth: 140,
                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                        },
                        {
                            xtype: 'textfield',
                            itemId: 'txtDepositDateAD',
                            margin: '0 0 0 10',
                            fieldLabel: 'Deposit Date (A.D)',
                            labelWidth: 140,
                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                        },
                        {
                            xtype: 'combobox',
                            colspan: 3,
                            itemId: 'ddlSavingProduct',
                            fieldLabel: 'Saving Product',
                            labelWidth: 140,
                            fieldStyle: 'background-color:#DAEBE1;background-image:none;',
                            size: 30,
                            displayField: 'ProductName',
                            forceSelection: true,
                            queryMode: 'local',
                            store: 'SavingProductShortStore',
                            valueField: 'ProductCode'
                        },
                        {
                            xtype: 'combobox',
                            colspan: 3,
                            itemId: 'ddlCenter',
                            fieldLabel: 'Center',
                            labelWidth: 140,
                            fieldStyle: 'background-color:#DAEBE1;background-image:none;',
                            size: 30,
                            displayField: 'CenterName',
                            forceSelection: true,
                            queryMode: 'local',
                            store: 'CenterCodeStore',
                            valueField: 'CenterCode',
                            listeners: {
                                select: {
                                    fn: me.onDdlCenterSelect,
                                    scope: me
                                }
                            }
                        },
                        {
                            xtype: 'textfield',
                            colspan: 2,
                            itemId: 'txtSavingAccountNumber',
                            fieldLabel: 'Saving Account Number',
                            labelWidth: 140,
                            fieldStyle: 'background-color:#DAEBE1;background-image:none;',
                            size: 63,
                            listeners: {
                                afterrender: {
                                    fn: me.onTxtSavingAccountNumberAfterRender,
                                    scope: me
                                }
                            }
                        },
                        {
                            xtype: 'label'
                        },
                        {
                            xtype: 'textfield',
                            colspan: 3,
                            itemId: 'txtMemberName',
                            fieldLabel: 'Member Name',
                            labelWidth: 140,
                            fieldStyle: 'background-color:#D2D2D2;background-image:none;',
                            size: 63
                        },
                        {
                            xtype: 'combobox',
                            colspan: 3,
                            itemId: 'ddlEmpName',
                            fieldLabel: 'Emp Name',
                            labelWidth: 140,
                            fieldStyle: 'background-color:#DAEBE1;background-image:none;',
                            size: 30,
                            displayField: 'EmpName',
                            forceSelection: true,
                            queryMode: 'local',
                            store: 'EmployeeSearchShortStore',
                            valueField: 'EmpId'
                        },
                        {
                            xtype: 'combobox',
                            colspan: 3,
                            itemId: 'ddlContraAccount',
                            fieldLabel: 'Contra Account',
                            labelWidth: 140,
                            fieldStyle: 'background-color:#DAEBE1;background-image:none;',
                            size: 55,
                            displayField: 'AccountDesc',
                            forceSelection: true,
                            queryMode: 'local',
                            store: 'ContraAccountSearchShortStore',
                            valueField: 'AccountCode'
                        },
                        {
                            xtype: 'textfield',
                            colspan: 3,
                            itemId: 'txtRemarks',
                            fieldLabel: 'Remarks',
                            labelWidth: 140,
                            size: 63
                        },
                        {
                            xtype: 'textfield',
                            colspan: 2,
                            itemId: 'txtDepositorName',
                            fieldLabel: 'Depositor Name',
                            labelWidth: 140,
                            size: 63
                        },
                        {
                            xtype: 'combobox',
                            colspan: 2,
                            itemId: 'txtMandatorySavingType',
                            margin: '0 0 0 10',
                            fieldLabel: 'Mandatory Saving Type',
                            labelWidth: 140,
                            emptyText: '---SELECT---',
                            size: 30,
                            displayField: 'RefDtlName',
                            forceSelection: true,
                            queryMode: 'local',
                            store: 'ReferenceShortStore',
                            valueField: 'RefDtlCode'
                        },
                        {
                            xtype: 'textfield',
                            colspan: 2,
                            itemId: 'txtPresentBal',
                            fieldLabel: 'Present Bal.',
                            labelWidth: 140,
                            fieldStyle: 'background-color:#D2D2D2;background-image:none;',
                            size: 30
                        },
                        {
                            xtype: 'textfield',
                            itemId: 'txtPenaltyAmt',
                            margin: '0 0 0 10',
                            fieldLabel: 'Penalty Amt',
                            labelWidth: 140,
                            size: 30
                        },
                        {
                            xtype: 'textfield',
                            colspan: 2,
                            itemId: 'txtCurrentAmountDue',
                            fieldLabel: 'Current Amount Due',
                            labelWidth: 140,
                            fieldStyle: 'background-color:#D2D2D2;background-image:none;',
                            size: 30
                        },
                        {
                            xtype: 'textfield',
                            itemId: 'txtPenaltyCal',
                            margin: '0 0 0 10',
                            fieldLabel: 'Penalty Cal. (%)',
                            labelWidth: 140,
                            fieldStyle: 'background-color:#D2D2D2;background-image:none;',
                            size: 30
                        },
                        {
                            xtype: 'textfield',
                            colspan: 2,
                            itemId: 'txtAmountRecevied',
                            fieldLabel: 'Amount Received ',
                            labelWidth: 140,
                            size: 30
                        },
                        {
                            xtype: 'textfield',
                            itemId: 'txtFixedAmountDue',
                            margin: '0 0 0 10',
                            fieldLabel: 'Fixed Amount Due',
                            labelWidth: 140,
                            fieldStyle: 'background-color:#D2D2D2;background-image:none;',
                            size: 30
                        },
                        {
                            xtype: 'container',
                            colspan: 3,
                            height: 25,
                            layout: {
                                type: 'hbox',
                                align: 'stretch',
                                pack: 'center'
                            },
                            items: [
                                {
                                    xtype: 'button',
                                    itemId: 'btnDeposit',
                                    text: 'Deposit',
                                    listeners: {
                                        click: {
                                            fn: me.onBtnDepositClick,
                                            scope: me
                                        }
                                    }
                                },
                                {
                                    xtype: 'button',
                                    margins: '0 0 0 5',
                                    itemId: 'btnUpdate',
                                    text: 'Update',
                                    listeners: {
                                        click: {
                                            fn: me.onBtnUpdateClick,
                                            scope: me
                                        }
                                    }
                                },
                                {
                                    xtype: 'button',
                                    margins: '0 0 0 5',
                                    itemId: 'btnDelete',
                                    text: 'Delete',
                                    listeners: {
                                        click: {
                                            fn: me.onBtnDeleteClick,
                                            scope: me
                                        }
                                    }
                                }
                            ]
                        },
                        {
                            xtype: 'container',
                            colspan: 3,
                            height: 25,
                            margin: '10 0 0 0',
                            layout: {
                                type: 'hbox',
                                align: 'stretch',
                                pack: 'center'
                            },
                            items: [
                                {
                                    xtype: 'button',
                                    itemId: 'btnGotoSavingWithdraw',
                                    text: 'Goto Saving Withdraw'
                                }
                            ]
                        },
                        {
                            xtype: 'fieldset',
                            colspan: 3,
                            title: 'My Fields',
                            layout: {
                                type: 'table',
                                columns: 2
                            },
                            items: [
                                {
                                    xtype: 'textfield',
                                    itemId: 'txtSearchDepositFromDateBS',
                                    fieldLabel: 'Deposit From Date (B.S)',
                                    labelWidth: 140
                                },
                                {
                                    xtype: 'textfield',
                                    itemId: 'txtSearchDepositToDateBS',
                                    margin: '0 0 0 5',
                                    fieldLabel: 'Deposit To Date (B.S)',
                                    labelWidth: 140
                                },
                                {
                                    xtype: 'combobox',
                                    itemId: 'txtSearchSavingAccountNumber',
                                    fieldLabel: 'Saving Account No.',
                                    labelWidth: 140,
                                    fieldStyle: 'background-color:#DAEBE1;background-image:none;',
                                    size: 40,
                                    displayField: 'SavingAccountNo',
                                    forceSelection: true,
                                    queryMode: 'local',
                                    store: 'SavingAccountNumberSearchStore',
                                    valueField: 'SavingAccountNo',
                                    listeners: {
                                        focus: {
                                            fn: me.onTxtSearchSavingAccountNumberFocus,
                                            scope: me
                                        },
                                        select: {
                                            fn: me.onTxtSearchSavingAccountNumberSelect,
                                            scope: me
                                        }
                                    }
                                },
                                {
                                    xtype: 'textfield',
                                    itemId: 'txtSearchMemberName',
                                    margin: '0 0 0 5.',
                                    fieldLabel: 'Member Name',
                                    labelWidth: 140,
                                    size: 40
                                },
                                {
                                    xtype: 'container',
                                    colspan: 2,
                                    height: 25,
                                    layout: {
                                        type: 'hbox',
                                        align: 'stretch',
                                        pack: 'center'
                                    },
                                    items: [
                                        {
                                            xtype: 'button',
                                            text: 'Search',
                                            listeners: {
                                                click: {
                                                    fn: me.onButtonClick,
                                                    scope: me
                                                }
                                            }
                                        }
                                    ]
                                }
                            ]
                        },
                        {
                            xtype: 'gridpanel',
                            colspan: 3,
                            itemId: 'grdSavingDepositDetail',
                            store: 'SavingAccountDepositDetailStore',
                            columns: [
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'DepositNo',
                                    text: 'DepositNo'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'SavingAccountNo',
                                    text: 'SavingAccountNo'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'ClientName',
                                    text: 'ClientName'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'DepositAmount',
                                    text: 'DepositAmount'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'CurrentBalance',
                                    text: 'CurrentBalance'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'DepositDate',
                                    text: 'DepositDate'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'VoucherNo',
                                    text: 'VoucherNo'
                                }
                            ]
                        },
                        {
                            xtype: 'textfield',
                            hidden: true,
                            itemId: 'hdnAccountNumber',
                            fieldLabel: 'Label'
                        }
                    ],
                    listeners: {
                        afterrender: {
                            fn: me.onFormAfterRender,
                            scope: me
                        }
                    }
                }
            ]
        });

        me.callParent(arguments);
    },

    onDdlCenterSelect: function(combo, records, eOpts) {
        Ext.ComponentQuery.query('#ddlEmpName')[0].setValue(records[0].data.EmployeeId);

    },

    onTxtSavingAccountNumberAfterRender: function(component, eOpts) {
        component.getEl().on('dblclick', function(){
             var winPopup = Ext.create('MyApp.view.SelectSavingDepositAccountNumberPopup',{

                });

                winPopup.extraParam={param:null};
                winPopup.show();
          });
    },

    onBtnDepositClick: function(button, e, eOpts) {
        var savingAccountDepositObj={
        AccountNo:Ext.ComponentQuery.query('#hdnAccountNumber')[0].getValue(),
        DepositDate:Ext.ComponentQuery.query('#txtDepositDateAD')[0].getValue(),
        DepositAmount:Ext.ComponentQuery.query('#txtAmountRecevied')[0].getValue(),
        ContraAccount:Ext.ComponentQuery.query('#ddlContraAccount')[0].getValue(),
        MandatorySavingType:Ext.ComponentQuery.query('#txtMandatorySavingType')[0].getValue(),
        VoucherNo:null,
        EmpId:Ext.ComponentQuery.query('#ddlEmpName')[0].getValue(),
        Remarks:Ext.ComponentQuery.query('#txtRemarks')[0].getValue(),
        TranOfficeCode:getOfficeCode(),
        CreatedBy:getCurrentUser(),
        DepositBy:Ext.ComponentQuery.query('#txtDepositorName')[0].getValue(),
        Action:'I'
        };


        var waitSave = watiMsg("Depositing..Please wait ...");
        Ext.Ajax.request({
            url: '../Handlers/Finance/Transaction/SavingTransaction/MfSavingDepositHandler.ashx',
            params: {
                method:'Save',
                mfSavingDeposit:JSON.stringify(savingAccountDepositObj)
            },
            success: function ( response, request ) {
                         waitSave.hide();
                            var out=Ext.decode(response.responseText);
                            console.log(out);

                            if(out.success==="true")
                                {
                                   msg("SUCCESS",out.message);
        						   //var compulsoryAccountCode = out.root[0].CompulsoryAccountCode;
                    //Ext.ComponentQuery.query('#txtSymbolNo')[0].setValue(compulsoryAccountCode);
                              }
                                else
                                    {
                                        msg("FAILURE",out.message);
                                    }
                            },
                            failure: function ( result, request ) {
                                waitSave.hide();
                                var out=Ext.decode(response.responseText);
                                msg("FAILURE",out.message);
                            }

                });

    },

    onBtnUpdateClick: function(button, e, eOpts) {
        var savingAccountDepositObj={
        AccountNo:Ext.ComponentQuery.query('#hdnAccountNumber')[0].getValue(),
        DepositDate:Ext.ComponentQuery.query('#txtDepositDateAD')[0].getValue(),
        DepositAmount:Ext.ComponentQuery.query('#txtAmountRecevied')[0].getValue(),
        ContraAccount:Ext.ComponentQuery.query('#ddlContraAccount')[0].getValue(),
        MandatorySavingType:Ext.ComponentQuery.query('#txtMandatorySavingType')[0].getValue(),
        VoucherNo:null,
        EmpId:Ext.ComponentQuery.query('#ddlEmpName')[0].getValue(),
        Remarks:Ext.ComponentQuery.query('#txtRemarks')[0].getValue(),
        TranOfficeCode:getOfficeCode(),
        CreatedBy:getCurrentUser(),
        DepositBy:Ext.ComponentQuery.query('#txtDepositorName')[0].getValue(),
        Action:'U'
        };


        var waitSave = watiMsg("Depositing..Please wait ...");
        Ext.Ajax.request({
            url: '../Handlers/Finance/Transaction/SavingTransaction/MfSavingDepositHandler.ashx',
            params: {
                method:'Save',
                mfSavingDeposit:JSON.stringify(savingAccountDepositObj)
            },
            success: function ( response, request ) {
                         waitSave.hide();
                            var out=Ext.decode(response.responseText);
                            console.log(out);

                            if(out.success==="true")
                                {
                                   msg("SUCCESS",out.message);
        						   //var compulsoryAccountCode = out.root[0].CompulsoryAccountCode;
                    //Ext.ComponentQuery.query('#txtSymbolNo')[0].setValue(compulsoryAccountCode);
                              }
                                else
                                    {
                                        msg("FAILURE",out.message);
                                    }
                            },
                            failure: function ( result, request ) {
                                waitSave.hide();
                                var out=Ext.decode(response.responseText);
                                msg("FAILURE",out.message);
                            }

                });
    },

    onBtnDeleteClick: function(button, e, eOpts) {
        var savingAccountDepositObj={
        AccountNo:Ext.ComponentQuery.query('#hdnAccountNumber')[0].getValue(),
        DepositDate:Ext.ComponentQuery.query('#txtDepositDateAD')[0].getValue(),
        DepositAmount:Ext.ComponentQuery.query('#txtAmountRecevied')[0].getValue(),
        ContraAccount:Ext.ComponentQuery.query('#ddlContraAccount')[0].getValue(),
        MandatorySavingType:Ext.ComponentQuery.query('#txtMandatorySavingType')[0].getValue(),
        VoucherNo:null,
        EmpId:Ext.ComponentQuery.query('#ddlEmpName')[0].getValue(),
        Remarks:Ext.ComponentQuery.query('#txtRemarks')[0].getValue(),
        TranOfficeCode:getOfficeCode(),
        CreatedBy:getCurrentUser(),
        DepositBy:Ext.ComponentQuery.query('#txtDepositorName')[0].getValue(),
        Action:'D'
        };


        var waitSave = watiMsg("Depositing..Please wait ...");
        Ext.Ajax.request({
            url: '../Handlers/Finance/Transaction/SavingTransaction/MfSavingDepositHandler.ashx',
            params: {
                method:'Save',
                mfSavingDeposit:JSON.stringify(savingAccountDepositObj)
            },
            success: function ( response, request ) {
                         waitSave.hide();
                            var out=Ext.decode(response.responseText);
                            console.log(out);

                            if(out.success==="true")
                                {
                                   msg("SUCCESS",out.message);
        						   //var compulsoryAccountCode = out.root[0].CompulsoryAccountCode;
                    //Ext.ComponentQuery.query('#txtSymbolNo')[0].setValue(compulsoryAccountCode);
                              }
                                else
                                    {
                                        msg("FAILURE",out.message);
                                    }
                            },
                            failure: function ( result, request ) {
                                waitSave.hide();
                                var out=Ext.decode(response.responseText);
                                msg("FAILURE",out.message);
                            }

                });
    },

    onTxtSearchSavingAccountNumberFocus: function(component, e, eOpts) {
        Ext.Ajax.request({
            url: '../Handlers/Finance/Transaction/SavingTransaction/ClientSavingAccountHandler.ashx',
            params: {
                method:'GetMemberAccountOpen',
                offCode:getOfficeCode(),
                memberName:null
            },
            success: function(response){


                var obj = Ext.decode(response.responseText);



                if(obj.success === "true")
                {

                    var store=Ext.getStore('SavingAccountNumberSearchStore');
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

    onTxtSearchSavingAccountNumberSelect: function(combo, records, eOpts) {
        Ext.ComponentQuery.query('#txtSearchMemberName')[0].setValue(records[0].data.ClientName);

    },

    onButtonClick: function(button, e, eOpts) {
        var accountDepositDateFromBS=Ext.ComponentQuery.query('#txtSearchDepositFromDateBS')[0].getValue();
        var accountDepositDateToBS=Ext.ComponentQuery.query('#txtSearchDepositToDateBS')[0].getValue();
        var savingAccountNo=Ext.ComponentQuery.query('#txtSearchSavingAccountNumber')[0].getValue();
        var memberName=Ext.ComponentQuery.query('#txtSearchMemberName')[0].getValue();


        Ext.Ajax.request({
            url: '../Handlers/Finance/Transaction/SavingTransaction/MfDepositDetailHandler.ashx',
            params: {
                method:'GetMfDepositDetail',
                offCode:getOfficeCode(),
                depositNo:null,
                savingAccountNo:savingAccountNo,
                clientName:memberName,
                fromDate:null,
                toDate:null,


            },
            success: function(response){


        var obj = Ext.decode(response.responseText);

                                console.log('resp',response);



              if(obj.success === "true")
                        {

                            var store=Ext.getStore('SavingAccountDepositDetailStore');
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

    onFormAfterRender: function(component, eOpts) {

        Ext.ComponentQuery.query('#txtDepositDateBS')[0].setValue(getMisDateBS());
        Ext.ComponentQuery.query('#txtDepositDateAD')[0].setValue(getMisDateAD());
        Ext.ComponentQuery.query('#txtSearchDepositFromDateBS')[0].setValue(getMisDateBS());
        Ext.ComponentQuery.query('#txtSearchDepositToDateBS')[0].setValue(getMisDateBS());

        Ext.Ajax.request({
            url: '../Handlers/Finance/Transaction/SavingTransaction/ProductForDepositHandler.ashx',
            params: {
                method:'GetProductForDeposit',
                productName:null,

            },
            success: function(response){


                var obj = Ext.decode(response.responseText);



                if(obj.success === "true")
                {

                    var store=Ext.getStore('SavingProductShortStore');
                    store.removeAll();
                    store.add(obj.root);

                }
                else
                {
                    msg("FAILURE",obj.message);
                }
            }
        });


        var centerObj={
            InstituteCode:Ext.get('offCode').dom.innerHTML,
            CenterCode:null

        };
        Ext.Ajax.request({
            url: '../Handlers/Finance/Maintenance/CenterLovHandler.ashx',
            params: {
                method:'Search',
                centerlov:JSON.stringify(centerObj)

            },
            success: function(response){


                var obj = Ext.decode(response.responseText);



                if(obj.success === "true")
                {

                    var store=Ext.getStore('CenterCodeStore');
                    store.removeAll();
                    store.add(obj.root);



                }
                else
                {
                    msg("FAILURE",obj.message);
                }
            }
        });

        Ext.Ajax.request({
            url: '../Handlers/Supervisor/EmployeeHandler.ashx',
            params: {
                method:'GetFieldAssistants',
                officeCode:Ext.get('offCode').dom.innerHTML,
                empName:null,

            },
            success: function(response){


                var obj = Ext.decode(response.responseText);



                if(obj.success === "true")
                {

                    var store=Ext.getStore('EmployeeSearchShortStore');
                    store.removeAll();
                    store.add(obj.root);


                }
                else
                {
                    msg("FAILURE",obj.message);
                }
            }
        });

        Ext.Ajax.request({
            url: '../Handlers/Finance/Maintenance/AccountHeadEntryHandler.ashx',
            params: {
                method:'GetContraAccount',
                offCode:Ext.get('offCode').dom.innerHTML,
                accountDesc:null,

            },
            success: function(response){


                var obj = Ext.decode(response.responseText);



                if(obj.success === "true")
                {

                    var store=Ext.getStore('ContraAccountSearchShortStore');
                    store.removeAll();
                    store.add(obj.root);
                    Ext.ComponentQuery.query('#ddlContraAccount')[0].select('100000021000002');




                }
                else
                {
                    msg("FAILURE",obj.message);
                }
            }
        });


        Ext.Ajax.request({
            url: '../Handlers/GeneralMasterParameters/References/MsRefrenceCodeDetailsHandler.ashx',
            params: {
                method:'GetReferenceDetailListShort',
                referenceCode:'MANDATORY_SAVING_TYPE',

            },
            success: function(response){


                var obj = Ext.decode(response.responseText);



                if(obj.success === "true")
                {

                    var store=Ext.getStore('ReferenceShortStore');
                    store.removeAll();
                    store.add(obj.root);


                }
                else
                {
                    msg("FAILURE",obj.message);
                }
            }
        });


    }

});