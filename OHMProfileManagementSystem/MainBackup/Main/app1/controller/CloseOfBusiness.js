/*
 * File: app/controller/CloseOfBusiness.js
 *
 * This file was generated by Sencha Architect version 2.1.0.
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

Ext.define('MyApp.controller.CloseOfBusiness', {
    extend: 'Ext.app.Controller',

    stores: [
        'FilingPeriodStore',
        'ReferenceBasisStore'
    ],

    onFrmCloseOfBusinessAfterRender: function(abstractcomponent, options) {
        //----------------------------------------------------------------
        //------------------LOGGING USER ACTIVITY ------------------------
        //----------------------------------------------------------------
        var userActivity={
            ApplicationID:'VAT',
            ModuleID:'VCB',
            UserID:'ITS',
            Action:'ENTER'
        };

        LogUserActivity(userActivity);


        //----------------------------------------------------------------
        //------------------ENDS LOGGING USER ACTIVITY -------------------
        //----------------------------------------------------------------

        $(document).ready(function(){

            $('tr').has('.exclude').children('td').css({backgroundColor:'#DFE9F6',border:0});
            $('tr').has('.exclude').css({backgroundColor:'#DFE9F6',border:0});
            $('.tablegrid .x-table-layout').css({border:0});
        }
        );
    },

    onTxtTaxYearBlur: function(field, options) {
        var me=this;
        var taxyear=Ext.ComponentQuery.query("#txtTaxYear")[0].getValue();
        if(taxyear===null)
        {
            return;
        }

        //VALIDATING TAX YEAR
        ValidateTaxyear(taxyear,function(invalidMsg){
            if(invalidMsg!=='')
            {
                msg('INFO',invalidMsg);
                Ext.ComponentQuery.query('#hdnVTaxyear')[0].setValue('INVALID');

                return;
            }
            else
            {
                Ext.ComponentQuery.query('#hdnVTaxyear')[0].setValue('');
            }
        });
        //ENDS VALIDATING TAX YEAR


    },

    onTxtVatOnSaleChange: function(field, newValue, oldValue, options) {
        var me =this;
        me.CalculateTotalDebit(Ext.ComponentQuery.query("#txtVatOnSale")[0].getValue(),Ext.ComponentQuery.query("#txtAdjDebit")[0].getValue(),Ext.ComponentQuery.query("#txtStockTax")[0].getValue());
    },

    onTxtVatOnPurchaseChange: function(field, newValue, oldValue, options) {
        var me=this;
        var vatOnPurchase="0";
        var vatOnPurI="0";
        var adjCredit="0";

        vatOnPurchase=Ext.ComponentQuery.query("#txtVatOnPurchase")[0].getValue();
        vatOnPurI=Ext.ComponentQuery.query("#txtVatOnPurI")[0].getValue();
        adjCredit=Ext.ComponentQuery.query("#txtAdjCredit")[0].getValue();

        me.CalculateTotalCredit(vatOnPurchase,vatOnPurI,adjCredit);
    },

    onTxtVatOnPurIChange: function(field, newValue, oldValue, options) {
        var me=this;
        var vatOnPurchase="0";
        var vatOnPurI="0";
        var adjCredit="0";

        vatOnPurchase=Ext.ComponentQuery.query("#txtVatOnPurchase")[0].getValue();
        vatOnPurI=Ext.ComponentQuery.query("#txtVatOnPurI")[0].getValue();
        adjCredit=Ext.ComponentQuery.query("#txtAdjCredit")[0].getValue();

        me.CalculateTotalCredit(vatOnPurchase,vatOnPurI,adjCredit);
    },

    onTxtAdjCreditChange: function(field, newValue, oldValue, options) {
        var me=this;
        var vatOnPurchase="0";
        var vatOnPurI="0";
        var adjCredit="0";

        vatOnPurchase=Ext.ComponentQuery.query("#txtVatOnPurchase")[0].getValue();
        vatOnPurI=Ext.ComponentQuery.query("#txtVatOnPurI")[0].getValue();
        adjCredit=Ext.ComponentQuery.query("#txtAdjCredit")[0].getValue();

        me.CalculateTotalCredit(vatOnPurchase,vatOnPurI,adjCredit);
    },

    onTxtAdjDebitChange: function(field, newValue, oldValue, options) {
        var me=this;
        me.CalculateTotalDebit(Ext.ComponentQuery.query("#txtVatOnSale")[0].getValue(),Ext.ComponentQuery.query("#txtAdjDebit")[0].getValue(),Ext.ComponentQuery.query("#txtStockTax")[0].getValue());
    },

    onTxtStockTaxChange: function(field, newValue, oldValue, options) {
        var me=this;
        me.CalculateTotalDebit(Ext.ComponentQuery.query("#txtVatOnSale")[0].getValue(),Ext.ComponentQuery.query("#txtAdjDebit")[0].getValue(),Ext.ComponentQuery.query("#txtStockTax")[0].getValue());
    },

    onTxtTotalCreditChange: function(field, newValue, oldValue, options) {
        var diff=this.CalculateVatDueTM(Number(Ext.ComponentQuery.query("#txtTotalCredit")[0].getValue()),Number(Ext.ComponentQuery.query("#txtTotalDebit")[0].getValue()));


    },

    onTxtTotalDebitChange: function(field, newValue, oldValue, options) {
        var me=this;
        var diff=me.CalculateVatDueTM(Number(Ext.ComponentQuery.query("#txtTotalCredit")[0].getValue()),Number(Ext.ComponentQuery.query("#txtTotalDebit")[0].getValue()));

    },

    onTxtVatDueTMChange: function(field, newValue, oldValue, options) {
        var me=this;
        me.CalculateVatDue(Ext.ComponentQuery.query("#txtVatDueTM")[0].getValue(),Ext.ComponentQuery.query("#txtCreditBF")[0].getValue());

    },

    onTxtCreditBFChange: function(field, newValue, oldValue, options) {
        var me=this;
        me.CalculateVatDue(Ext.ComponentQuery.query("#txtVatDueTM")[0].getValue(),Ext.ComponentQuery.query("#txtCreditBF")[0].getValue());
    },

    onTxtVatDueChange: function(field, newValue, oldValue, options) {
        var vatDue=Ext.ComponentQuery.query('#txtVatDue')[0];
        if(vatDue.getValue()>0)
        {
            Ext.ComponentQuery.query('#txtRefClaimAmt')[0].disable();
            Ext.ComponentQuery.query('#txtRefClaimAmt')[0].setValue('0');
        }
        else
        {
            Ext.ComponentQuery.query('#txtRefClaimAmt')[0].enable();
        }
    },

    onTxtRefClaimAmtBlur: function(field, options) {
        var me=this;
        var refClaimAmt=Ext.ComponentQuery.query("#txtRefClaimAmt")[0].getValue();
        var vatDue=Ext.ComponentQuery.query("#txtVatDue")[0].getValue();


        var refBasis=Ext.ComponentQuery.query("#ddlReferenceBasis");
        vatDue=vatDue===null?0:-vatDue;
        if(refClaimAmt>0)
        {
            if(refClaimAmt>vatDue)
            {

                msg('INFO','कर फिर्ता माग गरिएको रकम जम्मा क्रेडिट भन्दा बढी हुनुहुन्न।');
                Ext.ComponentQuery.query("#ddlReferenceBasis")[0].setVisible(false);
                return;
            }
        }


        if(Number(refClaimAmt)>0)
        {
            Ext.ComponentQuery.query("#ddlReferenceBasis")[0].setVisible(true);
        }
        else
        {
            Ext.ComponentQuery.query("#ddlReferenceBasis")[0].setVisible(false);
        }





    },

    onTxtRefClaimAmtChange: function(field, newValue, oldValue, options) {
        var refClaimAmt=Ext.ComponentQuery.query("#txtRefClaimAmt")[0].getValue();
        var refBasis=Ext.ComponentQuery.query("#ddlReferenceBasis")[0];


        if(Number(refClaimAmt)>0)
        {
            Ext.ComponentQuery.query("#ddlReferenceBasis")[0].setVisible(true);

        }
        else
        {
            Ext.ComponentQuery.query("#ddlReferenceBasis")[0].setVisible(false);
            refBasis.setValue('');
        }

    },

    onDdlReferenceBasisBlur: function(field, options) {


        var me=this;

    },

    onBtnSaveVatReturnsClick: function(button, e, options) {
        var strMessage='';

        if(Ext.ComponentQuery.query("#hfCOBAction")[0].getValue()=='S')
        {
            msg('INFO','* तपाईंले यो विवरण बुझाइसक्नु भयो।<BR><BR>तपाईंले यो विवरण फेरि बुझाउन सक्नहुन्न।');
            return;
        }

        var pan=Ext.ComponentQuery.query("#txtPan")[0].getValue();

        var filePer=Ext.ComponentQuery.query("#ddlFilingPeriod")[0].getValue()?Ext.ComponentQuery.query("#ddlFilingPeriod")[0].getValue():'';
        var taxyear=Ext.ComponentQuery.query("#txtTaxYear")[0].getValue();
        var period=Ext.ComponentQuery.query("#ddlPeriod")[0].getValue()?Ext.ComponentQuery.query("#ddlPeriod")[0].getValue():'';


        //Validating Pan
        if(pan===''||pan===null)
        {
            strMessage+='<BR>* तपाईंले प्यान अनिबार्य रूपमा भर्नु पर्नेछ।';
        }
        else
        {
            var isValid=ValidatePan(pan,'00');
            if(isValid===false)
            {
                strMessage+='<BR>* तपाईंले भर्नु भएको प्यान नं मिलेन।';
                //return;
            }
        }

        //Validating Taxyear
        if(taxyear===''|| taxyear===null)
        {
            strMessage+='<BR>* कर वर्ष अनिवार्य रूपमा भर्नु पर्नेछ।';
        }
        else
        {
            if(Ext.ComponentQuery.query('#hdnVTaxyear')[0].getValue()==='INVALID')
            {
                strMessage+='<BR>* तपाईंले भर्नु भएको कर वर्ष मिलेन।';
            }
        }

        if(filePer===''||filePer===null)
        {
            strMessage+='<BR>* मा.\\ चौ. \\ व्दै अनिवार्य रूपमा भर्नु पर्नेछ।';
        }

        if(period===''||period===null)
        {
            strMessage+='<BR>* अवधी अनिवार्य रूपमा भर्नु पर्नेछ।';
        }




        if(strMessage!=='')
        {
            msg('INFO',strMessage);
            return;
        }

        if(Ext.ComponentQuery.query('#hdnVFilingPeriod')[0].getValue()==='INVALID')
        {
            msg('INFO','<BR>* तपाईंले भर्नुभएको फाइलिंग पिरियड मिलेन।');
            return;
        }



        var me=this;
        //var VoucherDetailsJson=this.getJson(Ext.getStore('VoucherDetailsStore'));

        //SETTING VAT RETURNS ATTRIBUTES
        var objVatReturns={
            SubmissionNumber:Ext.ComponentQuery.query("#lblSubmissionNo")[0].getValue(),
            AcctType : Ext.ComponentQuery.query("#txtAccountType")[0].getValue(),
            TaxYear : Number(Ext.ComponentQuery.query("#txtTaxYear")[0].getValue()),
            FilePer : Ext.ComponentQuery.query("#ddlFilingPeriod")[0].getValue(),
            Period : Number(Ext.ComponentQuery.query("#ddlPeriod")[0].getValue()),
            RecDate : Ext.get('nepDate').dom.innerHTML,
            TaxableSale : Number(Ext.ComponentQuery.query("#txtTaxableSale")[0].getValue()),
            VATOnSale : Number(Ext.ComponentQuery.query("#txtVatOnSale")[0].getValue()),
            VATOnPur : Number(Ext.ComponentQuery.query("#txtVatOnPurchase")[0].getValue()),
            TaxablePurI : Number(Ext.ComponentQuery.query("#txtTaxablePurI")[0].getValue()),
            VATOnPurI : Number(Ext.ComponentQuery.query("#txtVatOnPurI")[0].getValue()),
            ExemptSale : Number(Ext.ComponentQuery.query("#txtExemptSale")[0].getValue()),
            TaxablePurchase : Number(Ext.ComponentQuery.query("#txtTaxablePurchase")[0].getValue()),
            ExemptPur : Number(Ext.ComponentQuery.query("#txtExemptPurchase")[0].getValue()),
            ExemptPurI : Number(Ext.ComponentQuery.query("#txtExemptPurI")[0].getValue()),
            CreditBF : Number(Ext.ComponentQuery.query("#txtCreditBF")[0].getValue()),
            TDStockAmount : Ext.ComponentQuery.query("#txtStockAmount")[0].getValue(),
            TDStockTax : Ext.ComponentQuery.query("#txtStockTax")[0].getValue(),
            AdjCredit : Number(Ext.ComponentQuery.query("#txtAdjCredit")[0].getValue()),
            AdjDebit : Number(Ext.ComponentQuery.query("#txtAdjDebit")[0].getValue()),
            Export : Number(Ext.ComponentQuery.query("#txtExport")[0].getValue()),
            Penalty : 0,
            Interest : 0,
            TotalCredit : Number(Ext.ComponentQuery.query("#txtTotalCredit")[0].getValue()),
            TotalDebit : Number(Ext.ComponentQuery.query("#txtTotalDebit")[0].getValue()),
            TotalVatTM : Number(Ext.ComponentQuery.query("#txtVatDueTM")[0].getValue()),
            VATDue : Number(Ext.ComponentQuery.query("#txtVatDue")[0].getValue()),
            RefClaimAmt : Number(Ext.ComponentQuery.query("#txtRefClaimAmt")[0].getValue()),
            TranDate : Ext.get('nepDate').dom.innerHTML,
            RTType : 'CB',
            OffCode : Ext.get('offCode').dom.innerHTML,
            BatchNo : '',
            UserID : '',
            RBID : Ext.ComponentQuery.query("#ddlReferenceBasis")[0].getValue(),
            Action : Ext.ComponentQuery.query("#hfCOBAction")[0].getValue()
        };
        //ENDS SETTING VAT RETURNS ATTRIBUTES

        var frm=Ext.getCmp('frmCloseOfBusiness');

        var form = button.up('form').getForm();
        if(form)
        {
            console.log(form);
        }


        var arr=[];

        if(form.isValid()){

            form.submit({
                url: '../Handlers/Vat/VatReturnsHandler.ashx',
                waitMsg: 'Saving Vat Returns...',
                params:{method:'SaveVatReturns',
                vatReturns:JSON.stringify(objVatReturns)},
                success: function(p1, o) {

                    var JSONResponse=Ext.decode(o.response.responseText);
                    if(JSONResponse.success=='True')
                    {  
                        Ext.Msg.show({
                            title:'INFO',
                            msg: '* तपाईंको विवरण सफलतापुर्ण सेभ भयो।<BR>कृपया सब्मिसन नं टिप्नु होला।<BR><BR>तपाईको सब्मिसन नं : <B STYLE="COLOR:RED">'+Ext.ComponentQuery.query("#lblSubmissionNo")[0].getValue()+'<\B>',
                            buttons: Ext.Msg.OK,
                            fn: function (btn){
                                if(btn=='ok'){     
                                    //RESET DEFAULTS

                                    //var fp=Ext.ComponentQuery.query('#frmVatReturns')[0];
                                    //fp.getForm().reset();


                                    Ext.ComponentQuery.query("#hfCOBAction")[0].setValue('E');
                                    //var txtAcctType=Ext.ComponentQuery.query("#txtAccountType")[0];
                                    //txtAcctType.setValue('00');

                                }
                            }
                        });

                    }
                    else
                    {
                        msg('INFO','Failed Saving Close Of Business');
                    }
                },
                failure:function(fp, o) {
                    alert("err");
                }
            });
        }

    },

    onBtnPrintClick: function(button, e, options) {
        var userActivity={
            ApplicationID:'VAT',
            ModuleID:'VCB',
            UserID:'ITS',
            Action:'PRINT'
        };

        LogUserActivity(userActivity);

        var param = { 
            'SubmissionNo' : Ext.ComponentQuery.query('#lblSubmissionNo')[0].getValue()
        };

        var url="../Reporting/Vat/ReportHandlers/CloseOfBusiness/CloseOfBusinessReportHandler.ashx";
        var winOption="width=730,height=345,left=100,top=100,resizable=yes,scrollbars=yes";
        OpenWindowWithPost(url,winOption,"NewFile", param);

    },

    onBtnSubmitVatReturnsClick: function(button, e, options) {
        var me=this;

        var strDec=Ext.ComponentQuery.query('#chkDec')[0];

        if(strDec.getValue()===false)
        {
            msg('INFO', 'यो विवरण साँचो हो भन्ने विवरण चेक गर्नुहोस्।');
            return;
        }

        if(Ext.ComponentQuery.query("#hfCOBAction")[0].getValue()=='S')
        {
            msg('INFO','* तपाईंले यो विवरण बुझाइसक्नु भयो।<BR><BR>तपाईंले यो विवरण फेरि बुझाउन सक्नहुन्न।');
            return;
        }

        var submissionNo=Ext.ComponentQuery.query("#lblSubmissionNo")[0].getValue();
        var filePer=Ext.ComponentQuery.query("#ddlFilingPeriod")[0].getValue()?Ext.ComponentQuery.query("#ddlFilingPeriod")[0].getValue():'';
        var taxyear=Ext.ComponentQuery.query("#txtTaxYear")[0].getValue();
        var period=Ext.ComponentQuery.query("#ddlPeriod")[0].getValue()?Ext.ComponentQuery.query("#ddlPeriod")[0].getValue():'';
        var pan=Ext.ComponentQuery.query("#txtPan")[0].getValue();
        var acctType=Ext.ComponentQuery.query("#txtAccountType")[0].getValue();
        var registrationDate=Ext.ComponentQuery.query('#hdnRegistrationDate')[0].getValue();
        var strMessage='';


        //Validating Pan
        if(pan===''||pan===null)
        {
            strMessage+='<BR>* तपाईंले प्यान अनिबार्य रूपमा भर्नु पर्नेछ।';
        }
        else
        {
            var isValid=ValidatePan(pan,'00');
            if(isValid===false)
            {
                strMessage+='<BR>* तपाईंले भर्नु भएको प्यान नं मिलेन।';
                //return;
            }
        }

        //Validating Taxyear
        if(taxyear===''|| taxyear===null)
        {
            strMessage+='<BR>* कर वर्ष अनिवार्य रूपमा भर्नु पर्नेछ।';
        }
        else
        {
            if(Ext.ComponentQuery.query('#hdnVTaxyear')[0].getValue()==='INVALID')
            {
                strMessage+='<BR>* तपाईंले भर्नु भएको कर वर्ष मिलेन।';
            }
        }

        if(filePer===''||filePer===null)
        {
            strMessage+='<BR>* मा.\\ चौ. \\ व्दै अनिवार्य रूपमा भर्नु पर्नेछ।';
        }

        if(period===''||period===null)
        {
            strMessage+='<BR>* अवधी अनिवार्य रूपमा भर्नु पर्नेछ।';
        }






        var refClaimAmt=Ext.ComponentQuery.query("#txtRefClaimAmt")[0].getValue();
        var vatDue=Ext.ComponentQuery.query("#txtVatDue")[0].getValue();


        var refBasis=Ext.ComponentQuery.query("#ddlReferenceBasis");
        vatDue=vatDue===null?0:-vatDue;
        if(refClaimAmt>0)
        {
            if(refClaimAmt>vatDue)
            {

                strMessage+='कर फिर्ता माग गरिएको रकम जम्मा क्रेडिट भन्दा बढी हुनुहुन्न।';
                Ext.ComponentQuery.query("#ddlReferenceBasis")[0].setVisible(false);

            }
        }



        if(strMessage!=='')
        {
            msg('INFO',strMessage);
            return;
        }



        if(Ext.ComponentQuery.query('#hdnVFilingPeriod')[0].getValue()==='INVALID')
        {
            msg('INFO','<BR>* तपाईंले भर्नुभएको फाइलिंग पिरियड मिलेन।');
            return;
        }



        //--------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------
        //***************************Save Vat Returns*******************************************************
        //--------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------

        //var VoucherDetailsJson=this.getJson(Ext.getStore('VoucherDetailsStore'));

        var objVatReturns={
            SubmissionNumber:Ext.ComponentQuery.query("#lblSubmissionNo")[0].getValue(),
            AcctType : Ext.ComponentQuery.query("#txtAccountType")[0].getValue(),
            TaxYear : Number(Ext.ComponentQuery.query("#txtTaxYear")[0].getValue()),
            FilePer : Ext.ComponentQuery.query("#ddlFilingPeriod")[0].getValue(),
            Period : Number(Ext.ComponentQuery.query("#ddlPeriod")[0].getValue()),
            RecDate : Ext.get('nepDate').dom.innerHTML,
            TaxableSale : Number(Ext.ComponentQuery.query("#txtTaxableSale")[0].getValue()),
            VATOnSale : Number(Ext.ComponentQuery.query("#txtVatOnSale")[0].getValue()),
            VATOnPur : Number(Ext.ComponentQuery.query("#txtVatOnPurchase")[0].getValue()),
            TaxablePurI : Number(Ext.ComponentQuery.query("#txtTaxablePurI")[0].getValue()),
            VATOnPurI : Number(Ext.ComponentQuery.query("#txtVatOnPurI")[0].getValue()),
            ExemptSale : Number(Ext.ComponentQuery.query("#txtExemptSale")[0].getValue()),
            TaxablePurchase : Number(Ext.ComponentQuery.query("#txtTaxablePurchase")[0].getValue()),
            ExemptPur : Number(Ext.ComponentQuery.query("#txtExemptPurchase")[0].getValue()),
            ExemptPurI : Number(Ext.ComponentQuery.query("#txtExemptPurI")[0].getValue()),
            CreditBF : Number(Ext.ComponentQuery.query("#txtCreditBF")[0].getValue()),
            TDStockAmount : Ext.ComponentQuery.query("#txtStockAmount")[0].getValue(),
            TDStockTax : Ext.ComponentQuery.query("#txtStockTax")[0].getValue(),
            AdjCredit : Number(Ext.ComponentQuery.query("#txtAdjCredit")[0].getValue()),
            AdjDebit : Number(Ext.ComponentQuery.query("#txtAdjDebit")[0].getValue()),
            Export : Number(Ext.ComponentQuery.query("#txtExport")[0].getValue()),
            Penalty : 0,
            Interest : 0,
            TotalCredit : Number(Ext.ComponentQuery.query("#txtTotalCredit")[0].getValue()),
            TotalDebit : Number(Ext.ComponentQuery.query("#txtTotalDebit")[0].getValue()),
            TotalVatTM : Number(Ext.ComponentQuery.query("#txtVatDueTM")[0].getValue()),
            VATDue : Number(Ext.ComponentQuery.query("#txtVatDue")[0].getValue()),
            RefClaimAmt : Number(Ext.ComponentQuery.query("#txtRefClaimAmt")[0].getValue()),
            TranDate : Ext.get('nepDate').dom.innerHTML,
            RTType : 'CB',
            OffCode : Ext.get('offCode').dom.innerHTML,
            BatchNo : '',
            UserID : '',
            RBID : Ext.ComponentQuery.query("#ddlReferenceBasis")[0].getValue(),
            Action : Ext.ComponentQuery.query("#hfCOBAction")[0].getValue()
        };


        //SETTING LOGIN TBS ATTRIBUTES
        var LoginTBs={
            SubmissionNumber:submissionNo,
            Username:'',
            Password:'',
            PAN:pan,
            Emailid:'',
            ContactNo:'',
            submittedFor:'VCB',
            SubmittedYN:'Y',
            SubmittedDate:Ext.decode(AppWakeUpJSON).root.NepaliDate,
            TranNo:'0',
            Address:'',
            RegOffice:'0',
            VatReturns:objVatReturns,
            Action:Ext.ComponentQuery.query("#hfCOBAction")[0].getValue()
        };
        //ENDS SETTING LOGIN TBS ATTRIBUTES


        var frm=Ext.getCmp('frmCloseOfBusiness');

        var form = button.up('form').getForm();
        if(form)
        {
            console.log(form);
        }


        if(form.isValid()){
            Ext.Msg.show({
                title:'INFO',
                msg: 'एकचोटि बुझाइसकेपछि तपाईंले यो विवरणमा सच्चाउन सक्नुहुन्न। <BR> तपाईं यो विवरण बुझाउन चाहनुहुन्छ?',
                buttons: Ext.Msg.YESNO,
                fn: function (btn){
                    if(btn=='yes'){     
                        Ext.Ajax.request({
                            url: '../Handlers/VAT/VatReturnsSubmissionNumberHandler.ashx',
                            params: {
                                method:'ValidateEVatReturns',
                                LoginTBS: JSON.stringify(LoginTBs)
                            },
                            success: function(response){
                                var JSONResponse=Ext.decode(response.responseText);

                                if(JSONResponse.success=='true')
                                {
                                    var resp=JSONResponse.root.split('&&');

                                    if(resp.length==3)
                                    {

                                        errCode=JSONResponse.root.split('&&')[0];
                                        errDesc=JSONResponse.root.split('&&')[1];
                                        submissionNo=JSONResponse.root.split('&&')[2];

                                        msg('INFO','तपाईंले बुझाउनु भएको विवरणमा निम्न प्रकारका गलतीहरु छन्।<BR>कृपया विवरण बुझाउनको लागि गलतीहरू सच्चयाउनु होला।<BR>तपाईको विवरणमा गलतीहरू..<BR><BR>'+errDesc);
                                    }
                                    else
                                    {
                                        submissionNo=JSONResponse.root.split('&&')[0];
                                        msg('INFO','तपाईंको विवरण सब्मित भयो।<BR>तपाईको सब्मिसन नं : <B STYLE="COLOR:RED">'+submissionNo+'<\B>');

                                        //var fp=Ext.ComponentQuery.query('#frmVatReturns')[0];
                                        //fp.getForm().reset();

                                        //RESET DEFAULTS
                                        Ext.ComponentQuery.query("#hfCOBAction")[0].setValue('S');
                                        var txtAcctType=Ext.ComponentQuery.query("#txtAccountType")[0];
                                        txtAcctType.setValue('00');
                                        Ext.ComponentQuery.query("#rtStatus")[0].setValue('S');
                                        Ext.ComponentQuery.query("#hfRTStatus")[0].setValue('Y');
                                    }
                                }
                            }
                        });
                    }
                    else{
                        return;
                    }
                },
                icon: Ext.Msg.INFO
            });

        }

        //***************************************************************************************************
        //***************************************************************************************************
        //***************************************************************************************************
        //***************************************************************************************************
        //***************************************************************************************************

    },

    onBtnVerifyClick: function(button, e, options) {

    },

    onDdlFilingPeriodChange: function(field, newValue, oldValue, options) {
        var combo=Ext.ComponentQuery.query("#ddlFilingPeriod")[0];
        var v = combo.getValue(); 

        if(v===''||v===null)
        {
            return;
        }

        //if(v!='M'||v!='m'||v!='T'||v!='t'||v!='B'||v!='b')
        if(v!='M'&&v!='m'&&v!='T'&&v!='t'&&v!='B'&&v!='b')
        {
            return;
        }

        var record = combo.findRecord(combo.valueField || combo.displayField, v); 
        var index = combo.store.indexOf(record);

        var ddlPeriod=Ext.ComponentQuery.query("#ddlPeriod")[0];
        ddlPeriod.setValue('');

        ddlPeriod.store.loadData(record.data.Period);

    },

    onDdlPeriodChange: function(field, newValue, oldValue, options) {

        var me=this;
        var filePer=Ext.ComponentQuery.query("#ddlFilingPeriod")[0].getValue();
        var taxyear=Ext.ComponentQuery.query("#txtTaxYear")[0].getValue();
        var period=Ext.ComponentQuery.query("#ddlPeriod")[0].getValue();
        var pan=Ext.ComponentQuery.query("#txtPan")[0].getValue();
        var acctType=Ext.ComponentQuery.query("#txtAccountType")[0].getValue();
        var registrationDate=Ext.ComponentQuery.query('#hdnRegistrationDate')[0].getValue();
        var message='';

        if(period==='')
        {
            return;
        }

        if(period<1||period>12)
        {
            return;
        }
        if(pan===''||pan===null)
        {
            message+= '<BR>* कृपया पहिला प्यान भर्नुहोला।';

        }
        if(taxyear==='0'||taxyear===null)
        {
            message+= '<BR>* कृपया पहिला कर वर्ष भर्नुहोला।';

        }


        if(Ext.ComponentQuery.query('#hdnVTaxyear')[0].getValue()==='INVALID')
        {
            message+='<BR>* तपाईले भर्नु भएको कर वर्ष मिलेन।';

        }

        if(message!=='')
        {
            Ext.ComponentQuery.query("#ddlPeriod")[0].setValue('');
            msg('INFO',message);
            return;
        }


        //VALIDATING YEAR MONTH DESCRIPTION


        Ext.Ajax.request({
            url: '../Handlers/VAT/VatUtilitiesHandler.ashx',
            params: {
                method:'GetFilePerEndDate',
                filePeriod: filePer,
                taxyear:taxyear,
                period:period
            },
            success: function(response){

                var endDate=Ext.decode(response.responseText);
                if(endDate.message==='')
                {
                    msg('INFO','* तपाईंले भर्नुभएको फाइलिंग पिरियड मिलेन।');
                    Ext.ComponentQuery.query('#hdnVFilingPeriod')[0].setValue('INVALID');
                    return;

                }
                else
                {


                    Ext.Ajax.request({
                        url: '../Handlers/VAT/VatUtilitiesHandler.ashx',
                        params: {
                            method:'GetFilePerStartDate',
                            filePeriod: filePer,
                            taxyear:taxyear,
                            period:period
                        },
                        success: function(response){
                            var startDate=Ext.decode(response.responseText);








                            //VALIDATING YEAR MONTH DESCRIPTION
                            ValidateFilingPeriod(pan,acctType,filePer,taxyear,period,registrationDate,function(errMessage){
                                if(errMessage!=='')
                                {
                                    msg('INFO',errMessage);
                                    Ext.ComponentQuery.query('#hdnVFilingPeriod')[0].setValue('INVALID');
                                    return;
                                }
                                else
                                {
                                    if(endDate.message<Ext.get('nepDate').dom.innerHTML||startDate.message>Ext.get('nepDate').dom.innerHTML)
                                    {
                                        msg('INFO','* तपाईले यो फाइलिंग पिरियडमा आफ्नो कारोवार बन्द गर्न सक्नु हुन्न।');
                                        Ext.ComponentQuery.query("#ddlPeriod")[0].setValue('');
                                        Ext.ComponentQuery.query('#hdnVFilingPeriod')[0].setValue('INVALID');
                                        return;
                                    }
                                    else
                                    {
                                        GetNFPeriod(pan, acctType,startDate.message,function(obj){
                                            console.log(obj);
                                            if(obj.message!=='')
                                            {
                                                var err='तपाईको निम्न पिरियडहरू फाइल गर्न बांकि छ।<BR><BR>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;'+obj.message+'<BR><BR>कृपया पहिले बांकि फाईलिंग पिरियडहरू भर्नुहोला।';
                                                msg('INFO',err);
                                                Ext.ComponentQuery.query('#hdnNFText')[0].setValue(err);
                                                Ext.ComponentQuery.query("#ddlPeriod")[0].setValue('');
                                                return;
                                            }
                                            else
                                            {
                                                Ext.ComponentQuery.query('#hdnNFText')[0].setValue('');

                                            }
                                            Ext.ComponentQuery.query('#hdnVFilingPeriod')[0].setValue('VALID');

                                        });

                                    }
                                }
                            });



                        }   
                    });




                }







            }
        });

    },

    CalculateTotalCredit: function(amtVatOnPurchase, amtVatOnPurI, amtAdjCredit) {

        Ext.ComponentQuery.query("#txtTotalCredit")[0].setValue(Number(amtVatOnPurchase)+Number(amtVatOnPurI)+Number(amtAdjCredit));
    },

    CalculateVatDueTM: function(amtTotalCredit, amtTotalDebit) {
        Ext.ComponentQuery.query("#txtVatDueTM")[0].setValue(Number(amtTotalDebit)-Number(amtTotalCredit));
    },

    CalculateTotalDebit: function(amtVatOnSale, amtAdjDebit, amtStockTax) {
        Ext.ComponentQuery.query("#txtTotalDebit")[0].setValue(Number(amtVatOnSale)+Number(amtAdjDebit)+amtStockTax);
    },

    CalculateVatDue: function(amtVatDueTM, amtCreditBF) {
        Ext.ComponentQuery.query("#txtVatDue")[0].setValue(Number(amtVatDueTM)-Number(amtCreditBF));

    },

    init: function(application) {
        this.control({
            "#frmCloseOfBusiness": {
                afterrender: this.onFrmCloseOfBusinessAfterRender
            },
            "#txtTaxYear": {
                blur: this.onTxtTaxYearBlur
            },
            "#txtVatOnSale": {
                change: this.onTxtVatOnSaleChange
            },
            "#txtVatOnPurchase": {
                change: this.onTxtVatOnPurchaseChange
            },
            "#txtVatOnPurI": {
                change: this.onTxtVatOnPurIChange
            },
            "#txtAdjCredit": {
                change: this.onTxtAdjCreditChange
            },
            "#txtAdjDebit": {
                change: this.onTxtAdjDebitChange
            },
            "#txtStockTax": {
                change: this.onTxtStockTaxChange
            },
            "#txtTotalCredit": {
                change: this.onTxtTotalCreditChange
            },
            "#txtTotalDebit": {
                change: this.onTxtTotalDebitChange
            },
            "#txtVatDueTM": {
                change: this.onTxtVatDueTMChange
            },
            "#txtCreditBF": {
                change: this.onTxtCreditBFChange
            },
            "#txtVatDue": {
                change: this.onTxtVatDueChange
            },
            "#txtRefClaimAmt": {
                blur: this.onTxtRefClaimAmtBlur,
                change: this.onTxtRefClaimAmtChange
            },
            "#ddlReferenceBasis": {
                blur: this.onDdlReferenceBasisBlur
            },
            "#btnSaveVatReturns": {
                click: this.onBtnSaveVatReturnsClick
            },
            "#btnPrint": {
                click: this.onBtnPrintClick
            },
            "#btnSubmitVatReturns": {
                click: this.onBtnSubmitVatReturnsClick
            },
            "#btnVerify": {
                click: this.onBtnVerifyClick
            },
            "#ddlFilingPeriod": {
                change: this.onDdlFilingPeriodChange
            },
            "#ddlPeriod": {
                change: this.onDdlPeriodChange
            }
        });
    }

});
