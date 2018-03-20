/*
 * File: app/view/RegAUMainPage.js
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

Ext.define('MyApp.view.RegAUMainPage', {
    extend: 'Ext.panel.Panel',

    frame: true,
    id: 'RegAUMainPage',
    itemId: 'RegAUMainPage',
    layout: {
        columns: 1,
        type: 'table'
    },
    title: 'Authorized Update Of Registration',

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'label',
                    text: 'Information available for Updates are:'
                },
                {
                    xtype: 'label',
                    itemId: 'lbl_ind',
                    margin: '',
                    padding: '0 25',
                    text: 'Individual Information'
                },
                {
                    xtype: 'label',
                    itemId: 'lbl_business',
                    margin: '0 25',
                    text: 'Business Information'
                },
                {
                    xtype: 'label',
                    itemId: 'lbl_vat',
                    margin: '0 25',
                    text: 'VAT Information'
                },
                {
                    xtype: 'label',
                    itemId: 'lbl_excise',
                    margin: '0 25',
                    text: 'Excise Information'
                },
                {
                    xtype: 'button',
                    itemId: 'regAuBtnContinue',
                    margin: '0 25',
                    text: 'Continue'
                }
            ]
        });

        me.callParent(arguments);
    }

});