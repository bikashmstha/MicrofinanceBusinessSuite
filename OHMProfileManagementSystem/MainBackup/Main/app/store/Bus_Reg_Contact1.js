/*
 * File: app/store/Bus_Reg_Contact1.js
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

Ext.define('MyApp.store.Bus_Reg_Contact1', {
    extend: 'Ext.data.Store',

    requires: [
        'MyApp.model.Bus_Reg_Contact',
        'Ext.data.proxy.Ajax',
        'Ext.data.reader.Json'
    ],

    constructor: function(cfg) {
        var me = this;
        cfg = cfg || {};
        me.callParent([Ext.apply({
            autoLoad: true,
            model: 'MyApp.model.Bus_Reg_Contact',
            storeId: 'Bus_Reg_Contact1',
            data: [
                {
                    Key: 'ईमेल (Email)',
                    Value: ''
                },
                {
                    Key: 'फ्याक्स (Fax)',
                    Value: ''
                },
                {
                    Key: 'फोन (मोबाइल/Mobile)',
                    Value: ''
                },
                {
                    Key: 'फोन (PSTN)',
                    Value: ''
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