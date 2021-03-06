/*
 * File: app/controller/ManualSelfAssessmentMD03.js
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

Ext.define('MyApp.controller.ManualSelfAssessmentMD03', {
    extend: 'Ext.app.Controller',

    stores: [
        'TaxPayerTypeD03',
        'FiscalYear'
    ],

    refs: [
        {
            ref: 'taxPayerSelDetail',
            selector: '#pnlTaxPayerSelectionDetailMD03'
        },
        {
            ref: 'auditorVerf',
            selector: '#pnlAuditorVerificationMD03'
        },
        {
            ref: 'submissionNo',
            selector: '#lblSubmissionNoMD03'
        }
    ],

    onPnlManualSelfAssmtMD03AfterRender: function(component, eOpts) {
        var me = this;

        var hdnAssmtType = Ext.ComponentQuery.query('#hdnAssmtTypeMD03')[0];

        var map = Ext.getCmp('CntSiteMapPath');
        var val = map.html;
        var arr = val.split(">>");

        var leaf = arr[arr.length-1].trim();

        //console.log("leaf>>",leaf);

        if(leaf === "Manual Self-Assessment")
        {
            hdnAssmtType.setValue("SA");
            //hdnAssmtType.setValue("ASS03");
        }
        else if(leaf === "Manual Jeopardy Assessment")
        {
            hdnAssmtType.setValue("JA");
        }
        else if(leaf === "Manual Change of Control")
        {
            hdnAssmtType.setValue("BH");
        }
        else if(leaf === "Manual Close Off Business")
        {
            hdnAssmtType.setValue("CB");
        } 
        else
        {
            //hdnAssmtType.setValue("ASS03");
            hdnAssmtType.setValue("SA");
        }


        me.hideShowDates(hdnAssmtType.getValue());

        var view = Ext.ComponentQuery.query('#pnlSelfAssessmentMD03')[0];
        var user = me.getController('MyApp.controller.LoginSecurity');  
        var param = "";

        if(view.extraParam === null)
        {
            user.clearSession();
            return;
        }


        console.log("param>>",view.extraParam);
        //-------------------------------------------------------------------------
        // NB: Loading details using TRAN-NO i.e. for Verification Preview
        //-------------------------------------------------------------------------
        if(view.extraParam)
        {    
            param = view.extraParam;
            var arg   = param.params;

            if(arg.from)
            {
                var from = arg.from;

                switch(from)
                {
                    case "MV":       
                    var tranNo = arg.tranNo; 

                    param.from = arg.from;
                    me.loadDetailByTran(tranNo,arg,view);
                    break;
                    case "AU":
                    me.loadDetailsForAU(arg,view);
                    break;
                    case "OV":
                    var tranNo = arg.tranNo; 
                    param.from = arg.from;
                    me.loadDetailByTran(arg,view);
                    break;
                }

                return;
            }
        } 



    },

    onTxtPanNoMD03Keypress: function(textfield, e, eOpts) {
        var me = this;

        if((e.keyCode === 13 || e.keyCode === 9) && textfield.getValue().length === 9)
        {

            me.clearControls();

            var btnRegister = Ext.ComponentQuery.query('#btnRegisterMD03')[0];        
            var btnUpdate = Ext.ComponentQuery.query('#btnUpdateMD03')[0];
            var btnEnterAnnex = Ext.ComponentQuery.query('#btnEnterAnnexMD03')[0];                

            btnRegister.setVisible(true);
            btnUpdate.setVisible(false);
            btnEnterAnnex.setVisible(false);

            //-------------------------------------------------------------------------
            // NB: Loading details using PAN and ACCOUNT-TYPE i.e. for Submission Login
            //-------------------------------------------------------------------------
            LoadTaxpayerInfoWithValidPan(textfield.getValue(),"10",function(data){


                if(!data.root.Taxpayer.Name)
                {
                    msg("WARNING","Please Enter a VALID Pan!!!",function(){textfield.focus();});

                    return;
                }

                var lblActionMD03 = Ext.ComponentQuery.query('#lblActionMD03')[0];
                var txtSubmissionNo = Ext.ComponentQuery.query('#txtSubmissionNoMD03')[0];

                lblActionMD03.setVisible(false);
                txtSubmissionNo.setDisabled(true);
                txtSubmissionNo.setValue("");

                me.loadControls(data);       
            });
        }
    },

    onTxtSubmissionNoMD03Keypress: function(textfield, e, eOpts) {
        var me = this;
        //-------------------------------------------------------------------------
        // NB: Loading details using submission Number i.e. for Income Tax Login
        //-------------------------------------------------------------------------


        if((e.keyCode === 13 || e.keyCode === 9) && textfield.getValue().length === 12)
        {
            var subNum = textfield.getValue();

            var wait  = waitMsg('Loading ...');

            Ext.Ajax.request({
                url: '../Handlers/IncomeTax/D01/AssessmentSADoneHandler.ashx?method=GetDCTBAssessment',
                params:{assessmentNo:subNum},
                success: function ( result, request ) {

                    wait.hide();
                    var obj = Ext.decode(result.responseText);                

                    if(obj.success === "true" && obj.total > 0)
                    {                
                        Ext.ComponentQuery.query('#txtPanNoMD03')[0].setValue(obj.root.Pan);
                        Ext.ComponentQuery.query('#cboFiscalYearMD03')[0].setValue(obj.root.FiscalYear);

                        me.loadControls(obj);
                        me.loadControlsForITaxLogin(obj.root);

                        me.loadAnxSummary(subNum);

                        var btnRegister = Ext.ComponentQuery.query('#btnRegisterMD03')[0];        
                        var btnUpdate = Ext.ComponentQuery.query('#btnUpdateMD03')[0];
                        var btnEnterAnnex = Ext.ComponentQuery.query('#btnEnterAnnexMD03')[0];  
                        var hdnRecStatus =  Ext.ComponentQuery.query('#hdnRecordStatusMD03')[0];
                        var lblSubNo = Ext.ComponentQuery.query('#lblSubmissionNoMD03')[0];

                        lblSubNo.setValue(subNum);

                        hdnRecStatus.setValue(obj.root.RecordStatus);
                        btnRegister.setVisible(false);
                        btnUpdate.setVisible(true);
                        btnEnterAnnex.setVisible(true);

                        if(obj.root.RecordStatus === "F")
                        { 
                            btnUpdate.setVisible(false); 
                        }
                        else
                        {
                            btnUpdate.setVisible(true);
                        }
                    }
                    else
                    {
                        msg("WARNING",obj.message,function(){textfield.focus();});
                        return;
                    }

                },
                failure: function(form, action) {

                    wait.hide();
                    msg("FAILURE","Error in Fetching data !!!");
                }

            });
        }
    },

    onBtnUpdateMD03Click: function(button, e, eOpts) {
        var me = this;

        var form = button.up('form').getForm();
        if(!form.isValid())
        {
            msg("WARNING","कृपया सबै विवरणहरू भन्नुहोस् !!!");    
            return;
        }

        me.saveUpdate("E");
    },

    onCboFiscalYearMD03Change: function(field, newValue, oldValue, eOpts) {
        var taxCatID =  Ext.ComponentQuery.query('#hdnTaxPayrCatIDMD03')[0].getValue();
        var store = Ext.getStore("TaxPayerTypeD03");

        if(taxCatID !== "")
        {

            store.loadData([],false);
            store.load({params:{fiscalYear:newValue,taxCatType:taxCatID}});

            //console.log("store",store);
        }
    },

    onRgbtnClubbedPanChange: function(field, newValue, oldValue, eOpts) {
        var radios = Ext.ComponentQuery.query('#rgbtnClubbedPanMD03')[0];
        var clubPanNo = Ext.ComponentQuery.query('#txtClubbedPanNoMD03')[0];

        if(newValue.pan === "Y")
        {
            clubPanNo.setReadOnly(false);
        }
        else if(newValue.pan === "N")
        {
            clubPanNo.setReadOnly(true);
            clubPanNo.setValue("");
        }

    },

    onCboTaxPayerTypeMD03Select: function(combo, records, eOpts) {
        var me = this;
        var newValue = combo.getValue(); 

        me.onChangeTaxPayerType(newValue);
    },

    onBtnRegisterMD03Click: function(button, e, eOpts) {
        var me = this;

        var form = button.up('form').getForm();
        if(!form.isValid())
        {
            msg("WARNING","कृपया सबै विवरणहरू भन्नुहोस् !!!");    
            return;
        }
        me.saveUpdate("A");

        var strAnxSummary = Ext.create ('Ext.data.Store', {
            fields: ['AnnexID','Business','Action'],
            proxy: {
                type: 'ajax',
                url: '',
                reader: {
                    type: 'json',
                    root: 'root'
                }
            },
            storeId:'AnxSummary'
        });


        strAnxSummary.loadData([],false);
    },

    onBtnEditMD03Click: function(button, e, eOpts) {
        var me = this;

        var lblActionMD03 = Ext.ComponentQuery.query('#lblActionMD03')[0];
        var txtSubmissionNo = Ext.ComponentQuery.query('#txtSubmissionNoMD03')[0];

        lblActionMD03.setVisible(true);
        txtSubmissionNo.setDisabled(false);
        txtSubmissionNo.setValue("");
        txtSubmissionNo.focus();

        Ext.ComponentQuery.query('#txtPanNoMD03')[0].setValue("");
        Ext.ComponentQuery.query('#cboFiscalYearMD03')[0].setValue("");


        /*
        var uiConfig = {menuLink:'SetAnnexD03',pageTitle:'Set Annex'};
        var arg = {submissionNo:"690000001198",
        pan:"100058330",
        fiscalYear :"2068.069",
        offCode:"28",
        action:"E"};

        DynamicUI(uiConfig,null,arg);

        */
    },

    onTxtAuditorPanNoMD03Keypress: function(textfield, e, eOpts) {
        var me = this;

        if((e.keyCode === 13 || e.keyCode === 9) && textfield.getValue().length === 9)
        {
            var txtAuditorName =  Ext.ComponentQuery.query('#txtAuditorNameMD03')[0];
            txtAuditorName.setValue("");
            txtAuditorName.clearInvalid();

            //-------------------------------------------------------------------------
            // NB: Loading details using PAN and ACCOUNT-TYPE i.e. for Submission Login
            //-------------------------------------------------------------------------
            LoadTaxpayerInfoWithValidPan(textfield.getValue(),"10",function(data){


                if(!data.root.Taxpayer.Name)
                {
                    msg("WARNING","Please Enter a VALID Pan!!!",function(){textfield.focus();});

                    return;
                }

                var rec = data.root.Taxpayer;

                txtAuditorName.setValue(rec.Name);

            },function(){ textfield.focus();});



            }

    },

    onTxtAuditorNameMD03Blur: function(component, e, eOpts) {

    },

    loadControls: function(data) {
        var me = this;
        var pnlSelfAssessment = Ext.ComponentQuery.query('#pnlSelfAssessmentMD03')[0];

        var pan = Ext.ComponentQuery.query('#txtPanNoMD03')[0];
        var IRO = Ext.ComponentQuery.query('#txtPlaceMD03')[0];
        var name = Ext.ComponentQuery.query('#txtNameMD03')[0];
        var houseNo = Ext.ComponentQuery.query("#txtHouseNoMD03")[0];
        var ward = Ext.ComponentQuery.query('#txtWardNoMD03')[0];
        var street = Ext.ComponentQuery.query('#txtToleNameMD03')[0];
        var vdc = Ext.ComponentQuery.query('#txtVDCNameMD03')[0];
        var district = Ext.ComponentQuery.query('#txtDistrictNameMD03')[0];
        var phone = Ext.ComponentQuery.query('#txtPhoneMD03')[0];
        var mobile = Ext.ComponentQuery.query('#txtMobileMD03')[0];
        var email = Ext.ComponentQuery.query('#txtEmailMD03')[0];
        var radios = Ext.ComponentQuery.query('#rbtnsLocationMD03')[0]; 

        var txtFromDate =  Ext.ComponentQuery.query('#txtFromDateMD03')[0];
        var txtToDate =  Ext.ComponentQuery.query('#txtToDateMD03')[0];

        var fiscalYear =  Ext.ComponentQuery.query('#cboFiscalYearMD03')[0].getValue();

        var hdnTaxCatID =  Ext.ComponentQuery.query('#hdnTaxPayrCatIDMD03')[0];

        var obj = data.root;
        var rec = data.root.Taxpayer;
        var addr = rec.BusinessAddress !== null? rec.BusinessAddress.Address:null;
        var office = rec.Office;
        var store = Ext.getStore("TaxPayerTypeD03");

        IRO.setValue(office.OfficeNameNepali);
        name.setValue(rec.Name);

        txtFromDate.setValue(obj.AssessmentFromDate);
        txtToDate.setValue(obj.DateUpto);

        if(addr !== null)
        {
            houseNo.setValue(addr.HouseNo);
            ward.setValue(addr.WardNo);
            street.setValue(addr.StreetName);
            vdc.setValue(addr.VdcTown);        
            district.setValue(addr.DistrictNameNep);
            phone.setValue(addr.Telephone);
            email.setValue(addr.Email);
        }


        if(rec.TaxpayerCategoryId == "I")
        {
            me.getTaxPayerSelDetail().setVisible(true);
            me.getAuditorVerf().setTitle("४. लेखाप्ररिक्षण प्रमाणीकरण");
        }
        else
        {
            me.getTaxPayerSelDetail().setVisible(false);
            me.getAuditorVerf().setTitle("३. लेखाप्ररिक्षण प्रमाणीकरण");
        }


        radios.setValue({loc:addr.LocationType});

        hdnTaxCatID.setValue(rec.TaxpayerCategoryId);

        //---------------------------------------------------------------------------
        // NB: Loading TaxpayerCategory
        //---------------------------------------------------------------------------
        if(fiscalYear !== "" && fiscalYear !== null && rec.TaxpayerCategoryId !== "")
        {
            store.loadData([],false);
            store.load({params:{fiscalYear:fiscalYear,taxCatType: rec.TaxpayerCategoryId}});
        }
        else
        {
            msg("INFO","Please Select Fiscal year to Load 'Taxpayer Category' ",function(){Ext.ComponentQuery.query('#cboFiscalYearMD03')[0].focus();});
            return;
        }

    },

    onChangeTaxPayerType: function(val) {
        var obj = Ext.ComponentQuery.query('#pnlSelfAssessmentMD03')[0];
        var taxCatID =  Ext.ComponentQuery.query('#hdnTaxPayrCatIDMD03')[0].getValue();


        //if(param.taxPayerCatID === "I")
        if(taxCatID === "I")
        {
            var statusVal = "";
            var flag = false;

            var clubbedPan = Ext.ComponentQuery.query('#cntClubbedPanMD03')[0];
            var panForClubbed = Ext.ComponentQuery.query('#txtClubbedPanNoMD03')[0];
            var clubbedName = Ext.ComponentQuery.query('#txtClubbedNameMD03')[0];
            var radios = Ext.ComponentQuery.query('#rgbtnClubbedMD03')[0];

            switch (val) {
                case "A": statusVal='N';flag = false; break;
                case "A1-1-1": statusVal='N';flag = false; break;
                case "A1-1-2": statusVal='Y';flag = true; break;
                case "A1-1-9C":statusVal='Y';flag = true; break;
                case "A1-1-9KA": statusVal='N';flag = false; break;
                case "A1-1-9KAC": statusVal='Y';flag = true; break;
                default: status ='N';flag = false; break;
            }

            clubbedPan.setVisible(flag);
            clubbedName.setReadOnly(!flag);
            panForClubbed.setValue("");
            clubbedName.setValue("");
            radios.setValue({status:statusVal});
        }

    },

    hideShowDates: function(assmtType) {
        var pnl = Ext.ComponentQuery.query('#pnlSelfAssessmentMD03')[0];
        var txtFromDate =  Ext.ComponentQuery.query('#txtFromDateMD03')[0];
        var txtToDate =  Ext.ComponentQuery.query('#txtToDateMD03')[0];

        txtFromDate.setVisible(false);
        txtToDate.setVisible(false);

        if(assmtType === "JA")
        {
            txtFromDate.setVisible(true);
            txtToDate.setVisible(true);

            pnl.setTitle("Manual Jeopardy Assessment");
            Ext.getCmp('CntSiteMapPath').update("Integrated Tax Menus >> Income Tax System >> Manual Jeopardy Assessment");

        }
        else if(assmtType === "BH")
        {
            txtFromDate.setVisible(true);
            txtToDate.setVisible(true);

            pnl.setTitle("Manual Change of Control");
            Ext.getCmp('CntSiteMapPath').update("Integrated Tax Menus >> Income Tax System >> Manual Change of Control");

        }
        else if(assmtType === "CB")
        {
            txtToDate.setVisible(true);    

            pnl.setTitle("Manual Close Off Business");
            Ext.getCmp('CntSiteMapPath').update("Integrated Tax Menus >> Income Tax System >> Manual Close Off Business");
        }


    },

    saveUpdate: function(action) {
        var me = this;
        var taxPayerCatID =  Ext.ComponentQuery.query('#hdnTaxPayrCatIDMD03')[0].getValue();

        var submissionNo = "";
        var officeCode = Ext.get('offCode').dom.innerHTML;

        var fiscalYear =  Ext.ComponentQuery.query('#cboFiscalYearMD03')[0].getValue();
        var pan = Ext.ComponentQuery.query('#txtPanNoMD03')[0].getValue();
        var taxPayerCat = Ext.ComponentQuery.query('#cboTaxPayerTypeMD03')[0].getValue();

        var clubbedYN = Ext.ComponentQuery.query('#rgbtnClubbedMD03')[0].getValue().status;
        var clubbedHasPan = Ext.ComponentQuery.query('#rgbtnClubbedPanMD03')[0].getValue().pan;
        var clubbedPan = Ext.ComponentQuery.query('#txtClubbedPanNoMD03')[0].getValue();
        var clubbedName = Ext.ComponentQuery.query('#txtClubbedNameMD03')[0].getValue();

        var auditorName = Ext.ComponentQuery.query('#txtAuditorNameMD03')[0].getValue();
        var auditorLicenseNo = Ext.ComponentQuery.query('#txtAuditorLicenseNoMD03')[0].getValue();
        var auditorPanNo = Ext.ComponentQuery.query('#txtAuditorPanNoMD03')[0].getValue();

        var txtSubmissionNo = Ext.ComponentQuery.query('#txtSubmissionNoMD03')[0];

        var acctType = "10";

        if(action === "E")
        {
            submissionNo =  txtSubmissionNo.getValue();
        }

        if(taxPayerCatID === "I")
        {
            var cntClubbedPan = Ext.ComponentQuery.query('#cntClubbedPanMD03')[0];

            if(cntClubbedPan.isVisible())
            {
                var errMsg = "";

                if(clubbedName === "")
                {
                    errMsg += "कृपया पति/ पत्नीको नाम राख्नुहोस् !!! <br/>";
                }

                if(clubbedHasPan === "Y")
                {

                    if(clubbedPan === "")
                    {
                        errMsg += "कृपया पति पत्नीको स्था.ले.नं. राख्नुहोस् !!!";
                    }
                }

                if(errMsg !== "")
                {
                    msg("WARNING",errMsg);
                    return;
                }
            }
        }


        var txtFromDate =  Ext.ComponentQuery.query('#txtFromDateMD03')[0];
        var txtToDate =  Ext.ComponentQuery.query('#txtToDateMD03')[0];

        var assessmentFromDate = "";
        var dateUpto = "";
        var partOrFull = "";
        var assessmentType = Ext.ComponentQuery.query('#hdnAssmtTypeMD03')[0].getValue();



        if(assessmentType === "JA" || assessmentType === "BH")
        {
            assessmentFromDate = txtFromDate.getValue();
            dateUpto = txtToDate.getValue();
            partOrFull = "Y";

        }
        else if(assessmentType === "CB")
        {
            dateUpto = txtToDate.getValue();
            partOrFull = "Y";
        }

        //-------------------------------------------------------------------
        // NB: For Manual Entry of ASSESSMENT
        //-------------------------------------------------------------------

        var manualSubNo = {
            SubmissionNumber:'',
            Username:'',
            Password:'',
            ContactNo:'',
            Emailid:'',
            submittedFor:'',
            SubmittedYN:'N',
            SubmittedDate:'',
            TranNo:'0',
            Address:'',
            RegOffice:'',
            Action:'A',
            PAN:pan,
            FiscalYear:fiscalYear
        };

        assessment = {  TotalPayableTax:null,
            MTCFromDate:"",
            AssessmentFromDate:assessmentFromDate,
            OffCode:officeCode,
            Pan:pan,
            FiscalYear:fiscalYear,
            AssessmentNo:submissionNo,
            SubmissionDate:"",
            AssessmentDate:"",
            ReturnDocType:'MD03',
            ExtendedReturnDate:"",
            OfficerCode:"",
            AuditorName:auditorName, 
            AuditorLicenceNo:auditorLicenseNo,
            DecisionType:"",
            ReferenceNo:"",
            ReferenceDate:"", 
            AssessmentToDate:"",
            ClubbedYN:clubbedYN,
            ClubbedHasPan:clubbedHasPan,
            ClubbedName:clubbedName, 
            TotalTaxLiability:null,
            PartOrFull:partOrFull,
            Terminal:"",
            Tran_Date:"", 
            UserName:"",
            RecordStatus:"",
            AuditorPan:auditorPanNo,
            ClubbedPan:clubbedPan,
            ReferenceFiscalYear:"",
            TaxpayerCat:taxPayerCat,
            Attachment:"",
            JpFiscalYear:"",
            BusinessClose:"", 
            DateUpto:dateUpto, 
            TaxIncomeAFTDe:"",
            TaxAFTDe:"",
            TranNo:"",     
            AcctType:acctType,
            Action:action,
            AssessmentType:assessmentType,                
            SubmissionNo:manualSubNo
        };

        var wait  = "";

        if(action === "A")
        {
            wait = waitMsg('Saving ...');
        }
        else
        {
            wait = waitMsg('Updating ...');
        }


        Ext.Ajax.request({
            url:'../Handlers/IncomeTax/D01/AssessmentSADoneHandler.ashx?method=SaveAssessmentSADone',
            params:{assmtSADone:JSON.stringify(assessment)},
            success:function(result, request)
            {
                wait.hide();
                var obj = Ext.decode(result.responseText);     
                msg(obj.success === "true" ?"SUCCESS":"WARNING",obj.message); 

                var btnRegister = Ext.ComponentQuery.query('#btnRegisterMD03')[0];        
                var btnUpdate = Ext.ComponentQuery.query('#btnUpdateMD03')[0];
                var btnEnterAnnex = Ext.ComponentQuery.query('#btnEnterAnnexMD03')[0];

                btnRegister.setVisible(false);
                btnUpdate.setVisible(true);
                btnEnterAnnex.setVisible(true);

                if(action === "A" && obj.success === "true")
                {
                    var message= obj.message;
                    var arr = message.split("<br>");

                    txtSubmissionNo.setValue(arr[3].trim());
                }

            },

            failure:function(result, request){
                wait.hide();
                msg('ERROR OCURRED !!!', 'Error');                 
            }
        });
    },

    loadControlsForITaxLogin: function(obj) {
        var me = this;

        //-------------------------------------------------------------------------
        // NB: Setting datas from Assessment
        //-------------------------------------------------------------------------
        var btnRegister = Ext.ComponentQuery.query('#btnRegisterMD03')[0];        
        var btnUpdate = Ext.ComponentQuery.query('#btnUpdateMD03')[0];
        var btnEnterAnnex = Ext.ComponentQuery.query('#btnEnterAnnexMD03')[0];

        var cboTaxPayerType = Ext.ComponentQuery.query('#cboTaxPayerTypeMD03')[0];
        var clubbedYN = Ext.ComponentQuery.query('#rgbtnClubbedMD03')[0];
        var clubbedHasPan = Ext.ComponentQuery.query('#rgbtnClubbedPanMD03')[0];
        var clubbedPan = Ext.ComponentQuery.query('#txtClubbedPanNoMD03')[0];
        var clubbedName = Ext.ComponentQuery.query('#txtClubbedNameMD03')[0];

        var auditorName = Ext.ComponentQuery.query('#txtAuditorNameMD03')[0];
        var auditorLicenseNo = Ext.ComponentQuery.query('#txtAuditorLicenseNoMD03')[0];
        var auditorPanNo = Ext.ComponentQuery.query('#txtAuditorPanNoMD03')[0];

        cboTaxPayerType.setValue(obj.TaxpayerCat);
        me.onChangeTaxPayerType(obj.TaxpayerCat);   

        clubbedYN.setValue({status:obj.ClubbedYN});
        clubbedHasPan.setValue({pan:obj.ClubbedHasPan}); 

        auditorName.setValue(obj.AuditorName);
        auditorLicenseNo.setValue(obj.AuditorLicenceNo);
        auditorPanNo.setValue(obj.AuditorPan);    

        if(obj.ClubbedYN === "Y")
        {        
            clubbedName.setValue(obj.ClubbedName);
        }

        if(obj.ClubbedHasPan === "Y")
        { 
            clubbedPan.setValue(obj.ClubbedPan);
        }

        btnRegister.setVisible(false);
        btnUpdate.setVisible(true);
        btnEnterAnnex.setVisible(true);
    },

    clearControls: function() {
        Ext.ComponentQuery.query('#txtPlaceMD03')[0].setValue("");
        Ext.ComponentQuery.query('#txtNameMD03')[0].setValue("");
        Ext.ComponentQuery.query("#txtHouseNoMD03")[0].setValue("");
        Ext.ComponentQuery.query('#txtWardNoMD03')[0].setValue("");
        Ext.ComponentQuery.query('#txtToleNameMD03')[0].setValue("");
        Ext.ComponentQuery.query('#txtVDCNameMD03')[0].setValue("");
        Ext.ComponentQuery.query('#txtDistrictNameMD03')[0].setValue("");
        Ext.ComponentQuery.query('#txtPhoneMD03')[0].setValue("");
        Ext.ComponentQuery.query('#txtMobileMD03')[0].setValue("");
        Ext.ComponentQuery.query('#txtEmailMD03')[0].setValue("");

        Ext.ComponentQuery.query('#txtFromDateMD03')[0].setValue("");
        Ext.ComponentQuery.query('#txtToDateMD03')[0].setValue("");
        Ext.ComponentQuery.query('#hdnTaxPayrCatIDMD03')[0].setValue("");

        Ext.ComponentQuery.query('#txtAuditorNameMD03')[0].setValue("");
        Ext.ComponentQuery.query('#txtAuditorLicenseNoMD03')[0].setValue("");
        Ext.ComponentQuery.query('#txtAuditorPanNoMD03')[0].setValue("");

        Ext.ComponentQuery.query('#cboTaxPayerTypeMD03')[0].setValue("");

        Ext.ComponentQuery.query('#lblSubmissionNoMD03')[0].setValue("");


        Ext.ComponentQuery.query('#txtAuditorNameMD03')[0].clearInvalid();
        Ext.ComponentQuery.query('#txtAuditorLicenseNoMD03')[0].clearInvalid();
        Ext.ComponentQuery.query('#txtAuditorPanNoMD03')[0].clearInvalid();
        Ext.ComponentQuery.query('#cboTaxPayerTypeMD03')[0].clearInvalid();

        var store = Ext.getStore("TaxPayerTypeD03");
        store.loadData([],false);

        return;
    },

    loadAnxSummary: function(submissionNo) {
        var me = this;
        var param = me.validateParam();
        var url = "../Handlers/IncomeTax/D03/DCTBAnnexHandler.ashx?method=GetDCTBAnnexSummary";
        var arg = {assessmentNo:submissionNo};

        if(param.params)
        {
            if(param.params.from === "AU")
            {
                url = "../Handlers/IncomeTax/D03/DCTBAnnexHandler.ashx?method=GetDCTBAnnexSummaryAU";
                arg = {offCodeAU:param.params.offCode,requestNo:param.params.requestNo,assessmentNo:submissionNo};
            }
        }

        Ext.Ajax.request({
            url:url,
            params:arg,
            //async : false,
            success: function ( result, request ) {   

                var obj = Ext.decode(result.responseText); 

                var strAnxSummary = Ext.create ('Ext.data.Store', {
                    fields: ['AnnexID','Business','Action'],
                    proxy: {
                        type: 'ajax',
                        url: '',
                        reader: {
                            type: 'json',
                            root: 'root'
                        }
                    },
                    storeId:'AnxSummary'
                });

                strAnxSummary.loadData([],false);
                strAnxSummary.add(obj.root);
                strAnxSummary.sort('AnnexID','ASC');

            },
            failure:  function ( result, request ) { 
                msg("FAILURE","Error in Saving data !!!");

            }
        });

    },

    loadDetailByTran: function( tranNo,param,view) {
        var me = this;
        var wait  = waitMsg('Loading Preview ...');


        Ext.Ajax.request({
            url:"../Handlers/IncomeTax/D01/AssessmentSADoneHandler.ashx?method=GetDCTBAssessmentD03ByTran" ,
            params:{tranNo:tranNo},
            async : false,
            success: function ( result, request ) {   

                wait.hide();        
                var obj = Ext.decode(result.responseText);  
                var lblSubNo = Ext.ComponentQuery.query('#lblSubmissionNoMD03')[0];

                var txtSubmissionNo = Ext.ComponentQuery.query('#txtSubmissionNoMD03')[0];   

                var btnRegister = Ext.ComponentQuery.query('#btnRegisterMD03')[0];        
                var btnUpdate = Ext.ComponentQuery.query('#btnUpdateMD03')[0];
                var btnEdit = Ext.ComponentQuery.query('#btnEditMD03')[0];
                var btnEnterAnnex = Ext.ComponentQuery.query('#btnEnterAnnexMD03')[0];

                var hdnRecStatus =  Ext.ComponentQuery.query('#hdnRecordStatusMD03')[0]; 

                Ext.ComponentQuery.query('#txtPanNoMD03')[0].setValue(obj.root.Pan);
                Ext.ComponentQuery.query('#cboFiscalYearMD03')[0].setValue(obj.root.FiscalYear);

                console.log("before loading controls obj>>",obj);

                me.loadControls(obj);
                me.loadControlsForITaxLogin(obj.root);        
                me.loadAnxSummary(obj.root.AssessmentNo);        

                hdnRecStatus.setValue(obj.root.RecordStatus);

                btnRegister.setVisible(false);
                btnUpdate.setVisible(false);
                btnEdit.setVisible(false);
                btnEnterAnnex.setVisible(true);

                txtSubmissionNo.setVisible(false);
                txtSubmissionNo.setValue(obj.root.AssessmentNo);

                me.hideShowDates(obj.root.AssessmentType);

                lblSubNo.setValue(obj.root.AssessmentNo);

                view.query('.field,.combo').forEach(function(c){c.setReadOnly(true);});

            },
            failure:  function ( result, request ) { 

                wait.hide();

                msg("FAILURE","Error in Saving data !!!");        
            }
        });
    },

    loadDetailsForAU: function(param,view) {
        var me = this;
        var wait  = waitMsg('Loading Preview ...');

        var actionAU     = "";
        var offCodeAU    = "";
        var requestNo    = "";
        var submissionNo = "";

        actionAU = param.auAction;
        requestNo = param.requestNo;
        offCodeAU = param.offCode;
        submissionNo = param.pks[0].data.Value;

        Ext.Ajax.request({
            url:"../Handlers/IncomeTax/D01/AssessmentSADoneHandler.ashx?method=GetDCTBAssessmentD03ForAU" ,
            params:{actionAU:actionAU,offCodeAU:offCodeAU,requestNo:requestNo,submissionNo:submissionNo},
            async : false,
            success: function ( result, request ) {   

                wait.hide();        
                var obj = Ext.decode(result.responseText);  
                var lblSubNo = Ext.ComponentQuery.query('#lblSubmissionNoMD03')[0];

                var txtSubmissionNo = Ext.ComponentQuery.query('#txtSubmissionNoMD03')[0];   

                var btnRegister = Ext.ComponentQuery.query('#btnRegisterMD03')[0];        
                var btnUpdate = Ext.ComponentQuery.query('#btnUpdateMD03')[0];
                var btnEdit = Ext.ComponentQuery.query('#btnEditMD03')[0];
                var btnEnterAnnex = Ext.ComponentQuery.query('#btnEnterAnnexMD03')[0];

                var hdnRecStatus =  Ext.ComponentQuery.query('#hdnRecordStatusMD03')[0]; 

                Ext.ComponentQuery.query('#txtPanNoMD03')[0].setValue(obj.root.Pan);
                Ext.ComponentQuery.query('#cboFiscalYearMD03')[0].setValue(obj.root.FiscalYear);

                me.loadControls(obj);
                me.loadControlsForITaxLogin(obj.root);        
                me.loadAnxSummary(obj.root.AssessmentNo);        

                hdnRecStatus.setValue(obj.root.RecordStatus);

                btnRegister.setVisible(false);
                btnUpdate.setVisible(false);
                btnEdit.setVisible(false);
                btnEnterAnnex.setVisible(true);

                txtSubmissionNo.setVisible(false);
                txtSubmissionNo.setValue(obj.root.AssessmentNo);

                me.hideShowDates(obj.root.AssessmentType);

                lblSubNo.setValue(obj.root.AssessmentNo);

                //view.query('.field,.combo').forEach(function(c){c.setReadOnly(true);});

            },
            failure:  function ( result, request ) { 

                wait.hide();

                msg("FAILURE","Error in Saving data !!!");        
            }
        });

    },

    validateParam: function() {
        var me = this;
        var view = Ext.ComponentQuery.query('#pnlSelfAssessmentMD03')[0];
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

    init: function(application) {
        this.control({
            "#pnlSelfAssessmentMD03": {
                afterrender: this.onPnlManualSelfAssmtMD03AfterRender
            },
            "#txtPanNoMD03": {
                keypress: this.onTxtPanNoMD03Keypress
            },
            "#txtSubmissionNoMD03": {
                keypress: this.onTxtSubmissionNoMD03Keypress
            },
            "#btnUpdateMD03": {
                click: this.onBtnUpdateMD03Click
            },
            "#cboFiscalYearMD03": {
                change: this.onCboFiscalYearMD03Change
            },
            "#rgbtnClubbedPanMD03": {
                change: this.onRgbtnClubbedPanChange
            },
            "combobox": {
                select: this.onCboTaxPayerTypeMD03Select
            },
            "#btnRegisterMD03": {
                click: this.onBtnRegisterMD03Click
            },
            "#btnEditMD03": {
                click: this.onBtnEditMD03Click
            },
            "#txtAuditorPanNoMD03": {
                keypress: this.onTxtAuditorPanNoMD03Keypress
            },
            "#txtAuditorNameMD03": {
                blur: this.onTxtAuditorNameMD03Blur
            }
        });
    }

});
