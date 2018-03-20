
            var orderDate=                {
                                xtype: "date",
                                fieldLabel: 'Order Date',
                                name: 'orderDate',
                                labelWidth: 130,
                                id: 'orderDate',
                                width: 370,
                                allowBlank: false,                               
                                margin: 5
                            };
                 var  expectedDeliveryDate=           {
                                     xtype: "date",
                                     fieldLabel: 'Sticker',
                                     name: 'cbosticker',
                                     labelWidth: 130,
                                     id: 'cbosticker',
                                     width: 370,
                                     allowBlank: false,
                                     emptyText: 'B2',
                                     margin: 5
                                 };
                     var supplierName= {
                                     xtype: "textfield",
                                     fieldLabel: 'Request date',
                                     name: 'txtRequestdate',
                                     id: 'txtRequestdate',
                                     labelWidth: 150,
                                     width: 400,
                                     allowBlank: false,
                                     margin: 5
                                 };


                     var supplierCountry=           {
                                    xtype: "combobox",
                                    fieldLabel: 'Request to',
                                    name: 'cborequestto',
                                    labelWidth: 130,
                                    id: 'cborequestto',
                                    width: 370,
                                    allowBlank: false,
                                    emptyText: 'Purchase',
                                    margin: 5
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

    items: [orderDate, expectedDeliveryDate, supplierName, supplierCountry],

    buttons: [{
                text: 'Save',
                handler: function () {
           
                         }
              },
              {
                 text: 'Cancel'
             }]
});



                         
