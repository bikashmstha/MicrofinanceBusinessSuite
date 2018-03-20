/*
 * File: app/controller/TDSSearchVerifiedRec.js
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

Ext.define('MyApp.controller.TDSSearchVerifiedRec', {
    extend: 'Ext.app.Controller',

    models: [
        'TDSDateType',
        'IROName'
    ],
    stores: [
        'IROName',
        'TDSDateType'
    ],
    views: [
        'TDSSearchVerifiedRec'
    ],

    onBtnSVRTDSResetClick: function(button, e, eOpts) {
        var me = this;

        me.Clear();
    },

    onBtnSVRTDSSearchClick: function(button, e, eOpts) {
        var me = this;

        var form = Ext.ComponentQuery.query("#frmSVRTDSform")[0].getForm();   
        console.log("form",form);
        var iro = Ext.ComponentQuery.query("#cboSVRTDSIro")[0];
        //var dtType = Ext.ComponentQuery.query("#cboSVRTDSDateType")[0];
        var fromDate = Ext.ComponentQuery.query("#txtSVRTDSFromDate")[0];
        var toDate = Ext.ComponentQuery.query("#txtSVRTDSToDate")[0];
        //var tso = Ext.ComponentQuery.query("#cboSVRTDSTSO")[0];

        if(!form.isValid())
        {
            msg("WARNING","Please enter required fields!!");
            return false;
        }

        me.getController('MyApp.controller.TDSVerifiedRec').init();
        me.getController('MyApp.controller.TDSVerifiedRec').ShowVerifiedRec(iro.getValue(),fromDate.getValue(),toDate.getValue());
    },

    onRdSVRTDSSelDateChange: function(field, newValue, oldValue, eOpts) {
        var rdRec = Ext.ComponentQuery.query("#rdSVRTDSAllRec")[0];

        var fromDate = Ext.ComponentQuery.query("#txtSVRTDSFromDate")[0];
        var toDate = Ext.ComponentQuery.query("#txtSVRTDSToDate")[0];

        if(field.getValue()===true)
        {
            rdRec.setValue(false);

            fromDate.setDisabled(false);
            toDate.setDisabled(false); 
        }
        else
        {
            fromDate.setDisabled(true);
            toDate.setDisabled(true);
        }
    },

    onRdSVRTDSAllRecChange: function(field, newValue, oldValue, eOpts) {
        var rdSel = Ext.ComponentQuery.query("#rdSVRTDSSelDate")[0];

        /*var fromDate = Ext.ComponentQuery.query("#txtSVRTDSFromDate")[0];
        var toDate = Ext.ComponentQuery.query("#txtSVRTDSToDate")[0];*/

        if(field.getValue()===true)
        {
            rdSel.setValue(false);

        }
    },

    ShowSearchVerifiedRec: function() {
        Ext.getCmp('cntOMTDS').removeAll();

        var pnlDynamic = Ext.create('MyApp.view.TDSSearchVerifiedRec');

        var pnlToRender = Ext.ComponentQuery.query("#cntOMTDS")[0];
        pnlToRender.add(pnlDynamic);
    },

    Clear: function() {
        var cboIro = Ext.ComponentQuery.query("#cboSVRTDSIro")[0];
        var cboDateType = Ext.ComponentQuery.query("#cboSVRTDSDateType")[0];
        var txtFromDate = Ext.ComponentQuery.query("#txtSVRTDSFromDate")[0];
        var txtToDate = Ext.ComponentQuery.query("#txtSVRTDSToDate")[0];

        var rdSelnDate = Ext.ComponentQuery.query("#rdSVRTDSSelDate")[0];
        var rdAllRec = Ext.ComponentQuery.query("#rdSVRTDSAllRec")[0];
        var rdTSORep = Ext.ComponentQuery.query("#rdSVRTDSTSORep")[0];

        cboIro.setValue('');
        cboDateType.setValue('');
        txtFromDate.setValue('');
        txtToDate.setValue('');

        rdSelnDate.setValue(true);
        rdAllRec.setValue(false);
        rdTSORep.setValue(false);
    },

    init: function(application) {
        this.control({
            "#btnSVRTDSReset": {
                click: this.onBtnSVRTDSResetClick
            },
            "#btnSVRTDSSearch": {
                click: this.onBtnSVRTDSSearchClick
            },
            "#rdSVRTDSSelDate": {
                change: this.onRdSVRTDSSelDateChange
            },
            "#rdSVRTDSAllRec": {
                change: this.onRdSVRTDSAllRecChange
            }
        });
    }

});