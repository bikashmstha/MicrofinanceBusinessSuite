/*
 * File: app/controller/StickerDelivery.js
 *
 * This file was generated by Sencha Architect version 2.2.2.
 * http://www.sencha.com/products/architect/
 *
 * This file requires use of the Ext JS 4.0.x library, under independent license.
 * License of Sencha Architect does not include license for Ext JS 4.0.x. For more
 * details see http://www.sencha.com/license or contact license@sencha.com.
 *
 * This file will be auto-generated each and everytime you save your project.
 *
 * Do NOT hand edit this file.
 */

Ext.define('MyApp.controller.StickerDelivery', {
    extend: 'Ext.app.Controller',

    stores: [
        'StickerType',
        'StickerOrders',
        'StickerDeliveryDet',
        'UserLocationEASy'
    ],

    onBtnAddSDDetailsClick: function(button, e, eOpts) {
        var cboLocation=Ext.ComponentQuery.query('#cboLocationSD')[0];
        var txtReceivedDate=Ext.ComponentQuery.query('#txtReceivedDateSD')[0];
        var errMsg="";
        var errCount=0;
        if(!cboLocation.getValue())
        {
            errCount++;
            errMsg +=errCount+") "+"कृपया लोकेसन छाल्नुहोस्  !<br/>";
            cboLocation.focus(true);
        }
        if(!txtReceivedDate.getValue())
        {
            errCount++;
            errMsg +=errCount+") "+"कृपया डिलिभरी मिति हाल्नुहोस् !<br/>";
            txtReceivedDate.focus(true);
        }

        if(errCount>0)
        {
            msg("WARNING",errMsg);    
            return false;
        }

        var grd = Ext.ComponentQuery.query('#grdSDDetails')[0];
        var recc={ 

            StickerType:"",
            OrderNo:"",
            BoxNo:"",
            Prefix:"",
            SeqFrom:"",
            SeqTo:""

        };
        grd.store.add(recc);

        var col = grd.headerCt.getHeaderAtIndex(0);
        var rec = grd.store.data.items;
        var record = rec[rec.length-1];
        grd.getPlugin('grdSDDetailsPlugin').startEdit(record, col);


    },

    onGrdSDDetailsBeforeRender: function(component, eOpts) {
        var grid = Ext.ComponentQuery.query('#grdSDDetails')[0];

        grid.columns[0].renderer = function(value, metaData, record, rowIndex, colIndex, store, view) {
            var temp="";    


            var items=Ext.getStore('StickerType').data.items;


            for(var i=0;i<items.length;i++)
            {

                if(items[i].data.StickerID==value)
                {
                    temp=items[i].data.StickerDescription;
                    break;
                }        
            }


            return temp;
        };

        grid.columns[1].renderer = function(value, metaData, record, rowIndex, colIndex, store, view) {
            var temp="";    


            var items=Ext.getStore('StickerOrders').data.items;


            for(var i=0;i<items.length;i++)
            {

                if(items[i].data.OrderNo==value)
                {
                    temp=items[i].data.OrderNo;
                    break;
                }        
            }

            return temp;
        };

    },

    onBtnSaveSDClick: function(button, e, eOpts) {
        var cboLocation=Ext.ComponentQuery.query('#cboLocationSD')[0];
        var txtReceivedDate=Ext.ComponentQuery.query('#txtReceivedDateSD')[0];
        var storeSDD=Ext.getStore('StickerDeliveryDet');

        var errMsg="";
        var errCount=0;
        if(!cboLocation.getValue())
        {
            errCount++;
            errMsg +=errCount+") "+"कृपया लोकेसन छाल्नुहोस् !<br/>";
            cboLocation.focus();
        }
        if(!txtReceivedDate.getValue())
        {
            errCount++;
            errMsg +=errCount+") "+"कृपया डिलिभरी मिति हाल्नुहोस् !<br/>";
            txtReceivedDate.focus();
        }
        if(storeSDD.getCount() < 1)
        {
            errCount++;
            errMsg +=errCount+") "+"कृपया स्टिकर डिलिभरीको Details हाल्नलाई Add click गर्नुहोस् !<br/>";
        }

        if(errCount>0)
        {
            msg("WARNING",errMsg);    
            return false;
        }

        this.SaveStickerDeliveryWithDetails("I");
        this.ClearControls();
    },

    onBtnEditSDClick: function(button, e, eOpts) {
        var me=this;
        me.ClearControls("e");
        var txtDeliveryNo=Ext.ComponentQuery.query('#txtDeliveryNoSD')[0];
        var txtSeqNo=Ext.ComponentQuery.query('#txtSeqNoSD')[0];
        var cboLocation=Ext.ComponentQuery.query('#cboLocationSD')[0];
        var txtReceivedDate=Ext.ComponentQuery.query('#txtReceivedDateSD')[0];

        var hdnAction = Ext.ComponentQuery.query('#hdnActionSD')[0];
        var lblAction = Ext.ComponentQuery.query('#lblActionSD')[0];

        hdnAction.setValue("E");
        lblAction.setValue("Updating ...............");

        var btnSave = Ext.ComponentQuery.query('#btnSaveSD')[0];
        var btnEdit = Ext.ComponentQuery.query('#btnEditSD')[0];
        var btnDelete = Ext.ComponentQuery.query('#btnDeleteSD')[0];
        var btnAdd=Ext.ComponentQuery.query('#btnAddSDDetails')[0];

        btnSave.enable(true);
        btnEdit.disable(true);
        btnDelete.disable(true);
        btnAdd.enable(true);

        //txtDeliveryNo.enable(true);
        txtDeliveryNo.setReadOnly(true);
        //txtSeqNo.enable(true);
        txtSeqNo.focus(true);

        var errMsg="";
        var errCount=0;
        if(!cboLocation.getValue())
        {
            errCount++;
            errMsg +=errCount+") "+"कृपया लोकेसन छाल्नुहोस् !<br/>";
            cboLocation.focus();
        }
        if(!txtReceivedDate.getValue())
        {
            errCount++;
            errMsg +=errCount+") "+"कृपया डिलिभरी मिति हाल्नुहोस् !<br/>";
            txtReceivedDate.focus();
        }

        if(!txtSeqNo.getValue())
        {
            errCount++;
            errMsg +=errCount+") "+"कृपया सिक्वेनस् नं. हाल्नुहोस्  !<br/>";
            txtSeqNo.focus(true);

        }
        /*if(!txtDeliveryNo.getValue())
        {
        errCount++;
        errMsg +=errCount+") "+"कृपया डिलिभरी नं. हाल्नुहोस्  !<br/>";
        }*/

        if(errCount>0)
        {
            msg("WARNING",errMsg);    
            return false;
        }
    },

    onBtnDeleteSDClick: function(button, e, eOpts) {
        var me=this;
        me.ClearControls("e");
        var txtDeliveryNo=Ext.ComponentQuery.query('#txtDeliveryNoSD')[0];
        var txtSeqNo=Ext.ComponentQuery.query('#txtSeqNoSD')[0];
        var cboLocation=Ext.ComponentQuery.query('#cboLocationSD')[0];
        var txtReceivedDate=Ext.ComponentQuery.query('#txtReceivedDateSD')[0];

        var hdnAction = Ext.ComponentQuery.query('#hdnActionSD')[0];
        var lblAction = Ext.ComponentQuery.query('#lblActionSD')[0];

        var action=hdnAction.setValue("D");
        //console.log(action.lastValue);
        lblAction.setValue("Deleting ...............");

        var btnSave = Ext.ComponentQuery.query('#btnSaveSD')[0];
        var btnEdit = Ext.ComponentQuery.query('#btnEditSD')[0];
        var btnDelete = Ext.ComponentQuery.query('#btnDeleteSD')[0];
        var btnAdd=Ext.ComponentQuery.query('#btnAddSDDetails')[0];

        btnSave.disable(true);
        btnEdit.disable(true);
        btnDelete.disable(true);
        btnAdd.disable(true);

        //txtDeliveryNo.enable(true);
        txtDeliveryNo.setReadOnly(true);
        //txtSeqNo.enable(true);

        var errMsg="";
        var errCount=0;
        if(!cboLocation.getValue())
        {
            errCount++;
            errMsg +=errCount+") "+"कृपया लोकेसन छाल्नुहोस् !<br/>";
            cboLocation.focus();
        }
        if(!txtReceivedDate.getValue())
        {
            errCount++;
            errMsg +=errCount+") "+"कृपया डिलिभरी मिति हाल्नुहोस् !<br/>";
            txtReceivedDate.focus();
        }
        if(!txtSeqNo.getValue())
        {
            errCount++;
            errMsg +=errCount+") "+"कृपया सिक्वेनस् नं. हाल्नुहोस्  !<br/>";
            txtSeqNo.focus();
        }
        /*
        if(!txtDeliveryNo.getValue())
        {
        errCount++;
        errMsg +=errCount+") "+"कृपया डिलिभरी नं. हाल्नुहोस्  !<br/>";
        }
        */

        if(errCount>0)
        {
            msg("WARNING",errMsg);    
            return false;
        }
    },

    onBtnSubmitSDClick: function(button, e, eOpts) {
        var me=this;

        //var txtDeliveryNo=Ext.ComponentQuery.query('#txtDeliveryNoSD')[0].getValue();
        //var txtSeqNo=Ext.ComponentQuery.query('#txtSeqNoSD')[0].getValue();
        var action = Ext.ComponentQuery.query('#hdnActionSD')[0];
        var lblAction = Ext.ComponentQuery.query('#lblActionSD')[0];
        var cboLocation=Ext.ComponentQuery.query('#cboLocationSD')[0];
        var txtReceivedDate=Ext.ComponentQuery.query('#txtReceivedDateSD')[0];
        var storeSDD=Ext.getStore('StickerDeliveryDet');

        var errMsg="";
        var errCount=0;
        if(!cboLocation.getValue())
        {
            errCount++;
            errMsg +=errCount+") "+"कृपया लोकेसन छाल्नुहोस् !<br/>";
            cboLocation.focus();
        }
        if(!txtReceivedDate.getValue())
        {
            errCount++;
            errMsg +=errCount+") "+"कृपया डिलिभरी मिति हाल्नुहोस् !<br/>";
            txtReceivedDate.focus();
        }

        if(storeSDD.getCount() < 1)
        {
            errCount++;
            errMsg +=errCount+") "+"कृपया स्टिकर डिलिभरीको Details हाल्नलाई Add click गर्नुहोस् !<br/>";
        }
        if(errCount>0)
        {
            msg("WARNING",errMsg);    
            return false;
        }


        if(action.lastValue === "D")
        {  
            Ext.Msg.confirm('Confirm', 'के तपाई साचै नै डाटा DELETE गर्न चाहनुहन्छ ?', function(btn) {
                if(btn == 'yes'){

                    me.SaveStickerDeliveryWithDetails("D");
                    this.ClearControls();
                    return true;
                }
            }, this);


        }
        else
        {
            Ext.Msg.confirm('Confirm', 'एकपटक Submit गरिसकेपछि अर्को पटक विवरण फेरि परिवर्तन गर्न पइने छैन। \n के तपाई Submit गर्न चाहनुहन्छ ?', function(btn) {
                if(btn == 'yes'){

                    me.SaveStickerDeliveryWithDetails("F");
                    this.ClearControls();

                    return true;
                }
            }, this);


        }
    },

    onBtnCancelSDClick: function(button, e, eOpts) {
        this.ClearControls();
    },

    onTxtSeqNoSDKeypress: function(textfield, e, eOpts) {
        var txtSeqNo=Ext.ComponentQuery.query('#txtSeqNoSD')[0];
        var cboLocation=Ext.ComponentQuery.query('#cboLocationSD')[0];
        var txtReceivedDate=Ext.ComponentQuery.query('#txtReceivedDateSD')[0];

        var errMsg="";
        var errCount=0;

        if(e.keyCode === 13)
        {
            if(!cboLocation.getValue())
            {
                errCount++;
                errMsg +=errCount+") "+"कृपया लोकेसन छाल्नुहोस् !<br/>";
                cboLocation.focus();
            }
            if(!txtReceivedDate.getValue())
            {
                errCount++;
                errMsg +=errCount+") "+"कृपया डिलिभरी मिति हाल्नुहोस् !<br/>";
                txtReceivedDate.focus();
            }

            if(!txtSeqNo.getValue())
            {
                errCount++;
                errMsg +=errCount+") "+"कृपया सिक्वेनस् नं. हाल्नुहोस्  !<br/>";
                txtSeqNo.focus(true);

            }
            if(errCount>0)
            {
                msg("WARNING",errMsg);    
                return false;
            }
            else
            {
                this.LoadStickerDeliveryWithDetails();
            }

        }

    },

    onPnlStickerDeliveryAfterRender: function(component, eOpts) {
        //var storeLoc = Ext.getStore('LocationEASy');
        //storeLoc.load();
        var storeST = Ext.getStore('StickerType');
        storeST.load();

        var storeULoc = Ext.getStore('UserLocationEASy');
        storeULoc.load(); 
        var storeSO = Ext.getStore('StickerOrders');
        storeSO.load({

            url:"../Handlers/Excise/Sticker/StickerOrderPlacementHandler.ashx?method=GetStickerOrderPlacements",
            method:'POST',
            params: {}

        });
        var storeSODet = Ext.getStore('StickerDeliveryDet');
        storeSODet.removeAll();
    },

    onTxtReceivedDateSDBlur: function(field, eOpts) {
        return validateFutureDate(field.getValue(),"Y",function(){field.focus();});
    },

    onTxtSeqNoSDBlur: function(field, eOpts) {

        var txtSeqNo=Ext.ComponentQuery.query('#txtSeqNoSD')[0];
        var cboLocation=Ext.ComponentQuery.query('#cboLocationSD')[0];
        var txtReceivedDate=Ext.ComponentQuery.query('#txtReceivedDateSD')[0];

        var errMsg="";
        var errCount=0;

        if(!cboLocation.getValue())
        {
            errCount++;
            errMsg +=errCount+") "+"कृपया लोकेसन छाल्नुहोस् !<br/>";
            cboLocation.focus();
        }
        if(!txtReceivedDate.getValue())
        {
            errCount++;
            errMsg +=errCount+") "+"कृपया डिलिभरी मिति हाल्नुहोस् !<br/>";
            txtReceivedDate.focus();
        }

        if(!txtSeqNo.getValue())
        {
            errCount++;
            errMsg +=errCount+") "+"कृपया सिक्वेनस् नं. हाल्नुहोस्  !<br/>";
            txtSeqNo.focus(true);

        }
        if(errCount>0)
        {
            msg("WARNING",errMsg);    
            return false;
        }

        else
        {
            this.LoadStickerDeliveryWithDetails();
        }

    },

    SaveStickerDeliveryWithDetails: function(recordStatus) {
        var cboLocation=Ext.ComponentQuery.query('#cboLocationSD')[0].getValue();
        var txtInvoiceNo=Ext.ComponentQuery.query('#txtInvoiceNoSD')[0].getValue();
        var txtReceivedDate=Ext.ComponentQuery.query('#txtReceivedDateSD')[0].getValue();
        var txtInvoiceAmount=Ext.ComponentQuery.query('#txtInvoiceAmountSD')[0].getValue();
        var txtReceivedBy=Ext.ComponentQuery.query('#txtReceivedBySD')[0].getValue();
        var txtLcNo=Ext.ComponentQuery.query('#txtLCNoSD')[0].getValue();
        var txtRemarks=Ext.ComponentQuery.query('#txtRemarksSD')[0].getValue();

        var deliveryNo=Ext.ComponentQuery.query('#txtDeliveryNoSD')[0].getValue();

        var tranDate="";
        var userID="";

        var action = Ext.ComponentQuery.query('#hdnActionSD')[0].getValue();
        var seqNo = Ext.ComponentQuery.query('#txtSeqNoSD')[0].getValue() === "" ?0:Ext.ComponentQuery.query('#txtSeqNoSD')[0].getValue();
        var tranNo = Ext.ComponentQuery.query('#hdnTranNoSD')[0].getValue() === ""?null:Ext.ComponentQuery.query('#hdnTranNoSD')[0].getValue();

        /*var loadMsg="";

        if(action == "E")
        {
        loadMsg = "Updating ...";
        }
        else
        {
        loadMsg = "Saving ...";
        }
        */
        var stickerDeliveryDetLST="";
        var storeStickerDeliveryDet=Ext.getStore('StickerDeliveryDet');
        storeStickerDeliveryDet.clearFilter();

        if(storeStickerDeliveryDet.getCount() > 0)
        {
            stickerDeliveryDetLST = getJson(storeStickerDeliveryDet); 
        }
        var SD={
            'LocationID':cboLocation,
            'InvoiceNo':txtInvoiceNo,
            'DeliveryDate':txtReceivedDate,
            'DeliveryNo':deliveryNo,
            'SeqNo':seqNo,
            'InvoiceAmount':txtInvoiceAmount,
            'ReceivedBy':txtReceivedBy,
            'LCNo':txtLcNo,
            'TranNo':tranNo,
            'Remarks':txtRemarks,
            'TranDate':tranDate,
            'RecordStatus':recordStatus,
            'UserID':userID,
            'Action':action,
            //'StickerDeliveryDetailsLST':[]
            'StickerDeliveryDetailsLST':stickerDeliveryDetLST!==""?stickerDeliveryDetLST:null
        };

        //console.log(SD);
        /*
        var SDDetails=[];
        var grdSDDet=Ext.ComponentQuery.query('#grdSDDetails')[0];
        var items=grdSDDet.getStore().data.items;
        //console.log(items);
        for(var i=0;i<items.length;i++)
        {
            // var seqNo=i+1;
            //var seqNo=items[i].data.seqNo;
            var stickerID=items[i].data.StickerID;
            var orderNo=items[i].data.OrderNo;
            var boxNo=items[i].data.BoxNo;
            var prefix=items[i].data.Prefix;
            var sequenceFrom=items[i].data.SeqFrom;
            var sequenceTo=items[i].data.SeqTo;
            // alert(stickerID);
            SDDetails[i]={
                'StickerID':stickerID,
                'OrderNo':orderNo,
                'BoxNo':boxNo,
                'Prefix':prefix,
                'SeqFrom':sequenceFrom,
                'SeqTo':sequenceTo
            };
        }

        //console.log(SDDetails);

        SD.StickerDeliveryDetailsLST=SDDetails;
        //console.log(SD.StickerDeliveryDetailsLST);
        //var waitSave = watiMsg(loadMsg);
        */
        Ext.Ajax.request({
            method: 'POST',
            url: '../Handlers/Excise/Sticker/StickerDeliveryHandler.ashx',
            params: {method:'SaveStickerDelivery', stickerDelivery : JSON.stringify(SD) },
            success: function( result, request ){

                //  waitSave.hide();

                var jsonMsg=Ext.decode(result.responseText);
                msg(jsonMsg.success=="true"?"SUCCESS":"FAILURE",jsonMsg.message);

            }
        });
    },

    ClearControls: function(txt) {
        var cboLocation=Ext.ComponentQuery.query('#cboLocationSD')[0];
        var txtInvoiceNo=Ext.ComponentQuery.query('#txtInvoiceNoSD')[0];
        var txtReceivedDate=Ext.ComponentQuery.query('#txtReceivedDateSD')[0];
        var txtInvoiceAmount=Ext.ComponentQuery.query('#txtInvoiceAmountSD')[0];
        var txtReceivedBy=Ext.ComponentQuery.query('#txtReceivedBySD')[0];
        var txtLcNo=Ext.ComponentQuery.query('#txtLCNoSD')[0];
        var txtRemarks=Ext.ComponentQuery.query('#txtRemarksSD')[0];
        var txtDeliveryNo=Ext.ComponentQuery.query('#txtDeliveryNoSD')[0];
        var txtSeqNo=Ext.ComponentQuery.query('#txtSeqNoSD')[0];
        var grd= Ext.ComponentQuery.query('#grdSDDetails')[0];
        var lblAction= Ext.ComponentQuery.query("#lblActionSD")[0];
        var hdnAction = Ext.ComponentQuery.query('#hdnActionSD')[0];

        var btnSave = Ext.ComponentQuery.query('#btnSaveSD')[0];
        var btnEdit = Ext.ComponentQuery.query('#btnEditSD')[0];
        var btnDelete = Ext.ComponentQuery.query('#btnDeleteSD')[0];
        var btnAdd=Ext.ComponentQuery.query('#btnAddSDDetails')[0];

        if(txt === "e")
        {
            cboLocation.reset();
            txtInvoiceNo.reset();
            txtReceivedDate.reset();
            txtInvoiceAmount.reset();
            txtReceivedBy.reset();
            txtLcNo.reset();
            txtRemarks.reset();
            txtDeliveryNo.reset();
            txtSeqNo.reset();
            grd.getStore().removeAll();
            txtDeliveryNo.setVisible(true);
            txtSeqNo.setVisible(true);
        }
        else
        {
            cboLocation.reset();
            txtInvoiceNo.reset();
            txtReceivedDate.reset();
            txtInvoiceAmount.reset();
            txtReceivedBy.reset();
            txtLcNo.reset();
            txtRemarks.reset();
            txtDeliveryNo.reset();
            txtSeqNo.reset();
            grd.getStore().removeAll();
            lblAction.reset();
            txtDeliveryNo.setVisible(false);
            txtSeqNo.setVisible(false);
            hdnAction.setValue("");
            btnSave.enable(true);
            btnEdit.enable(true);
            btnDelete.enable(true);
            btnAdd.enable(true);
        }
    },

    LoadStickerDeliveryWithDetails: function() {
        var txtSeqNo=Ext.ComponentQuery.query('#txtSeqNoSD')[0].getValue();
        var cboLocation=Ext.ComponentQuery.query('#cboLocationSD')[0].getValue();
        var txtReceivedDate=Ext.ComponentQuery.query('#txtReceivedDateSD')[0].getValue();

        if( cboLocation === "" || txtReceivedDate ==="" || txtSeqNo === "")
        {
            return;
        }

        //var wait = watiMsg('loading ...');

        Ext.Ajax.request({
            url:"../Handlers/Excise/Sticker/StickerDeliveryHandler.ashx?method=GetStickerDelivery",
            params:{locationID:cboLocation,deliveryDate:txtReceivedDate,seqNo:txtSeqNo},
            success: function ( result, request ) {            

                // wait.hide();            

                //console.log("obj",result.responseText);
                var obj = Ext.decode(result.responseText);            

                if(obj.success === "false")
                {   
                    msg("WARNING",obj.message);
                    return;
                }

                var data = obj.root; 

                if(data === "")
                {
                    msg("WARNING","यो स्टिकर डिलिभरीको डाटा भेटाऊन सकेन !");
                    return;
                }

                var txtDeliveryNo=Ext.ComponentQuery.query('#txtDeliveryNoSD')[0];
                var txtInvoiceNo = Ext.ComponentQuery.query('#txtInvoiceNoSD')[0];
                var txtInvoiceAmount = Ext.ComponentQuery.query('#txtInvoiceAmountSD')[0];
                var txtReceivedBy = Ext.ComponentQuery.query('#txtReceivedBySD')[0];
                var txtLcNo = Ext.ComponentQuery.query('#txtLCNoSD')[0];
                var txtRemarks = Ext.ComponentQuery.query('#txtRemarksSD')[0];
                var hdnAction = Ext.ComponentQuery.query('#hdnActionSD')[0];
                var hdnTranNo = Ext.ComponentQuery.query('#hdnTranNoSD')[0];

                txtDeliveryNo.setValue(data.DeliveryNo);   
                txtInvoiceNo.setValue(data.InvoiceNo);
                txtInvoiceAmount.setValue(data.InvoiceAmount);
                txtReceivedBy.setValue(data.ReceivedBy);
                txtLcNo.setValue(data.LCNo);
                txtRemarks.setValue(data.Remarks);
                hdnTranNo.setValue(data.TranNo);

                /* if(hdnAction.getValue() !== "D")
                {
                hdnAction.setValue(data.Action);
                }*/

                var grd= Ext.ComponentQuery.query('#grdSDDetails')[0];
                var store = Ext.getStore('StickerDeliveryDet');
                //console.log(data.StickerDeliveryDetailsLST);
                store.loadData(data.StickerDeliveryDetailsLST);

                store.clearFilter();
                store.filter(function(item){

                    return (item.data.LocationID == cboLocation && item.data.DeliveryDate==txtReceivedDate && item.data.SeqNo==txtSeqNo) ;
                });
            },
            failure: function ( result, request ) {

                // wait.hide();
                msg("FAILURE","Error in Fetching Data !!!");
            }
        });

    },

    init: function(application) {
        this.control({
            "#btnAddSDDetails": {
                click: this.onBtnAddSDDetailsClick
            },
            "#grdSDDetails": {
                beforerender: this.onGrdSDDetailsBeforeRender
            },
            "#btnSaveSD": {
                click: this.onBtnSaveSDClick
            },
            "#btnEditSD": {
                click: this.onBtnEditSDClick
            },
            "#btnDeleteSD": {
                click: this.onBtnDeleteSDClick
            },
            "#btnSubmitSD": {
                click: this.onBtnSubmitSDClick
            },
            "#btnCancelSD": {
                click: this.onBtnCancelSDClick
            },
            "#txtSeqNoSD": {
                keypress: this.onTxtSeqNoSDKeypress,
                blur: this.onTxtSeqNoSDBlur
            },
            "#pnlStickerDelivery": {
                afterrender: this.onPnlStickerDeliveryAfterRender
            },
            "#txtReceivedDateSD": {
                blur: this.onTxtReceivedDateSDBlur
            }
        });
    }

});
