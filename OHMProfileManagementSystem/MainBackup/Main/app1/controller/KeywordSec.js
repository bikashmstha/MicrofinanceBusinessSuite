/*
 * File: app/controller/KeywordSec.js
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

Ext.define('MyApp.controller.KeywordSec', {
    extend: 'Ext.app.Controller',

    stores: [
        'KeywordSec'
    ],
    views: [
        'KeywordSec'
    ],

    onBtnCancellKSClick: function(button, e, eOpts) {
        var me = this;

        me.clear("Reset");

        var gridKSL = Ext.ComponentQuery.query('#grdKeywordSectionLIst')[0];
        gridKSL.getSelectionModel().deselectAll();


    },

    onBtnSubmitKSClick: function(button, e, eOpts) {
        var me = this;

        var store = Ext.getStore('KeywordSec');

        var txtKeyword = Ext.ComponentQuery.query('#txtKeyword')[0];
        var txtKeywordDesc = Ext.ComponentQuery.query('#txtKeywordDesc')[0];
        var chkStatus = Ext.ComponentQuery.query("#chkStatus")[0];

        var btnSubmitKS = Ext.ComponentQuery.query('#btnSubmitKS')[0];


        var keyWord = txtKeyword.getValue();
        var keywordDesc = txtKeywordDesc.getValue();
        var Status = chkStatus.getValue();

        var gridKSL = Ext.ComponentQuery.query('#grdKeywordSectionLIst')[0];
        var selected = gridKSL.getSelectionModel().getSelection()[0];
        var act;

        var sta;

        if(keyWord ==="")
        {
            msg("WARNING","Please enter Keyword",function(){txtKeyword.focus(); });
            return false;
        }

        if(keywordDesc ==="")
        {
            msg("WARNING","Please enter Keyword Description",function(){txtKeywordDesc.focus(); });
            return false;
        }

        if (Status===true)
        {
            sta='Y';
        }

        else
        {
            sta='N';
        }

        var hdnIndex = Ext.ComponentQuery.query('#hdnIndex')[0].getValue();
        var hdnId = Ext.ComponentQuery.query('#hdnId')[0];

        var id = hdnId.getValue();

        var row = store.getAt(hdnIndex);


        var keywordSection = "";

        if (selected!== undefined)
        {
            act='E';
            if (Status===true)
            {
                keywordSection =  {
                    kw_id:id,
                    Keyword:keyWord,
                    KeywordDesc:keywordDesc,
                    Status:'Y',
                    Action:act
                };

            }
            else if (Status===false)
            {

                keywordSection =  {
                    kw_id:id,
                    Keyword:keyWord,
                    KeywordDesc:keywordDesc,
                    Status:'N',
                    Action:act
                };


            }

        }
        else
        {
            act = 'I';

            if (Status===true)
            {
                keywordSection =  {
                    Keyword:keyWord,
                    KeywordDesc:keywordDesc,
                    Status:'Y',
                    Action:act
                };

            }
            if (Status===false)
            {
                keywordSection =  {
                    Keyword:keyWord,
                    KeywordDesc:keywordDesc,
                    Status:'N',
                    Action:act
                };


            }
        }


        if (act =="I")
        {
            Ext.Ajax.request({
                url:"../Handlers/DocumentManagement/KeywordSectionHandler.ashx?method=SaveKeywordSection",
                params:{keywordSection:JSON.stringify(keywordSection)},
                success: function ( result, request ){
                    // waitSave.hide();
                    var obj = Ext.decode(result.responseText);
                    console.log(obj);

                    msg(obj.success == "true" ?"SUCCESS":"FAILURE",obj.message);

                    store.load();
                    me.clear("Reset");
                    MyApp.app.getController('DocumentReg').IsUpdateKeyword("true");

                    if(obj.success === "false")

                    {return;}

                },

                failure: function ( result, request ){

                    // waitSave.hide();
                    msg("FAILURE","Error in Fetching Data !!!");
                    return;
                }

            });
        }
        else if (act =="E")
        {
            Ext.Ajax.request({
                url:"../Handlers/DocumentManagement/KeywordSectionHandler.ashx?method=UpdateKeywordSection",
                params:{keywordSection:JSON.stringify(keywordSection)},
                success: function ( result, request ){
                    // waitSave.hide();
                    var obj = Ext.decode(result.responseText);

                    msg(obj.success === "true" ?"SUCCESS":"FAILURE",obj.message);

                    store.load();
                    me.clear("Reset");
                    MyApp.app.getController('DocumentReg').IsUpdateKeyword("true");

                    if(obj.success === "false")

                    {return;}

                },

                failure: function ( result, request ){

                    // waitSave.hide();
                    msg("FAILURE","Error in Fetching Data !!!");
                    return;
                }

            });
        }



    },

    onGrdKeywordSectionLIstAfterRender: function(component, eOpts) {
        var store = Ext.getStore('KeywordSec');

        store.load({
            params:{Keyword:""}
        });

        console.log("store",store);
        var items = store.data.items;


    },

    onGrdKeywordSectionLIstItemClick: function(dataview, record, item, index, e, eOpts) {
        var me = this;

        me.clear("Reset");

        var txtKeyword = Ext.ComponentQuery.query('#txtKeyword')[0];
        var txtKeywordDesc = Ext.ComponentQuery.query('#txtKeywordDesc')[0];
        var chkStatus = Ext.ComponentQuery.query("#chkStatus")[0];

        var btnSubmitKS = Ext.ComponentQuery.query('#btnSubmitKS')[0];

        txtKeyword.setValue(record.data.Keyword);
        txtKeyword.setReadOnly(false);
        txtKeywordDesc.setValue(record.data.KeywordDesc);
        txtKeywordDesc.setReadOnly(false);


        var statustype = record.data.Status;
        var id = record.data.kw_id;
        var date = record.data.EntryDate;
        if (statustype=='Y')
        {
            chkStatus.setValue(true);
        }
        else
        {
            chkStatus.setValue(false);
        }

        chkStatus.setReadOnly(false);

        btnSubmitKS.setText('Edit');
        btnSubmitKS.setIconCls('icon-edit');


        var hdnIndex = Ext.ComponentQuery.query('#hdnIndex')[0];
        hdnIndex.setValue(index);
        var hdnId = Ext.ComponentQuery.query('#hdnId')[0];
        hdnId.setValue(id);

    },

    onBtnDeleteKSClick: function(button, e, eOpts) {
        var me = this;

        var store = Ext.getStore('KeywordSec');

        var txtKeyword = Ext.ComponentQuery.query('#txtKeyword')[0];
        var txtKeywordDesc = Ext.ComponentQuery.query('#txtKeywordDesc')[0];
        var chkStatus = Ext.ComponentQuery.query("#chkStatus")[0];

        var btnSubmitKS = Ext.ComponentQuery.query('#btnSubmitKS')[0];


        var keyWord = txtKeyword.getValue();
        var keywordDesc = txtKeywordDesc.getValue();
        var Status = chkStatus.getValue();

        var gridKSL = Ext.ComponentQuery.query('#grdKeywordSectionLIst')[0];
        var selected = gridKSL.getSelectionModel().getSelection()[0];

        if (selected!== undefined)
        {
            var act = "D";

            var sta;
            var keywordSection = "";

            var hdnIndex = Ext.ComponentQuery.query('#hdnIndex')[0].getValue();
            console.log("hdnIndex",hdnIndex);
            var row = store.getAt(hdnIndex);

            var hdnId = Ext.ComponentQuery.query('#hdnId')[0];

            var id = hdnId.getValue();

            if (Status===true)
            {
                keywordSection =  {
                    kw_id:id,
                    Keyword:keyWord,
                    KeywordDesc:keywordDesc,
                    Status:'Y',
                    Action:act
                };
            }

            else
            {
                keywordSection =  {
                    kw_id:id,
                    Keyword:keyWord,
                    KeywordDesc:keywordDesc,
                    Status:'N',
                    Action:act
                };

            }


            Ext.Ajax.request({
                url:"../Handlers/DocumentManagement/KeywordSectionHandler.ashx?method=DeleteKeywordSection",
                params:{keywordSection:JSON.stringify(keywordSection)},
                success: function ( result, request ){
                    // waitSave.hide();
                    var obj = Ext.decode(result.responseText);

                    msg(obj.success === "true" ?"SUCCESS":"FAILURE",obj.message);

                    store.load();
                    me.clear("Reset");

                    if(obj.success === "false")

                    {return;}

                },

                failure: function ( result, request ){

                    // waitSave.hide();
                    msg("FAILURE","Error in Fetching Data !!!");
                    return;
                }

            });
        }
        else
        {
            msg("INFO","Please Select a keyword to delete!!!");
        }   




    },

    clear: function(args) {
        if(args=="Reset")
        {
            var txtKeyword = Ext.ComponentQuery.query('#txtKeyword')[0];
            var txtKeywordDesc = Ext.ComponentQuery.query('#txtKeywordDesc')[0];
            var chkStatus = Ext.ComponentQuery.query("#chkStatus")[0];

            var btnSubmitKS = Ext.ComponentQuery.query('#btnSubmitKS')[0];

            txtKeyword.setValue("");
            txtKeywordDesc.setValue("");
            chkStatus.setValue('true');

            txtKeyword.setReadOnly(false);
            txtKeywordDesc.setReadOnly(false);
            chkStatus.setReadOnly(false);

            btnSubmitKS.setText('Submit');
            btnSubmitKS.setIconCls('icon-save');


        }
    },

    init: function(application) {
        this.control({
            "#btnCancellKS": {
                click: this.onBtnCancellKSClick
            },
            "#btnSubmitKS": {
                click: this.onBtnSubmitKSClick
            },
            "#grdKeywordSectionLIst": {
                afterrender: this.onGrdKeywordSectionLIstAfterRender,
                itemclick: this.onGrdKeywordSectionLIstItemClick
            },
            "#btnDeleteKS": {
                click: this.onBtnDeleteKSClick
            }
        });
    }

});