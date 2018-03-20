/*
 * File: app/controller/ChangePassword.js
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

Ext.define('MyApp.controller.ChangePassword', {
    extend: 'Ext.app.Controller',

    onTxtNewPasswordCPChange: function(field, newValue, oldValue, eOpts) {
        var cNewPass=Ext.ComponentQuery.query('#txtConfirmNewPasswordCP')[0];
        if(cNewPass.getValue()!=="")
        {
            cNewPass.validate();
        }
    },

    onTxtVerifyNewPasswordCPChange: function(field, newValue, oldValue, eOpts) {
        field.validate();
    },

    onBtnSaveCPClick: function(button, e, eOpts) {
        //var me=this;
        var txtUserName=Ext.ComponentQuery.query('#txtUserNameCP')[0].getValue();
        var txtOldPassword=Ext.ComponentQuery.query('#txtCurrentPasswordCP')[0].getValue();
        var txtNewPassword=Ext.ComponentQuery.query('#txtConfirmNewPasswordCP')[0].getValue();

        var dataCP={'UserID':txtUserName,UserName:txtOldPassword,'Password':txtNewPassword};
        //console.log(dataCP);

        Ext.Ajax.request({
            method: 'POST',
            url: '../Handlers/Security/UserHandler.ashx',
            params: {method:'SaveChangePassword', changePassword : JSON.stringify(dataCP) },
            success: function( result, request ){

                var jsonMsg=Ext.decode(result.responseText);

            if(jsonMsg.success=="True")
            {
                msg("SUCCESS","Password Changed Successfully. You must Re-Login Now",function(){
                MyApp.app.controllers.items[2].clearSession();
                });

            }
            else
            {
                msg("FAILURE",jsonMsg.message);
            }


               // me.msg("Save Status",jsonMsg.message);

            }
        });
    },

    onBtnCancelCPClick: function(button, e, eOpts) {
        Ext.ComponentQuery.query("#txtUserNameCP")[0].reset();
        Ext.ComponentQuery.query("#txtCurrentPasswordCP")[0].reset();
        Ext.ComponentQuery.query("#txtNewPasswordCP")[0].reset();
        Ext.ComponentQuery.query("#txtConfirmNewPasswordCP")[0].reset();
    },

    init: function(application) {
        this.control({
            "#txtNewPasswordCP": {
                change: this.onTxtNewPasswordCPChange
            },
            "#txtConfirmNewPasswordCP": {
                change: this.onTxtVerifyNewPasswordCPChange
            },
            "#btnSaveCP": {
                click: this.onBtnSaveCPClick
            },
            "#btnCancelCP": {
                click: this.onBtnCancelCPClick
            }
        });
    }

});
