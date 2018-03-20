/*
 * File: app/view/SelectStaffLoanRepaymentLoanNumberPopup.js
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

Ext.define('MyApp.view.SelectStaffLoanRepaymentLoanNumberPopup', {
    extend: 'Ext.window.Window',

    requires: [
        'Ext.form.Panel',
        'Ext.form.field.Text',
        'Ext.button.Button',
        'Ext.grid.Panel',
        'Ext.grid.View',
        'Ext.selection.RowModel',
        'Ext.grid.column.Column'
    ],

    height: 500,
    itemId: 'SelectStaffLoanRepaymentLoanNumberPopup',
    width: 900,
    autoScroll: true,
    title: 'Select Loan No',

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'form',
                    frame: true,
                    itemId: 'frmSelectStaffLoanRepaymentLoanNumberPopup',
                    autoScroll: true,
                    bodyPadding: 10,
                    items: [
                        {
                            xtype: 'container',
                            layout: 'table',
                            items: [
                                {
                                    xtype: 'textfield',
                                    itemId: 'txtSeachLoanNumber',
                                    fieldLabel: 'Search ACC No.'
                                },
                                {
                                    xtype: 'button',
                                    colspan: 2,
                                    itemId: 'btnSearchLoanNumber',
                                    margin: '0 0 0 5',
                                    text: 'Search',
                                    listeners: {
                                        click: {
                                            fn: me.onBtnSearchSavingAccountNumberClick,
                                            scope: me
                                        }
                                    }
                                }
                            ]
                        },
                        {
                            xtype: 'gridpanel',
                            itemId: 'grdSearchLoanNumber',
                            title: '',
                            store: 'LoanNoForStaffLoanRepaymentStore',
                            selModel: Ext.create('Ext.selection.RowModel', {
                                listeners: {
                                    beforeselect: {
                                        fn: me.onRowModelBeforeSelect,
                                        scope: me
                                    }
                                }
                            }),
                            columns: [
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'LoanNo',
                                    text: 'Loan No'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'LoanDno',
                                    text: 'Loan Dno'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'ClientDesc',
                                    text: 'Client Desc'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'EmployeeId',
                                    text: 'Employee Id'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'ClientCode',
                                    text: 'Client Code'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'ClientNo',
                                    text: 'Client No'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    width: 141,
                                    dataIndex: 'LoanProductName',
                                    text: 'Loan Product Name'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'LoanProductCode',
                                    text: 'Loan Product Code'
                                }
                            ]
                        }
                    ],
                    listeners: {
                        afterrender: {
                            fn: me.onFrmSelectVdcPopupAfterRender,
                            scope: me
                        }
                    }
                }
            ]
        });

        me.callParent(arguments);
    },

    onBtnSearchSavingAccountNumberClick: function(button, e, eOpts) {
        var productcode=Ext.ComponentQuery.query('#ddlLoanProduct')[0].getValue();
        var waitSave = watiMsg('Loading Data. Please wait ...');

            Ext.Ajax.request({
            url: '../Handlers/Finance/Transaction/StaffLoanTransaction/StaffLoanRepayLoanHandler.ashx',
            params: {
                method:'GetStaffLoanRepayLoan',
                OfficeCode:getOfficeCode(),
                ProductCode:productcode,
                ClientName:null,

            },
            success: function(response){


                var obj = Ext.decode(response.responseText);



                if(obj.success === "true")
                {

                    var store=Ext.getStore('LoanNoForStaffLoanRepaymentStore');
                    store.removeAll();
                    store.add(obj.root);


                }
                else
                {
                    msg("FAILURE",obj.message);
                }

                waitSave.hide();
            }
        });


    },

    onRowModelBeforeSelect: function(rowmodel, record, index, eOpts) {
        Ext.MessageBox.confirm('Select', 'Are you sure ?', function(btn){

           if(btn === 'yes'){
               console.log('record',record);

               Ext.ComponentQuery.query('#txtLoanNo')[0].setValue(record.data.LoanDno);
              // Ext.ComponentQuery.query('#txtMemberName')[0].setValue(record.data.ClientDesc);
               Ext.ComponentQuery.query('#hdnLoanNo')[0].setValue(record.data.LoanNo);



              // return true;
           }
           else
           {

           }
            var v=Ext.ComponentQuery.query('#SelectStaffLoanRepaymentLoanNumberPopup')[0];

            v.close();
        });

    },

    onFrmSelectVdcPopupAfterRender: function(component, eOpts) {
        var store=Ext.getStore('LoanNoForStaffLoanRepaymentStore');
        store.removeAll();
    }

});