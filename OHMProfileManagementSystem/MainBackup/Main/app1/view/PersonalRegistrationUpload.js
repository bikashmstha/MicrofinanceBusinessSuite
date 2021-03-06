/*
 * File: app/view/PersonalRegistrationUpload.js
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

Ext.define('MyApp.view.PersonalRegistrationUpload', {
    extend: 'Ext.window.Window',

    height: 250,
    id: 'PersonalRegistrationUpload',
    itemId: 'PersonalRegistrationUpload',
    width: 605,
    resizable: false,
    layout: {
        align: 'stretch',
        type: 'vbox'
    },
    title: 'Upload Your Document',
    modal: true,

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'form',
                    flex: 1,
                    frame: true,
                    height: 196,
                    id: 'frmPersonalRegUpload',
                    itemId: 'frmPersonalRegUpload',
                    layout: {
                        align: 'stretch',
                        type: 'vbox'
                    },
                    bodyBorder: false,
                    bodyPadding: 10,
                    frameHeader: false,
                    items: [
                        {
                            xtype: 'container',
                            flex: 1,
                            items: [
                                {
                                    xtype: 'textfield',
                                    id: 'txtIdNumber',
                                    itemId: 'txtIdNumber',
                                    fieldLabel: 'परिचय पत्र नं',
                                    labelWidth: 150,
                                    enforceMaxLength: true,
                                    maxLength: 20
                                },
                                {
                                    xtype: 'textfield',
                                    cls: 'unicode',
                                    itemId: 'txtPersonalRegDocIssueOffice',
                                    fieldLabel: 'जारी गर्ने कार्यालय',
                                    labelWidth: 150,
                                    enableKeyEvents: true,
                                    enforceMaxLength: true,
                                    maxLength: 100,
                                    listeners: {
                                        keypress: {
                                            fn: me.onTxtPersonalRegDocIssueOfficeKeypress,
                                            scope: me
                                        },
                                        keyup: {
                                            fn: me.onTxtPersonalRegDocIssueOfficeKeyup,
                                            scope: me
                                        },
                                        change: {
                                            fn: me.onTxtPersonalRegDocIssueOfficeChange,
                                            scope: me
                                        },
                                        focus: {
                                            fn: me.onTxtPersonalRegDocIssueOfficeFocus,
                                            scope: me
                                        }
                                    }
                                },
                                {
                                    xtype: 'textfield',
                                    cls: 'unicode',
                                    itemId: 'txtPersonalRegDocIssueOfficePlace',
                                    fieldLabel: 'जारी गर्ने कार्यालयको स्थान ',
                                    labelWidth: 150,
                                    enableKeyEvents: true,
                                    enforceMaxLength: true,
                                    maxLength: 100,
                                    listeners: {
                                        keypress: {
                                            fn: me.onTxtPersonalRegDocIssueOfficePlaceKeypress,
                                            scope: me
                                        },
                                        keyup: {
                                            fn: me.onTxtPersonalRegDocIssueOfficePlaceKeyup,
                                            scope: me
                                        },
                                        change: {
                                            fn: me.onTxtPersonalRegDocIssueOfficePlaceChange,
                                            scope: me
                                        },
                                        focus: {
                                            fn: me.onTxtPersonalRegDocIssueOfficePlaceFocus,
                                            scope: me
                                        }
                                    }
                                },
                                {
                                    xtype: 'textfield',
                                    itemId: 'txtPersonalRegDocIssueDate',
                                    fieldLabel: 'जारी गरेको मिति ',
                                    labelWidth: 150,
                                    emptyText: 'yyyy.mm.dd',
                                    listeners: {
                                        blur: {
                                            fn: me.onTxtPersonalRegDocIssueDateBlur,
                                            scope: me
                                        }
                                    }
                                },
                                {
                                    xtype: 'form',
                                    id: 'Pers_Reg_DocumentForm',
                                    padding: '',
                                    style: 'border:0 none;',
                                    width: 548,
                                    layout: {
                                        type: 'table'
                                    },
                                    bodyPadding: '15 0 ',
                                    bodyStyle: 'background-color:transparent;',
                                    items: [
                                        {
                                            xtype: 'textfield',
                                            id: 'Pers_Reg_DocumentTxt',
                                            itemId: 'Pers_Reg_DocumentTxt',
                                            width: 450,
                                            fieldLabel: 'कागजपत्र',
                                            labelWidth: 150,
                                            readOnly: true,
                                            maxLength: 80
                                        },
                                        {
                                            xtype: 'filefield',
                                            id: 'Pers_Reg_Document',
                                            itemId: 'Pers_Reg_Document',
                                            margin: '0 34',
                                            width: 165,
                                            buttonMargin: 46,
                                            buttonOnly: true,
                                            listeners: {
                                                change: {
                                                    fn: me.onPers_Reg_T51DocumentChange,
                                                    scope: me
                                                }
                                            }
                                        }
                                    ]
                                },
                                {
                                    xtype: 'container',
                                    height: 40,
                                    layout: {
                                        align: 'middle',
                                        pack: 'end',
                                        type: 'hbox'
                                    },
                                    items: [
                                        {
                                            xtype: 'button',
                                            id: 'btnPersonalRegOk',
                                            itemId: 'btnPersonalRegOk',
                                            padding: 5,
                                            iconCls: 'icon-save',
                                            text: 'Ok',
                                            listeners: {
                                                click: {
                                                    fn: me.onBtnPersonalRegOkClick,
                                                    scope: me
                                                }
                                            }
                                        },
                                        {
                                            xtype: 'button',
                                            id: 'btnPersonalRegCancel',
                                            itemId: 'btnPersonalRegCancel',
                                            margin: '0 5',
                                            padding: 5,
                                            iconCls: 'icon-cancel',
                                            text: 'Cancel',
                                            listeners: {
                                                click: {
                                                    fn: me.onBtnPersonalRegCancelClick,
                                                    scope: me
                                                }
                                            }
                                        }
                                    ]
                                }
                            ]
                        }
                    ],
                    listeners: {
                        afterrender: {
                            fn: me.onFrmPersonalRegUploadAfterRender,
                            scope: me
                        }
                    }
                }
            ]
        });

        me.callParent(arguments);
    },

    onTxtPersonalRegDocIssueOfficeKeypress: function(textfield, e, eOpts) {
        return unicodeKeyPress(textfield,e, eOpts);
    },

    onTxtPersonalRegDocIssueOfficeKeyup: function(textfield, e, eOpts) {

        unicodeKeyUp(textfield,e, eOpts);
    },

    onTxtPersonalRegDocIssueOfficeChange: function(field, newValue, oldValue, eOpts) {
        unicodeChange(field, newValue, oldValue, eOpts);
    },

    onTxtPersonalRegDocIssueOfficeFocus: function(component, e, eOpts) {
        unicodeFocus(component, eOpts);
    },

    onTxtPersonalRegDocIssueOfficePlaceKeypress: function(textfield, e, eOpts) {
        return unicodeKeyPress(textfield,e, eOpts);
    },

    onTxtPersonalRegDocIssueOfficePlaceKeyup: function(textfield, e, eOpts) {

        unicodeKeyUp(textfield,e, eOpts);
    },

    onTxtPersonalRegDocIssueOfficePlaceChange: function(field, newValue, oldValue, eOpts) {
        unicodeChange(field, newValue, oldValue, eOpts);
    },

    onTxtPersonalRegDocIssueOfficePlaceFocus: function(component, e, eOpts) {
        unicodeFocus(component, eOpts);
    },

    onTxtPersonalRegDocIssueDateBlur: function(component, e, eOpts) {
        validateFutureDate(component.getValue(),'Y',function(){component.focus();});
    },

    onPers_Reg_T51DocumentChange: function(filefield, value, eOpts) {
        Ext.getCmp('Pers_Reg_DocumentForm').getForm().submit({
            url: '../Handlers/Common/DocumentUploadHandler.ashx',    
            waitMsg: 'Uploading your document...',
            success: function(form,action) {

                if(action.result.success!=true)
                {
                    msg("FAILURE","Document Upload Failed");
                    return;
                }
                console.log('action',action);
                var arr=action.result.msg.split("*");
                Ext.ComponentQuery.query('#Pers_Reg_DocumentTxt')[0].fullName=action.result.msg; 
                Ext.ComponentQuery.query('#Pers_Reg_DocumentTxt')[0].setValue(arr[1]);



            },
            failure: function(form,action) {

                msg("FAILURE","Document Upload Failed");
            }
        });

    },

    onBtnPersonalRegOkClick: function(button, e, eOpts) {
        if(Ext.ComponentQuery.query('#Pers_Reg_DocumentTxt')[0].getValue())
        {

            var index=Ext.getCmp('PersonalRegistrationUpload').rwindx; 

            var store=Ext.getStore('DocType');
            record=store.getAt(index);

            record.set({IdNumber:Ext.ComponentQuery.query('#txtIdNumber')[0].getValue()});
            record.set({IdIssueAuthority:Ext.ComponentQuery.query('#txtPersonalRegDocIssueOffice')[0].getValue()});
            record.set({IdIssueDate:Ext.ComponentQuery.query('#txtPersonalRegDocIssueDate')[0].getValue()});
            record.set({IdIssuePlace:Ext.ComponentQuery.query('#txtPersonalRegDocIssueOfficePlace')[0].getValue()});
            record.set({DocName:Ext.ComponentQuery.query('#Pers_Reg_DocumentTxt')[0].getValue()});
            record.set({DocNameUnique:Ext.ComponentQuery.query('#Pers_Reg_DocumentTxt')[0].fullName});
            record.set({Action:(record.get('Action')=="E")||record.get('Action')=="D"?"E":"A"});

            this.close();
        }
        else
        {
            msg('WARNING','Document Missing.');
        }
    },

    onBtnPersonalRegCancelClick: function(button, e, eOpts) {
        Ext.ComponentQuery.query('#PersonalRegistrationUpload')[0].close();
    },

    onFrmPersonalRegUploadAfterRender: function(component, eOpts) {

        var vw=Ext.getCmp('PersonalRegistrationUpload');


        Ext.ComponentQuery.query('#txtIdNumber')[0].setValue(vw.IdNumber);

        Ext.ComponentQuery.query('#txtPersonalRegDocIssueOffice')[0].setValue(vw.IdIssueAuthority);
        Ext.ComponentQuery.query('#txtPersonalRegDocIssueDate')[0].setValue(vw.IdIssueDate);
        Ext.ComponentQuery.query('#txtPersonalRegDocIssueOfficePlace')[0].setValue(vw.IdIssuePlace);
        Ext.ComponentQuery.query('#Pers_Reg_DocumentTxt')[0].setValue(vw.DocName);
        Ext.ComponentQuery.query('#Pers_Reg_DocumentTxt')[0].fullName=vw.DocNameUnique;
        //Ext.ComponentQuery.query('#txtPersonalRegDocNo')[0].setValue(vw.IdNumber);

    }

});