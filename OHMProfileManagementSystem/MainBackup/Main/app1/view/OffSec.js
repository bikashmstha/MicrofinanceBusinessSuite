/*
 * File: app/view/OffSec.js
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

Ext.define('MyApp.view.OffSec', {
    extend: 'Ext.panel.Panel',

    frame: true,
    height: 450,
    id: 'OffSec',
    itemId: 'OffSec',
    maxHeight: 450,
    minHeight: 450,
    layout: {
        align: 'stretch',
        type: 'hbox'
    },
    title: 'Office Section',

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'container',
                    flex: 1,
                    margin: '0 0 0 30',
                    items: [
                        {
                            xtype: 'gridpanel',
                            height: 300,
                            id: 'grdOffSection',
                            itemId: 'grdOffSection',
                            margin: '10 0 0 20',
                            maxHeight: 300,
                            maxWidth: 250,
                            minHeight: 300,
                            minWidth: 250,
                            width: 250,
                            autoScroll: true,
                            title: 'Office Section',
                            store: 'strOffSection',
                            columns: [
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'SectionCode',
                                    text: 'Section Code'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    minWidth: 150,
                                    defaultWidth: 150,
                                    dataIndex: 'SectionName',
                                    text: 'Section Name'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    hidden: true,
                                    dataIndex: 'OfficeCode',
                                    text: 'OfficeCode'
                                }
                            ],
                            listeners: {
                                itemclick: {
                                    fn: me.onGrdOffSectionItemClick,
                                    scope: me
                                }
                            }
                        }
                    ]
                },
                {
                    xtype: 'container',
                    flex: 1,
                    padding: '20 5 0 20',
                    items: [
                        {
                            xtype: 'combobox',
                            itemId: 'ddlOffice',
                            fieldLabel: 'Office',
                            emptyText: '-- Select Office --',
                            displayField: 'OfficeNameEnglish',
                            forceSelection: true,
                            store: 'Office',
                            valueField: 'OfficeCode',
                            listeners: {
                                select: {
                                    fn: me.onDdlOfficeSelect,
                                    scope: me
                                }
                            }
                        },
                        {
                            xtype: 'textfield',
                            itemId: 'txtSection',
                            fieldLabel: 'Section'
                        },
                        {
                            xtype: 'container',
                            items: [
                                {
                                    xtype: 'button',
                                    itemId: 'btnSubmit',
                                    margin: '20 0 0 105',
                                    iconCls: 'icon-save',
                                    text: 'Submit',
                                    listeners: {
                                        click: {
                                            fn: me.onBtnSubmitClick,
                                            scope: me
                                        }
                                    }
                                },
                                {
                                    xtype: 'button',
                                    itemId: 'btnCancel',
                                    margin: '20 0 0 10',
                                    iconCls: 'icon-cancel',
                                    text: 'Cancel',
                                    listeners: {
                                        click: {
                                            fn: me.onBtnCancelClick,
                                            scope: me
                                        }
                                    }
                                },
                                {
                                    xtype: 'hiddenfield',
                                    id: 'hiddenSecID',
                                    itemId: 'hiddenSecID',
                                    fieldLabel: 'Label'
                                },
                                {
                                    xtype: 'hiddenfield',
                                    id: 'hiddenAction',
                                    itemId: 'hiddenAction',
                                    fieldLabel: 'Label'
                                }
                            ]
                        }
                    ]
                }
            ],
            listeners: {
                afterrender: {
                    fn: me.onOffSecAfterRender,
                    scope: me
                }
            }
        });

        me.callParent(arguments);
    },

    onGrdOffSectionItemClick: function(dataview, record, item, index, e, eOpts) {
        var sectionCode=record.data.SectionCode;
        var sectionName=record.data.SectionName;
        var offCode=record.data.OfficeCode;
        Ext.ComponentQuery.query('#txtSection')[0].setValue(sectionName);



        var cmbOFF=Ext.ComponentQuery.query('#ddlOffice')[0];
        var Action=Ext.ComponentQuery.query('#hiddenAction')[0].setValue("E");
        var secCode=Ext.ComponentQuery.query('#hiddenSecID')[0].setValue(sectionCode);
        var btnSubmit = Ext.ComponentQuery.query('#btnSubmit')[0];


        var strOffice=Ext.getStore('Office');
        strOffice.removeAll();
        strOffice.loadData([],false);

        btnSubmit.setText('Edit');
        btnSubmit.setIconCls('icon-edit');


        Ext.Ajax.request
        ({

            url:'../Handlers/DocumentManagement/OffSectionHandler.ashx?method=GetOfficeName',
            params:{OfficeCode:offCode},


            success:function(response){
                console.log(response.responseText);
                var obj =Ext.decode(response.responseText);
                var row = obj.root;



                cmbOFF.setValue('');
                strOffice.removeAll();
                strOffice.loadData([],false);




                cmbOFF.store.add(obj.root);

                console.log("OFFICE--->",obj.root);
                //cmbOFF.store.add(obj.root);


                /*cmb.store.clearData(); 
                cmb.view.refresh();*/





                /*var grdDocAssign=Ext.ComponentQuery.query('#grdDocAssign')[0];

                var DocSearchStore=Ext.getStore('OfficeSection');

                DocSearchStore.removeAll();
                DocSearchStore.loadData([],false);*/

            },

            failure:function()
            {
                msg('FAILURE',Ext.decode(response));

            }



        });



    },

    onDdlOfficeSelect: function(combo, records, eOpts) {
        var offCode=Ext.ComponentQuery.query('#ddlOffice')[0].getValue();
        var txtSection=Ext.ComponentQuery.query('#txtSection')[0];
        txtSection.focus();
        /*var Action=Ext.ComponentQuery.query('#hiddenAction')[0].setValue("");*/
        Ext.Ajax.request
        ({

            url:'../Handlers/DocumentManagement/OffSectionHandler.ashx?method=GetOfficeSection',
            params:{OfficeCode:offCode},


            success:function(response){
                console.log(response.responseText);
                var obj =Ext.decode(response.responseText);
                var row = obj.root;


                console.log("Office Section--->",obj.root);

                var grid=Ext.ComponentQuery.query('#grdOffSection')[0];
                grid.store.loadData([],false);
                grid.store.add(obj.root); 


                /*var grdDocAssign=Ext.ComponentQuery.query('#grdDocAssign')[0];

                var DocSearchStore=Ext.getStore('OfficeSection');

                DocSearchStore.removeAll();
                DocSearchStore.loadData([],false);*/

            },

            failure:function()
            {
                msg('FAILURE',Ext.decode(response));

            }



        });



    },

    onBtnSubmitClick: function(button, e, eOpts) {
        var sectionCode=0;

        var records = Ext.getCmp('grdOffSection').getSelectionModel().getSelection();
        var record  = records.length === 1 ? records[0] : null;
        /*if(record!==null)
        {
        sectionCode=record.get('SectionCode');
        }*/
        if(Ext.ComponentQuery.query('#ddlOffice')[0].getValue()==='' || Ext.ComponentQuery.query('#ddlOffice')[0].getValue()===null)
        {
            msg('FAILURE','Please Select Office!!!');
            return false;
        }
        if(Ext.ComponentQuery.query('#txtSection')[0].getValue()==='')
        {
            msg('FAILURE','Please Enter Section!!!');
            return false;
        }
        if(Ext.ComponentQuery.query('#txtSection')[0].getValue().length<2 || Ext.ComponentQuery.query('#txtSection')[0].getValue().length>100)
        {
            msg('FAILURE','Please Enter Section Between 2 to 100 Character!!!');
            return false;
        }

        var offCode=Ext.ComponentQuery.query('#ddlOffice')[0].getValue();
        var SectionName=Ext.ComponentQuery.query('#txtSection')[0].getValue();

        var ActionLabel=Ext.ComponentQuery.query('#hiddenAction')[0].getValue();
        var secCode=Ext.ComponentQuery.query('#hiddenSecID')[0].getValue();
        console.log(sectionCode,SectionName,offCode,ActionLabel);


        Ext.Ajax.request
        ({

            url:'../Handlers/DocumentManagement/OffSectionHandler.ashx?method=SaveOfficeSection',
            params:{OfficeCode:offCode,SectionCode:secCode,SectionName:SectionName,Action:ActionLabel},


            success:function(response){
                console.log(response.responseText);
                var obj =Ext.decode(response.responseText);
                var row = obj.root;
                var SectionName=Ext.ComponentQuery.query('#txtSection')[0].setValue('');
                msg(obj.success === "true" ?"SUCCESS":"FAILURE",obj.message);

                var Action=Ext.ComponentQuery.query('#hiddenAction')[0].setValue("");

                console.log("Office Section--->",obj.root.count);
                msg(Ext.decode(response));
                var txtSection=Ext.ComponentQuery.query('#txtSection')[0].setValue('');
                txtSection.focus();
                Ext.ComponentQuery.query('#ddlOffice')[0].setValue('');

            },

            failure:function(response)
            {
                msg('FAILURE',Ext.decode(response));

            }



        });
        var btnSubmit = Ext.ComponentQuery.query('#btnSubmit')[0];

        btnSubmit.setText('Submit');
        btnSubmit.setIconCls('icon-save');

        /*Ext.Ajax.request
        ({

        url:'../Handlers/DocumentManagement/OffSectionHandler.ashx?method=GetOfficeSection',
        params:{OfficeCode:offCode},


        success:function(response){
        console.log(response.responseText);
        var obj =Ext.decode(response.responseText);
        var row = obj.root;


        console.log("Office Section--->",obj.root);

        var grid=Ext.ComponentQuery.query('#grdOffSection')[0];
        grid.store.loadData([],false);
        grid.store.add(obj.root); 


        },
        failure:function()
        {
        msg('FAILURE',Ext.decode(response));

        }



        });

        */



        var ddlOffices=Ext.ComponentQuery.query('#ddlOffice')[0].setValue(null);
        var txtSection=Ext.ComponentQuery.query('#txtSection')[0].setValue('');
        txtSection.focus();
        Ext.Ajax.request
        ({

            url:'../Handlers/DocumentManagement/OffSectionHandler.ashx?method=GetDefaultOfficeSection',
            params:{},


            success:function(response){
                console.log(response.responseText);
                var obj =Ext.decode(response.responseText);
                var row = obj.root;


                var GrdOffSec=Ext.ComponentQuery.query('#grdOffSection')[0];
                GrdOffSec.store.clearData(); 
                GrdOffSec.view.refresh();
                GrdOffSec.store.add(obj.root);



                var Action=Ext.ComponentQuery.query('#hiddenAction')[0].setValue("");
                var offCode=Ext.ComponentQuery.query('#hiddenSecID')[0].setValue("0");



            },

            failure:function()
            {
                msg('FAILURE',Ext.decode(response));

            }



        });



        Ext.Ajax.request
        ({

            url:'../Handlers/Common/OfficeHandler.ashx?method=GetOffices',
            params:{},


            success:function(response){
                console.log(response.responseText);
                var obj =Ext.decode(response.responseText);
                var row = obj.root;


                console.log("Office Section--->",obj.root);

                var ddlOff=Ext.ComponentQuery.query('#ddlOffice')[0];
                ddlOff.store.loadData([],false);
                ddlOff.store.add(obj.root); 




            },

            failure:function()
            {
                msg('FAILURE',Ext.decode(response));

            }



        });

    },

    onBtnCancelClick: function(button, e, eOpts) {
        var ddlOffices=Ext.ComponentQuery.query('#ddlOffice')[0].setValue(null);
        var txtSection=Ext.ComponentQuery.query('#txtSection')[0].setValue('');
        var btnSubmit = Ext.ComponentQuery.query('#btnSubmit')[0];

        btnSubmit.setText('Submit');
        btnSubmit.setIconCls('icon-save');

        txtSection.focus();
        Ext.Ajax.request
        ({

            url:'../Handlers/DocumentManagement/OffSectionHandler.ashx?method=GetDefaultOfficeSection',
            params:{},


            success:function(response){
                console.log(response.responseText);
                var obj =Ext.decode(response.responseText);
                var row = obj.root;


                var GrdOffSec=Ext.ComponentQuery.query('#grdOffSection')[0];
                GrdOffSec.store.clearData(); 
                GrdOffSec.view.refresh();
                GrdOffSec.store.add(obj.root);



                var Action=Ext.ComponentQuery.query('#hiddenAction')[0].setValue("");
                var offCode=Ext.ComponentQuery.query('#hiddenSecID')[0].setValue("0");



            },

            failure:function()
            {
                msg('FAILURE',Ext.decode(response));

            }



        });



        Ext.Ajax.request
        ({

            url:'../Handlers/Common/OfficeHandler.ashx?method=GetOffices',
            params:{},


            success:function(response){
                console.log(response.responseText);
                var obj =Ext.decode(response.responseText);
                var row = obj.root;


                console.log("Office Section--->",obj.root);

                var ddlOff=Ext.ComponentQuery.query('#ddlOffice')[0];
                ddlOff.store.loadData([],false);
                ddlOff.store.add(obj.root); 


                /*var grdDocAssign=Ext.ComponentQuery.query('#grdDocAssign')[0];

                var DocSearchStore=Ext.getStore('OfficeSection');

                DocSearchStore.removeAll();
                DocSearchStore.loadData([],false);*/

            },

            failure:function()
            {
                msg('FAILURE',Ext.decode(response));

            }



        });

    },

    onOffSecAfterRender: function(component, eOpts) {
        var offCode=Ext.ComponentQuery.query('#ddlOffice')[0].getValue();
        var GrdOffSec=Ext.ComponentQuery.query('#grdOffSection')[0];
        Ext.Ajax.request
        ({

            url:'../Handlers/DocumentManagement/OffSectionHandler.ashx?method=GetDefaultOfficeSection',
            params:{},


            success:function(response){
                console.log(response.responseText);
                var obj =Ext.decode(response.responseText);
                var row = obj.root;


                GrdOffSec.store.clearData(); 
                GrdOffSec.view.refresh();
                GrdOffSec.store.add(obj.root); 


            },

            failure:function(response)
            {
                msg('FAILURE',Ext.decode(response));

            }



        });
    }

});