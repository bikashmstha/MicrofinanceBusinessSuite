/*
 * File: app/view/SelectMemberForLoanDisbursementPopup.js
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

Ext.define('MyApp.view.SelectMemberForLoanDisbursementPopup', {
    extend: 'Ext.window.Window',

    requires: [
        'Ext.form.Panel',
        'Ext.form.field.Text',
        'Ext.button.Button',
        'Ext.grid.Panel',
        'Ext.grid.View',
        'Ext.grid.column.Column',
        'Ext.selection.RowModel'
    ],

    height: 500,
    itemId: 'SelectMemberForLoanDisbursementPopup',
    width: 700,
    autoScroll: true,
    title: 'Select Member',

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'form',
                    frame: true,
                    itemId: 'frmMemberForLoanDisbursement',
                    bodyPadding: 10,
                    title: '',
                    items: [
                        {
                            xtype: 'container',
                            layout: 'table',
                            items: [
                                {
                                    xtype: 'textfield',
                                    itemId: 'txtSearchMember',
                                    fieldLabel: 'Search'
                                },
                                {
                                    xtype: 'button',
                                    colspan: 2,
                                    itemId: 'btnSearchMember',
                                    margin: '0 0 0 5',
                                    text: 'Search',
                                    listeners: {
                                        click: {
                                            fn: me.onBtnSearchMemberClick,
                                            scope: me
                                        }
                                    }
                                }
                            ]
                        },
                        {
                            xtype: 'gridpanel',
                            itemId: 'grdSearchMember',
                            title: '',
                            store: 'MemberForLoanDisbursementStore',
                            columns: [
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'ClientCode',
                                    text: 'Client Code'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    width: 300,
                                    dataIndex: 'Name',
                                    text: 'Name'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    width: 228,
                                    dataIndex: 'Address',
                                    text: 'Address'
                                }
                            ],
                            selModel: Ext.create('Ext.selection.RowModel', {
                                listeners: {
                                    beforeselect: {
                                        fn: me.onRowModelBeforeSelect,
                                        scope: me
                                    }
                                }
                            })
                        }
                    ]
                }
            ]
        });

        me.callParent(arguments);
    },

    onBtnSearchMemberClick: function(button, e, eOpts) {
        var waitSave = watiMsg('Loading Data. Please wait ...');
        Ext.Ajax.request({
            url: '../Handlers/Finance/Transaction/StaffLoanTransaction/StaffLoanDisbursementClientHandler.ashx',
            params: {
                method:'GetStaffLoanDisClient',
                OfficeCode:getOfficeCode(),
                ClientName:Ext.ComponentQuery.query('#txtSearchMember')[0].getValue()
            },
            success: function(response){


                var obj = Ext.decode(response.responseText);


              if(obj.success === "true")
              {

                  var store=Ext.getStore('MemberForLoanDisbursementStore');
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

               Ext.ComponentQuery.query('#txtMemberCode')[0].setValue(record.data.ClientCode);
               Ext.ComponentQuery.query('#txtName')[0].setValue(record.data.Name);
               Ext.ComponentQuery.query('#txtAddress')[0].setValue(record.data.Address);


              // return true;
           }
           else
           {

           }
            var v=Ext.ComponentQuery.query('#SelectMemberForLoanDisbursementPopup')[0];

            v.close();
        });

    }

});