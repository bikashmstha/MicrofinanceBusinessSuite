/*
 * File: app/controller/DocReqViewer.js
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

Ext.define('MyApp.controller.DocReqViewer', {
    extend: 'Ext.app.Controller',

    stores: [
        'strDocReqViewer'
    ],

    onDocReqViewerAfterRender: function(component, eOpts) {



        var me=this;

        var offCode=Ext.get('offCode').dom.innerHTML;
        var grdDOcReqViewer=Ext.ComponentQuery.query('#grdDOcReqViewer')[0];
        var strDocReqViewer=Ext.getStore('strDocReqViewer');
        strDocReqViewer.removeAll();
        strDocReqViewer.loadData([],false);

        var watiMsg=waitMsg('Loading ...');

        Ext.Ajax.request
        ({

            url:'../Handlers/DocumentManagement/DocumentRequestHandler.ashx?method=GetDOcRequestForViewer',
            params:{ENRTY_BY:''},


            success:function(response){
                console.log(response.responseText);
                var obj =Ext.decode(response.responseText);
                var row = obj.root;
                console.log("row-->",obj.root);

                strDocReqViewer.removeAll();
                strDocReqViewer.loadData([],false);


                grdDOcReqViewer.store.add(obj.root);
                watiMsg.hide();

            },

            failure:function(response)
            {
                msg('FAILURE',Ext.decode(response));

            }



        });
    },

    init: function(application) {
        this.control({
            "#DocReqViewer": {
                afterrender: this.onDocReqViewerAfterRender
            }
        });
    }

});
