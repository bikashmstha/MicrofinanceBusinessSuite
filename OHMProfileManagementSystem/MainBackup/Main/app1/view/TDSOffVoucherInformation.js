/*
 * File: app/view/TDSOffVoucherInformation.js
 *
 * This file was generated by Sencha Architect version 2.2.3.
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

Ext.define('MyApp.view.TDSOffVoucherInformation', {
    extend: 'Ext.panel.Panel',

    frame: true,
    autoScroll: true,
    title: 'Voucher Information',

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'container',
                    height: 60,
                    margin: '10 0 0 0',
                    layout: {
                        align: 'stretch',
                        type: 'hbox'
                    },
                    items: [
                        {
                            xtype: 'displayfield',
                            id: 'dpfOffVITDSTran',
                            itemId: 'dpfOffVITDSTran',
                            maxHeight: 25,
                            style: '{font-weight:bold;}',
                            width: 243,
                            fieldLabel: 'Transaction Number',
                            labelWidth: 130
                        },
                        {
                            xtype: 'displayfield',
                            id: 'dpfOffVITDSWithPan',
                            itemId: 'dpfOffVITDSWithPan',
                            maxHeight: 25,
                            style: '{font-weight:bold;}',
                            width: 260,
                            fieldLabel: 'Witholder PAN Number',
                            labelWidth: 150
                        },
                        {
                            xtype: 'displayfield',
                            id: 'dpfOffVITDSWithName',
                            itemId: 'dpfOffVITDSWithName',
                            maxHeight: 25,
                            style: '{font-weight:bold;}',
                            width: 300,
                            fieldLabel: 'Witholder Name',
                            labelWidth: 110
                        },
                        {
                            xtype: 'label',
                            margin: '2 0 0 50',
                            maxHeight: 20,
                            style: '{font-weight:bold;}',
                            text: 'TDS Collection Period :'
                        },
                        {
                            xtype: 'displayfield',
                            id: 'dpfOffVITDSFrom',
                            itemId: 'dpfOffVITDSFrom',
                            margin: '0 0 0 5',
                            maxHeight: 25,
                            fieldLabel: 'From',
                            labelWidth: 40,
                            value: 'Display Field'
                        },
                        {
                            xtype: 'displayfield',
                            margins: '0 0 0 5',
                            id: 'dpfOffVITDSTo',
                            itemId: 'dpfOffVITDSTo',
                            maxHeight: 25,
                            fieldLabel: 'To',
                            labelWidth: 35,
                            value: 'Display Field'
                        },
                        {
                            xtype: 'displayfield',
                            id: 'dpfOffVITDSType',
                            itemId: 'dpfOffVITDSType',
                            maxHeight: 25,
                            style: '{font-weight:bold;}',
                            labelWidth: 50,
                            value: 'Display Field'
                        }
                    ]
                },
                {
                    xtype: 'form',
                    frame: true,
                    hidden: true,
                    id: 'frmOffVITDSValid',
                    itemId: 'frmOffVITDSValid',
                    margin: '0 110 0 10',
                    bodyPadding: 10,
                    items: [
                        {
                            xtype: 'container',
                            height: 40,
                            layout: {
                                align: 'stretch',
                                type: 'hbox'
                            },
                            items: [
                                {
                                    xtype: 'label',
                                    id: 'lblOffVITDSAcc',
                                    itemId: 'lblOffVITDSAcc',
                                    text: 'Account'
                                },
                                {
                                    xtype: 'label',
                                    id: 'lblOffVITDSVouchNo',
                                    itemId: 'lblOffVITDSVouchNo',
                                    margin: '0 0 0 30',
                                    text: 'Voucher No.'
                                },
                                {
                                    xtype: 'label',
                                    flex: 1,
                                    id: 'lblOffVITDSPayMode',
                                    itemId: 'lblOffVITDSPayMode',
                                    margin: '0 0 0 15',
                                    maxWidth: 90,
                                    text: 'Payment Mode'
                                },
                                {
                                    xtype: 'label',
                                    height: 19,
                                    id: 'lblOffVITDSPayDate',
                                    itemId: 'lblOffVITDSPayDate',
                                    margin: '0 0 0 5',
                                    maxWidth: 100,
                                    text: 'Payment Date(BS)'
                                },
                                {
                                    xtype: 'label',
                                    id: 'lblOffVITDSCashCode',
                                    itemId: 'lblOffVITDSCashCode',
                                    margin: '0 0 0 20',
                                    text: 'IRD Code'
                                },
                                {
                                    xtype: 'label',
                                    id: 'lblOffVITDSBankCode',
                                    itemId: 'lblOffVITDSBankCode',
                                    margin: '0 0 0 20',
                                    text: 'Bank Code'
                                },
                                {
                                    xtype: 'label',
                                    id: 'lblOffVITDSBranchCode',
                                    itemId: 'lblOffVITDSBranchCode',
                                    margin: '0 0 0 80',
                                    text: 'Branch Code'
                                },
                                {
                                    xtype: 'label',
                                    id: 'lblOffVITDSAmt',
                                    itemId: 'lblOffVITDSAmt',
                                    margin: '0 0 0 15',
                                    text: 'TDS Amount'
                                }
                            ]
                        },
                        {
                            xtype: 'container',
                            height: 27,
                            layout: {
                                align: 'stretch',
                                type: 'hbox'
                            },
                            items: [
                                {
                                    xtype: 'combobox',
                                    flex: 1,
                                    id: 'cboOffVITDSAccNo',
                                    itemId: 'cboOffVITDSAccNo',
                                    maxWidth: 100,
                                    displayField: 'Acct',
                                    queryMode: 'local',
                                    store: 'TDSAccount',
                                    valueField: 'Acct'
                                },
                                {
                                    xtype: 'textfield',
                                    id: 'txtOffVITDSVouchNo',
                                    itemId: 'txtOffVITDSVouchNo',
                                    width: 92
                                },
                                {
                                    xtype: 'combobox',
                                    id: 'cboOffVITDSPayMode',
                                    itemId: 'cboOffVITDSPayMode',
                                    width: 106,
                                    allowBlank: false,
                                    displayField: 'PayMode',
                                    queryMode: 'local',
                                    store: 'TDSPayMode',
                                    valueField: 'PayMode'
                                },
                                {
                                    xtype: 'textfield',
                                    id: 'txtOffVITDSPayDate',
                                    itemId: 'txtOffVITDSPayDate',
                                    width: 101,
                                    allowBlank: false
                                },
                                {
                                    xtype: 'combobox',
                                    id: 'cboOffVITDSIRDCode',
                                    itemId: 'cboOffVITDSIRDCode',
                                    width: 250,
                                    allowBlank: false,
                                    emptyText: '----Select TDS Type----',
                                    enableKeyEvents: true,
                                    displayField: 'OfficeNameEnglish',
                                    queryMode: 'local',
                                    store: 'IROName',
                                    valueField: 'OfficeCode'
                                },
                                {
                                    xtype: 'combobox',
                                    id: 'cboOffVITDSBankCode',
                                    itemId: 'cboOffVITDSBankCode',
                                    width: 250,
                                    allowBlank: false,
                                    emptyText: '----Select TDS Type----',
                                    enableKeyEvents: true,
                                    queryMode: 'local'
                                },
                                {
                                    xtype: 'textfield',
                                    id: 'txtOffVITDSBranchCode',
                                    itemId: 'txtOffVITDSBranchCode',
                                    width: 107,
                                    allowBlank: false
                                },
                                {
                                    xtype: 'textfield',
                                    id: 'txtOffVITDSAmt',
                                    itemId: 'txtOffVITDSAmt',
                                    width: 106,
                                    allowBlank: false
                                }
                            ]
                        }
                    ]
                },
                {
                    xtype: 'container',
                    height: 26,
                    margin: '5 0 0 10',
                    layout: {
                        align: 'stretch',
                        type: 'hbox'
                    },
                    items: [
                        {
                            xtype: 'toolbar',
                            flex: 1,
                            margin: '0 100 0 0',
                            items: [
                                {
                                    xtype: 'tbseparator'
                                },
                                {
                                    xtype: 'tbseparator'
                                },
                                {
                                    xtype: 'button',
                                    id: 'btnOffVITDSTranInfo',
                                    itemId: 'btnOffVITDSTranInfo',
                                    maxWidth: 200,
                                    text: 'Go to Transaction Information'
                                },
                                {
                                    xtype: 'tbseparator'
                                },
                                {
                                    xtype: 'tbseparator'
                                },
                                {
                                    xtype: 'button',
                                    id: 'btnOffVITDSPrint',
                                    itemId: 'btnOffVITDSPrint',
                                    maxWidth: 80,
                                    text: 'Print Preview'
                                },
                                {
                                    xtype: 'tbseparator'
                                },
                                {
                                    xtype: 'tbseparator'
                                }
                            ]
                        }
                    ]
                },
                {
                    xtype: 'gridpanel',
                    height: 300,
                    id: 'grdOffVITDSVouchList',
                    itemId: 'grdOffVITDSVouchList',
                    margin: '0 200 0 10',
                    autoScroll: true,
                    title: 'List of Voucher Information',
                    store: 'TDSVouchInfo',
                    viewConfig: {
                        height: 280
                    },
                    columns: [
                        {
                            xtype: 'gridcolumn',
                            width: 120,
                            dataIndex: 'TrAcctNo',
                            text: 'Account '
                        },
                        {
                            xtype: 'gridcolumn',
                            width: 120,
                            dataIndex: 'VouchNo',
                            text: 'Voucher No'
                        },
                        {
                            xtype: 'gridcolumn',
                            width: 120,
                            dataIndex: 'PayMode',
                            text: 'Payment Mode'
                        },
                        {
                            xtype: 'gridcolumn',
                            width: 120,
                            dataIndex: 'PayDate',
                            text: 'Payment Date'
                        },
                        {
                            xtype: 'gridcolumn',
                            width: 120,
                            dataIndex: 'BankCode',
                            text: 'Bank Code'
                        },
                        {
                            xtype: 'gridcolumn',
                            width: 120,
                            dataIndex: 'BranchCode',
                            text: 'Branch Code'
                        },
                        {
                            xtype: 'gridcolumn',
                            width: 120,
                            dataIndex: 'Amt',
                            text: 'Amt'
                        },
                        {
                            xtype: 'gridcolumn',
                            width: 120,
                            dataIndex: 'NonTDSAmt',
                            text: 'NonTDSAmt'
                        },
                        {
                            xtype: 'actioncolumn',
                            width: 200,
                            items: [
                                {
                                    handler: function(view, rowIndex, colIndex, item, e) {
                                        var cboAcc = Ext.ComponentQuery.query("#cboOffVITDSAccNo")[0];
                                        var txtVouch = Ext.ComponentQuery.query("#txtOffVITDSVouchNo")[0];
                                        var cboPayMode = Ext.ComponentQuery.query("#cboOffVITDSPayMode")[0];
                                        var txtPayDate = Ext.ComponentQuery.query("#txtOffVITDSPayDate")[0];
                                        var cboCashCode = Ext.ComponentQuery.query("#cboOffVITDSIRDCode")[0];
                                        var cboBankCode = Ext.ComponentQuery.query("#cboOffVITDSBankCode")[0];
                                        var txtBranchCode = Ext.ComponentQuery.query("#txtOffVITDSBranchCode")[0];
                                        var txtAmt = Ext.ComponentQuery.query("#txtOffVITDSAmt")[0];

                                        var store = Ext.getStore('TDSVouchInfo');
                                        var grid =  Ext.ComponentQuery.query("#grdOffVITDSVouchList")[0];
                                        var row = store.getAt(rowIndex).data;

                                        cboAcc.setValue(row.TrAcctNo);
                                        txtVouch.setValue(row.VouchNo);
                                        cboPayMode.setValue(row.PayMode);
                                        txtPayDate.setValue(row.PayDate);
                                        cboCashCode.setValue(row.BankCode);
                                        cboBankCode.setValue(row.BankCode);
                                        txtBranchCode.setValue(row.BranchCode);
                                        txtAmt.setValue(row.Amt);

                                        var hdnAction = Ext.ComponentQuery.query("#hdnOffVITDSAction")[0];
                                        hdnAction.setValue("E");
                                        var btnAdd = Ext.ComponentQuery.query("#btnOffVITDSAdd")[0];
                                        btnAdd.setText('Edit');

                                    },
                                    icon: '../ITS/resources/images/icons/pencil.png'
                                },
                                {
                                    handler: function(view, rowIndex, colIndex, item, e) {
                                        /*var store = Ext.getStore('TDSVouchInfo');
                                        var grid =  Ext.ComponentQuery.query("#grdVITDSVouchList")[0];
                                        var row = store.getAt(rowIndex).data;
                                        //var dpfTran = Ext.ComponentQuery.query("#dpfVITDSTran")[0].getValue();

                                        Ext.Msg.confirm('Confirm Action', 'Do you want to Remove ?', function(btn) {
                                            if(btn == 'yes'){

                                                var param = {
                                                    TranNo:row.TranNo,
                                                    VouchNo:row.VouchNo,
                                                    BankCode:row.BankCode,
                                                    BranchCode:row.BranchCode,
                                                    PayMode:row.PayMode,
                                                    Amt:row.Amt,
                                                    PayDate:row.PayDate,
                                                    DateType:row.DateType,
                                                    TrAcctNo:row.TrAcctNo,
                                                    EnteredDate:row.EnteredDate,
                                                    EnteredBy:row.EnteredBy,
                                                    NonTDSAmt:row.NonTDSAmt,
                                                    RecStatus:"D",
                                                    Action:"E"
                                                };

                                                Ext.Ajax.request({
                                                    url:"../Handlers/TDS/VoucherInformationHandler.ashx?method=SaveVouchInfo",
                                                    params:{objVouch:JSON.stringify(param)},
                                                    success: function ( result, request ){

                                                        //waitSave.hide();

                                                        var obj = Ext.decode(result.responseText);
                                                        var tran = Ext.ComponentQuery.query("#dpfVITDSTran")[0].getValue();
                                                        console.log("gettran",tran);
                                                        var store = Ext.getStore('TDSVouchInfo');
                                                        var hdnAction = Ext.ComponentQuery.query("#hdnVITDSAction")[0];

                                                        if(obj.success === "true")
                                                        {
                                                            msg("SUCCESS",obj.message);

                                                            hdnAction.setValue('');

                                                            store.removeAt(rowIndex);

                                                            /*var len = store.count();
                                                            if(len===0)
                                                            {
                                                            var btnInsVouch = Ext.ComponentQuery.query("#btnIRPTDSInsertVoucher")[0];
                                                            //var btnAdd = Ext.ComponentQuery.query("#btnIRPTDSAdd")[0];
                                                            //   btnAdd.setText('Add');
                                                            btnInsVouch.setDisabled(true);
                                                        }*/

                                                        /*}
                                                        else if(obj.success === "false") 
                                                        {
                                                        msg("FAILURE",obj.message);
                                                        return;
                                                        }

                                                        },

                                                        failure: function ( result, request ){

                                                        return;
                                                        }

                                                        });

                                                        return true;
                                                        }
                                                        }, this);
                                                        */
                                    },
                                    icon: '../ITS/resources/images/icons/cancel.png'
                                }
                            ]
                        }
                    ]
                },
                {
                    xtype: 'container',
                    margin: '0 0 0 10',
                    items: [
                        {
                            xtype: 'button',
                            id: 'btnOffVITDSVerify',
                            itemId: 'btnOffVITDSVerify',
                            width: 120,
                            text: 'Verify Records'
                        }
                    ]
                },
                {
                    xtype: 'hiddenfield',
                    id: 'hdnOffVITDSAction',
                    itemId: 'hdnOffVITDSAction',
                    fieldLabel: 'Label'
                },
                {
                    xtype: 'hiddenfield',
                    id: 'hdnOffVITDSVal',
                    itemId: 'hdnOffVITDSVal',
                    fieldLabel: 'Label'
                },
                {
                    xtype: 'hiddenfield',
                    id: 'hdnOffVITDSvdate',
                    itemId: 'hdnOffVITDSvdate',
                    fieldLabel: 'Label'
                },
                {
                    xtype: 'hiddenfield',
                    id: 'hdnOffVITDSuser',
                    itemId: 'hdnOffVITDSuser',
                    fieldLabel: 'Label'
                },
                {
                    xtype: 'hiddenfield',
                    id: 'hdnOffVITDSpwd',
                    itemId: 'hdnOffVITDSpwd',
                    fieldLabel: 'Label'
                },
                {
                    xtype: 'hiddenfield',
                    id: 'hdnOffVITDSsubdate',
                    itemId: 'hdnOffVITDSsubdate',
                    fieldLabel: 'Label'
                },
                {
                    xtype: 'hiddenfield',
                    id: 'hdnOffVITDSmail',
                    itemId: 'hdnOffVITDSmail',
                    fieldLabel: 'Label'
                },
                {
                    xtype: 'hiddenfield',
                    id: 'hdnOffVITDSphone',
                    itemId: 'hdnOffVITDSphone',
                    fieldLabel: 'Label'
                },
                {
                    xtype: 'hiddenfield',
                    id: 'hdnOffVITDSadd',
                    itemId: 'hdnOffVITDSadd',
                    fieldLabel: 'Label'
                },
                {
                    xtype: 'hiddenfield',
                    id: 'hdnOffVITDStso',
                    itemId: 'hdnOffVITDStso',
                    fieldLabel: 'Label'
                },
                {
                    xtype: 'hiddenfield',
                    id: 'hdnOffVITDSird',
                    itemId: 'hdnOffVITDSird',
                    fieldLabel: 'Label'
                }
            ]
        });

        me.callParent(arguments);
    }

});