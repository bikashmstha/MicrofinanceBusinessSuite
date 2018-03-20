/*
 * File: app/store/AnxsReasonsPaa.js
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

Ext.define('MyApp.store.AnxsReasonsPaa', {
    extend: 'Ext.data.Store',

    requires: [
        'MyApp.model.AnxsReasonsPaa',
        'Ext.data.proxy.Ajax',
        'Ext.data.reader.Array'
    ],

    constructor: function(cfg) {
        var me = this;
        cfg = cfg || {};
        me.callParent([Ext.apply({
            model: 'MyApp.model.AnxsReasonsPaa',
            storeId: 'MyArrayStore21',
            data: [
                {
                    ID: '1',
                    Name: 'अनुसूची १, आयकर-डे-१०-०२-०३-६४'
                },
                {
                    ID: '2',
                    Name: 'अनुसूची २, आयकर-डे-१०-०२-०३-६४'
                },
                {
                    ID: '5',
                    Name: 'अनुसूची ५, आयकर-डे-१०-०२-०३-६४'
                },
                {
                    ID: '6',
                    Name: 'अनुसूची ६, आयकर-डे-१०-०२-०३-६४'
                },
                {
                    ID: '7',
                    Name: 'अनुसूची ७, आयकर-डे-१०-०२-०३-६४'
                },
                {
                    ID: '8',
                    Name: 'अनुसूची ८, आयकर-डे-१०-०२-०३-६४'
                },
                {
                    ID: '9',
                    Name: 'संशोधित कर निर्धारण गरेको कारण'
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