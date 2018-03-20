/*
 * File: app/view/HolidaySetup.js
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

Ext.define('MyApp.view.HolidaySetup', {
    extend: 'Ext.panel.Panel',

    requires: [
        'Ext.form.Panel',
        'Ext.form.field.ComboBox',
        'Ext.button.Button',
        'Ext.grid.Panel',
        'Ext.grid.View',
        'Ext.grid.column.Column',
        'Ext.form.field.Checkbox',
        'Ext.grid.plugin.RowEditing'
    ],

    frame: true,
    itemId: 'frmHolidaySetup',
    title: 'Holiday Setup',

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'container',
                    items: [
                        {
                            xtype: 'form',
                            frame: true,
                            height: '',
                            width: '',
                            bodyPadding: 10,
                            title: '',
                            layout: {
                                type: 'table',
                                columns: 2
                            },
                            items: [
                                {
                                    xtype: 'combobox',
                                    colspan: 2,
                                    itemId: 'ddlFiscalYear',
                                    fieldLabel: 'Fiscal Year:',
                                    emptyText: '----Select-----',
                                    enforceMaxLength: true,
                                    editable: false,
                                    displayField: 'FiscalYearCode',
                                    queryMode: 'local',
                                    store: 'FiscalYearShortStore',
                                    valueField: 'FiscalYearCode'
                                },
                                {
                                    xtype: 'textfield',
                                    itemId: 'txtStartDate',
                                    fieldLabel: 'Start Date',
                                    readOnly: true,
                                    emptyText: 'DD-MM-YYYY'
                                },
                                {
                                    xtype: 'textfield',
                                    itemId: 'txtStartDateAD',
                                    margin: '0 0 0 50',
                                    fieldLabel: '(A.D):',
                                    readOnly: true,
                                    emptyText: 'DD-MON-YYYY'
                                },
                                {
                                    xtype: 'textfield',
                                    itemId: 'txtEndDate',
                                    fieldLabel: 'End Date:',
                                    readOnly: true,
                                    emptyText: 'DD-MM-YYYY'
                                },
                                {
                                    xtype: 'textfield',
                                    itemId: 'txtEndDateAD',
                                    margin: '0 0 0 50',
                                    fieldLabel: '(A.D)',
                                    readOnly: true,
                                    emptyText: 'DD-MON-YYYY'
                                },
                                {
                                    xtype: 'button',
                                    itemId: 'btnSearchHoliday',
                                    padding: 5,
                                    text: 'Search',
                                    listeners: {
                                        click: {
                                            fn: me.onBtnSearchHolidayClick,
                                            scope: me
                                        }
                                    }
                                }
                            ]
                        },
                        {
                            xtype: 'form',
                            frame: true,
                            bodyPadding: 10,
                            title: '',
                            items: [
                                {
                                    xtype: 'gridpanel',
                                    frame: true,
                                    itemId: 'grdHolidaySetup',
                                    autoScroll: true,
                                    title: '',
                                    store: 'HolidayStore',
                                    columns: [
                                        {
                                            xtype: 'gridcolumn',
                                            dataIndex: 'EnglishDate',
                                            text: 'English Date',
                                            editor: {
                                                xtype: 'textfield',
                                                itemId: 'txtEnglishDate'
                                            }
                                        },
                                        {
                                            xtype: 'gridcolumn',
                                            dataIndex: 'NepaliDate',
                                            text: 'Nepali Date',
                                            editor: {
                                                xtype: 'textfield',
                                                itemId: 'txtNepaliDate'
                                            }
                                        },
                                        {
                                            xtype: 'gridcolumn',
                                            dataIndex: 'IsHoliday',
                                            text: 'Holiday',
                                            editor: {
                                                xtype: 'checkboxfield',
                                                itemId: 'chkHoliday'
                                            }
                                        },
                                        {
                                            xtype: 'gridcolumn',
                                            dataIndex: 'HolidayDesc',
                                            text: 'Holiday Desc',
                                            editor: {
                                                xtype: 'textfield',
                                                itemId: 'txtHolidayDesc'
                                            }
                                        },
                                        {
                                            xtype: 'gridcolumn',
                                            dataIndex: 'LoanHoliday',
                                            text: 'Loan Holiday',
                                            editor: {
                                                xtype: 'checkboxfield',
                                                itemId: 'chkLoanHoliday'
                                            }
                                        },
                                        {
                                            xtype: 'gridcolumn',
                                            dataIndex: 'LoanHolidayDesc',
                                            text: 'Loan Holiday Description',
                                            editor: {
                                                xtype: 'textfield',
                                                itemId: 'txtLoanHolidayDesc'
                                            }
                                        },
                                        {
                                            xtype: 'gridcolumn',
                                            text: 'Action'
                                        }
                                    ],
                                    plugins: [
                                        Ext.create('Ext.grid.plugin.RowEditing', {
                                            listeners: {
                                                edit: {
                                                    fn: me.onRowEditingEdit,
                                                    scope: me
                                                },
                                                validateedit: {
                                                    fn: me.onRowEditingValidateedit,
                                                    scope: me
                                                },
                                                canceledit: {
                                                    fn: me.onRowEditingCanceledit,
                                                    scope: me
                                                }
                                            }
                                        })
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

    onBtnSearchHolidayClick: function(button, e, eOpts) {
        var holidayStore=Ext.getStore('HolidayStore');
        holidayStore.removeAll();

        var startDate=        Ext.ComponentQuery.query('#txtStartDateAD')[0].getValue();
        var endDate=        Ext.ComponentQuery.query('#txtEndDateAD')[0].getValue();

        Ext.Ajax.request
        ({

            url:'../Handlers/GeneralMasterParameters/Maintenance/HolidayHandler.ashx?method=Get',
            params:{startDate:startDate,endDate:endDate},
            success:function(response){
                var obj =Ext.decode(response.responseText);
                var row = obj.root;

                holidayStore.add(row);


            },
            failure:function()
            {
                msg('FAILURE',Ext.decode(response));

            }



        });
    },

    onRowEditingEdit: function(editor, e, eOpts) {
        /*var EnglishDate=Ext.ComponentQuery.query('#txtEnglishDate')[0];
        var NepaliDate=Ext.ComponentQuery.query('#txtNepaliDate')[0];
        var Holiday=Ext.ComponentQuery.query('#txtHoliday')[0];
        var HolidyDesc=Ext.ComponentQuery.query('#txtHolidyDesc')[0];
        var LoanHoliday=Ext.ComponentQuery.query('#txtLoanHoliday')[0];
        var LoanHolidayDesc=Ext.ComponentQuery.query('#txtLoanHolidayDesc')[0];

        var Holiday={
            EnglishDate:EnglishDate.getValue(),
            NepaliDate:NepaliDate.getValue(),
            Holiday:Holiday.getValue(),
            HolidayDesc:HolidyDesc.getValue(),
            LoanHoliday:LoanHoliday.getValue(),
            LoanHolidayDesc:LoanHolidayDesc.getValue()
        };

        Ext.Ajax.request({
                    url: '../Handlers/Maintenance/GeneralDefinitions/NarrationHandler.ashx',
                    params: {
                        method:'SaveHolidayList',
                        narration:JSON.stringify(Holiday)
                    },
                    success: function(response){

                    var out=Ext.decode(response.responseText);
                    console.log(out);



                }
                });
        */
    },

    onRowEditingValidateedit: function(editor, e, eOpts) {
                var englishDate=Ext.ComponentQuery.query('#txtEnglishDate')[0];
                var nepaliDate=Ext.ComponentQuery.query('#txtNepaliDate')[0];
                var isHoliday=Ext.ComponentQuery.query('#chkHoliday')[0];
                var holidayDesc=Ext.ComponentQuery.query('#txtHolidayDesc')[0];
                var loanHoliday=Ext.ComponentQuery.query('#chkLoanHoliday')[0];
                var loanHolidayDesc=Ext.ComponentQuery.query('#txtLoanHolidayDesc')[0];


               var wMsg='Updating....';
                var waitSave = watiMsg(wMsg);

                var holiday={
                    EnglishDate:englishDate.getValue(),
                    NepaliDate:nepaliDate.getValue(),
                    IsHoliday:isHoliday.getValue()===true?'Y':'N',
                    HolidayDesc:holidayDesc.getValue(),
                    LoanHoliday:loanHoliday.getValue()===true?'Y':'N',
                    LoanHolidayDesc:loanHolidayDesc.getValue()
                };

                Ext.Ajax.request({
                            url: '../Handlers/GeneralMasterParameters/Maintenance/HolidayHandler.ashx',
                            params: {
                                method:'Save',
                                holiday:JSON.stringify(holiday)
                            },
                            success: function(response){
                    waitSave.hide();
                    var out=Ext.decode(response.responseText);
                    console.log(out);

                    if(out.success==="true")
                        {
                            var message=out.root;
                            if(message.OutResultCode==="SUCCESS")
                                {
                                    msg("SUCCESS",message.OutResultMessage,function(){
                                        var grd = Ext.ComponentQuery.query('#grdHolidaySetup')[0];

                                        var record = grd.getSelectionModel().getSelection()[0];
                                        record.set('Action','U');

                                    });



                                }
                            else
                                {
                                  msg("FAILURE",message.OutResultMessage);
                                }
                        }
                        else
                            {
                                msg("FAILURE",out.message);
                            }
                    },
                    failure: function ( result, request ) {
                        waitSave.hide();
                        var out=Ext.decode(response.responseText);
                        msg("FAILURE",out.message);
                    }

                });

    },

    onRowEditingCanceledit: function(editor, e, eOpts) {

    }

});