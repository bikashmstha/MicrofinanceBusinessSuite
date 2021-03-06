/*
 * File: app/store/DeRegistrationDDL.js
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

Ext.define('MyApp.store.DeRegistrationDDL', {
    extend: 'Ext.data.Store',

    requires: [
        'MyApp.model.DeRegistrationDDL',
        'Ext.data.proxy.Ajax',
        'Ext.data.reader.Json'
    ],

    constructor: function(cfg) {
        var me = this;
        cfg = cfg || {};
        me.callParent([Ext.apply({
            autoLoad: true,
            model: 'MyApp.model.DeRegistrationDDL',
            storeId: 'DeRegistrationDDL',
            proxy: {
                type: 'ajax',
                url: 'data/DeregFrom.json',
                reader: {
                    type: 'json',
                    root: 'dereg'
                }
            }
        }, cfg)]);
    }
});