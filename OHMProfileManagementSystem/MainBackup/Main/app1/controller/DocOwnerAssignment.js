/*
 * File: app/controller/DocOwnerAssignment.js
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

Ext.define('MyApp.controller.DocOwnerAssignment', {
    extend: 'Ext.app.Controller',

    stores: [
        'DocOfficeStore',
        'DocUserStore',
        'DocOwnerOfficeStore',
        'DocOwnerUserStore',
        'DocAssignStore'
    ],

    onDocOwnerAssignmentAfterRender: function(component, eOpts) {

        var officeCode=Ext.get('offCode').dom.innerHTML;

        var OwnerOfficeComb=Ext.ComponentQuery.query('#cmbOfficeOwner')[0];
        var officeComb=Ext.ComponentQuery.query('#cmbOffice')[0];
        var grdDocAssign=Ext.ComponentQuery.query('#grdDocAssign')[0];
        grdDocAssign.store.loadData([],false);

        Ext.Ajax.request
        ({

            url:'../Handlers/Common/OfficeHandler.ashx?method=GetOfficeByParentType',
            params:{parentID:officeCode},

            success:function(response){
                var obj =Ext.decode(response.responseText);
                var row = obj.root;
                officeComb.store.loadData([],false);
                OwnerOfficeComb.store.loadData([],false);

                officeComb.store.add(row);
                OwnerOfficeComb.store.add(row);

            },
            failure:function()
            {
                msg('FAILURE',Ext.decode(response));

            }



        });
    },

    onCmbOfficeOwnerChange: function(field, newValue, oldValue, eOpts) {

        var officeCode=newValue;
        var strOwnerUser=Ext.getStore('DocOwnerUserStore');



        Ext.Ajax.request
        ({

            url:'../Handlers/Security/OfficeUserHandler.ashx?method=GetOfficeUsers',
            params:{parentID:officeCode},

            success:function(response){        
                var obj =Ext.decode(response.responseText);
                var row = obj.root;
                console.log(row);
                strOwnerUser.loadData([],false);
                strOwnerUser.add(row);         

            },
            failure:function()
            {
                msg('FAILURE',Ext.decode(response));

            }



        });


    },

    onCmbOwnerUserChange: function(field, newValue, oldValue, eOpts) {

        var selUser=Ext.ComponentQuery.query('#cmbOwnerUser')[0].getValue();
        var selOwnerOfficeCode=Ext.ComponentQuery.query('#cmbOfficeOwner')[0].getValue();
        var grdDocAssign=Ext.ComponentQuery.query('#grdDocAssign')[0];

        if(selOwnerOfficeCode)
        {

            Ext.Ajax.request
            ({

                url:'../Handlers/DocumentManagement/DocOwnerAssignHandler.ashx?method=GetAllDocument',
                params:{officCode:selOwnerOfficeCode,userID:selUser},

                success:function(response){        
                    var obj =Ext.decode(response.responseText);
                    var row = obj.root;

                    Ext.ComponentQuery.query('#hdnRow')[0].setValue(row);
                    grdDocAssign.store.loadData([],false);
                    grdDocAssign.store.add(row);         

                },
                failure:function()
                {
                    msg('FAILURE',Ext.decode(response));

                }



            });
        }


    },

    onCmbOfficeChange: function(field, newValue, oldValue, eOpts) {

        var officeCode=newValue;
        var strUser=Ext.getStore('DocUserStore');


        Ext.Ajax.request
        ({

            url:'../Handlers/Security/OfficeUserHandler.ashx?method=GetOfficeUsers',
            params:{parentID:officeCode},

            success:function(response){        
                var obj =Ext.decode(response.responseText);
                var row = obj.root;
                strUser.loadData([],false);
                strUser.add(row);

            },
            failure:function()
            {
                msg('FAILURE',Ext.decode(response));

            }



        });

    },

    onBtnDocAssignClick: function(button, e, eOpts) {
        var OwnerOfficeCode=Ext.ComponentQuery.query('#cmbOfficeOwner')[0].getValue();
        var Owner=Ext.ComponentQuery.query('#cmbOwnerUser')[0].getValue();


        var officeReq=Ext.ComponentQuery.query('#cmbOffice')[0].getValue();
        var newUser=Ext.ComponentQuery.query('#cmbUser')[0].getValue();

        var grdDocAssign=Ext.ComponentQuery.query('#grdDocAssign')[0];
        var rec=[];
        var selectedGrdDoc = grdDocAssign.getSelectionModel().getSelection();
        console.log('selectionGrdPan>>?',selectedGrdDoc);
        if(!OwnerOfficeCode)
        {
            msg("WARNING","Please select Owner Office !!!");
            return;
        }
        if(!Owner)
        {
            msg("WARNING","Please select Owner !!!");
            return;
        }
        if(!officeReq)
        {
            msg("WARNING","Please Office to asiign diocuments!!!");
            return;
        }
        if(!newUser)
        {
            msg("WARNING","Please User to asiign diocuments!!!");
            return;
        }

        if(selectedGrdDoc.length < 1)
        {
            msg("WARNING","Please select Document !!!");
            return;
        }


        else
        {

            for (var i = 0; i < selectedGrdDoc.length; i++)
            {

                rec.push(selectedGrdDoc[i].data.DocID);

            }
        }


        Ext.Ajax.request
        ({

            url:'../Handlers/DocumentManagement/DocOwnerAssignHandler.ashx?method=AssignDocToUser',
            params:{parentID:OwnerOfficeCode,parentUser:Owner,newID:officeReq,newUser:newUser,DocRegDoc:JSON.stringify(rec)},

            success:function(response){
                var obj =Ext.decode(response.responseText);
                msg(obj.success === "true" ?"SUCCESS":"FAILURE",obj.message);

                grdDocAssign.store.loadData([],false);


            },
            failure:function(response)
            {
                msg('FAILURE',Ext.decode(response));

            }



        });

    },

    onBtnCancelClick: function(button, e, eOpts) {
        Ext.ComponentQuery.query('#cmbOfficeOwner')[0].reset();
        Ext.ComponentQuery.query('#cmbOwnerUser')[0].reset();
        Ext.ComponentQuery.query('#cmbOffice')[0].reset();
        Ext.ComponentQuery.query('#cmbUser')[0].reset();

        var grdDA = Ext.ComponentQuery.query('#grdDocAssign')[0];
        grdDA.store.loadData([],false);

        var strOwnerUser=Ext.getStore('DocOwnerUserStore');
        strOwnerUser.removeAll();
    },

    init: function(application) {
        this.control({
            "#DocOwnerAssignment": {
                afterrender: this.onDocOwnerAssignmentAfterRender
            },
            "#cmbOfficeOwner": {
                change: this.onCmbOfficeOwnerChange
            },
            "#cmbOwnerUser": {
                change: this.onCmbOwnerUserChange
            },
            "#cmbOffice": {
                change: this.onCmbOfficeChange
            },
            "#btnDocAssign": {
                click: this.onBtnDocAssignClick
            },
            "#btnCancel": {
                click: this.onBtnCancelClick
            }
        });
    }

});