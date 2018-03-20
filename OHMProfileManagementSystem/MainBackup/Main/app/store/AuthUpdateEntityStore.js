/*
 * File: app/store/AuthUpdateEntityStore.js
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

Ext.define('MyApp.store.AuthUpdateEntityStore', {
    extend: 'Ext.data.Store',

    requires: [
        'MyApp.model.AuthUpdateEntity',
        'Ext.data.proxy.Ajax',
        'Ext.data.reader.Array'
    ],

    constructor: function(cfg) {
        var me = this;
        cfg = cfg || {};
        me.callParent([Ext.apply({
            model: 'MyApp.model.AuthUpdateEntity',
            storeId: 'MyArrayStore5',
            data: [
                {
                    EntityID: 'VRETURN',
                    EntityDesc: 'Vat Return'
                },
                {
                    EntityID: 'VMRETURN',
                    EntityDesc: 'Manual Vat Return'
                },
                {
                    EntityID: 'SPenalty',
                    EntityDesc: 'Special Penalty'
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