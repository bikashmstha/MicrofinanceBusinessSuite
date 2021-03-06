/*
 * File: app/controller/DDiplomatList.js
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

Ext.define('MyApp.controller.DDiplomatList', {
    extend: 'Ext.app.Controller',

    models: [
        'AgencyList'
    ],
    stores: [
        'AgencyList'
    ],
    views: [
        'DDiplomatList'
    ],

    onGrdDDListAfterRender: function(abstractcomponent, options) {
        var store = Ext.getStore('AgencyList');
        store.load();
    },

    onGrdDDListItemClick: function(tablepanel, record, item, index, e, options) {
        var hdnDDid = Ext.ComponentQuery.query("#hdnDDid")[0];
        hdnDDid.setValue(index);

        var hdnDDdcode = Ext.ComponentQuery.query("#hdnDDdcode")[0];
        var hdnDDname = Ext.ComponentQuery.query("#hdnDDname")[0];

        hdnDDdcode.setValue(record.data.dcode);
        hdnDDname.setValue(record.data.username);
    },

    onBtnDDStatusClick: function(button, e, options) {
        var grid = Ext.ComponentQuery.query("#grdDDList")[0];
        var selected = grid.getSelectionModel().getSelection()[0];
        var me = this;

        if(selected===undefined)
        {
            msg("WARNING","Please select the user to change status");
            return false;
        }

        var hdnDDid = Ext.ComponentQuery.query("#hdnDDid")[0];
        var id = hdnDDid.getValue();

        me.getController('MyApp.controller.WndDDLStatus').init();

        me.getController('MyApp.controller.WndDDLStatus').showStatus();

        me.getController('MyApp.controller.WndDDLStatus').WndSession(id);

        var hdnDDdcode = Ext.ComponentQuery.query("#hdnDDdcode")[0];
        var hdnDDname = Ext.ComponentQuery.query("#hdnDDname")[0];

        hdnDDid.setValue("");
        hdnDDdcode.setValue("");
        hdnDDname.setValue("");
    },

    onBtnDDResetPwdClick: function(button, e, options) {
        var me = this;

        var grid = Ext.ComponentQuery.query("#grdDDList")[0];
        var selected = grid.getSelectionModel().getSelection()[0];

        if(selected===undefined)
        {
            msg("WARNING","Please select the user to reset password");
            return false;
        }

        var hdnDDdcode = Ext.ComponentQuery.query("#hdnDDdcode")[0];
        var hdnDDname = Ext.ComponentQuery.query("#hdnDDname")[0];
        var hdnDDlogUser = Ext.ComponentQuery.query("#hdnDDlogUser")[0];

        if(hdnDDdcode.getValue()==="")
        {
            msg("WARNING","The selected user does not have user login");
            return false;
        }

        var diplomaticUserInfo={
            d_username:hdnDDname.getValue(),
            d_password:hdnDDname.getValue(),
            d_code:hdnDDdcode.getValue(),
            modified_by:hdnDDlogUser.getValue()
        };

        Ext.Ajax.request({
            url:"../Handlers/DiplomaticRefund/DiplomaticUserHandler.ashx?method=ChangePassword",
            params:{diplomaticUser:JSON.stringify(diplomaticUserInfo)},
            success: function ( result, request ){

                var obj = Ext.decode(result.responseText);

                var data = obj.root;

                if(obj.success==="true")
                {
                    msg("SUCCESS",obj.message);

                }
                else if(obj.success==="false")
                {
                    msg("FAILURE",obj.message);
                }

            },

            failure: function ( result, request ){

                msg("FAILURE","Error in Fetching Data !!!");
                return;
            }

        });

    },

    viewDiplomatList: function(value) {
        Ext.getCmp('cntARDisplay').removeAll();

        var DTran = Ext.create('MyApp.view.DDiplomatList');
        var pnlToRender = Ext.getCmp('cntARDisplay');

        pnlToRender.add(DTran);

        var hdnDDlogUser = Ext.ComponentQuery.query("#hdnDDlogUser")[0];
        hdnDDlogUser.setValue(value);
    },

    init: function(application) {
        this.control({
            "#grdDDList": {
                afterrender: this.onGrdDDListAfterRender,
                itemclick: this.onGrdDDListItemClick
            },
            "#btnDDStatus": {
                click: this.onBtnDDStatusClick
            },
            "#btnDDResetPwd": {
                click: this.onBtnDDResetPwdClick
            }
        });
    }

});
