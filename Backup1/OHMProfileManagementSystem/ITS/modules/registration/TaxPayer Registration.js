var PersonalInfo = {
    xtype: 'fieldset',
    collapsible: true,
    defaults: { anchor: '100%' },
    layout: 'anchor',
    title: 'Personal Info (व्यक्तिगत विवरण)',
    items:
    [
        {
            xtype: 'panel',
            defaults: { anchor: '100%' },
            height: 155,
            title: "ColumnLayout Panel",
            preventHeader: true,
            border: 0,
            frame: true,
            style: 'border:none;',
            layout: 'column',
            items:
            [
                 {
                     xtype: 'panel',
                     //defaults: { anchor: '90%' },
                     width: '78%',
                     height: 155,
                     title: "ColumnLayout Panel",
                     preventHeader: true,
                     border: 0,
                     frame: true,
                     style: 'border:none',
                     items:
            [
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
                    xtype: 'panel',
                    width: '100%',
                    height: 80,
                    title: "ColumnLayout Panel",
                    layout: 'column',
                    preventHeader: true,
                    style: 'border:none',
                    border: 0,
                    frame: true,
                    items:
                        [
                             {
                                 xtype: 'panel',
                                 title: 'Table Layout',
                                 width: '100%',
                                 height: 150,
                                 preventHeader: true,
                                 style: 'padding:0px;border:none',

                                 border: 0,
                                 frame: true,
                                 layout: {
                                     type: 'table',
                                     // The total column count must be specified here
                                     columns:4
                                 },
                                 defaults: {
                                     // applied to each contained panel
                                     bodyStyle: 'border:none;background-color:#DFE9F6;'
                                 },
                                 items: [
                                            {
                                                width: '100'
                                            },
                                            {
                                                html: 'जन्म मिति:-',
                                                width: '150'
                                            },
                                            {
                                                html: 'लिंग:-',
                                                width: '230'
                                            },
                                            {
                                                html: 'रास्ट्रियता:-',
                                                width: '200'
                                            },
                                            {
                                                xtype: 'radiogroup',
                                                //labelWidth: 30,
                                                width: 100,
                                                margin: 5,
                                                items: [
                                              { boxLabel: 'बि.स', name: 'rb-group1', inputValue: 1 ,checked:true},
                                              { boxLabel: 'इ.स', name: 'rb-group1', inputValue: 2}
                                              ]
                                            },
                                            {
                                                xtype: "textfield",
                                                name: 'txtdates',
                                                width: 150,
                                                allowBlank: false
                                            },
                                            {
                                                xtype: 'radiogroup',
                                                labelWidth: 30,
                                                width: 230,
                                                margin: 5,
                                                items: [
                                              { boxLabel: 'पुरुस', name: 'rb-group', inputValue: 1, checked: true, width: 80 },
                                              { boxLabel: 'महिला', name: 'rb-group', inputValue: 2, width: 80 },
                                              { boxLabel: 'तेश्रो लैंगिक', name: 'rb-group', inputValue: 3, width: 90 }
                                       ]
                                            },
                                            {
                                                xtype: "combo",
                                                id: 'idnationality',
                                                width: 200,
                                                allowBlank: false,
                                                store: new Ext.data.ArrayStore({
                                                    id: 0,
                                                    fields: ['myId', 'displayText'],
                                                    data: [[1, 'Nepali'], [2, 'Japaneas'], [3, 'Indian']]
                                                }),
                                                valueField: 'myId',
                                                displayField: 'displayText'
                                            }

                            ]
                             }
                        ]
                }
            ]
                 },
                 {
                     xtype: 'panel',
                     //defaults: { anchor: '30%' },
                     width: '22%',
                     height: 155,
                     title: "ColumnLayout Panel",
                     preventHeader: true,
                     border: 0,
                     frame: true,
                     style: 'border:none',
                     items:
                    [
                        {
                            xtype: 'panel',
                            defaults: { anchor: '100%' },
                            title: "ColumnLayout Panel",
                            // layout: 'column',
                            preventHeader: true,
                            border: 0,
                            frame: true,
                            style: 'border:none;margin:0 auto;',
                            items: [
                                    {
                                        xtype: 'panel',
                                         width: 140,
                                        title: "ColumnLayout Panel",
                                        // layout: 'column',
                                        preventHeader: true,
                                        border: 0,
                                        frame: true,
                                        style: 'border:none;margin:0 auto;padding:0px;',
                                        items: [
                                                 {
                                                    xtype: 'image',
                                                    src: '../resources/images/Hydrangeas.jpg',
                                                    height: 110,
                                                    width: 130,
                                                    border: true,
                                                    //style: 'padding-left:120px;',
                                                    resizable: false,
                                                    style: 'border:1px solid #000000;padding:5px;'
                                                  }
                                                ]
                                    },
                                    {
                                        xtype: 'fileuploadfield',
                                        name: 'filedata1',
                                        //labelWidth: 150,
                                        id: 'filedata1',
                                        width: 200,
                                        style: 'margin-top:5px;',
                                        // emptyText: 'Select a picture to upload...',
                                        // fieldLabel: 'करदाताको तस्बिर',
                                        buttonText: 'Select a File..'
                                    }

                                ]
                        }
                    ]
                 }
            ]
        },
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

var DocFilesstores = Ext.create('Ext.data.Store', {
    storeId: 'docStore',
    fields: ['idtype', 'idnumber', 'issuingcountry', 'issuingoffice', 'docfile'],
    data: { 'items': [
               { idtype:'Licence', idnumber:'2356', issuingcountry:'Nepal', issuingoffice:'Kathmandu', docfile:'View details'  },
               { idtype:'CitizenShip', idnumber:'2356', issuingcountry:'Nepal', issuingoffice:'Kathmandu', docfile:'View details'  }

    ]
    },
    proxy: {
        type: 'memory',
        reader: {
            type: 'json',
            root: 'items'
        }
    }
});

var Combo = Ext.create('Ext.form.ComboBox', {
                             id: 'idtype',
                             width:160,
                             allowBlank: false,
                             store: new Ext.data.ArrayStore({
                                 id: 0,
                                 fields: ['myId', 'displayText'],
                                 data: [[1, 'CitizenShip'], [2, 'Passport'], [3, 'Others']]
                             }),
                             valueField: 'myId',
                             displayField: 'displayText'
                             });
var CboDistrictCountry =  Ext.create('Ext.form.ComboBox',{
                             id: 'issuingcountry',
                             allowBlank: false,
                             store: new Ext.data.ArrayStore({
                                 id: 0,
                                 fields: ['myId', 'displayText'],
                                 data: [[1, 'Jhapa'], [2, 'Ilam'], [2, 'PachThar'], [2, 'Taplejung'], [2, 'Morang'], [2, 'Dhankuta'], [2, 'Sorekhute'], [2, 'Lamhu'], [2, 'Senja'], [2, 'Bagmati']]
                             }),
                             valueField: 'myId',
                             displayField: 'displayText'});
var CboIssuingOffice = Ext.create('Ext.form.ComboBox',{
                                   id: 'issuingoffice',
                                   allowBlank: false,
                                   store: new Ext.data.ArrayStore({
                                       id: 0,
                                       fields: ['myId', 'displayText'],
                                       data: [[1, 'CDO Office'], [2, 'Others']]
                                   }),
                                   valueField: 'myId',
                                   displayField: 'displayText'});
var FileDocFile = Ext.create('Ext.form.File',{
                                id: 'docfile',
                                buttonText: 'Select a File..'});

var DocList = {
    xtype: 'fieldset',
    defaultType: 'textfield',
    collapsible: true,
    defaults: { anchor: '100%' },
    title: 'Document (कागज पत्र)',
    items:
    [
        {
                    xtype:'gridpanel',
                    title: 'Address Book',
                    preventHeader: true,
                    border: 0,
                    frame: true,
                    style: 'border:none',
                    store: Ext.data.StoreManager.lookup('docStore'),
                    columns: [
                                        { header: 'कागजातको किसिम',width:160, dataIndex: 'idtype' ,field:Combo},
                                        { header: 'परिच पत्र नं',width:160, dataIndex: 'idnumber',field:{xtype:'textfield',allowBlank:false} },
                                        { header: 'जरिगारने देश',width:250, dataIndex: 'issuingcountry',field:CboDistrictCountry},
                                        { header: 'जरिगारने कार्यालय र स्थान', width:220,dataIndex: 'issuingoffice',field:CboIssuingOffice },
                                        { header: 'कागजात',width:190, dataIndex: 'docfile',field:FileDocFile }
                            ],
                    selType: 'cellmodel',
                    plugins: [
                                 Ext.create('Ext.grid.plugin.CellEditing', {
                                 clicksToEdit: 1
                                })
                            ],
                    height: 100,
                    width: '100%'
         }
    ]
};
var RelativesIntro = {
    xtype: 'fieldset',
    collapsible: true,
    defaults: { anchor: '100%' },
    layout: 'anchor',
    title: 'Relatives(पारिवारिक बिबरण)',
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
                            html: '<div style=margin-left:98px;>पहिलो</div>',
                            width: 335
                        },
                        {
                            html: 'बिचको',
                            width: 225
                        },
                        {
                            html: 'थर',
                            width: 225
                        },
                        {
                                    xtype: "textfield",
                                    fieldLabel: 'पति/पत्नीको  नाम',
                                    name: 'txtSpoucefirstNames',
                                    labelWidth: 90,
                                    width: 330,
                                    allowBlank: false
                                },
                        {
                                    xtype: "textfield",
                                    name: 'txtSpouceMiddleNames',
                                    labelWidth: 50,
                                    width: 220,
                                    allowBlank: false
                                },
                        {
                                    xtype: "textfield",
                                    name: 'txtSpouceLastNames',
                                    width: 220,
                                    allowBlank: false
                                },
                        {
                                    xtype: "textfield",
                                    fieldLabel: 'बुवाको  नाम',
                                    name: 'txtFatherfirstNames',
                                    labelWidth: 90,
                                    width: 330,
                                    allowBlank: false
                                },
                        {
                                    xtype: "textfield",
                                    name: 'txtFatherMiddleNames',
                                    width: 220,
                                    allowBlank: false
                                },
                        {
                                    xtype: "textfield",
                                    name: 'txtFatherLastNames',
                                     width: 220,
                                    allowBlank: false
                                },
                        {
                                        xtype: "textfield",
                                        fieldLabel: 'बजेको  नाम',
                                        name: 'txtGrandFatherfirstNames',
                                        labelWidth: 90,
                                         width: 330,
                                        allowBlank: false
                                    },
                        {
                                        xtype: "textfield",
                                        name: 'txtGrandFatherMiddleNames',
                                         width: 220,
                                        allowBlank: false
                                    },
                        {
                                        xtype: "textfield",
                                        name: 'txtGrandFatherLastNames',
                                         width: 220,
                                        allowBlank: false
                                    }

            ]
        }
    ]
};

var PermanentAddInfo = {
    xtype: 'fieldset',
    collapsible: true,
    layout: 'column',
    defaults: { anchor: '100%' },
    title: 'Permanent Address (स्थाई ठेगाना)',
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
                        style: 'border:none',
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
};

var TemporaryAddInfo = {
    xtype: 'fieldset',
    collapsible: true,
    layout: 'column',
    defaults: { anchor: '100%' },
    title: 'Temporary Address (अस्थाई ठेगाना)',
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
                        style: 'border:none',
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
};

var regSimple = Ext.create('Ext.form.Panel', {
    url: 'save-form.php',
    frame: true,
    title: 'Personal E-PAN',
    bodyStyle: 'padding:5px 5px 0',
    renderTo: Ext.get('mainContent'),
    fieldDefaults: {
        msgTarget: 'side',
        labelWidth: 75
    },
    defaultType: 'textfield',
    defaults: {
        anchor: '100%'
    },

    items: [PersonalInfo, DocList, RelativesIntro, PermanentAddInfo, TemporaryAddInfo],

    buttons: [{
        text: 'Save'
    },
     {
         text: 'Submit'
     }]
});