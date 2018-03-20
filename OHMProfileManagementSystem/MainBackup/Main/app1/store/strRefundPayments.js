/*
 * File: app/store/strRefundPayments.js
 *
 * This file was generated by Sencha Architect version 2.1.0.
 * http://www.sencha.com/products/architect/
 *
 * This file requires use of the Ext JS 4.0.x library, under independent license.
 * License of Sencha Architect does not include license for Ext JS 4.0.x. For more
 * details see http://www.sencha.com/license or contact license@sencha.com.
 *
 * This file will be auto-generated each and everytime you save your project.
 *
 * Do NOT hand edit this file.
 */

Ext.define('MyApp.store.strRefundPayments', {
    extend: 'Ext.data.Store',

    requires: [
        'MyApp.model.mdlRefundPayments'
    ],

    constructor: function(cfg) {
        var me = this;
        cfg = cfg || {};
        me.callParent([Ext.apply({
            storeId: 'MyJsonStore242',
            model: 'MyApp.model.mdlRefundPayments',
            proxy: {
                type: 'ajax',
                url: '../Handlers/Search/SearchDetailsHandler.ashx?method=GetRefundPaymentForSearchDetails',
                reader: {
                    type: 'json',
                    root: 'root'
                }
            }
        }, cfg)]);
    }
});