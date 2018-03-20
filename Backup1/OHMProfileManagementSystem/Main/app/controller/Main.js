/*
 * File: app/controller/Main.js
 *
 * This file was generated by Sencha Architect version 2.2.2.
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

Ext.define('MyApp.controller.Main', {
    extend: 'Ext.app.Controller',

    stores: [
        'LoginUser'
    ],

    showMainView: function() {
        /*
        Ext.application({
        name:'MyApp',
        controllers:["MenuController"],	
        launch:function(){
        var pnlDynamic = Ext.create('MyApp.view.MenuController',{
        autoScroll: true,
        height:1000,
        flex:1
        });

        //pnlDynamic.extraParam = ExtraParam;

        var pnlToRender = Ext.getCmp('cntBody');
        pnlToRender.removeAll();
        pnlToRender.add(pnlDynamic);
    }
    });
    */

    var pnlToRender = Ext.getCmp('cntBody'); 
    var pnlDynamic = Ext.create('MyApp.view.MenuController',{
    autoScroll: true,
    height:1000,
    flex:1
    });

    pnlToRender.removeAll();
    pnlToRender.add(pnlDynamic);


    },

    destroyAll: function() {
        var pnlToRender = Ext.getCmp('cntBody'); 
        pnlToRender.removeAll();
    },

    showLoginView: function() {
        /*
        Ext.application({
        name:'MyApp',
        controllers:["LoginSecurity"],	
        launch:function(){
        var pnlDynamic = Ext.create('MyApp.view.LoginSecurity',{
        autoScroll: true,
        height:1000,
        flex:1
        });

        //pnlDynamic.extraParam = ExtraParam;

        var pnlToRender = Ext.getCmp('cntBody');
        pnlToRender.removeAll();
        pnlToRender.add(pnlDynamic);
    }
    });

    */
    var pnlToRender = Ext.getCmp('cntBody');
    var pnlDynamic = Ext.create('MyApp.view.LoginSecurity',{
    autoScroll: true,
    height:1000,
    flex:1
    });


    pnlToRender.removeAll();
    pnlToRender.add(pnlDynamic);

    },

    LoadUserFromSession: function() {
        var me=this;
        Ext.Ajax.request({
            url:"../Handlers/Security/UserHandler.ashx?method=GetUserFromSession",
            success: function ( result, request ) {          
                var obj = Ext.decode(result.responseText);
                //console.log(obj);
                var el = Ext.get('logOUt');
                var elLoginTitle = Ext.get('LoginTitle');
                var elNepDate=Ext.get('nepDate');
                var elOffCode=Ext.get('offCode');


                elOffCode.dom.innerHTML=obj.root.Obj.OfficeUser.OfficeCode;

                //Sets Nepali Date
                GetNepaliDate(function(nepaliDate){
                    elNepDate.dom.innerHTML=nepaliDate;
                });


                el.child('span').dom.innerHTML = "LogOut";  
                elLoginTitle.dom.innerHTML = "Welcome " + obj.root.Obj.UserID;
                me.getController('MyApp.controller.Main').showMainView();                    

                var store=Ext.getStore('TreePanelDataStore');
                //var data=JSON.stringify(obj.root.MenuObj);   
                //console.log('JSON MENU',data);
                store.setRootNode(obj.root.MenuObj);











            },
            failure: function ( result, request ) {
                msg("FAILURE","Error in Fetching Data !!!");
            }
        });
    }

});