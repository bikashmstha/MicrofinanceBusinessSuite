/*
 * File: app/controller/D03Annex6.js
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

Ext.define('MyApp.controller.D03Annex6', {
    extend: 'Ext.app.Controller',

    stores: [
        'Annex'
    ],

    onPnlD03Annex6AfterRender: function(component, eOpts) {
        var me = this;
        var user = me.getController('MyApp.controller.LoginSecurity');  
        var param = "";

        var txtFiscalYear = Ext.ComponentQuery.query("#txtFiscalYearAnx6")[0];
        var txtPan = Ext.ComponentQuery.query("#txtPanAnx6")[0];
        var txtName = Ext.ComponentQuery.query("#txtNameAnx6")[0];

        var pan = "";
        var fiscalYear = "";
        var name = "";   


        param = me.validateParam();
        pan = param.pan;
        fiscalYear = param.fiscalYear;
        name = param.name;    

        txtPan.setValue(pan);    
        txtFiscalYear.setValue(fiscalYear);
        txtName.setValue(name);

        //----------------------------------------------------------------
        // NB: Return to SetAnnex	
        //----------------------------------------------------------------

        if(param.from === "MV")
        {
            var annexD03 = me.getController('MyApp.controller.SetAnnexD03');

            var el = Ext.get('lnkRedirectTopAnx6');

            el.on('click', function(e,t,eOpts){

                Ext.Msg.confirm('Confirm Action', 'के तपाई पछाडि गएर अनुसुची तय गर्न चाहनुहुन्छ?', function(btn) {
                    if(btn == 'yes'){        

                        param.action ="";
                        annexD03.redirectToAnnexD03(param);
                    }
                }, this);
            });
        }




    },

    onGrdInclusionD03Anx6AfterRender: function(component, eOpts) {
        var me = this;
        var view = Ext.ComponentQuery.query('#pnlD03Annex6')[0];
        var user = me.getController('MyApp.controller.LoginSecurity');  
        var param = "";
        var grid = Ext.ComponentQuery.query('#grdInclusionD03Anx6')[0];
        var strUpdAnnex = null;

        if(view.extraParam === null)
        {
            user.clearSession();

            return;

        }
        else
        {    
            param = view.extraParam;

            if( param.action === "E")
            {        
                me.loadDataForUpdate(param);    
                strUpdAnnex = Ext.getStore("UpdAnnex6");
            }

            me.loadAnnexLk();
        }


        grid.columns[2].renderer = function(value, metaData, record, rowIndex, colIndex, store, view) {

            var id = Ext.id();

            Ext.Function.defer(function(){
                var txtBox = ""; 
                var anxValue = null;

                if(rowIndex == 25)
                {
                    txtBox = new Ext.form.TextField({
                        id:"txtIN"+rowIndex+"Anx6",
                        itemId:"txtIN"+rowIndex+"Anx6",
                        value: null,
                        renderTo: id,
                        height: 22,
                        width:150,
                        fieldCls: 'TxtRight',
                        maskRe: /[0-9]/,
                        maxLength: 10,
                        readOnly:true,
                        enableKeyEvents: true
                    });

                    if( param.action === "E")
                    {
                        me.calInclusion();
                    }
                }
                else
                {           
                    //console.log("rowIndex",rowIndex);

                    anxValue = me.getAnnexValue(param,strUpdAnnex,rowIndex+1);

                    console.log("return console value >>: ",anxValue);

                    txtBox = new Ext.form.TextField({
                        id:"txtIN"+rowIndex+"Anx6",
                        itemId:"txtIN"+rowIndex+"Anx6",
                        value: anxValue,
                        renderTo: id,
                        height: 22,
                        width:150,
                        fieldCls: 'TxtRight',
                        maskRe: /[0-9]/,
                        maxLength: 10,
                        enableKeyEvents: true
                    });
                }

                txtBox.on('keyup', function(e){
                    me.calInclusion();

                }, this);

            },25);

            return '<div id="' + id +'"></div>';

        };

    },

    onBtnSubmitAnx6Click: function(button, e, eOpts) {
        var me = this;

        var view = Ext.ComponentQuery.query('#pnlD03Annex6')[0];
        var user = me.getController('MyApp.controller.LoginSecurity');  
        var assessmentNo = "";
        var action = "A";
        var tranNo = null;
        var annexIDSno = null;
        var form = button.up('form').getForm();

        var annexD03 = me.getController('MyApp.controller.SetAnnexD03');
        var row27 = Ext.ComponentQuery.query("#txtIN25Anx6")[0].getValue();

        row27 = row27 === "" ?null:row27;

        var param = me.validateParam();
        assessmentNo = param.submissionNo;

        if(param.action === "E")
        {
            action = param.action;
            tranNo = param.tranNo;
            annexIDSno = param.annexIDSno;

        }

        //------------------------------------------------------
        // NB: Get AnnexDetails
        //------------------------------------------------------

        var strIN = Ext.getStore("Annex");

        var annex = "";
        var annexDetails = "";

        var strAnxDetail = new Ext.data.Store({
            fields: ['AssessmentNo', 'AnnexID','ItemID','ItFromDate','Amount','UserID','Terminal','TranDate','AnnexIDSno','ItemType','RecordStatus','TranNo','Action']
        });
        strAnxDetail = annexD03.getAnnexDetails(strIN,strAnxDetail,0,25,assessmentNo,"A");

        if(strAnxDetail.getCount() > 0)
        {
            annexDetails = getJson(strAnxDetail);
        }

        var rateApplicable  = null;
        var fiscalYear = Ext.ComponentQuery.query("#txtFiscalYearAnx6")[0].getValue();
        //rateApplicable  = me.getTaxRate(param.taxpayerCat,row27);

        //------------------------------------------------------
        //Note: For Anx6 TotalInclusion = IncomeLoss = NetIncomeLoss

        annex = {   AssessmentNo:assessmentNo,
            AnnexID:6,
            MtcFromDate:"",
            TaxCatID:param.taxpayerCat,
            MsDisCatFromDate:"",
            DiscCatID:"",
            TotalInclusion:row27,
            TotalDeduction:null,
            Discount:null,
            UserID:"",
            Terminal:"000000000000E0",
            TranDate:"",
            CountryCode:"",
            AnnexIDSno:annexIDSno,
            RateApplicable:rateApplicable,
            TotalDeductibleLoss:null,
            TotalDeductibleExp:null,
            AssIncomeAftConcession:null,
            GainLossFromShare:null,
            GainLossFromBuilding:null,
            IncomeLoss:row27,
            NetIncomeLoss:row27,
            RecordStatus:"",
            TranNo:tranNo,
            Action:action,
            FiscalYear : fiscalYear,
            AnnexDetails:annexDetails
        };

        //strIN.loadData([],false);

        annexD03.saveAnnex(annex,param);

    },

    onLblRedirectAnx6Click: function(label) {
        var me = this;

        Ext.Msg.confirm('Confirm Action', 'के तपाई पछाडि गएर अनुसुची तय गर्न चाहनुहुन्छ?', function(btn) {
            if(btn == 'yes'){        

                var annexD03 = me.getController('MyApp.controller.SetAnnexD03');

                var param = me.validateParam();
                param.action ="";

                annexD03.redirectToAnnexD03(param);
            }
        }, this);

    },

    calInclusion: function() {
        var sum = 0;
        var store = Ext.getStore("Annex");
        var row26 = Ext.ComponentQuery.query("#txtIN25Anx6")[0];
        row26.setValue("");

        for(var i=0;i<25;i++){

            var id = "#txtIN" + i + "Anx6";
            var val = Ext.ComponentQuery.query(id)[0].getValue();
            var row = store.getAt(i).data;

            val = (val === "")?0:val;
            row.ItemValue = val === 0?null:val;
            sum = parseInt(sum) + parseInt(val);

        }//for

        row26.setValue(sum);



    },

    setInclusion: function() {

    },

    loadDataForUpdate: function(param) {
        var me = this;
        var strAnnex = Ext.getStore("Annex");

        var url = "../Handlers/IncomeTax/D03/DCTBAnnexHandler.ashx?method=GetDCTBAnnexWithDetails" ;
        var args = {assessmentNo:param.submissionNo,annexID:'6',annexIDSno:param.annexIDSno};

        if(param.from === "AU")
        {  
            url = "../Handlers/IncomeTax/D03/DCTBAnnexHandler.ashx?method=GetDCTBAnnexWithDetailsAU";
            args = {offCodeAU:param.offCodeAU,requestNo:param.requestNo,assessmentNo:param.submissionNo,annexID:'6',annexIDSno:param.annexIDSno};
        }

        Ext.Ajax.request({
            url:url,
            params:args,
            async : false,
            success: function ( result, request ) {   

                var obj = Ext.decode(result.responseText); 

                var strUpdAnnex = deepCloneStore(strAnnex,"UpdAnnex6");

                strUpdAnnex.loadData([],false);
                strUpdAnnex.add(obj.root.AnnexDetails);     
                strUpdAnnex.sort('ItemID','ASC'); 

                //console.log("updAnnex",strUpdAnnex);

                param.tranNo = obj.root.TranNo;
                param.annexIDSno = obj.root.AnnexIDSno;  

            },
            failure:  function ( result, request ) { 

                msg("FAILURE","Error in Saving data !!!");

            }
        });



    },

    loadInclusion: function() {
        /*
        var sum = 0;
        var store = Ext.getStore("Annex");
        var row26 = Ext.ComponentQuery.query("#txtIN25Anx6")[0];
        row26.setValue("");

        for(var i=0;i<25;i++){

        var id = "#txtIN" + i + "Anx6";
        var val = Ext.ComponentQuery.query(id)[0].getValue();
        var row = store.getAt(i).data;

        val = (val === "")?0:val;
        row.ItemValue = val === 0?null:val;
        sum = parseInt(sum) + parseInt(val);

        }//for

        row26.setValue(sum);

        */

        var store = Ext.getStore("UpdAnnex6");

        //console.log("working",store);

        store.each(function(record,idx){
            //do whatever you want with the record
            //console.log(record.get('fieldName');
            var amt = record.get('Amount');
            amt = amt === undefined ?null:amt;

            var id = "#txtIN" + idx + "Anx6";
            //Ext.ComponentQuery.query(id)[0].setValue(amt);

            //console.log("valu",Ext.ComponentQuery.query(id)[0].getValue());


            //console.log("amt",amt);
            //console.log("record",record);
            //console.log("idx",idx);
        });
    },

    onLaunch: function() {
        var me = this;
        var annexD03 = me.getController('MyApp.controller.SetAnnexD03');
        var param = me.validateParam();

        var el = Ext.get('lnkRedirectTopAnx6');

        el.on('click', function(e,t,eOpts){

            Ext.Msg.confirm('Confirm Action', 'के तपाई पछाडि गएर अनुसुची तय गर्न चाहनुहुन्छ?', function(btn) {
                if(btn == 'yes'){        

                    param.action ="";
                    annexD03.redirectToAnnexD03(param);
                }
            }, this);
        });

    },

    getAnnexValue: function(param,store,itemID) {
        var annexValue = null;
        var rowIdx;
        //param,store,itemID

        if(param.action === "E")
        {
            rowIdx = store.findBy(
            function(record, id){

                if(record.get('ItemID') === itemID)
                {
                    annexValue = record.get('Amount');
                    return true ;  // a record with this data exists
                }
                return false;  // there is no record in the store with this data
            });

            /*
            if(rowIdx !== -1)
            {
            alert("annexValue" + annexValue);
            }
            */

        }
        return annexValue;
    },

    loadAnnexLk: function() {

        var waitSave = waitMsg("Please wait ...");
        //------------------------------------------------------
        // NB: Retrive Data from Server
        //------------------------------------------------------

        Ext.Ajax.request({
            url: '../Handlers/IncomeTax/D03/AnnexItemsHandler.ashx?method=GetAnnexItems',
            params:{annexID:6,itemType:""},
            async : false,
            success: function ( result, request ) {

                var grid = Ext.ComponentQuery.query('#grdInclusionD03Anx6')[0];
                var strAnnex = Ext.getStore("Annex");

                strAnnex.loadData([],false);

                var obj = Ext.decode(result.responseText);


                var tot1To25 =  { AnnexID:'6',
                        ItemID:'26',
                        ItemDescNep:'जम्मा:(१ देखि २५)',
                        ItemDescEng:'Total:(1 to 25)',
                        ItemType:'IN',
                        Action:''
                    };


                strAnnex.add(obj.root); 
                strAnnex.add(tot1To25);        
                strAnnex.sort('ItemID','ASC');

                waitSave.hide();
            },
            failure: function(form, action) {

                waitSave.hide();

                msg("FAILURE","Error in Fetching data !!!");
            }

        });
    },

    validateParam: function() {
        var me = this;
        var view = Ext.ComponentQuery.query('#pnlD03Annex6')[0];
        var user = me.getController('MyApp.controller.LoginSecurity');  
        var param = "";

        if(view.extraParam === null)
        {
            user.clearSession();

            return;

        }
        else
        {
            return view.extraParam;
        }

    },

    getTaxRate: function(taxID,income) {
        var me = this;

        var fiscalYear = Ext.ComponentQuery.query("#txtFiscalYearAnx6")[0].getValue();
        var taxRate = null;

        Ext.Ajax.request({
            url: '../Handlers/IncomeTax/TaxRateHandler.ashx?method=GetTaxRate',
            params:{taxID:taxID,fiscalYear:fiscalYear,income:income},
            async:false,
            success: function ( result, request ) {


                var obj = Ext.decode(result.responseText);

                if(obj.success === "true")
                {
                    taxRate = me.getTaxRate().setValue(obj.root.Rate);
                }
                else
                {
                    msg("WARNING",obj.message,function(){ return null;});
                }

            },
            failure: function(form, action) {

                waitSave.hide();

                msg("FAILURE","Error in Fetching data !!!");
            }

        });

        alert("rate>>" + taxRate);

        return taxRate;
    },

    init: function(application) {
        this.control({
            "#pnlD03Annex6": {
                afterrender: this.onPnlD03Annex6AfterRender
            },
            "#grdInclusionD03Anx6": {
                afterrender: this.onGrdInclusionD03Anx6AfterRender
            },
            "#btnSubmitAnx6": {
                click: this.onBtnSubmitAnx6Click
            },
            "#lblRedirectAnx6": {
                click: this.onLblRedirectAnx6Click
            }
        });
    }

});
