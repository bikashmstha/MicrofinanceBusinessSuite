/*
 * File: app/view/Department.js
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

Ext.define('MyApp.view.Department', {
    extend: 'Ext.panel.Panel',

    requires: [
        'Ext.form.Panel',
        'Ext.grid.Panel',
        'Ext.grid.View',
        'Ext.form.field.ComboBox',
        'Ext.grid.column.Action',
        'Ext.selection.RowModel',
        'Ext.toolbar.Toolbar',
        'Ext.button.Button',
        'Ext.grid.plugin.RowEditing'
    ],

    frame: true,
    title: 'Department',

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'form',
                    frame: true,
                    itemId: 'frmDepartment',
                    bodyPadding: 10,
                    items: [
                        {
                            xtype: 'gridpanel',
                            itemId: 'grdDepartment',
                            title: 'Departments',
                            store: 'DepartmentStore',
                            columns: [
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'DeptCode',
                                    text: 'Department Code',
                                    editor: {
                                        xtype: 'textfield',
                                        itemId: 'txtDepartmentCode'
                                    }
                                },
                                {
                                    xtype: 'gridcolumn',
                                    width: 250,
                                    dataIndex: 'DeptName',
                                    text: 'Department Name',
                                    editor: {
                                        xtype: 'textfield',
                                        itemId: 'txtDepartmentName'
                                    }
                                },
                                {
                                    xtype: 'gridcolumn',
                                    width: 250,
                                    dataIndex: 'ParentDeptCode',
                                    text: 'Parent Department',
                                    editor: {
                                        xtype: 'combobox',
                                        itemId: 'ddlParentDepartment',
                                        displayField: 'DeptName',
                                        forceSelection: true,
                                        queryMode: 'local',
                                        store: 'DepartmentShortStore',
                                        valueField: 'DeptCode'
                                    }
                                },
                                {
                                    xtype: 'gridcolumn',
                                    dataIndex: 'Action',
                                    text: 'Action',
                                    editor: {
                                        xtype: 'textfield',
                                        itemId: 'txtAction'
                                    }
                                },
                                {
                                    xtype: 'actioncolumn',
                                    itemId: 'delDepartment',
                                    items: [
                                        {
                                            handler: function(view, rowIndex, colIndex, item, e, record, row) {
                                                var store = Ext.getStore('DepartmentStore');
                                                var grd =  Ext.ComponentQuery.query('#grdDepartment')[0];
                                                var row = store.getAt(rowIndex).data;

                                                Ext.Msg.confirm('Confirm Action', 'Do you want to Remove the selected Account Category ?', function(btn) {
                                                    if(btn == 'yes'){

                                                        /*
                                                        nepaliDateConversion.FiscalYear, OracleDbType.Varchar2, ParameterDirection.Input));
                                                        paramList.Add(SqlHelper.GetOraParam(":P_MONTH_CODE", nepaliDateConversion.MonthCode, OracleDbType.Int16, ParameterDirection.Input));
                                                        paramList.Add(SqlHelper.GetOraParam(":P_ENGLISH_START_DATE", nepaliDateConversion.EnglishStartDate, OracleDbType.Varchar2, ParameterDirection.Input));
                                                        paramList.Add(SqlHelper.GetOraParam(":P_NEPALI_START_DATE", nepaliDateConversion.NepaliStartDate, OracleDbType.Varchar2, ParameterDirection.Input));
                                                        paramList.Add(SqlHelper.GetOraParam(":P_ENGLISH_END_DATE", nepaliDateConversion.EnglishEndDate, OracleDbType.Varchar2, ParameterDirection.Input));
                                                        paramList.Add(SqlHelper.GetOraParam(":P_NEPALI_END_DATE", nepaliDateConversion.NepaliEndDate, OracleDbType.Varchar2, ParameterDirection.Input));
                                                        paramList.Add(SqlHelper.GetOraParam(":P_NEPALI_YEAR", nepaliDateConversion.NepaliYear, OracleDbType.Int16, ParameterDirection.Input));
                                                        paramList.Add(SqlHelper.GetOraParam(":P_NEPALI_PERIOD", nepaliDateConversion.NepaliPeriod, OracleDbType.Int16, ParameterDirection.Input));
                                                        paramList.Add(SqlHelper.GetOraParam(":P_NO_OF_DAYS_IN_MONTH", nepaliDateConversion.NoOfDays, OracleDbType.Int16, ParameterDirection.Input));
                                                        paramList.Add(SqlHelper.GetOraParam(":P_CREATED_MODIFIED_ON", nepaliDateConversion.CreatedOn, OracleDbType.Varchar2, ParameterDirection.Input));
                                                        paramList.Add(SqlHelper.GetOraParam(":P_CREATED_MODIFIED_BY", nepaliDateConversion.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                                                        paramList.Add(SqlHelper.GetOraParam(":P_INSERT_UPDATE", nepaliDateConversion.Action, OracleDbType.Varchar2, ParameterDirection.Input));
                                                        paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_CODE", null, OracleDbType.Varchar2, ParameterDirection.Output));
                                                        paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_DESC", null, OracleDbType.
                                                        */
                                                        var rec={DeptCode:row.DeptCode,
                                                                DeptName:row.DeptName,
                                                                ParentDeptCode:row.ParentDeptCode,
                                                            Action:'D'};

                                                        var wMsg='Deleting....';

                                                        var waitSave = watiMsg(wMsg);

                                                        Ext.Ajax.request({
                                                            url: '../Handlers/GeneralMasterParameters/Maintenance/DepartmentHandler.ashx',
                                                            params: {
                                                                method:'Save',
                                                                department:JSON.stringify(rec)
                                                            },
                                                            success: function(response){
                                                                waitSave.hide();
                                                                var out=Ext.decode(response.responseText);
                                                                console.log(out);

                                                                if(out.success==="true")
                                                                {
                                                                    var message=out.root;
                                                                    msg("SUCCESS",out.message,function(){
                                                                        grd.bindStore(store);
                                                                        store.removeAt(rowIndex);
                                                                    });




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



                                                        return true;
                                                    }
                                                });
                                            },
                                            icon: '../ITS/resources/images/icons/cancel.png'
                                        }
                                    ]
                                }
                            ],
                            selModel: Ext.create('Ext.selection.RowModel', {

                            }),
                            dockedItems: [
                                {
                                    xtype: 'toolbar',
                                    dock: 'top',
                                    items: [
                                        {
                                            xtype: 'button',
                                            itemId: 'btnAddDepartment',
                                            text: 'Add Department',
                                            listeners: {
                                                click: {
                                                    fn: me.onBtnAddDepartmentClick,
                                                    scope: me
                                                }
                                            }
                                        }
                                    ]
                                }
                            ],
                            plugins: [
                                Ext.create('Ext.grid.plugin.RowEditing', {
                                    listeners: {
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
                            ],
                            listeners: {
                                beforerender: {
                                    fn: me.onGrdDepartmentBeforeRender,
                                    scope: me
                                }
                            }
                        }
                    ],
                    listeners: {
                        afterrender: {
                            fn: me.onFrmDepartmentAfterRender,
                            scope: me
                        }
                    }
                }
            ]
        });

        me.callParent(arguments);
    },

    onBtnAddDepartmentClick: function(button, e, eOpts) {
        var store =Ext.getStore('DepartmentStore');
        var rec={DeptCode:'',
                 DeptName:'',
                 ParentDeptCode:'',
                 Action:'I'};
        store.add(rec);

    },

    onRowEditingValidateedit: function(editor, e, eOpts) {
        var errMsg='';
        var departmentCode=Ext.ComponentQuery.query('#txtDepartmentCode')[0];
        var departmentName=Ext.ComponentQuery.query('#txtDepartmentName')[0];
        var parentDepartment=Ext.ComponentQuery.query('#ddlParentDepartment')[0];
        var action=Ext.ComponentQuery.query('#txtAction')[0];

        if(departmentCode.getValue()===null ||departmentCode.getValue()==="")
            {
                errMsg+="Please,Enter Department Code.";
            }
        if(departmentName.getValue()===null ||departmentName.getValue()==="")
            {
                errMsg+="Please,Enter Department Name.";
            }
        /*if(parentDepartment.getValue()===null ||parentDepartment.getValue()==="")
            {
                errMsg+="Please,Select Parent Department.";
            }
        */
        if(errMsg!=='')
            {
                msg("WARNING",errMsg);
                return;
            }
        /*
        p_category_no                               IN           NUMBER,
                                         p_category_desc                             IN           VARCHAR2,
                                         p_category_initial                          IN           VARCHAR2,
                                         p_tran_office_code                          IN           VARCHAR2,       */

        var rec={DeptCode:departmentCode.getValue(),
                 DeptName:departmentName.getValue(),
                 ParentDeptCode:parentDepartment.getValue(),
                 Action:action.getValue()};



        var wMsg='';
        if(action.getValue()==='I')
            {
                wMsg='Inserting....';
            }
        else
            {
                wMsg='Updating....';
            }
        var waitSave = watiMsg(wMsg);

        Ext.Ajax.request({
                    url: '../Handlers/GeneralMasterParameters/Maintenance/DepartmentHandler.ashx',
                    params: {
                        method:'Save',
                        department:JSON.stringify(rec)
                    },
                    success: function(response){
                    waitSave.hide();
                    var out=Ext.decode(response.responseText);
                    console.log(out);

                    if(out.success==="true")
                        {
                            var message=out.root;
                                    msg("SUCCESS",out.message,function(){
                                        var grd = Ext.ComponentQuery.query('#grdDepartment')[0];

                                        var record = grd.getSelectionModel().getSelection()[0];
                                        record.set('Action','U');

                                    });




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

    },

    onGrdDepartmentBeforeRender: function(component, eOpts) {
        var grid = Ext.ComponentQuery.query('#grdDepartment')[0];

                grid.columns[2].renderer = function(value, metaData, record, rowIndex, colIndex, store, view) {
                    var temp="";


                    var items=Ext.getStore('DepartmentStore').data.items;


                    for(var i=0;i<items.length;i++)
                    {

                        if(items[i].data.DeptCode==value)
                        {
                            temp=items[i].data.DeptName;
                            break;
                        }
                    }


                    return temp;
                };
    },

    onFrmDepartmentAfterRender: function(component, eOpts) {
        var store=Ext.getStore('DepartmentShortStore');
        var departmentStore=Ext.getStore('DepartmentStore');


        var wMsg='Please, Wait....';

        var waitGet = watiMsg(wMsg);


        store.removeAll();

        Ext.Ajax.request({
            url: '../Handlers/GeneralMasterParameters/Maintenance/DepartmentHandler.ashx',
            params: {
                method:'Get'
            },
            success: function(response){
            waitGet.hide();
            var data=Ext.decode(response.responseText);
            store.removeAll();
            store.add(data.root);

                departmentStore.removeAll();
                departmentStore.add(data.root);


        }
        });

    }

});