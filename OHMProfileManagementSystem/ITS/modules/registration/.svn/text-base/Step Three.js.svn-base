var PersonalInfo = {
    xtype: 'fieldset',
    collapsible: true,
    defaults: { anchor: '100%' },
    layout: 'anchor',
    title: 'Select Business Types',
    items:
    [
       {
           xtype: 'panel',
           width: 500,
           height: 40,
           title: "ColumnLayout Panel",
           layout: 'column',
           preventHeader: true,
           border: 0,
           frame: true,
           style: 'border:none',
           items: [
                    {
                        xtype: 'combo',
                        fieldLabel: 'Business Types',
                        id: 'businesstype',
                        labelWidth: 90,
                        width: 300,
                        allowBlank: false,
                        margin: 5,
                        store: new Ext.data.ArrayStore({
                            id: 0,
                            fields: ['myId', 'displayText'],
                            data: [[1, 'Individual'], [2, 'Entity']]
                        }),
                        valueField: 'myId',
                        displayField: 'displayText'
                    },
                     {
                         xtype: "textfield",
                         fieldLabel: 'PAN No',
                         name: 'txtemail',
                         labelWidth: 50,
                         id: 'first',
                         width: 250,
                         allowBlank: false,
                         // emptyText: 'Enter Your First Name...',
                         margin: 5
                     }
                ]
       }
    ]
};

var regSimple = Ext.create('Ext.form.Panel', {
    url: 'save-form.php',
    frame: true,
    title: 'Business Type',
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

    items: [PersonalInfo],

    buttons: [{
        text: 'Next',
        handler: function () {
            //Validating Form
            // alert(Ext.getCmp('businesstype').getValue());
            if (Ext.getCmp('businesstype').getValue() == null) {
                Ext.Msg.show({
                    title: 'Please Select Business Type',
                    msg: 'Business Type is not provided, Please select Business type?',
                    buttons: Ext.Msg.OK,
                    icon: Ext.Msg.QUESTION
                });
            }
            //End of Validating Form

            if (Ext.getCmp('businesstype').getValue() != null) {
                var _strSelectedBusinessType = Ext.getCmp('businesstype').getValue();
                if (_strSelectedBusinessType == "1") {
                    GoEvent('TaxPayer Registration.js', 'Step');
                } else {
                    GoEvent('Business Registration.js', 'Step');
                }
            }
        }
    },
     {
         text: 'Cancel'
     }]
});