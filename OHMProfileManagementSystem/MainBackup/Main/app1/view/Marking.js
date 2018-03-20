/*
 * File: app/view/Marking.js
 *
 * This file was generated by Sencha Architect version 2.1.0.
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

Ext.define('MyApp.view.Marking', {
    extend: 'Ext.panel.Panel',

    frame: true,
    height: 1000,
    id: '',
    itemId: 'frm_Marking',
    autoScroll: false,
    layout: {
        align: 'stretch',
        type: 'vbox'
    },
    bodyPadding: 10,
    title: 'करदाता सम्बन्धी मार्किङ विवरण',

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'form',
                    flex: 1,
                    frame: true,
                    height: 950,
                    itemId: 'frm_Marking',
                    margin: 5,
                    autoScroll: true,
                    bodyPadding: 10,
                    items: [
                        {
                            xtype: 'label',
                            margin: '2 0 0 200',
                            style: 'font-size:20px;\r\n\r\n\r\ntext-align:center;',
                            text: 'करदाताको मार्किङ  सम्बन्धी विवरण'
                        },
                        {
                            xtype: 'container',
                            frame: true,
                            height: 40,
                            itemId: 'cntHeaderMarking',
                            margin: '10 0 0 5',
                            layout: {
                                align: 'stretch',
                                type: 'vbox'
                            },
                            items: [
                                {
                                    xtype: 'container',
                                    height: 40,
                                    layout: {
                                        align: 'stretch',
                                        type: 'hbox'
                                    },
                                    items: [
                                        {
                                            xtype: 'displayfield',
                                            flex: 1,
                                            itemId: 'Marking_IROName',
                                            width: 400,
                                            fieldLabel: 'आन्तरिक राजस्व कार्यालयको नाम',
                                            labelSeparator: ' ',
                                            labelWidth: 180
                                        },
                                        {
                                            xtype: 'displayfield',
                                            flex: 1,
                                            itemId: 'lblMarkingAction',
                                            fieldStyle: '{color:red;}',
                                            fieldLabel: ''
                                        }
                                    ]
                                }
                            ]
                        },
                        {
                            xtype: 'form',
                            frame: true,
                            height: 250,
                            margin: '0 0 5 0',
                            layout: {
                                columns: 6,
                                type: 'table'
                            },
                            bodyPadding: 10,
                            collapseFirst: false,
                            collapsible: false,
                            title: '१ करदाता सम्बन्धी विवरण',
                            titleCollapse: false,
                            items: [
                                {
                                    xtype: 'container',
                                    cls: 'extTbl',
                                    layout: {
                                        columns: 6,
                                        type: 'table'
                                    },
                                    items: [
                                        {
                                            xtype: 'textfield',
                                            colspan: 3,
                                            itemId: 'txtMarking_PanNo',
                                            margin: '5 0 0 5',
                                            fieldLabel: 'स्था . ले . नं .*',
                                            labelWidth: 80,
                                            allowBlank: false,
                                            emptyText: '',
                                            enableKeyEvents: true,
                                            enforceMaxLength: true,
                                            maskRe: /[0-9]/,
                                            maxLength: 9,
                                            minLength: 9,
                                            size: 9
                                        },
                                        {
                                            xtype: 'combobox',
                                            itemId: 'ddlMarkingActType',
                                            margin: '5 0 0 20',
                                            readOnly: false,
                                            fieldLabel: 'खाताको किसिम*',
                                            allowBlank: false,
                                            emptyText: '---छान्नुहोस्.---',
                                            displayField: 'AcctTypeDesc',
                                            forceSelection: true,
                                            queryMode: 'local',
                                            store: 'AccountType',
                                            typeAhead: true,
                                            valueField: 'AcctType'
                                        },
                                        {
                                            xtype: 'textfield',
                                            colspan: 6,
                                            itemId: 'txtMarking_Name',
                                            margin: '5 0 0 20',
                                            width: 720,
                                            readOnly: true,
                                            fieldLabel: 'नाम ',
                                            labelWidth: 40
                                        },
                                        {
                                            xtype: 'label',
                                            colspan: 1,
                                            margin: '5px 0 0 0',
                                            style: 'margin-right:45px;',
                                            text: 'ठेगाना '
                                        },
                                        {
                                            xtype: 'label',
                                            margin: '5px 0 0 0',
                                            style: 'margin-right:30px;',
                                            text: 'घर नं .'
                                        },
                                        {
                                            xtype: 'label',
                                            margin: '5px 0 0 0',
                                            style: 'margin-right:30px;',
                                            text: 'वार्ड नं .'
                                        },
                                        {
                                            xtype: 'label',
                                            margin: '5px 0 0 0',
                                            style: 'margin-right:30px;',
                                            text: 'गांउ / टोल र बाटोको नाम'
                                        },
                                        {
                                            xtype: 'radiogroup',
                                            itemId: 'Marking_VDC',
                                            margin: '5px 0 0 0',
                                            width: 200,
                                            fieldLabel: '',
                                            columns: 2,
                                            items: [
                                                {
                                                    xtype: 'radiofield',
                                                    itemId: 'rdl_Marking_Metro_Mun',
                                                    readOnly: true,
                                                    boxLabel: 'म. न. पा.'
                                                },
                                                {
                                                    xtype: 'radiofield',
                                                    itemId: 'rdl_Marking_Sub_Metro_Mun',
                                                    readOnly: true,
                                                    boxLabel: 'उ. म. न. पा.'
                                                },
                                                {
                                                    xtype: 'radiofield',
                                                    itemId: 'rdl_Marking_Mun',
                                                    readOnly: true,
                                                    boxLabel: 'न. पा.'
                                                },
                                                {
                                                    xtype: 'radiofield',
                                                    itemId: 'rdl_Marking_VDC',
                                                    readOnly: true,
                                                    boxLabel: 'गा. वि. स.'
                                                }
                                            ]
                                        },
                                        {
                                            xtype: 'label',
                                            margin: '5px 0 0 0',
                                            style: 'margin-right:50px;',
                                            text: 'जिल्ला'
                                        },
                                        {
                                            xtype: 'textfield',
                                            colspan: 2,
                                            itemId: 'txtMarking_HouseNo',
                                            margin: '5 0 0 90',
                                            width: 50,
                                            readOnly: true
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtMarking_WardNo',
                                            margin: '',
                                            width: 50,
                                            readOnly: true
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtMarking_ToleName',
                                            margin: '',
                                            width: 140,
                                            readOnly: true
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtMarking_VDCName',
                                            margin: '',
                                            width: 200,
                                            readOnly: true
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtMarking_DistrictName',
                                            margin: '',
                                            width: 100
                                        },
                                        {
                                            xtype: 'textfield',
                                            colspan: 2,
                                            itemId: 'txtMarking_Phone',
                                            margin: '5px 0 0 0',
                                            width: 150,
                                            readOnly: true,
                                            fieldLabel: 'फोन ',
                                            labelWidth: 60,
                                            enforceMaxLength: false
                                        },
                                        {
                                            xtype: 'textfield',
                                            colspan: 2,
                                            itemId: 'txtMarking_Mobile',
                                            margin: '5px 0 0 0',
                                            width: 207,
                                            readOnly: true,
                                            fieldLabel: 'मोबाइल ',
                                            labelWidth: 62
                                        },
                                        {
                                            xtype: 'textfield',
                                            colspan: 2,
                                            itemId: 'txtMarking_Email',
                                            margin: '5px 0 0 0',
                                            width: 340,
                                            readOnly: true,
                                            fieldLabel: 'इमेल ',
                                            labelWidth: 60
                                        },
                                        {
                                            xtype: 'displayfield',
                                            colspan: 6,
                                            itemId: 'txtMarking_TpOfficeType',
                                            margin: '10 0 0 0',
                                            width: 400,
                                            fieldLabel: 'करदाताको स्थिति '
                                        }
                                    ]
                                }
                            ]
                        },
                        {
                            xtype: 'form',
                            frame: true,
                            margin: '0 0 5 0',
                            layout: {
                                columns: 3,
                                type: 'table'
                            },
                            bodyPadding: 10,
                            collapseFirst: false,
                            collapsible: false,
                            frameHeader: false,
                            title: '२ करदाताको मार्किङ ',
                            titleCollapse: false,
                            items: [
                                {
                                    xtype: 'combobox',
                                    itemId: 'ddlMarkingMarkCode',
                                    margin: '0 0 0 5',
                                    readOnly: false,
                                    fieldLabel: 'मार्ककोड*',
                                    labelWidth: 80,
                                    allowBlank: false,
                                    emptyText: '---छान्नुहोस्.---',
                                    displayField: 'MarkDesc',
                                    forceSelection: true,
                                    queryMode: 'local',
                                    store: 'MarkCodes',
                                    typeAhead: true,
                                    valueField: 'MarkCode'
                                },
                                {
                                    xtype: 'textfield',
                                    itemId: 'txtMarkingStDate',
                                    margin: '0 0 0 20',
                                    fieldLabel: 'शुरुको मिति*',
                                    labelWidth: 80,
                                    allowBlank: false,
                                    emptyText: 'YYYY.MM.DD',
                                    enableKeyEvents: true,
                                    maskRe: /[0-9.]/,
                                    size: 10,
                                    listeners: {
                                        blur: {
                                            fn: me.onTxtMarkingStDateBlur,
                                            scope: me
                                        }
                                    }
                                },
                                {
                                    xtype: 'textfield',
                                    disabled: true,
                                    itemId: 'txtMarkingEndDate',
                                    margin: '0 0 0 20',
                                    fieldLabel: 'अन्तिम मिति',
                                    labelWidth: 80,
                                    emptyText: 'YYYY.MM.DD',
                                    maskRe: /[0-9.]/,
                                    size: 10,
                                    listeners: {
                                        blur: {
                                            fn: me.onTxtMarkingEndDateBlur,
                                            scope: me
                                        }
                                    }
                                },
                                {
                                    xtype: 'textareafield',
                                    itemId: 'txtMarkReason',
                                    margin: '5 0 0 5',
                                    width: 296,
                                    fieldLabel: 'मार्कगर्ने कारण*',
                                    labelWidth: 80,
                                    size: 50
                                }
                            ]
                        },
                        {
                            xtype: 'form',
                            frame: true,
                            height: 220,
                            margin: '0 0 5 0',
                            layout: {
                                align: 'stretch',
                                type: 'vbox'
                            },
                            bodyPadding: 10,
                            collapseFirst: false,
                            collapsible: false,
                            title: '३  करदाताको मार्किङ विवरण',
                            titleCollapse: false,
                            items: [
                                {
                                    xtype: 'container',
                                    flex: 1,
                                    width: 800,
                                    autoScroll: true,
                                    layout: {
                                        align: 'stretch',
                                        type: 'vbox'
                                    },
                                    items: [
                                        {
                                            xtype: 'container',
                                            height: 20,
                                            padding: '',
                                            width: 1000,
                                            layout: {
                                                align: 'stretch',
                                                padding: '',
                                                type: 'hbox'
                                            },
                                            items: [
                                                {
                                                    xtype: 'toolbar',
                                                    width: 1360,
                                                    autoScroll: false,
                                                    layout: {
                                                        align: 'stretch',
                                                        type: 'hbox'
                                                    },
                                                    items: [
                                                        {
                                                            xtype: 'tbspacer',
                                                            width: 5
                                                        },
                                                        {
                                                            xtype: 'label',
                                                            cls: 'LblCenter',
                                                            height: 13,
                                                            width: 40,
                                                            text: '१'
                                                        },
                                                        {
                                                            xtype: 'tbseparator'
                                                        },
                                                        {
                                                            xtype: 'label',
                                                            cls: 'LblCenter',
                                                            width: 100,
                                                            text: '२'
                                                        },
                                                        {
                                                            xtype: 'tbseparator'
                                                        },
                                                        {
                                                            xtype: 'label',
                                                            cls: 'LblCenter',
                                                            width: 100,
                                                            text: '३'
                                                        },
                                                        {
                                                            xtype: 'tbseparator'
                                                        },
                                                        {
                                                            xtype: 'label',
                                                            cls: 'LblCenter',
                                                            width: 100,
                                                            text: '४'
                                                        },
                                                        {
                                                            xtype: 'tbseparator'
                                                        },
                                                        {
                                                            xtype: 'label',
                                                            cls: 'LblCenter',
                                                            width: 100,
                                                            text: '५'
                                                        },
                                                        {
                                                            xtype: 'tbseparator'
                                                        },
                                                        {
                                                            xtype: 'label',
                                                            cls: 'LblCenter',
                                                            width: 100,
                                                            text: '६'
                                                        },
                                                        {
                                                            xtype: 'tbseparator'
                                                        },
                                                        {
                                                            xtype: 'label',
                                                            cls: 'LblCenter',
                                                            width: 100,
                                                            text: '७'
                                                        },
                                                        {
                                                            xtype: 'tbseparator'
                                                        },
                                                        {
                                                            xtype: 'label',
                                                            cls: 'LblCenter',
                                                            width: 100,
                                                            text: '८'
                                                        },
                                                        {
                                                            xtype: 'tbseparator'
                                                        },
                                                        {
                                                            xtype: 'label',
                                                            cls: 'LblCenter',
                                                            hidden: true,
                                                            width: 100,
                                                            text: '९'
                                                        },
                                                        {
                                                            xtype: 'tbseparator',
                                                            hidden: true
                                                        },
                                                        {
                                                            xtype: 'label',
                                                            cls: 'LblCenter',
                                                            hidden: true,
                                                            width: 50,
                                                            text: '१०'
                                                        },
                                                        {
                                                            xtype: 'tbseparator',
                                                            hidden: true
                                                        }
                                                    ]
                                                }
                                            ]
                                        },
                                        {
                                            xtype: 'gridpanel',
                                            flex: 1,
                                            itemId: 'grdMarking',
                                            width: 1000,
                                            autoScroll: false,
                                            title: '',
                                            store: 'TPMarking',
                                            dockedItems: [
                                                {
                                                    xtype: 'pagingtoolbar',
                                                    dock: 'bottom',
                                                    displayInfo: true,
                                                    store: 'TPMarking'
                                                }
                                            ],
                                            viewConfig: {
                                                height: 200
                                            },
                                            columns: [
                                                {
                                                    xtype: 'rownumberer',
                                                    width: 50,
                                                    align: 'left',
                                                    text: 'क्र.स.'
                                                },
                                                {
                                                    xtype: 'gridcolumn',
                                                    width: 100,
                                                    dataIndex: 'TPIN',
                                                    text: 'स्था . ले . नं . '
                                                },
                                                {
                                                    xtype: 'gridcolumn',
                                                    width: 100,
                                                    dataIndex: 'AcctType',
                                                    text: 'खाताको किसिम'
                                                },
                                                {
                                                    xtype: 'gridcolumn',
                                                    dataIndex: 'MarkCode',
                                                    text: 'मार्ककोड'
                                                },
                                                {
                                                    xtype: 'gridcolumn',
                                                    dataIndex: 'StartDate',
                                                    text: 'शुरुको मिति'
                                                },
                                                {
                                                    xtype: 'gridcolumn',
                                                    dataIndex: 'EndDate',
                                                    text: 'अन्तिम मिति'
                                                },
                                                {
                                                    xtype: 'gridcolumn',
                                                    dataIndex: 'MarkReason',
                                                    text: 'मार्कगर्ने कारण'
                                                },
                                                {
                                                    xtype: 'gridcolumn',
                                                    dataIndex: 'UserID',
                                                    text: 'प्रयोग कर्ता'
                                                },
                                                {
                                                    xtype: 'gridcolumn',
                                                    dataIndex: 'TranNo',
                                                    text: 'ट्रान न.'
                                                },
                                                {
                                                    xtype: 'gridcolumn',
                                                    hidden: true,
                                                    dataIndex: 'RStatus',
                                                    text: 'स्थिति '
                                                },
                                                {
                                                    xtype: 'gridcolumn',
                                                    hidden: true,
                                                    dataIndex: 'Action',
                                                    text: 'Action'
                                                }
                                            ]
                                        }
                                    ]
                                }
                            ]
                        },
                        {
                            xtype: 'container',
                            frame: true,
                            itemId: 'cntbtnMarking_button',
                            style: 'text-align:right;',
                            items: [
                                {
                                    xtype: 'button',
                                    itemId: 'btnMarking_Save',
                                    margin: '10 5',
                                    iconCls: 'icon-save',
                                    text: 'Save'
                                },
                                {
                                    xtype: 'button',
                                    itemId: 'btnMarking_Edit',
                                    margin: '10 5',
                                    iconCls: 'icon-edit',
                                    text: 'Edit'
                                },
                                {
                                    xtype: 'button',
                                    hidden: false,
                                    itemId: 'btnMarking_ShowMark',
                                    margin: '10 5',
                                    iconCls: '',
                                    text: 'Show Mark'
                                },
                                {
                                    xtype: 'button',
                                    hidden: false,
                                    itemId: 'btnMarking_submit',
                                    margin: '10 5',
                                    iconCls: 'icon-ok',
                                    text: 'Submit'
                                },
                                {
                                    xtype: 'button',
                                    itemId: 'btnMarking_Cancel',
                                    margin: '10 5',
                                    iconCls: 'icon-cancel',
                                    text: 'Cancel'
                                }
                            ]
                        },
                        {
                            xtype: 'hiddenfield',
                            itemId: 'hdnMarking_Action',
                            fieldLabel: 'Label'
                        },
                        {
                            xtype: 'hiddenfield',
                            anchor: '100%',
                            itemId: 'hdnMarkingTranNo',
                            fieldLabel: 'Label'
                        }
                    ]
                }
            ]
        });

        me.callParent(arguments);
    },

    onTxtMarkingStDateBlur: function(field, options) {
        return validateFutureDate(field.getValue(),"Y",function(){field.focus();});
    },

    onTxtMarkingEndDateBlur: function(field, options) {
        return validateFutureDate(field.getValue(),"Y",function(){field.focus();});
    }

});