/*
 * File: app/controller/DocLoc.js
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

Ext.define('MyApp.controller.DocLoc', {
    extend: 'Ext.app.Controller',

    models: [
        'Office'
    ],
    stores: [
        'Office',
        'strDMlBuilding',
        'strDMRoom',
        'strDMRack'
    ],
    views: [
        'DocLoc'
    ],

    onCboOfficeSelect: function(combo, records, eOpts) {

        console.log("records--?",records);


        Ext.ComponentQuery.query('#txtBuildingId')[0].setValue('');
        Ext.ComponentQuery.query('#txtBuilding')[0].setValue('');
        Ext.ComponentQuery.query('#txtRoomNo')[0].setValue('');
        Ext.ComponentQuery.query('#txtRoomDesc')[0].setValue('');
        Ext.ComponentQuery.query('#txtRackNo')[0].setValue('');
        Ext.ComponentQuery.query('#txtRackDesc')[0].setValue('');
        Ext.ComponentQuery.query('#btnUpdateBuilding')[0].hide(true);
        Ext.ComponentQuery.query('#btnUpdateRoom')[0].hide(true);  
        Ext.ComponentQuery.query('#btnUpdateRack')[0].hide(true);


        Ext.ComponentQuery.query('#txtBuildingId')[0].setReadOnly(false);
        Ext.ComponentQuery.query('#txtRoomNo')[0].setReadOnly(false);
        Ext.ComponentQuery.query('#txtRackNo')[0].setReadOnly(false);




        var cboOffice=Ext.ComponentQuery.query('#cboOffice')[0].getValue();

        var grdBuilding=Ext.ComponentQuery.query('#grdBuilding')[0];

        Ext.ComponentQuery.query('#hdnOffcode')[0].setValue(cboOffice);

        Ext.Ajax.request
        ({

            url:'../Handlers/DocumentManagement/BuildingHandler.ashx?method=GetBuilding',
            params:{offcode:cboOffice
            },


            success:function(response){
                console.log(response.responseText);
                var obj =Ext.decode(response.responseText);
                var row = obj.root;

                var strBuilding=Ext.getStore('strDMlBuilding');
                var strDMRoom=Ext.getStore('strDMRoom');
                var strDMRack=Ext.getStore('strDMRack');


                Ext.ComponentQuery.query('#txtBuildingId')[0].show(true);
                Ext.ComponentQuery.query('#txtBuilding')[0].show(true);





                strBuilding.removeAll();
                strBuilding.loadData([],false);

                strDMRoom.removeAll();
                strDMRoom.loadData([],false);

                strDMRack.removeAll();
                strDMRack.loadData([],false);

                console.log("row>>>>",obj.root);
                grdBuilding.store.add(obj.root); 

            },

            failure:function()
            {
                msg('FAILURE',Ext.decode(response));

            }



        });


    },

    onGrdBuildingItemClick: function(dataview, record, item, index, e, eOpts) {

        console.log("record-->>",record);
        var offcode=record.data.OFFCODE;
        var buildingid=record.data.BUILDING_ID;


        var strDMRoom=Ext.getStore('strDMRoom');
        var strDMRack=Ext.getStore('strDMRack');

        strDMRoom.removeAll();
        strDMRoom.loadData([],false);

        strDMRack.removeAll();
        strDMRack.loadData([],false);

        Ext.ComponentQuery.query('#hdnOffcode')[0].setValue(record.data.OFFCODE);
        Ext.ComponentQuery.query('#txtBuildingId')[0].setValue(record.data.BUILDING_ID);
        var grdBuilding=Ext.ComponentQuery.query('#txtBuilding')[0].setValue(record.data.BUILDING_DESC);


        var grdRoom=Ext.ComponentQuery.query('#grdRoom')[0];


        Ext.Ajax.request
        ({

            url:'../Handlers/DocumentManagement/RoomHandler.ashx?method=GetRooms',
            params:{offcode: offcode,buildingId:buildingid
            },


            success:function(response){
                console.log(response.responseText);
                var obj =Ext.decode(response.responseText);
                var row = obj.root;




                Ext.ComponentQuery.query('#hdnAction')[0].setValue('E');


                Ext.ComponentQuery.query('#txtBuildingId')[0].show(true);
                Ext.ComponentQuery.query('#txtBuilding')[0].show(true);


                Ext.ComponentQuery.query('#txtRoomNo')[0].show(true);
                Ext.ComponentQuery.query('#txtRoomDesc')[0].show(true);


                console.log("row>>>>",obj.root);
                //console.log("row",obj.root);
                grdRoom.store.add(obj.root); 


                Ext.ComponentQuery.query('#btnUpdateBuilding')[0].show(true);

                Ext.ComponentQuery.query('#txtBuildingId')[0].setReadOnly(true);





            },

            failure:function()
            {
                msg('FAILURE',Ext.decode(response));

            }



        });


    },

    onGrdRoomItemClick: function(dataview, record, item, index, e, eOpts) {

        console.log("record-->>",record);
        var offcode=record.data.OFFCODE;
        var buildingid=record.data.BUILDING_ID;
        console.log("BuildingId-->>",buildingid);
        var roomno=record.data.ROOM_NO;
        var rackno=record.data.RACK_NO;


        var grdBuildingid=Ext.ComponentQuery.query('#txtRoomNo')[0].setValue(record.data.ROOM_NO);
        var grdBuilding=Ext.ComponentQuery.query('#txtRoomDesc')[0].setValue(record.data.ROOM_DESC);
        var grdRack=Ext.ComponentQuery.query('#grdRack')[0];


        Ext.Ajax.request
        ({

            url:'../Handlers/DocumentManagement/RackHandler.ashx?method=GetRack',
            params:{offcode: offcode,buildingid:buildingid,roomno:roomno,rackid:""
            },


            success:function(response){
                console.log(response.responseText);
                var obj =Ext.decode(response.responseText);
                var row = obj.root;


                var strDMRack=Ext.getStore('strDMRack');            

                strDMRack.removeAll();
                strDMRack.loadData([],false);



                console.log("row>>>>",obj.root);
                //console.log("row",obj.root);
                grdRack.store.add(obj.root); 


                Ext.ComponentQuery.query('#btnUpdateRoom')[0].show(true);        
                Ext.ComponentQuery.query('#txtRoomNo')[0].setReadOnly(true);
                Ext.ComponentQuery.query('#hdnActionRoom')[0].setValue('E');

                Ext.ComponentQuery.query('#txtBuildingId')[0].show(true);
                Ext.ComponentQuery.query('#txtBuilding')[0].show(true);


                Ext.ComponentQuery.query('#txtRoomNo')[0].show(true);
                Ext.ComponentQuery.query('#txtRoomDesc')[0].show(true);

                Ext.ComponentQuery.query('#txtRackNo')[0].show(true);
                Ext.ComponentQuery.query('#txtRackDesc')[0].show(true);

            },

            failure:function()
            {
                msg('FAILURE',Ext.decode(response));

            }



        });


    },

    onGrdRackItemClick: function(dataview, record, item, index, e, eOpts) {

        console.log("record-->>",record);
        var offcode=record.data.OFFCODE;
        var buildingid=record.data.BUILDING_ID;
        var roomno=record.data.ROOM_NO;
        var rackno=record.data.RACK_NO;



        var grdBuildingid=Ext.ComponentQuery.query('#txtRackNo')[0].setValue(record.data.RACK_NO);
        var grdBuilding=Ext.ComponentQuery.query('#txtRackDesc')[0].setValue(record.data.RACK_DESC);
        var grdRack=Ext.ComponentQuery.query('#grdRack')[0];

        Ext.ComponentQuery.query('#btnUpdateRack')[0].show(true);
        Ext.ComponentQuery.query('#txtRackNo')[0].setReadOnly(true);

        Ext.ComponentQuery.query('#hdnActionRack')[0].setValue('E');


        /*
        Ext.Ajax.request
        ({

        url:'../Handlers/DocumentManagement/RackHandler.ashx?method=GetRack',
        params:{offcode:offcode,buildingid:buildingid,roomno:roomno,rackid:rackno
        },


        success:function(response){
        console.log(response.responseText);
        var obj =Ext.decode(response.responseText);
        var row = obj.root;


        var strDMRack=Ext.getStore('strDMRack');            

        strDMRack.removeAll();
        strDMRack.loadData([],false);

        console.log("row>>>>",obj.root);
        //console.log("row",obj.root);
        grdRack.store.add(obj.root); 

    },

    failure:function()
    {
        msg('FAILURE',Ext.decode(response));

    }



    });
    */
    },

    onBtnSubmitDLClick: function(button, e, eOpts) {

        var me=this;

        var cboOffice=Ext.ComponentQuery.query('#cboOffice')[0];
        var strDMlBuilding=Ext.getStore('strDMlBuilding');
        //grdSADone.clearFilter();

        if(strDMlBuilding.getCount() < 1)
        {
            msg("WARNING","Please select Office !!!",function(){cboOffice.focus();});
            return; 
        }





        var offcode=Ext.ComponentQuery.query('#hdnOffcode')[0];
        var buildingid=Ext.ComponentQuery.query('#hdnBuildingid')[0].getValue();
        var buildingdesc=Ext.ComponentQuery.query('#txtBuilding')[0].getValue();
        var txtBuildingId=Ext.ComponentQuery.query('#txtBuildingId')[0].getValue();

        var txtRoomNo=Ext.ComponentQuery.query('#txtRoomNo')[0].getValue();
        var txtRoomDesc=Ext.ComponentQuery.query('#txtRoomDesc')[0].getValue();

        var txtRackNo=Ext.ComponentQuery.query('#txtRackNo')[0].getValue();
        var txtRackDesc=Ext.ComponentQuery.query('#txtRackDesc')[0].getValue();





        var building="";
        var room="";
        var rack="";

        rack={
            OFFCODE:offcode.getValue()===""?null:offcode.getValue(),
            BUILDING_ID:txtBuildingId,
            ROOM_NO:txtRoomNo,
            RACK_NO:txtRackNo,
            RACK_DESC:txtRackDesc,
            ENTRY_BY:"",
            ENTRY_DATE:"",
            Status:'',
            Action:Ext.ComponentQuery.query('#hdnAction')[0].getValue()
        };

        room={
            OFFCODE:offcode.getValue()===""?null:offcode.getValue(),       
            BUILDING_ID:txtBuildingId,
            ROOM_NO:txtRoomNo,
            ROOM_DESC:txtRoomDesc,
            ENTRY_BY:"",
            ENTRY_DATE:"",
            STATUS:'',
            Action:Ext.ComponentQuery.query('#hdnActionRoom')[0].getValue()
        };

        building={

            OFFCODE:offcode.getValue()===""?null:offcode.getValue(),       
            BUILDING_ID:txtBuildingId, 
            BUILDING_DESC:buildingdesc,
            ENTRY_BY:"",        
            ENTRY_DATE:"",
            Room:room,
            Rack:rack,
            Action:Ext.ComponentQuery.query('#hdnAction')[0].getValue()

        };
        //----------------------------

        //-------------------
        var storeBuilding=Ext.getStore('strDMlBuilding');
        var storeDMRoom=Ext.getStore('strDMRoom');
        var strDMRack=Ext.getStore('strDMRack');



        Ext.Ajax.request({

            url:'../Handlers/DocumentManagement/BuildingHandler.ashx?method=SaveBuilding',
            params:{building:JSON.stringify(building)},


            success:function(result,request){
                var obj=Ext.decode(result.responseText);




                msg(obj.success === "true" ?"SUCCESS":"FAILURE",obj.message);





                /*
                var str=Ext.getStore('strDMRoom');
                str.loadData([],false);


                var rowBuilding = {

                OFFCODE:Ext.ComponentQuery.query('#hdnOffcode')[0].getValue(),
                BUILDING_ID:txtBuildingId, 
                BUILDING_DESC:buildingdesc,
                ENTRY_BY:"",        
                ENTRY_DATE:""


                };




                var rowRack = {

                OFFCODE:Ext.ComponentQuery.query('#hdnOffcode')[0].getValue(), 
                BUILDING_ID:txtBuildingId, 
                ROOM_NO:txtRoomNo, 
                RACK_NO:txtRackNo, 
                RACK_DESC:txtRackDesc, 
                ENTRY_BY:'', 
                ENTRY_DATE:'', 
                Status:'' 

                };

                storeBuilding.add(rowBuilding); 

                strDMRack.add(rowRack); 


                */


                var rowRoom = {
                    OFFCODE:Ext.ComponentQuery.query('#hdnOffcode')[0].getValue(),
                    BUILDING_ID:txtBuildingId,        
                    ROOM_NO:txtRoomNo,
                    ROOM_DESC:txtRoomDesc,
                    ENTRY_BY:'',
                    ENTRY_DATE:''     

                };
                storeDMRoom.add(rowRoom); 


                // Ext.ComponentQuery.query('#hdnActionRefund')[0].setValue('');
                // me.clearControlsRefund();


            },
            failure:function(result, request){
                msg('ERROR OCURRED !!!', 'Error');                 
            }


        });

    },

    onBtnUpdateBuildingClick: function(button, e, eOpts) {

        var me=this;


        if(Ext.ComponentQuery.query('#BtnSubmitDL')[0].getText()=="Edit")
        {
            Ext.ComponentQuery.query('#hdnAction')[0].setValue('E');

        }
        else
        {
            Ext.ComponentQuery.query('#hdnAction')[0].setValue('');
        }





        var offcode=Ext.ComponentQuery.query('#hdnOffcode')[0];
        var buildingid=Ext.ComponentQuery.query('#hdnBuildingid')[0].getValue();
        var buildingdesc=Ext.ComponentQuery.query('#txtBuilding')[0].getValue();
        var txtBuildingId=Ext.ComponentQuery.query('#txtBuildingId')[0].getValue();

        var txtRoomNo=Ext.ComponentQuery.query('#txtRoomNo')[0].getValue();
        var txtRoomDesc=Ext.ComponentQuery.query('#txtRoomDesc')[0].getValue();

        var txtRackNo=Ext.ComponentQuery.query('#txtRackNo')[0].getValue();
        var txtRackDesc=Ext.ComponentQuery.query('#txtRackDesc')[0].getValue();





        var building="";
        var room="";
        var rack="";





        building={

            OFFCODE:offcode.getValue()===""?null:offcode.getValue(),       
            BUILDING_ID:txtBuildingId, 
            BUILDING_DESC:buildingdesc,
            ENTRY_BY:"",        
            ENTRY_DATE:"",   
            Action:Ext.ComponentQuery.query('#hdnAction')[0].getValue()

        };
        //----------------------------

        //-------------------
        var store=Ext.getStore('strDMlBuilding');
        Ext.Ajax.request({

            url:'../Handlers/DocumentManagement/BuildingHandler.ashx?method=UpdateBuilding',
            params:{building:JSON.stringify(building)},


            success:function(result,request){
                var obj=Ext.decode(result.responseText);
                msg(obj.success === "true" ?"SUCCESS":"FAILURE",obj.message);


                var row = {


                    BUILDING_ID:txtBuildingId, 
                    BUILDING_DESC:buildingdesc,
                    ENTRY_BY:"",        
                    ENTRY_DATE:""


                };

                store.add(row);        



                // Ext.ComponentQuery.query('#hdnActionRefund')[0].setValue('');
                // me.clearControlsRefund();


            },
            failure:function(result, request){
                msg('ERROR OCURRED !!!', 'Error');                 
            }


        });

    },

    onBtnUpdateRoomClick: function(button, e, eOpts) {

        var me=this;


        if(Ext.ComponentQuery.query('#BtnSubmitDL')[0].getText()=="Edit")
        {
            Ext.ComponentQuery.query('#hdnAction')[0].setValue('E');

        }
        else
        {
            Ext.ComponentQuery.query('#hdnAction')[0].setValue('');
        }





        var offcode=Ext.ComponentQuery.query('#hdnOffcode')[0];
        var buildingid=Ext.ComponentQuery.query('#hdnBuildingid')[0].getValue();
        var buildingdesc=Ext.ComponentQuery.query('#txtBuilding')[0].getValue();
        var txtBuildingId=Ext.ComponentQuery.query('#txtBuildingId')[0].getValue();

        var txtRoomNo=Ext.ComponentQuery.query('#txtRoomNo')[0].getValue();
        var txtRoomDesc=Ext.ComponentQuery.query('#txtRoomDesc')[0].getValue();

        var txtRackNo=Ext.ComponentQuery.query('#txtRackNo')[0].getValue();
        var txtRackDesc=Ext.ComponentQuery.query('#txtRackDesc')[0].getValue();






        var room="";




        room={
            OFFCODE:offcode.getValue()===""?null:offcode.getValue(),       
            BUILDING_ID:txtBuildingId,
            ROOM_NO:txtRoomNo,
            ROOM_DESC:txtRoomDesc,
            ENTRY_BY:"",
            ENTRY_DATE:"",
            STATUS:'',
            Action:Ext.ComponentQuery.query('#hdnAction')[0].getValue()
        };


        //----------------------------

        //-------------------
        var store=Ext.getStore('strDMlBuilding');
        Ext.Ajax.request({

            url:'../Handlers/DocumentManagement/RoomHandler.ashx?method=UpdateRoom',
            params:{room:JSON.stringify(room)},


            success:function(result,request){
                var obj=Ext.decode(result.responseText);
                msg(obj.success === "true" ?"SUCCESS":"FAILURE",obj.message);


                var row = {


                    //BUILDING_ID:txtBuildingId, 
                    //BUILDING_DESC:buildingdesc,
                    // ENTRY_BY:"",        
                    //ENTRY_DATE:""


                };

                store.add(row);        



                // Ext.ComponentQuery.query('#hdnActionRefund')[0].setValue('');
                // me.clearControlsRefund();


            },
            failure:function(result, request){
                msg('ERROR OCURRED !!!', 'Error');                 
            }


        });

    },

    onBtnUpdateRackClick: function(button, e, eOpts) {

        var me=this;


        if(Ext.ComponentQuery.query('#BtnSubmitDL')[0].getText()=="Edit")
        {
            Ext.ComponentQuery.query('#hdnAction')[0].setValue('E');

        }
        else
        {
            Ext.ComponentQuery.query('#hdnAction')[0].setValue('');
        }





        var offcode=Ext.ComponentQuery.query('#hdnOffcode')[0];
        var buildingid=Ext.ComponentQuery.query('#hdnBuildingid')[0].getValue();
        var buildingdesc=Ext.ComponentQuery.query('#txtBuilding')[0].getValue();
        var txtBuildingId=Ext.ComponentQuery.query('#txtBuildingId')[0].getValue();

        var txtRoomNo=Ext.ComponentQuery.query('#txtRoomNo')[0].getValue();
        var txtRoomDesc=Ext.ComponentQuery.query('#txtRoomDesc')[0].getValue();

        var txtRackNo=Ext.ComponentQuery.query('#txtRackNo')[0].getValue();
        var txtRackDesc=Ext.ComponentQuery.query('#txtRackDesc')[0].getValue();







        var rack="";

        rack={
            OFFCODE:offcode.getValue()===""?null:offcode.getValue(),
            BUILDING_ID:txtBuildingId,
            ROOM_NO:txtRoomNo,
            RACK_NO:txtRackNo,
            RACK_DESC:txtRackDesc,
            ENTRY_BY:"",
            ENTRY_DATE:"",
            Status:'',
            Action:Ext.ComponentQuery.query('#hdnAction')[0].getValue()
        };




        //----------------------------

        //-------------------
        var store=Ext.getStore('strDMlBuilding');
        Ext.Ajax.request({

            url:'../Handlers/DocumentManagement/RackHandler.ashx?method=UpdateRack',
            params:{rack:JSON.stringify(rack)},


            success:function(result,request){
                var obj=Ext.decode(result.responseText);
                msg(obj.success === "true" ?"SUCCESS":"FAILURE",obj.message);


                var row = {


                    //BUILDING_ID:txtBuildingId, 
                    //BUILDING_DESC:buildingdesc,
                    //ENTRY_BY:"",        
                    //ENTRY_DATE:""


                };

                store.add(row);        



                // Ext.ComponentQuery.query('#hdnActionRefund')[0].setValue('');
                // me.clearControlsRefund();


            },
            failure:function(result, request){
                msg('ERROR OCURRED !!!', 'Error');                 
            }


        });

    },

    onCboTestAfterRender: function(component, eOpts) {
        Ext.ComponentQuery.query('#btnUpdateBuilding')[0].hide(true);
        Ext.ComponentQuery.query('#btnUpdateRoom')[0].hide(true);
        Ext.ComponentQuery.query('#btnUpdateRack')[0].hide(true);


        var storeBuilding=Ext.getStore('strDMlBuilding');
        var storeDMRoom=Ext.getStore('strDMRoom');
        var strDMRack=Ext.getStore('strDMRack');

        storeBuilding.loadData([],false);
        storeDMRoom.loadData([],false);
        strDMRack.loadData([],false);


        Ext.ComponentQuery.query('#txtBuildingId')[0].setValue('');
        Ext.ComponentQuery.query('#txtBuilding')[0].setValue('');
        Ext.ComponentQuery.query('#txtRoomNo')[0].setValue('');
        Ext.ComponentQuery.query('#txtRoomDesc')[0].setValue('');
        Ext.ComponentQuery.query('#txtRackNo')[0].setValue('');
        Ext.ComponentQuery.query('#txtRackDesc')[0].setValue('');
        Ext.ComponentQuery.query('#btnUpdateBuilding')[0].hide(true);
        Ext.ComponentQuery.query('#btnUpdateRoom')[0].hide(true);  
        Ext.ComponentQuery.query('#btnUpdateRack')[0].hide(true);


        Ext.ComponentQuery.query('#hdnAction')[0].setValue('');
        Ext.ComponentQuery.query('#hdnActionRoom')[0].setValue('');
        Ext.ComponentQuery.query('#hdnActionRack')[0].setValue('');

        Ext.ComponentQuery.query('#txtBuildingId')[0].hide(true);
        Ext.ComponentQuery.query('#txtBuilding')[0].hide(true);


        Ext.ComponentQuery.query('#txtRoomNo')[0].hide(true);
        Ext.ComponentQuery.query('#txtRoomDesc')[0].hide(true);

        Ext.ComponentQuery.query('#txtRackNo')[0].hide(true);
        Ext.ComponentQuery.query('#txtRackDesc')[0].hide(true);
    },

    onGrdRoomBeforeRender: function(component, eOpts) {
        /*

        var grid=Ext.ComponentQuery.query('#grdRoom')[0];



        grid.columns[3].renderer = function(value, metaData, record, rowIndex, colIndex, store, view) {
        var temp="";    

        console.log("value-->",value);
        var items = Ext.getStore('strDMRoom').data.items;

        //console.log("bankInfo",items);
        // alert("value>>"+value);

        //alert("len " + items.length);
        for(var i=0;i<items.length;i++)
        {  
            //alert("bank>>" + items[i].data.BankBr);
            if(items[i].data.ROOM_DESC === value)
            {   

                //temp=items[i].data.BankName;
                alert('user already exists');

                break;
            }        
        }

        //alert("temP>>" +temp);
        return temp;

    };



    */
    },

    init: function(application) {
        this.control({
            "#cboOffice": {
                select: this.onCboOfficeSelect
            },
            "#grdBuilding": {
                itemclick: this.onGrdBuildingItemClick
            },
            "#grdRoom": {
                itemclick: this.onGrdRoomItemClick,
                beforerender: this.onGrdRoomBeforeRender
            },
            "#grdRack": {
                itemclick: this.onGrdRackItemClick
            },
            "#BtnSubmitDL": {
                click: this.onBtnSubmitDLClick
            },
            "#btnUpdateBuilding": {
                click: this.onBtnUpdateBuildingClick
            },
            "#btnUpdateRoom": {
                click: this.onBtnUpdateRoomClick
            },
            "#btnUpdateRack": {
                click: this.onBtnUpdateRackClick
            },
            "#cboTest": {
                afterrender: this.onCboTestAfterRender
            }
        });
    }

});
