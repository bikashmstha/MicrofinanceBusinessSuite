/*
 * File: app/controller/D03Annex7.js
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

Ext.define('MyApp.controller.D03Annex7', {
    extend: 'Ext.app.Controller',

    stores: [
        'Annex'
    ],

    onPnlD03Annex7AfterRender: function(component, eOpts) {
        var me = this;
        var view = Ext.ComponentQuery.query('#pnlD03Annex7')[0];
        var user = me.getController('MyApp.controller.LoginSecurity');  

        var txtFiscalYear = Ext.ComponentQuery.query("#txtFiscalYearAnx7")[0];
        var txtPan = Ext.ComponentQuery.query("#txtPanAnx7")[0];
        var txtName = Ext.ComponentQuery.query("#txtNameAnx7")[0];

        var pan = "";
        var fiscalYear = "";
        var name = "";   

        var param = me.validateParam();

        pan = param.pan;
        fiscalYear = param.fiscalYear;
        name = param.name;    

        txtPan.setValue(pan);    
        txtFiscalYear.setValue(fiscalYear);
        txtName.setValue(name);    

        me.loadAnnexLk();

        //----------------------------------------------------------------
        // NB: Return to SetAnnex	
        //----------------------------------------------------------------
        if(param.from === "MV")
        {
            var annexD03 = me.getController('MyApp.controller.SetAnnexD03');
            var el = Ext.get('lnkRedirectTopAnx7');

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

    onBtnSubmitAnx7Click: function(button, e, eOpts) {
        var me = this;
        var annexD03 = me.getController('MyApp.controller.SetAnnexD03');
        var assessmentNo = "";
        var annexIDSno = null;
        var tranNo = "";

        var action = "A";
        var form = button.up('form').getForm();

        var param = me.validateParam();
        assessmentNo = param.submissionNo;

        if(param.action === "E")
        {
            action = param.action;
            tranNo = param.tranNo;
            annexIDSno = param.annexIDSno;

        }

        var row20 = Ext.ComponentQuery.query("#txtIN19Anx7")[0].getValue();
        var row25 = Ext.ComponentQuery.query("#txtDE4Anx7")[0].getValue();
        var row28 = Ext.ComponentQuery.query("#txtDL2Anx7")[0].getValue();
        var row29 = Ext.ComponentQuery.query("#txtDL3Anx7")[0].getValue();
        var row30 = Ext.ComponentQuery.query("#txtDL4Anx7")[0].getValue();
        var row32 = Ext.ComponentQuery.query("#txtMI1Anx7")[0].getValue();

        //------------------------------------------------------
        // NB: Get AnnexDetails
        //------------------------------------------------------

        var strIN = Ext.getStore("Annex");
        var strDE = Ext.getStore("Deduction");
        var strDL = Ext.getStore("DeductionLoss");
        var strMI = Ext.getStore("Misc");

        var annex = "";
        var annexDetails = "";

        var strAnxDetail = new Ext.data.Store({
            fields: ['AssessmentNo', 'AnnexID','ItemID','ItFromDate','Amount','UserID','Terminal','TranDate','AnnexIDSno','ItemType','RecordStatus','TranNo','Action']
        });

        strAnxDetail = annexD03.getAnnexDetails(strIN,strAnxDetail,0,19,assessmentNo,"A");
        strAnxDetail = annexD03.getAnnexDetails(strDE,strAnxDetail,0,4,assessmentNo,"A");
        strAnxDetail = annexD03.getAnnexDetails(strDL,strAnxDetail,0,2,assessmentNo,"A");
        strAnxDetail = annexD03.getAnnexDetails(strMI,strAnxDetail,0,1,assessmentNo,"A");

        if(strAnxDetail.getCount() > 0)
        {
            annexDetails = getJson(strAnxDetail);
        }

        var rateApplicable  = 25;

        annex = {   AssessmentNo:assessmentNo,
            AnnexID:7,
            MtcFromDate:"",
            TaxCatID:"",
            MsDisCatFromDate:null,
            DiscCatID:null,
            TotalInclusion:row20 === "" ?null:row20,
            TotalDeduction:row25 === "" ?null:row25,
            Discount:null,
            UserID:"",
            Terminal:"000000000000E0",
            TranDate:"",
            CountryCode:"",
            AnnexIDSno:annexIDSno,
            RateApplicable:rateApplicable,
            TotalDeductibleLoss:row29 === "" ?null:row29,
            TotalDeductibleExp:row28 === "" ?null:row28,
            AssIncomeAftConcession:null,
            GainLossFromShare:null,
            GainLossFromBuilding:null,
            IncomeLoss:row30 === "" ?null:row30,
            NetIncomeLoss:row32 === "" ?null:row32,
            RecordStatus:"",
            TranNo:tranNo,
            Action:action,
            AnnexDetails:annexDetails
        };


        annexD03.saveAnnex(annex,param);
    },

    onGrdInclusionD03Anx7AfterRender: function(component, eOpts) {
        var me = this;
        var grid = Ext.ComponentQuery.query('#grdInclusionD03Anx7')[0];
        var strUpdAnnex = null;
        var strIN = null;
        var param = null;

        param = me.validateParam();

        if(param !== null)
        {    
            if( param.action === "E")
            {        
                me.loadDataForUpdate(param);    
                strUpdAnnex = Ext.getStore("UpdAnnex");

                strIN = deepCloneStore(strUpdAnnex,"UpdInclusion");  
                strIN.filter('ItemType',"IN");
                strIN.sort('ItemID','ASC'); 

            }
        }

        grid.columns[2].renderer = function(value, metaData, record, rowIndex, colIndex, store, view) {

            var id = Ext.id();

            Ext.Function.defer(function(){
                var txtBox = ""; 
                var anxValue = null;     


                if(rowIndex == 19)
                {
                    txtBox = new Ext.form.TextField({
                        id:"txtIN"+rowIndex+"Anx7",
                        itemId:"txtIN"+rowIndex+"Anx7",
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
                }
                else
                {
                    anxValue = me.getAnnexValue(param,strIN,rowIndex,1);

                    txtBox = new Ext.form.TextField({
                        id:"txtIN"+rowIndex+"Anx7",
                        itemId:"txtIN"+rowIndex+"Anx7",
                        value: anxValue,
                        renderTo: id,
                        height: 22,
                        width:150,
                        fieldCls: 'TxtRight',
                        maskRe: /[0-9]/,
                        maxLength: 10,
                        enableKeyEvents: true
                    });

                    txtBox.on('keyup', function(e){
                        me.calInclusion();

                    }, this);
                }



            },25);

            return '<div id="' + id +'"></div>';

        };

    },

    onGrdDeductionD03Anx7AfterRender: function(component, eOpts) {
        var me = this;
        var grid = Ext.ComponentQuery.query('#grdDeductionD03Anx7')[0];
        var strUpdAnnex = null;
        var strDE = null;
        var param = null;

        param = me.validateParam();

        if(param !== null)
        {    
            if( param.action === "E")
            {           
                strUpdAnnex = Ext.getStore("UpdAnnex");

                strDE = deepCloneStore(strUpdAnnex,"UpdDeduction");   
                strDE.filter('ItemType', "DE");
                strDE.sort('ItemID','ASC'); 
            }

        }

        grid.columns[2].renderer = function(value, metaData, record, rowIndex, colIndex, store, view) {

            var id = Ext.id();    
            var anxValue = null;   


            Ext.Function.defer(function(){


                var txtBox = "";  

                if(rowIndex > 3)
                {
                    txtBox = txtBox = new Ext.form.TextField({
                        id:"txtDE"+rowIndex+"Anx7",
                        itemId:"txtDE"+rowIndex+"Anx7",
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
                }
                else
                {

                    anxValue = me.getAnnexValue(param,strDE,rowIndex,21);

                    txtBox = new Ext.form.TextField({
                        id:"txtDE"+rowIndex+"Anx7",
                        itemId:"txtDE"+rowIndex+"Anx7",
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
                    me.calDeduction();

                }, this);

            },25);

            return '<div id="' + id +'"></div>';
        };

    },

    onGrdDeductionLossD03Anx7AfterRender: function(component, eOpts) {
        var me = this;
        var grid = Ext.ComponentQuery.query('#grdDeductionLossD03Anx7')[0];
        var strUpdAnnex = null;
        var strDL = null;
        var param = null;

        param = me.validateParam();

        if(param !== null)
        {    
            if( param.action === "E")
            {         
                strUpdAnnex = Ext.getStore("UpdAnnex");

                strDL = deepCloneStore(strUpdAnnex,"UpdDeductionLoss");
                strDL.filter('ItemType',"DL");
                strDL.sort('ItemID','ASC'); 
            }

        }

        grid.columns[2].renderer = function(value, metaData, record, rowIndex, colIndex, store, view) {

            var id = Ext.id();

            Ext.Function.defer(function(){
                var txtBox = null;
                var anxValue = null;

                if(rowIndex > 1)
                {
                    txtBox = new Ext.form.TextField({
                        id:"txtDL"+rowIndex+"Anx7",
                        itemId:"txtDL"+rowIndex+"Anx7",
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



                }
                else
                {

                    anxValue = me.getAnnexValue(param,strDL,rowIndex,26);

                    txtBox = new Ext.form.TextField({
                        id:"txtDL"+rowIndex+"Anx7",
                        itemId:"txtDL"+rowIndex+"Anx7",
                        value: anxValue,
                        renderTo: id,
                        height: 22,
                        width:150,
                        fieldCls: 'TxtRight',
                        maskRe: /[0-9]/,
                        maxLength: 10,
                        enableKeyEvents: true
                    });

                    txtBox.on('keyup', function(e){
                        me.calDeductionLoss();

                    }, this);
                }


            },25);

            return '<div id="' + id +'"></div>';
        };

    },

    onGrdDeductionMiscD03Anx7AfterRender: function(component, eOpts) {
        var me = this;
        var grid = Ext.ComponentQuery.query('#grdDeductionMiscD03Anx7')[0];
        var strUpdAnnex = null;
        var strMisc = null;
        var param = null;

        param = me.validateParam();

        if(param !== null)
        {    
            if( param.action === "E")
            {        
                strUpdAnnex = Ext.getStore("UpdAnnex");

                strMisc = deepCloneStore(strUpdAnnex,"UpdDeductionMisc");
                strMisc.filter('ItemType', "MI");
                strMisc.sort('ItemID','ASC'); 
            }

        }

        grid.columns[2].renderer = function(value, metaData, record, rowIndex, colIndex, store, view) {

            var id = Ext.id();

            Ext.Function.defer(function(){
                var txtBox = "";
                var anxValue = null;

                if(rowIndex ==  1)
                {
                    txtBox = new Ext.form.TextField({
                        id:"txtMI"+rowIndex+"Anx7",
                        itemId:"txtMI"+rowIndex+"Anx7",
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
                        me.calDeduction();
                        me.calDeductionLoss();
                    }
                }
                else
                {            
                    anxValue = me.getAnnexValue(param,strMisc,rowIndex,31);

                    txtBox = new Ext.form.TextField({
                        id:"txtMI"+rowIndex+"Anx7",
                        itemId:"txtMI"+rowIndex+"Anx7",
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
                    me.calTotalMisc();

                }, this);


            },25);
            return '<div id="' + id +'"></div>';
        };
    },

    onLblRedirectAnx7Click: function(label) {
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
        var row20 = Ext.ComponentQuery.query("#txtIN19Anx7")[0];
        row20.setValue("");

        for(var i=0;i<20;i++){

            var id = "#txtIN" + i + "Anx7";
            var val = Ext.ComponentQuery.query(id)[0].getValue();
            var row = store.getAt(i).data;

            val = (val === "")?0:val;
            row.ItemValue = val === 0?null:val;
            sum = parseInt(sum) + parseInt(val);

        }//for

        row20.setValue(sum);

        this.calBusinessIncomeAndLoss();


    },

    calDeduction: function() {

        var sum = 0;
        var store = Ext.getStore("Deduction");
        var row25 = Ext.ComponentQuery.query("#txtDE4Anx7")[0];
        row25.setValue("");

        for(var i=0;i<4;i++){

            var row = store.getAt(i).data;
            var id = "#txtDE" + i + "Anx7";
            var val = Ext.ComponentQuery.query(id)[0].getValue();

            val = (val === "")?0:val;    
            row.ItemValue = val === 0?null:val;
            sum = parseInt(sum) + parseInt(val);

        }//for

        row25.setValue(sum);

        this.calTotalDeduction();
    },

    calDeductionLoss: function() {
        var sum = 0;
        var store = Ext.getStore("DeductionLoss");
        var row28 = Ext.ComponentQuery.query("#txtDL2Anx7")[0];
        row28.setValue("");


        for(var i=0;i<2;i++){

            var id = "#txtDL" + i + "Anx7";
            var row = store.getAt(i).data;
            var val = Ext.ComponentQuery.query(id)[0].getValue();

            val = (val === "")?0:val;   
            //row.ItemValue = val;
            row.ItemValue = val === 0?null:val;
            sum = parseInt(sum) + parseInt(val);

        }//for

        row28.setValue(sum);

        this.calTotalDeduction();
    },

    calTotalDeduction: function() {
        var row25 = Ext.ComponentQuery.query("#txtDE4Anx7")[0].getValue();
        var row28 = Ext.ComponentQuery.query("#txtDL2Anx7")[0].getValue();
        var row29 = Ext.ComponentQuery.query("#txtDL3Anx7")[0];
        var sum = null;

        row25 = (row25 === "")?0:row25; 
        row28 = (row28 === "")?0:row28; 

        sum =  parseInt(row25) + parseInt(row28);
        row29.setValue(sum);
        this.calBusinessIncomeAndLoss();
    },

    calBusinessIncomeAndLoss: function() {
        var row20 = Ext.ComponentQuery.query("#txtIN19Anx7")[0].getValue();
        var row29 = Ext.ComponentQuery.query("#txtDL3Anx7")[0].getValue();
        var row30 = Ext.ComponentQuery.query("#txtDL4Anx7")[0];
        var sum = null;

        row20 = (row20 === "")?0:row20; 
        row29 = (row29 === "")?0:row29; 

        sum =  parseInt(row20) - parseInt(row29);
        row30.setValue(sum);

        this.calTotalMisc();
    },

    calTotalMisc: function() {
        var row30 = Ext.ComponentQuery.query("#txtDL4Anx7")[0].getValue();
        var row31 = Ext.ComponentQuery.query("#txtMI0Anx7")[0].getValue();
        var row32 = Ext.ComponentQuery.query("#txtMI1Anx7")[0];
        var sum = null;

        var store = Ext.getStore("Misc");
        var row = store.getAt(0).data;
        //row.ItemValue = row33;
        row.ItemValue = row31 === 0?null:row31;

        row30 = (row30 === "")?0:row30; 
        row31 = (row31 === "")?0:row31; 

        sum =  parseInt(row30) + parseInt(row31);
        row32.setValue(sum);

    },

    clearStores: function() {
        var strAnnex = Ext.getStore("Annex");
        var strDE = Ext.getStore("Deduction");
        var strDL = Ext.getStore("DeductionLoss");
        var strMI = Ext.getStore("Misc");
        var strDIS = Ext.getStore("Dis");

        strAnnex.loadData([],false);
        strDE.loadData([],false);
        strDL.loadData([],false);
        strMI.loadData([],false);
        strDIS.loadData([],false);
    },

    onLaunch: function() {
        var me = this;
        var annexD03 = me.getController('MyApp.controller.SetAnnexD03');
        var param = me.validateParam();
        var el = Ext.get('lnkRedirectTopAnx7');

        el.on('click', function(e,t,eOpts){

            Ext.Msg.confirm('Confirm Action', 'के तपाई पछाडि गएर अनुसुची तय गर्न चाहनुहुन्छ?', function(btn) {
                if(btn == 'yes'){        

                    param.action ="";
                    annexD03.redirectToAnnexD03(param);
                }
            }, this);
        });
    },

    loadDataForUpdate: function(param) {
        var me = this;
        var strAnnex = Ext.getStore("Annex");

        var url = "../Handlers/IncomeTax/D03/DCTBAnnexHandler.ashx?method=GetDCTBAnnexWithDetails" ;
        var args = {assessmentNo:param.submissionNo,annexID:'7',annexIDSno:param.annexIDSno};

        if(param.from === "AU")
        {  
            url = "../Handlers/IncomeTax/D03/DCTBAnnexHandler.ashx?method=GetDCTBAnnexWithDetailsAU";
            args = {offCodeAU:param.offCodeAU,requestNo:param.requestNo,assessmentNo:param.submissionNo,annexID:'7',annexIDSno:param.annexIDSno};
        }

        Ext.Ajax.request({
            url:url,
            params:args,
            async : false,
            success: function ( result, request ) {   

                var obj = Ext.decode(result.responseText); 

                var strUpdAnnex = deepCloneStore(strAnnex,"UpdAnnex");

                strUpdAnnex.loadData([],false);
                strUpdAnnex.add(obj.root.AnnexDetails);     
                strUpdAnnex.sort('ItemID','ASC'); 

                param.tranNo = obj.root.TranNo;
                param.annexIDSno = obj.root.AnnexIDSno;  

            },
            failure:  function ( result, request ) { 

                msg("FAILURE","Error in Saving data !!!");

            }
        });


    },

    validateParam: function() {
        var me = this;
        var view = Ext.ComponentQuery.query('#pnlD03Annex7')[0];
        var user = me.getController('MyApp.controller.LoginSecurity');  

        //console.log("view7>>",view);

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

    getAnnexValue: function(param,store,itemID,startIdx) {
        var annexValue = null;
        var rowIdx;

        if(param.action === "E")
        {
            rowIdx = store.findBy(
            function(record, id){

                if(record.get('ItemID') === (startIdx + itemID))
                {
                    annexValue = record.get('Amount');
                    return true ;  // a record with this data exists
                }
                return false;  // there is no record in the store with this data
            });

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
            params:{annexID:7,itemType:""},
            //async:false,
            //async : false,
            success: function ( result, request ) {

                waitSave.hide();
                var grid = Ext.ComponentQuery.query('#grdInclusionD03Anx7')[0];
                var strAnnex = Ext.getStore("Annex");

                strAnnex.loadData([],false);

                var obj = Ext.decode(result.responseText);


                var row20 =  { AnnexID:'7',
                        ItemID:'20',
                        ItemDescNep:'जम्मा:(१ देखि १९)',
                        ItemDescEng:'Total:(1 to 19)',
                        ItemType:'IN'
                    };

                var row25 =  { AnnexID:'७',
                        ItemID:'25',
                        ItemDescNep:'जम्मा:(२१ देखि २४)',
                        ItemDescEng:'Total:(1 to 24)',
                        ItemType:'DE'
                    };

                var row28 =  { AnnexID:'7',
                        ItemID:'28',
                        ItemDescNep:'जम्मा:(२६ देखि २७)',
                        ItemDescEng:'Total:(26 to 27)',
                        ItemType:'DL'
                    };

                var row29 =  { AnnexID:'7',
                        ItemID:'29',
                        ItemDescNep:'जम्मा कट्टी:(२५ + २८)',
                        ItemDescEng:'Total:(25 + 28)',
                        ItemType:'DL'
                    };

                var row30 =  { AnnexID:'7',
                        ItemID:'30',
                        ItemDescNep:'व्यवसायको आय र नोक्सानी :(२० - २९)',
                        ItemDescEng:'Gain or Loss :(20 - 29)',
                        ItemType:'DL'
                    };

                var row32 =  { AnnexID:'7',
                        ItemID:'32',
                        ItemDescNep:'जम्मा:(३० + ‌३१)',
                        ItemDescEng:'Total:(30 + 31)',
                        ItemType:'MI'
                    };

                strAnnex.add(obj.root); 
                strAnnex.add(row20);        
                strAnnex.add(row25);  
                strAnnex.add(row28);  
                strAnnex.add(row29);  
                strAnnex.add(row30);  
                strAnnex.add(row32);  
                strAnnex.sort('ItemID','ASC'); 

                var strDE = null;
                var strDL = null;
                var strMI = null;
                var strDIS = null;

                strDE = deepCloneStore(strAnnex,"Deduction");
                strDL = deepCloneStore(strAnnex,"DeductionLoss");
                strMI = deepCloneStore(strAnnex,"Misc");
                strDIS = deepCloneStore(strAnnex,"Dis");

                strAnnex.filter('ItemType',"IN");
                strDE.filter('ItemType', "DE");
                strDL.filter('ItemType',"DL");
                strMI.filter('ItemType', "MI");
                //strDIS.filter('ItemType', "DIS");


                //var gridDI = Ext.ComponentQuery.query('#grdInclusionD03Anx7')[0];
                var gridDE = Ext.ComponentQuery.query('#grdDeductionD03Anx7')[0];
                var gridDL = Ext.ComponentQuery.query('#grdDeductionLossD03Anx7')[0];
                var gridMI = Ext.ComponentQuery.query('#grdDeductionMiscD03Anx7')[0];
                // var gridDIS = Ext.ComponentQuery.query('#grdDiscountD03Anx7')[0];     


                // gridDI.store = strAnnex;
                //gridDI.bindStore(strAnnex);

                gridDE.store = strDE;
                gridDE.bindStore(strDE);

                gridDL.store = strDL;
                gridDL.bindStore(strDL);      

                gridMI.store = strMI;
                gridMI.bindStore(strMI);

                //gridDIS.store = strDIS;
                //gridDIS.bindStore(strDIS);

            },
            failure: function(form, action) {

                waitSave.hide();

                msg("FAILURE","Error in Fetching data !!!");
            }

        });
    },

    init: function(application) {
        this.control({
            "#pnlD03Annex7": {
                afterrender: this.onPnlD03Annex7AfterRender
            },
            "#btnSubmitAnx7": {
                click: this.onBtnSubmitAnx7Click
            },
            "#grdInclusionD03Anx7": {
                afterrender: this.onGrdInclusionD03Anx7AfterRender
            },
            "#grdDeductionD03Anx7": {
                afterrender: this.onGrdDeductionD03Anx7AfterRender
            },
            "#grdDeductionLossD03Anx7": {
                afterrender: this.onGrdDeductionLossD03Anx7AfterRender
            },
            "#grdDeductionMiscD03Anx7": {
                afterrender: this.onGrdDeductionMiscD03Anx7AfterRender
            },
            "#lblRedirectAnx7": {
                click: this.onLblRedirectAnx7Click
            }
        });
    }

});