/// <reference path="../../extjs/ext-all-debug-w-comments.js" />

Ext.define('BusinessAddressInfo', {
    extend: 'Ext.data.Model',
    fields: ['Address', 'AddressType', 'HouseNo', 'WardNo', 'Tole','VDC','District','Area']
});
Ext.define('BusinessContactInfo', {
    extend: 'Ext.data.Model',
    fields: ['Contact', 'ContactType']
});
var addressData = [
        ['samakhushi', 'Permanent', '14410', '21', 'sarkariDhara', 'asd', 'Bagmati', 'sdfsd'],
        ['kupandol', 'Permanent', '14410', '21', 'sarkariDhara', 'asd', 'Bagmati', 'sdfsd'],
        ['jawalakhel', 'Permanent', '14410', '21', 'sarkariDhara', 'asd', 'Bagmati', 'sdfsd'],
       ['sanepa', 'Permanent', '14410', '21', 'sarkariDhara', 'asd', 'Bagmati', 'sdfsd'],
        ['thamel', 'Permanent', '14410', '21', 'sarkariDhara', 'asd', 'Bagmati', 'sdfsd']
    ];
var contactData = [
        ['samakhushi', 'Permanent'],
        ['kupandol', 'Permanent'],
        ['jawalakhel', 'Permanent'],
       ['sanepa', 'Permanent'],
        ['thamel', 'Permanent']
    ];
var addressStore = Ext.create('Ext.data.ArrayStore', {
                    model: 'BusinessAddressInfo',
                    data: addressData,
                    autoload:true
                });
var contactStore = Ext.create('Ext.data.ArrayStore', {
    model: 'BusinessAddressInfo',
    data: contactData,
    autoload: true
});                
// create the Grid
var gridAddress = Ext.create('Ext.grid.Panel', {
    store: addressStore,
    stateful: true,
    stateId: 'stateGrid',
    style:{marginTop:'10px'},
    columns: [
            {
                text: 'Address',
                flex: 1,
                sortable: false,
                dataIndex: 'Address'
            },
            {
                text: 'AddressType',
                width: 125,
                sortable: true,
                dataIndex: 'AddressType'
            },
            {
                text: 'House No',
                width: 125,
                sortable: true,
                dataIndex: 'HouseNo'
            },
            {
                text: 'Ward No',
                width: 125,
                sortable: true,
                dataIndex: 'WardNo'
            },
            {
                text: 'Tole',
                width: 125,
                sortable: true,
                dataIndex: 'Tole'
            }, {
                text: 'Municipality/VDC',
                width: 125,
                sortable: true,
                dataIndex: 'VDC'
            }, {
                text: 'District',
                width: 125,
                sortable: true,
                dataIndex: 'District'
            }, {
                text: 'Area',
                width: 125,
                sortable: true,
                dataIndex: 'Area'
            }
        ],
    height: 350,
    anchor: 100,
    title: 'Address List',    
    viewConfig: {
        stripeRows: true
    }
});

var gridContact = Ext.create('Ext.grid.Panel', {
    store: contactStore,
    stateful: true,
    stateId: 'stateGrid',
    style: { marginTop: '10px' },
    columns: [
            {
                text: 'Contact',
                flex: 1,
                sortable: false,
                dataIndex: 'Address'
            },
            {
                text: 'ContactType',
                flex: 1,
                sortable: true,
                dataIndex: 'AddressType'
            }
        ],
    height: 350,
    anchor: 100,
    title: 'Address List',
    viewConfig: {
        stripeRows: true
    }
});

var businessTypes = Ext.create('Ext.data.Store', {
    fields: ['bType', 'bValue'],
    data: [
        { "bValue": "1", "bType": "Business Type 1" },
        { "bValue": "2", "bType": "Business Type 2" },
        { "bValue": "3", "bType": "Business Type 3" }
    //...
    ]
});

var addressTypes = Ext.create('Ext.data.Store', {
    fields: ['aType', 'aValue'],
    data: [
        { "aValue": "1", "aType": "Temporary" },
        { "aValue": "2", "aType": "Permanent" }    
    ]
});

var contactTypes = Ext.create('Ext.data.Store', {
    fields: ['aType', 'aValue'],
    data: [
        { "aValue": "1", "aType": "Temporary" },
        { "aValue": "2", "aType": "Permanent" }
    ]
});

var item1 = {    
    defaults: { width: 230 },
    defaultType: 'textfield',
    layout: 'column',
    border: false,
    items: [{
                xtype: 'container',
                columnWidth: .5,
                layout: 'anchor',
                items: [{
                    fieldLabel: 'Business Type',
                    name: 'first',
                    anchor: '55%',
                    xtype: 'combo',
                    store: businessTypes,
                    queryMode: 'local',
                    displayField: 'bType',
                    emptyText: 'Choose',
                    valueField: 'bValue'
                }]
            },
            {
                xtype: 'container',
                columnWidth: .5,
                layout: 'anchor',
                items: [{
                    xtype: 'textfield',
                    fieldLabel: 'Firm Name',
                    name: 'company',
                    anchor: '55%'
                }]
            }]
};

var item2 = {
    xtype: 'tabpanel',
    plain: true,
    border: true,
    margin: '0 0 10 0',
    activeTab: 0,
    height: 135,
    defaults: { bodyStyle: 'padding:10px' },
    items: [{
        title: 'Registration Details',
        defaults: { width: 230 },
        xtype: 'panel',
        defaultType: 'textfield',collapsible:true,
        layout: 'column',
        items: [{
            xtype: 'container',
            columnWidth: .5,
            layout: 'anchor',
            items: [{
                xtype: 'datefield',
                fieldLabel: 'Registration Date',
                name: 'first',
                anchor: '55%'
            }, {
                xtype: 'textfield',
                fieldLabel: 'Address',
                name: 'company',
                anchor: '55%'
            }]
        },
                                  {
                                      xtype: 'container',
                                      columnWidth: .5,
                                      layout: 'anchor',
                                      items: [{
                                          xtype: 'textfield',
                                          fieldLabel: 'Organisation',
                                          name: 'last',
                                          anchor: '55%'
                                      }, {
                                          xtype: 'textfield',
                                          fieldLabel: 'Registration No.',
                                          name: 'email',
                                          vtype: 'email',
                                          anchor: '55%'
                                      }]
                                  }]
    }]
};

var item3 = {
                xtype: 'container',
                columnWidth: .5,
                items: [
                            {xtype: 'textfield',fieldLabel: 'Business Start Date',name: 'bStartDate'},
                            {xtype: 'checkboxfield',fieldLabel: 'Self Invested',name: 'selfInvested'}
                       ]
            };

            var itemAddress = {
                title: 'Address',
                autoScroll: true,
                height: 205,
                width:'100%',
                style: { margin: '0px',padding: '0px' },
                items: [
                        { xtype: 'container', defaultType: 'textfield', layout: 'column', 
                            items: [{
                                    xtype: 'container', columnWidth: .25,defaults: { width: 230 },
                                    items: [{ xtype: 'combo', fieldLabel: 'Address Type', name: 'baddType', itemId: 'baddType', id: 'baddType', emptyText: 'Choose', store: addressTypes, queryMode: 'local', displayField: 'aType', valueField: 'aValue' },


                                            { xtype: 'textfield', fieldLabel: 'Ward No', name: 'bemail', itemId: 'bemail', id: 'bemail', vtype: 'email' }
                                            
                                           ]
                                    },
                                    {
                                        xtype: 'container', columnWidth: .25, defaults: { width: 230 },
                                        items: [{ xtype: 'textfield', fieldLabel: 'Address', name: 'bAddress', itemId: 'bAddress', id: 'bAddress' },
                                              { xtype: 'textfield', fieldLabel: 'Tole', name: 'btole', itemId: 'btole', id: 'btole' }
                                                ]

                                    },
                                    {
                                        xtype: 'container', columnWidth: .25, defaults: { width: 230 },
                                                items: [
                                                        { xtype: 'combo', fieldLabel: 'District', name: 'bdistrict', itemId: 'bdistrict', id: 'bdistrict', emptyText: 'Choose' },
                                              { xtype: 'textfield', fieldLabel: 'Area', name: 'barea', itemId: 'barea', id: 'barea'}         
                                                       ]
                                            },
                                    {
                                        xtype: 'container', columnWidth: .25, defaults: { width: 230 },
                                        items: [
                                                        { xtype: 'combo', fieldLabel: 'Municipality / VDC', emptyText: 'Choose', name: 'bVDC', itemId: 'bVDC', id: 'bVDC' },
                                                       { xtype: 'textfield', fieldLabel: 'House No', name: 'bHouseNo', itemId: 'bHouseNo', id: 'bHouseNo' },
                                                       ]
                                    }
                        
                                    ]
                },
                { xtype: 'button', text: '+', name: 'btnAddAddress',
                    handler: function () {

                    
                    }
                },
            gridAddress
           ]
            };

                var itemContact = {
                    title: 'Contact',
                    autoScroll: true,
                    height: 205,
                    style: { paddingBottom: '30px' },
                    items: [{ xtype: 'container', defaultType: 'textfield', layout: 'column',
                        items: [{ xtype: 'container', columnWidth: .25, layout: 'anchor', defaults: { width: 230 },
                                            items: [{ xtype: 'combo', fieldLabel: 'Contact Type', emptyText: 'Choose', name: 'bcontactType',store: contactTypes, queryMode:  'local', displayField: 'aType', valueField: 'aValue'}]
                                        },{
                                    xtype: 'container', columnWidth: .25, layout: 'anchor',defaults: { width: 230 },
                                    items: [{ xtype: 'textfield', fieldLabel: 'Contact', name: 'bContact'}]                               
                                        }]
                                    }, 
                { xtype: 'button', text: '+', name: 'btnAddAddress',
                    handler: function () {


                    }
                },
            gridContact]
                    };
                            

var item4 = {
    xtype: 'tabpanel',
    plain: true,
    activeTab: 0,
    height: 235,
    defaults: { bodyStyle: 'padding:10px' },
    items: [itemAddress, itemContact,
        {
            title: 'Business Details',
            defaults: { width: 230 },
            defaultType: 'textfield',

            items: [{
                fieldLabel: 'Home',
                name: 'home',
                value: '(888) 555-1212'
            }, {
                fieldLabel: 'Business',
                name: 'business'
            }, {
                fieldLabel: 'Mobile',
                name: 'mobile'
            }, {
                fieldLabel: 'Fax',
                name: 'fax'
            }]
        }, {
            title: "House Owner's Detail",
            defaults: { width: 230 },
            defaultType: 'textfield',

            items: [{
                fieldLabel: 'Home',
                name: 'home',
                value: '(888) 555-1212'
            }, {
                fieldLabel: 'Business',
                name: 'business'
            }, {
                fieldLabel: 'Mobile',
                name: 'mobile'
            }, {
                fieldLabel: 'Fax',
                name: 'fax'
            }]
        }, {
            title: "House Owner's Address",
            defaults: { width: 230 },
            defaultType: 'textfield',

            items: [{
                fieldLabel: 'Home',
                name: 'home',
                value: '(888) 555-1212'
            }, {
                fieldLabel: 'Business',
                name: 'business'
            }, {
                fieldLabel: 'Mobile',
                name: 'mobile'
            }, {
                fieldLabel: 'Fax',
                name: 'fax'
            }]
        }]
};





var tab2 = Ext.create('Ext.form.Panel', {
    bodyStyle: 'padding:5px',
    showTitle: false,
    border: false,
    anchor: 100,
    fieldDefaults: {
        labelAlign: 'top',
        msgTarget: 'side'
    },
    defaults: {
        anchor: '100%'
    },
    items: [{ border: false, items: [item1, item2] },
             item3,
             item4
           ],
    buttons: [{
        text: 'Save'
    }, {
        text: 'Cancel'
    }]
});

tab2.render(Ext.get('mainContent'));