/*
 * File: app/view/PopupDocReqAssignment.js
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

Ext.define('MyApp.view.PopupDocReqAssignment', {
    extend: 'Ext.panel.Panel',

    frame: true,
    itemId: 'PopupDocReqAssignment',
    title: 'Document Request Assignment Popup',

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'form',
                    frame: true,
                    itemId: 'popupDRA',
                    bodyPadding: 10,
                    items: [
                        {
                            xtype: 'gridpanel',
                            height: 400,
                            itemId: 'grdPopupReqDocAssignment',
                            maxHeight: 400,
                            minHeight: 400,
                            autoScroll: true,
                            title: '',
                            store: 'strpopupDocReqAssignment',
                            columns: [
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'REQUEST_ID',
                                    text: 'REQUEST_ID'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'REQUEST_DATE',
                                    text: 'REQUEST_DATE'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'REQUEST_TYPE',
                                    text: 'REQUEST_TYPE'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'DOC_ID',
                                    text: 'DOC_ID'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'REQ_OFFCODE',
                                    text: 'REQ_OFFCODE'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'REQUEST_BY',
                                    text: 'REQUEST_BY'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'REQBY_FROM_DATE',
                                    text: 'REQBY_FROM_DATE'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'ENTRY_BY',
                                    text: 'ENTRY_BY'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'ENTRY_DATE',
                                    text: 'ENTRY_DATE'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'TRAN_NO',
                                    text: 'TRAN_NO'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'R_STATUS',
                                    text: 'R_STATUS'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'KEYWORD',
                                    text: 'KEYWORD'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'ID',
                                    text: 'ID'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'REQUEST_FOR',
                                    text: 'REQUEST_FOR'
                                },
                                {
                                    xtype: 'actioncolumn',
                                    itemId: 'PreView',
                                    items: [
                                        {
                                            handler: function(view, rowIndex, colIndex, item, e, record, row) {
                                                var grd=Ext.ComponentQuery.query('#grdPopupReqDocAssignment')[0];
                                                var selectionT=grd.getSelectionModel().getSelection()[0];
                                                console.log("ppp",selectionT);
                                                if(!selectionT)
                                                {
                                                    msg("WARNING","Select");
                                                    return;
                                                }
                                                var selectedIndxT= grd.getStore().indexOf(selectionT);

                                                var utStore =grd.getStore();
                                                console.log("store",utStore);
                                                var pan=utStore.getAt(selectedIndxT).data.ID;
                                                var Doc_ID=utStore.getAt(selectedIndxT).data.DOC_ID; 



                                                //var watiMsg=waitMsg('Loading ...');




                                                Ext.Msg.confirm('Confirm Action', 'एकपटक SUBMIT गरिसकेपछि अर्को पटक विवरण परिबर्नत हुने छैन्। \n के तपाई Submit गर्न चाहनुहन्छ ?', function(btn) {
                                                    if(btn == 'yes'){




                                                        Ext.Ajax.request
                                                        ({

                                                            url:'../Handlers/DocumentManagement/DocumentRequestHandler.ashx?method=UpdateDocReqassByid',
                                                            params:{ID:pan,DOC_ID:Doc_ID},


                                                            success:function(result,response){
                                                                console.log(result.responseText);
                                                                var obj =Ext.decode(result.responseText);
                                                                var row = obj.root;
                                                                console.log("row-->",obj.root); 

                                                                msg(obj.success === "true" ?"SUCCESS":"FAILURE",obj.message);




                                                                /*
                                                                //popup    

                                                                var grdID=Ext.ComponentQuery.query('#grdDocReqAssignment')[0];
                                                                var selectionT=grdID.getSelectionModel().getSelection()[0];
                                                                console.log("ppp",selectionT);
                                                                if(!selectionT)
                                                                {
                                                                    msg("WARNING","Select ID");
                                                                    return;
                                                                }
                                                                var selectedIndxT= grdID.getStore().indexOf(selectionT);

                                                                var utStore =grdID.getStore();
                                                                console.log("store",utStore);
                                                                var ID=utStore.getAt(selectedIndxT).data.ID;
                                                                alert(ID);

                                                                //uiConfig = {menuLink:"PopupDocReqAssignment",pageTitle:"POPUP"};
                                                                //DynamicUI(uiConfig,null,{tranNo:tranNo,indexM:selectedIndx,indexT:selectedIndxT,from:"MV"});



                                                                var params={ID:ID};
                                                                //Ext.getCmp("PopupWindow").close();

                                                                dynamicPopUp("PopupDocReqAssignment",{params:params});


                                                                //En popup        

                                                                */











                                                                //grdDocReqAssignment.store.add(obj.root);
                                                                // watiMsg.hide();

                                                            },

                                                            failure:function(response)
                                                            {
                                                                msg('FAILURE',Ext.decode(response));

                                                            }

                                                        });

                                                        return true;
                                                    }
                                                }, this);

                                            },
                                            icon: '../ITS/resources/images/icons/eye.png',
                                            tooltip: 'Search'
                                        }
                                    ]
                                }
                            ]
                        }
                    ]
                }
            ]
        });

        me.callParent(arguments);
    }

});