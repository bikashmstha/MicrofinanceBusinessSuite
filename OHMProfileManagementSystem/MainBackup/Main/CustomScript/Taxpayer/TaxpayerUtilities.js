
//VALIDATE PAN
function ValidatePan(pan,acctType,focus)
{
    var isValid=false;
	if(pan == "")
	{
		return true;
	}
	
    Ext.Ajax.request({
        url: '../Handlers/Registration/Taxpayer/TaxpayerHandler.ashx',
        params: {method:'ValidatePan',pan: pan,accountType:acctType},
        async:false,
        success: function(response){
            
            var JSONResponse=Ext.decode(response.responseText);
            if(JSONResponse.success=='true')
            {   
                isValid=true;
            }
			else
			{
				if(focus !== null || focus !== "")
				{
					msg("WARNING",JSONResponse.message,focus);
				}
				else
				{
					msg("WARNING",JSONResponse.message);
				}
				isValid = false;
			}
			
    
        }
    });
return isValid;
}

//LOAD TAXPAYER INFO    
function LoadTaxpayerInfo(pan,acctType,callback)
{
   
    var TaxpayerInfo;
    Ext.Ajax.request({
        url: '../Handlers/Registration/Taxpayer/TaxpayerHandler.ashx',
        params: {
            method:'GetTaxPayer',pan:pan,acctType:acctType
        },
        success: function(response){
            TaxpayerInfo =Ext.decode(response.responseText);
            
            callback(TaxpayerInfo);
        },
        failure:function(response)
        {
            msg('FAILURE',Ext.decode(response));
        }
    });
}



// Auther: shanjeev sah
// function name : LoadTaxpayerCurrentOfficeWithValidPanAccType
//GetTaxpayerCurrOffice(string pan, string acctType) 
function LoadTaxpayerCurrentOfficeWithValidPanAccType(pan,accType,callback)
{
    
    var TaxpayerInfo;
	
	var waitSave = Ext.MessageBox.wait('Loading ...');
    Ext.Ajax.request({
        url: '../Handlers/Registration/Taxpayer/TaxpayerHandler.ashx',
        params: {
            method:'GetTaxpayerCurrOffice',pan:pan,acctType:accType
        },
        success: function(response){
		
            waitSave.hide();
            obj =Ext.decode(response.responseText);
						
            if(obj.success === "false") 
			{
				msg("WARNING",obj.message);
				return;
			}
            
            callback(obj);
              
        },
        failure:function(response)
        {			
            waitSave.hide();
            msg('FAILURE',Ext.decode(response));
        }
    });
   
   // return TaxpayerInfo;
    
}

function LoadTaxpayerInfoWithValidPan(pan,acctType,callback)
{    
    var TaxpayerInfo;
	var isValid = true;
	
	if(pan == "")
	{
		return true;
	}
		
	var waitSave = Ext.MessageBox.wait('Loading ...');
    Ext.Ajax.request({
        url: '../Handlers/Registration/Taxpayer/TaxpayerHandler.ashx',
		async : false,
        params: {
            method:'GetValidTaxpayerInfo',pan:pan, acctType:acctType
        },
        success: function(response){
		
            waitSave.hide();
            obj =Ext.decode(response.responseText);
						
            if(obj.success === "false") 
			{
				msg("WARNING",obj.message);
				isValid = false;
			}
			else
			{   callback(obj);
			    isValid = true;
			}
              
        },
        failure:function(response)
        {			
            waitSave.hide();
            msg('FAILURE',Ext.decode(response));
        }
    });
   
   return isValid;
   // return TaxpayerInfo;
    
}

//GETS NON FILED PERIODS
function GetNFPeriod(pan, acctType,calcUpto,callback)
{
	Ext.Ajax.request({
		url:"../Handlers/VAT/Reports/Audit Trial/AuditTrialHandler.ashx?method=GetNFText" ,
		params:{pan:pan,
			acctType:acctType,
			calcUpto:calcUpto},
		success: function ( result, request ) {            
			var obj = Ext.decode(result.responseText);
			callback(obj);

			
		},
		failure:function (result, request)
		{
			//wait.hide();
			msg("FAILURE","Error in Fecthing Data");
		}
	});
}