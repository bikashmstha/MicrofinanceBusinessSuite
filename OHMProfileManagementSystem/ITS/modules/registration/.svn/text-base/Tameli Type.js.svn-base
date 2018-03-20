
Ext.define('TameliTypes', {
    extend: 'Ext.data.Model',
    fields: ['TameliTypeID', 'TameliTypeName']
});
var store1 = Ext.create('Ext.data.Store', {
    model: 'TameliTypes',
    proxy: {
        type: 'ajax',
        url: 'registration/handlers/LoadUsers.ashx',
        reader: {
            type: 'json'
        }
    },
    autoLoad: true
});

// create the Grid
var grid = Ext.create('Ext.grid.Panel', {
    store: store1,
    stateful: true,
    stateId: 'stateGrid',
    columns: [
                                                    {
                                                        text: 'TameliTypeID',
                                                        flex: 1,
                                                        sortable: true,
                                                        dataIndex: 'TameliTypeID'
                                                    },
                                                    {
                                                        text: 'TameliTypeName',
                                                        flex: 2,
                                                        sortable: true,
                                                        dataIndex: 'TameliTypeName'
                                                    }
                                                ],
    height: 350,
    title: 'Tameli List',
    renderTo: Ext.get('mainContent'),
    viewConfig: {
        stripeRows: true
    }
});

