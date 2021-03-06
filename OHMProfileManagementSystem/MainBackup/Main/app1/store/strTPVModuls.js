/*
 * File: app/store/strTPVModuls.js
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

Ext.define('MyApp.store.strTPVModuls', {
    extend: 'Ext.data.Store',

    requires: [
        'MyApp.model.mdlTPVModuls'
    ],

    constructor: function(cfg) {
        var me = this;
        cfg = cfg || {};
        me.callParent([Ext.apply({
            autoLoad: true,
            model: 'MyApp.model.mdlTPVModuls',
            storeId: 'strTPVModuls',
            data: [
                {
                    ModulID: 'VatReturns',
                    ModulName: 'E-Vat Return Entry'
                },
                {
                    ModulID: 'EstimateReturn',
                    ModulName: 'E-Installment Return'
                },
                {
                    ModulID: 'SelfAssessmentD01',
                    ModulName: 'E-Self Assessment D01'
                },
                {
                    ModulID: 'SelfAssessmentD03',
                    ModulName: 'E-Self Assessment D03'
                }
            ],
            proxy: {
                type: 'ajax',
                reader: {
                    type: 'array',
                    root: 'data'
                }
            }
        }, cfg)]);
    }
});