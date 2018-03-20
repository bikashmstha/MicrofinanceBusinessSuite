function GoEvent(pPagename, pTitleBarText) {
    Ext.get('mainContent').update('');
    Ext.get('irdTitle').update(pTitleBarText);
    var js = document.createElement('script');
    js.type = "text/javascript";
    var scriptName = 'registration/' + pPagename;
    js.src = scriptName;
    document.body.appendChild(js);
}