/*
 * File: app/view/TDSSearchUnVerRecords.js
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

Ext.define('MyApp.view.TDSSearchUnVerRecords', {
    extend: 'Ext.panel.Panel',

    frame: true,

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'form',
                    frame: true,
                    height: 101,
                    id: 'frmSUVRTDS',
                    itemId: 'frmSUVRTDS',
                    margin: '50 0 0 300',
                    width: 444,
                    bodyPadding: 10,
                    title: 'Search Un-Verified TDS Records',
                    items: [
                        {
                            xtype: 'container',
                            margin: '0 0 0 20',
                            items: [
                                {
                                    xtype: 'combobox',
                                    id: 'cboTDSSUVRIro',
                                    itemId: 'cboTDSSUVRIro',
                                    width: 360,
                                    fieldLabel: 'Select Type',
                                    allowBlank: false,
                                    emptyText: '--------Select Type---------',
                                    displayField: 'recType',
                                    queryMode: 'local',
                                    store: 'TDSUVRec',
                                    valueField: 'recID'
                                }
                            ]
                        },
                        {
                            xtype: 'container',
                            margin: '0 0 0 125',
                            items: [
                                {
                                    xtype: 'button',
                                    id: 'btnTDSSUVRSearch',
                                    itemId: 'btnTDSSUVRSearch',
                                    width: 120,
                                    text: 'Search Records'
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