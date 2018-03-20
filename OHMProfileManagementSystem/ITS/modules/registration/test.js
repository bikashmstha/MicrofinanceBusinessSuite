var v = { xtype: 'container', defaultType: 'textfield', layout: 'column',renderTo:Ext.get('mainContent'),
    items: [{
        xtype: 'container', columnWidth: .5, layout: 'anchor', autoScroll: true,
        items: [{ xtype: 'textfield', fieldLabel: 'Address', name: 'bAddress', anchor: '96%' },
                                { xtype: 'textfield', fieldLabel: 'House No', name: 'company', anchor: '96%' },
                                { xtype: 'textfield', fieldLabel: 'Tole', name: 'tole', anchor: '96%' },
                                { xtype: 'combo', fieldLabel: 'District', name: 'district', anchor: '96%' }
                               ]
    },
                        {
                            xtype: 'container', columnWidth: .5, layout: 'anchor',
                            items: [{ xtype: 'combo', fieldLabel: 'Address Type', name: 'addType', anchor: '100%' },
                                    { xtype: 'textfield', fieldLabel: 'Ward No', name: 'email', vtype: 'email', anchor: '100%' },
                                        { xtype: 'combo', fieldLabel: 'Municipality / VDC', name: 'tole', anchor: '100%' },
                                        { xtype: 'textfield', fieldLabel: 'Area', name: 'area', anchor: '100%' }
                                    ]

                        }]
                    };
                   