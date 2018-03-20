/*
 * File: app/store/strBusPerTypes.js
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

Ext.define('MyApp.store.strBusPerTypes', {
    extend: 'Ext.data.Store',

    requires: [
        'MyApp.model.mdlBusPerTypes'
    ],

    constructor: function(cfg) {
        var me = this;
        cfg = cfg || {};
        me.callParent([Ext.apply({
            autoLoad: true,
            model: 'MyApp.model.mdlBusPerTypes',
            storeId: 'strBusPerTypes',
            proxy: {
                type: 'ajax',
                url: '../Handlers/Common/BusPersonnelTypesHandler.ashx?method=LoadBusPersonnelTypes',
                reader: {
                    type: 'json',
                    root: 'root'
                }
            }
        }, cfg)]);
    }
});