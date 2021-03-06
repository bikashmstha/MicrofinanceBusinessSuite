/*
 * File: app/controller/VatReason.js
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

Ext.define('MyApp.controller.VatReason', {
    extend: 'Ext.app.Controller',

    stores: [
        'MaReason'
    ],

    onGridListItemClick: function(dataview, record, item, index, e, eOpts) {
        var txtCode = Ext.ComponentQuery.query('#txtCode')[0];
        var txtDescEng = Ext.ComponentQuery.query('#txtDescEng')[0];
        var txtDescNep = Ext.ComponentQuery.query('#txtDescNep')[0];

        var btnRnSubmit = Ext.ComponentQuery.query('#btnRnSubmit')[0];

        txtCode.setValue(record.data.ReasonCode);
        txtDescEng.setValue(record.data.ReasonDescEng);
        txtDescNep.setValue(record.data.ReasonDescNep);

        btnRnSubmit.setText('Edit');

        txtCode.setReadOnly(true);

    },

    onBtnRnCancelClick: function(button, e, eOpts) {
        var me = this;

        me.clear("Reset");


    },

    onBtnRnSubmitClick: function(button, e, eOpts) {
        var me = this;

        var store = Ext.getStore('MaReason');

        var txtCode = Ext.ComponentQuery.query('#txtCode')[0];
        var txtDescEng = Ext.ComponentQuery.query('#txtDescEng')[0];
        var txtDescNep = Ext.ComponentQuery.query('#txtDescNep')[0];

        var grid = Ext.ComponentQuery.query('#gridList')[0];
        var selected = grid.getSelectionModel().getSelection()[0];

        var postData = "";
        var message ="";
        var errMsg ="";
        var waitSave ="";
        var Url ='../Handlers/VAT/ManagementAssessment/VatReasonHandler.ashx?method=' ;

        var form = button.up('form').getForm();

        if(!form.isValid())
        {

            msg("WARNING","Please Fill the required fields !!!");

            return;
        }

        if(store.getCount() > 0)
        {
            store.clearFilter();

            store.filter(function(item){
                return item.get("Action")!= 'D';
            }); 
        }

        if(selected!== undefined)
        {

            //------------------------------------------------------
            // NB: For Edit Case
            //------------------------------------------------------


            postData={
                ReasonCode:txtCode.getValue(),
                ReasonDescEng:txtDescEng.getValue(),
                ReasonDescNep:txtDescNep.getValue()
            };


            Url += 'Edit';
            message = "Successfully Updated.";
            errMsg = "Error in Update !!!";

            waitSave = Ext.MessageBox.wait('Updating ...');

        }
        else
        {

            //------------------------------------------------------
            // NB: For Save Case
            //------------------------------------------------------

            postData={
                ReasonCode:txtCode.getValue(),
                ReasonDescEng:txtDescEng.getValue(),
                ReasonDescNep:txtDescNep.getValue()

            };


            Url += 'Save';
            message = "Sucessfully Saved.";
            errMsg = "Error in Save !!!";

            waitSave = Ext.MessageBox.wait('Saving ...');

        }


        Ext.Ajax.request({
            url:Url,
            params: {reason:JSON.stringify(postData)},
            success: function ( result, request ) {

                // var obj = Ext.decode(result.responseText);        

                // msg(obj.success === "true" ?"SUCCESS":"FAILURE",obj.success === "true" ?message:obj.message);
                // if(obj.success === "false"){ return;}

                msg("Success",message);

                store.load();
                me.clear("Reset");

            },
            failure: function ( result, request ) {

                waitSave.hide();

                msg("FAILURE",errMsg);
            }

        });

    },

    clear: function(args) {
        if(args=="Reset")
        {
            var txtCode = Ext.ComponentQuery.query('#txtCode')[0];
            var txtDescEng = Ext.ComponentQuery.query('#txtDescEng')[0];
            var txtDescNep = Ext.ComponentQuery.query('#txtDescNep')[0];

            txtCode.setValue("");
            txtDescEng.setValue("");
            txtDescNep.setValue("");

            txtCode.setReadOnly(false);
            txtDescEng.setReadOnly(false);
            txtDescNep.setReadOnly(false);

            btnRnSubmit.setText("Submit");

            txtCode.clearInvalid();
            txtDescEng.clearInvalid();
            txtDescNep.clearInvalid();

            var grid = Ext.ComponentQuery.query('#gridList')[0];
            //var selected = grid.getSelectionModel().getSelection()[0];
            grid.getSelectionModel().deselectAll();

        }
    },

    msg: function(args) {
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
            "#gridList": {
                itemclick: this.onGridListItemClick
            },
            "#btnRnCancel": {
                click: this.onBtnRnCancelClick
            },
            "#btnRnSubmit": {
                click: this.onBtnRnSubmitClick
            }
        });
    }

});
