/*
 * File: app/view/Notification.js
 *
 * This file was generated by Sencha Architect version 2.2.2.
 * http://www.sencha.com/products/architect/
 *
 * This file requires use of the Ext JS 4.0.x library, under independent license.
 * License of Sencha Architect does not include license for Ext JS 4.0.x. For more
 * details see http://www.sencha.com/license or contact license@sencha.com.
 *
 * This file will be auto-generated each and everytime you save your project.
 *
 * Do NOT hand edit this file.
 */

Ext.define('MyApp.view.Notification', {
    extend: 'Ext.panel.Panel',

    frame: true,
    id: 'pnlNotification',
    itemId: 'pnlNotification',
    title: 'Notification',

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'form',
                    frame: true,
                    height: 268,
                    id: 'notForm',
                    itemId: 'notForm',
                    margin: '10 0 0 10',
                    bodyPadding: 10,
                    items: [
                        {
                            xtype: 'displayfield',
                            id: 'dpfNotAction',
                            itemId: 'dpfNotAction',
                            margin: '0 0 0 10',
                            maxHeight: 30,
                            width: 700,
                            fieldLabel: '',
                            fieldStyle: '{color:red;}'
                        },
                        {
                            xtype: 'textfield',
                            anchor: '100%',
                            id: 'txtNotOffCode',
                            itemId: 'txtNotOffCode',
                            margin: '20 0 10 0',
                            maxWidth: 190,
                            fieldLabel: 'कार्यालय कोड',
                            labelWidth: 130,
                            readOnly: true,
                            allowBlank: false,
                            maxLength: 2,
                            minLength: 2
                        },
                        {
                            xtype: 'textfield',
                            id: 'txtNotAccType',
                            itemId: 'txtNotAccType',
                            width: 180,
                            fieldLabel: 'खाताको किसिम',
                            labelWidth: 130,
                            readOnly: true,
                            allowBlank: false,
                            enforceMaxLength: true,
                            maxLength: 2,
                            minLength: 2,
                            size: 2
                        },
                        {
                            xtype: 'container',
                            height: 30,
                            layout: {
                                align: 'middle',
                                type: 'hbox'
                            },
                            items: [
                                {
                                    xtype: 'textfield',
                                    id: 'txtNotPan',
                                    itemId: 'txtNotPan',
                                    width: 270,
                                    fieldLabel: 'स्थायी लेखा नं.',
                                    labelWidth: 130,
                                    enableKeyEvents: true,
                                    enforceMaxLength: true,
                                    maxLength: 9,
                                    minLength: 9
                                },
                                {
                                    xtype: 'textfield',
                                    id: 'txtNotTradeName',
                                    itemId: 'txtNotTradeName',
                                    margin: '0 0 0 16',
                                    width: 420,
                                    fieldLabel: 'करदाताको नाम',
                                    labelWidth: 90,
                                    readOnly: true
                                }
                            ]
                        },
                        {
                            xtype: 'container',
                            height: 31,
                            layout: {
                                align: 'middle',
                                type: 'hbox'
                            },
                            items: [
                                {
                                    xtype: 'textfield',
                                    id: 'txtNotIssuedDate',
                                    itemId: 'txtNotIssuedDate',
                                    width: 230,
                                    fieldLabel: 'जारी मिति',
                                    labelWidth: 130,
                                    emptyText: 'YYYY/MM/DD'
                                },
                                {
                                    xtype: 'textfield',
                                    flex: 1,
                                    id: 'txtNotSeq',
                                    itemId: 'txtNotSeq',
                                    margin: '0 0 0 35',
                                    maxWidth: 160,
                                    fieldLabel: 'क्रम. संख्या',
                                    labelWidth: 93,
                                    enableKeyEvents: true,
                                    listeners: {
                                        blur: {
                                            fn: me.onTxtNotSeqBlur,
                                            scope: me
                                        }
                                    }
                                }
                            ]
                        },
                        {
                            xtype: 'container',
                            height: 50,
                            layout: {
                                align: 'middle',
                                type: 'hbox'
                            },
                            items: [
                                {
                                    xtype: 'textfield',
                                    id: 'txtNotTaxYear',
                                    itemId: 'txtNotTaxYear',
                                    width: 190,
                                    fieldLabel: 'कर वर्ष',
                                    labelWidth: 130,
                                    maxLength: 4,
                                    minLength: 4
                                },
                                {
                                    xtype: 'combobox',
                                    id: 'cboNotFilePer',
                                    itemId: 'cboNotFilePer',
                                    margin: '0 0 0 57',
                                    width: 220,
                                    fieldLabel: 'मा /द्वै /चौ',
                                    labelWidth: 90,
                                    allowBlank: false,
                                    editable: false,
                                    displayField: 'FilPeriodDesc',
                                    queryMode: 'local',
                                    store: 'FilingPeriodStore',
                                    valueField: 'FilPeriod'
                                },
                                {
                                    xtype: 'combobox',
                                    id: 'cboNotPer',
                                    itemId: 'cboNotPer',
                                    margin: '0 0 0 15',
                                    width: 170,
                                    fieldLabel: 'अवधि',
                                    labelWidth: 50,
                                    allowBlank: false,
                                    editable: false,
                                    displayField: 'PeriodDesc',
                                    store: 'PeriodStore',
                                    valueField: 'Period'
                                }
                            ]
                        },
                        {
                            xtype: 'container',
                            height: 30,
                            layout: {
                                align: 'middle',
                                type: 'hbox'
                            },
                            items: [
                                {
                                    xtype: 'combobox',
                                    flex: 1,
                                    id: 'cboNotAmtType',
                                    itemId: 'cboNotAmtType',
                                    maxWidth: 250,
                                    fieldLabel: 'क्रेडित / डेबित',
                                    labelWidth: 130,
                                    editable: false,
                                    displayField: 'AmtType',
                                    queryMode: 'local',
                                    store: 'NotAmtType',
                                    valueField: 'Type'
                                },
                                {
                                    xtype: 'textfield',
                                    id: 'txtNotAmtDr',
                                    itemId: 'txtNotAmtDr',
                                    margin: '0 0 0 25',
                                    width: 215,
                                    fieldLabel: 'रकम',
                                    labelWidth: 91,
                                    enforceMaxLength: true,
                                    maskRe: /[0-9]/,
                                    maxLength: 14
                                }
                            ]
                        }
                    ]
                },
                {
                    xtype: 'container',
                    height: 25,
                    width: 1050,
                    layout: {
                        align: 'middle',
                        pack: 'end',
                        type: 'hbox'
                    },
                    items: [
                        {
                            xtype: 'button',
                            id: 'btnNotSave',
                            itemId: 'btnNotSave',
                            margin: '',
                            iconCls: 'icon-save',
                            text: 'Save'
                        },
                        {
                            xtype: 'button',
                            id: 'btnNotEdit',
                            itemId: 'btnNotEdit',
                            margin: '0 0 0 5',
                            iconCls: 'icon-edit',
                            text: 'Edit'
                        },
                        {
                            xtype: 'button',
                            id: 'btnNotDel',
                            itemId: 'btnNotDel',
                            margin: '0 0 0 5',
                            iconCls: 'icon-delete',
                            text: 'Delete'
                        },
                        {
                            xtype: 'button',
                            id: 'btnNotSubmit',
                            itemId: 'btnNotSubmit',
                            margin: '0 0 0 5',
                            iconCls: 'icon-ok',
                            text: 'Submit'
                        },
                        {
                            xtype: 'button',
                            id: 'btnNotCancel',
                            itemId: 'btnNotCancel',
                            margin: '0 0 0 5',
                            iconCls: 'icon-cancel',
                            text: 'Cancel'
                        }
                    ]
                },
                {
                    xtype: 'hiddenfield',
                    id: 'hdnNotTran',
                    itemId: 'hdnNotTran',
                    fieldLabel: 'Label'
                },
                {
                    xtype: 'hiddenfield',
                    id: 'hdnNotAction',
                    itemId: 'hdnNotAction',
                    fieldLabel: 'Label'
                },
                {
                    xtype: 'hiddenfield',
                    itemId: 'hdnnotifDate',
                    fieldLabel: 'Label'
                },
                {
                    xtype: 'hiddenfield',
                    itemId: 'hdnnotifErrMsg',
                    fieldLabel: 'Label'
                }
            ]
        });

        me.callParent(arguments);
    },

    onTxtNotSeqBlur: function(field, eOpts) {
        var me = this;

        var txtNotAccType = Ext.ComponentQuery.query('#txtNotAccType')[0].getValue();
        var txtNotPan = Ext.ComponentQuery.query('#txtNotPan')[0].getValue();
        var txtNotSeq = Ext.ComponentQuery.query('#txtNotSeq')[0].getValue();


        if(txtNotAccType === "")
        {
            msg("WARNING","Enter AccType");
            return;
        }
        else if(txtNotPan === "")
        {
            msg("WARNING","Enter PAN No");
            return;
        }
        else if(txtNotSeq === "")
        {
            msg("WARNING","Enter SEQ");
            return;
        }

        //var wait = waitMsg('loading ...');


        Ext.Ajax.request({
            url:"../Handlers/VAT/Notification/VatNotificationHandler.ashx?method=GetNotification" ,
            params:{Pan:txtNotPan,AcctType:txtNotAccType,SeqNo:txtNotSeq},
            success: function ( result, request ) 
            {            

                //wait.hide();            

                var obj = Ext.decode(result.responseText);            

                if(obj.success === "false")
                {   
                    msg("WARNING",obj.message);
                    return;
                }


                var txtNotOffCode = Ext.ComponentQuery.query('#txtNotOffCode')[0];
                var txtNotPan = Ext.ComponentQuery.query('#txtNotPan')[0];
                var txtNotTradeName = Ext.ComponentQuery.query('#txtNotTradeName')[0];
                var txtNotIssuedDate = Ext.ComponentQuery.query('#txtNotIssuedDate')[0];
                var txtNotSeq = Ext.ComponentQuery.query('#txtNotSeq')[0];
                var action = Ext.ComponentQuery.query('#hdnNotAction')[0];
                var txtNotAccType = Ext.ComponentQuery.query('#txtNotAccType')[0];
                var txtNotAmtDr = Ext.ComponentQuery.query('#txtNotAmtDr')[0];
                var cboNotFilePer = Ext.ComponentQuery.query('#cboNotFilePer')[0];
                var cboNotPer = Ext.ComponentQuery.query('#cboNotPer')[0];
                var txtNotTaxYear = Ext.ComponentQuery.query('#txtNotTaxYear')[0];
                var cboNotAmtType = Ext.ComponentQuery.query('#cboNotAmtType')[0]; 
                var hdnTran = Ext.ComponentQuery.query('#hdnNotTran')[0];

                // var store = Ext.getStore('RebateDetails');

                var data = obj.root; 


                //txtNotAccType.setValue(data[0].AccType);
                if(data.AmtDr!==null)
                {
                    cboNotAmtType.setValue('डेबिट');
                    txtNotAmtDr.setValue(data.AmtDr);
                }
                else if(data.AmtCr!==null)
                {
                    cboNotAmtType.setValue('क्रेडिट');
                    txtNotAmtDr.setValue(data.AmtCr);
                }
                else
                {
                    cboNotAmtType.setValue('');
                    txtNotAmtDr.setValue('');
                }


                cboNotFilePer.setValue(data.FilePer);
                cboNotPer.setValue(data.Period);
                txtNotIssuedDate.setValue(data.IssuedDate);
                txtNotTaxYear.setValue(data.TaxYear);
                hdnTran.setValue(data.TranNo);

                if(action.getValue() !== "D")
                {
                    action.setValue(data.Action);
                }




            },
            failure: function ( result, request ) {

                // wait.hide();


                msg("FAILURE","Error in Fetching Data !!!");
            }
        });
    }

});