/// <reference path="ext-all-debug-w-comments.js" />

var PersonalInfo = {
    xtype: 'fieldset',
    collapsible: true,
    defaults: { anchor: '90%' },
    layout: 'anchor',
    title: 'Submission No',
    items: [{
        xtype: 'panel',
        width: '100%',
        height: 40,
        title: "ColumnLayout Panel",
        layout: 'column',
        preventHeader: true,
        border: 0,
        frame: true,
        style: 'border:none',
        items: [{
            xtype: "textfield",
            fieldLabel: 'UserName',
            name: 'txtUsername',
            labelWidth: 150,
            width: 400,
            allowBlank: false,
            margin: 5
        }]
    }, {
        xtype: 'panel',
        width: '100%',
        height: 40,
        title: "ColumnLayout Panel",
        layout: 'column',
        preventHeader: true,
        border: 0,
        frame: true,
        style: 'border:none',
        items: [{
            xtype: "textfield",
            fieldLabel: 'Password',
            id: 'pass',
            name: 'txtPassword',
            inputType: 'password',
            labelWidth: 150,
            width: 400,
            allowBlank: false,
            margin: 5
        }]
    }, {
        xtype: 'panel',
        width: '100%',
        height: 40,
        title: "ColumnLayout Panel",
        layout: 'column',
        preventHeader: true,
        border: 0,
        frame: true,
        style: 'border:none',
        items: [{
            xtype: "textfield",
            fieldLabel: 'Re-Password',
            id: 'rePass',
            name: 'txtRepassword',
            labelWidth: 150,
            inputType: 'password',
            width: 400,
            allowBlank: false,
            margin: 5

        }]
    }, {
        xtype: 'panel',
        width: '100%',
        height: 40,
        title: "ColumnLayout Panel",
        layout: 'column',
        preventHeader: true,
        border: 0,
        frame: true,
        style: 'border:none',
        items: [{
            xtype: "textfield",
            fieldLabel: 'Contact No',
            name: 'txtContactNo',
            labelWidth: 150,
            width: 400,
            allowBlank: false,
            margin: 5
        }]
    }, {
        xtype: 'panel',
        width: '100%',
        height: 40,
        title: "ColumnLayout Panel",
        layout: 'column',
        preventHeader: true,
        border: 0,
        frame: true,
        style: 'border:none',
        items: [{
            xtype: "textfield",
            fieldLabel: 'Email-ID',
            name: 'txtemail',
            labelWidth: 150,
            vtype: 'email',
            width: 400,
            allowBlank: false,
            margin: 5
        }]
    }]
};

var SubmissionForm = {
    xtype: 'fieldset',
    collapsible: true,
    defaults: { anchor: '90%' },
    layout: 'anchor',
    title: 'Submission For',
    items:
    [{
        xtype: 'panel',
        width: '100%',
        height: 40,
        title: "ColumnLayout Panel",
        layout: 'column',
        preventHeader: true,
        border: 0,
        frame: true,
        style: 'border:none',
        items: [{
            xtype: 'fieldcontainer',
            fieldLabel: '',
            layout: 'column',
            defaultType: 'checkboxfield',
            labelWidth: 155,
            items: [{
                boxLabel: 'Personal Panel',
                name: 'chkPersonalPanel',
                inputValue: '1',
                id: 'chkPersonalPanel',
                margin: "10px",
                checked: true,
                handler: function () {
                    var _strPersonalChecked = Ext.getCmp('chkPersonalPanel').getValue();
                    if (_strPersonalChecked == true) {
                        Ext.getCmp('chkincomeTax').setValue = false;
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
                    var _strPersonalChecked = Ext.getCmp('chkincomeTax').getValue();
                    if (_strPersonalChecked == true) {
                        Ext.getCmp('chkPersonalPanel').checked = false;
                    }
                }
            }, {
                boxLabel: 'Vat',
                name: 'chkvat',
                inputValue: '3',
                id: 'chkvat',
                margin: "10px"
                //                            handler: function () {
                //                                alert('df');
                //                            }
            }, {
                boxLabel: 'Excise',
                name: 'chkexcise',
                inputValue: '3',
                id: 'chkexcise',
                margin: "10px"
                //                            handler: function () {
                //                                alert('df');
                //                            }
            }]
        }]
    }]
};

var VeryfingOffices = {
    xtype: 'fieldset',
    collapsible: true,
    defaults: { anchor: '90%' },
    layout: 'anchor',
    title: 'Verifying Offices',
    items: [{
        xtype: 'panel',
        width: '100%',
        height: 40,
        title: "ColumnLayout Panel",
        layout: 'column',
        preventHeader: true,
        border: 0,
        frame: true,
        style: 'border:none',
        items: [{
            xtype: 'fieldcontainer',
            fieldLabel: '',
            layout: 'column',
            defaultType: 'checkboxfield',
            labelWidth: 155,
            items: [{
                boxLabel: 'IRO',
                name: 'chkiro',
                inputValue: '1',
                id: 'chkiro',
                margin: "10px",
                handler: function () {
                    //document.getElementById('cboironame-labelEl').innerHTML = "IRO Name";
                    if (Ext.getCmp('chkiso').getValue() == true) {
                        //alert(id);
                        document.getElementById('cboironame-labelEl').innerHTML = "IRO Name";
                        //Ext.getCmp('chkiso').setValue(false);
                    } else {
                        document.getElementById('cboironame-labelEl').innerHTML = "TSO Name";
                        Ext.getCmp('chkiso').setValue(true);
                        //Ext.getCmp('chkiso').setValue(false);
                    }
                }
            }, {
                boxLabel: 'TSO',
                margin: "10px",
                name: 'chkiso',
                inputValue: '2',
                checked: false,
                id: 'chkiso',
                handler: function () {
                    //document.getElementById('cboironame-labelEl').innerHTML = "TSO Name";
                    if (Ext.getCmp('chkiso').getValue() == true) {
                        //alert(id);
                        document.getElementById('cboIRON-labelEl').innerHTML = "TSO Name";
                        // Ext.getCmp('chkiro').setValue(false);
                    } else {
                        document.getElementById('cboIRON-labelEl').innerHTML = "IRO Name";
                        Ext.getCmp('chkiro').setValue(true);
                        Ext.getCmp('chkiso').setValue(false);
                    }
                }
            }, {
                boxLabel: 'Others',
                name: 'chkothers',
                checked: true,
                inputValue: '3',
                id: 'chkothers',
                margin: "10px",
                handler: function () {
                    if (Ext.getCmp('chkothers').getValue() == true) {
                        //alert(id);
                        Ext.get('cboVO').show();
                    } else {
                        Ext.get('cboVO').hide();
                    }
                }

            }]
        }]
    }, {

        xtype: 'panel',
        width: '100%',
        height: 40,
        title: "ColumnLayout Panel",
        layout: 'column',
        preventHeader: true,
        border: 0,
        frame: true,
        style: 'border:none',
        items: [{
            xtype: "combobox",
            fieldLabel: 'Verifying Office',
            name: 'cboVO',
            labelWidth: 150,
            id: 'cboVO',
            width: 400,
            allowBlank: false,
            emptyText: 'Select',
            margin: 5,
            store: new Ext.data.ArrayStore({
                id: 0,
                fields: ['id', 'name'],
                data: [[1, 'PCS'], [2, 'IRD']]
            }),
            queryMode: 'local',
            typeAhead: true,
            valueField: 'id',
            displayField: 'name',
            forceSelection:true,
            triggerAction:'all'

        }]

    }, {

        xtype: 'panel',
        width: '100%',
        height: 40,
        title: "ColumnLayout Panel",
        layout: 'column',
        preventHeader: true,
        border: 0,
        frame: true,
        style: 'border:none',
        items: [{

            xtype: "combobox",
            fieldLabel: 'IRO Name',
            name: 'cboIRON',
            labelWidth: 150,
            id: 'cboIRON',
            width: 400,
            allowBlank: false,
            emptyText: 'Select',
            margin: 5,
            store: new Ext.data.ArrayStore({
                id: 0,
                fields: ['id', 'name'],
                data: [[1, 'PCS'], [2, 'IRD']]
            }),
            queryMode: 'local',
            typeAhead: true,
            valueField: 'id',
            displayField: 'name',
            forceSelection: true,
            triggerAction: 'all'

        }]
    }]
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

    items: [PersonalInfo, SubmissionForm, VeryfingOffices],

    buttons: [{
        text: 'Submit',
        scope: this,
        handler: function () {
            var val = this.regSimple.getForm().getValues(true);
            alert(val);
        }

    }, {
        text: 'Cancel',
        handler: function () {
//            this.regSimple.getform().reset();
        }
    }, {
        text: 'Next',
        handler: function () {
            var _strCheckedPersonalPnl = Ext.getCmp('chkPersonalPanel').getValue();

            if (_strCheckedPersonalPnl == true) {
                GoEvent('TaxPayer Registration.js', 'Step');
            } else {
                GoEvent('Step Three.js', 'Step');
            }
        }
    }]
});