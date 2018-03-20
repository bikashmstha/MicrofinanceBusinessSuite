/*
 * File: app/view/StickerOrderPlacement.js
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

Ext.define('MyApp.view.StickerOrderPlacement', {
    extend: 'Ext.panel.Panel',

    frame: true,
    itemId: 'pnlSOP',
    title: 'Sticker Order Placement',

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'container',
                    itemId: 'cntTopSOP',
                    items: [
                        {
                            xtype: 'displayfield',
                            height: 25,
                            hidden: true,
                            itemId: 'lblActionSOP',
                            width: 800,
                            fieldStyle: '{color:red;}'
                        },
                        {
                            xtype: 'textfield',
                            hidden: true,
                            itemId: 'txtOrderNoSOP',
                            width: 250,
                            fieldLabel: 'Order No',
                            labelWidth: 150,
                            msgTarget: 'side',
                            allowBlank: false,
                            enableKeyEvents: true,
                            maskRe: /[0-9]/,
                            maxLength: 10
                        },
                        {
                            xtype: 'textfield',
                            itemId: 'txtOrderDateSOP',
                            width: 250,
                            fieldLabel: 'Order Date',
                            labelWidth: 150,
                            msgTarget: 'side',
                            allowBlank: false,
                            emptyText: 'YYYY.MM.DD',
                            enableKeyEvents: true
                        },
                        {
                            xtype: 'textfield',
                            itemId: 'txtExptDelDateSOP',
                            width: 250,
                            fieldLabel: 'Expected Delivery Date',
                            labelWidth: 150,
                            msgTarget: 'side',
                            emptyText: 'YYYY.MM.DD'
                        },
                        {
                            xtype: 'textfield',
                            itemId: 'txtSupplierNameSOP',
                            width: 400,
                            fieldLabel: 'Supplier Name',
                            labelWidth: 150
                        },
                        {
                            xtype: 'combobox',
                            itemId: 'cboSupplierCountrySOP',
                            width: 400,
                            fieldLabel: 'Supplier Country',
                            labelWidth: 150,
                            emptyText: '.....छान्नुहोस्.....',
                            displayField: 'CountryName',
                            forceSelection: true,
                            queryMode: 'local',
                            store: 'CountryStore',
                            typeAhead: true,
                            valueField: 'CountryCode'
                        }
                    ]
                },
                {
                    xtype: 'container',
                    itemId: 'btmContSOP',
                    margin: '10 0 0 0',
                    items: [
                        {
                            xtype: 'gridpanel',
                            height: 200,
                            itemId: 'grdStickerOrderPlacement',
                            width: 405,
                            title: 'Sticker Order Placement Details',
                            store: 'StickerOrdersDet',
                            dockedItems: [
                                {
                                    xtype: 'toolbar',
                                    dock: 'top',
                                    width: 505,
                                    items: [
                                        {
                                            xtype: 'button',
                                            itemId: 'btnAddSOP',
                                            iconCls: 'icon-add',
                                            text: 'Add'
                                        },
                                        {
                                            xtype: 'tbseparator'
                                        }
                                    ]
                                }
                            ],
                            columns: [
                                {
                                    xtype: 'gridcolumn',
                                    width: 250,
                                    dataIndex: 'StickerType',
                                    text: 'StickerType',
                                    editor: {
                                        xtype: 'combobox',
                                        itemId: 'cboStickerTypeSOP',
                                        emptyText: 'Select ---',
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
                                    dataIndex: 'Quantity',
                                    text: 'Quantity',
                                    editor: {
                                        xtype: 'textfield',
                                        itemId: 'txtQuantitySOP',
                                        maskRe: /[0-9]/
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
                                    width: 50,
                                    items: [
                                        {
                                            handler: function(view, rowIndex, colIndex, item, e) {
                                                //alert('sssss');

                                                var doIt = confirm("This change is irreversible. \n Are you sure? ");

                                                if( doIt===true)
                                                {
                                                    var str=Ext.getStore('StickerOrdersDet');
                                                    //var record=str.data.items[rowIndex].data;
                                                    // if(record.Action==="A")
                                                    //{
                                                    str.removeAt(rowIndex);
                                                    //}
                                                    //else
                                                    // { 
                                                    // record.Action="D";
                                                    //str.filter(function(item){
                                                    // return item.get('Action')!='D'

                                                    //});
                                                    //}
                                                    Ext.ComponentQuery.query('#grdStickerOrderPlacement')[0].bindStore(str);
                                                }

                                            },
                                            icon: '../ITS/resources/images/icons/cancel.png',
                                            iconCls: ''
                                        }
                                    ]
                                }
                            ],
                            plugins: [
                                Ext.create('Ext.grid.plugin.RowEditing', {
                                    pluginId: 'pluginSOP',
                                    listeners: {
                                        canceledit: {
                                            fn: me.onGridroweditingpluginCanceledit,
                                            scope: me
                                        },
                                        validateedit: {
                                            fn: me.onGridroweditingpluginValidateedit,
                                            scope: me
                                        },
                                        beforeedit: {
                                            fn: me.onGridroweditingpluginBeforeEdit,
                                            scope: me
                                        }
                                    }
                                })
                            ]
                        },
                        {
                            xtype: 'hiddenfield',
                            itemId: 'hdnActionSOP',
                            fieldLabel: 'Label'
                        },
                        {
                            xtype: 'hiddenfield',
                            itemId: 'hdnTranNoSOP',
                            fieldLabel: 'Label'
                        }
                    ]
                },
                {
                    xtype: 'fieldcontainer',
                    height: 25,
                    itemId: 'fCntActionSOP',
                    margin: '10 0 0 0',
                    width: 910,
                    layout: {
                        align: 'stretch',
                        pack: 'end',
                        type: 'hbox'
                    },
                    fieldLabel: '',
                    items: [
                        {
                            xtype: 'button',
                            itemId: 'btnSaveSOP',
                            iconCls: 'icon-save',
                            text: 'Save'
                        },
                        {
                            xtype: 'splitter'
                        },
                        {
                            xtype: 'button',
                            itemId: 'btnEditSOP',
                            iconCls: 'icon-edit',
                            text: 'Edit'
                        },
                        {
                            xtype: 'splitter'
                        },
                        {
                            xtype: 'button',
                            itemId: 'btnDeleteSOP',
                            iconCls: 'icon-delete',
                            text: 'Delete'
                        },
                        {
                            xtype: 'splitter'
                        },
                        {
                            xtype: 'button',
                            itemId: 'btnSubmitSOP',
                            iconCls: 'icon-ok',
                            text: 'Submit'
                        },
                        {
                            xtype: 'splitter'
                        },
                        {
                            xtype: 'button',
                            itemId: 'btnCancelSOP',
                            iconCls: 'icon-cancel',
                            text: 'Cancel'
                        }
                    ]
                }
            ]
        });

        me.callParent(arguments);
    },

    onGridroweditingpluginCanceledit: function(editor, e, eOpts) {
        //grid.store.removeAt(grid.rowIdx);


        var btnAddSOP=Ext.ComponentQuery.query('#btnAddSOP')[0];
        btnAddSOP.enable(true);

    },

    onGridroweditingpluginValidateedit: function(editor, e, eOpts) {
        var cboStickerTypeSOP=Ext.ComponentQuery.query('#cboStickerTypeSOP')[0];
        var txtQuantitySOP=Ext.ComponentQuery.query('#txtQuantitySOP')[0];


        var count=0;
        var message="";
        var valid=true;

        //var btnAddSOP=Ext.ComponentQuery.query('#btnAddSOP')[0];




        //if(editor.context.newValues.stickerType==="" || Number(editor.context.newValues.stickerType)===0)
        if(Number(editor.context.newValues.StickerType)===0)
        {
            valid=false;
            console.log(editor.context.newValues.StickerType);
            count++;
            message=message+count+") "+"StickerType छान्नुहोस् !<br/>" ;
            //btnAddSOP.disable(true);
        }

        else if(isNaN(editor.context.newValues.Quantity) || Number(editor.context.newValues.Quantity)===0)
        {
            valid = false;
            // cboPaymentMode.focus();
            //console.log(editor.context.newValues.PaymentMode);
            count++;
            message=message+count+") "+"Quantity छान्नुहोस् ! <br/>" ;
            // btnAddSOP.disable(true);
        }







        else
        {
            // btnAddSOP.enable(true);
            valid=true;
        }



        /*
        else
        {    
        if(Number(editor.context.newValues.AmountRetained)>Number(editor.context.newValues.Amount))
        {
        count++;
        message=message+count+") "+" पुनरावेदन गरिएको रकम भन्दा निर्णय ठहर गरिएको रकम कम हुनूपर्छ .<br/>" ;
        }
        }
        */
        e.cancel =count>0;
        if(e.cancel)
        {
            Ext.MessageBox.alert('Warning',message);
        }

    },

    onGridroweditingpluginBeforeEdit: function(editor, e, eOpts) {
        var hdnAction = Ext.ComponentQuery.query('#hdnActionSOP')[0];
        if(hdnAction.lastValue === "D")
        {
            return false;
        }
        else
        {
            return true;
        }

    }

});