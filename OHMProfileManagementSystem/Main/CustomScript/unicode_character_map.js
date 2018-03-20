
var PCSMapArray = new Array();
<!--NUMBERIC MAP-->
PCSMapArray[48] ="\u0966";
PCSMapArray[49] ="\u0967";
PCSMapArray[50] ="\u0968";
PCSMapArray[51] ="\u0969";
PCSMapArray[52] ="\u096A";
PCSMapArray[53] ="\u096B";
PCSMapArray[54] ="\u096C";
PCSMapArray[55] ="\u096D";
PCSMapArray[56] ="\u096E";
PCSMapArray[57] ="\u096F";

/*SHIFT NUMBERIC KEY*/
///not completed
PCSMapArray[248] ="\u0923\u094D";
PCSMapArray[249] ="\u091C\u094D\u091E";
PCSMapArray[250] ="\u0926\u094D\u0926";
PCSMapArray[251] ="\u0918";
PCSMapArray[252] ="\u0926\u094D\u0927";
PCSMapArray[253] ="\u091B";
PCSMapArray[254] ="\u091F";
PCSMapArray[255] ="\u0920";
PCSMapArray[256] ="\u0921";
PCSMapArray[257] ="\u0922";


<!--FOR SMALL-->

PCSMapArray[97] ="\u092c\u094D";
PCSMapArray[98] ="\u0926\u094D\u092F";
PCSMapArray[99] ="\u090B";
PCSMapArray[100] ="\u092E\u094D";
PCSMapArray[101] ="\u092D\u094D";
PCSMapArray[102] ="\u0901";
PCSMapArray[103] ="\u0928\u094D";
PCSMapArray[104] ="\u091C\u094D";
PCSMapArray[105] ="\u0915\u094D\u0937\u094D";
PCSMapArray[106] ="\u0935\u094D";
PCSMapArray[107] ="\u092A\u094D";
PCSMapArray[108] ="\u0940";
PCSMapArray[109] ="\u0903";
PCSMapArray[110] ="\u0932\u094D";
PCSMapArray[111] ="\u0907";
PCSMapArray[112] ="\u090F";
PCSMapArray[113] ="\u0924\u094D\u0924";
PCSMapArray[114] ="\u091A\u094D";
PCSMapArray[115] ="\u0915\u094D";
PCSMapArray[116] ="\u0924\u094D";
PCSMapArray[117] ="\u0917\u094D";
PCSMapArray[118] ="\u0916\u094D";
PCSMapArray[119] ="\u0927\u094D";
PCSMapArray[120] ="\u0939\u094D";
PCSMapArray[121] ="\u0925\u094D";
PCSMapArray[122] ="\u0936\u094D";



<!--FOR CAPITAL-->

PCSMapArray[65] ="\u092c";
PCSMapArray[66] ="\u0926";
PCSMapArray[67] ="\u0905";
PCSMapArray[68] ="\u092E";
PCSMapArray[69] ="\u092D";
PCSMapArray[70] ="\u093E";
PCSMapArray[71] ="\u0928";
PCSMapArray[72] ="\u091C";
PCSMapArray[73] ="\u0937\u094D";
PCSMapArray[74] ="\u0935";
PCSMapArray[75] ="\u092A";
PCSMapArray[76] ="\u093F";
PCSMapArray[77] ="";
PCSMapArray[78] ="\u0932";
PCSMapArray[79] ="\u092F";
PCSMapArray[80] ="\u0909";
PCSMapArray[81] ="\u0924\u094D\u0930";
PCSMapArray[82] ="\u091A";
PCSMapArray[83] ="\u0915";
PCSMapArray[84] ="\u0924";
PCSMapArray[85] ="\u0917";
PCSMapArray[86] ="\u0916";
PCSMapArray[87] ="\u0927";
PCSMapArray[88] ="\u0939";
PCSMapArray[89] ="\u0925";
PCSMapArray[90] ="\u0936";













/*SPECIAL KEY (EXELUCDABLE CHARACTER)*/

PCSMapArray[16] ="";
PCSMapArray[17] ="";
PCSMapArray[18] ="";
PCSMapArray[20] ="";
PCSMapArray[8] ="";
PCSMapArray[9] ="";
PCSMapArray[27] ="";
PCSMapArray[93] ="";
PCSMapArray[37] ="";
PCSMapArray[38] ="";
PCSMapArray[39] ="";
PCSMapArray[40] ="";
PCSMapArray[33] ="";
PCSMapArray[34] ="";
PCSMapArray[35] ="";
PCSMapArray[36] ="";
PCSMapArray[46] ="";
PCSMapArray[44] ="";
PCSMapArray[45] ="";
PCSMapArray[0] ="";
PCSMapArray[91] ="";


/*SPACE BAR KEY*/
PCSMapArray[32] =" ";

/*- + \ ~ [ ] sign*/
PCSMapArray[173] ="\u0914"; ///not found in unicode 
PCSMapArray[61] ="\u093C"; ///not found in unicode
PCSMapArray[220] ="\u094D";
PCSMapArray[192] ="\u091E";
PCSMapArray[219] ="\u0930\u094D";
PCSMapArray[221] ="\u0947";
PCSMapArray[59] ="\u0938";
PCSMapArray[222] ="\u0941";


PCSMapArray[188] ="";
PCSMapArray[190] ="\u0964";
PCSMapArray[191] ="\u0930";

/*- + \ ~ [ ] sign with shift*/
PCSMapArray[573] ="\u0913";
PCSMapArray[461] =" ";
PCSMapArray[620] ="\u0902";
PCSMapArray[592] ="\u0965";
PCSMapArray[619] ="\u0943";
PCSMapArray[621] ="\u0948";
PCSMapArray[459] ="\u091F\u094D\u0920";
PCSMapArray[622] ="\u0942";


PCSMapArray[588] ="";
PCSMapArray[590] ="\u0936\u094D\u0930";
PCSMapArray[591] ="\u0930\u094D\u0942";



PCSMapArray[1000] ="\u091D";
PCSMapArray[1001] ="\u092B";












function get_PCS_Unicode(ev,controlid)
{
	var code =  ev.keyCode;
	
	if(ev.shiftKey){
		if(code>47 && code<58)
			code = parseInt(code)+200;
		else if(code===173 || code===61 || code===220 || code===192 || code===219 ||
				code===221 || code===59 || code===222 || code===188 || code===190 || code===191)
		    {code = parseInt(code)+400;	}
		else
			code = parseInt(code)+32;	
	}
	//alert(code);	
	if(ev.altKey)
		alert('fdsaf');

	if(validatePCSExcludedKey(code)===true)
	{
		var strlength = controlid.getValue().length;
		var cutofstring = controlid.getValue().substring(0,strlength-1);
		var previousLetter =  controlid.getValue().substring(strlength-2,strlength-1);
		var LastLetter =  controlid.getValue().substring(strlength-3,strlength-2);
		
		// && LastLetter=="\u093F"
		/*if(LastLetter=="\u093F" || LastLetter=="" && code!='76')
		{
			var extraLetter = PCSMapArray[code]+'\u093F';
			cutofstring = controlid.value.substring(0,strlength-2);
			controlid.value = cutofstring+extraLetter;
			return true;
		}
*/
		if(code=="76")
		{
			controlid.setValue(cutofstring+'\u093F');
			return true;
		}
		
		if(previousLetter=="\u092A" && code==109)
		{
			cutofstring = controlid.getValue().substring(0,strlength-2);
			code="1001";
		}
		if(previousLetter=="\u092D" && code==109)
		{
			cutofstring = controlid.getValue().substring(0,strlength-2);
			code="1000";
		}
		
		if(code!="13" && code!='76')
		{
			controlid.setValue(cutofstring+PCSMapArray[code]);
		}
	}
}

function validatePCSExcludedKey(keycode)
{
	if(PCSMapArray[keycode]=="")
		return false;
	else
		return true;
}


var MADANMapArray = new Array();
<!--NUMBERIC MAP-->
MADANMapArray[48] ="\u0966";
MADANMapArray[49] ="\u0967";
MADANMapArray[50] ="\u0968";
MADANMapArray[51] ="\u0969";
MADANMapArray[52] ="\u096A";
MADANMapArray[53] ="\u096B";
MADANMapArray[54] ="\u096C";
MADANMapArray[55] ="\u096D";
MADANMapArray[56] ="\u096E";
MADANMapArray[57] ="\u096F";

/*SHIFT NUMBERIC KEY*/
///not completed
MADANMapArray[248] ="\u0923";
MADANMapArray[249] ="\u091C\u094D\u091E";
MADANMapArray[250] ="\u0908";
MADANMapArray[251] ="\u0918";
MADANMapArray[252] ="\u0926\u094D\u0927";
MADANMapArray[253] ="\u091B";
MADANMapArray[254] ="\u091F";
MADANMapArray[255] ="\u0920";
MADANMapArray[256] ="\u0921";
MADANMapArray[257] ="\u0922";


<!--FOR SMALL-->

MADANMapArray[97] ="\u0906";
MADANMapArray[98] ="\u094C";
MADANMapArray[99] ="\u090B";
MADANMapArray[100] ="\u0919\u094D\u0917";
MADANMapArray[101] ="\u090E";
MADANMapArray[102] ="\u0901";
MADANMapArray[103] ="'\u0926\u094D\u0926'";
MADANMapArray[104] ="\u091D";
MADANMapArray[105] ="\u0915\u094D\u0937";
MADANMapArray[106] ="\u094B";
MADANMapArray[107] ="\u092B";
MADANMapArray[108] ="\u0940";
MADANMapArray[109] ="\u0921\u094D\u0921";
MADANMapArray[110] ="\u0926\u094D\u092F";
MADANMapArray[111] ="\u0907";
MADANMapArray[112] ="\u090F";
MADANMapArray[113] ="\u0924\u094D\u0924";
MADANMapArray[114] ="\u0926\u094D\u092C";
MADANMapArray[115] ="\u0919\u094D\u0915";
MADANMapArray[116] ="\u091F\u094D\u091F";
MADANMapArray[117] ="\u090A";
MADANMapArray[118] ="\u0950";
MADANMapArray[119] ="\u0921\u094D\u0922";
MADANMapArray[120] ="\u0939\u094D\u092F";
MADANMapArray[121] ="\u0920\u094D\u0920";
MADANMapArray[122] ="\u0915\u094D\u0915";



<!--FOR CAPITAL-->

MADANMapArray[65] ="\u092c";
MADANMapArray[66] ="\u0926";
MADANMapArray[67] ="\u0905";
MADANMapArray[68] ="\u092E";
MADANMapArray[69] ="\u092D";
MADANMapArray[70] ="\u093E";
MADANMapArray[71] ="\u0928";
MADANMapArray[72] ="\u091C";
MADANMapArray[73] ="\u0937";
MADANMapArray[74] ="\u0935";
MADANMapArray[75] ="\u092A";
MADANMapArray[76] ="\u093F";
MADANMapArray[77] ="\u0903";
MADANMapArray[78] ="\u0932";
MADANMapArray[79] ="\u092F";
MADANMapArray[80] ="\u0909";
MADANMapArray[81] ="\u0924\u094D\u0930";
MADANMapArray[82] ="\u091A";
MADANMapArray[83] ="\u0915";
MADANMapArray[84] ="\u0924";
MADANMapArray[85] ="\u0917";
MADANMapArray[86] ="\u0916";
MADANMapArray[87] ="\u0927";
MADANMapArray[88] ="\u0939";
MADANMapArray[89] ="\u0925";
MADANMapArray[90] ="\u0936";













/*SPECIAL KEY (EXELUCDABLE CHARACTER)*/

MADANMapArray[16] ="";
MADANMapArray[17] ="";
MADANMapArray[18] ="";
MADANMapArray[20] ="";
MADANMapArray[8] ="";
MADANMapArray[9] ="";
MADANMapArray[27] ="";
MADANMapArray[93] ="";
MADANMapArray[37] ="";
MADANMapArray[38] ="";
MADANMapArray[39] ="";
MADANMapArray[40] ="";
MADANMapArray[33] ="";
MADANMapArray[34] ="";
MADANMapArray[35] ="";
MADANMapArray[36] ="";
MADANMapArray[46] ="";
MADANMapArray[44] ="";
MADANMapArray[45] ="";
MADANMapArray[0] ="";
MADANMapArray[91] ="";


/*SPACE BAR KEY*/
MADANMapArray[32] =" ";

/*- + \ ~ [ ] sign*/
MADANMapArray[173] ="\u0914";
MADANMapArray[61] =" ";
MADANMapArray[220] ="\u094D";
MADANMapArray[192] ="\u091E";
MADANMapArray[219] ="\u0930\u094D";
MADANMapArray[221] ="\u0947";
MADANMapArray[59] ="\u0938";
MADANMapArray[222] ="\u0941";


MADANMapArray[188] ="";
MADANMapArray[190] ="\u0964";
MADANMapArray[191] ="\u0930";

/*- + \ ~ [ ] sign with shift*/
MADANMapArray[573] ="\u0913";
MADANMapArray[461] =" ";
MADANMapArray[620] ="\u0902";
MADANMapArray[592] ="\u0965";
MADANMapArray[619] ="\u0943";
MADANMapArray[621] ="\u0948";
MADANMapArray[459] ="\u091F\u094D\u0920";
MADANMapArray[622] ="\u0942";


MADANMapArray[588] ="\u0919";
MADANMapArray[590] ="\u0936\u094D\u0930";
MADANMapArray[591] ="";












function get_Madan_Unicode(ev,controlid)
{
	var code =  ev.keyCode;
	//alert(ev.keyCode);
	if(ev.shiftKey){
		
		if(code>47 && code<58)
			code = parseInt(code)+200;
		else if(code===173 || code===61 || code===220 || code===192 ||
				code===219 || code===221 || code===59 || code===222 || code===188 || code===190 || code===191)
		    {code = parseInt(code)+400;	}
		else
			code = parseInt(code)+32;	
	}
		
	if(ev.altKey)
		alert('fdsaf');

	if(validateExcludedKey(code)===true)
	{

		var strlength = controlid.getValue().length;
		var cutofstring = controlid.getValue().substring(0,strlength-1);
		if(code!="13")
		{
		controlid.setValue(cutofstring+MADANMapArray[code]);
		}
		Ext.ComponentQuery.query('#'+controlid.id).setValue(cutofstring+siteunicode[code]);
	}
}

function validateExcludedKey(keycode)
{
	if(MADANMapArray[keycode]=="")
		return false;
	else
		return true;
}


function GetUnicode(ev,id)
{
//	if(document.getElementById('fontType').value=="0")
//	{
//		alert('Please Select Font Type');document.getElementById('unival').value="";
//	}
//	else if(document.getElementById('fontType').value=="pcs")
//	{
			get_PCS_Unicode(ev,id);								
//	}
//	else if(document.getElementById('fontType').value=="madan")
//	{
//			get_Madan_Unicode(ev,id);								
//	}
}