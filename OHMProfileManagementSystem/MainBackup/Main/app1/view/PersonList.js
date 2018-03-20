/*
 * File: app/view/PersonList.js
 *
 * This file was generated by Sencha Architect version 3.0.4.
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

Ext.define('MyApp.view.PersonList', {
    extend: 'Ext.panel.Panel',

    requires: [
        'Ext.form.Panel',
        'Ext.form.FieldSet',
        'Ext.form.field.ComboBox'
    ],

    frame: true,
    title: 'Person\'s List',

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'form',
                    frame: true,
                    id: 'frmPersonList',
                    itemId: 'frmPersonList',
                    bodyPadding: 10,
                    items: [
                        {
                            xtype: 'container',
                            items: [
                                {
                                    xtype: 'fieldset',
                                    title: 'Search Criteria',
                                    layout: {
                                        type: 'table',
                                        columns: 3
                                    },
                                    items: [
                                        {
                                            xtype: 'combobox',
                                            colspan: 3,
                                            itemId: 'ddlCompany',
                                            fieldLabel: 'Company',
                                            store: 'CompanyStore'
                                        },
                                        {
                                            xtype: 'combobox',
                                            colspan: 3,
                                            itemId: 'ddlGroup',
                                            fieldLabel: 'Group',
                                            store: 'CompanyStore'
                                        },
                                        {
                                            xtype: 'combobox',
                                            colspan: 3,
                                            itemId: 'ddlIPOFormFillStatus',
                                            fieldLabel: 'IPO '
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtFirstName',
                                            fieldLabel: 'First Name'
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtMiddleName',
                                            margin: '0 0 0 10',
                                            fieldLabel: 'Middle Name'
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtLastName',
                                            margin: '0 0 0 10',
                                            fieldLabel: 'Last Name'
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtIPOBeginningDate',
                                            fieldLabel: 'Beginning Date',
                                            emptyText: 'YYYY.MM.DD'
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtIPOClosingDate',
                                            margin: '0 0 0 10',
                                            fieldLabel: 'Closing Date',
                                            emptyText: 'YYYY.MM.DD'
                                        }
                                    ]
                                }
                            ]
                        }
                    ],
                    listeners: {
                        afterrender: {
                            fn: me.onFrmPersonListAfterRender,
                            scope: me
                        }
                    }
                }
            ]
        });

        me.callParent(arguments);
    },

    onFrmPersonListAfterRender: function(component, eOpts) {
        var me=this;

        var today=Ext.get('nepDate').dom.innerHTML;


        var begDate=Ext.ComponentQuery.query('txtIPOBeginningDate')[0];
        var cloDate=Ext.ComponentQury.query('txtIPOClosingDate')[0];

        begDate.setValue(today);
        cloDate.setValue(today);

        me.LoadCompanies(null,today);


    }

});