/*
 * File: app/view/DocReqAssignment.js
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

Ext.define('MyApp.view.DocReqAssignment', {
    extend: 'Ext.panel.Panel',

    frame: true,
    itemId: 'DocReqAssignment',
    title: 'Document Request Assignment',

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'form',
                    frame: true,
                    height: 420,
                    bodyPadding: 10,
                    title: 'My Form',
                    items: [
                        {
                            xtype: 'gridpanel',
                            frame: true,
                            height: 350,
                            itemId: 'grdDocReqAssignment',
                            maxHeight: 350,
                            minHeight: 350,
                            autoScroll: true,
                            title: 'My Grid Panel',
                            store: 'strDocReqAssignment',
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
                                    itemId: 'btnSearch',
                                    items: [
                                        {
                                            handler: function(view, rowIndex, colIndex, item, e, record, row) {
                                                var grd=Ext.ComponentQuery.query('#grdDocReqAssignment')[0];
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




                                                var watiMsg=waitMsg('Loading ...');

                                                Ext.Ajax.request
                                                ({

                                                    url:'../Handlers/DocumentManagement/DocumentRequestHandler.ashx?method=GetDocReqAssmtbyid',
                                                    params:{ID:pan},


                                                    success:function(response){
                                                        console.log(response.responseText);
                                                        var obj =Ext.decode(response.responseText);
                                                        var row = obj.root;
                                                        //console.log("row-->",obj.root.getCount()); 

                                                        if(obj.root.length>1)
                                                        {
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




                                                            //uiConfig = {menuLink:"PopupDocReqAssignment",pageTitle:"POPUP"};
                                                            //DynamicUI(uiConfig,null,{tranNo:tranNo,indexM:selectedIndx,indexT:selectedIndxT,from:"MV"});



                                                            var params={ID:ID};
                                                            //Ext.getCmp("PopupWindow").close();

                                                            dynamicPopUp("PopupDocReqAssignment",{params:params});
                                                        }

                                                        else
                                                        {
                                                            msg("info","Single record Updated Successfully");
                                                            return;
                                                            //Ext.Msg.alert('Status', 'Changes saved successfully.');
                                                        }


                                                        //popup    



                                                        //En popup        













                                                        //grdDocReqAssignment.store.add(obj.root);
                                                        watiMsg.hide();

                                                    },

                                                    failure:function(response)
                                                    {
                                                        msg('FAILURE',Ext.decode(response));

                                                    }



                                                });

                                            },
                                            icon: '../ITS/resources/images/icons/eye.png'
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