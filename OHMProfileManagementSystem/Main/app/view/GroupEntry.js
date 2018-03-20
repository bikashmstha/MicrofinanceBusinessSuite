/*
 * File: app/view/GroupEntry.js
 *
 * This file was generated by Sencha Architect version 4.2.2.
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

Ext.define('MyApp.view.GroupEntry', {
    extend: 'Ext.panel.Panel',

    requires: [
        'Ext.form.Panel',
        'Ext.form.field.Text',
        'Ext.form.field.Checkbox',
        'Ext.form.Label',
        'Ext.button.Button',
        'Ext.form.FieldSet',
        'Ext.grid.Panel',
        'Ext.grid.View',
        'Ext.grid.column.Action',
        'Ext.selection.RowModel',
        'Ext.panel.Tool'
    ],

    frame: true,
    title: 'Group Entry',

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'form',
                    frame: true,
                    itemId: 'frmGroupEntry',
                    bodyPadding: 10,
                    title: '',
                    layout: {
                        type: 'table',
                        columns: 3
                    },
                    items: [
                        {
                            xtype: 'container',
                            colspan: 3,
                            layout: {
                                type: 'table',
                                columns: 3
                            },
                            items: [
                                {
                                    xtype: 'textfield',
                                    colspan: 2,
                                    itemId: 'txtGroupFormedBs',
                                    fieldLabel: 'Group Formed(B.S)',
                                    labelWidth: 140,
                                    emptyText: 'DD-MON-YYYY'
                                },
                                {
                                    xtype: 'textfield',
                                    colspan: 1,
                                    itemId: 'txtGroupFormedAd',
                                    margin: '0 0 0 80',
                                    fieldLabel: 'Group Formed(A.D)',
                                    labelWidth: 140,
                                    emptyText: 'DD-MON-YYYY'
                                },
                                {
                                    xtype: 'textfield',
                                    colspan: 2,
                                    itemId: 'txtGroupCode',
                                    fieldLabel: 'Group Code',
                                    labelWidth: 140,
                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;',
                                    readOnly: true
                                },
                                {
                                    xtype: 'checkboxfield',
                                    colspan: 1,
                                    itemId: 'chkActive',
                                    margin: '0 0 0 80',
                                    fieldLabel: 'Active',
                                    boxLabel: ''
                                },
                                {
                                    xtype: 'textfield',
                                    colspan: 1,
                                    itemId: 'txtCenterCode',
                                    fieldLabel: 'Center Code',
                                    labelWidth: 140,
                                    fieldStyle: 'background-color:#DAEBE1;background-image:none;',
                                    readOnly: true,
                                    listeners: {
                                        afterrender: {
                                            fn: me.onTxtCenterCodeAfterRender,
                                            scope: me
                                        }
                                    }
                                },
                                {
                                    xtype: 'textfield',
                                    colspan: 1,
                                    itemId: 'txtCenterName',
                                    margin: '0 0 0 5',
                                    width: 350,
                                    fieldLabel: '',
                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;',
                                    readOnly: true
                                },
                                {
                                    xtype: 'label'
                                },
                                {
                                    xtype: 'textfield',
                                    colspan: 3,
                                    itemId: 'txtGroupName',
                                    width: 400,
                                    fieldLabel: 'Group Name',
                                    labelWidth: 140
                                },
                                {
                                    xtype: 'textfield',
                                    colspan: 1,
                                    itemId: 'txtFieldAssistantCode',
                                    fieldLabel: 'Field Assistant',
                                    labelWidth: 140,
                                    fieldStyle: 'background-color:#DAEBE1;background-image:none;',
                                    readOnly: true,
                                    listeners: {
                                        afterrender: {
                                            fn: me.onTxtFieldAssistantCodeAfterRender,
                                            scope: me
                                        }
                                    }
                                },
                                {
                                    xtype: 'textfield',
                                    colspan: 2,
                                    itemId: 'txtFieldAssistantName',
                                    margin: '0 0 0 5',
                                    width: 350,
                                    fieldLabel: '',
                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;',
                                    readOnly: true
                                },
                                {
                                    xtype: 'textfield',
                                    colspan: 2,
                                    itemId: 'txtGrtPerformDate',
                                    fieldLabel: 'GRT Perform Date',
                                    labelWidth: 140,
                                    emptyText: 'DD-MON-YYYY'
                                },
                                {
                                    xtype: 'textfield',
                                    colspan: 1,
                                    itemId: 'txtGrtPerformValue',
                                    margin: '0 0 0 80',
                                    fieldLabel: 'GRT Perform Value',
                                    labelWidth: 140
                                },
                                {
                                    xtype: 'textfield',
                                    colspan: 1,
                                    itemId: 'txtGrtPerformedById',
                                    fieldLabel: 'GRT Performed By',
                                    labelWidth: 140,
                                    fieldStyle: 'background-color:#DAEBE1;background-image:none;',
                                    readOnly: true,
                                    listeners: {
                                        afterrender: {
                                            fn: me.onTxtGrtPerformedByIdAfterRender,
                                            scope: me
                                        }
                                    }
                                },
                                {
                                    xtype: 'textfield',
                                    colspan: 2,
                                    itemId: 'txtGrtPerformedByName',
                                    margin: '0 0 0 5',
                                    width: 350,
                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;',
                                    readOnly: true
                                },
                                {
                                    xtype: 'textfield',
                                    colspan: 2,
                                    itemId: 'txtGroupClosedDateBs',
                                    fieldLabel: 'Group Closed Date (B.S)',
                                    labelWidth: 140,
                                    emptyText: 'DD-MON-YYYY'
                                },
                                {
                                    xtype: 'textfield',
                                    colspan: 1,
                                    itemId: 'txtGroupClosedDateAd',
                                    margin: '0 0 0 80',
                                    fieldLabel: 'Group Closed Date (A.D)',
                                    labelWidth: 140,
                                    emptyText: 'DD-MON-YYYY'
                                },
                                {
                                    xtype: 'textfield',
                                    colspan: 1,
                                    itemId: 'txtGroupLeaderCode',
                                    fieldLabel: 'Group Leader',
                                    labelWidth: 140,
                                    fieldStyle: 'background-color:#DAEBE1;background-image:none;',
                                    readOnly: true,
                                    listeners: {
                                        afterrender: {
                                            fn: me.onTxtGroupLeaderCodeAfterRender,
                                            scope: me
                                        }
                                    }
                                },
                                {
                                    xtype: 'textfield',
                                    colspan: 2,
                                    itemId: 'txtGroupLeaderName',
                                    margin: '0 0 0 5',
                                    width: 350,
                                    fieldLabel: '',
                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;',
                                    readOnly: true
                                },
                                {
                                    xtype: 'textfield',
                                    hidden: true,
                                    itemId: 'hdClientNo',
                                    fieldLabel: 'Label'
                                }
                            ]
                        },
                        {
                            xtype: 'container',
                            colspan: 3,
                            height: 30,
                            layout: {
                                type: 'hbox',
                                align: 'stretch',
                                pack: 'center'
                            },
                            items: [
                                {
                                    xtype: 'button',
                                    itemId: 'btnCreateGroup',
                                    text: 'Create Group'
                                },
                                {
                                    xtype: 'button',
                                    hidden: true,
                                    itemId: 'btnUpdateGroup',
                                    margin: '0 0 0 5',
                                    text: 'Update Group'
                                },
                                {
                                    xtype: 'button',
                                    hidden: true,
                                    itemId: 'btnDeleteGroup',
                                    margin: '0 0 0 5',
                                    text: 'Delete Group'
                                }
                            ]
                        }
                    ]
                },
                {
                    xtype: 'fieldset',
                    itemId: 'frmSearchGroup',
                    title: 'Center Details',
                    layout: {
                        type: 'table',
                        columns: 3
                    },
                    items: [
                        {
                            xtype: 'textfield',
                            colspan: 2,
                            itemId: 'txtSearchBuildDateFromBs',
                            fieldLabel: 'Build Date From (B.S)',
                            labelWidth: 130,
                            emptyText: 'DD-MON-YYYY'
                        },
                        {
                            xtype: 'textfield',
                            colspan: 1,
                            itemId: 'txtSearchBuildDateToBs',
                            margin: '0 0 0 80',
                            fieldLabel: 'Build Date To (B.S)',
                            labelWidth: 140,
                            emptyText: 'DD-MON-YYYY'
                        },
                        {
                            xtype: 'textfield',
                            colspan: 1,
                            itemId: 'txtSearchCenterDetailsCode',
                            fieldLabel: 'Center Code',
                            labelWidth: 130,
                            fieldStyle: 'background-color:#DAEBE1;background-image:none;',
                            readOnly: true,
                            listeners: {
                                afterrender: {
                                    fn: me.onTxtSearchCenterDetailsCodeAfterRender,
                                    scope: me
                                }
                            }
                        },
                        {
                            xtype: 'textfield',
                            colspan: 1,
                            itemId: 'txtSearchCenterDetailsName',
                            margin: '0 0 0 5',
                            width: 350,
                            fieldLabel: '',
                            fieldStyle: 'background-color:#D2D2D2;background-image:none;',
                            readOnly: true
                        },
                        {
                            xtype: 'label'
                        },
                        {
                            xtype: 'textfield',
                            colspan: 1,
                            itemId: 'txtSearchGroupDetailsCode',
                            fieldLabel: 'Group Code',
                            labelWidth: 130,
                            fieldStyle: 'background-color:#DAEBE1;background-image:none;',
                            readOnly: true,
                            listeners: {
                                afterrender: {
                                    fn: me.onTxtSearchGroupDetailsCodeAfterRender,
                                    scope: me
                                }
                            }
                        },
                        {
                            xtype: 'textfield',
                            colspan: 2,
                            itemId: 'txtSearchGroupDetailsName',
                            margin: '0 0 0 5',
                            width: 350,
                            fieldLabel: '',
                            fieldStyle: 'background-color:#D2D2D2;background-image:none;',
                            readOnly: true
                        },
                        {
                            xtype: 'container',
                            colspan: 3,
                            height: 30,
                            layout: {
                                type: 'hbox',
                                align: 'stretch',
                                pack: 'center'
                            },
                            items: [
                                {
                                    xtype: 'button',
                                    itemId: 'btnCenterDetailsSearch',
                                    text: 'Search'
                                }
                            ]
                        }
                    ]
                },
                {
                    xtype: 'gridpanel',
                    itemId: 'grdGroupSearch',
                    title: '',
                    store: 'GroupSearchStore',
                    columns: [
                        {
                            xtype: 'gridcolumn',
                            dataIndex: 'GroupCode',
                            text: 'Group Code'
                        },
                        {
                            xtype: 'gridcolumn',
                            dataIndex: 'GroupName',
                            text: 'Group Name'
                        },
                        {
                            xtype: 'gridcolumn',
                            dataIndex: 'CenterName',
                            text: 'Center Name'
                        },
                        {
                            xtype: 'gridcolumn',
                            dataIndex: 'GroupFormedBy',
                            text: 'Group Formed By'
                        },
                        {
                            xtype: 'gridcolumn',
                            width: 107,
                            dataIndex: 'GroupFormedDate',
                            text: 'Group Formed Date'
                        },
                        {
                            xtype: 'gridcolumn',
                            dataIndex: 'GrtPerformVal',
                            text: 'GRT Perform Value'
                        },
                        {
                            xtype: 'gridcolumn',
                            dataIndex: 'GrtPerformBy',
                            text: 'GRT Perform By'
                        },
                        {
                            xtype: 'gridcolumn',
                            dataIndex: 'GrtPerformDate',
                            text: 'GRT Perform Date'
                        },
                        {
                            xtype: 'actioncolumn',
                            items: [
                                {
                                    handler: function(view, rowIndex, colIndex, item, e, record, row) {
                                        Ext.ComponentQuery.query('#grdGroupSearch')[0].getSelectionModel().select(rowIndex);
                                        //get reference of store
                                        var store = Ext.getStore('GroupSearchStore');

                                        //get selected row using rowindex
                                        var row = store.getAt(rowIndex).data;


                                        // set values



                                        Ext.ComponentQuery.query('#txtGroupCode')[0].setValue(row.GroupCode);
                                        Ext.ComponentQuery.query('#txtGroupName')[0].setValue(row.GroupName);
                                        Ext.ComponentQuery.query('#txtGroupFormedAd')[0].setValue(row.GroupFormedDate);
                                        Ext.ComponentQuery.query('#chkActive')[0].setValue(row.ActiveFlags==='Y'?true:false);
                                        Ext.ComponentQuery.query('#txtCenterCode')[0].setValue(row.CenterCode);
                                        Ext.ComponentQuery.query('#txtCenterName')[0].setValue(row.CenterName);
                                        Ext.ComponentQuery.query('#txtFieldAssistantCode')[0].setValue(row.GroupFormedBy);
                                        Ext.ComponentQuery.query('#txtFieldAssistantName')[0].setValue(row.GroupFormedByName);
                                        Ext.ComponentQuery.query('#txtGrtPerformDate')[0].setValue(row.GrtPerformDate);
                                        Ext.ComponentQuery.query('#txtGrtPerformValue')[0].setValue(row.GrtPerformVal);
                                        Ext.ComponentQuery.query('#txtGrtPerformedById')[0].setValue(row.GrtPerformBy);
                                        Ext.ComponentQuery.query('#txtGrtPerformedByName')[0].setValue(row.GrtPerformByName);
                                        Ext.ComponentQuery.query('#txtGroupClosedDateAd')[0].setValue(row.GroupClosedDate);
                                        Ext.ComponentQuery.query('#txtGroupLeaderCode')[0].setValue(row.GrpLeaderIndicator);
                                        Ext.ComponentQuery.query('#txtGroupLeaderName')[0].setValue(row.GrpLeaderIndicatorName);


                                        //set buttons visible
                                        Ext.ComponentQuery.query('#btnUpdateGroup')[0].setVisible(true);
                                        Ext.ComponentQuery.query('#btnDeleteGroup')[0].setVisible(true);
                                        Ext.ComponentQuery.query('#btnCreateGroup')[0].setVisible(false);
                                    },
                                    icon: '../ITS/resources/images/icons/Modify.png'
                                }
                            ]
                        }
                    ],
                    selModel: Ext.create('Ext.selection.RowModel', {

                    })
                }
            ],
            listeners: {
                afterrender: {
                    fn: me.onPanelAfterRender,
                    scope: me
                }
            },
            tools: [
                {
                    xtype: 'tool',
                    cls: 'popupTool',
                    listeners: {
                        click: {
                            fn: me.onToolClick,
                            scope: me
                        }
                    }
                }
            ]
        });

        me.callParent(arguments);
    },

    onTxtCenterCodeAfterRender: function(component, eOpts) {
        component.getEl().on('dblclick', function(){
             var winPopup = Ext.create('MyApp.view.SelectGroupCenterPopup',{

                });

               // winPopup.extraParam={targetControl:"TxtCenterCode"};
                winPopup.show();
          });
    },

    onTxtFieldAssistantCodeAfterRender: function(component, eOpts) {
        component.getEl().on('dblclick', function(){
             var winPopup = Ext.create('MyApp.view.SelectGroupFieldAssistantsPopup',{

                });

                winPopup.extraParam={param:null};
                winPopup.show();
          });
    },

    onTxtGrtPerformedByIdAfterRender: function(component, eOpts) {
        component.getEl().on('dblclick', function(){
             var winPopup = Ext.create('MyApp.view.SelectGroupGrtPerformedByPopup',{

                });

                winPopup.extraParam={param:null};
                winPopup.show();
          });
    },

    onTxtGroupLeaderCodeAfterRender: function(component, eOpts) {
        component.getEl().on('dblclick', function(){
             var winPopup = Ext.create('MyApp.view.SelectGroupMemberPopup',{

                });

                winPopup.extraParam={param:null};
                winPopup.show();
          });
    },

    onTxtSearchCenterDetailsCodeAfterRender: function(component, eOpts) {
        component.getEl().on('dblclick', function(){
             var winPopup = Ext.create('MyApp.view.SelectGroupCenterDetailsPopup',{

                });

                winPopup.extraParam={param:null};
                winPopup.show();
          });
    },

    onTxtSearchGroupDetailsCodeAfterRender: function(component, eOpts) {
        component.getEl().on('dblclick', function(){
             var winPopup = Ext.create('MyApp.view.SelectGroupDetailsPopup',{

                });

                winPopup.extraParam={param:null};
                winPopup.show();
          });
    },

    onPanelAfterRender: function(component, eOpts) {
        var store=Ext.getStore('GroupSearchStore');
                            store.removeAll();
    },

    onToolClick: function(tool, e, eOpts) {
        Ext.MessageBox.confirm('Reset Form', 'Are you sure ?', function(btn){


            if(btn === 'yes'){
        Ext.ComponentQuery.query("#frmGroupEntry")[0].getForm().reset();
           }
           else
           {

           }

        });
    }

});