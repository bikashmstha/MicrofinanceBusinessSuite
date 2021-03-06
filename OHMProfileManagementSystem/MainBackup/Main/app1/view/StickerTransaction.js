/*
 * File: app/view/StickerTransaction.js
 *
 * This file was generated by Sencha Architect version 2.2.2.
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

Ext.define('MyApp.view.StickerTransaction', {
    extend: 'Ext.panel.Panel',

    frame: true,
    itemId: 'pnlStickerTransaction',
    width: 811,
    autoScroll: true,
    title: 'Sticker Transaction',

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'fieldcontainer',
                    height: 23,
                    itemId: 'fCntTopSTT',
                    margin: '0 0 0 10',
                    width: 811,
                    layout: {
                        align: 'stretch',
                        type: 'hbox'
                    },
                    fieldLabel: '',
                    items: [
                        {
                            xtype: 'button',
                            itemId: 'btnDraftSTT',
                            text: 'Draft'
                        },
                        {
                            xtype: 'splitter'
                        },
                        {
                            xtype: 'button',
                            itemId: 'btnSIPTSTT',
                            text: 'Show incoming pending transfers '
                        },
                        {
                            xtype: 'splitter'
                        },
                        {
                            xtype: 'button',
                            itemId: 'btnSOPTSTTT',
                            text: 'Show outgoing pending transfers'
                        },
                        {
                            xtype: 'splitter'
                        },
                        {
                            xtype: 'button',
                            itemId: 'btnSATSTT',
                            text: 'Show Approved transfers'
                        },
                        {
                            xtype: 'splitter'
                        },
                        {
                            xtype: 'button',
                            itemId: 'btnSRTSTT',
                            text: 'Show rejected transfers'
                        }
                    ]
                },
                {
                    xtype: 'displayfield',
                    height: 25,
                    itemId: 'lblActionSTT',
                    margin: '0 0 0 10',
                    width: 800,
                    fieldStyle: '{color:red;}'
                },
                {
                    xtype: 'container',
                    itemId: 'cntTopSTT',
                    margin: '0 0 0 10',
                    items: [
                        {
                            xtype: 'textfield',
                            hidden: true,
                            itemId: 'txtTransferFromSTT',
                            width: 400,
                            fieldLabel: 'Transfer From'
                        },
                        {
                            xtype: 'textfield',
                            hidden: true,
                            itemId: 'txtTransferToSTT',
                            width: 400,
                            fieldLabel: 'TransferTo'
                        },
                        {
                            xtype: 'combobox',
                            itemId: 'cboTransferFromSTT',
                            width: 400,
                            fieldLabel: 'Transfer From',
                            emptyText: '.....छान्नुहोस्.....',
                            displayField: 'LocationName',
                            forceSelection: true,
                            queryMode: 'local',
                            store: 'UserLocationEASy',
                            typeAhead: true,
                            valueField: 'LocationID'
                        },
                        {
                            xtype: 'textfield',
                            hidden: true,
                            itemId: 'txtTransferNoSTT',
                            fieldLabel: 'Transfer No',
                            msgTarget: 'side',
                            enableKeyEvents: true
                        },
                        {
                            xtype: 'combobox',
                            itemId: 'cboTransferToSTT',
                            width: 400,
                            fieldLabel: 'TransferTo',
                            emptyText: '.....छान्नुहोस्.....',
                            displayField: 'LocationName',
                            forceSelection: true,
                            queryMode: 'local',
                            store: 'AllowedLocationEASy',
                            typeAhead: true,
                            valueField: 'LocationID'
                        },
                        {
                            xtype: 'textfield',
                            validator: function(value) {

                                var errDate = "";

                                errDate = validateNepDate(value);

                                return errDate === ""?true:errDate;

                            },
                            itemId: 'txtTransferDateSTT',
                            width: 200,
                            fieldLabel: 'Transfer Date',
                            msgTarget: 'side',
                            emptyText: 'YYYY.MM.DD',
                            listeners: {
                                change: {
                                    fn: me.onTxtReceivedDateSDChange,
                                    scope: me
                                }
                            }
                        },
                        {
                            xtype: 'textfield',
                            itemId: 'txtTransferBySTT',
                            fieldLabel: 'Transfer By',
                            name: 'receivedBy'
                        }
                    ]
                },
                {
                    xtype: 'container',
                    itemId: 'cntSTTDetails',
                    margin: '10 0 0 10',
                    width: 1050,
                    autoScroll: true,
                    items: [
                        {
                            xtype: 'gridpanel',
                            height: 250,
                            itemId: 'grdSTTDetails',
                            width: 956,
                            title: 'Sticker Transaction Details',
                            columnLines: true,
                            store: 'StickerTransactionDet',
                            columns: [
                                {
                                    xtype: 'gridcolumn',
                                    width: 300,
                                    dataIndex: 'StickerID',
                                    text: 'Sticker Type',
                                    editor: {
                                        xtype: 'combobox',
                                        itemId: 'cboStickerTypeSTT',
                                        emptyText: '.....छान्नुहोस्.....',
                                        displayField: 'StickerDescription',
                                        forceSelection: true,
                                        queryMode: 'local',
                                        store: 'StickerType',
                                        typeAhead: true,
                                        valueField: 'StickerID'
                                    }
                                },
                                {
                                    xtype: 'gridcolumn',
                                    renderer: function(value, metaData, record, rowIndex, colIndex, store, view) {
                                        return '<span style="text-decoration:underline;color:blue">Select</span>';
                                    },
                                    itemId: 'selectLotSTT',
                                    width: 55,
                                    dataIndex: 'Lot',
                                    text: 'Lot'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    width: 150,
                                    dataIndex: 'TransferNo',
                                    text: 'Transfer No',
                                    editor: {
                                        xtype: 'textfield',
                                        itemId: 'txtTransferNoSTTD',
                                        readOnly: true
                                    }
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'BoxNo',
                                    text: 'Box No',
                                    editor: {
                                        xtype: 'textfield',
                                        itemId: 'txtBoxNoSTT',
                                        readOnly: true
                                    }
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'Prefix',
                                    text: 'Prefix',
                                    editor: {
                                        xtype: 'textfield',
                                        itemId: 'txtPrefixSTT',
                                        readOnly: true
                                    }
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'StickerNoFrom',
                                    text: 'Sticker No From',
                                    editor: {
                                        xtype: 'textfield',
                                        itemId: 'txtStickerNoFromSTT',
                                        maskRe: /[0-9]/,
                                        maxLength: 15
                                    }
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'StickerNoTo',
                                    text: 'Sticker No To',
                                    editor: {
                                        xtype: 'textfield',
                                        itemId: 'txtStickerNoToSTT',
                                        maskRe: /[0-9]/,
                                        maxLength: 15
                                    }
                                },
                                {
                                    xtype: 'gridcolumn',
                                    hidden: true,
                                    dataIndex: 'Action',
                                    text: 'Action'
                                },
                                {
                                    xtype: 'actioncolumn',
                                    itemId: 'deleteSTTDet',
                                    width: 47,
                                    items: [
                                        {
                                            handler: function(view, rowIndex, colIndex, item, e) {
                                                var grid = Ext.ComponentQuery.query('#grdSTTDetails')[0];
                                                var store = Ext.getStore('StickerTransactionDet');
                                                var row = store.getAt(rowIndex).data;

                                                Ext.Msg.confirm('Confirm','के तपाई साचै डाटा हटाउन चाहनुहुन्छ?', function(btn) {
                                                    if(btn == 'yes'){

                                                        if(row.Action === "E")
                                                        {    
                                                            //alert("Deleting...");
                                                            row.Action = "D";
                                                            grid.bindStore(store);         
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
                                            },
                                            icon: '../ITS/resources/images/icons/cancel.png'
                                        }
                                    ]
                                }
                            ],
                            dockedItems: [
                                {
                                    xtype: 'toolbar',
                                    dock: 'top',
                                    width: 956,
                                    items: [
                                        {
                                            xtype: 'button',
                                            itemId: 'btnAddSTT',
                                            iconCls: 'icon-add',
                                            text: 'Add'
                                        }
                                    ]
                                }
                            ],
                            plugins: [
                                Ext.create('Ext.grid.plugin.RowEditing', {
                                    pluginId: 'grdSTTplugin',
                                    listeners: {
                                        beforeedit: {
                                            fn: me.onGridroweditingpluginBeforeEdit,
                                            scope: me
                                        },
                                        validateedit: {
                                            fn: me.onGridroweditingpluginValidateedit,
                                            scope: me
                                        }
                                    }
                                })
                            ]
                        },
                        {
                            xtype: 'hiddenfield',
                            itemId: 'hdnActionSTT',
                            fieldLabel: 'Label'
                        },
                        {
                            xtype: 'hiddenfield',
                            itemId: 'hdnTranNoSTT',
                            fieldLabel: 'Label'
                        },
                        {
                            xtype: 'hiddenfield',
                            itemId: 'hdnActSTT',
                            fieldLabel: 'Label'
                        }
                    ]
                },
                {
                    xtype: 'fieldcontainer',
                    height: 100,
                    hidden: true,
                    itemId: 'fCntRemarksSTT',
                    margin: '10 0 0 10',
                    width: 700,
                    defaults: {
                        hideLabel: true
                    },
                    fieldLabel: 'Remarks',
                    items: [
                        {
                            xtype: 'textareafield',
                            height: 100,
                            itemId: 'txtRemarksSTT',
                            width: 550,
                            fieldLabel: 'Label'
                        }
                    ]
                },
                {
                    xtype: 'fieldcontainer',
                    height: 25,
                    itemId: 'fCntBottomSTT',
                    margin: '10 0 0 0',
                    width: 968,
                    layout: {
                        align: 'stretch',
                        pack: 'end',
                        type: 'hbox'
                    },
                    items: [
                        {
                            xtype: 'button',
                            height: 10,
                            itemId: 'btnSaveSTT',
                            iconCls: 'icon-save',
                            text: 'Save'
                        },
                        {
                            xtype: 'splitter'
                        },
                        {
                            xtype: 'button',
                            itemId: 'btnEditSTT',
                            iconCls: 'icon-edit',
                            text: 'Edit'
                        },
                        {
                            xtype: 'splitter'
                        },
                        {
                            xtype: 'button',
                            itemId: 'btnDeleteSTT',
                            iconCls: 'icon-delete',
                            text: 'Delete'
                        },
                        {
                            xtype: 'splitter'
                        },
                        {
                            xtype: 'button',
                            itemId: 'btnSubmitSTT',
                            iconCls: 'icon-ok',
                            text: 'Submit'
                        },
                        {
                            xtype: 'splitter'
                        },
                        {
                            xtype: 'button',
                            itemId: 'btnCancelSTT',
                            iconCls: 'icon-cancel',
                            text: 'Cancel'
                        }
                    ]
                },
                {
                    xtype: 'fieldcontainer',
                    height: 25,
                    hidden: true,
                    itemId: 'fCntBottom2STT',
                    margin: '10 0 0 0',
                    width: 968,
                    layout: {
                        align: 'stretch',
                        pack: 'end',
                        type: 'hbox'
                    },
                    fieldLabel: '',
                    items: [
                        {
                            xtype: 'button',
                            itemId: 'btnApproveSTT',
                            iconCls: 'icon-verify',
                            text: 'Approve'
                        },
                        {
                            xtype: 'splitter'
                        },
                        {
                            xtype: 'button',
                            itemId: 'btnRejectSTT',
                            iconCls: 'icon-cancel',
                            text: 'Reject'
                        }
                    ]
                }
            ]
        });

        me.callParent(arguments);
    },

    onTxtReceivedDateSDChange: function(field, newValue, oldValue, eOpts) {
        field.validate();
    },

    onGridroweditingpluginBeforeEdit: function(editor, e, eOpts) {
        var hdnAction = Ext.ComponentQuery.query('#hdnActionSTT')[0];

        if(hdnAction.lastValue ==="IN")
        {
            return false;
        }
        else
        {
            return true;
        }

    },

    onGridroweditingpluginValidateedit: function(editor, e, eOpts) {
        var cboStickerType=Ext.ComponentQuery.query('#cboStickerTypeSTT')[0].getValue();
        //var txtStickerNoFrom=Ext.ComponentQuery.query('#txtStickerNoFromSTT')[0].getValue();

        var errMsg="";
        var errCount=0;

        if(!cboStickerType)
        {
            errCount++;
            errMsg +=errCount+") "+"कृपया स्टिकर किसिम छाल्नुहोस् !<br/>";
        }

        /*if(!txtStickerNoFrom)
        {
        errCount++;
        errMsg +=errCount+") "+"कृपया स्टिकर नं. फ्रम हाल्नुहोस् !<br/>";
        }*/

        if(errCount>0)
        {
            msg("WARNING",errMsg);    
            return false;
        }   
        e.cancel=false;
    }

});