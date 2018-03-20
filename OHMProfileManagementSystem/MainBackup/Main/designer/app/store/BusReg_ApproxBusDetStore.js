/*
 * File: app/store/BusReg_ApproxBusDetStore.js
 *
 * This file was generated by Sencha Architect version 4.2.2.
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

Ext.define('MyApp.store.BusReg_ApproxBusDetStore', {
    extend: 'Ext.data.Store',

    requires: [
        'MyApp.model.BusReg_ApproxBusDet',
        'Ext.data.proxy.Ajax',
        'Ext.data.reader.Json'
    ],

    constructor: function(cfg) {
        var me = this;
        cfg = cfg || {};
        me.callParent([Ext.apply({
            model: 'MyApp.model.BusReg_ApproxBusDet',
            storeId: 'BusReg_ApproxBusDetStore',
            data: [
                {
                    Type: 'कुल कर लाग्ने कारोवार (निकासी समेत)',
                    YearlyBusiness: 0.00,
                    UpComingQuarterlyBusiness: 0.00
                },
                {
                    Type: 'कुल आय कर नलाग्ने कारोवार (निकासी समेत)',
                    YearlyBusiness: 0.00,
                    UpComingQuarterlyBusiness: 0.00
                },
                {
                    Type: 'कुल मु.अ.क. नलाग्ने कारोवार (निकासी समेत)',
                    YearlyBusiness: 0.00,
                    UpComingQuarterlyBusiness: 0.00
                },
                {
                    Type: 'कुल प्राप्त रकम',
                    YearlyBusiness: 0.00,
                    UpComingQuarterlyBusiness: 0.00
                },
                {
                    Type: 'कुल निर्धारणयोग्य आय',
                    YearlyBusiness: 0.00,
                    UpComingQuarterlyBusiness: 0.00
                },
                {
                    Type: 'कुल करयोग्य आय',
                    YearlyBusiness: 0.00,
                    UpComingQuarterlyBusiness: 0.00
                },
                {
                    Type: 'कुल निकासी',
                    YearlyBusiness: 0.00,
                    UpComingQuarterlyBusiness: 0.00
                }
            ],
            proxy: {
                type: 'ajax',
                reader: {
                    type: 'json'
                }
            }
        }, cfg)]);
    }
});