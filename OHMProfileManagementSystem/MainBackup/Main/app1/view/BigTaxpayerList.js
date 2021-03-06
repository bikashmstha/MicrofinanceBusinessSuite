/*
 * File: app/view/BigTaxpayerList.js
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

Ext.define('MyApp.view.BigTaxpayerList', {
    extend: 'Ext.panel.Panel',

    height: 572,
    width: 852,
    title: 'My Panel',

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'form',
                    height: 197,
                    id: 'frmBigTaxpayerList',
                    itemId: 'frmBigTaxpayerList',
                    width: 676,
                    bodyPadding: 10,
                    title: '',
                    items: [
                        {
                            xtype: 'container',
                            items: [
                                {
                                    xtype: 'numberfield',
                                    itemId: 'txtOfficeCode',
                                    fieldLabel: 'Office Code',
                                    decimalPrecision: 0
                                },
                                {
                                    xtype: 'textfield',
                                    itemId: 'txtTaxYear',
                                    fieldLabel: 'Tax Year',
                                    emptyText: 'YYYY',
                                    maskRe: /[0-9]/
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
        var officeCode=Ext.ComponentQuery.query('#txtOfficeCode')[0].getValue();
        var taxYEar=Ext.ComponentQuery.query('#txtTaxYear')[0].getValue();


        var count=0;
        var errorMsg = "";

        if(officeCode === "" || officeCode === null)
        {

            count++;
            errorMsg = errorMsg +'<br/>'+ count + ") कृपया Office Code भर्नुहोस.!!!";

        }

        if(taxYEar === "")
        {

            count++;
            errorMsg = errorMsg +'<br/>'+ count + ")कृपया Tax Year  भर्नुहोस.!!!";

        }


        if(count >0)
        {
            msg("WARNING",errorMsg);
            return false;
        }



        var obj={OFFCODE:officeCode,            
            P_TAXYEAR:taxYEar   

        };
        var url="../Reporting/Vat/ReportHandlers/VAT_LIST_REPORT/ListOfBigTaxpayersHandler.ashx";
        var winOption="width=730,height=345,left=100,top=100,resizable=yes,scrollbars=yes";
        OpenWindowWithPost(url,winOption,"NewFile",obj);
    }

});