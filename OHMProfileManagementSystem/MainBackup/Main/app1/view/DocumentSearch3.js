/*
 * File: app/view/DocumentSearch.js
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

Ext.define('MyApp.view.DocumentSearch', {
    extend: 'Ext.panel.Panel',

    frame: true,

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'form',
                    frame: true,
                    id: 'frmDS',
                    itemId: 'frmDS',
                    bodyPadding: 10,
                    title: 'Document Search',
                    items: [
                        {
                            xtype: 'textfield',
                            anchor: '100%',
                            id: 'txtDSPan',
                            itemId: 'txtDSPan',
                            maxWidth: 250,
                            fieldLabel: 'PAN',
                            labelWidth: 150,
                            enforceMaxLength: true,
                            maskRe: /[0-9]/,
                            maxLength: 9,
                            minLength: 9
                        },
                        {
                            xtype: 'textfield',
                            anchor: '100%',
                            id: 'txtDSDocSub',
                            itemId: 'txtDSDocSub',
                            fieldLabel: 'Document - Subject',
                            labelWidth: 150
                        },
                        {
                            xtype: 'textareafield',
                            anchor: '100%',
                            id: 'txtArDSDocKey',
                            itemId: 'txtArDSDocKey',
                            fieldLabel: 'Document Keyword',
                            labelWidth: 150
                        },
                        {
                            xtype: 'combobox',
                            anchor: '100%',
                            id: 'cboDSDocOff',
                            itemId: 'cboDSDocOff',
                            maxWidth: 350,
                            fieldLabel: 'Document Office',
                            labelWidth: 150,
                            emptyText: 'select ...',
                            enableKeyEvents: true,
                            enforceMaxLength: false,
                            displayField: 'OfficeNameEnglish',
                            store: 'Office',
                            typeAhead: true,
                            valueField: 'OfficeCode'
                        },
                        {
                            xtype: 'container',
                            height: 25,
                            layout: {
                                align: 'stretch',
                                type: 'hbox'
                            },
                            items: [
                                {
                                    xtype: 'radiofield',
                                    id: 'rdDSOpen',
                                    itemId: 'rdDSOpen',
                                    fieldLabel: 'Document Status',
                                    labelWidth: 150,
                                    boxLabel: 'Open',
                                    checked: true
                                },
                                {
                                    xtype: 'radiofield',
                                    id: 'rdDSClassify',
                                    itemId: 'rdDSClassify',
                                    margin: '0 0 0 10',
                                    boxLabel: 'Classify'
                                }
                            ]
                        },
                        {
                            xtype: 'container',
                            height: 23,
                            margin: '5 0 0 0',
                            layout: {
                                align: 'stretch',
                                type: 'hbox'
                            },
                            items: [
                                {
                                    xtype: 'label',
                                    margin: '1 0 0 0 ',
                                    text: 'Created Date:'
                                },
                                {
                                    xtype: 'textfield',
                                    validator: function(value) {
                                        var errDate = "";

                                        errDate = validateNepDate(value);

                                        return errDate === ""?true:errDate;
                                    },
                                    id: 'txtDSFrom',
                                    itemId: 'txtDSFrom',
                                    margin: '0 0 0 40',
                                    width: 150,
                                    fieldLabel: 'From',
                                    labelSeparator: ' ',
                                    labelWidth: 50,
                                    enforceMaxLength: true,
                                    maskRe: /[0-9.]/,
                                    maxLength: 10,
                                    listeners: {
                                        change: {
                                            fn: me.onTxtDSFromChange,
                                            scope: me
                                        }
                                    }
                                },
                                {
                                    xtype: 'textfield',
                                    validator: function(value) {
                                        var errDate = "";

                                        errDate = validateNepDate(value);

                                        return errDate === ""?true:errDate;
                                    },
                                    id: 'txtDSTo',
                                    itemId: 'txtDSTo',
                                    margin: '0 0 0 10',
                                    width: 150,
                                    fieldLabel: 'To',
                                    labelSeparator: ' ',
                                    labelWidth: 50,
                                    enforceMaxLength: true,
                                    maskRe: /[0-9.]/,
                                    maxLength: 10,
                                    listeners: {
                                        change: {
                                            fn: me.onTxtDSToChange,
                                            scope: me
                                        },
                                        blur: {
                                            fn: me.onTxtDSToBlur,
                                            scope: me
                                        }
                                    }
                                }
                            ]
                        },
                        {
                            xtype: 'container',
                            margin: '10 0 0 150',
                            items: [
                                {
                                    xtype: 'button',
                                    id: 'btnDSSearch',
                                    itemId: 'btnDSSearch',
                                    text: 'Search'
                                },
                                {
                                    xtype: 'button',
                                    id: 'btnDSCancel',
                                    itemId: 'btnDSCancel',
                                    text: 'Cancel'
                                }
                            ]
                        }
                    ]
                },
                {
                    xtype: 'container',
                    items: [
                        {
                            xtype: 'gridpanel',
                            height: 300,
                            id: 'grdDSDocSearch',
                            itemId: 'grdDSDocSearch',
                            autoScroll: true,
                            store: 'DocSearchStore',
                            columns: [
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'Pan',
                                    text: 'Pan'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'DocSubject',
                                    text: 'DocSubject'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'offcode',
                                    text: 'Offcode'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'DocKeyword',
                                    text: 'DocKeyword'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'DOC_ID',
                                    text: 'DOC_ID'
                                },
                                {
                                    xtype: 'actioncolumn',
                                    itemId: 'DocSearches',
                                    items: [
                                        {
                                            handler: function(view, rowIndex, colIndex, item, e, record, row) {
                                                //var DOCID=row
                                                var grd=Ext.ComponentQuery.query('#grdDSDocSearch')[0];
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
                                                var DOCID=utStore.getAt(selectedIndxT).data.DOC_ID;

                                                console.log("DOCID----",DOCID);


                                                var params={DOCID:DOCID};



                                                uiConfig = {menuLink:'DocumentRegView', pageTitle:'DocumentRegView'};
                                                DynamicUI(uiConfig,null,params);            




                                            },
                                            icon: '../ITS/resources/images/icons/eye.png',
                                            tooltip: 'View'
                                        }
                                    ]
                                },
                                {
                                    xtype: 'actioncolumn',
                                    itemId: 'phyLocView',
                                    tooltip: 'View Physical Location',
                                    items: [
                                        {
                                            handler: function(view, rowIndex, colIndex, item, e, record, row) {

                                                //var DOCID=row
                                                var grd=Ext.ComponentQuery.query('#grdDSDocSearch')[0];
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
                                                var DOCID=utStore.getAt(selectedIndxT).data.DOC_ID;
                                                var subject=utStore.getAt(selectedIndxT).data.DocSubject;

                                                console.log("subject----",subject);


                                                var params={DOCID:DOCID,DocSubject:subject};



                                                uiConfig = {menuLink:'PhyLocn', pageTitle:'Physical Location'};
                                                DynamicUI(uiConfig,null,params);            

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
    },

    onTxtDSFromChange: function(field, newValue, oldValue, eOpts) {
        field.validate();
    },

    onTxtDSToChange: function(field, newValue, oldValue, eOpts) {
        field.validate();
    },

    onTxtDSToBlur: function(component, e, eOpts) {
        var txtDSFrom=Ext.ComponentQuery.query('#txtDSFrom')[0];
        var txtDSTo=Ext.ComponentQuery.query('#txtDSTo')[0];

        if(txtDSFrom.getValue()>txtDSTo.getValue())
        {
            msg("WARNING","From-Date must be less than To-Date !!!");
            txtDSTo.focus(true);
            return;
        }
    }

});