/*
 * File: app/controller/BigTaxpayerDebitReport.js
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

Ext.define('MyApp.controller.BigTaxpayerDebitReport', {
    extend: 'Ext.app.Controller',

    onBtnPrintClick: function(button, e, options) {
        var FromDate=Ext.ComponentQuery.query('#txtFDate')[0].getValue();
        var ToDate=Ext.ComponentQuery.query('#txtTDate')[0].getValue();
        var lowerNumber=Ext.ComponentQuery.query('#txtLBound')[0].getValue();
        var upperNumber=Ext.ComponentQuery.query('#txtUBound')[0].getValue();
        var offCode=Ext.ComponentQuery.query('#txtOffCode')[0].getValue();



        var obj={paramLANG:'N',            
            paramFRECDATE:FromDate,
            paramTRECDATE:ToDate,
            paramOFFCODE:offCode,
            paramLRANG:lowerNumber,
            paramURANG:upperNumber
        };
        var url="../Reporting/Vat/ReportHandlers/BigTaxpayer/BigTaxPayerDebitReportHandler.ashx";
        var winOption="width=730,height=345,left=100,top=100,resizable=yes,scrollbars=yes";
        OpenWindowWithPost(url,winOption,"NewFile",obj);

    },

    init: function(application) {
        this.control({
            "#btnPrint": {
                click: this.onBtnPrintClick
            }
        });
    }

});
