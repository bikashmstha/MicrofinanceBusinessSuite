/*
 * File: app/view/AppealMAWindow.js
 *
 * This file was generated by Sencha Architect version 2.1.0.
 * http://www.sencha.com/products/architect/
 *
 * This file requires use of the Ext JS 4.0.x library, under independent license.
 * License of Sencha Architect does not include license for Ext JS 4.0.x. For more
 * details see http://www.sencha.com/license or contact license@sencha.com.
 *
 * This file will be auto-generated each and everytime you save your project.
 *
 * Do NOT hand edit this file.
 */

Ext.define('MyApp.view.AppealMAWindow', {
    extend: 'Ext.window.Window',

    height: 250,
    id: 'AppealMAWindow',
    itemId: 'AppealMAWindow',
    width: 420,
    autoScroll: true,
    title: 'कर निर्धरण आदेश नं. सूचि',

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'gridpanel',
                    itemId: 'appealGrdMA',
                    width: 400,
                    autoScroll: true,
                    title: '',
                    store: 'AppealMA',
                    viewConfig: {

                    },
                    columns: [
                        {
                            xtype: 'rownumberer',
                            width: 30,
                            dataIndex: 'SeqNo',
                            text: 'क्र.सं.'
                        },
                        {
                            xtype: 'gridcolumn',
                            width: 120,
                            dataIndex: 'MANo',
                            text: 'कर निर्धरण आदेश नं.'
                        },
                        {
                            xtype: 'gridcolumn',
                            width: 120,
                            dataIndex: 'EffDate',
                            text: 'कर निर्धरण मिति'
                        },
                        {
                            xtype: 'gridcolumn',
                            width: 125,
                            dataIndex: 'TotMaAmount',
                            text: 'कर निर्धरण भएको रकम'
                        }
                    ],
                    listeners: {
                        itemdblclick: {
                            fn: me.onGridpanelItemDblClick,
                            scope: me
                        },
                        beforerender: {
                            fn: me.onAppealGrdMABeforeRender,
                            scope: me
                        }
                    }
                }
            ]
        });

        me.callParent(arguments);
    },

    onGridpanelItemDblClick: function(tablepanel, record, item, index, e, options) {

        var win=Ext.getCmp('AppealMAWindow');
        //console.log(win);

        var maNo=win.maNo;

        var grd=Ext.ComponentQuery.query('#appealGrdMA')[0];
        var selection=grd.getSelectionModel().getSelection()[0];
        var selectedIndx= grd.getStore().indexOf(selection);

        var storeMA=grd.getStore();

        maNo.setValue(storeMA.getAt(selectedIndx).data.MANo);

        win.close();
    },

    onAppealGrdMABeforeRender: function(abstractcomponent, options) {
        /*var grid = Ext.ComponentQuery.query('#appealGrdMA')[0];

        grid.columns[2].renderer = function(value, metaData, record, rowIndex, colIndex, store, view) {
        var temp="";   

        var strFilPeriod = Ext.getStore("FilingPeriodStore");                
        var index = strFilPeriod.find('FilPeriod',value);
        var rec = strFilPeriod.getAt(index);

        var strPeriod = Ext.getStore("Period");

        var items=Ext.getStore('FilingPeriodStore').data.items;    


        for(var i=0;i<items.length;i++)
        {

        if(items[i].data.FilPeriod === value)
        {
        temp=items[i].data.FilPeriodDesc;
        break;
        }        
        }   


        // console.log("rec",rec);

        if(rec !== false && rec !== undefined)
        {
            strPeriod.loadData(rec.data.Period);
        } 


        return temp;
    };


    grid.columns[3].renderer = function(value, metaData, record, rowIndex, colIndex, store, view) {
        var temp="";    


        var items=Ext.getStore('Period').data.items;


        for(var i=0;i<items.length;i++)
        {

            if(items[i].data.Period==value)
            {
                temp=items[i].data.PeriodDesc;
                break;
            }        
        }


        return temp;
    };
    */
    }

});