function getAppProvider(appName){
	var modules=new Array("RAS", "EIMS","RAS_REPORT","EIMS_REPORT");
	var modules1 = new Array("Central Function", "VAT", "IT", "Excise", "REG", "Verification", "Security", "Lookup_Maintenance", "VAT_Reports");
    
    if(modules.indexOf(appName)>=0)
       return "info";
    
    if(modules1.indexOf(appName)>=0)
        return "pcs";
    
}

function getCurrentProvider(){
    var ret = { provider: "pcs" };
    return ret;
}

function getProviderUrl(provider){
    if (provider == "pcs")
        return "http://officerportal.ird.gov.np/main/app.html?token=";//+MyTocken.Tocken;
    else
        return "http://officerportal.ird.gov.np:800/main/app.html?token="; // +MyTocken.Tocken;
}

/*

function loadDynamicPanel(data){
    Ext.getCmp('CntMainPage').removeAll();
    ALERT
    var pnlDynamic = Ext.create('MyApp.view.' + data.link, {
        autoScroll: true,
        height: 1000,
        flex: 1
    });

    var pnlToRender = Ext.getCmp('CntMainPage');
    pnlToRender.add(pnlDynamic);
}

function loadWindow(){
    if(Ext.getCmp('MainWindow'))
    Ext.getCmp('MainWindow').removeAll();
    var pnlDynamic = Ext.create('MyApp.view.MainMenu', {
        autoScroll: true,
        height: 1000,
        flex: 1
    });    
    if(Ext.getCmp('MainWindow')){
    var pnlToRender = Ext.getCmp('MainWindow');
    pnlToRender.add(pnlDynamic);
    }
}*/

function getParameterByName(name) {
    name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
    var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
        results = regex.exec(location.search);
    return results == null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
}

var MyTocken='';

function messagebox(title, message, icon) {
    var rqdIcon = Ext.MessageBox.INFO;
    if (icon == 1)
        rqdIcon = Ext.Msg.ERROR;
    else if (icon == 2)
        rqdIcon = Ext.Msg.WARNING;

    Ext.Msg.show({
        title: title,
        msg: message,
        buttons: Ext.MessageBox.OK,
        icon: rqdIcon
    });

}

function showMessage(title, message, icon) {
    if (!icon) {
        if (title.toString().toUpperCase().indexOf("ERROR") >= 0)
            icon = 1;
    }
    messagebox(title, message, icon);
}