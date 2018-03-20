/*
 * File: app/store/AnnexGroup1.js
 *
 * This file was generated by Sencha Architect version 3.0.4.
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

Ext.define('MyApp.store.AnnexGroup1', {
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
            storeId: 'AnnexGroup1',
            data: [
                {
                    AnnexType: 'B',
                    AnnexID: '5',
                    AnnexName: 'अनुसूची - ५',
                    AnnexDesc: 'व्यापार आयको विवरण राख्ने'
                },
                {
                    AnnexType: 'I',
                    AnnexID: '6',
                    AnnexName: 'अनुसूची - ६',
                    AnnexDesc: 'रोजगारी आयको विवरण राख्ने'
                },
                {
                    AnnexType: 'B',
                    AnnexID: '7',
                    AnnexName: 'अनुसूची - ७',
                    AnnexDesc: 'लगानीबाट भएको आयको गणानाको विवरण राख्ने'
                },
                {
                    AnnexType: 'B',
                    AnnexID: '8',
                    AnnexName: 'अनुसूची - ८',
                    AnnexDesc: 'गैर व्यावसायिक सम्पत्तिको निसर्गबाट प्राप्त खुद लाभ'
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