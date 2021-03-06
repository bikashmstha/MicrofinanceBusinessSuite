/*
 * File: app/view/MyForm26.js
 *
 * This file was generated by Sencha Architect version 2.1.0.
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

Ext.define('MyApp.view.MyForm26', {
    extend: 'Ext.form.Panel',

    height: 250,
    width: 400,
    bodyPadding: 10,
    title: 'Sample Report',

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'button',
                    text: 'MyButton',
                    listeners: {
                        click: {
                            fn: me.onButtonClick,
                            scope: me
                        }
                    }
                }
            ]
        });

        me.callParent(arguments);
    },

    onButtonClick: function(button, e, options) {
        var param = { 'uid' : '1234'};
        var url="../../../Reporting/Central/ReportHandlers/TestReportHandler.ashx";
        var winOption="width=730,height=345,left=100,top=100,resizable=yes,scrollbars=yes";
        OpenWindowWithPost(url,winOption,"NewFile", param);
    }

});