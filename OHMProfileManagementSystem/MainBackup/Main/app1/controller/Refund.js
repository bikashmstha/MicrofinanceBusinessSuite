/*
 * File: app/controller/Refund.js
 *
 * This file was generated by Sencha Architect version 2.2.3.
 * http://www.sencha.com/products/architect/
 *
 * This file requires use of the Ext JS 4.1.x library, under independent license.
 * License of Sencha Architect does not include license for Ext JS 4.1.x. For more
 * details see http://www.sencha.com/license or contact license@sencha.com.
 *
 * This file will be auto-generated each and everytime you save your project.
 *
 * Do NOT hand edit this file.
 */

Ext.define('MyApp.controller.Refund', {
    extend: 'Ext.app.Controller',

    stores: [
        'AccountLedgerRefund',
        'RefundExcessCreditDet',
        'FiscalYear'
    ],

    onBtnAddRefundClick: function(button, e, eOpts) {
        var strAccountLedger=Ext.getStore('AccountLedgerRefund');

        var grdRefund=Ext.ComponentQuery.query('#grdRefund')[0];


        var txtPanRefund=Ext.ComponentQuery.query('#txtPanRefund')[0];
        var txtAcctTypeRefund=Ext.ComponentQuery.query('#txtAcctTypeRefund')[0];
        var txtOfficeCodeRefund=Ext.ComponentQuery.query('#txtOfficeCodeRefund')[0];
        var txtRefundYearRefund=Ext.ComponentQuery.query('#txtRefundYearRefund')[0];

        var btnAddRefund=Ext.ComponentQuery.query('#btnAddRefund')[0];
        btnAddRefund.disable(true);

        var str=Ext.getStore('RefundExcessCreditDet');




        var rec="";
        rec={

            Sno:str.count()+1,
            AcctType:txtAcctTypeRefund.getValue(),
            ClaimAmount:'',
            CreditAmount:'',	
            FiscalYear:'',		
            OffCode:txtOfficeCodeRefund.getValue()===""?null:txtOfficeCodeRefund.getValue(),		
            Pan:txtPanRefund.getValue(),
            RefundReqNo:'',			
            RefundYear:txtRefundYearRefund.getValue()===""?null:txtRefundYearRefund.getValue(),				
            Terminal:'',			
            TranDate:'',	
            UserName:'',
            Action:''

        };

        grdRefund.store.add(rec);

        var col = grdRefund.headerCt.getHeaderAtIndex(0);
        var recd = grdRefund.store.data.items;
        var record = recd[recd.length-1];
        grdRefund.getPlugin('pluginRefund').startEdit(record, col);

    },

    onTxtPanRefundKeypress: function(textfield, e, eOpts) {
        if(e.keyCode=== 13 || e.keyCode === 9 )
        {

            this.PanCurrentOfficeTaxpayerInfo();
        }
    },

    onBtnSaveRefundClick: function(button, e, eOpts) {
        var me=this;

        Ext.ComponentQuery.query('#btnEditRefund')[0].enable(true);
        Ext.ComponentQuery.query('#btnSaveRefund')[0].enable(true);
        Ext.ComponentQuery.query('#txtRefReqNo')[0].disable(true);

        Ext.ComponentQuery.query('#lblMessage')[0].setText('');
        Ext.ComponentQuery.query('#imgUpdate')[0].hide(true);


        var str=Ext.getStore('RefundExcessCreditDet');



        if(Ext.ComponentQuery.query('#txtPanRefund')[0].getValue()==="")
        {
            msg("WARNING","Please fill 'Pan !!!' ");
            return;
        }
        if(Ext.ComponentQuery.query('#txtRefundYearRefund')[0].getValue()==="")
        {
            msg("WARNING","Please fill 'Refund Year !!! '");
            return;
        }


        if(Ext.ComponentQuery.query('#txtRequestDateRefund')[0].getValue()==="")
        {
            msg("WARNING","Please fill 'Request Date !!!' ");
            return;
        }

        if(Ext.ComponentQuery.query('#txtOfficerNameRefund')[0].getValue()==="")
        {
            msg("WARNING","Please fill 'Officer Name !!!' ");
            return;
        }

        if(str.data.length < 1)
        {
            msg("WARNING","Please fill 'Excess Credit Detail !!!' ");
            return;
        }


        else
        {
            me.saveRefund("I");
        }

    },

    onBtnEditRefundClick: function(button, e, eOpts) {
        Ext.ComponentQuery.query('#hdnActionRefund')[0].setValue('E');
        Ext.ComponentQuery.query('#lblMessage')[0].setText('Updating..........');
        Ext.ComponentQuery.query('#imgUpdate')[0].show(true);

        Ext.ComponentQuery.query('#txtRefReqNo')[0].enable(true);


        if(Ext.ComponentQuery.query('#txtRefReqNo')[0].getValue()==="")
        {
            msg("WARNING","Please fill ' Refund Request Number, PAN, Refund Year ' and key press on 'Refund Year' !!!");
            Ext.ComponentQuery.query('#btnEditRefund')[0].disable(true);
            Ext.ComponentQuery.query('#btnSaveRefund')[0].enable(true);
            return;
        }











        //this.saveRefund("I");
    },

    onBtnSubmitRefundClick: function(button, e, eOpts) {



        var me = this;

        var str=Ext.getStore('RefundExcessCreditDet');



        if(Ext.ComponentQuery.query('#txtPanRefund')[0].getValue()==="")
        {
            msg("WARNING","Please fill 'Pan !!!' ");
            return;
        }
        if(Ext.ComponentQuery.query('#txtRefundYearRefund')[0].getValue()==="")
        {
            msg("WARNING","Please fill 'Refund Year !!! '");
            return;
        }


        if(Ext.ComponentQuery.query('#txtRequestDateRefund')[0].getValue()==="")
        {
            msg("WARNING","Please fill 'Request Date !!!' ");
            return;
        }

        if(Ext.ComponentQuery.query('#txtOfficerNameRefund')[0].getValue()==="")
        {
            msg("WARNING","Please fill 'Officer Name !!!' ");
            return;
        }

        if(str.data.length < 1)
        {
            msg("WARNING","Please fill 'Excess Credit Detail !!!' ");
            return;
        }

        else
        {

            Ext.Msg.confirm('Confirm Action', 'एकपटक SUBMIT गरिसकेपछि अर्को पटक विवरण उपलव्द हुने छैन्। \n के तपाई SUBMIT गर्न चाहनुहन्छ ?', function(btn) {
                if(btn == 'yes'){

                    Ext.ComponentQuery.query('#hdnActionRefund')[0].setValue('E');
                    me.saveRefund("F");

                    me.clearControlsRefund();



                    Ext.ComponentQuery.query('#btnEditRefund')[0].enable(true);

                    Ext.ComponentQuery.query('#btnSubmitRefund')[0].disable(true);
                    Ext.ComponentQuery.query('#btnVerifyRefund')[0].disable(true);
                    Ext.ComponentQuery.query('#btnDelete')[0].disable(true);

                    return true;
                }
            }, this);
        }


    },

    onTxtRefundYearRefundKeypress: function(textfield, e, eOpts) {

        if(e.keyCode=== 13 || e.keyCode === 9)
        {
            var me=this;

            var OfficeCodeRefund=Ext.ComponentQuery.query('#txtOfficeCodeRefund')[0];
            var RefReqNo=Ext.ComponentQuery.query('#txtRefReqNo')[0];
            var PanRefund=Ext.ComponentQuery.query('#txtPanRefund')[0];
            var AcctTypeRefund=Ext.ComponentQuery.query('#txtAcctTypeRefund')[0];
            var RefundYearRefund=Ext.ComponentQuery.query('#txtRefundYearRefund')[0];


            var txtRequestDateRefund=Ext.ComponentQuery.query('#txtRequestDateRefund')[0];
            var txtOfficerCodeRefund=Ext.ComponentQuery.query('#txtOfficerCodeRefund')[0];
            var txtOfficerNameRefund=Ext.ComponentQuery.query('#txtOfficerNameRefund')[0];

            var hdnTranNo=Ext.ComponentQuery.query('#hdnTranNo')[0];

            var grdRefund=Ext.ComponentQuery.query('#grdRefund')[0];

            var str=Ext.getStore('RefundExcessCreditDet');
            str.removeAll();
            str.loadData([],false);




            Ext.Ajax.request({

                url:'../Handlers/IncomeTax/Refund/RefundExcessCreditHandler.ashx',
                params:{
                    method:'GetRefundExcessDebit',OffCode:OfficeCodeRefund.getValue(),Pan:PanRefund.getValue(),AcctType:AcctTypeRefund.getValue(),RefundYear:RefundYearRefund.getValue(),RefundReqNo:RefReqNo.getValue()
                },

                success: function(response){    
                    //waitMsg.hide();
                    //var sum = 0;
                    var obj =Ext.decode(response.responseText);
                    //console.log(obj);
                    var row = obj.root;

                    if(Ext.ComponentQuery.query('#txtRefReqNo')[0].getValue().length>0)
                    {
                        if(obj.root.RequestDate===null)
                        {
                            msg("WARNING","No Data Found");
                            return;
                        }

                        else
                        {          


                            if(obj.root.Status==="I" || obj.root.Status==="")
                            {

                                txtRequestDateRefund.setValue(row.RequestDate);
                                txtOfficerCodeRefund.setValue(row.OfficerCode);
                                txtOfficerNameRefund.setValue(row.UserName);
                                hdnTranNo.setValue(row.TranNo);
                                grdRefund.store.add(obj.root.RefundExcessCreditDet);
                                Ext.ComponentQuery.query('#btnVerifyRefund')[0].disable(true);

                            }


                            else if(obj.root.Status==="D")
                            {
                                msg("Info","यो बिबरण हटाईसकेको छ"); 
                                Ext.ComponentQuery.query('#hdnForGrd')[0].setValue('Z');

                                me.clearControlsRefund();

                                Ext.ComponentQuery.query('#btnAddRefund')[0].disable(true);
                                Ext.ComponentQuery.query('#btnSaveRefund')[0].disable(true);
                                Ext.ComponentQuery.query('#btnEditRefund')[0].disable(true);
                                Ext.ComponentQuery.query('#btnSubmitRefund')[0].disable(true);
                                Ext.ComponentQuery.query('#btnDelete')[0].disable(true);
                                Ext.ComponentQuery.query('#btnVerifyRefund')[0].disable(true);
                                Ext.ComponentQuery.query('#btnPrintRefund')[0].disable(true);
                                Ext.ComponentQuery.query('#btnCancelRefund')[0].enable(true);
                                return;
                            }

                            else if(obj.root.Status==="F")
                            {
                                msg("Info","यो बिबरण परिबर्तन गर्न पाईनेछैन्"); 
                                Ext.ComponentQuery.query('#hdnForGrd')[0].setValue('Z');

                                txtRequestDateRefund.setValue(row.RequestDate);
                                txtOfficerCodeRefund.setValue(row.OfficerCode);
                                txtOfficerNameRefund.setValue(row.UserName);

                                hdnTranNo.setValue(row.TranNo);


                                Ext.ComponentQuery.query('#txtTradeNameRefund')[0].setReadOnly(true);
                                Ext.ComponentQuery.query('#txtRefundYearRefund')[0].setReadOnly(true);
                                Ext.ComponentQuery.query('#txtRequestDateRefund')[0].setReadOnly(true);
                                Ext.ComponentQuery.query('#txtOfficerCodeRefund')[0].setReadOnly(true);
                                Ext.ComponentQuery.query('#txtOfficerNameRefund')[0].setReadOnly(true);
                                Ext.ComponentQuery.query('#txtPanRefund')[0].setReadOnly(true);
                                Ext.ComponentQuery.query('#txtRefReqNo')[0].setReadOnly(true);



                                grdRefund.store.add(obj.root.RefundExcessCreditDet);

                                Ext.ComponentQuery.query('#btnVerifyRefund')[0].disable(true);

                                Ext.ComponentQuery.query('#btnAddRefund')[0].disable(true);
                                Ext.ComponentQuery.query('#btnSaveRefund')[0].disable(true);
                                Ext.ComponentQuery.query('#btnEditRefund')[0].disable(true);
                                Ext.ComponentQuery.query('#btnSubmitRefund')[0].disable(true);
                                Ext.ComponentQuery.query('#btnDelete')[0].disable(true);
                                Ext.ComponentQuery.query('#btnVerifyRefund')[0].enable(true);
                                Ext.ComponentQuery.query('#btnPrintRefund')[0].disable(true);
                                Ext.ComponentQuery.query('#btnCancelRefund')[0].enable(true);

                                return;
                            }



                            else if(obj.root.Status==="V")
                            {
                                msg("Info","यो बिबरण रूजु भईसकेको छ");  
                                Ext.ComponentQuery.query('#hdnForGrd')[0].setValue('Z');



                                me.clearControlsRefund();

                                Ext.ComponentQuery.query('#btnAddRefund')[0].disable(true);
                                Ext.ComponentQuery.query('#btnSaveRefund')[0].disable(true);
                                Ext.ComponentQuery.query('#btnEditRefund')[0].disable(true);
                                Ext.ComponentQuery.query('#btnSubmitRefund')[0].disable(true);
                                Ext.ComponentQuery.query('#btnDelete')[0].disable(true);
                                Ext.ComponentQuery.query('#btnVerifyRefund')[0].disable(true);
                                Ext.ComponentQuery.query('#btnPrintRefund')[0].disable(true);
                                Ext.ComponentQuery.query('#btnCancelRefund')[0].enable(true);              

                                return;
                            }
                        }



                    }


                },                   

                failure:function(response)
                {			
                    //waitMsg.hide();
                    msg('FAILURE',Ext.decode(response));
                }
            });
        }

    },

    onBtnDeleteClick: function(button, e, eOpts) {



        var me = this;


        var str=Ext.getStore('RefundExcessCreditDet');



        if(Ext.ComponentQuery.query('#txtPanRefund')[0].getValue()==="")
        {
            msg("WARNING","Please fill 'Pan !!!' ");
            return;
        }
        if(Ext.ComponentQuery.query('#txtRefundYearRefund')[0].getValue()==="")
        {
            msg("WARNING","Please fill 'Refund Year !!! '");
            return;
        }


        if(Ext.ComponentQuery.query('#txtRequestDateRefund')[0].getValue()==="")
        {
            msg("WARNING","Please fill 'Request Date !!!' ");
            return;
        }

        if(Ext.ComponentQuery.query('#txtOfficerNameRefund')[0].getValue()==="")
        {
            msg("WARNING","Please fill 'Officer Name !!!' ");
            return;
        }

        if(str.data.length < 1)
        {
            msg("WARNING","Please fill 'Excess Credit Detail !!!' ");
            return;
        }

        else
        {

            Ext.Msg.confirm('Confirm Action', 'एकपटक DELETE गरिसकेपछि अर्को पटक विवरण उपलव्द हुने छैन्। \n के तपाई DELETE गर्न चाहनुहन्छ ?', function(btn) {
                if(btn == 'yes'){

                    Ext.ComponentQuery.query('#hdnActionRefund')[0].setValue('E');
                    me.saveRefund("D");

                    me.clearControlsRefund();




                    Ext.ComponentQuery.query('#btnSubmitRefund')[0].disable(true);
                    Ext.ComponentQuery.query('#btnVerifyRefund')[0].disable(true);
                    Ext.ComponentQuery.query('#btnDelete')[0].disable(true);

                    return true;
                }
            }, this);
        }

    },

    onBtnVerifyRefundClick: function(button, e, eOpts) {



        var me = this;


        var str=Ext.getStore('RefundExcessCreditDet');



        if(Ext.ComponentQuery.query('#txtPanRefund')[0].getValue()==="")
        {
            msg("WARNING","Please fill 'Pan !!!' ");
            return;
        }
        if(Ext.ComponentQuery.query('#txtRefundYearRefund')[0].getValue()==="")
        {
            msg("WARNING","Please fill 'Refund Year !!! '");
            return;
        }


        if(Ext.ComponentQuery.query('#txtRequestDateRefund')[0].getValue()==="")
        {
            msg("WARNING","Please fill 'Request Date !!!' ");
            return;
        }

        if(Ext.ComponentQuery.query('#txtOfficerNameRefund')[0].getValue()==="")
        {
            msg("WARNING","Please fill 'Officer Name !!!' ");
            return;
        }

        if(str.data.length < 1)
        {
            msg("WARNING","Please fill 'Excess Credit Detail !!!' ");
            return;
        }

        else
        {

            Ext.Msg.confirm('Confirm Action', 'एकपटक VERIFY गरिसकेपछि अर्को पटक विवरण उपलव्द हुने छैन्। \n के तपाई VERIFY गर्न चाहनुहन्छ ?', function(btn) {
                if(btn == 'yes'){

                    Ext.ComponentQuery.query('#hdnActionRefund')[0].setValue('E');
                    me.saveRefund("V");

                    me.clearControlsRefund();




                    Ext.ComponentQuery.query('#btnSubmitRefund')[0].disable(true);
                    //Ext.ComponentQuery.query('#btnVerifyRefund')[0].disable(true);
                    Ext.ComponentQuery.query('#btnDelete')[0].disable(true);

                    return true;
                }
            }, this);
        }

    },

    onBtnCancelRefundClick: function(button, e, eOpts) {
        this.clearControlsRefund();
    },

    onTxtPanRefundBlur: function(component, e, eOpts) {
        this.PanCurrentOfficeTaxpayerInfo();
    },

    PanCurrentOfficeTaxpayerInfo: function() {
        var pan = Ext.ComponentQuery.query('#txtPanRefund')[0].getValue();
        var offCode = Ext.ComponentQuery.query('#txtOfficeCodeRefund')[0].getValue();
        var accType =  Ext.ComponentQuery.query('#txtAcctTypeRefund')[0].getValue();

        var me=this;


        LoadTaxpayerInfoWithValidPan(pan,accType,function(data){
            var taxpayer=data.root.Taxpayer;
            var address=taxpayer.BusinessAddress.Address;
            var office=taxpayer.Office;

            console.log("TaxPayer",taxpayer);



            if(taxpayer.AcctStatus === "D")
            {
                msg("WARNING","PAN is Deactivated !!!");
                me.clearControlsRefund();
                return;
            }
            if(offCode != office.OfficeCode)
            {
                msg("WARNING","PAN is not Registered in this office !!!");
                me.clearControlsRefund();

                return;
            }


            Ext.ComponentQuery.query('#txtTradeNameRefund')[0].setValue(taxpayer.Name);



        });

    },

    clearControlsRefund: function() {
        Ext.ComponentQuery.query('#txtTradeNameRefund')[0].setValue('');
        Ext.ComponentQuery.query('#txtRefundYearRefund')[0].setValue('');
        Ext.ComponentQuery.query('#txtRequestDateRefund')[0].setValue('');
        Ext.ComponentQuery.query('#txtOfficerCodeRefund')[0].setValue('');
        Ext.ComponentQuery.query('#txtOfficerNameRefund')[0].setValue('');
        Ext.ComponentQuery.query('#txtPanRefund')[0].setValue('');
        Ext.ComponentQuery.query('#txtRefReqNo')[0].setValue('');

        Ext.ComponentQuery.query('#txtRefReqNo')[0].disable(true);




        Ext.ComponentQuery.query('#hdnActionRefund')[0].setValue('');
        Ext.ComponentQuery.query('#lblMessage')[0].setText('');
        Ext.ComponentQuery.query('#imgUpdate')[0].hide(true);




        Ext.ComponentQuery.query('#hdnTranNo')[0].setValue('');



        var str=Ext.getStore('RefundExcessCreditDet');
        str.removeAll();
        str.loadData([],false);



        Ext.ComponentQuery.query('#btnSaveRefund')[0].enable(true);
        Ext.ComponentQuery.query('#btnEditRefund')[0].enable(true);
        Ext.ComponentQuery.query('#btnSubmitRefund')[0].enable(true);
        Ext.ComponentQuery.query('#btnDelete')[0].enable(true);
        Ext.ComponentQuery.query('#btnVerifyRefund')[0].disable(true);

        Ext.ComponentQuery.query('#btnAddRefund')[0].enable(true);










    },

    saveRefund: function(Status) {
        var me=this;

        var txtOfficeCodeRefund=Ext.ComponentQuery.query('#txtOfficeCodeRefund')[0];
        var txtAcctTypeRefund=Ext.ComponentQuery.query('#txtAcctTypeRefund')[0];
        var txtOfficerCodeRefund=Ext.ComponentQuery.query('#txtOfficerCodeRefund')[0];
        var txtPanRefund=Ext.ComponentQuery.query('#txtPanRefund')[0];
        var txtRefReqNo=Ext.ComponentQuery.query('#txtRefReqNo')[0];
        var txtRefundYearRefund=Ext.ComponentQuery.query('#txtRefundYearRefund')[0];
        var txtRequestDateRefund=Ext.ComponentQuery.query('#txtRequestDateRefund')[0];
        var txtOfficerNameRefund=Ext.ComponentQuery.query('#txtOfficerNameRefund')[0];

        var hdnActionRefund=Ext.ComponentQuery.query('#hdnActionRefund')[0];
        var hdnTranNo=Ext.ComponentQuery.query('#hdnTranNo')[0];

        //---------------------------------------------------------------------------

        var RefundExcessCreditDetLST="";

        var strRefundExcessCreditDet=Ext.getStore('RefundExcessCreditDet');
        strRefundExcessCreditDet.clearFilter();

        if(strRefundExcessCreditDet.getCount() > 0)
        {
            RefundExcessCreditDetLST = getJson(strRefundExcessCreditDet); 
        }

        //--------------------------------------------------------------------------------


        var refundExcessCredit="";
        refundExcessCredit={

            AcctType:txtAcctTypeRefund.getValue(), 
            OffCode:txtOfficeCodeRefund.getValue()===""?null:txtOfficeCodeRefund.getValue(), 
            OfficerCode:txtOfficerCodeRefund.getValue(), 
            Pan:txtPanRefund.getValue(), 
            RefundReqNo:txtRefReqNo.getValue(), 
            RefundYear:txtRefundYearRefund.getValue()===""?null:txtRefundYearRefund.getValue(), 
            RequestDate:txtRequestDateRefund.getValue(), 
            Status:Status, 
            Terminal:'',
            TranDate:'', 
            TranNo:hdnTranNo.getValue()===""?null:hdnTranNo.getValue(), 
            UserName:txtOfficerNameRefund.getValue(), 
            Action:hdnActionRefund.getValue(),


            RefundExcessCreditDet:RefundExcessCreditDetLST!==""?RefundExcessCreditDetLST:null
        };
        //----------------------------

        //-------------------

        Ext.Ajax.request({

            url:'../Handlers/IncomeTax/Refund/RefundExcessCreditHandler.ashx?method=SaveRefundExcessCredit',
            params:{refundExcessCredit:JSON.stringify(refundExcessCredit)},


            success:function(result,request){
                var obj=Ext.decode(result.responseText);
                msg(obj.success === "true" ?"SUCCESS":"FAILURE",obj.message);


                Ext.ComponentQuery.query('#hdnActionRefund')[0].setValue('');
                me.clearControlsRefund();


            },
            failure:function(result, request){
                msg('ERROR OCURRED !!!', 'Error');                 
            }


        });
    },

    init: function(application) {
        this.control({
            "#btnAddRefund": {
                click: this.onBtnAddRefundClick
            },
            "#txtPanRefund": {
                keypress: this.onTxtPanRefundKeypress,
                blur: this.onTxtPanRefundBlur
            },
            "#btnSaveRefund": {
                click: this.onBtnSaveRefundClick
            },
            "#btnEditRefund": {
                click: this.onBtnEditRefundClick
            },
            "#btnSubmitRefund": {
                click: this.onBtnSubmitRefundClick
            },
            "#txtRefundYearRefund": {
                keypress: this.onTxtRefundYearRefundKeypress
            },
            "#btnDelete": {
                click: this.onBtnDeleteClick
            },
            "#btnVerifyRefund": {
                click: this.onBtnVerifyRefundClick
            },
            "#btnCancelRefund": {
                click: this.onBtnCancelRefundClick
            }
        });
    }

});
