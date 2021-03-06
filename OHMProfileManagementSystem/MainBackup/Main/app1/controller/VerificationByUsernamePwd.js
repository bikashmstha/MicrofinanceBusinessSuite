/*
 * File: app/controller/VerificationByUsernamePwd.js
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

Ext.define('MyApp.controller.VerificationByUsernamePwd', {
    extend: 'Ext.app.Controller',

    onBtnBackClick: function(button, e, eOpts) {
        var submissionNo=Ext.ComponentQuery.query('#lblSubmissionNo')[0].getValue();
        var pan=Ext.ComponentQuery.query('#lblPan')[0].getValue();
        var application= Ext.ComponentQuery.query('#hfApplication')[0].getValue();
        var module=Ext.ComponentQuery.query('#hfModule')[0].getValue();

        var acctType=Ext.ComponentQuery.query('#hfAccountType')[0].getValue();
        var taxyear=Ext.ComponentQuery.query('#hfTaxyear')[0].getValue();
        var filePer=Ext.ComponentQuery.query('#hfFilePer')[0].getValue();
        var period=Ext.ComponentQuery.query('#hfPeriod')[0].getValue();


        var uiConfig = {menuLink:'EVatReturnsVerification',
                pageTitle:'E-Returns Verification With Username and Password'
            };


        DynamicUI(uiConfig,function(){
            Ext.ComponentQuery.query('#hfApplication')[0].setValue(application);
            Ext.ComponentQuery.query('#hfModule')[0].setValue(module);

            Ext.ComponentQuery.query('#lblSubmissionNo')[0].setValue(submissionNo);
            Ext.ComponentQuery.query('#lblPan')[0].setValue(pan);

            Ext.ComponentQuery.query('#hfAccountType')[0].setValue(acctType);
            Ext.ComponentQuery.query('#hfTaxyear')[0].setValue(taxyear);
            Ext.ComponentQuery.query('#hfFilePer')[0].setValue(filePer);
            Ext.ComponentQuery.query('#hfPeriod')[0].setValue(period);

        });

    },

    onBtnSubmitClick: function(button, e, eOpts) {
        var pan=Ext.ComponentQuery.query('#lblPan')[0].getValue();
        var submissionNo=Ext.ComponentQuery.query('#lblSubmissionNo')[0].getValue();
        var username=Ext.ComponentQuery.query('#txtUsername')[0].getValue();
        var password=Ext.ComponentQuery.query('#txtPassword')[0].getValue();
        var prevVatDue=Ext.ComponentQuery.query('#txtPreviousVatDue')[0].getValue();
        var applId=Ext.ComponentQuery.query('#hfApplication')[0].getValue();
        var moduleId=Ext.ComponentQuery.query('#hfModule')[0].getValue();

        var acctType=Ext.ComponentQuery.query('#hfAccountType')[0].getValue();
        var taxyear=Ext.ComponentQuery.query('#hfTaxyear')[0].getValue();
        var filePer=Ext.ComponentQuery.query('#hfFilePer')[0].getValue();
        var period=Ext.ComponentQuery.query('#hfPeriod')[0].getValue();


        var message='';
        if(username===''||username===null)
        {
            message+='Username Cannot Be Left Blank.<BR>';
        }
        if(password===''||password===null)
        {
            message+='Password Cannot Be Left Blank.<BR>';
        }
        if(applId=='VAT'&&moduleId=='VRET'&&(prevVatDue===''||prevVatDue===null))
        {
            message+='Previous Vat Due Cannot Be left Blank.';
        }
        if(message!=='')
        {
            msg('INFO',message);
            return;
        }



        var frm=Ext.getCmp('frmVerificationByUsernamePwd');

        var form = button.up('form').getForm();
        if(form)
        {
            console.log(form);
        }
        //\Handlers\VAT\Verification\ERetVerificationByUserPwdHandler.ashx

        var arr=[];

        if(form.isValid()){


            var userSelfVerByUserPwd={
                PAN:pan,
                Username:username,
                Password:password,
                submissionNo:submissionNo,
                PrevVatDue:prevVatDue,
                ApplId:applId,
                ModuleId:moduleId,
                AcctType:acctType,
                Taxyear:taxyear,
                FilePer:filePer,
                Period:period

            };



            form.submit({
                url: '../Handlers/Verification/UserSelfVerificationByUserPwdHandler.ashx',
                waitMsg: 'Verifying Vat Returns...',
                params:{method:'VerifyByUserPass',
                    userSelfVerByUserPwd:JSON.stringify(userSelfVerByUserPwd)
                },
                success: function(p1, o) {

                    var JSONResponse=Ext.decode(o.response.responseText);
                    console.log(JSONResponse);
                    if(JSONResponse.success=='true')
                    {  

                        msg('INFO',JSONResponse.message+'.<BR>Please Note Your Submission No.<BR><BR>Your Submission No is: <B STYLE="COLOR:RED">'+submissionNo+'<\B>');

                    }
                    else
                    {
                        msg('INFO','Failed Verifying Vat Returns');
                    }

                },
                failure:function(fp, o) {
                    alert("err");
                }
            });

        }

    },

    init: function(application) {
        this.control({
            "#btnBack": {
                click: this.onBtnBackClick
            },
            "#btnSubmit": {
                click: this.onBtnSubmitClick
            }
        });
    }

});
