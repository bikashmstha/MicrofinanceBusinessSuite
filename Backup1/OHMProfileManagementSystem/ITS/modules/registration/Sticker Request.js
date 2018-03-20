var StickerRequest = {
    xtype: 'panel',
    width: '100%',
    height: 100,
    title: "ColumnLayout Panel",
    layout: 'vbox',
    preventHeader: true,
    border: 0,
    frame: true,
    style: 'border:none',
    items: [
                            {
                                xtype: "combobox",
                                fieldLabel: 'Location',
                                name: 'cbolocation',
                                labelWidth: 130,
                                id: 'cbolocation',
                                width: 370,
                                allowBlank: false,
                                emptyText: 'Lazimpat IRD Store1',
                                margin: 5
                            },
                                 {
                                     xtype: "combobox",
                                     fieldLabel: 'Sticker',
                                     name: 'cbosticker',
                                     labelWidth: 130,
                                     id: 'cbosticker',
                                     width: 370,
                                     allowBlank: false,
                                     emptyText: 'B2',
                                     margin: 5
                                 },   {
                                                        xtype: "textfield",
                                                        fieldLabel: 'Request date',
                                                        name: 'txtRequestdate',
                                                        id: 'txtRequestdate',
                                                        labelWidth: 150,
                                                        width: 400,
                                                        allowBlank: false,
                                                        margin: 5
                                                    },
                                                  
    
                                {
                                    xtype: "combobox",
                                    fieldLabel: 'Request to',
                                    name: 'cborequestto',
                                    labelWidth: 130,
                                    id: 'cborequestto',
                                    width: 370,
                                    allowBlank: false,
                                    emptyText: 'Purchase',
                                    margin: 5
                                }
                                ,
    
                        {
                            xtype: "textfield",
                            fieldLabel: 'Quantity',
                            name: 'txtQuantity',
                            labelWidth: 150,
                            width: 400,
                            allowBlank: false,                        
                            margin: 5
                      
                            },

  
                                {
                                    xtype: "combobox",
                                    fieldLabel: 'Status',
                                    name: 'cboverifyingoffice',
                                    labelWidth: 130,
                                    id: 'cboverifyingoffice',
                                    width: 370,
                                    allowBlank: false,
                                    emptyText: 'PENDING',
                                    margin: 5
                                }
                                ]

};

        var regSimple = Ext.create('Ext.form.Panel', {
    url: 'save-form.php',
    frame: true,
    title: 'Sticker Request',
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

    items: [StickerRequest],

    buttons: [{
        text: 'Save',
        handler: function () {
            var _strCheckedPersonalPnl = Ext.getCmp('chkPersonalPanel').getValue();

            if (_strCheckedPersonalPnl == true) {
                GoEvent('TaxPayer Registration.js', 'Step');
            } else {
                GoEvent('Step Three.js', 'Step');
            }
        }
    },
     {
         text: 'Cancel'
     }]
});



                         
