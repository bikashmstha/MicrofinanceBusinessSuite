/*
 * File: app/view/LoanDeductionTypes.js
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

Ext.define('MyApp.view.LoanDeductionTypes', {
    extend: 'Ext.panel.Panel',

    requires: [
        'Ext.form.Panel',
        'Ext.button.Button',
        'Ext.grid.Panel',
        'Ext.grid.View',
        'Ext.form.field.ComboBox',
        'Ext.grid.plugin.RowEditing',
        'Ext.grid.column.Action'
    ],

    height: 250,
    width: 400,
    title: 'My Panel',

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'form',
                    frame: true,
                    id: 'frmLoanDeductionTypes',
                    itemId: 'frmLoanDeductionTypes',
                    bodyPadding: 10,
                    title: '',
                    items: [
                        {
                            xtype: 'container',
                            items: [
                                {
                                    xtype: 'button',
                                    itemId: 'btnLoanDedAdd',
                                    text: 'Add'
                                },
                                {
                                    xtype: 'gridpanel',
                                    itemId: 'grdLoanDedType',
                                    title: '',
                                    store: 'LoanDeductionTypesStore',
                                    columns: [
                                        {
                                            xtype: 'gridcolumn',
                                            dataIndex: 'DeductionTypeCode',
                                            text: 'Deduction Type Code',
                                            editor: {
                                                xtype: 'textfield',
                                                itemId: 'txtDedTypeCode'
                                            }
                                        },
                                        {
                                            xtype: 'gridcolumn',
                                            width: 124,
                                            dataIndex: 'DeductionTypeDesc',
                                            text: 'Deduction Type Desc',
                                            editor: {
                                                xtype: 'textfield',
                                                itemId: 'txtDedTypeDesc'
                                            }
                                        },
                                        {
                                            xtype: 'gridcolumn',
                                            renderer: function(value, metaData, record, rowIndex, colIndex, store, view) {
                                                return "<input id='"+record.data.DeductionTypeCode+"myid'   type='checkbox'" + ((value == 'Y') ? "checked='checked'" : "") + ">";
                                                //return "<input id='"+record.data.DeductionTypeCode+"myid'   type='checkbox'" + ((value == 'Y') ? "checked='checked'" : "") + " disabled='disabled'>";
                                            },
                                            width: 191,
                                            dataIndex: 'SavingAccountDeduction',
                                            text: 'Saving Account Deduction'
                                        },
                                        {
                                            xtype: 'gridcolumn',
                                            width: 165,
                                            dataIndex: 'SavingProductCode',
                                            text: 'Saving Product Code',
                                            editor: {
                                                xtype: 'combobox',
                                                itemId: 'ddlSavingProductCode',
                                                fieldStyle: 'background-color:#DAEBE1;background-image:none;',
                                                displayField: 'ProductName',
                                                queryMode: 'local',
                                                store: 'ProductTypeStore',
                                                valueField: 'ProductCode'
                                            }
                                        },
                                        {
                                            xtype: 'gridcolumn',
                                            width: 134,
                                            dataIndex: 'SavingProductDesc',
                                            text: 'Saving Product Desc',
                                            editor: {
                                                xtype: 'textfield',
                                                itemId: 'txtSavingProductDesc',
                                                fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                            }
                                        },
                                        {
                                            xtype: 'gridcolumn',
                                            width: 165,
                                            dataIndex: 'NonExistSavingProductCode',
                                            text: 'Non Exist Saving Product Code',
                                            editor: {
                                                xtype: 'combobox',
                                                itemId: 'ddlNonExistSavingProductCode',
                                                fieldStyle: 'background-color:#DAEBE1;background-image:none;',
                                                displayField: 'ProductName',
                                                queryMode: 'local',
                                                store: 'ProductTypeStore',
                                                valueField: 'ProductCode'
                                            }
                                        },
                                        {
                                            xtype: 'gridcolumn',
                                            width: 164,
                                            dataIndex: 'NonExistSavingProductDesc',
                                            text: 'Non Exist Saving Product Desc',
                                            editor: {
                                                xtype: 'textfield',
                                                itemId: 'txtNonExistSavingProductDesc',
                                                fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                            }
                                        },
                                        {
                                            xtype: 'gridcolumn',
                                            renderer: function(value, metaData, record, rowIndex, colIndex, store, view) {
                                                return "<input id='"+record.data.DeductionTypeCode+"active'   type='checkbox'" + ((value == 'Y') ? "checked='checked'" : "") + ">";

                                                //return value=="Y" ? '<input id="chkActive" type="checkbox" checked  />':'<input type="checkbox"  />';
                                            },
                                            width: 50,
                                            dataIndex: 'ActiveFlag',
                                            text: 'Active '
                                        },
                                        {
                                            xtype: 'gridcolumn',
                                            dataIndex: 'Action',
                                            text: 'Action',
                                            editor: {
                                                xtype: 'textfield',
                                                itemId: 'txtAction'
                                            }
                                        },
                                        {
                                            xtype: 'actioncolumn',
                                            items: [
                                                {
                                                    handler: function(view, rowIndex, colIndex, item, e, record, row) {
                                                        //console.log('rowIndex',rowIndex);
                                                        //console.log('record',record);
                                                        //console.log('row',row);
                                                        //console.log('e',e);
                                                        //console.log('item',item);
                                                        //console.log('view',view);



                                                        Ext.Msg.confirm('Confirm Action', 'Do you want to Remove the selected entry?', function(btn) {
                                                            if(btn == 'yes'){

                                                                var store = Ext.getStore('LoanDeductionTypesStore');
                                                                var grd =  Ext.ComponentQuery.query('#grdLoanDedType')[0];
                                                                var row = store.getAt(rowIndex).data;

                                                                var objLoanDeductionType ={
                                                                    DeductionTypeCode:row.DeductionTypeCode,
                                                                    DeductionTypeDesc:row.DeductionTypeDesc,
                                                                    SavingProductCode:row.SavingProductCode,
                                                                    SavingAccountDeduction:row.SavingAccountDeduction,
                                                                    NonExistSavingProductCode:row.NonExistSavingProductCode,
                                                                    ActiveFlag:row.ActiveFlag,
                                                                    CreatedOn : getMisDateAD(),
                                                                    CreatedBy : getCurrentUser(),
                                                                    Action:'D'
                                                                };

                                                                var wMsg='Deleting....';

                                                                var waitSave = watiMsg(wMsg);

                                                                Ext.Ajax.request({
                                                                    url:'../Handlers/Finance/Maintenance/LoanDeductionTypeHandler.ashx',
                                                                    params:{method:'Save',loanDeductionType:JSON.stringify(objLoanDeductionType)},
                                                                    success: function ( result, request ) {
                                                                        waitSave.hide();
                                                                        var out = Ext.decode(result.responseText);
                                                                        if(out.success==='true'){
                                                                            msg("SUCCESS",out.message,function(){
                                                                                //grd.bindStore(store);
                                                                                store.removeAt(rowIndex);
                                                                            });


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



                                                                return true;
                                                            }
                                                        });

                                                    },
                                                    icon: '../ITS/resources/images/icons/delete.png'
                                                }
                                            ]
                                        }
                                    ],
                                    plugins: [
                                        Ext.create('Ext.grid.plugin.RowEditing', {
                                            listeners: {
                                                validateedit: {
                                                    fn: me.onRowEditingValidateedit,
                                                    scope: me
                                                }
                                            }
                                        })
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

    onRowEditingValidateedit: function(editor, e, eOpts) {

        var rowIndex = e.rowIdx;
        var store = Ext.getStore('LoanDeductionTypesStore');

        var idActive= store.getAt(rowIndex).data.DeductionTypeCode+"active";
        var idSavDed= store.getAt(rowIndex).data.DeductionTypeCode+"myid";
        //console.log('editor',editor);
        //console.log('e',e);
        //console.log('eOpts',eOpts);
        var objLoanDeductionType = e.record.data;

        //console.log('idSavDed',document.getElementById(idSavDed).checked);
        //console.log('idActive',document.getElementById(idActive).checked);

        objLoanDeductionType.DeductionTypeCode=Ext.ComponentQuery.query('#txtDedTypeCode')[0].getValue();
        objLoanDeductionType.DeductionTypeDesc=Ext.ComponentQuery.query('#txtDedTypeDesc')[0].getValue();
        objLoanDeductionType.SavingProductCode=Ext.ComponentQuery.query('#ddlSavingProductCode')[0].getValue();
        objLoanDeductionType.SavingAccountDeduction=document.getElementById(idSavDed).checked?"Y":"N";
        objLoanDeductionType.NonExistSavingProductCode=Ext.ComponentQuery.query('#ddlNonExistSavingProductCode')[0].getValue();

        objLoanDeductionType.ActiveFlag=document.getElementById(idActive).checked?"Y":"N";
        objLoanDeductionType.CreatedOn = getMisDateAD();
        objLoanDeductionType.CreatedBy= getCurrentUser();
        objLoanDeductionType.Action = Ext.ComponentQuery.query('#txtAction')[0].getValue();



        var waitSave = watiMsg('Saving .Please wait ...');
        Ext.Ajax.request({
            url:'../Handlers/Finance/Maintenance/LoanDeductionTypeHandler.ashx',
            params:{method:'Save',loanDeductionType:JSON.stringify(objLoanDeductionType)},
            success: function ( result, request ) {
                waitSave.hide();
                var out = Ext.decode(result.responseText);
                if(out.success==='true'){

                        msg('SUCCESS',out.message,function(){

                             var grd = Ext.ComponentQuery.query('#grdLoanDedType')[0];

                                        var record = grd.getSelectionModel().getSelection()[0];
                                        record.set('Action','U');
                    });
                }

                else{msg('FAILURE',out.message);
                       store.removeAt(rowIndex);

                    }
            },
            failure: function(form, action) {
                waitSave.hide();var out=Ext.decode(response.responseText);msg('FAILURE',out.message);     }
        });

    }

});