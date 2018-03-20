/*
 * File: app/view/D03Annex6.js
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

Ext.define('MyApp.view.D03Annex6', {
    extend: 'Ext.panel.Panel',

    frame: true,
    itemId: 'pnlD03Annex6',
    width: 800,
    autoScroll: true,
    title: 'Annex-6',

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'form',
                    frame: true,
                    itemId: 'frmD03Annex6',
                    margin: 5,
                    bodyPadding: 10,
                    items: [
                        {
                            xtype: 'label',
                            height: 50,
                            margin: '0 0 0 320',
                            maxHeight: 50,
                            style: 'font-size:20px',
                            text: 'अनुसूची - ६'
                        },
                        {
                            xtype: 'panel',
                            frame: true,
                            height: 120,
                            margin: '10 0 5 0',
                            layout: {
                                columns: 1,
                                type: 'table'
                            },
                            title: ' पछाडि गएर अनुसूची तय गर्न <div id="lnkRedirectTopAnx6" style="cursor:pointer;color:red;display:inline;text-decoration:underline"><span>यहाँ कि्लक</span></div> गर्नुहोस् । ',
                            items: [
                                {
                                    xtype: 'container',
                                    itemId: 'cntTblAnx6',
                                    layout: {
                                        columns: 2,
                                        type: 'table'
                                    },
                                    items: [
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtFiscalYearAnx6',
                                            fieldLabel: 'आर्थिक वर्ष',
                                            labelWidth: 150,
                                            readOnly: true
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtIROAnx6',
                                            margin: '0 0 0 370',
                                            fieldLabel: 'आ.रा.का',
                                            value: 22,
                                            readOnly: true
                                        },
                                        {
                                            xtype: 'textfield',
                                            colspan: 2,
                                            itemId: 'txtPanAnx6',
                                            fieldLabel: 'स्थायी लेखा नम्बर',
                                            labelWidth: 150,
                                            readOnly: true
                                        },
                                        {
                                            xtype: 'textfield',
                                            colspan: 2,
                                            itemId: 'txtNameAnx6',
                                            width: 600,
                                            fieldLabel: 'नाम',
                                            labelWidth: 150,
                                            readOnly: true
                                        }
                                    ]
                                }
                            ]
                        },
                        {
                            xtype: 'gridpanel',
                            cls: '',
                            height: 1070,
                            itemId: 'grdInclusionD03Anx6',
                            margin: '0 0 5 0',
                            autoScroll: true,
                            title: 'Inclusion (IN)',
                            hideHeaders: true,
                            store: 'Annex',
                            columns: [
                                {
                                    xtype: 'gridcolumn',
                                    width: 30,
                                    sortable: false,
                                    dataIndex: 'ItemID',
                                    text: 'ID'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    renderer: function(value, metaData, record, rowIndex, colIndex, store, view) {
                                        var row = store.getAt(rowIndex).data;
                                        var desc = row.ItemDescNep + "<br>" + row.ItemDescEng ;

                                        return desc;
                                    },
                                    width: 750,
                                    text: 'ItemDescEng'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    width: 255,
                                    sortable: false,
                                    dataIndex: 'ItemValue',
                                    hideable: false,
                                    text: 'ItemValue'
                                }
                            ]
                        },
                        {
                            xtype: 'container',
                            itemId: 'cntBtnAnx6',
                            items: [
                                {
                                    xtype: 'button',
                                    itemId: 'btnSubmitAnx6',
                                    padding: 5,
                                    iconCls: 'icon-ok',
                                    text: 'Submit'
                                },
                                {
                                    xtype: 'toolbar',
                                    margin: '5 0 5 0',
                                    items: [
                                        {
                                            xtype: 'label',
                                            html: 'पछाडि गएर अनुसूची तय गर्न',
                                            text: ''
                                        },
                                        {
                                            xtype: 'label',
                                            html: '<a href="#" style="color:red"> यहाँ कि्लक  </a>',
                                            itemId: 'lblRedirectAnx6',
                                            text: 'My Label',
                                            listeners: {
                                                render: {
                                                    fn: me.onLblRedirectAnx6Render,
                                                    scope: me
                                                }
                                            }
                                        },
                                        {
                                            xtype: 'label',
                                            html: ' गर्नुहोस् । ',
                                            text: 'My Label'
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
    },

    onLblRedirectAnx6Render: function(component, eOpts) {
        var c = component;

        c.getEl().on('click', function(){ this.fireEvent('click', c); }, c);
    }

});