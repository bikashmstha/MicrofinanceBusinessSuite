Ext.Direct.addProvider(Sample.Remote.GridHandler);

Ext.onReady(function(){

    var store = new Ext.data.DirectStore({
        autoLoad: true,
        remoteSort: false,
        directFn: Sample.Grid.Load,
        paramOrder: ['sort', 'dir'],
        idProperty: 'TameliTypeID',
        totalProperty: 'total',
        root: 'data',
        sortInfo: {
            field: 'name',
            direction: 'ASC'
        },
        fields: [{
            type: 'int',
            name: 'TameliTypeID'
        }, {
            type: 'string',
            name: 'TameliTypeName'
        }]
    });
    
    var grid = new Ext.grid.GridPanel({
        renderTo: Ext.getBody(),
        width: 700,
        title: 'Simple Grid with remote sorting',
        height: 400,
        store: store,
        autoExpandColumn: 'name',
        columns: [{
            header: 'TameliTypeName', dataIndex: 'TameliTypeName', id: 'TameliTypeID', sortable: true
        },{
            header: 'TameliTypeID', dataIndex: 'TameliTypeID', width: 100, sortable: true
        }s]
    });
    
});