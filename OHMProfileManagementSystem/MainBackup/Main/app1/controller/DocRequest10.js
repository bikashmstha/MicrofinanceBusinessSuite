/*
 * File: app/controller/DocRequest.js
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

Ext.define('MyApp.controller.DocRequest', {
    extend: 'Ext.app.Controller',

    stores: [
        'strRequestOffice'
    ],

    onDocRequestAfterRender: function(component, eOpts) {
        var me=this;



        var offCode=Ext.get('offCode').dom.innerHTML;
        var cboRequestOffice=Ext.ComponentQuery.query('#cboRequestOffice')[0];

        cboRequestOffice.removeAll();
        cboRequestOffice.loadData([],false);



        Ext.Ajax.request
        ({

            url:'../Handlers/DocumentManagement/SecUserOfficeHandler.ashx?method=GetSecUserOffice',
            params:{officeCode:offCode},


            success:function(response){
                console.log(response.responseText);
                var obj =Ext.decode(response.responseText);
                var row = obj.root;
                console.log("row-->",obj.root.FROM_DATE);

                Ext.ComponentQuery.query('#hdnReqFromDate')[0].setValue(obj.root.FROM_DATE);

                //gridUsers.store.add(obj.root); 

            },

            failure:function()
            {
                msg('FAILURE',Ext.decode(response));

            }



        });





        Ext.Ajax.request
        ({

            url:'../Handlers/DocumentManagement/RequestOfficeHandler.ashx?method=GetAllRequestOffice',
            params:{offcode:offCode},


            success:function(response){
                console.log(response.responseText);
                var obj =Ext.decode(response.responseText);
                var row = obj.root;
                console.log("row-->",obj.root);

                cboRequestOffice.removeAll();
                cboRequestOffice.loadData([],false);



                cboRequestOffice.store.add(obj.root); 

            },

            failure:function(response)
            {
                msg('FAILURE',Ext.decode(response));

            }



        });
    },

    onBtnSubmitClick: function(button, e, eOpts) {
        var cboRequestOffice=Ext.ComponentQuery.query('#cboRequestOffice')[0];
        var txtPAN=Ext.ComponentQuery.query('#txtPAN')[0];
        var txtDocumentKeyword=Ext.ComponentQuery.query('#txtDocumentKeyword')[0];

        var txtReqDate=Ext.ComponentQuery.query('#txtReqDate')[0];






        if(cboRequestOffice.getValue()==="" || cboRequestOffice.getValue()===null )
        {
            msg("WARNING","Please select Request Office !!!");
            return;

        }

        if(txtPAN.getValue()==="" || txtPAN.getValue()===null )
        {
            msg("WARNING","Please fill Valid PAN !!!");
            return;

        }

        if(txtPAN.getValue()==="" || txtPAN.getValue()===null )
        {
            msg("WARNING","Please fill Valid PAN !!!");
            return;

        }

        if(txtReqDate.getValue()==="" || txtReqDate.getValue()===null )
        {
            msg("WARNING","Please fill Request Date !!!");
            return;

        }


        var requestType="";
        if(Ext.ComponentQuery.query('#rbdView')[0].getValue())
        {
            requestType='V';
        }
        else if(Ext.ComponentQuery.query('#rbdDTransfer')[0].getValue())
        {
            requestType='DT';
        }
        else if(Ext.ComponentQuery.query('#rbdPTransfer')[0].getValue())
        {
            requestType='PT';
        }


        var chkRequestFor="";
        if(Ext.ComponentQuery.query('#chkRequestFor')[0].getValue())
        {
            chkRequestFor='Y';
        }
        else
        {
            chkRequestFor='N';
        }



        var DocRequest={


            REQUEST_ID:1,
            REQUEST_DATE:txtReqDate.getValue(),
            REQUEST_TYPE:requestType,
            DOC_ID:null,
            REQ_OFFCODE: cboRequestOffice.getValue()===""?null:cboRequestOffice.getValue(),
            REQUEST_BY:'',
            REQBY_FROM_DATE:Ext.ComponentQuery.query('#hdnReqFromDate')[0].getValue(),
            ENTRY_BY:'',
            ENTRY_DATE:'',
            TRAN_NO:'1',
            R_STATUS:'R',
            KEYWORD:txtDocumentKeyword.getValue(),
            ID:txtPAN.getValue(),
            REQUEST_FOR:chkRequestFor

        };



        Ext.Ajax.request({

            url:'../Handlers/DocumentManagement/DocumentRequestHandler.ashx?method=SaveDocumentRequest',
            params:{docrequest:JSON.stringify(DocRequest)},


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





                // Ext.ComponentQuery.query('#hdnActionRefund')[0].setValue('');
                // me.clearControlsRefund();


            },
            failure:function(result, request){
                msg('ERROR OCURRED !!!', 'Error');                 
            }


        });



    },

    onTxtPANBlur: function(component, e, eOpts) {

        this.PanCurrentOfficeTaxpayerInfo();




    },

    onBtnCancelDRClick: function(button, e, eOpts) {
        Ext.ComponentQuery.query('#cboRequestOffice')[0].setValue('');
        Ext.ComponentQuery.query('#txtPAN')[0].setValue('');
        Ext.ComponentQuery.query('#txtDocumentKeyword')[0].setValue('');

        Ext.ComponentQuery.query('#txtReqDate')[0].setValue('');
        Ext.ComponentQuery.query('#chkRequestFor')[0].setValue(true);

        Ext.ComponentQuery.query('#txtReqDate')[0].setValue('');



    },

    PanCurrentOfficeTaxpayerInfo: function() {
        var me=this;
        var txtPAN=Ext.ComponentQuery.query('#txtPAN')[0];
        var offCode=Ext.get('offCode').dom.innerHTML;
        LoadTaxpayerInfoWithValidPan(txtPAN.getValue(),'10',function(data){

        });


    },

    init: function(application) {
        this.control({
            "#DocRequest": {
                afterrender: this.onDocRequestAfterRender
            },
            "#btnSubmit": {
                click: this.onBtnSubmitClick
            },
            "#txtPAN": {
                blur: this.onTxtPANBlur
            },
            "#btnCancelDR": {
                click: this.onBtnCancelDRClick
            }
        });
    }

});
