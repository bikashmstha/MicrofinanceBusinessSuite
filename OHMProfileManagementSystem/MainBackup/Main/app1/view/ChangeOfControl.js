/*
 * File: app/view/ChangeOfControl.js
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

Ext.define('MyApp.view.ChangeOfControl', {
    extend: 'Ext.panel.Panel',

    frame: true,
    height: 790,
    width: 860,
    layout: {
        align: 'stretch',
        type: 'vbox'
    },
    title: 'Change Of Control',

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'label',
                    margins: '50 0 10 0',
                    style: 'font-size:20px;\r\ntext-align:center;',
                    text: 'विद्युतीय प्रणालीमा आधारित कर विवरण  '
                },
                {
                    xtype: 'label',
                    margins: '0 150 25 150',
                    style: 'font-size:14px;',
                    text: 'यो प्रणालीद्वारा तपाईंले विद्युतीय माध्यमबाट आफ्नो ब्यवसायको आय विवरण भर्न र त्यसलाई प्रमाणित गर्न सक्नु हुन्छ । हामीले यस प्रणालीलाई सरलीकरण गर्न सक्दो प्रयास गरेका छौं । यसमा राखिएको कार्यविधि पढी सामान्य लेख्पढ गर्न जान्ने जोसुकैले पनि कुनै तालिम बिना नै आफ्नो विवरण भर्न सक्नु हुनेछ ।   '
                },
                {
                    xtype: 'label',
                    margins: '10 5',
                    style: 'text-decoration:underline;\r\nfont-size:14px;',
                    text: 'नयाँ प्रयोगकर्ताले ध्यान दिनुपर्ने कुराहरु: '
                },
                {
                    xtype: 'container',
                    itemId: 'cntSubmissionNoCoc',
                    items: [
                        {
                            xtype: 'label',
                            style: 'font-size:14px;',
                            text: '१. विवरण भर्नको लागि '
                        },
                        {
                            xtype: 'label',
                            itemId: 'lblSubmissionNoCoc',
                            style: 'color:red;\r\ntext-decoration:underline;\r\ncursor:pointer;',
                            text: 'Get Submission Number ',
                            listeners: {
                                render: {
                                    fn: me.onLblSubmissionNoCocRender,
                                    scope: me
                                }
                            }
                        },
                        {
                            xtype: 'label',
                            text: 'मा क्लिक गर्नु होस् ।  '
                        }
                    ]
                },
                {
                    xtype: 'container',
                    itemId: 'cntIncomeTaxCoc',
                    items: [
                        {
                            xtype: 'label',
                            style: 'font-size:14px;',
                            text: '२. यदी तपाईंले सब्मिशन नम्बर लिइ सक्नु भएको छ भने  '
                        },
                        {
                            xtype: 'label',
                            itemId: 'lblIncomeTaxCoc',
                            style: 'color:red;\r\ntext-decoration:underline;\r\ncursor:pointer;',
                            text: 'Income Tax Login ',
                            listeners: {
                                render: {
                                    fn: me.onLblIncomeTaxCocRender,
                                    scope: me
                                }
                            }
                        },
                        {
                            xtype: 'label',
                            text: 'मा क्लिक गरी आय विवरण भर्न, प्रविष्टि र रुजु गर्न सक्नु हुन्छ । रुजु नगरेसम्म तपाईंको विवरण आन्तरिक राजस्व विभागमा दर्ता भएको मानिदैन । '
                        }
                    ]
                },
                {
                    xtype: 'container',
                    hidden: true,
                    itemId: 'cntTaxpayerLoginCoc',
                    items: [
                        {
                            xtype: 'label',
                            style: 'font-size:14px;',
                            text: '३. यदी तपाईंसँग प्रयोगकर्ताको नाम र पासवर्ड छ भने '
                        },
                        {
                            xtype: 'label',
                            itemId: 'lblTaxpayerLoginCoc',
                            style: 'color:red;\r\ntext-decoration:underline;\r\ncursor:pointer;',
                            text: 'Taxpayer Login ',
                            listeners: {
                                render: {
                                    fn: me.onLblTaxpayerLoginCocRender,
                                    scope: me
                                }
                            }
                        },
                        {
                            xtype: 'label',
                            text: 'मा क्लिक गरी आय विवरण भर्न, प्रविष्टि र रुजु गर्न सक्नु हुन्छ । '
                        }
                    ]
                }
            ]
        });

        me.callParent(arguments);
    },

    onLblSubmissionNoCocRender: function(abstractcomponent, options) {
        var c = abstractcomponent;

        c.getEl().on('click', function(){ this.fireEvent('click', c); }, c);
    },

    onLblIncomeTaxCocRender: function(abstractcomponent, options) {
        var c = abstractcomponent;

        c.getEl().on('click', function(){ this.fireEvent('click', c); }, c);
    },

    onLblTaxpayerLoginCocRender: function(abstractcomponent, options) {
        var c = abstractcomponent;

        c.getEl().on('click', function(){ this.fireEvent('click', c); }, c);
    }

});