/*
 * File: app/view/AppealEntry.js
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

Ext.define('MyApp.view.AppealEntry', {
    extend: 'Ext.panel.Panel',

    frame: true,
    height: 700,
    itemId: 'pnlAppealEntry',
    autoScroll: true,
    title: 'पुनरावेदनको सूचना',

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'form',
                    CalAppealTotalAmount: function() {

                        var grd = Ext.ComponentQuery.query('#Appeal_grdTaxPeriod')[0];
                        var store = grd.getStore();
                        var selectedRow = grd.getSelectionModel();

                        var record = grd.getSelectionModel().getSelection()[0];
                        var apTotAmount = Ext.ComponentQuery.query('#Appeal_txtTotalAmount')[0];

                        apTotAmount.setValue("");

                        //This code sum numbers in certain column
                        var sum = 0; 
                        var rowIdx = store.indexOf(record);
                        var idx = 0;

                        console.log("rowIdx",rowIdx);

                        store.each(function (rec) {     


                            if(rec.get('Amount') !=="" && rowIdx !== idx)
                            {
                                sum = parseInt(sum) + parseInt(rec.get('Amount')); 
                            }

                            idx++;


                        });

                        apTotAmount.setValue(sum);
                    },
                    frame: true,
                    itemId: 'frmAppealEntry',
                    bodyPadding: 10,
                    title: '',
                    items: [
                        {
                            xtype: 'container',
                            frame: false,
                            itemId: 'cntTopAppeal',
                            items: [
                                {
                                    xtype: 'displayfield',
                                    height: 25,
                                    hidden: true,
                                    itemId: 'lblActionAppeal',
                                    width: 800,
                                    fieldStyle: '{color:red;}'
                                },
                                {
                                    xtype: 'textfield',
                                    itemId: 'Appeal_txtOffCode',
                                    width: 200,
                                    fieldLabel: 'कार्यलय कोड',
                                    labelWidth: 140,
                                    msgTarget: 'side',
                                    readOnly: true,
                                    allowBlank: false,
                                    enableKeyEvents: true,
                                    maskRe: /[0-9]/,
                                    maxLength: 4
                                },
                                {
                                    xtype: 'textfield',
                                    hidden: true,
                                    itemId: 'Appeal_txtAppealNo',
                                    fieldLabel: 'पुनरावेदन दर्ता नं.',
                                    labelWidth: 140,
                                    msgTarget: 'side',
                                    allowBlank: false,
                                    emptyText: 'का.कोड....वर्ष....क्रम नं........',
                                    enableKeyEvents: true,
                                    enforceMaxLength: true,
                                    maskRe: /[0-9]/,
                                    maxLength: 10,
                                    minLength: 10
                                },
                                {
                                    xtype: 'textfield',
                                    itemId: 'Appeal_txtPan',
                                    width: 240,
                                    fieldLabel: 'स्था.ले.नं.',
                                    labelWidth: 140,
                                    msgTarget: 'side',
                                    allowBlank: false,
                                    enableKeyEvents: true,
                                    enforceMaxLength: true,
                                    maskRe: /[0-9]/,
                                    maxLength: 9,
                                    minLength: 9
                                },
                                {
                                    xtype: 'textfield',
                                    itemId: 'Appeal_txtTaxPayerName',
                                    width: 460,
                                    fieldLabel: 'करदाताको नाम',
                                    labelWidth: 140,
                                    readOnly: true
                                },
                                {
                                    xtype: 'textfield',
                                    itemId: 'Appeal_txtTaxPayerAddress',
                                    width: 460,
                                    fieldLabel: 'करदाताको ठेगाना',
                                    labelWidth: 140,
                                    readOnly: true
                                },
                                {
                                    xtype: 'textfield',
                                    itemId: 'Appeal_txtAppealDate',
                                    width: 240,
                                    fieldLabel: 'पुनरावेदनमा गएको मिति',
                                    labelWidth: 140,
                                    msgTarget: 'side',
                                    allowBlank: false,
                                    emptyText: 'YYYY.MM.DD'
                                },
                                {
                                    xtype: 'combobox',
                                    itemId: 'cboAppealSubjectAE',
                                    fieldLabel: 'पुनरावेदनमा गएको विषय',
                                    labelWidth: 140,
                                    msgTarget: 'side',
                                    allowBlank: false,
                                    emptyText: '.....छान्नुहोस्.....',
                                    displayField: 'ApplSubject',
                                    forceSelection: true,
                                    queryMode: 'local',
                                    store: 'AppealSubjectAE',
                                    typeAhead: true,
                                    valueField: 'ApplSubCode'
                                },
                                {
                                    xtype: 'fieldcontainer',
                                    height: 22,
                                    itemId: 'fCntApplMANo',
                                    width: 400,
                                    layout: {
                                        align: 'stretch',
                                        type: 'hbox'
                                    },
                                    fieldLabel: '',
                                    labelWidth: 130,
                                    items: [
                                        {
                                            xtype: 'label',
                                            itemId: 'lblAE',
                                            width: 130,
                                            text: 'कर निर्धारण आदेश नं.'
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'Appeal_txtAppeal_On_Ma_No',
                                            margin: '0 0 0 7',
                                            fieldLabel: '',
                                            labelWidth: 140,
                                            msgTarget: 'side',
                                            allowBlank: false,
                                            enableKeyEvents: true,
                                            maskRe: /[0-9]/,
                                            maxLength: 10
                                        }
                                    ]
                                },
                                {
                                    xtype: 'combobox',
                                    itemId: 'Appeal_cboAppeal_Loc_Code',
                                    fieldLabel: 'पुनरावेदनमा गएको निकाय',
                                    labelWidth: 140,
                                    msgTarget: 'side',
                                    allowBlank: false,
                                    emptyText: '.....छान्नुहोस्.....',
                                    displayField: 'name',
                                    forceSelection: true,
                                    queryMode: 'local',
                                    store: 'AppealLocationStore',
                                    typeAhead: true,
                                    valueField: 'code'
                                },
                                {
                                    xtype: 'textfield',
                                    itemId: 'Appeal_txtAppeal_Loc_Code_RegNo',
                                    fieldLabel: ' दर्ता नं.',
                                    labelWidth: 140
                                },
                                {
                                    xtype: 'fieldcontainer',
                                    height: 27,
                                    itemId: 'fCntOrderAE',
                                    width: 600,
                                    layout: {
                                        align: 'stretch',
                                        type: 'hbox'
                                    },
                                    fieldLabel: '',
                                    items: [
                                        {
                                            xtype: 'textfield',
                                            itemId: 'Appeal_txtOrderNo',
                                            fieldLabel: 'आदेश नं.',
                                            labelWidth: 140
                                        },
                                        {
                                            xtype: 'textfield',
                                            margins: '0 0 0 10',
                                            itemId: 'Appeal_txtOrderDate',
                                            width: 200,
                                            fieldLabel: 'आदेश मिति',
                                            msgTarget: 'side',
                                            emptyText: 'YYYY.MM.DD'
                                        }
                                    ]
                                },
                                {
                                    xtype: 'textareafield',
                                    itemId: 'Appeal_txtAppealReason',
                                    width: 560,
                                    fieldLabel: 'पुनरावेदन बिवरण',
                                    labelWidth: 140,
                                    enableKeyEvents: true
                                }
                            ]
                        },
                        {
                            xtype: 'container',
                            height: 250,
                            itemId: 'cntBottomAppeal',
                            width: 900,
                            autoScroll: true,
                            items: [
                                {
                                    xtype: 'gridpanel',
                                    height: 250,
                                    itemId: 'Appeal_grdTaxPeriod',
                                    width: 750,
                                    title: 'कर अवधि',
                                    columnLines: true,
                                    store: 'AppealLines',
                                    columns: [
                                        {
                                            xtype: 'rownumberer',
                                            width: 35,
                                            dataIndex: 'SeqNo',
                                            text: 'क्र.सं.'
                                        },
                                        {
                                            xtype: 'gridcolumn',
                                            dataIndex: 'TaxYear',
                                            text: 'वर्ष',
                                            editor: {
                                                xtype: 'textfield',
                                                itemId: 'AL_txtTaxYear',
                                                msgTarget: 'side',
                                                emptyText: 'YYYY',
                                                maskRe: /[0-9]/,
                                                maxLength: 4
                                            }
                                        },
                                        {
                                            xtype: 'gridcolumn',
                                            dataIndex: 'FilePer',
                                            text: 'मा/चौ/द्वै',
                                            editor: {
                                                xtype: 'combobox',
                                                itemId: 'AL_cboFilePeriod',
                                                msgTarget: 'side',
                                                emptyText: '...छान्नुहोस्...',
                                                displayField: 'FilPeriodDesc',
                                                forceSelection: true,
                                                queryMode: 'local',
                                                store: 'FilingPeriodStore',
                                                typeAhead: true,
                                                valueField: 'FilPeriod'
                                            }
                                        },
                                        {
                                            xtype: 'gridcolumn',
                                            dataIndex: 'Period',
                                            text: 'कर अवधि',
                                            editor: {
                                                xtype: 'combobox',
                                                itemId: 'AL_cboPeriod',
                                                msgTarget: 'side',
                                                emptyText: '...छान्नुहोस्...',
                                                displayField: 'PeriodDesc',
                                                forceSelection: true,
                                                queryMode: 'local',
                                                store: 'Period',
                                                typeAhead: true,
                                                valueField: 'Period'
                                            }
                                        },
                                        {
                                            xtype: 'gridcolumn',
                                            width: 240,
                                            dataIndex: 'AppealOn',
                                            text: 'पुनरावेदन गएको विषय कर/जरिवाना/थप दस्तुर/वयाज',
                                            editor: {
                                                xtype: 'combobox',
                                                itemId: 'AL_cboAppealOn',
                                                msgTarget: 'side',
                                                emptyText: '...छान्नुहोस्...',
                                                enableKeyEvents: true,
                                                displayField: 'appealOnSubj',
                                                forceSelection: true,
                                                queryMode: 'local',
                                                store: 'AppealOnSubjectStore',
                                                typeAhead: true,
                                                valueField: 'id'
                                            }
                                        },
                                        {
                                            xtype: 'gridcolumn',
                                            width: 120,
                                            dataIndex: 'Amount',
                                            text: 'पुनरावेदन गरिएको रकम',
                                            editor: {
                                                xtype: 'textfield',
                                                itemId: 'AL_txtAmount',
                                                width: 100,
                                                msgTarget: 'side',
                                                fieldStyle: 'text-align:right',
                                                maskRe: /[0-9]/,
                                                maxLength: 14
                                            }
                                        },
                                        {
                                            xtype: 'actioncolumn',
                                            width: 50,
                                            items: [
                                                {
                                                    handler: function(view, rowIndex, colIndex, item, e) {
                                                        var hdnAct = Ext.ComponentQuery.query('#hdnActAppeal')[0];
                                                        var hdnAction = Ext.ComponentQuery.query('#hdnActionAppeal')[0];
                                                        var hdnActAU=Ext.ComponentQuery.query('#hdnActionAppAU')[0];
                                                        //console.log("t",hdnAct.lastValue);
                                                        //console.log("d",hdnAction.lastValue);

                                                        var grd = Ext.ComponentQuery.query("#Appeal_grdTaxPeriod")[0];
                                                        var store = Ext.getStore('AppealLines');
                                                        var row = store.getAt(rowIndex).data;
                                                        //console.log("row",row);

                                                        var apTotAmount=Ext.ComponentQuery.query('#Appeal_txtTotalAmount')[0];
                                                        var totAmount = (row.Amount === "")?0:row.Amount;

                                                        var overallTot = "";

                                                        //console.log("tot",totAmount);
                                                        //console.log("aptot",apTotAmount.getValue());



                                                        if(hdnAct.lastValue === "T" || hdnAction.lastValue === "D" || hdnActAU.lastValue === "V")
                                                        {
                                                            return false;
                                                        }
                                                        else
                                                        {

                                                            Ext.Msg.confirm('Confirm','के तपाई साचै डाटा हटाउन चाहनुहुन्छ?', function(btn) {
                                                                if(btn == 'yes'){

                                                                    overallTot = parseInt(apTotAmount.getValue())-parseInt(totAmount);
                                                                    //console.log("Over",overallTot);
                                                                    apTotAmount.setValue(overallTot);

                                                                    if(row.Action === "E")
                                                                    {    
                                                                        //alert("Deleting...");
                                                                        row.Action = "D";
                                                                        grd.bindStore(store);         
                                                                        store.filter(function(item){
                                                                            return item.get("Action")!= 'D';
                                                                        });
                                                                    }
                                                                    else
                                                                    {
                                                                        //alert("New");
                                                                        store.removeAt(rowIndex);
                                                                    }

                                                                    // store.removeAt(rowIndex);

                                                                    return true;
                                                                }
                                                            }, this);

                                                            return true;
                                                        }


                                                    },
                                                    icon: '../ITS/resources/images/icons/cancel.png'
                                                }
                                            ]
                                        }
                                    ],
                                    plugins: [
                                        Ext.create('Ext.grid.plugin.RowEditing', {
                                            pluginId: 'grdTaxPeriodPlugin',
                                            clicksToMoveEditor: 1,
                                            listeners: {
                                                validateedit: {
                                                    fn: me.onGridroweditingpluginValidateedit,
                                                    scope: me
                                                },
                                                canceledit: {
                                                    fn: me.onGridroweditingpluginCanceledit,
                                                    scope: me
                                                },
                                                edit: {
                                                    fn: me.onGridroweditingpluginEdit,
                                                    scope: me
                                                },
                                                beforeedit: {
                                                    fn: me.onGridroweditingpluginBeforeEdit,
                                                    scope: me
                                                }
                                            }
                                        })
                                    ],
                                    dockedItems: [
                                        {
                                            xtype: 'toolbar',
                                            dock: 'top',
                                            items: [
                                                {
                                                    xtype: 'button',
                                                    itemId: 'appeal_btnAdd',
                                                    iconCls: 'icon-add',
                                                    text: 'Add'
                                                }
                                            ]
                                        }
                                    ]
                                },
                                {
                                    xtype: 'hiddenfield',
                                    itemId: 'hdnActionAppeal',
                                    fieldLabel: 'Label'
                                },
                                {
                                    xtype: 'hiddenfield',
                                    itemId: 'hdnAppealTranNo',
                                    fieldLabel: 'Label'
                                },
                                {
                                    xtype: 'hiddenfield',
                                    itemId: 'hdnAppealFilePer',
                                    fieldLabel: 'Label'
                                },
                                {
                                    xtype: 'hiddenfield',
                                    itemId: 'hdnActAppeal',
                                    fieldLabel: 'Label'
                                },
                                {
                                    xtype: 'hiddenfield',
                                    itemId: 'hdnActionAppAU',
                                    fieldLabel: 'Label'
                                }
                            ]
                        },
                        {
                            xtype: 'container',
                            height: 25,
                            itemId: 'cntAppealTotalAmount',
                            margin: '10 0 0 495',
                            width: 300,
                            items: [
                                {
                                    xtype: 'textfield',
                                    itemId: 'Appeal_txtTotalAmount',
                                    fieldLabel: 'कुल जम्मा',
                                    readOnly: true
                                }
                            ]
                        },
                        {
                            xtype: 'fieldcontainer',
                            height: 25,
                            itemId: 'fCntAppeal',
                            margin: '10 0 0 10',
                            width: 900,
                            layout: {
                                align: 'stretch',
                                pack: 'end',
                                type: 'hbox'
                            },
                            fieldLabel: '',
                            items: [
                                {
                                    xtype: 'button',
                                    itemId: 'Appeal_btnSave',
                                    iconCls: 'icon-save',
                                    text: 'Save'
                                },
                                {
                                    xtype: 'splitter'
                                },
                                {
                                    xtype: 'button',
                                    itemId: 'Appeal_btnEdit',
                                    iconCls: 'icon-edit',
                                    text: 'Edit'
                                },
                                {
                                    xtype: 'splitter'
                                },
                                {
                                    xtype: 'button',
                                    itemId: 'Appeal_btnDelete',
                                    iconCls: 'icon-delete',
                                    text: 'Delete'
                                },
                                {
                                    xtype: 'splitter'
                                },
                                {
                                    xtype: 'button',
                                    itemId: 'Appeal_btnSubmit',
                                    iconCls: 'icon-ok',
                                    text: 'Submit'
                                },
                                {
                                    xtype: 'splitter'
                                },
                                {
                                    xtype: 'button',
                                    itemId: 'Appeal_btnCancel',
                                    iconCls: 'icon-cancel',
                                    text: 'Cancel'
                                },
                                {
                                    xtype: 'splitter'
                                },
                                {
                                    xtype: 'button',
                                    itemId: 'btnPrintAppeal',
                                    iconCls: 'icon-print',
                                    text: 'Print'
                                }
                            ]
                        },
                        {
                            xtype: 'fieldcontainer',
                            height: 25,
                            hidden: true,
                            itemId: 'fCntBack',
                            margin: '10 0 0 1000',
                            width: 200,
                            fieldLabel: '',
                            items: [
                                {
                                    xtype: 'button',
                                    itemId: 'btnBackAppeal',
                                    iconCls: 'icon-back',
                                    text: 'Back'
                                }
                            ]
                        }
                    ]
                }
            ]
        });

        me.callParent(arguments);
    },

    onGridroweditingpluginValidateedit: function(editor, e, eOpts) {
        /*var apTotAmount=Ext.ComponentQuery.query('#Appeal_txtTotalAmount')[0];
        var grd=Ext.ComponentQuery.query('#Appeal_grdTaxPeriod')[0];

        var store = grd.getStore();

        var countData=store.data.items.length;
        var totalAR=0;

        for(var i=0;i<countData;i++)
        {
        //console.log(store.data.items[i].data);

        if(editor.context.rowIdx==i)
        {
            totalAR=Number(totalAR)+Number(editor.context.newValues.Amount);
        }
        else
        {
            totalAR=Number(totalAR)+Number(store.data.items[i].data.Amount);
        }

    }

    apTotAmount.setValue(totalAR);*/


    //var valid = true;
    var pan = Ext.ComponentQuery.query("#Appeal_txtPan")[0].getValue();
    var acctType = "00";

    var filePerMsg = Ext.ComponentQuery.query("#hdnAppealFilePer")[0].getValue();

    var cboFilingPeriod = Ext.ComponentQuery.query("#AL_cboFilePeriod")[0];
    var cboPeriod = Ext.ComponentQuery.query("#AL_cboPeriod")[0];
    var txtTaxYear = Ext.ComponentQuery.query("#AL_txtTaxYear")[0];
    var cboApplOn = Ext.ComponentQuery.query("#AL_cboAppealOn")[0];
    var txtAmount = Ext.ComponentQuery.query("#AL_txtAmount")[0];

    var filePer = cboFilingPeriod.getValue();
    var period = cboPeriod.getValue();
    var year = txtTaxYear.getValue();
    var applOn = cboApplOn.getValue();
    var amount =txtAmount.getValue();

    var errMsg="";
    var errCount=0;

    if(!filePer)
    {
        errCount++;
        errMsg +=errCount+") "+"कृपया मा/चौ/द्वै हाल्नुहोस् !<br/>";
    }
    if(!period)
    {
        errCount++;
        errMsg +=errCount+") "+"कृपया कर अवधि हाल्नुहोस् !<br/>";
    }
    if(!year)
    {
        errCount++;
        errMsg +=errCount+") "+"कृपया कर बर्ष हाल्नुहोस्  !<br/>";
    }
    if(!applOn)
    {
        errCount++;
        errMsg +=errCount+") "+"कृपया पुनरावेदन गएको विषय हाल्नुहोस् !<br/>";
    }

    if(!amount)
    {
        errCount++;
        errMsg +=errCount+") "+"कृपया पुनरावेदन गएको रकम हाल्नुहोस !<br/>";
    }

    if(errCount>0)
    {
        msg("WARNING",errMsg);    
        return false;
    }
    },

    onGridroweditingpluginCanceledit: function(editor, e, eOpts) {
        var cboFilingPeriod = Ext.ComponentQuery.query("#AL_cboFilePeriod")[0];
        var fpAppl = cboFilingPeriod.getValue();

        if(fpAppl === null)
        {
            grid.store.removeAt(grid.rowIdx);
        }
        //var totalAmount = Ext.ComponentQuery.query("#Appeal_txtTotalAmount")[0];
        //totalAmount.reset();
    },

    onGridroweditingpluginEdit: function(editor, e, eOpts) {
        var taxAmount=editor.newValues.Amount;
        var taxYear=editor.newValues.TaxYear;

        taxAmount = taxAmount === ""?null:taxAmount;
        taxYear = taxYear === ""?null:taxYear;

    },

    onGridroweditingpluginBeforeEdit: function(editor, e, eOpts) {
        var hdnAct = Ext.ComponentQuery.query('#hdnActAppeal')[0];
        var hdnAction = Ext.ComponentQuery.query('#hdnActionAppeal')[0];
        //var hdnActAU=Ext.ComponentQuery.query('#hdnActionAppAU')[0];

        if(hdnAct.lastValue === "T" || hdnAction.lastValue === "D" /*|| hdnActAU.lastValue === "V"*/)
        {
            return false;
        }
        else
        {
            return true;
        }

    }

});