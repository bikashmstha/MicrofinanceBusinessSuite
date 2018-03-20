var PersonalInfo = {
    xtype: 'fieldset',
    collapsible: true,
    defaults: { anchor: '100%' },
    layout: 'anchor',
    title: 'ब्यबसायको बिबरण',
    items:
    [
        {
                     xtype: 'panel',
                     //defaults: { anchor: '90%' },
                     width: '100%',
                     height: 120,
                     title: "ColumnLayout Panel",
                     preventHeader: true,
                     border: 0,
                     frame: true,
                     style: 'border:none;',
                     items:
                             [
                             {
                xtype:'panel',
                title: 'Table Layout',
                preventHeader: true,
                border: 0,
                frame: true,
                style: 'border:none;',
                width: '100%',
                height: 30,
                items: [
                        {
                                xtype: "textfield",
                                name: 'txtLastNamedd',
                                fieldLabel:'ब्यबसाय नम्बर',
                                labelWidth: 80,
                                width: 200,
                                allowBlank: false,
                        }
                       ]
              },
                             {
                xtype:'panel',
                title: 'Table Layout',
                preventHeader: true,
                border: 0,
                frame: true,
                style: 'border:none;',
                width: '100%',
                height: 90,
                items: [
                        {
                                xtype: 'label',
                                //forId: 'myFieldId',
                                text: 'फर्म नाम:',
                                margins: '0 0 0 10'
                        },
                        {
                                xtype: "textfield",
                                fieldLabel: 'नेपालीमा',
                                name: 'txtNepfirstName',
                                labelWidth: 50,
                                width: 550,
                                allowBlank: false,
                                // emptyText: 'Enter Your First Name...',
                               // margin: 5
                        },
                        {
                                 xtype: "textfield",
                                 fieldLabel: 'अंग्रेजीमा',
                                 name: 'txtfirstName',
                                 labelWidth: 50,
                                 width: 550,
                                 allowBlank: false,
                                 // emptyText: 'Enter Your First Name...',
                                 //margin: 5
                        }

                       ]
              }
                             ]
        }
    ]
};
var addressstores = Ext.create('Ext.data.Store', {
    storeId:'addressStore',
    fields:['name', 'email', 'phone'],
    data:{'items':[

        {"name":"Phone", "email":"4433456", "phone":"555-222-1244"},
        {"name":"Email", "email":"marge@simpsons.com", "phone":"555-222-1254"},
        {"name":"Fax", "email":"231223455", "phone":"555-111-1224"},
        {"name":"Mobile", "email":"9803353149", "phone":"555--222-1234"}

    ]},
    proxy: {
        type: 'memory',
        reader: {
            type: 'json',
            root: 'items'
        }
    }
});
var SitcStores = Ext.create('Ext.data.Store', {
    storeId:'sitcstores',
    fields:['name', 'value'],
    data:{'items':[

        {"name":"Main Category", "value":"Artist"},
        {"name":"Employement", "value":"Manager"},
        {"name":"Investment", "value":"Auditor"},
        {"name":"Occupation", "value":"Consultant"}

    ]},
    proxy: {
        type: 'memory',
        reader: {
            type: 'json',
            root: 'items'
        }
    }
});
var RelativesIntro = {
    xtype: 'fieldset',
    collapsible: true,
    defaults: { anchor: '100%' },
    layout: 'anchor',
    title: 'दर्ता बिबरणहरु',
    items:
    [
        {
            xtype: 'panel',
            title: 'Table Layout',
            width: '100%',
            //height: 160,
            preventHeader: true,
            style: 'border:none',
            border: 0,
            frame: true,
            layout: {
                type: 'table',
                // The total column count must be specified here
                columns: 3
            },
            defaults: {
                // applied to each contained panel
                bodyStyle: 'padding:0px;border:none;background-color:#DFE9F6;'
            },
            items: [
                        {
                            html: 'दर्ता मिति',
                            width: 180
                        },
                        {
                            html: 'कार्यालय स्थान',
                            width: 430
                        },
                        {
                            html: 'दर्ता नम्बर',
                            width: 225
                        },
                        {
                                    xtype: "textfield",
                                    fieldLabel: '',
                                    name: 'txtSpoucefirstNames',
                                    labelWidth: 90,
                                    width: 175,
                                    allowBlank: false
                                },
                        {
                                    xtype: "textfield",
                                    name: 'txtSpouceMiddleNames',
                                    labelWidth: 50,
                                    width: 425,
                                    allowBlank: false
                                },
                        {
                                    xtype: "textfield",
                                    name: 'txtSpouceLastNames',
                                    width: 220,
                                    allowBlank: false
                                }

            ]
        },
        {
            xtype: 'panel',
            title: 'Table Layout',
            width: '100%',
            preventHeader: true,
            style: 'border:none',
            border: 0,
            frame: true,
            layout: {
                type: 'table',
                columns: 1
            },
            defaults: {
                bodyStyle: 'padding:0px;border:none;background-color:#DFE9F6;'
            },
            items: [
                        {
                            html: 'कारोबार सुरु मिति वा सुरु हुने मिति',
                            width: 175
                        },
                        {
                                    xtype: "textfield",
                                    name: 'txtFatherfirstNames',
                                    width: 175,
                                    allowBlank: false
                                }

            ]
        }
    ]
};
var MainBusiness = {
     xtype: 'panel',
     //defaults: { anchor: '90%' },
     width: '100%',
     height: 40,
     title: "ColumnLayout Panel",
     preventHeader: true,
     border: 0,
     frame: true,
     style: 'border:none;padding-left:20px;',
     items:
    [
        {
            xtype:'checkbox',
            text:'dfs',
            fieldLabel: 'के यो तपाईको मुख्य ब्यबसाय हो',
            // emptyText:'Select District...',
            labelWidth: 160
        }
    ]
};
var SITCInfo = {
    xtype: 'tabpanel',
    width: '100%',
    height: 720,
    activeTab: 0,
    items:
    [
                        {
                             title: 'मुख्य कार्यालयको ठेगाना',
                             xtype: 'panel',
                             //defaults: { anchor: '90%' },
                             width: '100%',
                             height: 155,
                             preventHeader: true,
                             border: 0,
                             frame: true,
                             style: 'border:none',
                             layout:'column',
                             items:
                                    [
                                        {
                                             xtype: 'panel',
                                             width: '56%',
                                             title: "ColumnLayout Panel",
                                             preventHeader: true,
                                             border: 0,
                                             frame: true,
                                             style: 'border:none;',
                                             items: [
                                                        {
                                                             xtype: 'panel',
                                                             width: '100%',
                                                             height: 40,
                                                             layout: 'column',
                                                             title: "ColumnLayout Panel",
                                                             preventHeader: true,
                                                             border: 0,
                                                             frame: true,
                                                             style: 'border:none',
                                                             items: [

                                                                        {
                                                                                xtype: 'combo',
                                                                                fieldLabel: 'जिल्ला',
                                                                                // emptyText:'Select District...',
                                                                                labelWidth: 40,
                                                                                width: 300,
                                                                                allowBlank: false,
                                                                                margin: 5,
                                                                                store: new Ext.data.ArrayStore({
                                                                                    id: 0,
                                                                                    fields: ['myId', 'displayText'],
                                                                                    data: [[1, 'Jhapa'], [2, 'Ilam'], [2, 'PachThar'], [2, 'Taplejung'], [2, 'Morang'], [2, 'Dhankuta'], [2, 'Sorekhute'], [2, 'Lamhu'], [2, 'Senja'], [2, 'Bagmati']]
                                                                                }),
                                                                                valueField: 'myId',
                                                                                displayField: 'displayText'
                                                                         },
                                                                        {
                                                                            xtype: 'textfield',
                                                                            fieldLabel: 'ग.बि.स/न.पा',
                                                                            // emptyText:'Enter VDC/MUN...',
                                                                            labelWidth: 80,
                                                                            allowBlank: false,
                                                                            margin: 5
                                                                        }
                                                                    ]
                                                        },
                                                        {
                                                             xtype: 'panel',
                                                             width: '100%',
                                                             height: 40,
                                                             layout: 'column',
                                                             title: "ColumnLayout Panel",
                                                             preventHeader: true,
                                                             border: 0,
                                                             frame: true,
                                                             style: 'border:none',
                                                             items: [
                                                                        {
                                                                            xtype: 'textfield',
                                                                            fieldLabel: 'टोल',
                                                                            width: 300,
                                                                            labelWidth: 40,
                                                                            allowBlank: false,
                                                                            margin: 5
                                                                        },
                                                                        {
                                                                            xtype: 'textfield',
                                                                            fieldLabel: 'घर नम्बर',
                                                                            labelWidth: 80,
                                                                            allowBlank: false,
                                                                            // emptyText:'Enter Block Number...',
                                                                            margin: 5
                                                                        }
                                                                    ]
                                                        },
                                                        {
                                                             xtype: 'panel',
                                                             width: '100%',
                                                             height: 40,
                                                             layout: 'column',
                                                             title: "ColumnLayout Panel",
                                                             preventHeader: true,
                                                             border: 0,
                                                             frame: true,
                                                             style: 'border:none',
                                                             items: [
                                                                        {
                                                                            xtype: 'textfield',
                                                                            fieldLabel: 'वडा नम्बर',
                                                                            labelWidth: 40,
                                                                            allowBlank: false,
                                                                            //  emptyText:'Enter Ward Number...',
                                                                            margin: 5
                                                                        },
                                                                        {
                                                                            xtype: 'combo',
                                                                                fieldLabel: 'क्षेत्र',
                                                                                // emptyText:'Select District...',
                                                                                labelWidth: 40,
                                                                                width: 200,
                                                                                allowBlank: false,
                                                                                margin: 5,
                                                                                store: new Ext.data.ArrayStore({
                                                                                    id: 0,
                                                                                    fields: ['myId', 'displayText'],
                                                                                    data: [[1, 'Jhapa'], [2, 'Ilam'], [2, 'PachThar'], [2, 'Taplejung'], [2, 'Morang'], [2, 'Dhankuta'], [2, 'Sorekhute'], [2, 'Lamhu'], [2, 'Senja'], [2, 'Bagmati']]
                                                                                }),
                                                                                valueField: 'myId',
                                                                                displayField: 'displayText'
                                                                        }
                                                                    ]
                                                        }
                                                    ]
                                        },
                                        {
                                            xtype:'gridpanel',
                                            title: 'Address Book',
                                            preventHeader: true,
                                            border: 0,
                                            frame: true,
                                            style: 'border:none;',
                                            store: Ext.data.StoreManager.lookup('addressStore'),
                                            columns: [
                                                         {header: 'सम्पर्क साधन',  dataIndex: 'name',width:200},
                                                         {header: 'बिबरण', width:200,dataIndex: 'email',field:{xtype:'textfield',allowBlank:false}}
                                                    ],
                                            selType: 'cellmodel',
                                            plugins: [
                                                         Ext.create('Ext.grid.plugin.CellEditing', {
                                                         clicksToEdit: 1
                                                        })
                                                    ],
                                            height: 100,
                                            width: '43%'
                                        }
                                    ]
                        },
                        {
                            title: 'कारोबारको मुख्य स्थान',
                            xtype: 'panel',
                             //defaults: { anchor: '90%' },
                             width: '100%',
                             height: 155,
                             preventHeader: true,
                             border: 0,
                             frame: true,
                             style: 'border:none',
                             layout:'column',
                             items:
                                    [
                                        {
                                             xtype: 'panel',
                                             width: '56%',
                                             title: "ColumnLayout Panel",
                                             preventHeader: true,
                                             border: 0,
                                             frame: true,
                                             style: 'border:none;',
                                             items: [
                                                        {
                                                             xtype: 'panel',
                                                             width: '100%',
                                                             height: 40,
                                                             layout: 'column',
                                                             title: "ColumnLayout Panel",
                                                             preventHeader: true,
                                                             border: 0,
                                                             frame: true,
                                                             style: 'border:none',
                                                             items: [

                                                                        {
                                                        xtype: 'combo',
                                                        fieldLabel: 'जिल्ला',
                                                        // emptyText:'Select District...',
                                                        labelWidth: 40,
                                                        width: 300,
                                                        allowBlank: false,
                                                        margin: 5,
                                                        store: new Ext.data.ArrayStore({
                                                            id: 0,
                                                            fields: ['myId', 'displayText'],
                                                            data: [[1, 'Jhapa'], [2, 'Ilam'], [2, 'PachThar'], [2, 'Taplejung'], [2, 'Morang'], [2, 'Dhankuta'], [2, 'Sorekhute'], [2, 'Lamhu'], [2, 'Senja'], [2, 'Bagmati']]
                                                        }),
                                                        valueField: 'myId',
                                                        displayField: 'displayText'
                                                    },
                                                                        {
                                                        xtype: 'textfield',
                                                        fieldLabel: 'ग.बि.स/न.पा',
                                                        // emptyText:'Enter VDC/MUN...',
                                                        labelWidth: 80,
                                                        allowBlank: false,
                                                        margin: 5
                                                    }
                                                                    ]
                                                        },
                                                        {
                                                             xtype: 'panel',
                                                             width: '100%',
                                                             height: 40,
                                                             layout: 'column',
                                                             title: "ColumnLayout Panel",
                                                             preventHeader: true,
                                                             border: 0,
                                                             frame: true,
                                                             style: 'border:none',
                                                             items: [
                                                                        {
                                                                            xtype: 'textfield',
                                                                            fieldLabel: 'टोल',
                                                                            width: 300,
                                                                            labelWidth: 40,
                                                                            allowBlank: false,
                                                                            margin: 5
                                                                        },
                                                                        {
                                                                            xtype: 'textfield',
                                                                            fieldLabel: 'घर नम्बर',
                                                                            labelWidth: 80,
                                                                            allowBlank: false,
                                                                            // emptyText:'Enter Block Number...',
                                                                            margin: 5
                                                                        }
                                                                    ]
                                                        },
                                                        {
                                                             xtype: 'panel',
                                                             width: '100%',
                                                             height: 40,
                                                             layout: 'column',
                                                             title: "ColumnLayout Panel",
                                                             preventHeader: true,
                                                             border: 0,
                                                             frame: true,
                                                             style: 'border:none',
                                                             items: [
                                                                        {
                                                                            xtype: 'textfield',
                                                                            fieldLabel: 'वडा नम्बर',
                                                                            labelWidth: 40,
                                                                            allowBlank: false,
                                                                            //  emptyText:'Enter Ward Number...',
                                                                            margin: 5
                                                                        },
                                                                        {
                                                                            xtype: 'combo',
                                                                                fieldLabel: 'क्षेत्र',
                                                                                // emptyText:'Select District...',
                                                                                labelWidth: 40,
                                                                                width: 200,
                                                                                allowBlank: false,
                                                                                margin: 5,
                                                                                store: new Ext.data.ArrayStore({
                                                                                    id: 0,
                                                                                    fields: ['myId', 'displayText'],
                                                                                    data: [[1, 'Jhapa'], [2, 'Ilam'], [2, 'PachThar'], [2, 'Taplejung'], [2, 'Morang'], [2, 'Dhankuta'], [2, 'Sorekhute'], [2, 'Lamhu'], [2, 'Senja'], [2, 'Bagmati']]
                                                                                }),
                                                                                valueField: 'myId',
                                                                                displayField: 'displayText'
                                                                        }
                                                                    ]
                                                        }
                                                    ]
                                        },
                                        {
                                            xtype:'gridpanel',
                                            title: 'Address Book',
                                            preventHeader: true,
                                            border: 0,
                                            frame: true,
                                            style: 'border:none;',
                                            store: Ext.data.StoreManager.lookup('addressStore'),
                                            columns: [
                                                         {header: 'सम्पर्क साधन',  dataIndex: 'name',width:200},
                                                         {header: 'बिबरण', width:200,dataIndex: 'email',field:{xtype:'textfield',allowBlank:false}}
                                                    ],
                                            selType: 'cellmodel',
                                            plugins: [
                                                         Ext.create('Ext.grid.plugin.CellEditing', {
                                                         clicksToEdit: 1
                                                        })
                                                    ],
                                            height: 100,
                                            width: '43%'
                                        }
                                    ]
                        },
                        {
                            title: 'ब्यबसायिक बिबरण',
                            xtype: 'panel',
                             //defaults: { anchor: '90%' },
                             width: '100%',
                             height: 155,
                             preventHeader: true,
                             layout:'column',
                             border: 0,
                             frame: true,
                             style: 'border:none;padding:10px',
                             items:
                                    [
                                            {
                                         xtype: 'panel',
                                         //defaults: { anchor: '90%' },
                                         width: '100%',
                                         height:40,
                                         preventHeader: true,
                                         layout:'column',
                                         border: 0,
                                         frame: true,
                                         style: 'border:none;',
                                         items:[
                                                 {
                                                    xtype: 'combo',
                                                    fieldLabel: 'कुनै एउटा छान्न्नुहोस',
                                                    // emptyText:'Select District...',
                                                    labelWidth: 110,
                                                    width:380,
                                                    allowBlank: false,
                                                    margin: 5,
                                                    store: new Ext.data.ArrayStore({
                                                            id: 0,
                                                            fields: ['myId', 'displayText'],
                                                            data: [[1, 'प्रोप्राइटर']]
                                                          }),
                                                    valueField: 'myId',
                                                    displayField: 'displayText'
                                                }
                                                ]
                                            },
                                            {
                                            xtype: "combo",
                                            fieldLabel: 'ब्यबसायको प्रकार',
                                            // emptyText:'Select Main Category...',
                                            allowBlank: false,
                                            labelWidth: 115,
                                            width: 380,
                                            margin: 5,
                                            store: new Ext.data.ArrayStore({
                                                id: 0,
                                                fields: ['myId', 'displayText'],
                                                data: [[1, 'Main Category'], [2, 'Employement'], [3, 'Investement'], [4, 'Occupation'], [5, 'Others']]
                                            }),
                                            valueField: 'myId',
                                            displayField: 'displayText'
                                        },
                                            {
                                            xtype: "combo",
                                            fieldLabel: 'ब्यबसायको उप्प्रकर',
                                            // emptyText:'Select Sub Category...',
                                            labelWidth: 110,
                                            width: 360,
                                            margin: 5,
                                            allowBlank: false,
                                            store: new Ext.data.ArrayStore({
                                                id: 0,
                                                fields: ['myId', 'displayText'],
                                                data: [[1, 'Artist'], [2, 'Auditing'], [3, 'Consultant'], [4, 'Corporation'], [5, 'Finincial'], [6, 'Government'], [7, 'Enginearing'], [8, 'House Rent'], [9, 'journalism']]
                                            }),
                                            valueField: 'myId',
                                            displayField: 'displayText'
                                        },
                                            {
                                            xtype:'button',
                                            text:'Add',
                                            margin:5,
                                            width:100,
                                            handler: function() {
                                                                alert('dsf');
                                                             }
                                        },
                                            {
                                            xtype:'gridpanel',
                                            title: 'Address Book',
                                            preventHeader: true,
                                            border: 0,
                                            frame: true,
                                            style: 'border:none',
                                            store: Ext.data.StoreManager.lookup('sitcstores'),
                                            columns: [
                                                         {header: 'ब्यबसायको प्रकार',  dataIndex: 'name',width:300},
                                                         {header: 'ब्यबसायको उपप्रकार',dataIndex: 'value', width:500}
                                                    ],
                                            selType: 'cellmodel',
                                            plugins: [
                                                         Ext.create('Ext.grid.plugin.CellEditing', {
                                                         clicksToEdit: 1
                                                        })
                                                    ],
                                            height: 300,
                                            width: '100%'
                                        }

                                    ]
                        },
                        {
                            title: 'घरधनीको बिबरण',
                            xtype: 'panel',
                             //defaults: { anchor: '90%' },
                             width: '78%',
                             height: 155,
                             preventHeader: true,
                             layout:'column',
                             border: 0,
                             frame: true,
                             style: 'border:none;padding:10px',
                             items:
                                    [
                                         {
                                           xtype: 'textfield',
                                           fieldLabel: 'घरधनीको PAN No (यदि भएमा)',
                                           // emptyText:'Enter VDC/MUN...',
                                           labelWidth: 170,
                                           allowBlank: false,
                                           margin: 5
                                        },
                                         {
                                           xtype: 'textfield',
                                           fieldLabel: 'घरधनीको नाम',
                                           // emptyText:'Enter VDC/MUN...',
                                           labelWidth: 80,
                                           allowBlank: false,
                                           margin: 5
                                        },
                                         {
                                           xtype: 'textfield',
                                           fieldLabel: 'कोठाको क्षेत्रफल:(लम्बाई*चौडाई)',
                                           // emptyText:'Enter VDC/MUN...',
                                           labelWidth: 180,
                                           allowBlank: false,
                                           margin: 5
                                        },
                                         {
                                           xtype: 'textfield',
                                           fieldLabel: 'कित नम्बर',
                                           // emptyText:'Enter VDC/MUN...',
                                           labelWidth: 170,
                                           allowBlank: false,
                                           margin: 5
                                        },
                                         {
                                           xtype: 'textfield',
                                           fieldLabel: 'घर भाडा',
                                           // emptyText:'Enter VDC/MUN...',
                                           labelWidth: 80,
                                           allowBlank: false,
                                           margin: 5
                                        },
                                         {
                                           xtype: 'textfield',
                                           fieldLabel: 'भाडामा लिएको मिति',
                                           // emptyText:'Enter VDC/MUN...',
                                           labelWidth: 180,
                                           allowBlank: false,
                                           margin: 5
                                        },
                                        {
                                            title: 'कारोबारको मुख्य स्थान',
                                            xtype: 'panel',
                                             //defaults: { anchor: '90%' },
                                             width: '100%',
                                             height: 130,
                                             preventHeader: true,
                                             frame: true,
                                             style: 'border:none;',
                                             layout:'column',
                                             items:
                                                    [
                                                        {
                                             xtype: 'panel',
                                             width: '57%',
                                             title: "ColumnLayout Panel",
                                             preventHeader: true,
                                             border: 0,
                                             frame: true,
                                             style: 'border:none;',
                                             items: [
                                                        {
                                                             xtype: 'panel',
                                                             width: '100%',
                                                             height: 40,
                                                             layout: 'column',
                                                             title: "ColumnLayout Panel",
                                                             preventHeader: true,
                                                             border: 0,
                                                             frame: true,
                                                             style: 'border:none',
                                                             items: [

                                                                        {
                                                        xtype: 'combo',
                                                        fieldLabel: 'जिल्ला',
                                                        // emptyText:'Select District...',
                                                        labelWidth: 40,
                                                        width: 300,
                                                        allowBlank: false,
                                                        margin: 5,
                                                        store: new Ext.data.ArrayStore({
                                                            id: 0,
                                                            fields: ['myId', 'displayText'],
                                                            data: [[1, 'Jhapa'], [2, 'Ilam'], [2, 'PachThar'], [2, 'Taplejung'], [2, 'Morang'], [2, 'Dhankuta'], [2, 'Sorekhute'], [2, 'Lamhu'], [2, 'Senja'], [2, 'Bagmati']]
                                                        }),
                                                        valueField: 'myId',
                                                        displayField: 'displayText'
                                                    },
                                                                        {
                                                        xtype: 'textfield',
                                                        fieldLabel: 'ग.बि.स/न.पा',
                                                        // emptyText:'Enter VDC/MUN...',
                                                        labelWidth: 80,
                                                        allowBlank: false,
                                                        margin: 5
                                                    }
                                                                    ]
                                                        },
                                                        {
                                                             xtype: 'panel',
                                                             width: '100%',
                                                             height: 40,
                                                             layout: 'column',
                                                             title: "ColumnLayout Panel",
                                                             preventHeader: true,
                                                             border: 0,
                                                             frame: true,
                                                             style: 'border:none',
                                                             items: [
                                                                        {
                                                                            xtype: 'textfield',
                                                                            fieldLabel: 'टोल',
                                                                            width: 300,
                                                                            labelWidth: 40,
                                                                            allowBlank: false,
                                                                            margin: 5
                                                                        },
                                                                        {
                                                                            xtype: 'textfield',
                                                                            fieldLabel: 'घर नम्बर',
                                                                            labelWidth: 80,
                                                                            allowBlank: false,
                                                                            // emptyText:'Enter Block Number...',
                                                                            margin: 5
                                                                        }
                                                                    ]
                                                        },
                                                        {
                                                             xtype: 'panel',
                                                             width: '100%',
                                                             height: 40,
                                                             layout: 'column',
                                                             title: "ColumnLayout Panel",
                                                             preventHeader: true,
                                                             border: 0,
                                                             frame: true,
                                                             style: 'border:none',
                                                             items: [
                                                                        {
                                                                            xtype: 'textfield',
                                                                            fieldLabel: 'वडा नम्बर',
                                                                            labelWidth: 40,
                                                                            allowBlank: false,
                                                                            //  emptyText:'Enter Ward Number...',
                                                                            margin: 5
                                                                        },
                                                                        {
                                                                            xtype: 'combo',
                                                                                fieldLabel: 'क्षेत्र',
                                                                                // emptyText:'Select District...',
                                                                                labelWidth: 40,
                                                                                width: 200,
                                                                                allowBlank: false,
                                                                                margin: 5,
                                                                                store: new Ext.data.ArrayStore({
                                                                                    id: 0,
                                                                                    fields: ['myId', 'displayText'],
                                                                                    data: [[1, 'Jhapa'], [2, 'Ilam'], [2, 'PachThar'], [2, 'Taplejung'], [2, 'Morang'], [2, 'Dhankuta'], [2, 'Sorekhute'], [2, 'Lamhu'], [2, 'Senja'], [2, 'Bagmati']]
                                                                                }),
                                                                                valueField: 'myId',
                                                                                displayField: 'displayText'
                                                                        }
                                                                    ]
                                                        }
                                                    ]
                                        },
                                                        {
                                            xtype:'gridpanel',
                                            title: 'Address Book',
                                            preventHeader: true,
                                            border: 0,
                                            frame: true,
                                            style: 'border:none;',
                                            store: Ext.data.StoreManager.lookup('addressStore'),
                                            columns: [
                                                         {header: 'सम्पर्क साधन',  dataIndex: 'name',width:200},
                                                         {header: 'बिबरण', width:200,dataIndex: 'email',field:{xtype:'textfield',allowBlank:false}}
                                                    ],
                                            selType: 'cellmodel',
                                            plugins: [
                                                         Ext.create('Ext.grid.plugin.CellEditing', {
                                                         clicksToEdit: 1
                                                        })
                                                    ],
                                            height: 100,
                                            width: '42%'
                                        }
                                                    ]
                                        }
                                    ]
                        },
                        {
                            title: 'ब्यबसायिकको व्यक्तिको बिबरण',
                            xtype: 'panel',
                             //defaults: { anchor: '90%' },
                             width: '78%',
                             height: 720,
                             preventHeader: true,
                             layout:'column',
                             border: 0,
                             frame: true,
                             //autoScroll: true,
                             style: 'border:none;padding:3px',
                             items:
                                    [
                                    {
                                             title: 'प्रबन्ध निर्देशन प्रमुख्कर्यकारी अधिकृत',
                                             xtype: 'fieldset',
                                             collapsible: true,
                                             width:'100%',
                                             height: 335,
                                             //preventHeader: true,
                                             //frame: true,
                                             style: 'padding:4px;',
                                             layout:'column',
                                             items:[
                                                     {
                                            xtype:'panel',
                                            title: 'Table Layout',
                                            preventHeader: true,
                                            border: 0,
                                            frame: true,
                                            style: 'border:none',
                                            width: '100%',
                                            height: 80,
                                            layout: {
                    type: 'table',
                    // The total column count must be specified here
                    columns: 3
                },
                                            defaults: {
                    // applied to each contained panel
                    bodyStyle: 'padding:0px;border:none;background-color:#DFE9F6'
                },
                                            items: [
                                                                {
                            html: '<div >नाम<label style=margin-left:40px;>पहिलो</label</div>',
                            width:270
                        },
                                                                {
                            html: 'दोस्रो',
                            width:205
                        },
                                                                {
                            html: 'थर',
                            width:200
                        },
                                                                {
                                xtype: "textfield",
                                fieldLabel: 'नेपालीमा',
                                name: 'txtNepfirstName',
                                labelWidth: 50,
                                width: 265,
                                allowBlank: false,
                                // emptyText: 'Enter Your First Name...',
                               // margin: 5
                        },
                                                                {
                               xtype: "textfield",
                                name: 'txtNepMiddleName',
                                //fieldLabel: 'दोस्रो',
                                //labelWidth: 50,
                                width: 200,
                                allowBlank: false,
                                // emptyText: 'Enter Your Middle Name...',
                                //margin: 5
                        },
                                                                {
                                xtype: "textfield",
                                name: 'txtNepLastName',
                                //fieldLabel: 'थर',
                                width: 200,
                                allowBlank: false,
                                //labelWidth: 50,
                                // emptyText: 'Enter Your Last Name...',
                                //margin: 5
                        },
                                                                {
                                 xtype: "textfield",
                                 fieldLabel: 'अंग्रेजीमा',
                                 name: 'txtfirstName',
                                 labelWidth: 50,
                                 width: 265,
                                 allowBlank: false,
                                 // emptyText: 'Enter Your First Name...',
                                 //margin: 5
                        },
                                                                {
                                xtype: "textfield",
                                name: 'txtMiddleName',
                                //fieldLabel: 'Middle',
                                //labelWidth: 50,
                                width: 200,
                                allowBlank: false,
                                // emptyText: 'Enter Your Middle Name...',
                                //margin: 5
                        },
                                                                {
                                xtype: "textfield",
                                name: 'txtLastName',
                                //fieldLabel: 'Last',
                                //labelWidth: 50,
                                width: 200,
                                allowBlank: false,
                                // emptyText: 'Enter Your Last Name...',
                               // margin: 5
                        }
                                                ]
                                          },
                                                     {
                                           xtype: 'textfield',
                                           fieldLabel: 'नियुक्ति मिति (YYYY.MM.DD)',
                                           // emptyText:'Enter VDC/MUN...',
                                           labelWidth: 170,
                                           allowBlank: false,
                                           margin: 5
                                        },
                                                     {
                                                xtype: "combo",
                                                id: 'idnationality',
                                                fieldLabel:'रास्ट्रियता',
                                                width: 300,
                                                allowBlank: false,
                                                margin:5,
                                                store: new Ext.data.ArrayStore({
                                                    id: 0,
                                                    fields: ['myId', 'displayText'],
                                                    data: [[1, 'Nepali'], [2, 'Japaneas'], [3, 'Indian']]
                                                }),
                                                valueField: 'myId',
                                                displayField: 'displayText'
                                        },
                                                     {
                                            xtype:'panel',
                                            title: 'Table Layout',
                                            preventHeader: true,
                                            border: 0,
                                            frame: true,
                                            style: 'border:none',
                                            width: '100%',
                                            height: 60,
                                            layout: {
                                                    type: 'table',
                                                    columns: 4
                                                    },
                                            defaults: {
                                                    bodyStyle: 'padding:0px;border:none;background-color:#DFE9F6'
                                                    },
                                            items: [
                                                     {
                                                        html: 'कागजको प्रकार:',
                                                        width:220
                                                     },
                                                     {
                                                        html: 'परिचय पत्र नं:',
                                                        width:220
                                                     },
                                                     {
                                                        html: 'जरिगारने कार्यालय तथा स्थान:',
                                                        width:220
                                                     },
                                                     {
                                                        html: 'जारीगरेको मिति:',
                                                        width:220
                                                     },
                                                     {
                                                        xtype: "combo",
                                                        //id: 'idnationality',
                                                        width: 215,
                                                        allowBlank: false,
                                                        store: new Ext.data.ArrayStore({
                                                            id: 0,
                                                            fields: ['myId', 'displayText'],
                                                            data: [[1, 'Nepali'], [2, 'Japaneas'], [3, 'Indian']]
                                                        }),
                                                        valueField: 'myId',
                                                        displayField: 'displayText'
                                                     },
                                                     {
                                                        xtype: "textfield",
                                                        labelWidth: 90,
                                                        width: 215,
                                                        allowBlank: false
                                                     },
                                                     {
                                                        xtype: "textfield",
                                                        labelWidth: 90,
                                                        width: 215,
                                                        allowBlank: false
                                                     },
                                                     {
                                                        xtype: "datefield",
                                                        minLength: 10,
                                                        maxLength: 10,
                                                        width: 215,
                                                        allowBlank: false
                                                     }

                                                ]
                                          },
                                                     {
                                            title: 'प्रबन्ध निर्देशन प्रमुख्कर्यकारी अधिकृत को ठेगाना',
                                             xtype: 'fieldset',
                                             collapsible: true,
                                             width:'100%',
                                             height: 135,
                                             //preventHeader: true,
                                             //frame: true,
                                             style: 'padding:1px;',
                                             layout:'column',
                                             items:
                                                    [
                                                        {
                                             xtype: 'panel',
                                             width: '57%',
                                             title: "ColumnLayout Panel",
                                             preventHeader: true,
                                             border: 0,
                                             frame: true,
                                             style: 'border:none;',
                                             items: [
                                                        {
                                                             xtype: 'panel',
                                                             width: '100%',
                                                             height: 35,
                                                             layout: 'column',
                                                             title: "ColumnLayout Panel",
                                                             preventHeader: true,
                                                             border: 0,
                                                             frame: true,
                                                             style: 'border:none;padding:0px;',
                                                             items: [

                                                                        {
                                                        xtype: 'combo',
                                                        fieldLabel: 'जिल्ला',
                                                        // emptyText:'Select District...',
                                                        labelWidth: 40,
                                                        width: 300,
                                                        allowBlank: false,
                                                        margin: 5,
                                                        store: new Ext.data.ArrayStore({
                                                            id: 0,
                                                            fields: ['myId', 'displayText'],
                                                            data: [[1, 'Jhapa'], [2, 'Ilam'], [2, 'PachThar'], [2, 'Taplejung'], [2, 'Morang'], [2, 'Dhankuta'], [2, 'Sorekhute'], [2, 'Lamhu'], [2, 'Senja'], [2, 'Bagmati']]
                                                        }),
                                                        valueField: 'myId',
                                                        displayField: 'displayText'
                                                    },
                                                                        {
                                                        xtype: 'textfield',
                                                        fieldLabel: 'ग.बि.स/न.पा',
                                                        // emptyText:'Enter VDC/MUN...',
                                                        labelWidth: 80,
                                                        allowBlank: false,
                                                        margin: 5
                                                    }
                                                                    ]
                                                        },
                                                        {
                                                             xtype: 'panel',
                                                             width: '100%',
                                                             height: 35,
                                                             layout: 'column',
                                                             title: "ColumnLayout Panel",
                                                             preventHeader: true,
                                                             border: 0,
                                                             frame: true,
                                                             style: 'border:none;padding:0px;',
                                                             items: [
                                                                        {
                                                                            xtype: 'textfield',
                                                                            fieldLabel: 'टोल',
                                                                            width: 300,
                                                                            labelWidth: 40,
                                                                            allowBlank: false,
                                                                            margin: 5
                                                                        },
                                                                        {
                                                                            xtype: 'textfield',
                                                                            fieldLabel: 'घर नम्बर',
                                                                            labelWidth: 80,
                                                                            allowBlank: false,
                                                                            // emptyText:'Enter Block Number...',
                                                                            margin: 5
                                                                        }
                                                                    ]
                                                        },
                                                        {
                                                             xtype: 'panel',
                                                             width: '100%',
                                                             height: 35,
                                                             layout: 'column',
                                                             title: "ColumnLayout Panel",
                                                             preventHeader: true,
                                                             border: 0,
                                                             frame: true,
                                                             style: 'border:none;padding:0px;',
                                                             items: [
                                                                        {
                                                                            xtype: 'textfield',
                                                                            fieldLabel: 'वडा नम्बर',
                                                                            labelWidth: 40,
                                                                            allowBlank: false,
                                                                            //  emptyText:'Enter Ward Number...',
                                                                            margin: 5
                                                                        },
                                                                        {
                                                                            xtype: 'combo',
                                                                                fieldLabel: 'क्षेत्र',
                                                                                // emptyText:'Select District...',
                                                                                labelWidth: 40,
                                                                                width: 200,
                                                                                allowBlank: false,
                                                                                margin: 5,
                                                                                store: new Ext.data.ArrayStore({
                                                                                    id: 0,
                                                                                    fields: ['myId', 'displayText'],
                                                                                    data: [[1, 'Jhapa'], [2, 'Ilam'], [2, 'PachThar'], [2, 'Taplejung'], [2, 'Morang'], [2, 'Dhankuta'], [2, 'Sorekhute'], [2, 'Lamhu'], [2, 'Senja'], [2, 'Bagmati']]
                                                                                }),
                                                                                valueField: 'myId',
                                                                                displayField: 'displayText'
                                                                        }
                                                                    ]
                                                        }
                                                    ]
                                        },
                                                        {
                                            xtype:'gridpanel',
                                            title: 'Address Book',
                                            preventHeader: true,
                                            border: 0,
                                            frame: true,
                                            style: 'border:none;',
                                            store: Ext.data.StoreManager.lookup('addressStore'),
                                            columns: [
                                                         {header: 'सम्पर्क साधन',  dataIndex: 'name',width:200},
                                                         {header: 'बिबरण', width:200,dataIndex: 'email',field:{xtype:'textfield',allowBlank:false}}
                                                    ],
                                            selType: 'cellmodel',
                                            plugins: [
                                                         Ext.create('Ext.grid.plugin.CellEditing', {
                                                         clicksToEdit: 1
                                                        })
                                                    ],
                                            height: 100,
                                            width: '42%'
                                        }
                                                    ]
                                        }
                                                    ]
                                    },
                                    {
                                             title: 'आयकर पर्योजन्को लागि सम्पर्क व्यक्ति(प्रबन्ध निर्देशन प्रमुख्कर्यकारी अधिकृत बाहेक भयमा मात्र)',
                                             xtype: 'fieldset',
                                             collapsible: true,
                                             width:'100%',
                                             height: 335,
                                             //preventHeader: true,
                                             //frame: true,
                                             style: 'padding:4px;',
                                             layout:'column',
                                             items:[
                                                     {
                                            xtype:'panel',
                                            title: 'Table Layout',
                                            preventHeader: true,
                                            border: 0,
                                            frame: true,
                                            style: 'border:none',
                                            width: '100%',
                                            height: 80,
                                            layout: {
                    type: 'table',
                    // The total column count must be specified here
                    columns: 3
                },
                                            defaults: {
                    // applied to each contained panel
                    bodyStyle: 'padding:0px;border:none;background-color:#DFE9F6'
                },
                                            items: [
                                                                {
                            html: '<div >नाम<label style=margin-left:40px;>पहिलो</label</div>',
                            width:270
                        },
                                                                {
                            html: 'दोस्रो',
                            width:205
                        },
                                                                {
                            html: 'थर',
                            width:200
                        },
                                                                {
                                xtype: "textfield",
                                fieldLabel: 'नेपालीमा',
                                name: 'txtNepfirstName',
                                labelWidth: 50,
                                width: 265,
                                allowBlank: false,
                                // emptyText: 'Enter Your First Name...',
                               // margin: 5
                        },
                                                                {
                               xtype: "textfield",
                                name: 'txtNepMiddleName',
                                //fieldLabel: 'दोस्रो',
                                //labelWidth: 50,
                                width: 200,
                                allowBlank: false,
                                // emptyText: 'Enter Your Middle Name...',
                                //margin: 5
                        },
                                                                {
                                xtype: "textfield",
                                name: 'txtNepLastName',
                                //fieldLabel: 'थर',
                                width: 200,
                                allowBlank: false,
                                //labelWidth: 50,
                                // emptyText: 'Enter Your Last Name...',
                                //margin: 5
                        },
                                                                {
                                 xtype: "textfield",
                                 fieldLabel: 'अंग्रेजीमा',
                                 name: 'txtfirstName',
                                 labelWidth: 50,
                                 width: 265,
                                 allowBlank: false,
                                 // emptyText: 'Enter Your First Name...',
                                 //margin: 5
                        },
                                                                {
                                xtype: "textfield",
                                name: 'txtMiddleName',
                                //fieldLabel: 'Middle',
                                //labelWidth: 50,
                                width: 200,
                                allowBlank: false,
                                // emptyText: 'Enter Your Middle Name...',
                                //margin: 5
                        },
                                                                {
                                xtype: "textfield",
                                name: 'txtLastName',
                                //fieldLabel: 'Last',
                                //labelWidth: 50,
                                width: 200,
                                allowBlank: false,
                                // emptyText: 'Enter Your Last Name...',
                               // margin: 5
                        }
                                                ]
                                          },
                                                     {
                                           xtype: 'textfield',
                                           fieldLabel: 'नियुक्ति मिति (YYYY.MM.DD)',
                                           // emptyText:'Enter VDC/MUN...',
                                           labelWidth: 170,
                                           allowBlank: false,
                                           margin: 5
                                        },
                                                     {
                                                xtype: "combo",
                                                id: 'idnationality',
                                                fieldLabel:'रास्ट्रियता',
                                                width: 300,
                                                allowBlank: false,
                                                margin:5,
                                                store: new Ext.data.ArrayStore({
                                                    id: 0,
                                                    fields: ['myId', 'displayText'],
                                                    data: [[1, 'Nepali'], [2, 'Japaneas'], [3, 'Indian']]
                                                }),
                                                valueField: 'myId',
                                                displayField: 'displayText'
                                        },
                                                     {
                                            xtype:'panel',
                                            title: 'Table Layout',
                                            preventHeader: true,
                                            border: 0,
                                            frame: true,
                                            style: 'border:none',
                                            width: '100%',
                                            height: 60,
                                            layout: {
                                                    type: 'table',
                                                    columns: 4
                                                    },
                                            defaults: {
                                                    bodyStyle: 'padding:0px;border:none;background-color:#DFE9F6'
                                                    },
                                            items: [
                                                     {
                                                        html: 'कागजको प्रकार:',
                                                        width:220
                                                     },
                                                     {
                                                        html: 'परिचय पत्र नं:',
                                                        width:220
                                                     },
                                                     {
                                                        html: 'जरिगारने कार्यालय तथा स्थान:',
                                                        width:220
                                                     },
                                                     {
                                                        html: 'जारीगरेको मिति:',
                                                        width:220
                                                     },
                                                     {
                                                        xtype: "combo",
                                                        //id: 'idnationality',
                                                        width: 215,
                                                        allowBlank: false,
                                                        store: new Ext.data.ArrayStore({
                                                            id: 0,
                                                            fields: ['myId', 'displayText'],
                                                            data: [[1, 'Nepali'], [2, 'Japaneas'], [3, 'Indian']]
                                                        }),
                                                        valueField: 'myId',
                                                        displayField: 'displayText'
                                                     },
                                                     {
                                                        xtype: "textfield",
                                                        labelWidth: 90,
                                                        width: 215,
                                                        allowBlank: false
                                                     },
                                                     {
                                                        xtype: "textfield",
                                                        labelWidth: 90,
                                                        width: 215,
                                                        allowBlank: false
                                                     },
                                                     {
                                                        xtype: "datefield",
                                                        minLength: 10,
                                                        maxLength: 10,
                                                        width: 215,
                                                        allowBlank: false
                                                     }

                                                ]
                                          },
                                                     {
                                            title: 'प्रबन्ध निर्देशन प्रमुख्कर्यकारी अधिकृत को ठेगाना',
                                             xtype: 'fieldset',
                                             collapsible: true,
                                             width:'100%',
                                             height: 135,
                                             //preventHeader: true,
                                             //frame: true,
                                             style: 'padding:1px;',
                                             layout:'column',
                                             items:
                                                    [
                                                        {
                                             xtype: 'panel',
                                             width: '57%',
                                             title: "ColumnLayout Panel",
                                             preventHeader: true,
                                             border: 0,
                                             frame: true,
                                             style: 'border:none;',
                                             items: [
                                                        {
                                                             xtype: 'panel',
                                                             width: '100%',
                                                             height: 35,
                                                             layout: 'column',
                                                             title: "ColumnLayout Panel",
                                                             preventHeader: true,
                                                             border: 0,
                                                             frame: true,
                                                             style: 'border:none;padding:0px;',
                                                             items: [

                                                                        {
                                                        xtype: 'combo',
                                                        fieldLabel: 'जिल्ला',
                                                        // emptyText:'Select District...',
                                                        labelWidth: 40,
                                                        width: 300,
                                                        allowBlank: false,
                                                        margin: 5,
                                                        store: new Ext.data.ArrayStore({
                                                            id: 0,
                                                            fields: ['myId', 'displayText'],
                                                            data: [[1, 'Jhapa'], [2, 'Ilam'], [2, 'PachThar'], [2, 'Taplejung'], [2, 'Morang'], [2, 'Dhankuta'], [2, 'Sorekhute'], [2, 'Lamhu'], [2, 'Senja'], [2, 'Bagmati']]
                                                        }),
                                                        valueField: 'myId',
                                                        displayField: 'displayText'
                                                    },
                                                                        {
                                                        xtype: 'textfield',
                                                        fieldLabel: 'ग.बि.स/न.पा',
                                                        // emptyText:'Enter VDC/MUN...',
                                                        labelWidth: 80,
                                                        allowBlank: false,
                                                        margin: 5
                                                    }
                                                                    ]
                                                        },
                                                        {
                                                             xtype: 'panel',
                                                             width: '100%',
                                                             height: 35,
                                                             layout: 'column',
                                                             title: "ColumnLayout Panel",
                                                             preventHeader: true,
                                                             border: 0,
                                                             frame: true,
                                                             style: 'border:none;padding:0px;',
                                                             items: [
                                                                        {
                                                                            xtype: 'textfield',
                                                                            fieldLabel: 'टोल',
                                                                            width: 300,
                                                                            labelWidth: 40,
                                                                            allowBlank: false,
                                                                            margin: 5
                                                                        },
                                                                        {
                                                                            xtype: 'textfield',
                                                                            fieldLabel: 'घर नम्बर',
                                                                            labelWidth: 80,
                                                                            allowBlank: false,
                                                                            // emptyText:'Enter Block Number...',
                                                                            margin: 5
                                                                        }
                                                                    ]
                                                        },
                                                        {
                                                             xtype: 'panel',
                                                             width: '100%',
                                                             height: 35,
                                                             layout: 'column',
                                                             title: "ColumnLayout Panel",
                                                             preventHeader: true,
                                                             border: 0,
                                                             frame: true,
                                                             style: 'border:none;padding:0px;',
                                                             items: [
                                                                        {
                                                                            xtype: 'textfield',
                                                                            fieldLabel: 'वडा नम्बर',
                                                                            labelWidth: 40,
                                                                            allowBlank: false,
                                                                            //  emptyText:'Enter Ward Number...',
                                                                            margin: 5
                                                                        },
                                                                        {
                                                                            xtype: 'combo',
                                                                                fieldLabel: 'क्षेत्र',
                                                                                // emptyText:'Select District...',
                                                                                labelWidth: 40,
                                                                                width: 200,
                                                                                allowBlank: false,
                                                                                margin: 5,
                                                                                store: new Ext.data.ArrayStore({
                                                                                    id: 0,
                                                                                    fields: ['myId', 'displayText'],
                                                                                    data: [[1, 'Jhapa'], [2, 'Ilam'], [2, 'PachThar'], [2, 'Taplejung'], [2, 'Morang'], [2, 'Dhankuta'], [2, 'Sorekhute'], [2, 'Lamhu'], [2, 'Senja'], [2, 'Bagmati']]
                                                                                }),
                                                                                valueField: 'myId',
                                                                                displayField: 'displayText'
                                                                        }
                                                                    ]
                                                        }
                                                    ]
                                        },
                                                        {
                                            xtype:'gridpanel',
                                            title: 'Address Book',
                                            preventHeader: true,
                                            border: 0,
                                            frame: true,
                                            style: 'border:none;',
                                            store: Ext.data.StoreManager.lookup('addressStore'),
                                            columns: [
                                                         {header: 'सम्पर्क साधन',  dataIndex: 'name',width:200},
                                                         {header: 'बिबरण', width:200,dataIndex: 'email',field:{xtype:'textfield',allowBlank:false}}
                                                    ],
                                            selType: 'cellmodel',
                                            plugins: [
                                                         Ext.create('Ext.grid.plugin.CellEditing', {
                                                         clicksToEdit: 1
                                                        })
                                                    ],
                                            height: 100,
                                            width: '42%'
                                        }
                                                    ]
                                        }
                                                    ]
                                    }
                                    ]
                        }

    ]
};

var regSimple = Ext.create('Ext.form.Panel', {
    url: 'save-form.php',
    frame: true,
    title: 'Business Update',
    bodyStyle: 'padding:5px 5px 0',
    renderTo: Ext.get('mainContent'),
    fieldDefaults: {
        msgTarget:'side',
        labelWidth: 75
    },
    defaultType: 'textfield',
    defaults: {
        anchor: '100%'
    },

    items: [PersonalInfo,  RelativesIntro,MainBusiness,SITCInfo],

    buttons: [{
        text: 'Save'
    },
     {
         text: 'Submit'
     }]
});