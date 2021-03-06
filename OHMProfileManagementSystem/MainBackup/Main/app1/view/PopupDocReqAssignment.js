/*
 * File: app/view/PopupDocReqAssignment.js
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
                            height: 500,
                            itemId: 'grdPopupReqDocAssignment',
                            maxHeight: 500,
                            minHeight: 500,
                            autoScroll: true,
                            title: '',
                            store: 'strpopupDocReqAssignment',
                            columns: [
                                {
                                    xtype: 'gridcolumn',
                                    hidden: true,
                                    dataIndex: 'REQUEST_ID',
                                    text: 'REQUEST_ID'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    hidden: true,
                                    dataIndex: 'REQUEST_DATE',
                                    text: 'REQUEST_DATE'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    hidden: true,
                                    dataIndex: 'REQUEST_TYPE',
                                    text: 'REQUEST_TYPE'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'DOC_ID',
                                    text: 'Document Id'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    hidden: true,
                                    dataIndex: 'REQ_OFFCODE',
                                    text: 'REQ_OFFCODE'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    hidden: true,
                                    dataIndex: 'REQUEST_BY',
                                    text: 'REQUEST_BY'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    hidden: true,
                                    dataIndex: 'REQBY_FROM_DATE',
                                    text: 'REQBY_FROM_DATE'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    hidden: true,
                                    dataIndex: 'ENTRY_BY',
                                    text: 'ENTRY_BY'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    hidden: true,
                                    dataIndex: 'ENTRY_DATE',
                                    text: 'ENTRY_DATE'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    hidden: true,
                                    dataIndex: 'TRAN_NO',
                                    text: 'TRAN_NO'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    hidden: true,
                                    dataIndex: 'R_STATUS',
                                    text: 'R_STATUS'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    hidden: true,
                                    dataIndex: 'KEYWORD',
                                    text: 'KEYWORD'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    hidden: true,
                                    dataIndex: 'ID',
                                    text: 'ID'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    hidden: true,
                                    dataIndex: 'REQUEST_FOR',
                                    text: 'REQUEST_FOR'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'DOC_SUBJECT',
                                    text: 'Document Subject'
                                },
                                {
                                    xtype: 'actioncolumn',
                                    itemId: 'PopupPreView',
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
                                                var reqid=utStore.getAt(selectedIndxT).data.REQUEST_ID; 

                                                console.log("dddddddddd",reqid);

                                                var watiMsg=waitMsg('Loading ...');




                                                Ext.Msg.confirm('Confirm Action', 'Do you want to Update?', function(btn) {
                                                    if(btn == 'yes'){




                                                        Ext.Ajax.request
                                                        ({

                                                            url:'../Handlers/DocumentManagement/DocumentRequestHandler.ashx?method=UpdateDocReqassByid',
                                                            params:{ID:pan,DOC_ID:Doc_ID,REQUEST_ID:reqid},


                                                            success:function(result,response){
                                                                console.log(result.responseText);
                                                                var obj =Ext.decode(result.responseText);
                                                                var row = obj.root;
                                                                console.log("row-->",obj.root); 

                                                                msg(obj.success === "true" ?"SUCCESS":"FAILURE",obj.message);





                                                                //Reloading Parent form

                                                                var strpopupDocReqAssgn=Ext.getStore('strDocReqAssignment');
                                                                strpopupDocReqAssgn.removeAll();
                                                                strpopupDocReqAssgn.loadData([],false);

                                                                var offCode=Ext.get('offCode').dom.innerHTML;
                                                                var grdDocReqAssignment=Ext.ComponentQuery.query('#grdDocReqAssignment')[0];




                                                                Ext.Ajax.request
                                                                ({

                                                                    url:'../Handlers/DocumentManagement/DocumentRequestHandler.ashx?method=GetAllDocReqAssignment',
                                                                    params:{REQ_OFFCODE:offCode},


                                                                    success:function(response){
                                                                        console.log(response.responseText);
                                                                        var obj =Ext.decode(response.responseText);
                                                                        var row = obj.root;
                                                                        console.log("row-->",obj.root);       

                                                                        grdDocReqAssignment.store.add(obj.root);
                                                                        watiMsg.hide();

                                                                    },

                                                                    failure:function(response)
                                                                    {
                                                                        msg('FAILURE',Ext.decode(response));
                                                                        watiMsg.hide();

                                                                    }



                                                                });


                                                                // End Reloading Parent form




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
                                            tooltip: 'search'
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