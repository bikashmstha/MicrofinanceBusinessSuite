/*
 * File: app/controller/DocumentSearch.js
 *
 * This file was generated by Sencha Architect version 2.2.2.
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

Ext.define('MyApp.controller.DocumentSearch', {
    extend: 'Ext.app.Controller',

    stores: [
        'DocSearchStore'
    ],
    views: [
        'DocumentSearch'
    ],

    onRdDSClassifyChange: function(field, newValue, oldValue, eOpts) {
        var rdDSOpen = Ext.ComponentQuery.query("#rdDSOpen")[0];
        //var grdDSDocSearch = Ext.ComponentQuery.query("#grdDSDocSearch")[0];

        if(field.getValue()===true)
        {
            rdDSOpen.setValue(false);
            //grdDSDocSearch.setVisible(true);
        }
    },

    onFrmDSAfterRender: function(component, eOpts) {
        var grdDSDocSearch = Ext.ComponentQuery.query("#grdDSDocSearch")[0];
        grdDSDocSearch.setVisible(false);
    },

    onRdDSOpenChange: function(field, newValue, oldValue, eOpts) {
        var rdDSClassify = Ext.ComponentQuery.query("#rdDSClassify")[0];
        //var grdDSDocSearch = Ext.ComponentQuery.query("#grdDSDocSearch")[0];

        if(field.getValue()===true)
        {
            rdDSClassify.setValue(false);
            //grdDSDocSearch.setVisible(false);
        }
    },

    onBtnDSSearchClick: function(button, e, eOpts) {
        var grdDSDocSearch = Ext.ComponentQuery.query("#grdDSDocSearch")[0];
        grdDSDocSearch.setVisible(true);

        var cboDSDocOff=Ext.ComponentQuery.query('#cboDSDocOff')[0];
        var txtDSPan=Ext.ComponentQuery.query('#txtDSPan')[0];

        var txtDSFrom=Ext.ComponentQuery.query('#txtDSFrom')[0];
        var txtDSTo=Ext.ComponentQuery.query('#txtDSTo')[0];


        var txtDSDocSub=Ext.ComponentQuery.query('#txtDSDocSub')[0];
        var txtArDSDocKey=Ext.ComponentQuery.query('#txtArDSDocKey')[0];

        var DocSearchStore=Ext.getStore('DocSearchStore');

        DocSearchStore.removeAll();
        DocSearchStore.loadData([],false);









        var errMsg = "";

        if(txtDSPan.getValue() === "" || txtDSPan.getValue() === null)
        {
            errMsg += "Please fill Pan No !!! <br/>";
        }

        if(txtDSDocSub.getValue() === "" || txtDSDocSub.getValue() === null)
        {

            errMsg += "Please fill PDocument Subject !!!";            
        }
        if(txtArDSDocKey.getValue() === "" || txtArDSDocKey.getValue() === null)
        {

            errMsg += "Please fill Document Key !!!";            
        }
        if(cboDSDocOff.getValue() === "" || cboDSDocOff.getValue() === null)
        {

            errMsg += "Please select Office !!!";            
        }
        if(txtDSFrom.getValue() === "" || txtDSFrom.getValue() === null)
        {

            errMsg += "Please fill From-Date !!!";            
        }
        if(txtDSTo.getValue() === "" || txtDSTo.getValue() === null)
        {

            errMsg += "Please fill To-Date !!!";            
        }

        if(errMsg === "")
        {
            msg("WARNING","Please fill atleast one field");
            return;
        }






        if(txtDSFrom.getValue()>txtDSTo.getValue())
        {
            msg("WARNING","From-Date must be less than To-Date !!!");
            txtDSTo.focus(true);
            return;
        }

        /*
        if(cboDSDocOff.getValue()==="" || cboDSDocOff.getValue()===null)
        {
        msg("WARNING","Please select Document-Office !!!");
        cboDSDocOff.focus(true);
        return;
        }
        */












        var search={

            Pan:txtDSPan.getValue(),
            DocSubject:txtDSDocSub.getValue()===""?"":txtDSDocSub.getValue(),
            DocKeyword:txtArDSDocKey.getValue()===""?"":txtArDSDocKey.getValue(),
            Status:'',
            FromDate:txtDSFrom.getValue()===""?"":txtDSFrom.getValue(),
            ToDate:txtDSTo.getValue()===""?"":txtDSTo.getValue(),
            offcode:cboDSDocOff.getValue()===""?0:cboDSDocOff.getValue()
        };


        //var grdDSDocSearch=Ext.ComponentQuery.query('#grdDSDocSearch')[0];



        Ext.Ajax.request
        ({

            url:'../Handlers/DocumentManagement/DocumentSearchHandler.ashx?method=GetDocument',
            params:{objDoc: JSON.stringify(search)
            },


            success:function(response){
                console.log(response.responseText);
                var obj =Ext.decode(response.responseText);
                var row = obj.root;


                console.log("search--->",obj.root.count);
                grdDSDocSearch.store.add(obj.root); 

                if(DocSearchStore.getCount()<1)
                {
                    msg("WARNING","No data found");
                    return;
                }


            },

            failure:function()
            {
                msg('FAILURE',Ext.decode(response));

            }



        });

    },

    onBtnDSCancelClick: function(button, e, eOpts) {
        var txtDSPan = Ext.ComponentQuery.query("#txtDSPan")[0];
        var txtDSDocSub = Ext.ComponentQuery.query("#txtDSDocSub")[0];
        var txtArDSDocKey = Ext.ComponentQuery.query("#txtArDSDocKey")[0];
        var cboDSDocOff = Ext.ComponentQuery.query("#cboDSDocOff")[0];
        var rdDSOpen = Ext.ComponentQuery.query("#rdDSOpen")[0];
        var rdDSClassify = Ext.ComponentQuery.query("#rdDSClassify")[0];
        var txtDSFrom = Ext.ComponentQuery.query("#txtDSFrom")[0];
        var txtDSTo = Ext.ComponentQuery.query("#txtDSTo")[0];
        var grdDSDocSearch = Ext.ComponentQuery.query("#grdDSDocSearch")[0];

        txtDSPan.setValue("");
        txtDSDocSub.setValue("");
        txtArDSDocKey.reset();
        cboDSDocOff.reset();
        rdDSOpen.setValue(true);
        rdDSClassify.setValue(false);
        txtDSFrom.setValue("");
        txtDSTo.setValue("");
        txtDSFrom.clearInvalid();
        txtDSTo.clearInvalid();
        grdDSDocSearch.setVisible(false);
    },

    init: function(application) {
        this.control({
            "#rdDSClassify": {
                change: this.onRdDSClassifyChange
            },
            "#frmDS": {
                afterrender: this.onFrmDSAfterRender
            },
            "#rdDSOpen": {
                change: this.onRdDSOpenChange
            },
            "#btnDSSearch": {
                click: this.onBtnDSSearchClick
            },
            "#btnDSCancel": {
                click: this.onBtnDSCancelClick
            }
        });
    }

});
