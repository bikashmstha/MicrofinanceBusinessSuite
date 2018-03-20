
// Create a variable to hold our EXT Form Panel. 
// Assign various config options as seen.
var login = new Ext.FormPanel({
    labelWidth: 80,
    url: 'registration/handlers/Login.ashx',
    frame: true,
    title: 'LoginPage',
    defaultType: 'textfield',
    preventHeader: true,
    monitorValid: true,
    // Specific attributes for the text fields for username / password. 
    // The "name" attribute defines the name of variables sent to the server.
    items: [{
        fieldLabel: 'Submission No.',
        name: 'submissionNo',
        id: 'submissionNo',
        itemId: 'submissionNo',
        allowBlank: false
    },
            {
                fieldLabel: 'Username',
                name: 'loginUsername',
                id: 'loginUsername',
                itemId: 'loginUsername',
                allowBlank: false
            },
            {
                fieldLabel: 'Password',
                name: 'loginPassword',
                id: 'loginPassword',
                itemId: 'loginPassword',
                inputType: 'password',
                allowBlank: false
            }],

    // All the magic happens after the user clicks the button     
    buttons: [{
        text: 'Login',
        formBind: true,
        // Function that fires when user clicks the button
        handler: function () {
            Ext.Ajax.request({
                url: 'registration/handlers/Login.ashx',
                params: {
                    submissionNo: Ext.getCmp('submissionNo').value,
                    loginUsername: Ext.getCmp('loginUsername').value,
                    loginPassword: Ext.getCmp('loginPassword').value
                },
                success: function (response) {
                    var text = JSON.parse(response.responseText);
                    alert(text.success);
                    // process server response here
                },
                failure: function (response) {
                    var text = JSON.parse(response.responseText);
                    Ext.Msg.alert();
                }
            });
            //                        login.getForm().submit({
            //                            method: 'POST',

            //                            success: function (response) {
            //                                var text = JSON.parse(response.responseText);
            //                                                   alert(text.success);
            //                            },
            //                            failure: function (form, action) {
            //                                if (action.failureType == 'server') {
            //                                    Ext.util.JSON.decode()
            //                                    obj = Ext.decode(action.response.responseText);
            //                                    Ext.Msg.alert('Login Failed!', obj.errors.reason);
            //                                } else {
            //                                    Ext.Msg.alert('Warning!', 'Authentication server is unreachable : ' + action.response.responseText);
            //                                }
            //                                login.getForm().reset();
            //                            }
            //                        });
        }
    }]
});

login.render(Ext.get('mainContent'));
