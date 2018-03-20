/*
 * File: app/controller/CenterEntry.js
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

Ext.define('MyApp.controller.CenterEntry', {
    extend: 'Ext.app.Controller',

    stores: [
        'SearchCenterStore'
    ],

    onBtnCreateCenterClick: function(button, e, eOpts) {


        var objCen ={
                      //  FiscalYear : Ext.get('fiscalYear').dom.innerHTML,
                        CenterCode :  Ext.ComponentQuery.query('#txtCenterCode')[0].getValue(),
                        CenterName :  Ext.ComponentQuery.query('#txtCenterName')[0].getValue(),
                        VdcnpCode :  Ext.ComponentQuery.query('#txtVdcCode')[0].getValue(),
                        //EmployeeId :  Ext.ComponentQuery.query('#')[0].getValue(),
                        CollectionDay :  Ext.ComponentQuery.query('#ddlCollectionDay')[0].getValue(),
                        InstallmentInterval :  Ext.ComponentQuery.query('#txtInstallmentInterval')[0].getValue(),
                        //ComputerUserId :  Ext.ComponentQuery.query('#')[0].getValue(),
                        CenterHouseBuiltDate : Ext.ComponentQuery.query('#txtCollectionDateBS')[0].getValue(),
                        FirstCollectionDate :  Ext.ComponentQuery.query('#txtCollectionDateAD')[0].getValue(),
                        MandatoryCollectionAmount :  Ext.ComponentQuery.query('#txtMandatorySavingAmt')[0].getValue(),
                        CenterChief :  Ext.ComponentQuery.query('#txtCenterChief')[0].getValue(),
                        ChiefDate :  Ext.ComponentQuery.query('#txtChiefDateAD')[0].getValue(),
                        CenterCollectionTime :  Ext.ComponentQuery.query('#txtCenterMeetingTime')[0].getValue(),
                        ActiveFlags :  Ext.ComponentQuery.query('#chkActive')[0].getValue(),
                        TranOfficeCode :  Ext.get('offCode').dom.innerHTML,
                        //CreatedOn :  Ext.ComponentQuery.query('#')[0].getValue(),
                        //CreatedBy :  Ext.ComponentQuery.query('#')[0].getValue(),
                        //ModifiedOn :  Ext.ComponentQuery.query('#')[0].getValue(),
                        //ModifiedBy :  Ext.ComponentQuery.query('#')[0].getValue(),
                        //LastChangedDate :  Ext.ComponentQuery.query('#')[0].getValue(),
                        //TransferDate : Ext.ComponentQuery.query('#')[0].getValue(),
                        AdjustAccountHead :  Ext.ComponentQuery.query('#txtAdjustmentAccountHeadCode')[0].getValue(),
                        DayDate :  Ext.ComponentQuery.query('#ddlCenterType')[0].getValue(),
                        CenterMeetingStartDate : Ext.ComponentQuery.query('#txtCenterMeetingTime')[0].getValue(),
                        UnitFundCollectionAmt : Ext.ComponentQuery.query('#txtCenterFundAmt')[0].getValue(),
                        CenterCategory :  Ext.ComponentQuery.query('#ddlCenterCategory')[0].getValue(),
                        ThirdPartyData :  Ext.ComponentQuery.query('#')[0].getValue(),
                        //PenaltyOnLateCome : Ext.ComponentQuery.query('#')[0].getValue(),
                        CenterClosedDate : Ext.ComponentQuery.query('#txtCenterClosedDateAD')[0].getValue(),
                        CenterAddress :  Ext.ComponentQuery.query('#txtAddress')[0].getValue(),
                        PhoneNo :  Ext.ComponentQuery.query('#txtPhoneNo')[0].getValue(),
        				Action: 'I'
        };


        var waitSave = watiMsg('Saving Center.Please wait ...');
        Ext.Ajax.request({
             url:'../Handlers/GeneralMasterParameters/Center/CenterHandler.ashx',
             params:{method:'Save',center:JSON.stringify(objCen)},
             success: function ( result, request ) {
        waitSave.hide();
                  var out = Ext.decode(result.responseText);
        				if(out.success==='true'){
        					msg('SUCCESS',out.message,function(){
        						var grd = Ext.ComponentQuery.query('#grdCenter')[0];
        						var record = grd.getSelectionModel().getSelection()[0];
        						record.set('Action','U');
        						});
        						}

        				else{msg('FAILURE',out.message);


                  }
             },
             failure: function(form, action) {
        waitSave.hide();var out=Ext.decode(response.responseText);msg('FAILURE',out.message);     }
        });
    },

    onBtnSearchCenterClick: function(button, e, eOpts) {


        var objCen={
            BuildDateFrom : Ext.ComponentQuery.query('#txtBuildDateFromBS')[0].getValue(),
            BuildDateTo : Ext.ComponentQuery.query('#txtBuildDateToBS')[0].getValue(),
            CenterCode : Ext.ComponentQuery.query('#txtSearchCenterCode')[0].getValue(),
            //CenterDesc : Ext.ComponentQuery.query('#txtSearchCenterDesc')[0].getValue(),
            TranOfficeCode : Ext.get('offCode').dom.innerHTML

        };

        Ext.Ajax.request({
            url:'../Handlers/GeneralMasterParameters/Center/CenterHandler.ashx',
            params:{method:'Search',center:JSON.stringify(objCen)},
            success: function ( result, request ) {

                var obj = Ext.decode(result.responseText);
                if(obj.success === 'true'){
                    console.log("Resu",obj.root);
                    var store =Ext.getStore('SearchCenterStore');
                    store.removeAll();
                    store.add(obj.root);


                }else{msg('FAILURE','Could Not Load Data');}
            },
            failure: function(form, action) {
                msg("FAILURE","Could Not Load Data");    }
        });
    },

    onBtnUpdateCenterClick: function(button, e, eOpts) {


        var objCen ={
                        //FiscalYear : Ext.get('fiscalYear').dom.innerHTML,
                        CenterCode :  Ext.ComponentQuery.query('#txtCenterCode')[0].getValue(),
                        CenterName :  Ext.ComponentQuery.query('#txtCenterName')[0].getValue(),
                        VdcnpCode :  Ext.ComponentQuery.query('#txtVdcCode')[0].getValue(),
                        //EmployeeId :  Ext.ComponentQuery.query('#')[0].getValue(),
                        CollectionDay :  Ext.ComponentQuery.query('#ddlCollectionDay')[0].getValue(),
                        InstallmentInterval :  Ext.ComponentQuery.query('#txtInstallmentInterval')[0].getValue(),
                        //ComputerUserId :  Ext.ComponentQuery.query('#')[0].getValue(),
                        CenterHouseBuiltDate : Ext.ComponentQuery.query('#txtCollectionDateBS')[0].getValue(),
                        FirstCollectionDate :  Ext.ComponentQuery.query('#txtCollectionDateAD')[0].getValue(),
                        MandatoryCollectionAmount :  Ext.ComponentQuery.query('#txtMandatorySavingAmt')[0].getValue(),
                        CenterChief :  Ext.ComponentQuery.query('#txtCenterChief')[0].getValue(),
                        ChiefDate :  Ext.ComponentQuery.query('#txtChiefDateAD')[0].getValue(),
                        CenterCollectionTime :  Ext.ComponentQuery.query('#txtCenterMeetingTime')[0].getValue(),
                        ActiveFlags :  Ext.ComponentQuery.query('#chkActive')[0].getValue(),
                        TranOfficeCode :  Ext.get('offCode').dom.innerHTML,
                        //CreatedOn :  Ext.ComponentQuery.query('#')[0].getValue(),
                        //CreatedBy :  Ext.ComponentQuery.query('#')[0].getValue(),
                        //ModifiedOn :  Ext.ComponentQuery.query('#')[0].getValue(),
                        //ModifiedBy :  Ext.ComponentQuery.query('#')[0].getValue(),
                        //LastChangedDate :  Ext.ComponentQuery.query('#')[0].getValue(),
                        //TransferDate : Ext.ComponentQuery.query('#')[0].getValue(),
                        AdjustAccountHead :  Ext.ComponentQuery.query('#txtAdjustmentAccountHeadCode')[0].getValue(),
                        DayDate :  Ext.ComponentQuery.query('#ddlCenterType')[0].getValue(),
                        CenterMeetingStartDate : Ext.ComponentQuery.query('#txtCenterMeetingTime')[0].getValue(),
                        UnitFundCollectionAmt : Ext.ComponentQuery.query('#txtCenterFundAmt')[0].getValue(),
                        CenterCategory :  Ext.ComponentQuery.query('#ddlCenterCategory')[0].getValue(),
                        ThirdPartyData :  Ext.ComponentQuery.query('#')[0].getValue(),
                        //PenaltyOnLateCome : Ext.ComponentQuery.query('#')[0].getValue(),
                        CenterClosedDate : Ext.ComponentQuery.query('#txtCenterClosedDateAD')[0].getValue(),
                        CenterAddress :  Ext.ComponentQuery.query('#txtAddress')[0].getValue(),
                        PhoneNo :  Ext.ComponentQuery.query('#txtPhoneNo')[0].getValue(),
        				Action: 'U'
        };


        var waitSave = watiMsg('Saving Center.Please wait ...');
        Ext.Ajax.request({
             url:'../Handlers/GeneralMasterParameters/Center/CenterHandler.ashx',
             params:{method:'Save',center:JSON.stringify(objCen)},
             success: function ( result, request ) {
        waitSave.hide();
                  var out = Ext.decode(result.responseText);
        				if(out.success==='true'){
        					msg('SUCCESS',out.message,function(){
        						var grd = Ext.ComponentQuery.query('#grdCenter')[0];
        						var record = grd.getSelectionModel().getSelection()[0];
        						record.set('Action','U');
        						});
        						}

        				else{msg('FAILURE',out.message);


                  }
             },
             failure: function(form, action) {
        waitSave.hide();var out=Ext.decode(response.responseText);msg('FAILURE',out.message);     }
        });
    },

    onBtnDeleteCenterClick: function(button, e, eOpts) {


        var objCen ={

        				Action: 'D'
        };


        var waitSave = watiMsg('Deleting Center.Please wait ...');
        Ext.Ajax.request({
             url:'../Handlers/GeneralMasterParameters/Center/CenterHandler.ashx',
             params:{method:'Save',center:JSON.stringify(objCen)},
             success: function ( result, request ) {
        waitSave.hide();
                  var out = Ext.decode(result.responseText);
        				if(out.success==='true'){
        					msg('SUCCESS',out.message,function(){
        						var grd = Ext.ComponentQuery.query('#grdCenter')[0];
        						var record = grd.getSelectionModel().getSelection()[0];
        						record.set('Action','U');
        						});
        						}

        				else{msg('FAILURE',out.message);


                  }
             },
             failure: function(form, action) {
        waitSave.hide();var out=Ext.decode(response.responseText);msg('FAILURE',out.message);     }
        });
    },

    init: function(application) {
        this.control({
            "#btnCreateCenter": {
                click: this.onBtnCreateCenterClick
            },
            "#btnSearchCenter": {
                click: this.onBtnSearchCenterClick
            },
            "#btnUpdateCenter": {
                click: this.onBtnUpdateCenterClick
            },
            "#btnDeleteCenter": {
                click: this.onBtnDeleteCenterClick
            }
        });
    }

});
