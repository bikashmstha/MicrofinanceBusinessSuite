var store1 = Ext.create('Ext.data.JsonStore', {
    model: 'TameliTypes',
    autoLoad: true,
    proxy: {
        type: 'ajax',
        url: 'registration/handlers/LoadUsers.ashx',
        reader: {
            type: 'json'
        }
    }
});

var grid = Ext.create('Ext.grid.Panel', {
    store: store1,
    stateful: true,
    stateId: 'stateGrid',
    columns: [
                                                    {
                                                        text: 'SN',
                                                        flex: 1,
                                                        sortable: true,
                                                        dataIndex: 'fname'
                                                    },
                                                    {
                                                        text: 'Name',
                                                        flex: 2,
                                                        sortable: true,
                                                        dataIndex: 'mname'
                                                    },
                                                    {
                                                        text: 'Submission No',
                                                        flex: 2,
                                                        sortable: true,
                                                        dataIndex: 'lname'
                                                    },
                                                    {
                                                        text: 'Date',
                                                        flex: 2,
                                                        sortable: true,
                                                        dataIndex: 'TABLE_ID'
                                                    }
                                                ],
    height: 200,
    preventHeader: true,
    margin: 5,
    renderTo: Ext.get('mainContent'),
    viewConfig: {
        stripeRows: true
    },
    dockedItems: [{
        xtype: 'pagingtoolbar',
        store: store1,   // same store GridPanel is using
        dock: 'bottom',
        displayInfo: true,
        displayMsg: 'Displaying topics {0} - {1} of {2}',
        emptyMsg: 'No insurers to display'
    }]
});

var UnverifiedSubmissionGrid = {
    xtype: 'fieldset',
    collapsible: true,
    defaults: { anchor: '100%' },
    layout: 'anchor',
    title: 'Unverified Submission',
    items:
    [
        grid
    ]
};
var UnverifiedSubmission = {
    xtype: 'fieldset',
    collapsible: true,
    defaults: { anchor: '100%' },
    layout: 'anchor',
    height: 210,
    title: '',
    items:
    [{
        xtype: 'panel',
        width: 100,
        defaults: { anchor: '70%' },
        height: 190,
        title: "ColumnLayout Panel",
        layout: 'anchor',
        preventHeader: true,
        border: 0,
        frame: true,
        style: 'border:none',
        items: [{
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
                        xtype: "datefield",
                        fieldLabel: 'UserName',
                        name: 'txtUsername',
                        labelWidth: 150,
                        id: 'first',
                        width: 400,
                        allowBlank: false,
                        // emptyText: 'Enter Your First Name...',
                        margin: 5
                    }]
        },
        {
            xtype: 'radiogroup',
            fieldLabel: 'Verify',
            labelWidth: 150,
            margin: 8,
            width: 100,
            // Arrange radio buttons into two columns, distributed vertically
            columns: 2,
            vertical: true,
            items: [
            { boxLabel: 'Yes', name: 'rb', inputValue: '1' },
            { boxLabel: 'No', name: 'rb', inputValue: '2', checked: true }
        ]
        },
       {
           xtype: 'panel',
           width: 800,
           height: 110,
           title: "ColumnLayout Panel",
           layout: 'column',
           preventHeader: true,
           border: 0,
           frame: true,
           style: 'border:none',
           items: [{
               xtype: "textfield",
               fieldLabel: 'Remarks',
               name: 'txtremarks',
               labelWidth: 150,
               id: 'txtremarks',
               width: 600,
               height: 90,
               allowBlank: false,
               // emptyText: 'Enter Your First Name...',
               margin: 5
           }]
       }]
    }]
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

    items: [UnverifiedSubmissionGrid, UnverifiedSubmission],

    buttons: [{
        text: 'Next'
    },
     {
         text: 'Cancel'
     }]
});