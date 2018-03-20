﻿/*
 * File: app/view/RefundPayments.js
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

Ext.define('MyApp.view.RefundPayments', {
    extend: 'Ext.panel.Panel',

    frame: true,
    height: 530,
    itemId: 'RefundPaymentsRfp',
    maxHeight: 530,
    width: 800,
    title: 'भुक्तानी फिर्ता',

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'form',
                    frame: true,
                    height: 480,
                    itemId: 'frmRefundPaymentsRfp',
                    margin: 5,
                    maxHeight: 550,
                    bodyPadding: 10,
                    items: [
                        {
                            xtype: 'label',
                            height: 50,
                            margin: '0 0 0 320',
                            maxHeight: 50,
                            style: 'font-size:20px',
                            text: 'भुक्तानी फिर्ता'
                        },
                        {
                            xtype: 'container',
                            itemId: 'cntTopRfp',
                            margin: '30 0 0 0',
                            items: [
                                {
                                    xtype: 'fieldset',
                                    height: 110,
                                    maxHeight: 110,
                                    padding: 5,
                                    title: 'भुक्तानी फिर्ता खोज्नुहोस्',
                                    items: [
                                        {
                                            xtype: 'textfield',
                                            anchor: '100%',
                                            disabled: true,
                                            itemId: 'txtPanRfp',
                                            maxWidth: 205,
                                            fieldLabel: 'करदाता दर्ता नम्बर',
                                            msgTarget: 'side',
                                            emptyText: 'Enter Pan No.',
                                            maxLength: 9
                                        },
                                        {
                                            xtype: 'checkboxfield',
                                            itemId: 'chkAllRfp',
                                            margin: '0 0 0 105',
                                            maxWidth: 255,
                                            fieldLabel: '',
                                            boxLabel: 'सबै',
                                            checked: true
                                        },
                                        {
                                            xtype: 'container',
                                            layout: {
                                                type: 'table'
                                            }
                                        },
                                        {
                                            xtype: 'button',
                                            itemId: 'btnLoadRefundRfp',
                                            margin: '5 0 5 104',
                                            icon: '',
                                            iconCls: 'icon-load',
                                            text: 'Load'
                                        }
                                    ]
                                }
                            ]
                        },
                        {
                            xtype: 'container',
                            itemId: 'cntBottomRfp',
                            width: 1038,
                            items: [
                                {
                                    xtype: 'gridpanel',
                                    height: 250,
                                    itemId: 'grdRefundPaymentRfp',
                                    autoScroll: true,
                                    title: 'भुक्तानी फिर्ता विवरण',
                                    store: 'RefundPaymentsRfp',
                                    columns: [
                                        {
                                            xtype: 'rownumberer'
                                        },
                                        {
                                            xtype: 'gridcolumn',
                                            defaultWidth: 65,
                                            dataIndex: 'AppliedDate',
                                            text: 'RequestDate'
                                        },
                                        {
                                            xtype: 'gridcolumn',
                                            defaultWidth: 70,
                                            dataIndex: 'Pan',
                                            text: 'Pan'
                                        },
                                        {
                                            xtype: 'gridcolumn',
                                            defaultWidth: 70,
                                            dataIndex: 'TaxYear',
                                            text: 'TaxYear'
                                        },
                                        {
                                            xtype: 'gridcolumn',
                                            defaultWidth: 70,
                                            dataIndex: 'FilPeriod',
                                            text: 'Filing Period'
                                        },
                                        {
                                            xtype: 'gridcolumn',
                                            defaultWidth: 60,
                                            dataIndex: 'Period',
                                            text: 'Period'
                                        },
                                        {
                                            xtype: 'gridcolumn',
                                            defaultWidth: 70,
                                            align: 'right',
                                            dataIndex: 'AmountClaimed',
                                            text: 'Requested Amount'
                                        },
                                        {
                                            xtype: 'gridcolumn',
                                            defaultWidth: 230,
                                            dataIndex: 'AppliedAs',
                                            text: 'Refund Request Basis'
                                        },
                                        {
                                            xtype: 'gridcolumn',
                                            defaultWidth: 60,
                                            dataIndex: 'Status',
                                            text: 'Status'
                                        },
                                        {
                                            xtype: 'gridcolumn',
                                            dataIndex: 'CloseStatus',
                                            text: 'Close Status'
                                        },
                                        {
                                            xtype: 'actioncolumn',
                                            items: [
                                                {
                                                    handler: function(view, rowIndex, colIndex, item, e) {
                                                        var row = view.store.getAt(rowIndex).data;

                                                        //console.log("row>>",row);

                                                        if(row.CloseStatus === "CL")
                                                        {
                                                            msg("WARNING","Refund Claim not closed yet !!!");
                                                            return;
                                                        }
                                                        else
                                                        {  

                                                            var param = { 'pan':row.Pan,'accType':'00','taxYear':row.TaxYear,'filper':row.FilPeriod,'period':row.Period,'appDate':row.AppliedDate};

                                                            //console.log("param",param);


                                                            var url="../../../Reporting/Vat/ReportHandlers/RefundPaymentReportHandler.ashx";
                                                            var winOption="width=730,height=345,left=100,top=100,resizable=yes,scrollbars=yes";
                                                            OpenWindowWithPost(url,winOption,"NewFile", param);


                                                        }

                                                    },
                                                    icon: '../ITS/resources/images/icons/print.png',
                                                    iconCls: 'iconMargin',
                                                    tooltip: 'Click to Print'
                                                },
                                                {
                                                    handler: function(view, rowIndex, colIndex, item, e) {
                                                        var winRefClose = Ext.create('MyApp.view.RefundClose');

                                                        var store = Ext.getStore('RefundPaymentsRfp');
                                                        var row = store.getAt(rowIndex).data;


                                                        if(row.CloseStatus === "F")
                                                        {
                                                            msg("WARNING","Refund Close already finalized !!!");
                                                            return;
                                                        }

                                                        var strFilPeriod = Ext.getStore("FilingPeriodStore");                
                                                        var idxFile = strFilPeriod.find('FilPeriod',row.FilPeriod);
                                                        var recFile = strFilPeriod.getAt(idxFile);

                                                        var strPeriod = Ext.getStore("Period");  
                                                        strPeriod.loadData(recFile.data.Period);
                                                        var idxPeriod = strPeriod.find('Period',row.Period);
                                                        var recPeriod = strPeriod.getAt(idxPeriod);

                                                        var wait  = watiMsg('Loading ...');

                                                        var pan = row.Pan;
                                                        //var officeCode = "22";
                                                        var accountType = "00";


                                                        var officeCode = Ext.get('offCode').dom.innerHTML;
                                                        var currentDate = Ext.get('nepDate').dom.innerHTML;

                                                        var taxyear = row.TaxYear;
                                                        var fileper = row.FilPeriod;
                                                        var period = row.Period;

                                                        Ext.Ajax.request({
                                                            url:"../Handlers/VAT/RefundPayments/RefundPaymentsHandler2.ashx?method=CloneRefundClaim" ,
                                                            params:{offCode:officeCode,accType:accountType,panNo:pan,taxyear:row.TaxYear,fileper:row.FilPeriod,period:row.Period,appliedDate:row.AppliedDate},
                                                            success: function ( result, request ) {            

                                                                wait.hide();          

                                                                var obj = Ext.decode(result.responseText);

                                                                if(obj.success === "true")
                                                                {            
                                                                    winRefClose.modal = true;
                                                                    winRefClose.show();

                                                                    var strBank = Ext.getStore("OfficeBankInfo");

                                                                    strBank.load(
                                                                    {
                                                                        params:{officeCode:officeCode }
                                                                    });

                                                                    Ext.ComponentQuery.query('#txtBankCodeRpc')[0].bindStore(strBank);

                                                                    // Ext.ComponentQuery.query('#lblDateRpc')[0].setValue(currentDate);

                                                                    Ext.ComponentQuery.query('#txtOfficeCodeRpc')[0].setValue(officeCode);
                                                                    Ext.ComponentQuery.query('#txtPanRpc')[0].setValue(row.Pan);
                                                                    Ext.ComponentQuery.query('#txtAccTypeRpc')[0].setValue("00");
                                                                    Ext.ComponentQuery.query('#txtTaxYearRpc')[0].setValue(row.TaxYear);
                                                                    Ext.ComponentQuery.query('#txtFilePer')[0].setValue(recFile.data.FilPeriodDesc);
                                                                    Ext.ComponentQuery.query('#txtPeriodRpc')[0].setValue(recPeriod.data.PeriodDesc);
                                                                    Ext.ComponentQuery.query('#txtAmountClaimedRpc')[0].setValue(row.AmountClaimed);
                                                                    Ext.ComponentQuery.query('#hdnFilPeriodRpc')[0].setValue(row.FilPeriod);
                                                                    Ext.ComponentQuery.query('#hdnPeriodRpc')[0].setValue(row.Period);

                                                                    var data = obj.root;

                                                                    if(obj.total > 0 && data.Status === "I" )
                                                                    {
                                                                        Ext.ComponentQuery.query('#txtAcceptedAmountRpc')[0].setValue(data.AcceptedAmount);
                                                                        Ext.ComponentQuery.query('#txtPayDedAmountRpc')[0].setValue(data.PayDedAmount);
                                                                        Ext.ComponentQuery.query('#txtChequeAmountRpc')[0].setValue(data.ChequeAmount);                
                                                                        Ext.ComponentQuery.query('#txtRefCloseDate')[0].setValue(data.RefCloseDate);
                                                                        Ext.ComponentQuery.query('#txtChequeNumberRpc')[0].setValue(data.ChequeNumber);
                                                                        Ext.ComponentQuery.query('#txtChequeDateRpc')[0].setValue(data.ChequeDate);
                                                                        Ext.ComponentQuery.query('#txtBankCodeRpc')[0].setValue(data.BankCode);
                                                                        Ext.ComponentQuery.query('#txtUserIDRpc')[0].setValue(data.UserID);
                                                                        Ext.ComponentQuery.query('#txtTranDateRpc')[0].setValue(data.TranDate);
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    msg("FAILURE",obj.message);
                                                                }

                                                            },
                                                            failure:  function ( result, request ) { 

                                                                wait.hide();            
                                                                button.up('window').close();

                                                                msg("FAILURE","Error in Fetching data !!!");
                                                            }
                                                        });
                                                    },
                                                    icon: '../ITS/resources/images/icons/filesave.png',
                                                    iconCls: 'iconMargin',
                                                    tooltip: 'Click to Close'
                                                }
                                            ]
                                        }
                                    ]
                                }
                            ]
                        }
                    ]
                }
            ]
        });

        me.callParent(arguments);
    }

});
