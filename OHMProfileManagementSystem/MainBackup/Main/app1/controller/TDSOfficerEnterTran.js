/*
 * File: app/controller/TDSOfficerEnterTran.js
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

Ext.define('MyApp.controller.TDSOfficerEnterTran', {
    extend: 'Ext.app.Controller',

    views: [
        'TDSOfficerEnterTran'
    ],

    onBtnOETTDSCheckClick: function(button, e, eOpts) {
        var me = this;

        var tranNo = Ext.ComponentQuery.query("#txtTDSOffEnterTran")[0];

        var form = Ext.ComponentQuery.query("#frmTDSOffEnterTran")[0].getForm();

        if(!form.isValid())
        {
            msg("WARNING","Enter Transaction Number!");
            return false;
        }

        var waitSave = watiMsg('Loading...');

        Ext.Ajax.request({
            url:"../Handlers/TDS/GetTransactionHandler.ashx?method=CheckTran",

            params: {
                TranNo:tranNo.getValue()
            },
            success: function( result, request){
                //var uiConfig = {menuLink:'TDSUserLogin',pageTitle:'Login'};
                //DynamicUI(uiConfig,function(){

                //Ext.ComponentQuery.query('#hdnSubmissionNo')[0].setValue(objTempSubmissionNo);
                //});

                var obj = Ext.decode(result.responseText);
                var data = obj.root;

                waitSave.hide();

                //var tran = data.TranNo;
                var whPan = data.WhPan;
                var whName = data.WhName;
                var fromDate = data.FromDate;
                var toDate = data.ToDate;
                var dateType = data.DateType;

                var cntOETTDS = Ext.ComponentQuery.query("#cntOETTDS")[0];

                if(obj.success === "true")
                {
                    if(data.Status==="V")
                    {
                        msg("WARNING","Transaction already verified,you can only print it!");
                        cntOETTDS.setVisible(true);
                    }
                    else
                    {
                        if(data.IrdCode===0)
                        {
                            msg("FAILURE","You are not permitted to perform the operation !");
                        }
                        else
                        {
                            me.getController('MyApp.controller.TDSOffVoucherInformation').init();
                            me.getController('MyApp.controller.TDSOffVoucherInformation').ShowVoucherInfo(data.TranNo,whPan,whName,fromDate,toDate,dateType,data.VoucherDate,data.Username,data.Password,data.SubmittedDate,data.EmailID,data.PhoneNo,data.WhAddress,data.TsoCode,data.IrdCode);
                        }
                    }
                }
                else if(obj.success === "false")
                {
                    msg("FAILURE",obj.message);
                    return;
                }

            },
            failure: function ( result, request ){

                waitSave.hide();

                msg("FAILURE","Login Failed !!!");
                return;
            }
        });
    },

    onFrmTDSOffEnterTranAfterRender: function(component, eOpts) {
        var cntOETTDS = Ext.ComponentQuery.query("#cntOETTDS")[0];

        cntOETTDS.setVisible(false);
    },

    ShowOfficerTran: function() {
        var pnlToRender = Ext.getCmp('cntOMTDS');
        var pnlDynamic = Ext.create('MyApp.view.TDSOfficerEnterTran');

        pnlToRender.removeAll();
        pnlToRender.add(pnlDynamic);
    },

    init: function(application) {
        this.control({
            "#btnOETTDSCheck": {
                click: this.onBtnOETTDSCheckClick
            },
            "#frmTDSOffEnterTran": {
                afterrender: this.onFrmTDSOffEnterTranAfterRender
            }
        });
    }

});
