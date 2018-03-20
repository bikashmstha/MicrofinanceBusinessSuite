/*
 * File: app/controller/VatReturnsLogin.js
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

Ext.define('MyApp.controller.VatReturnsLogin', {
    extend: 'Ext.app.Controller',

    onBtnVatReturnsLoginClick: function(button, e, eOpts) {
        var me=this;
        var uiConfig='';

        var validateForm=Ext.getCmp('frmVatReturnsSubNo');

        var submissionNo=Ext.ComponentQuery.query("#txtVRSubmissionNo")[0].value;
        var username=Ext.ComponentQuery.query("#txtVRUsername")[0].value;
        var password=Ext.ComponentQuery.query("#txtVRPassword")[0].value;

        var form = button.up('form').getForm();
        if(form)
        {
            console.log(form);
        }
        if(form.isValid()){
            Ext.Ajax.request({
                url: '../Handlers/Vat/VatReturnsSubmissionNumberHandler.ashx',
                waitMsg: 'Validating User...',
                params:{method:'ValidateUser',
                    submissionNo:submissionNo,
                    username:username,
                password:password},
                success: function(response) {


                    var userInfo=Ext.decode(response.responseText);

                    //USER VALIDATION FAILED
                    if(userInfo.root==='')
                    {
                        msg('INFO','User Authentication Failed.\n Please Try with another username');
                        return;
                    }


                    /*if(userInfo.root.SubmittedYN=='N')
                    {*/

                    if(userInfo.root.submittedFor=='VRET')
                    {
                        uiConfig = {menuLink:'VatReturns',
                            pageTitle:'vat returns'
                        };

                    }


                    DynamicUI(uiConfig,function(){
                        Ext.ComponentQuery.query("#txtAccountType")[0].setValue('00');
                        Ext.ComponentQuery.query("#lblSubmissionNo")[0].setValue(submissionNo);
                        Ext.ComponentQuery.query("#txtPan")[0].setValue(userInfo.root.PAN);
                        Ext.ComponentQuery.query("#hfRTStatus")[0].setValue(userInfo.root.SubmittedYN);

                        //LOAD TAXPAYER INFO    
                        Ext.Ajax.request({
                            url: '../Handlers/Registration/Taxpayer/TPTypeHandler.ashx',
                            params: {
                                method:'GetTaxPayer',pan:userInfo.root.PAN,
                                id: 1
                            },
                            success: function(response){
                                var TaxpayerInfo =Ext.decode( response.responseText);
                                //console.log(TaxpayerInfo);
                                Ext.ComponentQuery.query("#txtAccountType")[0].setValue('00');

                                //Sets TaxPayer's Info
                                Ext.ComponentQuery.query("#lblTaxpayerName")[0].setValue(TaxpayerInfo.root.Name);
                                Ext.ComponentQuery.query("#lblTaxpayerAddress")[0].setValue(TaxpayerInfo.root.Address);
                                Ext.ComponentQuery.query("#lblTaxpayerPhoneNo")[0].setValue(TaxpayerInfo.root.Phone);
                                Ext.ComponentQuery.query("#lblTaxpayerFax")[0].setValue(TaxpayerInfo.root.Fax);

                            }
                        });


                        //LOAD VAT RETURNS DETAILS
                        Ext.Ajax.request({
                            url: '../Handlers/Vat/VatReturnsHandler.ashx',
                            params: {method:'GetVatReturn',SubNo:submissionNo,
                                id: 1
                            },
                            success: function(response){
                                var TaxpayerInfo =Ext.decode( response.responseText);

                                if(TaxpayerInfo.root!=='')
                                {



                                    //Set Taxpayer Year Month Details
                                    Ext.ComponentQuery.query("#txtTaxYear")[0].setValue(TaxpayerInfo.root.TaxYear);
                                    Ext.ComponentQuery.query("#ddlFilingPeriod")[0].setValue(TaxpayerInfo.root.FilePer);
                                    Ext.ComponentQuery.query("#ddlPeriod")[0].setValue(TaxpayerInfo.root.Period);


                                    //Set Taxpayer Transaction Details
                                    Ext.ComponentQuery.query("#txtTaxableSale")[0].setValue(TaxpayerInfo.root.TaxableSale);
                                    Ext.ComponentQuery.query("#txtVatOnSale")[0].setValue(TaxpayerInfo.root.VATOnSale);
                                    Ext.ComponentQuery.query("#txtExport")[0].setValue(TaxpayerInfo.root.Export);
                                    Ext.ComponentQuery.query("#txtExemptSale")[0].setValue(TaxpayerInfo.root.ExemptSale);
                                    Ext.ComponentQuery.query("#txtTaxablePurchase")[0].setValue(TaxpayerInfo.root.TaxablePurchase);
                                    Ext.ComponentQuery.query("#txtVatOnPurchase")[0].setValue(TaxpayerInfo.root.VATOnPur);
                                    Ext.ComponentQuery.query("#txtTaxablePurI")[0].setValue(TaxpayerInfo.root.TaxablePurI);
                                    Ext.ComponentQuery.query("#txtVatOnPurI")[0].setValue(TaxpayerInfo.root.VATOnPurI);
                                    Ext.ComponentQuery.query("#txtExemptPurchase")[0].setValue(TaxpayerInfo.root.ExemptPur);
                                    Ext.ComponentQuery.query("#txtExemptPurI")[0].setValue(TaxpayerInfo.root.ExemptPurI);
                                    Ext.ComponentQuery.query("#txtAdjCredit")[0].setValue(TaxpayerInfo.root.AdjCredit);
                                    Ext.ComponentQuery.query("#txtAdjDebit")[0].setValue(TaxpayerInfo.root.AdjDebit);
                                    Ext.ComponentQuery.query("#txtCreditBF")[0].setValue(TaxpayerInfo.root.CreditBF);
                                    Ext.ComponentQuery.query("#txtRefClaimAmt")[0].setValue(TaxpayerInfo.root.RefClaimAmt);
                                    Ext.ComponentQuery.query("#ddlReferenceBasis")[0].setValue(TaxpayerInfo.root.RBID);
                                    Ext.getCmp("hfAction").setValue(TaxpayerInfo.root.Action);
                                }       
                                else
                                {
                                    Ext.getCmp("hfAction").setValue("A");

                                }
                            }
                        });

                        if(Ext.ComponentQuery.query('#hfRTStatus')[0].getValue()=='Y')
                        {
                            msg('INFO','Returns Already Submitted.<BR>You cannot Edit the Returns.');
                            Ext.ComponentQuery.query('#btnSaveVatReturns')[0].disable(true);
                            Ext.ComponentQuery.query('#btnSubmitVatReturns')[0].disable(true);

                        }
                        if(Ext.ComponentQuery.query('#hfRTStatus')[0].getValue()=='V')
                        {
                            msg('INFO','Returns Already Verified.<BR>You cannot Edit the Returns.');
                            Ext.ComponentQuery.query('#btnSaveVatReturns')[0].disable(true);
                            Ext.ComponentQuery.query('#btnSubmitVatReturns')[0].disable(true);
                            Ext.ComponentQuery.query('#btnVerify')[0].disable(true);


                        }

                    });












                },

                failure:function(fp, o) {

                    msg('ERROR','There are Errors on the Pages');
                }
            });
        }


    },

    msg: function(title, message) {
        var rqdIcon = Ext.MessageBox.INFO;

        if(title == "FAILURE")
        rqdIcon = Ext.Msg.ERROR;
        else if(title == "WARNING")
        rqdIcon = Ext.Msg.WARNING;

        Ext.Msg.show({
            title: title,
            msg: message ,
            buttons: Ext.MessageBox.OK,
            icon: rqdIcon
        });
    },

    init: function(application) {
        this.control({
            "#btnVatReturnsLogin": {
                click: this.onBtnVatReturnsLoginClick
            }
        });
    }

});
