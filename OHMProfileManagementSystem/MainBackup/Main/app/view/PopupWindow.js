/*
 * File: app/view/PopupWindow.js
 *
 * This file was generated by Sencha Architect version 3.0.4.
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

Ext.define('MyApp.view.PopupWindow', {
    extend: 'Ext.window.Window',

    requires: [
        'Ext.panel.Panel',
        'Ext.button.Button'
    ],

    height: 800,
    id: 'PopupWindow',
    itemId: 'PopupWindow',
    width: 800,
    layout: 'fit',
    title: 'Preview Window',

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'panel',
                    frame: true,
                    itemId: 'prevWinRegPanel',
                    margin: 5,
                    title: 'You have requested PAN for ',
                    layout: {
                        type: 'vbox',
                        align: 'stretch'
                    },
                    items: [
                        {
                            xtype: 'container',
                            items: [
                                {
                                    xtype: 'button',
                                    itemId: 'prevWinRegPanelbtnPPAN',
                                    margin: 5,
                                    text: 'Preview Personal Information',
                                    listeners: {
                                        click: {
                                            fn: me.onPrevWinRegPanelbtnPPANClick,
                                            scope: me
                                        }
                                    }
                                },
                                {
                                    xtype: 'button',
                                    itemId: 'prevWinRegPanelbtnITax',
                                    margin: 5,
                                    text: 'Preview Income Tax ',
                                    listeners: {
                                        click: {
                                            fn: me.onPrevWinRegPanelbtnITaxClick,
                                            scope: me
                                        }
                                    }
                                },
                                {
                                    xtype: 'button',
                                    itemId: 'prevWinRegPanelbtnVAT',
                                    margin: 5,
                                    text: 'Preview VAT',
                                    listeners: {
                                        click: {
                                            fn: me.onPrevWinRegPanelbtnVATClick,
                                            scope: me
                                        }
                                    }
                                },
                                {
                                    xtype: 'button',
                                    itemId: 'prevWinRegPanelbtnExcise',
                                    margin: 5,
                                    text: 'Preview Excise',
                                    listeners: {
                                        click: {
                                            fn: me.onPrevWinRegPanelbtnExciseClick,
                                            scope: me
                                        }
                                    }
                                }
                            ]
                        },
                        {
                            xtype: 'panel',
                            flex: 9,
                            height: 460,
                            itemId: 'prevWinRegContainer',
                            width: 869,
                            autoScroll: true,
                            title: 'Preview'
                        }
                    ]
                },
                {
                    xtype: 'panel',
                    frame: true,
                    height: 650,
                    itemId: 'testVer',
                    autoScroll: true,
                    layout: 'fit'
                }
            ],
            listeners: {
                afterrender: {
                    fn: me.onPopupWindowAfterRender,
                    scope: me
                }
            }
        });

        me.callParent(arguments);
    },

    onPrevWinRegPanelbtnPPANClick: function(button, e, eOpts) {
        var PopupWindow=Ext.ComponentQuery.query('#PopupWindow')[0];

        var cont=Ext.ComponentQuery.query('#prevWinRegContainer')[0];
        var vw;
        var controller;
        if(PopupWindow.extraParam.RegistrationFor)
        {
            var submissionNo=PopupWindow.extraParam.submissionNo;


            cont.setTitle('PPAN Preview');
            controller = MyApp.app.getController('PersonRegistration');

            MyApp.app.controllers.add(controller);

            vw = Ext.create('MyApp.view.PersonRegistration',{  });
            vw.extraParam={subNo:submissionNo,busTyp:"I"};

            controller.init();
            cont.removeAll();
            cont.add(vw);
        }
        else
        {

            var pan_no=PopupWindow.extraParam.pan_no;
            var request_no=PopupWindow.extraParam.request_no;
            var office_code=PopupWindow.extraParam.office_code;
            var regFor=PopupWindow.extraParam.RegistrationForAU;
            var businessTyp=PopupWindow.extraParam.businessTyp;
            var businessSubTyp=PopupWindow.extraParam.businessSubTyp;

            cont.setTitle('PPAN Preview');
            controller = MyApp.app.getController('PersonRegistrationAU');

            MyApp.app.controllers.add(controller);

            vw = Ext.create('MyApp.view.PersonRegistrationAU',{  });
            vw.extraParam={pan_no:pan_no,request_no:request_no,office_code:office_code,
                           regFor:regFor,busTyp:businessTyp,busSubTyp:businessSubTyp};

            controller.init();
            cont.removeAll();
            cont.add(vw);
        }

        Ext.ComponentQuery.query('#PPAN_Reg_Next')[0].hide();
    },

    onPrevWinRegPanelbtnITaxClick: function(button, e, eOpts) {
        var PopupWindow=Ext.ComponentQuery.query('#PopupWindow')[0];

        var cont=Ext.ComponentQuery.query('#prevWinRegContainer')[0];
        var vw;
        var controller;
        if(PopupWindow.extraParam.RegistrationFor)
        {
            var submissionNo=PopupWindow.extraParam.submissionNo;


            cont.setTitle('ITAX Preview');
            controller = MyApp.app.getController('BusinessRegistration');

            MyApp.app.controllers.add(controller);

            vw = Ext.create('MyApp.view.BusinessRegistration',{  });
            vw.extraParam={subNo:submissionNo,busTyp:"I"};

            controller.init();
            cont.removeAll();
            cont.add(vw);
        }
        else
        {

            var pan_no=PopupWindow.extraParam.pan_no;
            var request_no=PopupWindow.extraParam.request_no;
            var office_code=PopupWindow.extraParam.office_code;
            var regFor=PopupWindow.extraParam.RegistrationForAU;
            var businessTyp=PopupWindow.extraParam.businessTyp;
            var businessSubTyp=PopupWindow.extraParam.businessSubTyp;

            cont.setTitle('ITAX Preview');
            controller = MyApp.app.getController('BusinessRegistrationAU');

            MyApp.app.controllers.add(controller);

            vw = Ext.create('MyApp.view.BusinessRegistrationAU',{  });
            vw.extraParam={pan_no:pan_no,request_no:request_no,office_code:office_code,
                           regFor:regFor,busTyp:businessTyp,busSubTyp:businessSubTyp};

            controller.init();
            cont.removeAll();
            cont.add(vw);
        }
        Ext.ComponentQuery.query('#Bus_Reg_Next')[0].hide();
    },

    onPrevWinRegPanelbtnVATClick: function(button, e, eOpts) {
        var PopupWindow=Ext.ComponentQuery.query('#PopupWindow')[0];

        var cont=Ext.ComponentQuery.query('#prevWinRegContainer')[0];
        var vw;
        var controller;
        if(PopupWindow.extraParam.RegistrationFor)
        {
            var submissionNo=PopupWindow.extraParam.submissionNo;


            cont.setTitle('VAT Preview');
            controller = MyApp.app.getController('VATRegistration');

            MyApp.app.controllers.add(controller);

            vw = Ext.create('MyApp.view.VATRegistration',{  });
            vw.extraParam={subNo:submissionNo,busTyp:"I"};

            controller.init();
            cont.removeAll();
            cont.add(vw);
        }
        else
        {

            var pan_no=PopupWindow.extraParam.pan_no;
            var request_no=PopupWindow.extraParam.request_no;
            var office_code=PopupWindow.extraParam.office_code;
            var regFor=PopupWindow.extraParam.RegistrationForAU;
            var businessTyp=PopupWindow.extraParam.businessTyp;
            var businessSubTyp=PopupWindow.extraParam.businessSubTyp;

            cont.setTitle('VAT Preview');
            controller = MyApp.app.getController('VATRegistrationAU');

            MyApp.app.controllers.add(controller);

            vw = Ext.create('MyApp.view.VATRegistrationAU',{  });
            vw.extraParam={pan_no:pan_no,request_no:request_no,office_code:office_code,
                           regFor:regFor,busTyp:businessTyp,busSubTyp:businessSubTyp};

            controller.init();
            cont.removeAll();
            cont.add(vw);
        }
        Ext.ComponentQuery.query('#VAT_Reg_Next')[0].hide();
    },

    onPrevWinRegPanelbtnExciseClick: function(button, e, eOpts) {
        var PopupWindow=Ext.ComponentQuery.query('#PopupWindow')[0];

        var cont=Ext.ComponentQuery.query('#prevWinRegContainer')[0];
        var vw;
        var controller;
        if(PopupWindow.extraParam.RegistrationFor)
        {
            var submissionNo=PopupWindow.extraParam.submissionNo;


            cont.setTitle('Excise Preview');
            controller = MyApp.app.getController('ExciseRegistration');

            MyApp.app.controllers.add(controller);

            vw = Ext.create('MyApp.view.ExciseRegistration',{  });
            vw.extraParam={subNo:submissionNo,busTyp:"I"};

            controller.init();
            cont.removeAll();
            cont.add(vw);
        }
        else
        {

            var pan_no=PopupWindow.extraParam.pan_no;
            var request_no=PopupWindow.extraParam.request_no;
            var office_code=PopupWindow.extraParam.office_code;
            var regFor=PopupWindow.extraParam.RegistrationForAU;
            var businessTyp=PopupWindow.extraParam.businessTyp;
            var businessSubTyp=PopupWindow.extraParam.businessSubTyp;

            cont.setTitle('Excise Preview');
            controller = MyApp.app.getController('ExciseRegistrationAU');

            MyApp.app.controllers.add(controller);

            vw = Ext.create('MyApp.view.ExciseRegistrationAU',{  });
            vw.extraParam={pan_no:pan_no,request_no:request_no,office_code:office_code,
                           regFor:regFor,busTyp:businessTyp,busSubTyp:businessSubTyp};

            controller.init();
            cont.removeAll();
            cont.add(vw);
        }

    },

    onPopupWindowAfterRender: function(component, eOpts) {
        var PopupWindow=Ext.ComponentQuery.query('#PopupWindow')[0];

        var panel=Ext.ComponentQuery.query('#prevWinRegPanel')[0];
        var testVer = Ext.ComponentQuery.query('#testVer')[0];

        var regFor="";
        var regForAU ="";

        if(panel !== undefined)
        {
            var btnPPAN=Ext.ComponentQuery.query('#prevWinRegPanelbtnPPAN')[0];
            var btnITax=Ext.ComponentQuery.query('#prevWinRegPanelbtnITax')[0];
            var btnVAT=Ext.ComponentQuery.query('#prevWinRegPanelbtnVAT')[0];
            var btnExcise=Ext.ComponentQuery.query('#prevWinRegPanelbtnExcise')[0];

            btnPPAN.hide();
            btnITax.hide();
            btnVAT.hide();
            btnExcise.hide();

            if(PopupWindow.extraParam.RegistrationFor)
            {
                regFor=PopupWindow.extraParam.RegistrationFor;

                panel.show();
                testVer.hide();


                for(var c=0;c<regFor.length;c++)
                {
                    if (regFor[c] == "PPAN" || regFor[c] == "I")
                    {
                        btnPPAN.show();
                    }
                    else if(regFor[c]=="ITAX")
                    {
                        btnITax.show();
                    }
                    else if(regFor[c]=="VAT")
                    {
                        btnVAT.show();
                    }
                    else if(regFor[c]=="EXCS")
                    {
                        btnExcise.show();
                    }
                }
            }
            else if(PopupWindow.extraParam.RegistrationForAU)
            {
                var win = Ext.ComponentQuery.query('#prevWinRegPanel')[0];
                win.setTitle('Authorized Update For');

                var pan_no=PopupWindow.extraParam.pan_no;
                var request_no=PopupWindow.extraParam.request_no;
                var office_code=PopupWindow.extraParam.office_code;


                Ext.Ajax.request({
                    url: '../Handlers/Registration/Taxpayer/TaxpayerInfoHandler.ashx?method=GetVatTaxpayerAU',
                    params:{pan_no:pan_no,request_no:request_no,office_code:office_code},
                    success: function ( result, request ) {
                        var data = Ext.decode(result.responseText);
                        if(data.root)
                        {
                            PopupWindow.extraParam.businessTyp=data.root.TaxpayerCategoryID;
                            PopupWindow.extraParam.businessSubTyp=data.root.TaxpayerType;
                        }

                    },
                    failure: function ( result, request ) {

                        msg('ERROR','');
                    }

                });
                regFor=PopupWindow.extraParam.RegistrationForAU;
                panel.show();
                testVer.hide();


                for(var c=0;c<regFor.length;c++)
                {
                    if(regFor[c]=="PPAN")
                    {
                        btnPPAN.show();
                    }
                    else if(regFor[c]=="ITAX")
                    {
                        btnITax.show();
                    }
                    else if(regFor[c]=="VAT")
                    {
                        btnVAT.show();
                    }
                    else if(regFor[c]=="EXCS")
                    {
                        // btnExcise.show();
                    }
                }
            }
            else
            {
                panel.hide();
            }
        }





        //---------------------------------------------------------------------------------------
        // NB: D03 Multiple form preview Case
        //---------------------------------------------------------------------------------------

        if(!regFor && !regForAU)
        {
            if(testVer !== undefined)
            {
                if(PopupWindow.extraParam.module)
                {
                    //alert("D03 !!!");
                    var moduleName = PopupWindow.extraParam.module;

                    if(moduleName === "ManualSelfAssessmentMD03")
                    {
                        testVer.show();
                        //alert("working !!!");


                        var controller = MyApp.app.getController(moduleName);
                        MyApp.app.controllers.add(controller);

                        //{params:params}

                        var vw = Ext.create('MyApp.view.'+ moduleName,{  });
                        vw.extraParam ={params:PopupWindow.extraParam?PopupWindow.extraParam:{}};


                        //var PopupWindow=Ext.ComponentQuery.query('#PopupWindow')[0];
                        //var submissionNo=PopupWindow.extraParam.submissionNo;
                        /*
                        var cont=Ext.ComponentQuery.query('#prevWinRegContainer')[0];
                        cont.setTitle('PPAN Preview');

                        var vw = Ext.create('MyApp.view.PersonRegistration',{  });
                        vw.extraParam={subNo:submissionNo,busTyp:"I"};

                        controller.init();
                        cont.removeAll();
                        cont.add(vw);

                        */


                        controller.init();// launch init() method
                        testVer.removeAll();
                        testVer.add(vw);

                    }
                }
                else
                {
                    testVer.hide();
                }
            }
        }



    }

});