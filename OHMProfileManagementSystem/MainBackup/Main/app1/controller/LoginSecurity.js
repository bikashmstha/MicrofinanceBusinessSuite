/*
 * File: app/controller/LoginSecurity.js
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

Ext.define('MyApp.controller.LoginSecurity', {
    extend: 'Ext.app.Controller',

    stores: [
        'LoginUser'
    ],

    refs: [
        {
            ref: 'userName',
            selector: '#txtUserNameSec',
            xtype: 'textfield'
        },
        {
            ref: 'password',
            selector: '#txtPasswordSec',
            xtype: 'textfield'
        }
    ],

    onBtnLoginSecClick: function(button, e, eOpts) {
        var me = this;

                var form = button.up('form').getForm();

                if(!form.isValid())
                {
                    return;
                }

                me.newLogin();
    },

    onBtnCancelSecClick: function(button, e, eOpts) {
        var txtUserName = Ext.ComponentQuery.query('#txtUserNameSec')[0];
                var txtPassword = Ext.ComponentQuery.query('#txtPasswordSec')[0];

                txtUserName.setValue("");
                txtPassword.setValue("");

                txtUserName.clearInvalid();
                txtPassword.clearInvalid();
    },

    onTxtPasswordSecKeypress: function(textfield, e, eOpts) {
        var me = this;

                if(e.keyCode === 13)
                {
                    var form = textfield.up('form').getForm();

                    if(!form.isValid())
                    {
                        return;
                    }

                    me.newLogin();
                }
    },

    init: function(application) {


                var me = this;
                var user;
                /*
                var store = Ext.getStore('LoginUser');
                store.load();

                user = store.first();

                /
                if(!user){
                store.add({loggedIn: false});
                user = store.first();
                store.sync();
                }

                */

        this.control({
            "#btnLoginSec": {
                click: this.onBtnLoginSecClick
            },
            "#btnCancelSec": {
                click: this.onBtnCancelSecClick
            },
            "#txtPasswordSec": {
                keypress: this.onTxtPasswordSecKeypress
            }
        });
    },

    clearSession: function() {
        var me = this;
                var valid = null;

                var waitSave = watiMsg("LogOut processing ...");

                Ext.Ajax.request({
                    url: '../Handlers/Security/SessionHandler.ashx?method=ClearSession',
                    async : false,
                    success: function ( result, request ) {

                        waitSave.hide();

                        var obj = Ext.decode(result.responseText);

                        var el = Ext.get('logOUt');
                        var elLoginTitle = Ext.get('LoginTitle');


                        if(obj.success === "true")
                        {

                            el.child('span').dom.innerHTML = "LogIn";
                            elLoginTitle.dom.innerHTML = "Welcome";
                            me.getController('MyApp.controller.Main').showLoginView();

                            valid =  true;

                        }
                        else
                        {
                            valid =  false;
                        }

                    },
                    failure: function(form, action) {
                        waitSave.hide();

                        switch (action.failureType)
                        {
                            case Ext.form.action.Action.CLIENT_INVALID:
                            msg('Failure', 'Form fields may not be submitted with invalid values');
                            break;
                            case Ext.form.action.Action.CONNECT_FAILURE:
                            msg('Failure', 'Ajax communication failed');
                            break;
                            case Ext.form.action.Action.SERVER_INVALID:
                            msg('Failure', action.result.msg);
                        }

                        valid =  false;
                    }

                });

                /*
                if(valid !== null)
                {
                return valid;
                }


                */

                /*
                user.destroy();

                var store = this.getUserStore();
                store.sync();
                */

                //return true;
    },

    getUser: function() {
         return user;
    },

    validateSession: function(arg) {
        var me = this;
                var valid = null;

                var waitSave = watiMsg("Please wait ...");

                Ext.Ajax.request({
                    url: '../Handlers/Security/SessionHandler.ashx?method=ValidateSession',
                    async : false,
                    success: function ( result, request ) {

                        waitSave.hide();

                        var obj = Ext.decode(result.responseText);


                        if(obj.success === "false")
                        {
                            if(arg !== "default")
                            {
                                msg("FAILURE",obj.message);
                            }

                            me.getController('MyApp.controller.Main').showLoginView();

                            valid =  false;

                        }
                        else
                        {
                            valid =  true;
                        }

                    },
                    failure: function(form, action) {
                        waitSave.hide();

                        switch (action.failureType)
                        {
                            case Ext.form.action.Action.CLIENT_INVALID:
                            msg('Failure', 'Form fields may not be submitted with invalid values');
                            break;
                            case Ext.form.action.Action.CONNECT_FAILURE:
                            msg('Failure', 'Ajax communication failed');
                            break;
                            case Ext.form.action.Action.SERVER_INVALID:
                            msg('Failure', action.result.msg);
                        }

                        valid =  false;
                    }

                });

                if(valid !== null)
                {
                    return valid;
                }
    },

    newLogin: function() {
        var me = this;
                //var userName = Ext.ComponentQuery.query('#txtUserNameSec')[0].getValue();
                //var password = Ext.ComponentQuery.query('#txtPasswordSec')[0].getValue();

                /*
                console.log("getUserName",me.getUserName().getValue());
                console.log("getPassword",me.getPassword().getValue());
                */

                var userName = me.getUserName().getValue();
                var user = {
                    userID : me.getUserName().getValue(),
                    password : me.getPassword().getValue()
                };

                /*


                var user = {
                userID :userName,
                password : password
                };

                */



                var waitSave = watiMsg("Please wait ...");

                //------------------------------------------------------
                // NB: Posting Data to Server
                //------------------------------------------------------
        alert('ok');
                Ext.Ajax.request({
                    url: '../Handlers/Security/LoginHandler.ashx',
                    params:user,
                    success: function ( result, request ) {
        alert('ok1');
                        waitSave.hide();

                        var obj = Ext.decode(result.responseText);

                        var el = Ext.get('logOUt');
                        var elLoginTitle = Ext.get('LoginTitle');
                        var elNepDate=Ext.get('nepDate');
                        var elOffCode=Ext.get('offCode');

                        if(obj.success === "true")
                        {
                            //console.log("obj Login",obj);

                            //Ext.Msg.alert('Status', 'Login Successful!', function(btn, text){
                            // if (btn == 'ok'){

                            //Sets Office Code
                            elOffCode.dom.innerHTML=obj.root.Obj.OfficeUser.OfficeCode;

                            //Sets Nepali Date
                            GetNepaliDate(function(nepaliDate){
                                elNepDate.dom.innerHTML=nepaliDate;
                            });


                            el.child('span').dom.innerHTML = "LogOut";
                            elLoginTitle.dom.innerHTML = "Welcome " + userName;
                            me.getController('MyApp.controller.Main').showMainView();

                            var store=Ext.getStore('TreePanelDataStore');
                            //var data=JSON.stringify(obj.root.MenuObj);
                            //console.log('JSON MENU',data);
                            store.setRootNode(obj.root.MenuObj);
                            // }
                            //});
                        }
                        else
                        {
                            alert('ok3');
                            msg("FAILURE",obj.message);
                        }

                    },
                    failure: function(form, action) {
                        waitSave.hide();
        alert('ok4');
                        switch (action.failureType)
                        {
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

});
