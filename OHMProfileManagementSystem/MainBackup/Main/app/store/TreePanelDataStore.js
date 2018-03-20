/*
 * File: app/store/TreePanelDataStore.js
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

Ext.define('MyApp.store.TreePanelDataStore', {
    extend: 'Ext.data.TreeStore',

    requires: [
        'MyApp.model.TreePanelModel',
        'Ext.data.proxy.Ajax',
        'Ext.data.reader.Json',
        'Ext.data.Field'
    ],

    constructor: function(cfg) {
        var me = this;
        cfg = cfg || {};
        me.callParent([Ext.apply({
            autoLoad: true,
            model: 'MyApp.model.TreePanelModel',
            storeId: 'MyJsonTreeStore',
            root: {
                text: 'Integrated Tax Menus',
                id: 'gp_id',
                expanded: true,
                link: 'NULL'
            },
            proxy: {
                type: 'ajax',
                url: 'data/treejson.js',
                reader: {
                    type: 'json'
                }
            },
            fields: [
                {
                    name: 'breadcrumb'
                }
            ]
        }, cfg)]);
    }
});