/*
 * File: app/view/ChangeOfFilingPeriod.js
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

Ext.define('MyApp.view.ChangeOfFilingPeriod', {
    extend: 'Ext.panel.Panel',

    frame: true,
    itemId: 'pnlChangeOfFilPerCof',
    width: 800,
    autoScroll: true,
    title: 'Change of Filing Period',

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'form',
                    frame: true,
                    height: 411,
                    itemId: 'frmChangeOfFilingPeriod',
                    margin: 5,
                    maxHeight: 600,
                    autoScroll: true,
                    layout: {
                        align: 'stretch',
                        type: 'vbox'
                    },
                    bodyPadding: 10,
                    items: [
                        {
                            xtype: 'label',
                            flex: 1,
                            margin: '0 0 0 160',
                            maxHeight: 50,
                            style: 'font-size:20px',
                            text: 'Change of Filing Period'
                        },
                        {
                            xtype: 'displayfield',
                            flex: 1,
                            height: 30,
                            itemId: 'lblActionCof',
                            maxHeight: 30,
                            fieldLabel: '',
                            fieldStyle: '{color:red;}'
                        },
                        {
                            xtype: 'textfield',
                            itemId: 'txtAccTypeCof',
                            maxWidth: 200,
                            width: 200,
                            fieldLabel: 'खाताको किसिम *',
                            labelWidth: 130,
                            value: '00',
                            readOnly: true
                        },
                        {
                            xtype: 'textfield',
                            itemId: 'txtPanCof',
                            maxWidth: 250,
                            width: 250,
                            fieldLabel: 'करदाता दर्ता नम्बर *',
                            labelWidth: 130,
                            msgTarget: 'side',
                            allowBlank: false,
                            blankText: 'Please Enter PAN No.',
                            emptyText: 'Enter Pan No.',
                            enableKeyEvents: true,
                            enforceMaxLength: true,
                            maskRe: /[0-9]/,
                            maxLength: 9,
                            minLength: 9
                        },
                        {
                            xtype: 'textfield',
                            itemId: 'txtStartDateCof',
                            maxWidth: 250,
                            width: 250,
                            fieldLabel: 'शुरू मिति *',
                            labelWidth: 130,
                            msgTarget: 'side',
                            allowBlank: false,
                            emptyText: 'YYYY.MM.DD',
                            enableKeyEvents: true,
                            enforceMaxLength: false,
                            maskRe: /[0-9.]/,
                            minLength: 10,
                            selectOnFocus: true
                        },
                        {
                            xtype: 'container',
                            maxHeight: 25,
                            layout: {
                                columns: 2,
                                type: 'table'
                            },
                            items: [
                                {
                                    xtype: 'combobox',
                                    itemId: 'cboFilingPeriodCof',
                                    maxHeight: 30,
                                    maxWidth: 252,
                                    fieldLabel: 'मा / चौ / द्वै',
                                    labelWidth: 130,
                                    emptyText: 'Select ...',
                                    displayField: 'FilPeriodDesc',
                                    forceSelection: true,
                                    queryMode: 'local',
                                    valueField: 'FilPeriod'
                                },
                                {
                                    xtype: 'label',
                                    itemId: 'lblCurrFilePerCof',
                                    margin: '0 0 0 10',
                                    maxHeight: 25,
                                    style: '{color:red;}',
                                    text: ''
                                }
                            ]
                        },
                        {
                            xtype: 'container',
                            flex: 1,
                            itemId: 'cntButtonsCof',
                            margin: '5 0 0 68',
                            maxHeight: 30,
                            maxWidth: 967,
                            width: 967,
                            layout: {
                                type: 'hbox'
                            },
                            items: [
                                {
                                    xtype: 'button',
                                    itemId: 'btnSaveCof',
                                    margin: '',
                                    padding: 5,
                                    iconCls: 'icon-save',
                                    text: 'Save'
                                },
                                {
                                    xtype: 'button',
                                    margins: '0 0 0 5',
                                    itemId: 'btnEditCof',
                                    padding: 5,
                                    iconCls: 'icon-edit',
                                    text: 'Edit'
                                },
                                {
                                    xtype: 'button',
                                    margins: '0 0 0 5',
                                    itemId: 'btnDeleteCof',
                                    padding: 5,
                                    iconCls: 'icon-delete',
                                    text: 'Delete'
                                },
                                {
                                    xtype: 'button',
                                    margins: '0 0 0 5 ',
                                    itemId: 'btnSubmitCof',
                                    padding: 5,
                                    iconCls: 'icon-ok',
                                    text: 'Submit'
                                },
                                {
                                    xtype: 'button',
                                    margins: '0 0 0 5',
                                    itemId: 'btnCancelCof',
                                    padding: 5,
                                    iconCls: 'icon-cancel',
                                    text: 'Cancel'
                                },
                                {
                                    xtype: 'button',
                                    flex: 1,
                                    margins: '0 5 0 5',
                                    itemId: 'btnDeleteHisCof',
                                    maxWidth: 110,
                                    padding: 5,
                                    iconCls: 'icon-delete',
                                    text: 'Delete History'
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