/*
 * File: app/view/CompulsoryAccountEntry.js
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

Ext.define('MyApp.view.CompulsoryAccountEntry', {
    extend: 'Ext.panel.Panel',

    requires: [
        'Ext.form.Panel',
        'Ext.form.field.ComboBox',
        'Ext.form.field.Checkbox',
        'Ext.button.Button',
        'Ext.grid.Panel',
        'Ext.grid.View',
        'Ext.grid.column.Action',
        'Ext.panel.Tool'
    ],

    frame: true,
    title: 'Compulsary Account Entry',

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'form',
                    clear: function() {




                        Ext.ComponentQuery.query("#frmCompulsaryAccountEntry")[0].getForm().reset();



                    },
                    frame: true,
                    id: 'frmCompulsaryAccountEntry',
                    itemId: 'frmCompulsaryAccountEntry',
                    bodyPadding: 10,
                    layout: {
                        type: 'table',
                        columns: 2
                    },
                    items: [
                        {
                            xtype: 'textfield',
                            itemId: 'txtSymbolNo',
                            fieldLabel: 'Symbol No',
                            labelWidth: 150,
                            fieldStyle: 'background-color:#D2D2D2;background-image:none;',
                            readOnly: true,
                            size: 40
                        },
                        {
                            xtype: 'combobox',
                            itemId: 'ddlProductType',
                            style: {
                                marginLeft: '40px'
                            },
                            fieldLabel: 'Product Type',
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
                            itemId: 'txtCompulsoryAccDesc',
                            fieldLabel: 'Compulsary Account Desc',
                            labelWidth: 150,
                            size: 40
                        },
                        {
                            xtype: 'checkboxfield',
                            itemId: 'chkActive',
                            style: {
                                marginLeft: '40px'
                            },
                            fieldLabel: 'Active',
                            boxLabel: ''
                        },
                        {
                            xtype: 'combobox',
                            colspan: 2,
                            itemId: 'ddlSavingProductCode',
                            fieldLabel: 'Saving Product Code',
                            labelWidth: 150,
                            emptyText: '---SELECT---',
                            size: 40,
                            displayField: 'ProductName',
                            forceSelection: true,
                            queryMode: 'local',
                            store: 'ProductTypeStore',
                            valueField: 'ProductCode'
                        },
                        {
                            xtype: 'container',
                            colspan: 2,
                            height: 40,
                            layout: 'table',
                            suspendLayout: true,
                            items: [
                                {
                                    xtype: 'button',
                                    itemId: 'btnCreateCompulsaryAcc',
                                    margin: 10,
                                    text: ' Create Compulsary Account'
                                },
                                {
                                    xtype: 'button',
                                    hidden: true,
                                    itemId: 'btnUpdateCompulsoryAcc',
                                    text: 'Update Compulsory Account'
                                },
                                {
                                    xtype: 'button',
                                    hidden: true,
                                    itemId: 'btnDeleteCompulsoryAcc',
                                    margin: '0 0 0 5',
                                    text: 'Delete Compulsory Account'
                                }
                            ]
                        },
                        {
                            xtype: 'gridpanel',
                            colspan: 2,
                            itemId: 'grdCompulsaryAccDetails',
                            width: 859,
                            title: 'Compulsary Account Details :',
                            store: 'CompulsaryAccountDetailsStore',
                            columns: [
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'CompulsoryAccountCode',
                                    text: 'Symbol No'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    width: 169,
                                    dataIndex: 'CompulsoryAccountDesc',
                                    text: 'Account Description'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    width: 227,
                                    dataIndex: 'ProductName',
                                    text: 'Product Name'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    width: 172,
                                    dataIndex: 'ProductType',
                                    text: 'Saving Product Type'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'ActiveFlag',
                                    text: 'Is Active'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'Action',
                                    text: 'Action'
                                },
                                {
                                    xtype: 'actioncolumn',
                                    icon: '',
                                    items: [
                                        {
                                            handler: function(view, rowIndex, colIndex, item, e, record, row) {
                                                Ext.ComponentQuery.query('#grdCompulsaryAccDetails')[0].index = rowIndex;
                                                Ext.ComponentQuery.query('#grdCompulsaryAccDetails')[0].getSelectionModel().select(rowIndex);
                                                //get reference of store
                                                var store = Ext.getStore('CompulsaryAccountDetailsStore');

                                                //get selected row using rowindex
                                                var row = store.getAt(rowIndex).data;


                                                // set values

                                                console.log('row',row);

                                                Ext.ComponentQuery.query('#txtSymbolNo')[0].setValue(row.CompulsoryAccountCode);
                                                Ext.ComponentQuery.query('#ddlProductType')[0].setValue(row.ProductType);
                                                Ext.ComponentQuery.query('#txtCompulsoryAccDesc')[0].setValue(row.CompulsoryAccountDesc);
                                                Ext.ComponentQuery.query('#chkActive')[0].setValue(row.ActiveFlag=='Y'?true:false);
                                                Ext.ComponentQuery.query('#ddlSavingProductCode')[0].setValue(row.ProductCode);


                                                Ext.ComponentQuery.query('#btnUpdateCompulsoryAcc')[0].setVisible(true);
                                                Ext.ComponentQuery.query('#btnDeleteCompulsoryAcc')[0].setVisible(true);
                                                Ext.ComponentQuery.query('#btnCreateCompulsaryAcc')[0].setVisible(false);

                                            },
                                            icon: '../ITS/resources/images/icons/Modify.png'
                                        }
                                    ]
                                }
                            ]
                        }
                    ]
                }
            ],
            tools: [
                {
                    xtype: 'tool',
                    handler: function(event, toolEl, owner, tool) {
                        Ext.MessageBox.confirm('Reset Form', 'Are you sure ?', function(btn){


                            if(btn === 'yes'){
                                var frm= Ext.ComponentQuery.query('#frmCompulsaryAccountEntry')[0].getForm();
                                frm.clear();
                            }
                            else
                            {

                            }

                        });


                    },
                    cls: 'popupTool'
                }
            ]
        });

        me.callParent(arguments);
    }

});