/*
 * File: app/controller/ComputerAssessment.js
 *
 * This file was generated by Sencha Architect version 2.1.0.
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

Ext.define('MyApp.controller.ComputerAssessment', {
    extend: 'Ext.app.Controller',

    stores: [
        'AccountType',
        'NepaliMonthStore'
    ],

    onCA_btnGenerateClick: function(button, e, options) {

        var Form = Ext.ComponentQuery.query('#frmComputerAssessment')[0].getForm();
        var AccType=Ext.ComponentQuery.query('#CA_cmbAccType')[0];
        var Year=Ext.ComponentQuery.query('#CA_txtYear')[0];
        var Month=Ext.ComponentQuery.query('#CA_cmbMonth')[0];
        var lblMsg=Ext.ComponentQuery.query('#CA_lblMsg')[0];
        var GID=Ext.ComponentQuery.query('#CA_txtGID')[0];


        var caGenerate={
            AccTType:AccType.getValue(),
            Year:Year.getValue(),
            Month:Month.getValue()

        };

        var errMsg="";
        var errCount=0;

        if(AccType.getValue()===null)
        {
            errCount++;
            errMsg +=errCount+") "+"कृपया खाताको किसिम छान्नुहोस् !<br/>";
            AccType.focus();
        }
        if(!Year.getValue())
        {
            errCount++;
            errMsg +=errCount+") "+"कृपया बर्ष हाल्नुहोस्  !<br/>";
            Year.focus();
        }
        if(Month.getValue()===null)
        {
            errCount++;
            errMsg +=errCount+") "+"कृपया महिना छान्नुहोस् !<br/>";
            Month.focus();
        }
        if(errCount>0)
        {
            msg("WARNING",errMsg);    
            return false;
        }

        if(!Form.isValid())
        {
            msg("WARNING","Please enter the required fields");
            return;
        }

        var waitSave=watiMsg("Generating...");

        Ext.Ajax.request({
            url:"../Handlers/VAT/ComputerAssessment/CAGenerateHandler.ashx?method=GenerateComputerAssessment",
            params:{caGenerate:JSON.stringify(caGenerate)},
            success: function ( result, request ){

                waitSave.hide();

                var obj = Ext.decode(result.responseText);
                if(obj.success === "true")
                {
                    if(obj.message==='')
                    {
                        lblMsg.setText('Server is busy. Please generate later on');
                        Ext.get('CA_lblMsg').setStyle('color', 'red');   
                    }
                    else
                    {
                        lblMsg.setText('Computer Assessment is generating. Check it after some times');  
                        GID.setValue(obj.message);
                        Ext.get('CA_lblMsg').setStyle('color', 'black'); 
                    }
                }

                //msg(obj.success === "true"?"SUCCESS":"FAILURE",obj.message);

                if(obj.success === "false") return;

            },

            failure: function ( result, request ){

                waitSave.hide();

                msg("FAILURE","Error in Fetching Data !!!");
                return;
            }


        });

    },

    onCA_btnCheckClick: function(button, e, options) {
        var GID=Ext.ComponentQuery.query('#CA_txtGID')[0];
        var lblMsg=Ext.ComponentQuery.query('#CA_lblMsg')[0];

        if(!GID.getValue())
        {
            msg("WARNING","कृपया GID हाल्नुहोस !");  
            GID.focus();
            return;
        }

        var waitSave=watiMsg("Checking...");

        Ext.Ajax.request({
            url:"../Handlers/VAT/ComputerAssessment/CAGenerateHandler.ashx?method=CheckGComputerAssessment",
            params:{GID:GID.getValue(),jobName:'GEN_CA'},
            success: function ( result, request ){

                waitSave.hide();

                var obj = Ext.decode(result.responseText);
                if(obj.success==="true")
                {
                    if(obj.message.indexOf("successful") !== -1)
                    {
                        Ext.get('CA_lblMsg').setStyle('color', 'green'); 
                    }
                    else if(obj.message.indexOf("generating")!== -1)
                    {
                        Ext.get('CA_lblMsg').setStyle('color', 'black');   
                    }
                    else
                    {
                        Ext.get('CA_lblMsg').setStyle('color', 'red');   
                    }


                    lblMsg.setText(obj.message);

                }

                //   msg(obj.success === "true"?"SUCCESS":"FAILURE",obj.message);

                if(obj.success === "false") return;

            },

            failure: function ( result, request ){

                waitSave.hide();

                msg("FAILURE","Error in Fetching Data !!!");
                return;
            }


        });
    },

    onFrmComputerAssessmentAfterRender: function(abstractcomponent, options) {
        var me=this;
        me.GetLatestJob();
    },

    onCA_btnCancelClick: function(button, e, options) {
        Ext.ComponentQuery.query('#CA_cmbAccType')[0].reset();
        Ext.ComponentQuery.query('#CA_cmbAccType')[0].focus();
        Ext.ComponentQuery.query('#CA_txtYear')[0].reset();
        Ext.ComponentQuery.query('#CA_cmbMonth')[0].reset();

    },

    GetLatestJob: function() {

        var GID=Ext.ComponentQuery.query('#CA_txtGID')[0];
        var lblMsg=Ext.ComponentQuery.query('#CA_lblMsg')[0];

        Ext.Ajax.request({
            url:"../Handlers/Common/JobStatusHandler.ashx?method=GetLatestJobStatus",
            params:{jobName:'GEN_CA'},
            success: function ( result, request ){

                var obj = Ext.decode(result.responseText);
                if(obj.success==="true")
                {
                    var rac=obj.root;

                    if(rac.JobST==='Y')
                    {
                        Ext.get('CA_lblMsg').setStyle('color', 'green'); 
                        lblMsg.setText('Latest computer assessment generated successfully. Your GID is '+rac.RID);
                        GID.setValue(rac.RID);
                        Ext.get('CA_lblMsg').setStyle('color', 'green');   
                    }
                    else if(rac.JobST==='F')
                    {
                        lblMsg.setText('Latest CAG Faild. Error: '+ rac.JobError);
                        Ext.get('CA_lblMsg').setStyle('color', 'red');   
                    }
                    else if(rac.JobST==='P')
                    {
                        lblMsg.setText('Latest Computer assessment is generating. Check it after some times');
                        GID.setValue(rac.RID);
                    }

                }

                if(obj.success === "false") return;

            },

            failure: function ( result, request ){

                waitSave.hide();

                msg("FAILURE","Error in Fetching Data !!!");
                return;
            }


        });

    },

    init: function(application) {
        this.control({
            "#CA_btnGenerate": {
                click: this.onCA_btnGenerateClick
            },
            "#CA_btnCheck": {
                click: this.onCA_btnCheckClick
            },
            "#frmComputerAssessment": {
                afterrender: this.onFrmComputerAssessmentAfterRender
            },
            "#CA_btnCancel": {
                click: this.onCA_btnCancelClick
            }
        });
    }

});
