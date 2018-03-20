/*
 * File: app.js
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

// @require @packageOverrides
Ext.Loader.setConfig({
    enabled: true
});


Ext.application({
    models: [
        'TreePanelModel',
        'Narration',
        'NepaliDateConversion',
        'NepaliFiscalYear',
        'InstallmentPeriod',
        'LoanPeriod',
        'LoanInstallmentPeriodMap',
        'LoanPeriodProductMap',
        'AccountCategory',
        'AccountSubCategory',
        'GLVoucherType',
        'VoucherApprovalSecurity',
        'OfficeShort',
        'SavingMidTermInterest',
        'ABBSTypeCharge',
        'Religion',
        'UserShort',
        'ReferenceShort',
        'PostShort',
        'DesignationShort',
        'DepartmentShort',
        'CountryShort',
        'Role',
        'ModuleShort',
        'FiscalYearShort',
        'Department',
        'DepartmentMap',
        'ReportShortStore',
        'OfficeWiseHoliday',
        'MemberForCheque',
        'SelectMemberAccountForCheque',
        'ChequeGenerateDetail',
        'MyModel',
        'LoanUtilization',
        'CollectionSheetUnentry',
        'VoucherApprovalMaster',
        'VoucherApprovalDetail',
        'BudgetAllocation',
        'BudgetAllocationShare'
    ],
    stores: [
        'TreePanelDataStore',
        'ParentMenuStore',
        'SavingMidTermInterest',
        'ReligionStore',
        'PostShortStore',
        'DesignationShortStore',
        'DepartmentShortStore',
        'CountryShortStore',
        'RoleStore',
        'ModuleShortStore',
        'FiscaYearStore',
        'OfficeWiseHolidayStore',
        'LoanUtilizationStore'
    ],
    views: [
        'MyViewport'
    ],
    controllers: [
        'LoginSecurity',
        'MenuController'
    ],
    name: 'MyApp',

    requires: [
        'MyApp.view.MyViewport'
    ],

    launch: function() {
        Ext.create('MyApp.view.MyViewport');
        var me = this;
        var clear = false;
        var main = me.getController('MyApp.controller.Main');


        var el = Ext.get('logOUt');
        var elLoginTitle = Ext.get('LoginTitle');

        var txtToken = getParameterByName('token');

        if (txtToken.length > 30) {
            var txtModule = getParameterByName('module');
            Ext.Ajax.request({
                url: '../Handlers/Security/SessionHandler.ashx?',
                params: { token: txtToken, module: txtModule, method: 'LoginByToken' },
                success: function (result, request) {
                    var obj = Ext.decode(result.responseText);

                    var el = Ext.get('logOUt');
                    var elLoginTitle = Ext.get('LoginTitle');
                    var elNepDate = Ext.get('nepDate');
                    var elOffCode = Ext.get('offCode');
                    // alert("success: "+obj.success);
                    if (obj.success == "true") {

                        //Sets Office Code
                        elOffCode.dom.innerHTML = obj.root.Obj.OfficeUser.OfficeCode;

                        //Sets Nepali Date
                        GetNepaliDate(function (nepaliDate) {
                            elNepDate.dom.innerHTML = nepaliDate;
                        });


                        el.child('span').dom.innerHTML = "LogOut";
                        me.getController('MyApp.controller.Main').showMainView();

                        var store = Ext.getStore('TreePanelDataStore');
                        if (store)
                        store.setRootNode(obj.root.MenuObj);

                    }
                    else {
                        msg("FAILURE", obj.message);
                    }

                },

                failure: function (form, action) {
                    waitSave.hide();
                    var user = me.getController('MyApp.controller.LoginSecurity');
                    var valid = user.validateSession("default");
                    if (valid) {
                        el.child('span').dom.innerHTML = "LogOut";
                        main.showMainView();


                        if (txtToken.length < 30) {
                            main.LoadUserFromSession();
                        }
                    }
                    switch (action.failureType) {
                        case Ext.form.action.Action.CLIENT_INVALID:
                        msg('Failure', 'Form fields may not be submitted with invalid values');
                        break;
                        case Ext.form.action.Action.CONNECT_FAILURE:
                        msg('Failure', 'Ajax communication failed');
                        break;
                        case Ext.form.action.Action.SERVER_INVALID:
                        msg('Failure', action.result.msg);
                    }
                }

            });
        }
        else {
            var user = me.getController('MyApp.controller.LoginSecurity');
            var valid = user.validateSession("default");
            if (valid) {
                el.child('span').dom.innerHTML = "LogOut";
                main.showMainView();


                if (txtToken.length < 30) {
                    main.LoadUserFromSession();
                }
            }
        }


        el.on('click', function (e, t, eOpts) {

            if (el.child('span').dom.innerHTML !== "LogIn") {
                el.child('span').dom.innerHTML = "LogIn";
                elLoginTitle.dom.innerHTML = "Welcome";
                clear = user.clearSession();
            }
        });

    }

});
