var siteMaparray = new Array();
siteMaparray[0] ="Document Management System@@NULL";
siteMaparray[1] ="Central Function@@NULL";
siteMaparray[2] ="Look Up Maintenance@@NULL";

var bCumb="";
 function getPNode(nnode)
 {
 //alert(nnode.data.text);
 var separator=  bCumb?"$":"";
 
	 if(nnode.parentNode)
	 {
		bCumb=bCumb + separator+nnode.data.text;
		getPNode(nnode.parentNode)
	 }
	 else
	 {
	  bCumb=bCumb+ separator+nnode.data.text;
	 }
      return bCumb;
 }

var AppWakeUpJSON=null;

var bCrumb="";

function setBreadcrumb(parentNode)
{
	if(parentNode.parentNode)
	{
		setBreadcrumb(parentNode.parentNode)
   }
	else
	{
	bCrumb=bCrumb+">>"+parentNode.data.text;
	}
	return bCrumb;

}

var AppWakeUpJSON=null;

Ext.Ajax.request({
		url: '../Handlers/Common/DateHandler.ashx?method=GetDates',
		params:{},
		success: function (result, request ) {
			AppWakeUpJSON=result.responseText;
		},
		failure: function ( result, request ) {
				//msg('StartUp Error..','Please refresh your Browser to load application again');
		}
});

function DynamicUI(obj, callback,ExtraParam)  //(ControllerList,pTitle_And_link)
{
   		var pTitle = obj.pageTitle;
		var plink  = obj.menuLink;
		var controllerList = [plink];
		
		//var controller = ControllerManager.get(plink);//I believe you have some controller manager, similar to Sencha's Ext.ControllerManager
		/*if(controller){
			alert("Exits");
		}
		else
		{
			alert(" controller does not exists !");
		}
		*/
		ManageSiteMap(pTitle,plink);
		if(plink ===  "")
        {
			Ext.getCmp('CntMainPage').removeAll();
			var pnlDynamic = Ext.create('Ext.panel.Panel',{
				flex:1,
    			id: 'PnlError',
   				itemId: 'PnlError',
    			title: 'Link "Property" is Missing',
				loader: {url: 'resources/linkMissing.html',autoLoad: true}
			});
			var pnlToRender = Ext.getCmp('CntMainPage');
			pnlToRender.add(pnlDynamic);
			
			return;
		}
		else if(controllerList === undefined || controllerList[0] === "")
		{
		    msg('WARNING','Controller not found in Controller Manager');
		    return;						
		}	
		else
		{
			controllerList.push("MenuController") ;
			controllerList.push("LoginSecurity") ;
		}
		
	Ext.Loader.setConfig({enabled:true});
	
	Ext.application({
	    name:'MyApp',
		controllers:controllerList,	
		launch:function(){
				 // modified by bikash/rAZ
					/*var xtraParam=ExtraParam?ExtraParam:{};					    					
					xtraParam.App = this;						
					loadDynamicPanel(pTitle,plink,xtraParam);					
					*/
					//ExtraParam.App = this;
					loadDynamicPanel(pTitle,plink,ExtraParam);
		            Ext.override(Ext.LoadMask, {
					     onHide: function() {
					          this.callParent();
					     }
					});
					if(callback){callback()};					
					
					//by RAZ
					MyApp.app = this;
		}
	});
}

function GetQueryStringParams(sParam)
{
    var sPageURL = window.location.search.substring(1);
    var sURLVariables = sPageURL.split('&');
    for (var i = 0; i < sURLVariables.length; i++) 
    {
        var sParameterName = sURLVariables[i].split('=');
        if (sParameterName[0] == sParam) 
        {
            return sParameterName[1];
        }
    }
}


function loadDynamicPanel(pTitle,plink,ExtraParam)
{
	//window.history.pushState({u:1}, 'Title', 'app.html?panel='+Ext.encode(plink).replace(/"/g,'')+'&title='+Ext.encode(pTitle).replace(/"/g,''));
	//try
	//{	
		Ext.getCmp('CntMainPage').removeAll();
		var pnlDynamic = Ext.create('MyApp.view.'+plink,{
			autoScroll: true,
			height:1000,
			//title:record.data.text,
			//param:record,
			flex:1
		});

        pnlDynamic.extraParam = ExtraParam;
		//console.log("pnl",pnlDynamic);
		ChangeTitleAccordingly(pTitle);
		/*
		if(plink!=siteMaparray[0].split('@@')[1])
		{
			ManageSiteMap(pTitle,plink);
		}
		*/
		//pnlDynamic.extraParam = {a:'bcd'};
		
		var pnlToRender = Ext.getCmp('CntMainPage');
		pnlToRender.add(pnlDynamic);	
	//}
	/*catch(Error)
	{		
		Ext.getCmp('CntMainPage').removeAll();
		//console.log("error" ,Error.message);
		var pnlDynamic = Ext.create('Ext.panel.Panel',{
		flex:1,
		id: 'PnlError',
		itemId: 'PnlError',
		title: '404 Page Not Found..',
		//frame:true,
			loader: {url: 'resources/404.html',
			        autoLoad: true,
				    callback: function() {
					
					if(Error.message == "undefined")
						errMsg = "Page Not Found..."
				    else
						errMsg = Error.message;
					
					document.getElementById('ErrorLog').innerHTML='Error Description:-  ' + errMsg;
					
				}}
		});
		var pnlToRender = Ext.getCmp('CntMainPage');
		pnlToRender.add(pnlDynamic);
		return;
	}*/

}

/*The function is about Managing sitemap*/
function ManageSiteMap(pTitle,plink)
{
	try
	{
	
	   var breadcumb = "Document Management System Menus >>" + pTitle;
		Ext.getCmp('CntSiteMapPath').update(breadcumb);
		//Ext.getCmp('CntSiteMapPath').update('Integrated Tax Menus >> Value Added Tax System >> Preliminary Assessment');
	}catch(err)
	{
		return true;	
	}
}

function ManageSiteMap1(pTitle,plink)
{
	try
	{
	
    	siteMaparray.splice(2,1); 
		siteMaparray.splice(0,0,pTitle+'@@'+plink);
		document.getElementById('CntSiteMapPath').innerHTML="";
		for(var index=0;index<3;index++)
		{
			var siteMapSignleArray = siteMaparray[index].split('@@');
			var text        = siteMapSignleArray[0];
			var link        = siteMapSignleArray[1];

			var UpdateLinkText = document.getElementById('CntSiteMapPath').innerHTML+
								"<a id='sitemap"+index+"' class='SiteMapLink' title='"+text+"' onclick=\"loadDynamicPanel('"+text+'@@'+link+"');\">"+text+" >></a> ";
			Ext.getCmp('CntSiteMapPath').update(UpdateLinkText);
		}	
	}catch(err)
	{
		return true;	
	}
}


/*Create Cookies Function*/
/*W Stands Form Write and C Stands from Cookies*/
function WC(CookieName,CookieValue)
{
	Ext.util.Cookies.set(CookieName,Ext.encode(CookieValue));
}

/*Reading Cookies Function*/
/*R Stands Form Read and C Stands from Cookies*/
function RC(CookieName)
{
	return (Ext.decode(Ext.util.Cookies.get(CookieName)));
}


function ChangeTitleAccordingly(pageTitle)
{
		document.title='..::Welcome to Document Management System [ '+pageTitle+' ]'
}

function getJson(str) {
    var myItems = str.getRange();
    var myJson = [];

    for (var i in myItems) {
        myJson.push(myItems[i].data);
    }

    return myJson;
}

function getEngTodayDate()
{
	var currentTime = new Date()
	var month = currentTime.getMonth() + 1
	var day = currentTime.getDate()
	var year = currentTime.getFullYear()
	return month + "/" + day + "/" + year;
}
/*
function msg(title,message)
{
	var rqdIcon = Ext.MessageBox.INFO;

	if(title == "FAILURE")
		rqdIcon = Ext.Msg.ERROR;
	else if(title == "WARNING")
		rqdIcon = Ext.Msg.WARNING;

	Ext.Msg.show({
		title: title,
		msg: message ,
		buttons: Ext.MessageBox.OK,
		icon: rqdIcon
	});

}
*/
function watiMsg(message)
{
	var wait = Ext.MessageBox.wait(message);
	return wait;
}

function waitMsg(message)
{
	var wait = Ext.MessageBox.wait(message);
	return wait;
}

function validateNepDate(date)
{	
	var errDate = "";
	var  dateElement = date.split(".");
	
	if(dateElement.length == 3)
	{
		Day = dateElement[2];
		Month = dateElement[1];
		Year = dateElement[0];
		
		if((isNaN(Year)=== true))
			errDate = "Enter numeric for year(YYYY.MM.DD)";
		else if(isNaN(Month)=== true) 
			errDate = "Enter numeric for month(YYYY.MM.DD)";
		else if(isNaN(Day) === true)
			 errDate = "Enter numeric for day(YYYY.MM.DD)";
		else if(Year.length!== 4) 
			 errDate = "Enter year of four characters (YYYY.MM.DD)";
		else if(Month.length!== 2) 
			 errDate = "Enter month of two characters (YYYY.MM.DD)";
		else if(Day.length!== 2) 
			 errDate = "Enter day of two characters (YYYY.MM.DD)";
		else if(Month<1 || Month>12) 
			errDate = "Enter month between 1 to 12 ";
		else if(Day<1 || Day>32)
			errDate = " Enter day between 1 to 32";  		 
	}
	else
		errDate = "Enter date in YYYY.MM.DD format";
		
		
    return errDate;
	
}

function getNumUnicode(val)
{            
	var text = val.replace("0", "०");
	text = text.replace("1", "१");          
	text = text.replace("2", "२");
	text = text.replace("3", "३");
	text = text.replace("4", "४");
	text = text.replace("5", "५");
	text = text.replace("6", "६ ");
	text = text.replace("7", "७");
	text = text.replace("8", "८");
	text = text.replace("9", "९");
	
	//alert("text" + text);
	return text;
}

function OpenWindowWithPost(url, windowoption, name, params)
 {
            var form = document.createElement("form");
            form.setAttribute("method", "post");
            form.setAttribute("action", url);
            form.setAttribute("target", name);
 
            for (var i in params) {
                if (params.hasOwnProperty(i)) {
                    var input = document.createElement('input');
                    input.type = 'hidden';
                    input.name = i;
                    input.value = params[i];
                    form.appendChild(input);
                }
            }
 
            document.body.appendChild(form);
 
            //note I am using a post.htm page since I did not want to make double request to the page 
           //it might have some Page_Load call which might screw things up.
            window.open("post.htm", name, windowoption);
 
            form.submit();
 
            document.body.removeChild(form);
    }

function LogUserActivity(userActivity)
{

Ext.Ajax.request({
		url: '../Handlers/Common/UserActivityLogHandler.ashx',
		params:{
			method:'SaveUserActivity',
            userActivity: JSON.stringify(userActivity)
		},
		success: function (result, request ) {
			AppWakeUpJSON=result.responseText;
		},
		failure: function ( result, request ) {
				//msg('StartUp Error..','Please refresh your Browser to load application again');
		}
});

}


function deepCloneStore(source,storeID)
{
	var target = null;

	if(storeID !== "")
	{
		target = Ext.create ('Ext.data.Store', {
			model: source.model,
			storeId:storeID
		});
	}
	else
	{
		target = Ext.create ('Ext.data.Store', {
			model: source.model
		});
	}

	Ext.each (source.getRange (), function (record) {
		var newRecordData = Ext.clone (record.copy().data);
		var model = new source.model (newRecordData, newRecordData.id);

		target.add (model);
	});

	return target;
}

//GETS CURRENT NEPALI DATE
function GetNepaliDate(callback)
{
	var nepaliDate='';
	Ext.Ajax.request({
	    url: '../Handlers/Common/DateHandler.ashx?method=GetDates',
	    params:{},
	    success: function (result, request ) {
	        currDate=result.responseText;
	        nepaliDate=Ext.decode(currDate).root.NepaliDate;
			callback(nepaliDate);
	    }
	});
}

//VALIDATES TAX YEAR
function ValidateTaxyear(taxyear,callback){
	var currDate=null;
	var invalidMsg='';
	GetNepaliDate(function(nepaliDate){
		var currentYear=nepaliDate.split('.')[0];
		if(taxyear<2054 || taxyear>currentYear)
		{
			invalidMsg='* कर वर्ष 2054 र चालु वर्ष ('+currentYear+')को  बिचमा हुनुपर्छ।';
			callback(invalidMsg);
		}
	});
	callback(invalidMsg);
}
/*
//VALIDATES FILING PERIOD
function ValidateFilingPeriod(pan,acctType,filePer,taxyear,period,registrationDate,callback)
{
	var errMessage='';
        Ext.Ajax.request({
            url: '../Handlers/VAT/VatUtilitiesHandler.ashx',
            params: {
                method:'GetFilePerEndDate',
                filePeriod: filePer,
                taxyear:taxyear,
                period:period
            },
            success: function(response){
                var endDate=Ext.decode(response.responseText);

                //CHECKS WHETHER THE TAX PAYER IS REGISTERED IN THIS PERIOD
                if(endDate.message<=registrationDate)
                {
                    errMessage='Taxpayer Not Registered In This Period';
					callback(errMessage);
                }
				
				if(errMessage!=='')
				{
					return;
				}
				


                //GETS TAXPAYER'S FILING PERIOD
                Ext.Ajax.request({
                    url: '../Handlers/VAT/VatUtilitiesHandler.ashx',
                    params: {
                        method:'GetFilePeriod',
                        pan: pan,
                        acctType:acctType,
                        date:endDate.root
                    },
                    success: function(p1){
                        
                        var fp =Ext.decode(p1.responseText);
                        if(fp.success!='True')
                        {
                            msg('INFO',fp.message);
                        }
                        else
                        {
                            if(fp.message!=filePer)
                            {
                                errMessage='Invalid Filing Period';
								callback(errMessage);
                            }

                        }

                    }
                });

            }
        });	
}
*/
//VALIDATES FILING PERIOD
function ValidateFilingPeriod(pan,acctType,filePer,taxyear,period,registrationDate,callback)
{
	var errMessage='';
        Ext.Ajax.request({
            url: '../Handlers/VAT/VatUtilitiesHandler.ashx',
            params: {
                method:'GetFilePerEndDate',
                filePeriod: filePer,
                taxyear:taxyear,
                period:period
            },
            success: function(response){
                var endDate=Ext.decode(response.responseText);

                //CHECKS WHETHER THE TAX PAYER IS REGISTERED IN THIS PERIOD
                if(endDate.message<=registrationDate)
                {
                    errMessage='* करदाता यो अवधिमा दर्ता भएको छैन।';
					callback(errMessage);
                }
				
				if(errMessage!=='')
				{
					return;
				}
				


                //GETS TAXPAYER'S FILING PERIOD
                Ext.Ajax.request({
                    url: '../Handlers/VAT/VatUtilitiesHandler.ashx',
                    params: {
                        method:'GetFilePeriod',
                        pan: pan,
                        acctType:acctType,
                        date:endDate.root
                    },
                    success: function(p1){
                        
                        var fp =Ext.decode(p1.responseText);
                        if(fp.success!='True')
                        {
                            msg('INFO',fp.message);
                        }
                        else
                        {
                            if(fp.message!=filePer)
                            {
                                errMessage='* तपाईंले भर्नुभएको फाइलिंग पिरियड मिलेन।';
								callback(errMessage);
                            }

                        }
						callback(errMessage);

                    }
                });

            }
        });	
}

function validateDateYear(value)
{
	var errDate = "";
	if(value != "" && value.length == 10)
	{
		var arr = value.split(".");		
		var taxyear = arr[0].trim();
		
		ValidateTaxyear(taxyear,function(invalidMsg){
			if(invalidMsg!=='')
			{
				errDate = invalidMsg;
			}
		});

	}
	else
	{
		errDate = "Please Enter Valid Date!!!";
	}
	return errDate;
}

function validateFutureDate1(nepDate,futureDate,callback)
{
	//var nepDate ='2070.09.39';
    //var futureDate = 'Y';
	
	if(nepDate == "")
	{
		return true;
	}

	var errDate = "";
	errDate = validateNepDate(nepDate);
	
	if(errDate == "")
	{
    	Ext.Ajax.request({
    	    url: '../Handlers/Common/DateHandler.ashx?method=ValidateNepDate',
    		async:false,
    	    params:{nepDate:nepDate,futureDate:futureDate},
    	    success: function (result, request ) {
    	      var obj = Ext.decode(result.responseText);
			  
    	      if(obj.success == "false")
    	      {
    	           errDate = obj.message;
    
    	      }
    	    }
    	});
		
	}
	
	if(errDate != "")
	{
	   msg("WARNING",errDate,callback);
	   return false;
	}
	else
	{
	   return true;
	}
}


function validateFutureDateWithCallback(nepDate,futureDate,callback)
{
	//var nepDate ='2070.09.39';
    //var futureDate = 'Y';
	var obj=true;
	if(nepDate == "")
	{
		return true;
	}

	var errDate = "";
	errDate = validateNepDate(nepDate);
	
	if(errDate == "")
	{
    	Ext.Ajax.request({
    	    url: '../Handlers/Common/DateHandler.ashx?method=ValidateNepDate',
    		async:false,
    	    params:{nepDate:nepDate,futureDate:futureDate},
    	    success: function (result, request ) {
    	      var obj = Ext.decode(result.responseText);
			  
    	      if(obj.success == "false")
    	      {
    	           errDate = obj.message;
					
    	      }
    	    }
    	});
		
	}
	
	if(errDate != "")
	{
		obj=false;
	   callback(obj);
	   
	   
	}
	else
	{
	   callback(obj);
	}
}




function msg(title,message,callback)
{	
	var rqdIcon = Ext.MessageBox.INFO;
	var func = function(){};
	
	if(callback != "" || callback != null)
	{
		func = callback;
	}

	if(title == "FAILURE")
		rqdIcon = Ext.Msg.ERROR;
	else if(title == "WARNING")
		rqdIcon = Ext.Msg.WARNING;

	Ext.Msg.show({
		title: title,
		msg: message ,
		buttons: Ext.MessageBox.OK,
		icon: rqdIcon,
		fn:func
	});

}

function disableControls(form,flag)
{
	var fields = form.getFields();
	//console.log("fields>>",fields);
	Ext.each(fields.items, function (f) {
		f.inputEl.dom.disabled = flag;
	});
}

function dynamicPopUp(moduleName,extraParam)
{
	var controller = MyApp.app.getController(moduleName);
	MyApp.app.controllers.add(controller); 					   

	var vw = Ext.create('MyApp.view.'+ moduleName,{  });
	vw.extraParam = extraParam?extraParam:{};					    					
	
	var winPopup = Ext.create('MyApp.view.PopupWindow',{
								autoScroll:true,
								width:1000,
								height:650,
								items:[vw], 
								draggable:true,
								maximizable:true,
								minimizable:true,
								resizable:false,
								modal:true,
								title:"",
								y:30,
								layout:'fit'
							});

	controller.init();// launch init() method
	winPopup.show();
}

function getFloat(val)
{
	var retVal = 0;
	retVal = val === null || val === ""?0:parseFloat(val);
	return retVal;
}



function validFutureDateOrNoWithNapDate(nepDate,futureDate)
{
   var ErrMsg="";
	if(nepDate == "")
		{
		   ErrMsg="Date should not be blank";
		   return ErrMsg;
		}
		
  var errDate = "";
	errDate = validateNepDate(nepDate);
	
	if(errDate == "")
	{
    	Ext.Ajax.request({
    	    url: '../Handlers/Common/DateHandler.ashx?method=ValidateNepDate',
    		async:false,
    	    params:{nepDate:nepDate,futureDate:futureDate},
    	    success: function (result, request ) {
    	      var obj = Ext.decode(result.responseText);
			  
    	      if(obj.success == "false")
    	      {
    	           ErrMsg = obj.message;
    
    	      }
    	    }
    	});
		
	}
	else
	{
	  ErrMsg=errDate;
	}
	return ErrMsg;
	
}
