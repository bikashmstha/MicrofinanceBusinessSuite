/*
 * File: app/view/DocumentType.js
 *
 * This file was generated by Sencha Architect version 2.2.2.
 * http://www.sencha.com/products/architect/
 *
 * This file requires use of the Ext JS 4.0.x library, under independent license.
 * License of Sencha Architect does not include license for Ext JS 4.0.x. For more
 * details see http://www.sencha.com/license or contact license@sencha.com.
 *
 * This file will be auto-generated each and everytime you save your project.
 *
 * Do NOT hand edit this file.
 */

Ext.define('MyApp.view.DocumentType', {
    extend: 'Ext.panel.Panel',

    frame: true,
    layout: {
        align: 'stretch',
        type: 'hbox'
    },
    title: 'Document',

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'panel',
                    frame: true,
                    margin: '0 5 0 0',
                    width: 200,
                    layout: {
                        type: 'fit'
                    },
                    title: 'Document  List',
                    items: [
                        {
                            xtype: 'gridpanel',
                            id: 'grdDocument',
                            itemId: 'grdDocument',
                            store: 'DocType',
                            columns: [
                                {
                                    xtype: 'gridcolumn',
                                    hidden: true,
                                    width: 190,
                                    dataIndex: 'DocTypeDescEn',
                                    text: 'DocTypeDescEn'
                                }
                            ]
                        }
                    ]
                },
                {
                    xtype: 'container',
                    flex: 1,
                    layout: {
                        align: 'stretch',
                        type: 'vbox'
                    },
                    items: [
                        {
                            xtype: 'panel',
                            flex: 7,
                            frame: true,
                            title: 'Document Fields',
                            items: [
                                {
                                    xtype: 'fieldset',
                                    height: 170,
                                    margin: '20 10 10 10',
                                    padding: '35 20 20 30',
                                    items: [
                                        {
                                            xtype: 'textfield',
                                            anchor: '100%',
                                            id: 'txtDocTypeID',
                                            itemId: 'txtDocTypeID',
                                            maxWidth: 300,
                                            fieldLabel: 'Document ID',
                                            labelWidth: 180
                                        },
                                        {
                                            xtype: 'textfield',
                                            anchor: '100%',
                                            id: 'txtDocTypeDescEn',
                                            itemId: 'txtDocTypeDescEn',
                                            fieldLabel: 'Document Desc English',
                                            labelWidth: 180
                                        },
                                        {
                                            xtype: 'textfield',
                                            anchor: '100%',
                                            id: 'txtDocTypeDescNp',
                                            itemId: 'txtDocTypeDescNp',
                                            fieldLabel: 'Document Desc Nepali',
                                            labelWidth: 180
                                        },
                                        {
                                            xtype: 'checkboxfield',
                                            anchor: '100%',
                                            id: 'chkDocStatus',
                                            itemId: 'chkDocStatus',
                                            fieldLabel: 'Status',
                                            labelWidth: 180,
                                            boxLabel: ''
                                        }
                                    ]
                                },
                                {
                                    xtype: 'fieldset',
                                    height: 30,
                                    margin: '1 10 01 10',
                                    padding: '3 0 0 150',
                                    items: [
                                        {
                                            xtype: 'button',
                                            itemId: 'btnCancel',
                                            margin: '0 0 0 10',
                                            text: 'Cancel'
                                        },
                                        {
                                            xtype: 'button',
                                            id: 'btnDocSubmit',
                                            itemId: 'btnDocSubmit',
                                            text: 'Submit'
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