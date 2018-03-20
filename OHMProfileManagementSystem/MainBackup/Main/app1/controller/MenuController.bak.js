/*
 * File: app/controller/MenuController.js
 *
 * This file was generated by Sencha Architect version 2.1.0.
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

Ext.define('MyApp.controller.MenuController', {
    extend: 'Ext.app.Controller',

    stores: [
        'LoginUser'
    ],
    views: [
        'MenuController'
    ],

    onTrMenusItemClick: function(dataview, record, item, index, e, options) {
        var me = this;
        var user = me.getController('MyApp.controller.LoginSecurity');    
        var valid = user.validateSession("default");

        if(valid) 
        {    
            if(record.data.link!="NULL"&&record.data.link!='null'&&record.data.link!==''&&record.data.link!=null)
            {

                bCumb="";
                var breadCrumbText=  getPNode(record);		
                var breadCrumbTextArr=breadCrumbText.split('$');		
                breadCrumbTextArr.reverse();
                var breadCrumbTextt=breadCrumbTextArr.join('>>');

                var uiConfig = {menuLink:record.data.link,
                    pageTitle:breadCrumbTextt
                };
                // console.log("uiConfig",uiConfig);
                DynamicUI(uiConfig);
            }
        }


        //-------------------------------------------------------------------------------
        //loadDynamicPanel(record.data.text+'@@'+record.data.link);

        /*
        var uiConfig = {menuLink:record.data.link,
        pageTitle:record.data.text
        };
        */
        //console.log('test parent',record.data.parentNode);

        /*
        console.log('record',record);
        console.log('item',item);
        console.log('e',e);
        console.log('options',options);
        console.log('dataview',dataview);
        var breadcrumb = record.get('breadcrumb');

        alert('breadcrumb' + breadcrumb);
        */






        //DLC(ContOnDemandArray[record.data.id],record.data.text+'@@'+record.data.link);

        //DLC(record.data.link);
    },

  onTreepanelBeforeItemExpand: function(nodeinterface, eOpts) {
        var moduleProvider = getAppProvider(nodeinterface.data.appId);
        var currentProvider = getCurrentProvider();
        if (currentProvider.provider != moduleProvider && nodeinterface.data.appId != "" && nodeinterface.data.appId != undefined) {

            Ext.Ajax.request({
                url: '../Handlers/Security/SessionHandler.ashx?method=getToken',
                success: function (result, request) {
                    result = Ext.JSON.decode(result.responseText);
                    if (result.success == "true") {
                        token = result.root;
                        var module = nodeinterface.data.appId;
                        location.replace(getProviderUrl(moduleProvider) + token + "&module=" + nodeinterface.data.appId);
                    } else {
                        showMessage("Error:", result.message);
                    }
                },
                failure: function (form, action) {

                }

            });

            return false;
        }
    },

    init: function(application) {
        this.control({
            "#trMenus": {
                itemclick: this.onTrMenusItemClick//,
                //itemdblclick: this.onViewItemDblClick,
                //beforeitemdblclick: this.onViewBeforeItemDblClick
            },
            "treepanel": {
                beforeitemexpand: this.onTreepanelBeforeItemExpand
            }
        });
    }


});
