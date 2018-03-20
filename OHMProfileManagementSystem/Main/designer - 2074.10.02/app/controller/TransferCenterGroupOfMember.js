/*
 * File: app/controller/TransferCenterGroupOfMember.js
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

Ext.define('MyApp.controller.TransferCenterGroupOfMember', {
    extend: 'Ext.app.Controller',

    stores: [
        'SearchMemberStore',
        'SearchGroupStore',
        'SearchCenterStore',
        'SearchCenterGroupStore'
    ],

    onDdlGrpOldMemberNoAfterRender: function(component, eOpts) {

        Ext.Ajax.request({
                    url:'../Handlers/Finance/Maintenance/MemberHandler.ashx',
                    params:{method:'GetMemberList',offCode:Ext.get('offCode').dom.innerHTML, centerCode:null, memberName:null
        },
                    success: function ( result, request ) {

                        var obj = Ext.decode(result.responseText);
                        if(obj.success === 'true'){
                            console.log("Resu",obj.root);
                            var store =Ext.getStore('SearchMemberStore');
                            store.removeAll();
                            store.add(obj.root);


                        }else{msg('FAILURE','Could Not Load Data');}
                    },
                    failure: function(form, action) {
                        msg("FAILURE","Could Not Load Data");    }
                });



    },

    onDdlGrpOldMemberNoSelect: function(combo, records, eOpts) {
        //console.log("combo",combo);
        console.log("records",records[0].data.GroupCode);
        //console.log("eOpts",eOpts);

        Ext.ComponentQuery.query('#txtGrpOldGroupName')[0].setValue(records[0].data.GroupDesc);
        Ext.ComponentQuery.query('#txtGrpOldCenterName')[0].setValue(records[0].data.CenterName);
        Ext.ComponentQuery.query('#txtGrpNewCenterName')[0].setValue(records[0].data.CenterName);

        Ext.ComponentQuery.query('#TCGMtab1')[0].ClientNo=records[0].data.ClientNo;
        Ext.ComponentQuery.query('#TCGMtab1')[0].GroupCode=records[0].data.GroupCode;

        //records[0].data.ClientNo;=;

        Ext.ComponentQuery.query('#ddlGrpNewGroupName')[0].enable();

        Ext.Ajax.request({
                    url:'../Handlers/Finance/Maintenance/GroupHandler.ashx',
                    params:{method:'GetGroupTransfer',centerCode:records[0].data.CenterCode, groupCode:records[0].data.GroupCode
        },
                    success: function ( result, request ) {

                        var obj = Ext.decode(result.responseText);
                        if(obj.success === 'true'){
                            console.log("Resu",obj.root);
                            var store =Ext.getStore('SearchGroupStore');
                            store.removeAll();
                            store.add(obj.root);


                        }else{msg('FAILURE','Could Not Load Data');}
                    },
                    failure: function(form, action) {
                        msg("FAILURE","Could Not Load Data");    }
                });


    },

    onBtnCenterTransferClick: function(button, e, eOpts) {
        /*var obj={
        		ClientNo:'010200000001',
        		OldGroupCode:'0102000101',
        		NewGroupCode: '0102006001',
        		CenterCode:'01020060',
        		UserName:'DEMO',
        		TranOfficeCode:'01020'



        };*/

        var obj={
        		ClientNo: Ext.ComponentQuery.query('#TCGMtab2')[0].ClientNo,
        		OldGroupCode:Ext.ComponentQuery.query('#TCGMtab2')[0].GroupCode,
        		NewGroupCode: Ext.ComponentQuery.query('#ddlCenNewGroupName')[0].getValue(),
        		CenterCode: Ext.ComponentQuery.query('#ddlCenNewCenterName')[0].getValue(),
        		UserName:'DEMO',
        		TranOfficeCode:Ext.get('offCode').dom.innerHTML



        };
        Ext.Ajax.request({
                    url:'../Handlers/Finance/Transaction/MemberTransaction/TransferCenterToAnotherCenterHandler.ashx',
                    params:{method:'Save',TransferCenterToAnotherCenter:JSON.stringify(obj)
        },
                    success: function ( result, request ) {

                        var obj = Ext.decode(result.responseText);
                        if(obj.success === 'true'){
                            console.log("Resu",obj.root);
                            msg("SUCCESS","Client Transfer completed successfully.");



                        }else{msg('FAILURE','Client Transfer Failed');}
                    },
                    failure: function(form, action) {
                        msg("FAILURE","Client Transfer Failed");    }
                });

    },

    onDdlCenNewCenterNameSelect: function(combo, records, eOpts) {
        Ext.ComponentQuery.query('#ddlCenNewGroupName')[0].enable();




        Ext.Ajax.request({
                    url:'../Handlers/Finance/Maintenance/GroupHandler.ashx',
                    params:{method:'GetGroupForCenterTransfer',centerCode:records[0].data.CenterCode, groupName:null
        },
                    success: function ( result, request ) {

                        var obj = Ext.decode(result.responseText);
                        if(obj.success === 'true'){
                            console.log("Resu",obj.root);
                            var store =Ext.getStore('SearchCenterGroupStore');
                            store.removeAll();
                            store.add(obj.root);



                        }else{msg('FAILURE','Could Not Load Data');}
                    },
                    failure: function(form, action) {
                        msg("FAILURE","Could Not Load Data");    }
                });
    },

    onDdlCenOldMemberNoSelect: function(combo, records, eOpts) {
        Ext.ComponentQuery.query('#txtCenOldGroupName')[0].setValue(records[0].data.GroupDesc);
        Ext.ComponentQuery.query('#txtCenOldCenterName')[0].setValue(records[0].data.CenterName);

        Ext.ComponentQuery.query('#ddlCenNewCenterName')[0].enable();

        Ext.ComponentQuery.query('#TCGMtab2')[0].ClientNo=records[0].data.ClientNo;
        Ext.ComponentQuery.query('#TCGMtab2')[0].GroupCode=records[0].data.GroupCode;



        var centerlovObj ={
            InstituteCode:Ext.get('offCode').dom.innerHTML ,
            CenterName: null,
            CenterCode:records[0].data.CenterCode
        };

        Ext.Ajax.request({
                    url:'../Handlers/Finance/Maintenance/CenterLovHandler.ashx',
                    params:{method:'GetTransferLovList',centerlov:JSON.stringify(centerlovObj)
        },
                    success: function ( result, request ) {

                        var obj = Ext.decode(result.responseText);
                        if(obj.success === 'true'){
                            console.log("Resu",obj.root);
                            var store =Ext.getStore('SearchCenterStore');
                            store.removeAll();
                            store.add(obj.root);


                        }else{msg('FAILURE','Could Not Load Data');}
                    },
                    failure: function(form, action) {
                        msg("FAILURE","Could Not Load Data");    }
                });


    },

    onDdlCenOldMemberNoAfterRender: function(component, eOpts) {

        Ext.Ajax.request({
                    url:'../Handlers/Finance/Maintenance/MemberHandler.ashx',
                    params:{method:'GetMemberList',offCode:Ext.get('offCode').dom.innerHTML, centerCode:null, memberName:null
        },
                    success: function ( result, request ) {

                        var obj = Ext.decode(result.responseText);
                        if(obj.success === 'true'){
                            console.log("Resu",obj.root);
                            var store =Ext.getStore('SearchMemberStore');
                            store.removeAll();
                            store.add(obj.root);


                        }else{msg('FAILURE','Could Not Load Data');}
                    },
                    failure: function(form, action) {
                        msg("FAILURE","Could Not Load Data");    }
                });



    },

    onBtnGroupTransferClick: function(button, e, eOpts) {
         /*  var obj={
        				ClientNo:'010200000001',
        				OldGroupCode:'0102000101',
        				NewGroupCode:'0102000102',
        				UserName:'DEMO',
        				TranOfficeCode:'01020',
        				ClientCode:'010200010101'


        				};*/

         var obj={
        				ClientNo:Ext.ComponentQuery.query('#TCGMtab1')[0].ClientNo,
        				OldGroupCode:Ext.ComponentQuery.query('#TCGMtab1')[0].GroupCode,
        				NewGroupCode:Ext.ComponentQuery.query('#ddlGrpNewGroupName')[0].getValue(),
        				UserName:'DEMO',
        				TranOfficeCode:Ext.get('offCode').dom.innerHTML,
        				//ClientCode:Ext.ComponentQuery.query('#ddlGrpOldMemberNo')[0].getValue()


        				};

        Ext.Ajax.request({
                    url:'../Handlers/Finance/Transaction/MemberTransaction/TransferWithinCenterHandler.ashx',
                    params:{method:'Save',transferwithincenter:JSON.stringify(obj)
        },
                    success: function ( result, request ) {

                        var obj = Ext.decode(result.responseText);
                        if(obj.success === 'true'){
                            console.log("Resu",obj.root);
                            msg("SUCCESS","Client Transfer completed successfully.");



                        }else{msg('FAILURE','Client Transfer Failed');}
                    },
                    failure: function(form, action) {
                        msg("FAILURE","Client Transfer Failed");    }
                });

    },

    init: function(application) {
        this.control({
            "#ddlGrpOldMemberNo": {
                afterrender: this.onDdlGrpOldMemberNoAfterRender,
                select: this.onDdlGrpOldMemberNoSelect
            },
            "#btnCenterTransfer": {
                click: this.onBtnCenterTransferClick
            },
            "#ddlCenNewCenterName": {
                select: this.onDdlCenNewCenterNameSelect
            },
            "#ddlCenOldMemberNo": {
                select: this.onDdlCenOldMemberNoSelect,
                afterrender: this.onDdlCenOldMemberNoAfterRender
            },
            "#btnGroupTransfer": {
                click: this.onBtnGroupTransferClick
            }
        });
    }

});
