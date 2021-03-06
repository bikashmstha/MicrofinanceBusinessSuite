/*
 * File: app/view/SelectGroupMemberPopup.js
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

Ext.define('MyApp.view.SelectGroupMemberPopup', {
    extend: 'Ext.window.Window',

    requires: [
        'Ext.form.field.Text',
        'Ext.button.Button',
        'Ext.grid.Panel',
        'Ext.grid.View',
        'Ext.grid.column.Column',
        'Ext.selection.RowModel'
    ],

    height: 500,
    itemId: 'SelectGroupMemberPopup',
    width: 700,
    title: 'Group Member',
    maximizable: true,
    minimizable: true,
    modal: true,

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'container',
                    layout: {
                        type: 'table',
                        columns: 2
                    },
                    items: [
                        {
                            xtype: 'textfield',
                            itemId: 'txtMemberName',
                            fieldLabel: 'Search'
                        },
                        {
                            xtype: 'button',
                            itemId: 'btnSearchGrpMem',
                            text: 'Search',
                            listeners: {
                                click: {
                                    fn: me.onBtnSearchGrpMemClick,
                                    scope: me
                                }
                            }
                        },
                        {
                            xtype: 'gridpanel',
                            colspan: 2,
                            itemId: 'grdGrpMem',
                            width: 619,
                            title: '',
                            store: 'GroupMemberStore',
                            columns: [
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'ClientNo',
                                    text: 'Member No'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    width: 258,
                                    dataIndex: 'Name',
                                    text: 'Member Name'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'CenterCode',
                                    text: 'Center Code'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    width: 160,
                                    dataIndex: 'CenterName',
                                    text: 'Center Name'
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
            ],
            listeners: {
                afterrender: {
                    fn: me.onWindowAfterRender,
                    scope: me
                }
            }
        });

        me.callParent(arguments);
    },

    onBtnSearchGrpMemClick: function(button, e, eOpts) {
        var waitSave = watiMsg('Loading Data. Please wait ...');
        Ext.Ajax.request({
            url:'../Handlers/Finance/Transaction/PublicSavingTransaction/GroupBasedMemberHandler.ashx',
            params:{method:'GetGroupBasedMem',OfficeCode : getOfficeCode(), ClientName:Ext.ComponentQuery.query('#txtMemberName')[0].getValue()
                   },
            success: function ( result, request ) {

                var obj = Ext.decode(result.responseText);
                if(obj.success === 'true'){
                    //console.log("Resu",obj.root);
                    var store =Ext.getStore('GroupMemberStore');
                    store.removeAll();
                    store.add(obj.root);
                    waitSave.hide();

                }else{msg('FAILURE','Could Not Load Data');}
            },
            failure: function(form, action) {
                msg("FAILURE","Could Not Load Data");    }
        });

    },

    onRowModelBeforeSelect: function(rowmodel, record, index, eOpts) {
        Ext.MessageBox.confirm('Select', 'Are you sure ?', function(btn){

           if(btn === 'yes'){
               //console.log(record);

               Ext.ComponentQuery.query('#txtClientNo')[0].setValue(record.data.ClientNo);
               Ext.ComponentQuery.query('#txtFirstName')[0].setValue(record.data.Fname);
               Ext.ComponentQuery.query('#txtLastName')[0].setValue(record.data.Lname);
               Ext.ComponentQuery.query('#ddlGender')[0].setValue(record.data.Gender);
               Ext.ComponentQuery.query('#txtPostalAddress')[0].setValue(record.data.PostalAddress);
               Ext.ComponentQuery.query('#txtAddress')[0].setValue(record.data.Address);
               Ext.ComponentQuery.query('#txtEmpCode')[0].setValue(record.data.EmployeeId);
               Ext.ComponentQuery.query('#txtEmpDesc')[0].setValue(record.data.EmpName);



           }

           else
           {

           }
            var v=Ext.ComponentQuery.query('#SelectGroupMemberPopup')[0];

            v.close();
        });


    },

    onWindowAfterRender: function(component, eOpts) {
        var waitSave = watiMsg('Loading Data. Please wait ...');

        Ext.Ajax.request({
            url:'../Handlers/Finance/Transaction/PublicSavingTransaction/GroupBasedMemberHandler.ashx',
            params:{method:'GetGroupBasedMem',OfficeCode : getOfficeCode(), ClientName:null
                   },
            success: function ( result, request ) {

                var obj = Ext.decode(result.responseText);
                if(obj.success === 'true'){
                    //console.log("Resu",obj.root);
                    var store =Ext.getStore('GroupMemberStore');
                    store.removeAll();
                    store.add(obj.root);
                    waitSave.hide();

                }else{msg('FAILURE','Could Not Load Data');}
            },
            failure: function(form, action) {
                msg("FAILURE","Could Not Load Data");    }
        });

    }

});