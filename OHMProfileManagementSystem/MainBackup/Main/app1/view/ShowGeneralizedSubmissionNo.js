/*
 * File: app/view/ShowGeneralizedSubmissionNo.js
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

Ext.define('MyApp.view.ShowGeneralizedSubmissionNo', {
    extend: 'Ext.panel.Panel',

    frame: true,
    id: '',
    itemId: 'ShowGeneralizedSubmissionNo',
    layout: {
        align: 'stretch',
        type: 'vbox'
    },
    title: 'सब्मिशन नम्बर देखाउने फाराम ',

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'form',
                    flex: 1,
                    frame: true,
                    style: 'text-align:center;\r\nfont-size=14px;',
                    layout: {
                        align: 'stretch',
                        type: 'vbox'
                    },
                    bodyStyle: 'text-align:center;\r\nfont-size=14px;',
                    frameHeader: false,
                    items: [
                        {
                            xtype: 'container',
                            height: 50,
                            margin: '50 0 0 0',
                            maxHeight: 50,
                            style: 'text-align:center;\r\nmargin-left:300px;\r\nfont-size=14px;',
                            layout: {
                                align: 'stretch',
                                type: 'vbox'
                            },
                            items: [
                                {
                                    xtype: 'label',
                                    margins: '',
                                    height: 25,
                                    itemId: '',
                                    margin: '',
                                    maxHeight: 25,
                                    style: 'font-size:20px',
                                    text: 'तपाई सफलतापूर्वक दर्ता हुनुभयो!!! '
                                },
                                {
                                    xtype: 'label',
                                    height: 25,
                                    style: 'font-size:17px;',
                                    text: 'कृपया तपाईको सब्मिशन नं.,  प्रयोगकर्ताको नाम   र  पासवर्ड टिपिराख्नुहोस् । '
                                }
                            ]
                        },
                        {
                            xtype: 'container',
                            height: 25,
                            maxHeight: 25,
                            layout: {
                                align: 'stretch',
                                type: 'hbox'
                            },
                            items: [
                                {
                                    xtype: 'displayfield',
                                    height: 25,
                                    itemId: 'lblSubmissionNo',
                                    margin: '0 0 0 50',
                                    maxHeight: 25,
                                    style: 'font-size:20px',
                                    fieldLabel: ' तपाईको सब्मिशन नं.',
                                    labelStyle: 'font-size:14px',
                                    labelWidth: 150,
                                    fieldStyle: 'font-weight:bold'
                                },
                                {
                                    xtype: 'displayfield',
                                    height: 25,
                                    itemId: 'lblUsername',
                                    margin: '0 0 0 100',
                                    fieldLabel: 'प्रयोगकर्ताको नाम   ',
                                    labelStyle: 'font-size:14px',
                                    fieldStyle: 'font-weight:bold'
                                },
                                {
                                    xtype: 'displayfield',
                                    height: 25,
                                    itemId: 'lblPan',
                                    margin: '0 0 0 70',
                                    fieldLabel: 'स्था . ले . नं . ',
                                    labelStyle: 'font-size:14px',
                                    fieldStyle: 'font-weight:bold'
                                }
                            ]
                        },
                        {
                            xtype: 'container',
                            flex: 0.5,
                            margin: '5 0 0 5',
                            style: 'text-align:center;\r\nmargin-left:300px;\r\nfont-size=14px;',
                            layout: {
                                padding: '5 5 ',
                                type: 'hbox'
                            },
                            items: [
                                {
                                    xtype: 'button',
                                    hidden: true,
                                    itemId: 'btnGetNewSubmissionNo',
                                    style: 'margin-left:400px;',
                                    text: 'Get New Submission No'
                                },
                                {
                                    xtype: 'button',
                                    itemId: 'btnEVatReturnsEntry',
                                    margin: '0 0 0 0',
                                    iconAlign: 'right',
                                    text: 'Proceed >'
                                }
                            ]
                        },
                        {
                            xtype: 'hiddenfield',
                            flex: 1,
                            itemId: 'hdnFysicalyr',
                            fieldLabel: 'Label'
                        },
                        {
                            xtype: 'hiddenfield',
                            flex: 1,
                            itemId: 'hdnAcctType',
                            fieldLabel: 'Label'
                        },
                        {
                            xtype: 'hiddenfield',
                            flex: 1,
                            itemId: 'hdnsubmittedFor',
                            fieldLabel: 'Label'
                        },
                        {
                            xtype: 'hiddenfield',
                            flex: 1,
                            itemId: 'hdnLeaf',
                            fieldLabel: 'Label'
                        }
                    ]
                }
            ]
        });

        me.callParent(arguments);
    }

});