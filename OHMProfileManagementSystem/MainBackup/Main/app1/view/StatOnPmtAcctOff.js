/*
 * File: app/view/StatOnPmtAcctOff.js
 *
 * This file was generated by Sencha Architect version 2.2.2.
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

Ext.define('MyApp.view.StatOnPmtAcctOff', {
    extend: 'Ext.panel.Panel',

    height: 250,
    width: 400,
    title: 'My Panel',

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'form',
                    id: 'frmStatOnPmtAcctOff',
                    itemId: 'frmStatOnPmtAcctOff',
                    bodyPadding: 10,
                    title: '',
                    items: [
                        {
                            xtype: 'container',
                            items: [
                                {
                                    xtype: 'textfield',
                                    itemId: 'txtStartDate',
                                    fieldLabel: 'Start Date'
                                },
                                {
                                    xtype: 'textfield',
                                    itemId: 'txtEndDate',
                                    fieldLabel: 'End Date'
                                },
                                {
                                    xtype: 'button',
                                    margin: '0 0 0 159',
                                    text: 'Generate Report',
                                    listeners: {
                                        click: {
                                            fn: me.onButtonClick,
                                            scope: me
                                        }
                                    }
                                }
                            ]
                        }
                    ]
                }
            ]
        });

        me.callParent(arguments);
    },

    onButtonClick: function(button, e, eOpts) {
        var startDate=Ext.ComponentQuery.query('#txtStartDate')[0].getValue();
        var endDate=Ext.ComponentQuery.query('#txtEndDate')[0].getValue();





        var obj={P_ST_DATE:startDate,            
            P_END_DATE:endDate   

        };
        var url="../Reporting/Vat/ReportHandlers/VAT_LIST_REPORT/statOnPmMonthlyCollHandler.ashx";
        var winOption="width=730,height=345,left=100,top=100,resizable=yes,scrollbars=yes";
        OpenWindowWithPost(url,winOption,"NewFile",obj);
    }

});