/*
 * File: app/view/PublicSavingAccountOpen.js
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

Ext.define('MyApp.view.PublicSavingAccountOpen', {
    extend: 'Ext.panel.Panel',

    requires: [
        'Ext.form.Panel',
        'Ext.form.Label',
        'Ext.Img',
        'Ext.form.field.ComboBox',
        'Ext.form.field.Checkbox',
        'Ext.button.Button',
        'Ext.form.FieldSet'
    ],

    frame: true,
    title: 'Public Saving Accoun tOpen',

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'form',
                    frame: true,
                    bodyPadding: 10,
                    layout: {
                        type: 'table',
                        columns: 4
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
                                    fieldLabel: 'Account Open Date (B.S)',
                                    labelWidth: 150,
                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                },
                                {
                                    xtype: 'textfield',
                                    fieldLabel: 'Account Open Date (A.D)',
                                    labelWidth: 150,
                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                },
                                {
                                    xtype: 'textfield',
                                    colspan: 3,
                                    fieldLabel: 'Saving Account No.',
                                    labelWidth: 150,
                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                },
                                {
                                    xtype: 'textfield',
                                    colspan: 3,
                                    fieldLabel: 'Member Name',
                                    labelWidth: 150,
                                    fieldStyle: 'background-color:#DAEBE1;background-image:none;',
                                    size: 60
                                },
                                {
                                    xtype: 'textfield',
                                    fieldLabel: 'Saving Product',
                                    labelWidth: 150,
                                    fieldStyle: 'background-color:#DAEBE1;background-image:none;'
                                },
                                {
                                    xtype: 'textfield',
                                    colspan: 2,
                                    margin: '0 0 0 5',
                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;',
                                    size: 37
                                },
                                {
                                    xtype: 'textfield',
                                    fieldLabel: 'Interest Scheme',
                                    labelWidth: 150
                                },
                                {
                                    xtype: 'textfield',
                                    margin: '0 0 0 5',
                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;',
                                    size: 37
                                }
                            ]
                        },
                        {
                            xtype: 'container',
                            margin: '0 0 0 10',
                            layout: {
                                type: 'table',
                                columns: 1
                            },
                            items: [
                                {
                                    xtype: 'label',
                                    text: 'Client photo:'
                                },
                                {
                                    xtype: 'image',
                                    height: 120
                                }
                            ]
                        },
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
                                    fieldLabel: 'Fixed Collection Amt',
                                    labelWidth: 150
                                },
                                {
                                    xtype: 'combobox',
                                    margin: '0 0 0 5',
                                    fieldLabel: 'Collection Type'
                                },
                                {
                                    xtype: 'textfield',
                                    fieldLabel: 'Collection Period',
                                    labelWidth: 150
                                },
                                {
                                    xtype: 'textfield',
                                    colspan: 2,
                                    fieldLabel: 'Current Bal.',
                                    labelWidth: 150
                                },
                                {
                                    xtype: 'combobox',
                                    fieldLabel: 'Ac Status',
                                    labelWidth: 150
                                },
                                {
                                    xtype: 'textfield',
                                    colspan: 2,
                                    fieldLabel: 'Deposit Period',
                                    labelWidth: 150
                                },
                                {
                                    xtype: 'combobox',
                                    fieldLabel: 'Ac Operator',
                                    labelWidth: 150
                                },
                                {
                                    xtype: 'textfield',
                                    colspan: 2,
                                    fieldLabel: 'Maturity Date (B.S)',
                                    labelWidth: 150,
                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                },
                                {
                                    xtype: 'textfield',
                                    fieldLabel: 'Maturity Date (A.D)',
                                    labelWidth: 150,
                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                },
                                {
                                    xtype: 'textfield',
                                    colspan: 2,
                                    fieldLabel: 'Amt At Maturity',
                                    labelWidth: 150
                                },
                                {
                                    xtype: 'combobox',
                                    fieldLabel: 'Transfer Type',
                                    labelWidth: 150
                                }
                            ]
                        },
                        {
                            xtype: 'container',
                            margin: '0 0 0 10',
                            layout: {
                                type: 'table',
                                columns: 1
                            },
                            items: [
                                {
                                    xtype: 'label',
                                    text: 'Joint Client Photo'
                                },
                                {
                                    xtype: 'image',
                                    height: 120
                                }
                            ]
                        },
                        {
                            xtype: 'container',
                            colspan: 4,
                            layout: {
                                type: 'table',
                                columns: 3
                            },
                            items: [
                                {
                                    xtype: 'checkboxfield',
                                    colspan: 2,
                                    fieldLabel: 'Transfer Amt to Normal Ac',
                                    labelWidth: 150
                                },
                                {
                                    xtype: 'textfield',
                                    fieldLabel: 'Interest Rate (%)',
                                    labelWidth: 150,
                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                },
                                {
                                    xtype: 'textfield',
                                    colspan: 3,
                                    fieldLabel: 'Reference Ac No.',
                                    labelWidth: 150,
                                    fieldStyle: 'background-color:#DAEBE1;background-image:none;',
                                    size: 60
                                },
                                {
                                    xtype: 'textfield',
                                    colspan: 2,
                                    fieldLabel: 'Account Close Date (B.S)',
                                    labelWidth: 150,
                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                },
                                {
                                    xtype: 'textfield',
                                    fieldLabel: 'Account Close Date (B.S)',
                                    labelWidth: 150,
                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                },
                                {
                                    xtype: 'textfield',
                                    fieldLabel: 'Contra Ac',
                                    labelWidth: 150,
                                    fieldStyle: 'background-color:#DAEBE1;background-image:none;'
                                },
                                {
                                    xtype: 'textfield',
                                    margin: '0 0 0 5',
                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;',
                                    size: 37
                                }
                            ]
                        },
                        {
                            xtype: 'container',
                            colspan: 4,
                            height: 25,
                            layout: {
                                type: 'hbox',
                                align: 'stretch',
                                pack: 'center'
                            },
                            items: [
                                {
                                    xtype: 'button',
                                    text: 'Open Account'
                                }
                            ]
                        },
                        {
                            xtype: 'container',
                            colspan: 4,
                            height: 25,
                            margin: '10 0 0 0',
                            layout: {
                                type: 'hbox',
                                align: 'stretch',
                                pack: 'center'
                            },
                            items: [
                                {
                                    xtype: 'button',
                                    text: 'Member Info '
                                },
                                {
                                    xtype: 'button',
                                    margins: '0 10 0 10',
                                    text: 'Cheque'
                                },
                                {
                                    xtype: 'button',
                                    text: 'Signature'
                                }
                            ]
                        },
                        {
                            xtype: 'fieldset',
                            colspan: 4,
                            title: 'Search',
                            layout: {
                                type: 'table',
                                columns: 2
                            },
                            items: [
                                {
                                    xtype: 'textfield',
                                    fieldLabel: 'Account Open Date From (A.D)',
                                    labelWidth: 180
                                },
                                {
                                    xtype: 'textfield',
                                    margin: '0 0 0 10',
                                    fieldLabel: 'Account Open Date From (B.S)',
                                    labelWidth: 180
                                },
                                {
                                    xtype: 'textfield',
                                    fieldLabel: 'Saving Account No.',
                                    labelWidth: 180,
                                    fieldStyle: 'background-color:#DAEBE1;background-image:none;'
                                },
                                {
                                    xtype: 'textfield',
                                    margin: '0 0 0 10',
                                    fieldLabel: 'Member Name',
                                    labelWidth: 180,
                                    size: 40
                                },
                                {
                                    xtype: 'button',
                                    text: 'Search'
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