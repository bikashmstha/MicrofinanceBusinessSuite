/*
 * File: app/store/Annex13.js
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

Ext.define('MyApp.store.Annex13', {
    extend: 'Ext.data.Store',

    requires: [
        'MyApp.model.Annex13'
    ],

    constructor: function(cfg) {
        var me = this;
        cfg = cfg || {};
        me.callParent([Ext.apply({
            model: 'MyApp.model.Annex13',
            storeId: 'Annex13',
            proxy: {
                type: 'ajax',
                url: '../Handlers/IncomeTax/D03/Annex13ItemsHandler.ashx?method=GetAnnex13Items',
                reader: {
                    type: 'json',
                    root: 'root'
                }
            }
        }, cfg)]);
    }
});