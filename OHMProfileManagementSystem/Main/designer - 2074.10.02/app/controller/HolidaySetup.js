/*
 * File: app/controller/HolidaySetup.js
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

Ext.define('MyApp.controller.HolidaySetup', {
    extend: 'Ext.app.Controller',

    stores: [
        'HolidayStore',
        'FiscalYearShortStore'
    ],

    onFrmHolidaySetupAfterRender: function(component, eOpts) {
        var fiscalYearStore=Ext.getStore('FiscalYearShortStore');
        fiscalYearStore.removeAll();
        Ext.Ajax.request
        ({

            url:'../Handlers/Common/FiscalYearHandler.ashx?method=GetFiscalYearShort',

            success:function(response){

                var obj =Ext.decode(response.responseText);
                var row = obj.root;

                fiscalYearStore.add(row);

            },
            failure:function()
            {
                msg('FAILURE',Ext.decode(response));

            }



        });


    },

    onDdlFiscalYearChange: function(field, newValue, oldValue, eOpts) {


        var fiscalYear=Ext.ComponentQuery.query('#ddlFiscalYear')[0].getValue();
        Ext.Ajax.request
        ({

            url:'../Handlers/Common/FiscalYearHandler.ashx?method=Get',
            params:{fiscalYear:fiscalYear},
            success:function(response){
                var obj =Ext.decode(response.responseText);
                var row = obj.root[0];

                console.log('fy',row);

                Ext.ComponentQuery.query('#txtStartDate')[0].setValue(row.StartDateNep);
                Ext.ComponentQuery.query('#txtStartDateAD')[0].setValue(row.StartDate);
                Ext.ComponentQuery.query('#txtEndDate')[0].setValue(row.EndDateNep);
                Ext.ComponentQuery.query('#txtEndDateAD')[0].setValue(row.EndDate);

            },
            failure:function()
            {
                msg('FAILURE',Ext.decode(response));

            }



        });



    },

    init: function(application) {
        this.control({
            "#frmHolidaySetup": {
                afterrender: this.onFrmHolidaySetupAfterRender
            },
            "#ddlFiscalYear": {
                change: this.onDdlFiscalYearChange
            }
        });
    }

});