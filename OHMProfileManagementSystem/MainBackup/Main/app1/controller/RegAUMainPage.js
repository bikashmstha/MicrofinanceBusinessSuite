/*
 * File: app/controller/RegAUMainPage.js
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

Ext.define('MyApp.controller.RegAUMainPage', {
    extend: 'Ext.app.Controller',

    onRegAUMainPageAfterRender: function(component, eOpts) {
        var params=Ext.ComponentQuery.query('#RegAUMainPage')[0].extraParam;
        console.log('RegAUMainPage ',RegAUMainPage);

        var pan_no		= params.pan_no;
        var request_no  = params.request_no;
        var office_code = params.office_code;
        var regFor		= "";

        var ind=Ext.ComponentQuery.query('#lbl_ind')[0];
        var business=Ext.ComponentQuery.query('#lbl_business')[0];
        var vat=Ext.ComponentQuery.query('#lbl_vat')[0];
        var excise=Ext.ComponentQuery.query('#lbl_excise')[0];

        ind.setVisible(false);
        business.setVisible(false);
        vat.setVisible(false);
        excise.setVisible(false);


        Ext.Ajax.request({
            url:"../Handlers/Registration/RegistrationsForHandler.ashx?method=GetRegistrationsForsAU",
            params:{pan_no:pan_no},
            success: function ( result, request ) { 
                var obj = Ext.decode(result.responseText);             
                var arr=[];
                var dta=obj.root;


                if(dta.length>0)
                {
                    console.log('RegFor : ',dta);
                    for(var c=0;c<dta.length;c++)
                    {
                        if(dta[c].RegFor=="PPAN")
                        {
                            ind.setVisible(true);
                            arr.push(dta[c].RegFor);
                        }
                        else if(dta[c].RegFor=="ITAX")
                        {
                            business.setVisible(true);
                            arr.push(dta[c].RegFor);
                        }
                        else if(dta[c].RegFor=="VAT")
                        {
                            vat.setVisible(true);
                            arr.push(dta[c].RegFor);
                        }
                        else if(dta[c].RegFor=="EXCS")
                        {
                            //excise.setVisible(true);
                            //arr.push(dta[c].RegFor);
                        }
                    }            
                    Ext.ComponentQuery.query('#RegAUMainPage')[0].extraParam.regFor=arr;
                }  
                else
                {
                    msg("WARNING","No Data Found!!!");
                }
            },
            failure: function ( result, request ) {
                msg("FAILURE","Error in Fetching Data !!!");
            }
        });

    },

    onRegAuBtnContinueClick: function(button, e, eOpts) {
        var params=Ext.ComponentQuery.query('#RegAUMainPage')[0].extraParam;


        var pan_no		= params.pan_no;
        var request_no  = params.request_no;
        var office_code = params.office_code;
        var regFor		= params.regFor;
        var action		= params.action;

        var businessTyp='';
        var businessSubTyp='';

        var tpInfo={PAN:pan_no,Request_No:request_no,Office_Code:office_code};


        Ext.Ajax.request({
            url:"../Handlers/Registration/Taxpayer/TaxpayerInfoHandler.ashx?method=TransferRegistrationAU",
            params:{taxpayerInfo:JSON.stringify(tpInfo)},
            success: function ( result, request ) { 
                var obj = Ext.decode(result.responseText);  




                var dta=obj.root;
                if(obj.success=="True"||obj.success=="true")
                {  
                    if(indexOf.call(regFor, "PPAN") >=0)
                    {                
                        if(indexOf.call(regFor, "ITAX") >=0)
                        {
                            Ext.Ajax.request({
                                url: '../Handlers/Registration/Taxpayer/TaxpayerInfoHandler.ashx?method=GetVatTaxpayerAU',
                                params:{pan_no:pan_no,request_no:request_no,office_code:office_code},
                                success: function ( result, request ) {
                                    var data = Ext.decode(result.responseText); 
                                    if(data.root)
                                    {                                   
                                        businessTyp=data.root.TaxpayerCategoryID;
                                        businessSubTyp=data.root.TaxpayerType;
                                        uiConfig = {menuLink:'PersonRegistrationAU',pageTitle:'Person Registration'};
                                        DynamicUI(uiConfig,function(){    
                                        },{pan_no:pan_no,request_no:request_no,office_code:office_code,regFor:regFor,busTyp:businessTyp,busSubTyp:businessSubTyp});

                                        }

                                    },
                                    failure: function ( result, request ) {

                                        msg('ERROR','');
                                    }

                                });
                            }
                            else
                            {
                                uiConfig = {menuLink:'PersonRegistrationAU',pageTitle:'Person Registration'};
                                DynamicUI(uiConfig,function(){    
                                },{pan_no:pan_no,request_no:request_no,office_code:office_code,regFor:regFor});
                                }
                            }
                            else if(indexOf.call(regFor, "ITAX") >=0)
                            {
                                Ext.Ajax.request({
                                    url: '../Handlers/Registration/Taxpayer/TaxpayerInfoHandler.ashx?method=GetVatTaxpayerAU',
                                    params:{pan_no:pan_no,request_no:request_no,office_code:office_code},
                                    success: function ( result, request ) {
                                        var data = Ext.decode(result.responseText); 
                                        if(data.root)
                                        {   
                                            businessTyp=data.root.TaxpayerCategoryID;
                                            businessSubTyp=data.root.TaxpayerType;
                                            //console.log('bikdata :',{pan_no:pan_no,request_no:request_no,office_code:office_code,busTyp:businessTyp,regFor:regFor});
                                            uiConfig = {menuLink:'BusinessRegistrationAU',pageTitle:'Business Registration'};            
                                            DynamicUI(uiConfig,function(){          
                                            },{pan_no:pan_no,request_no:request_no,office_code:office_code,busTyp:businessTyp,busSubTyp:businessSubTyp,regFor:regFor});
                                            }

                                        },
                                        failure: function ( result, request ) {

                                            msg('ERROR','');
                                        }

                                    });
                                }

                                //else if(indexOf.call(regFor, "VAT") >=0)
                                //{

                                //}
                                // else if(indexOf.call(regFor, "EXCS") >=0)
                                //{

                                //}            

                            }  
                            else
                            {
                                msg("WARNING","Error in preparing data !!!");
                            }
                        },
                        failure: function ( result, request ) {
                            msg("FAILURE","Error in preparing data !!!");
                        }
                    });



    },

    init: function(application) {
        this.control({
            "#RegAUMainPage": {
                afterrender: this.onRegAUMainPageAfterRender
            },
            "#regAuBtnContinue": {
                click: this.onRegAuBtnContinueClick
            }
        });
    }

});
