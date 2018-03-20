/// <reference path="ext-all-debug-w-comments.js" />
var PersonalInfo = {
    xtype: 'fieldset',
    collapsible: true,
    defaults: { anchor: '90%' },
    layout: 'anchor',
    title: 'Submission No',
    items:
    [
       {
           xtype: 'panel',
           width: '100%',
           height: 40,
           title: "ColumnLayout Panel",
           layout: 'column',
           preventHeader: true,
           border: 0,
           frame: true,
           style: 'border:none',
           items: [
                    {
                        xtype: "textfield",
                        fieldLabel: 'UserName',
                        name: 'txtUsername',
                        labelWidth: 150,
                        //                        id: 'first',
                        width: 400,
                        allowBlank: false,
                        // emptyText: 'Enter Your First Name...',
                        margin: 5
                    }
                  ]
       },
       {
           xtype: 'panel',
           width: '100%',
           height: 40,
           title: "ColumnLayout Panel",
           layout: 'column',
           preventHeader: true,
           border: 0,
           frame: true,
           style: 'border:none',
           items: [
         {
             xtype: "textfield",
             fieldLabel: 'Password',
             name: 'txtPassword',
             inputType: 'password',
             labelWidth: 150,

             width: 400,
             allowBlank: false,
             // emptyText: 'Enter Your First Name...',
             margin: 5
         }]
       },
       {
           xtype: 'panel',
           width: '100%',
           height: 40,
           title: "ColumnLayout Panel",
           layout: 'column',
           preventHeader: true,
           border: 0,
           frame: true,
           style: 'border:none',
           items: [
         {
             xtype: "textfield",
             fieldLabel: 'Re-Password',
             name: 'txtrepassword',
             labelWidth: 150,
             inputType: 'password',
             width: 400,
             allowBlank: false,
             // emptyText: 'Enter Your First Name...',
             margin: 5
         }]
       },
       {
           xtype: 'panel',
           width: '100%',
           height: 40,
           title: "ColumnLayout Panel",
           layout: 'column',
           preventHeader: true,
           border: 0,
           frame: true,
           style: 'border:none',
           items: [
         {
             xtype: "textfield",
             fieldLabel: 'Contact No',
             name: 'txtContactNo',
             labelWidth: 150,

             width: 400,
             allowBlank: false,
             // emptyText: 'Enter Your First Name...',
             margin: 5
         }]
       },
       {
           xtype: 'panel',
           width: '100%',
           height: 40,
           title: "ColumnLayout Panel",
           layout: 'column',
           preventHeader: true,
           border: 0,
           frame: true,
           style: 'border:none',
           items: [
         {
             xtype: "textfield",
             fieldLabel: 'Email-ID',
             name: 'txtemail',
             labelWidth: 150,

             width: 400,
             allowBlank: false,
             // emptyText: 'Enter Your First Name...',
             margin: 5
         }]
       }
    ]
};

var SubmissionForm = {
    xtype: 'fieldset',
    collapsible: true,
    defaults: { anchor: '90%' },
    layout: 'anchor',
    title: 'Submission For',
    items:
    [
       {
           xtype: 'panel',
           width: '100%',
           height: 40,
           title: "ColumnLayout Panel",
           layout: 'column',
           preventHeader: true,
           border: 0,
           frame: true,
           style: 'border:none',
           items: [
                        {
                            xtype: 'fieldcontainer',
                            fieldLabel: '',
                            layout: 'column',
                            defaultType: 'checkboxfield',
                            labelWidth: 155,
                            items: [
                        {
                            boxLabel: 'Personal Panel',
                            name: 'chkPersonalPanel',
                            inputValue: '1',
                            id: 'chkPersonalPanel',
                            margin: "10px",
                            checked: true,
                            handler: function () {
                                var _strPersonalChecked = Ext.getCmp('chkPersonalPanel').getValue();
                                if (_strPersonalChecked == true) {
                                    Ext.getCmp('chkincomeTax').setValue(false);
                                    Ext.getCmp('chkvat').setValue(false);
                                    Ext.getCmp('chkexcise').setValue(false);
                                }
                            }
                        }, {
                            boxLabel: 'Income Tax',
                            margin: "10px",
                            name: 'chkincomeTax',
                            inputValue: '2',
                            checked: false,
                            id: 'chkincomeTax',
                            handler: function () {
                                Ext.getCmp('chkPersonalPanel').setValue(false);
                            }
                        }, {
                            boxLabel: 'Vat',
                            name: 'chkvat',
                            inputValue: '3',
                            id: 'chkvat',
                            margin: "10px",
                            handler: function () {
                                Ext.getCmp('chkPersonalPanel').setValue(false);
                            }
                        }, {
                            boxLabel: 'Excise',
                            name: 'chkexcise',
                            inputValue: '3',
                            id: 'chkexcise',
                            margin: "10px",
                            handler: function () {
                                Ext.getCmp('chkPersonalPanel').setValue(false);
                            }
                        }
            ]
                        }
                   ]
       }
    ]
};

var VeryfingOffices = {
    xtype: 'fieldset',
    collapsible: true,
    defaults: { anchor: '90%' },
    layout: 'anchor',
    title: 'Verifying Offices',
    items:
    [
       {
           xtype: 'panel',
           width: '100%',
           height: 160,
           title: "ColumnLayout Panel",
           layout: 'column',
           preventHeader: true,
           border: 0,
           frame: true,
           style: 'border:none',
           items: [
         {
             xtype: 'fieldcontainer',
             fieldLabel: '',
             layout: 'anchor',
             defaultType: 'checkboxfield',
             labelWidth: 155,
             items: [
             //                {
             //                    boxLabel: 'IRO',
             //                    name: 'chkiro',
             //                    inputValue: '1',
             //                    id: 'chkiro',
             //                    margin: "10px",
             //                    handler: function () {
             //                        //document.getElementById('cboironame-labelEl').innerHTML = "IRO Name";
             //                        if (Ext.getCmp('chkiso').getValue() == true) {
             //                            //alert(id);
             //                            document.getElementById('cboironame-labelEl').innerHTML = "IRO Name";
             //                            //Ext.getCmp('chkiso').setValue(false);
             //                        } else {
             //                            document.getElementById('cboironame-labelEl').innerHTML = "TSO Name";
             //                            Ext.getCmp('chkiso').setValue(true);
             //                            //Ext.getCmp('chkiso').setValue(false);
             //                        }
             //                    }
             //                },
                             {
                             xtype: 'radiogroup',
                             //labelWidth: 30,
                             width: 150,
                             margin: 5,
                             items: [
                                              { boxLabel: 'TSO', name: 'rb-group1', id: 'rb-group2', inputValue: 1, handler: function () {
                                                  if (Ext.getCmp('rb-group2').getValue() == true) {
                                                      Ext.getCmp('cboverifyingoffice').hide();
                                                  }
                                                  else {
                                                      Ext.getCmp('cboverifyingoffice').show();
                                                  }
                                              }
                                              },
                                              { boxLabel: 'Others', name: 'rb-group1', id: 'rb-group3', checked: true, inputValue: 2 }
                                              ]
                         },
                           {
                               xtype: 'panel',
                               width: 400,
                               height: 150,
                               title: "ColumnLayout Panel",
                               layout: 'column',
                               preventHeader: true,
                               border: 0,
                               frame: true,
                               style: 'border:none',
                               items: [
                            {
                                xtype: "combobox",
                                fieldLabel: 'Select Verifying Office',
                                name: 'cboverifyingoffice',
                                labelWidth: 130,
                                id: 'cboverifyingoffice',
                                width: 370,
                                allowBlank: false,
                                store: new Ext.data.ArrayStore({
                                    id: 0,
                                    fields: ['myId', 'displayText'],
                                    data: [[1, 'कुनै एउटा छानुस'], [2, 'श्री बाणिज्य झापा उद्योग प्रा. लि'], [3, 'श्री कुलेश्वोर गुर कारखाना प्रा. लि']]
                                }),
                                valueField: 'myId',
                                displayField: 'displayText',
                                margin: 5
                            },
                            {
                                xtype: "combobox",
                                fieldLabel: 'IRO Name',
                                name: 'cboironame',
                                labelWidth: 130,
                                id: 'cboironame',
                                width: 370,
                                allowBlank: false,
                                store: new Ext.data.ArrayStore({
                                    id: 0,
                                    fields: ['myId', 'displayText'],
                                    data: [[1, 'कुनै एउटा छान्नुस'], [2, 'भद्रपुर'], [3, 'झापा'], [4, 'इलम'], [5, 'कालिकोट'], [6, 'लहान'], [7, 'गैघट']]
                                }),
                                valueField: 'myId',
                                displayField: 'displayText',
                                margin: 5
                            },
                            {
                                xtype: "combobox",
                                fieldLabel: 'TSO Name',
                                name: 'TSOname',
                                labelWidth: 130,
                                id: 'TSOname',
                                width: 370,
                                allowBlank: false,
                                store: new Ext.data.ArrayStore({
                                    id: 0,
                                    fields: ['myId', 'displayText'],
                                    data: [[1, 'कुनै एउटा छान्नुस'], [2, 'करदाता सेवा कार्यालय,टंगल'], [3, 'करदाता सेवा कार्यालय,भक्तपुर'], [4, 'करदाता सेवा कार्यालय,इलम'], [5, 'करदाता सेवा कार्यालय,कालिकोट'], [6, 'करदाता सेवा कार्यालय,लहान'], [7, 'करदाता सेवा कार्यालय,गैघट']]
                                }),
                                valueField: 'myId',
                                displayField: 'displayText',
                                margin: 5
                            }
                          ]
                           }
            ]
         }]
       }
    ]
};

var regSimple = Ext.create('Ext.form.Panel', {
    url: 'save-form.php',
    frame: true,
    title: 'Step One (Personal E-PAN)',
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

    items: [PersonalInfo, SubmissionForm, VeryfingOffices],

    buttons: [{
        text: 'Next',
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