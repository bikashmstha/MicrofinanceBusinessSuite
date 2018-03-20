/*
 * File: app.js
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

Ext.Loader.setConfig({
    enabled: true
});

Ext.application({
    models: [
        'TreePanelModel'
    ],
    stores: [
        'TreePanelDataStore'
    ],
    views: [
        'MyViewport'
    ],
    autoCreateViewport: true,
    name: 'MyApp',
    controllers: [
        'LoginSecurity',
        'MenuController'
    ],

    launch: function() {
        var me = this;
        var clear = false;
        var main = me.getController('MyApp.controller.Main');
        var user = me.getController('MyApp.controller.LoginSecurity');    
        var valid = user.validateSession("default");

        var el = Ext.get('logOUt');
        var elLoginTitle = Ext.get('LoginTitle');


        if(valid)
        {    
            el.child('span').dom.innerHTML = "LogOut";
            main.showMainView();
            main.LoadUserFromSession();
        }

        el.on('click', function(e,t,eOpts){

            if(el.child('span').dom.innerHTML !== "LogIn")
            {
                el.child('span').dom.innerHTML = "LogIn";
                elLoginTitle.dom.innerHTML = "Welcome";
                clear = user.clearSession();
            }
        });


    }

});
