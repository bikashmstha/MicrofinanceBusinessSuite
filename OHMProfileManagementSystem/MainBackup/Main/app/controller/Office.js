/*
 * File: app/controller/Office.js
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

Ext.define('MyApp.controller.Office', {
    extend: 'Ext.app.Controller',

    models: [
        'Office'
    ],
    stores: [
        'Office'
    ],
    views: [
        'Office'
    ],

    onGrdOfficeItemClick: function(dataview, record, item, index, e, eOpts) {
        console.log("record", record.data);

        Ext.ComponentQuery.query('#txtOfficeCode')[0].setValue(record.data.OfficeCode);
        //Ext.ComponentQuery.query('#txtOfficeNameNp')[0].setValue(record.data.OfficeNameNepali);

        Ext.ComponentQuery.query('#txtOfficeNameEn')[0].setValue(record.data.OfficeNameEnglish);


    },

    onOfficeAfterRender: function(component, eOpts) {
        strOffice = Ext.getStore("Office");
        strOffice.load();
    },

    init: function(application) {
        this.control({
            "#grdOffice": {
                itemclick: this.onGrdOfficeItemClick
            },
            "#Office": {
                afterrender: this.onOfficeAfterRender
            }
        });
    }

});
