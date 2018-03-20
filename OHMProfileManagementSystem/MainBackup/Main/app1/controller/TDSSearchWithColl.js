/*
 * File: app/controller/TDSSearchWithColl.js
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

Ext.define('MyApp.controller.TDSSearchWithColl', {
    extend: 'Ext.app.Controller',

    models: [
        'TDSDateType',
        'IROName'
    ],
    stores: [
        'TDSDateType',
        'IROName'
    ],
    views: [
        'TDSSearchWithColl'
    ],

    onBtnSWCTDSSearchClick: function(button, e, eOpts) {
        var me = this;

        var form = Ext.ComponentQuery.query("#frmSWCTDSform")[0].getForm();                     
        var iro = Ext.ComponentQuery.query("#cboSWCTDSIro")[0];
        var pan = Ext.ComponentQuery.query("#txtSWCTDSWithPan")[0];
        var fromDate = Ext.ComponentQuery.query("#txtSWCTDSFromDate")[0];
        var toDate = Ext.ComponentQuery.query("#txtSWCTDSToDate")[0];
        //var tso = Ext.ComponentQuery.query("#cboSVRTDSTSO")[0];

        if(!form.isValid())
        {
            msg("WARNING","Please enter required fields!!");
            return false;
        }

        if(pan.getValue()==="")
        {
            msg("WARNING","Please enter required fields!!");
            return false;
        }
        else
        {

            isValid = ValidatePan(pan.getValue());

            if(isValid === false)
            {
                msg('WARNING', 'Please enter valid PAN !!!');
                return false;    
            }
        }

        me.getController('MyApp.controller.TDSWithholderCollRec').init();
        me.getController('MyApp.controller.TDSWithholderCollRec').ShowWithholderCollRec(pan.getValue(),iro.getValue(),fromDate.getValue(),toDate.getValue());
    },

    onRdSWCTDSSelDateChange: function(field, newValue, oldValue, eOpts) {
        var rdRec = Ext.ComponentQuery.query("#rdSWCTDSAllRec")[0];

        var fromDate = Ext.ComponentQuery.query("#txtSWCTDSFromDate")[0];
        var toDate = Ext.ComponentQuery.query("#txtSWCTDSToDate")[0];

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

    onRdSWCTDSAllRecChange: function(field, newValue, oldValue, eOpts) {
        var rdSel = Ext.ComponentQuery.query("#rdSWCTDSSelDate")[0];

        if(field.getValue()===true)
        {
            rdSel.setValue(false);
        }
    },

    onBtnSWCTDSResetClick: function(button, e, eOpts) {
        var me = this;

        me.Clear();
    },

    ShowSearchWithColl: function() {
        Ext.getCmp('cntOMTDS').removeAll();

        var pnlDynamic = Ext.create('MyApp.view.TDSSearchWithColl');

        var pnlToRender = Ext.ComponentQuery.query("#cntOMTDS")[0];

        pnlToRender.add(pnlDynamic);
    },

    Clear: function() {
        var cboSWCTDSIro = Ext.ComponentQuery.query("#cboSWCTDSIro")[0];
        var txtSWCTDSWithPan = Ext.ComponentQuery.query("#txtSWCTDSWithPan")[0];
        var cboSWCTDSDateType = Ext.ComponentQuery.query("#cboSWCTDSDateType")[0];
        var txtSWCTDSFromDate = Ext.ComponentQuery.query("#txtSWCTDSFromDate")[0];
        var txtSWCTDSToDate = Ext.ComponentQuery.query("#txtSWCTDSToDate")[0];
        var rdSWCTDSSelDate = Ext.ComponentQuery.query("#rdSWCTDSSelDate")[0];
        var rdSWCTDSAllRec = Ext.ComponentQuery.query("#rdSWCTDSAllRec")[0];

        cboSWCTDSIro.setValue('');
        txtSWCTDSWithPan.setValue('');
        cboSWCTDSDateType.setValue('');
        txtSWCTDSFromDate.setValue('');
        txtSWCTDSToDate.setValue('');

        txtSWCTDSFromDate.clearInvalid();
        txtSWCTDSToDate.clearInvalid();

        rdSWCTDSSelDate.setValue(true);
        rdSWCTDSAllRec.setValue(false);
    },

    init: function(application) {
        this.control({
            "#btnSWCTDSSearch": {
                click: this.onBtnSWCTDSSearchClick
            },
            "#rdSWCTDSSelDate": {
                change: this.onRdSWCTDSSelDateChange
            },
            "#rdSWCTDSAllRec": {
                change: this.onRdSWCTDSAllRecChange
            },
            "#btnSWCTDSReset": {
                click: this.onBtnSWCTDSResetClick
            }
        });
    }

});