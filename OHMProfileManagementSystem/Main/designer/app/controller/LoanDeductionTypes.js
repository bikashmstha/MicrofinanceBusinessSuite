/*
 * File: app/controller/LoanDeductionTypes.js
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

Ext.define('MyApp.controller.LoanDeductionTypes', {
    extend: 'Ext.app.Controller',

    stores: [
        'LoanDeductionTypesStore',
        'ProductTypeStore'
    ],

    onDdlSavingProductCodeAfterRender: function(component, eOpts) {

                Ext.Ajax.request({
                    url:'../Handlers/Finance/Transaction/SavingTransaction/SavingProductHandler.ashx',
                    params:{method:'GetSavingProduct',
                           },
                    success: function ( result, request ) {

                        var obj = Ext.decode(result.responseText);
                        if(obj.success === 'true'){
                            console.log("Resu",obj.root);
                            var store =Ext.getStore('ProductTypeStore');
                            store.removeAll();
                            store.add(obj.root);


                        }else{msg('FAILURE','Could Not Load Data');}
                    },
                    failure: function(form, action) {
                        msg("FAILURE","Could Not Load Data");    }
                });
    },

    onDdlSavingProductCodeSelect: function(combo, records, eOpts) {
        var productName = records[0].data.ProductName;



        Ext.ComponentQuery.query('#txtSavingProductDesc')[0].setValue(productName);

    },

    onDdlNonExistSavingProductCodeAfterRender: function(component, eOpts) {

                Ext.Ajax.request({
                    url:'../Handlers/Finance/Transaction/SavingTransaction/SavingProductHandler.ashx',
                    params:{method:'GetSavingProduct',
                           },
                    success: function ( result, request ) {

                        var obj = Ext.decode(result.responseText);
                        if(obj.success === 'true'){
                            console.log("Resu",obj.root);
                            var store =Ext.getStore('ProductTypeStore');
                            store.removeAll();
                            store.add(obj.root);


                        }else{msg('FAILURE','Could Not Load Data');}
                    },
                    failure: function(form, action) {
                        msg("FAILURE","Could Not Load Data");    }
                });
    },

    onDdlNonExistSavingProductCodeSelect: function(combo, records, eOpts) {
        var nonExSavProductName = records[0].data.ProductName;

        Ext.ComponentQuery.query('#txtNonExistSavingProductDesc')[0].setValue(nonExSavProductName);
    },

    onFrmLoanDeductionTypesAfterRender: function(component, eOpts) {
        Ext.Ajax.request({
                    url:'../Handlers/Finance/Maintenance/LoanDeductionTypeHandler.ashx',
                    params:{method:'Get',
                           },
                    success: function ( result, request ) {

                        var obj = Ext.decode(result.responseText);
                        if(obj.success === 'true'){
                            console.log("Resu",obj.root);
                            var store =Ext.getStore('LoanDeductionTypesStore');
                            store.removeAll();
                            store.add(obj.root);
                            //waitSave.hide();

                        }else{msg('FAILURE','Could Not Load Data');}
                    },
                    failure: function(form, action) {
                        msg("FAILURE","Could Not Load Data");    }
                });
    },

    onFrmLoanDeductionTypesAfterRender: function(component, eOpts) {
        var waitSave = watiMsg("Loading data .Please wait ...");
        Ext.Ajax.request({
                    url:'../Handlers/Finance/Maintenance/LoanDeductionTypeHandler.ashx',
                    params:{method:'Get',
                           },
                    success: function ( result, request ) {

                        var obj = Ext.decode(result.responseText);
                        if(obj.success === 'true'){
                            console.log("Resu",obj.root);
                            waitSave.hide();
                            var store =Ext.getStore('LoanDeductionTypesStore');
                            store.removeAll();
                            store.add(obj.root);
                            //waitSave.hide();

                        }else{msg('FAILURE','Could Not Load Data');}
                    },
                    failure: function(form, action) {
                        msg("FAILURE","Could Not Load Data");    }
                });
    },

    onBtnLoanDedAddClick: function(button, e, eOpts) {

        var store=Ext.getStore('LoanDeductionTypesStore');
        var objLoanDed ={
                    DeductionTypeCode:'',
        			DeductionTypeDesc:'',
        			SavingProductCode:'',
        			SavingAccountDeduction:'',
        			NonExistSavingProductCode:'',
        			ActiveFlag:'',
        			Action:"I"
        };

        store.add(objLoanDed);

    },

    init: function(application) {
        this.control({
            "#ddlSavingProductCode": {
                afterrender: this.onDdlSavingProductCodeAfterRender,
                select: this.onDdlSavingProductCodeSelect
            },
            "#ddlNonExistSavingProductCode": {
                afterrender: this.onDdlNonExistSavingProductCodeAfterRender,
                select: this.onDdlNonExistSavingProductCodeSelect
            },
            "#frmLoanDeductionTypes": {
                afterrender: this.onFrmLoanDeductionTypesAfterRender,
                afterrender: this.onFrmLoanDeductionTypesAfterRender
            },
            "#btnLoanDedAdd": {
                click: this.onBtnLoanDedAddClick
            }
        });
    }

});