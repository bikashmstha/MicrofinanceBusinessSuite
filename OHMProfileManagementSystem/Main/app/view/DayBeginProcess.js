/*
 * File: app/view/DayBeginProcess.js
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

Ext.define('MyApp.view.DayBeginProcess', {
    extend: 'Ext.panel.Panel',

    requires: [
        'Ext.form.field.Text',
        'Ext.container.Container',
        'Ext.button.Button'
    ],

    frame: true,
    title: 'Day Begin Operation',

    layout: {
        type: 'table',
        columns: 2
    },

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'textfield',
                    itemId: 'txtDateBS',
                    margin: '0 0 0 50',
                    padding: 10,
                    fieldLabel: 'Date(B.S.)',
                    labelWidth: 60,
                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                },
                {
                    xtype: 'textfield',
                    itemId: 'txtDateAD',
                    margin: '0 0 0 50',
                    fieldLabel: '(A.D.)',
                    labelWidth: 50,
                    fieldStyle: 'background-color:#D2D2D2;background-image:none;'
                },
                {
                    xtype: 'container',
                    colspan: 2,
                    height: 28,
                    layout: {
                        type: 'hbox',
                        align: 'stretch',
                        pack: 'center',
                        padding: ''
                    },
                    items: [
                        {
                            xtype: 'button',
                            itemId: 'btnDayBeginOperation',
                            text: 'Day Begin Operation',
                            listeners: {
                                click: {
                                    fn: me.onBtnDayBeginOperationClick,
                                    scope: me
                                }
                            }
                        }
                    ]
                }
            ],
            listeners: {
                afterrender: {
                    fn: me.onPanelAfterRender,
                    scope: me
                }
            }
        });

        me.callParent(arguments);
    },

    onBtnDayBeginOperationClick: function(button, e, eOpts) {
        var date=Ext.ComponentQuery.query('#txtDateBS')[0];
        var edate =Ext.ComponentQuery.query('#txtDateAD')[0];




        /*TranOfficeCode { get; set; }
                public string Date { get; set; }
                public string EDate { get; set; }
                public string OutDayBegin_Date { get; set; }
        */
        Ext.Msg.confirm('Confirm Action', 'Are You Sure to Start Day Begin Operation ?', function(btn) {
            if(btn == 'yes'){

                 var objDayBeginProcess={TranOfficeCode:getOfficeCode(),
                 Date:date.getValue(),
                 EDate:edate.getValue()};

                var wMsg='Day Begin Operation On Process....';

                var waitSave = watiMsg(wMsg);

                Ext.Ajax.request({
                            url: '../Handlers/Finance/Processing/DayBeginProcessHandler.ashx',
                            params: {
                                method:'SaveDayBeginProcess',
                                dayBeginProcess:JSON.stringify(objDayBeginProcess)
                            },
                            success: function(response){
                            waitSave.hide();
                            var out=Ext.decode(response.responseText);
                            console.log(out);

                            if(out.success==="true")
                                {
                                    var message=out.root;

                                            msg("SUCCESS",message.OutResultMessage,function(){

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

    onPanelAfterRender: function(component, eOpts) {
        Ext.ComponentQuery.query('#txtDateBS')[0].setValue(getMisDateBS());
        Ext.ComponentQuery.query('#txtDateAD')[0].setValue(getMisDateAD());
    }

});