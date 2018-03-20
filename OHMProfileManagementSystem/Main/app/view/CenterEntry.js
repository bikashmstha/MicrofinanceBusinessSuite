/*
 * File: app/view/CenterEntry.js
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

Ext.define('MyApp.view.CenterEntry', {
    extend: 'Ext.panel.Panel',

    requires: [
        'Ext.form.Panel',
        'Ext.form.field.Checkbox',
        'Ext.form.Label',
        'Ext.form.field.ComboBox',
        'Ext.button.Button',
        'Ext.form.FieldSet',
        'Ext.grid.Panel',
        'Ext.grid.View',
        'Ext.grid.column.Action',
        'Ext.panel.Tool'
    ],

    frame: true,
    autoScroll: true,
    title: 'Center Entry',

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'form',
                    frame: true,
                    id: 'frm-CenterEntry',
                    itemId: 'frm-CenterEntry',
                    bodyPadding: 10,
                    title: '',
                    items: [
                        {
                            xtype: 'container',
                            layout: {
                                type: 'table',
                                columns: 3
                            },
                            items: [
                                {
                                    xtype: 'textfield',
                                    colspan: 2,
                                    itemId: 'txtBuildDateBS',
                                    fieldLabel: 'Build Date (B.S.)',
                                    labelWidth: 145,
                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                },
                                {
                                    xtype: 'textfield',
                                    colspan: 1,
                                    itemId: 'txtBuildDateAD',
                                    fieldLabel: '(A.D.)',
                                    labelWidth: 115,
                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                },
                                {
                                    xtype: 'textfield',
                                    colspan: 2,
                                    itemId: 'txtCenterCode',
                                    fieldLabel: 'Center Code',
                                    labelWidth: 145,
                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                },
                                {
                                    xtype: 'checkboxfield',
                                    colspan: 1,
                                    itemId: 'chkActive',
                                    fieldLabel: 'Active',
                                    boxLabel: ''
                                },
                                {
                                    xtype: 'textfield',
                                    colspan: 3,
                                    itemId: 'txtCenterName',
                                    fieldLabel: 'Center Name',
                                    labelWidth: 145
                                },
                                {
                                    xtype: 'textfield',
                                    colspan: 3,
                                    itemId: 'txtAddress',
                                    fieldLabel: 'Address',
                                    labelWidth: 145
                                },
                                {
                                    xtype: 'textfield',
                                    colspan: 1,
                                    itemId: 'txtVdcCode',
                                    fieldLabel: 'VDC Code',
                                    labelWidth: 145,
                                    fieldStyle: 'background-color:#DAEBE1;background-image:none;'
                                },
                                {
                                    xtype: 'textfield',
                                    colspan: 1,
                                    itemId: 'txtVdcDesc',
                                    margin: '0 0 0 5',
                                    width: 152,
                                    fieldLabel: '',
                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                },
                                {
                                    xtype: 'label',
                                    colspan: 1
                                },
                                {
                                    xtype: 'textfield',
                                    colspan: 1,
                                    itemId: 'txtFieldAssistantCode',
                                    fieldLabel: 'Field Assistant',
                                    labelWidth: 145,
                                    fieldStyle: 'background-color:#DAEBE1;background-image:none;'
                                },
                                {
                                    xtype: 'textfield',
                                    colspan: 2,
                                    itemId: 'txtFieldAssistantDesc',
                                    margin: '0 0 0 5',
                                    fieldLabel: '',
                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                },
                                {
                                    xtype: 'combobox',
                                    colspan: 2,
                                    itemId: 'ddlCenterType',
                                    fieldLabel: 'Center Type',
                                    labelWidth: 145,
                                    queryMode: 'local'
                                },
                                {
                                    xtype: 'textfield',
                                    colspan: 1,
                                    itemId: 'txtInstallmentInterval',
                                    fieldLabel: 'Installment Interval (Meeting Frequency)',
                                    labelWidth: 115,
                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                },
                                {
                                    xtype: 'combobox',
                                    colspan: 2,
                                    itemId: 'ddlCollectionDay',
                                    fieldLabel: 'Collection Day',
                                    labelWidth: 145,
                                    emptyText: '--- SELECT ---',
                                    queryMode: 'local'
                                },
                                {
                                    xtype: 'textfield',
                                    colspan: 1,
                                    itemId: 'txtCenterMeetingTime',
                                    fieldLabel: 'Center Meeting Time',
                                    labelWidth: 115
                                },
                                {
                                    xtype: 'textfield',
                                    colspan: 2,
                                    itemId: 'txtCenterClosedDateBS',
                                    fieldLabel: 'Center Closed Date (B.S.)',
                                    labelWidth: 145,
                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                },
                                {
                                    xtype: 'textfield',
                                    colspan: 1,
                                    itemId: 'txtCenterClosedDateAD',
                                    fieldLabel: '(A.D.)',
                                    labelWidth: 115,
                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                },
                                {
                                    xtype: 'textfield',
                                    colspan: 2,
                                    itemId: 'txtCollectionDateBS',
                                    fieldLabel: 'Collection Date (B.S.)',
                                    labelWidth: 145
                                },
                                {
                                    xtype: 'textfield',
                                    colspan: 1,
                                    itemId: 'txtCollectionDateAD',
                                    fieldLabel: '(A.D.)',
                                    labelWidth: 115,
                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                },
                                {
                                    xtype: 'textfield',
                                    colspan: 2,
                                    itemId: 'txtMandatorySavingAmt',
                                    fieldLabel: 'Mandatory Saving Amount',
                                    labelWidth: 145
                                },
                                {
                                    xtype: 'textfield',
                                    colspan: 1,
                                    itemId: 'txtCenterFundAmt',
                                    fieldLabel: 'Center Fund Amount',
                                    labelWidth: 115
                                },
                                {
                                    xtype: 'textfield',
                                    colspan: 2,
                                    itemId: 'txtCenterChief',
                                    fieldLabel: 'Center Chief',
                                    labelWidth: 145,
                                    fieldStyle: 'background-color:#DAEBE1;background-image:none;'
                                },
                                {
                                    xtype: 'combobox',
                                    colspan: 1,
                                    itemId: 'ddlCenterCategory',
                                    fieldLabel: 'Center Category',
                                    labelWidth: 115,
                                    queryMode: 'local'
                                },
                                {
                                    xtype: 'textfield',
                                    colspan: 2,
                                    itemId: 'txtChiefDateBS',
                                    fieldLabel: 'Chief Date (B.S.)',
                                    labelWidth: 145,
                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                },
                                {
                                    xtype: 'textfield',
                                    colspan: 1,
                                    itemId: 'txtChiefDateAD',
                                    fieldLabel: '(A.D.)',
                                    labelWidth: 115,
                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                },
                                {
                                    xtype: 'textfield',
                                    colspan: 1,
                                    itemId: 'txtAdjustmentAccountHeadCode',
                                    fieldLabel: 'Adjustment Account Head',
                                    labelWidth: 145,
                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                },
                                {
                                    xtype: 'textfield',
                                    colspan: 2,
                                    itemId: 'txtAdjustmentAccountHeadDesc',
                                    margin: '0 0 0 5',
                                    fieldLabel: '',
                                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                },
                                {
                                    xtype: 'textfield',
                                    colspan: 3,
                                    itemId: 'txtPhoneNo',
                                    fieldLabel: 'Phone No.',
                                    labelWidth: 145
                                },
                                {
                                    xtype: 'container',
                                    colspan: 3,
                                    items: [
                                        {
                                            xtype: 'button',
                                            itemId: 'btnCreateCenter',
                                            text: 'Create Center'
                                        },
                                        {
                                            xtype: 'button',
                                            hidden: true,
                                            itemId: 'btnUpdateCenter',
                                            margin: '0 0 0 5',
                                            text: 'Update Center'
                                        },
                                        {
                                            xtype: 'button',
                                            hidden: true,
                                            itemId: 'btnDeleteCenter',
                                            margin: '0 0 0 5 ',
                                            text: 'Delete Center'
                                        }
                                    ]
                                },
                                {
                                    xtype: 'fieldset',
                                    colspan: 3,
                                    height: 35,
                                    title: 'Center Details :',
                                    layout: {
                                        type: 'hbox',
                                        align: 'stretch',
                                        pack: 'center'
                                    },
                                    items: [
                                        {
                                            xtype: 'label',
                                            text: 'Demo Branch Office :-'
                                        },
                                        {
                                            xtype: 'label',
                                            itemId: 'lblCenterDetails',
                                            text: 'Center code'
                                        }
                                    ]
                                },
                                {
                                    xtype: 'fieldset',
                                    colspan: 3,
                                    title: 'Search :',
                                    layout: {
                                        type: 'table',
                                        columns: 3
                                    },
                                    items: [
                                        {
                                            xtype: 'textfield',
                                            colspan: 1,
                                            itemId: 'txtBuildDateFromBS',
                                            fieldLabel: 'Build Date From (B.S.)',
                                            labelWidth: 130
                                        },
                                        {
                                            xtype: 'label'
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtBuildDateToBS',
                                            margin: '0 0 0 100',
                                            fieldLabel: 'Build Date To (B.S.)',
                                            labelWidth: 130
                                        },
                                        {
                                            xtype: 'textfield',
                                            colspan: 2,
                                            itemId: 'txtSearchCenterCode',
                                            fieldLabel: 'Center Code',
                                            labelWidth: 130,
                                            fieldStyle: 'background-color:#DAEBE1;background-image:none;'
                                        },
                                        {
                                            xtype: 'textfield',
                                            colspan: 2,
                                            itemId: 'txtSearchCenterDesc',
                                            margin: '0 0 0 5',
                                            fieldLabel: '',
                                            fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                                        },
                                        {
                                            xtype: 'button',
                                            colspan: 3,
                                            itemId: 'btnSearchCenter',
                                            text: 'Search'
                                        }
                                    ]
                                }
                            ]
                        },
                        {
                            xtype: 'gridpanel',
                            itemId: 'grdSearchCenter',
                            title: '',
                            store: 'SearchCenterStore',
                            columns: [
                                {
                                    xtype: 'gridcolumn',
                                    width: 77,
                                    dataIndex: 'CenterCode',
                                    text: 'Center Code'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    width: 128,
                                    dataIndex: 'CenterName',
                                    text: 'Center Name'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    width: 58,
                                    dataIndex: 'VdcnpCode',
                                    text: 'Vdc'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'EmployeeId',
                                    text: 'Field Assistant'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    width: 75,
                                    dataIndex: 'CenterCategory',
                                    text: 'Center Type'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    width: 109,
                                    dataIndex: 'InstallmentInterval',
                                    text: 'Meeting Frequency'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    width: 81,
                                    dataIndex: 'CollectionDay',
                                    text: 'Collection Day'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'CenterCollectionTime',
                                    text: 'Collection Time'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    width: 106,
                                    dataIndex: 'FirstCollectionDate',
                                    text: 'First Collection Date'
                                },
                                {
                                    xtype: 'gridcolumn',
                                    width: 146,
                                    dataIndex: 'MandatoryCollectionAmount',
                                    text: 'Mandatory Fund Amount'
                                },
                                {
                                    xtype: 'actioncolumn',
                                    icon: '../ITS/resources/images/icons/Modify.png',
                                    items: [
                                        {
                                            handler: function(view, rowIndex, colIndex, item, e, record, row) {
                                                Ext.ComponentQuery.query('#grdSearchCenter')[0].getSelectionModel().select(rowIndex);
                                                //get reference of store
                                                var store = Ext.getStore('SearchCenterStore');

                                                //get selected row using rowindex
                                                var row = store.getAt(rowIndex).data;


                                                // set values

                                                console.log('row',row);

                                                Ext.ComponentQuery.query('#txtBuildDateAD')[0].setValue(row.CenterHouseBuiltDate);
                                                Ext.ComponentQuery.query('#txtCenterCode')[0].setValue(row.CenterCode);
                                                Ext.ComponentQuery.query('#chkActive')[0].setValue(row.ActiveFlags==='Y'?true:false);
                                                Ext.ComponentQuery.query('#txtCenterName')[0].setValue(row.CenterName);
                                                Ext.ComponentQuery.query('#txtAddress')[0].setValue(row.CenterAddress);
                                                Ext.ComponentQuery.query('#txtVdcCode')[0].setValue(row.VdcnpCode);
                                                Ext.ComponentQuery.query('#txtVdcDesc')[0].setValue(row.VdcDesc);
                                                Ext.ComponentQuery.query('#txtFieldAssistantCode')[0].setValue(row.EmployeeId);
                                                Ext.ComponentQuery.query('#txtFieldAssistantDesc')[0].setValue(row.EmployeeName);
                                                //Ext.ComponentQuery.query('#ddlCenterType')[0].setValue(row.);
                                                Ext.ComponentQuery.query('#txtInstallmentInterval')[0].setValue(row.InstallmentInterval);
                                                Ext.ComponentQuery.query('#ddlCollectionDay')[0].setValue(row.CollectionDay);
                                                Ext.ComponentQuery.query('#txtCenterMeetingTime')[0].setValue(row.CenterCollectionTime);
                                                Ext.ComponentQuery.query('#txtCenterClosedDateAD')[0].setValue(row.CenterClosedDate);
                                                Ext.ComponentQuery.query('#txtCollectionDateAD')[0].setValue(row.CenterHouseBuiltDate);
                                                Ext.ComponentQuery.query('#txtMandatorySavingAmt')[0].setValue(row.MandatoryCollectionAmount);
                                                Ext.ComponentQuery.query('#txtCenterFundAmt')[0].setValue(row.UnitFundCollectionAmt);
                                                Ext.ComponentQuery.query('#txtCenterChief')[0].setValue(row.CenterChief);
                                                Ext.ComponentQuery.query('#ddlCenterCategory')[0].setValue(row.CenterCategory);
                                                Ext.ComponentQuery.query('#txtChiefDateAD')[0].setValue(row.ChiefDate);
                                                Ext.ComponentQuery.query('#txtAdjustmentAccountHeadCode')[0].setValue(row.AdjustAccountHead);
                                                Ext.ComponentQuery.query('#txtAdjustmentAccountHeadDesc')[0].setValue(row.AdjustAccountDesc);
                                                Ext.ComponentQuery.query('#txtPhoneNo')[0].setValue(row.PhoneNo);


                                                //set buttons visible
                                                Ext.ComponentQuery.query('#btnUpdateCenter')[0].setVisible(true);
                                                Ext.ComponentQuery.query('#btnDeleteCenter')[0].setVisible(true);
                                                Ext.ComponentQuery.query('#btnCreateCenter')[0].setVisible(false);

                                            },
                                            icon: '../ITS/resources/images/icons/Modify.png'
                                        }
                                    ]
                                }
                            ]
                        }
                    ]
                }
            ],
            tools: [
                {
                    xtype: 'tool',
                    handler: function(event, toolEl, owner, tool) {
                        Ext.MessageBox.confirm('Reset Form', 'Are you sure ?', function(btn){


                            if(btn === 'yes'){
                                Ext.ComponentQuery.query("#frm-CenterEntry")[0].getForm().reset();
                            }
                            else
                            {

                            }

                        });
                    },
                    cls: 'popupTool'
                }
            ]
        });

        me.callParent(arguments);
    }

});