<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="ASPNETWebApplication.IRD_Application.modules.Test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../extjs/resources/css/ext-all.css" />
    <script type="text/javascript" src="../extjs/ext-all-debug.js"></script>
    
    <link href="../resources/css/default.css" rel="stylesheet" type="text/css" />
    <script src="../extjs/jquery-1.5.1.js" type="text/javascript"></script>
    <script type="text/javascript">        jQuery.noConflict();</script>
    <script type="text/javascript">

        jQuery.noConflict();

        Ext.onReady(function () {

            Ext.QuickTips.init();


            Ext.application({
                name: 'MyApp',
                launch: function () {

                    var store = Ext.create('Ext.data.TreeStore', {
                        root: {
                            expanded: true,
                            children: [
                                                                            { text: "Registration", id: 'R0001', expanded: true, iconCls: 'ico-test',
                                                                                children: [
                                                                                            { text: "Client Registration", id: 'C000001', leaf: true },
                                                                                            { text: "Tameli Type", id: 'C000002', leaf: true }
                                                                                        ]
                                                                            },
                                                                            { text: "XCise", id: 'Rooo2'
                                                                            },
                                                                            { text: "VAT", id: 'R0003', leaf: true },
                                                                            { text: "EPan", id: 'R0004', leaf: true }
                                                                        ]
                        }
                    });

                    var tr = Ext.create('Ext.tree.Panel', {
                        showTitle: false,
                        border: false,
                        minHeight: 736,
                        store: store,
                        anchor: '75% 20%',
                        rootVisible: false,
                        listeners: {
                            itemclick: function (view, rec, item, index, eventObj) {
                                var idd = rec.data.id;
                                Ext.get('mainContent').update('');
                                if (idd.indexOf("C") >= 0) {

                                    jQuery('#irdTitle').html(rec.data.text);
                                    var js = document.createElement('script');
                                    js.type = "text/javascript";
                                    var scriptName = 'registration/' + rec.data.text + '.js';
                                    js.src = scriptName;
                                    document.body.appendChild(js);
                                }
                            }
                        }
                    });


                    Ext.create('Ext.Viewport', {
                        layout: {
                            type: 'border',
                            padding: 5
                        },
                        defaults: {
                            split: true
                        },
                        items: [{
                            region: 'west',
                            collapsible: true,
                            title: 'Navigation',
                            split: true,

                            width: '30%',
                            minWidth: 100,
                            minHeight: 140,
                            items: [tr]
                        },
                        {
                            title: '<div id="irdTitle">Title</div>',
                            layout: 'anchor',
                            region: 'center',
                            margins: '5 5 0 0',
                            html: '<div id="mainContent"></div>'
                        }]

                    });

                    Ext.define('TameliTypes', {
                        extend: 'Ext.data.Model',
                        fields: ['TameliTypeID', 'TameliTypeName']
                    });



                    //                    var store = new Ext.data.Store({
                    //                        url: 'registration/handlers/LoadUsers.ashx',
                    //                        reader: new JsonReader({
                    //                            root: 'root'
                    //                        }, [
                    //                              { name: 'TameliTypeID', mapping: 1 },
                    //                              { name: 'TameliTypeName', mapping: 0 }
                    //                            ])
                    //                    });

                    var store1 = Ext.create('Ext.data.Store', {
                        model: 'TameliTypes',
                        proxy: {
                            type: 'ajax',
                            url: 'registration/handlers/LoadUsers.ashx',
                            reader: {
                                type: 'json'
                            }
                        }
                        , autoLoad: true
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


                    //                                        // sample static data for the store
                    //                                        var myData = [];
                    //                                        Ext.Ajax.timeout = 500000;
                    //                                        Ext.Ajax.request({
                    //                                            url: 'registration/handlers/LoadUsers.ashx',

                    //                                            success: function (response) {
                    //                                                             var text = response.responseText;
                    //                                                             myData=text;
                    //                                                             alert(myData);
                    //                                                             var store = Ext.create('Ext.data.ArrayStore', {
                    //                                                                fields: [
                    //                                                                                               { name: 'TameliTypeName' },
                    //                                                                                               { name: 'TameliTypeID', type: 'int' }
                    //                                                                                            ],
                    //                                                                data: myData
                    //                                                      }); 
                    //                                        // create the Grid
                    //                                        var grid = Ext.create('Ext.grid.Panel', {
                    //                                            store: store,
                    //                                            stateful: true,
                    //                                            stateId: 'stateGrid',
                    //                                            columns: [
                    //                                                    {
                    //                                                        text: 'TameliTypeID',
                    //                                                        flex: 1,
                    //                                                        sortable: true,
                    //                                                        dataIndex: 'TameliTypeID'
                    //                                                    },
                    //                                                    {
                    //                                                        text: 'TameliTypeName',
                    //                                                        flex: 2,
                    //                                                        sortable: true,
                    //                                                        dataIndex: 'TameliTypeName'
                    //                                                    }
                    //                                                ],
                    //                                            height: 350,
                    //                                            title: 'Tameli List',
                    //                                            renderTo: Ext.get('mainContent'),
                    //                                            viewConfig: {
                    //                                                stripeRows: true
                    //                                            }
                    //                                        });
                    //                            // process server response here
                    //                        },
                    //                        failure: function (response) {
                    //                            alert('ajax request failed');
                    //                            // process server response here
                    //                           }
                    //                    });                          

                    //                    Ext.Ajax.timeout = 500000;
                    //                    Ext.Ajax.request({
                    //                        url: 'registration/handlers/LoadUsers.ashx',

                    //                        success: function (response) {
                    //                            var text = response.responseText;
                    //                            alert(text);
                    //                            // process server response here
                    //                        },
                    //                        failure: function (response) {
                    //                            alert('ajax request failed');
                    //                            // process server response here
                    //                        }
                    //                    });

                }
            });
        });
    </script>
</head>
<body>
<asp:ScriptManager ID="ssd" runat="server">
<Services>
<asp:ServiceReference Path="" />
</Services>
</asp:ScriptManager>
   
</body>
</html>
