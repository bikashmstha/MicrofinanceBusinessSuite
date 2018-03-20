/*
 * File: app/store/AnnexGroup0.js
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

Ext.define('MyApp.store.AnnexGroup0', {
    extend: 'Ext.data.Store',

    requires: [
        'MyApp.model.AnnexGroup',
        'Ext.data.proxy.Ajax',
        'Ext.data.reader.Array'
    ],

    constructor: function(cfg) {
        var me = this;
        cfg = cfg || {};
        me.callParent([Ext.apply({
            model: 'MyApp.model.AnnexGroup',
            storeId: 'MyArrayStore7',
            data: [
                {
                    AnnexType: 'I',
                    AnnexID: '1',
                    AnnexName: 'अनुसूची - १',
                    AnnexDesc: 'ब्यक्तिगत आयको विवरण राख्ने',
                    AnnexDescEn: 'Record Individual Income',
                    
                },
                {
                    AnnexType: 'B',
                    AnnexID: '2',
                    AnnexName: 'अनुसूची - २',
                    AnnexDesc: 'करको गणना (निकायको लागि)विवरण राख्ने',
                    AnnexDescEn: 'Record Business Income',
                    
                }
            ],
            proxy: {
                type: 'ajax',
                reader: {
                    type: 'array'
                }
            }
        }, cfg)]);
    }
});