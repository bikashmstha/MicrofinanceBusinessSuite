var store = Ext.create('Ext.data.TreeStore', {
    root: {
        expanded: true,
        children: [
                                                            { text: "Registration", id: 'SP1', leaf: true },
                                                            { text: "XCise", id: 'SP2', expanded: true, children: [
                                                                { text: "book report", id: 'SP3', leaf: true },
                                                                { text: "alegrbra", id: 'SP4', leaf: true }
                                                            ]
                                                            },
                                                            { text: "buy lottery tickets", id: 'SP5', leaf: true }
                                                        ]
    }
});

var tr = Ext.create('Ext.tree.Panel', {
    title: 'Simple Tree',
    width: 200,
    height: 150,
    store: store,
    renderTo: Ext.get('mainContent'),
    rootVisible: false
});