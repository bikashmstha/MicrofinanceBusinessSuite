/*
 * File: app/controller/VisitSelection.js
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

Ext.define('MyApp.controller.VisitSelection', {
    extend: 'Ext.app.Controller',

    stores: [
        'VisitTypeStore',
        'VisitOfficerStore'
    ],

    onVisitSelectionAfterRender: function(component, eOpts) {

        var userActivity={
            ApplicationID:'VAT',
            ModuleID:'VATRETURN',
            UserID:'ITS',
            Action:'ENTER'
        };

        LogUserActivity(userActivity);



        //*************************** LOAD VISIT TYPES *********************************************************
        var strVT = Ext.getStore('VisitTypeStore');
        strVT.removeAll();
        strVT.load();

        var officerStore=Ext.getStore('VisitOfficerStore');
        officerStore.removeAll();


        //var stFP = Ext.getStore('FilingPeriodStore');
        //stFP.load();


        //var nepaliDate = Ext.get('nepDate').dom.innerHTML;
        //Ext.ComponentQuery.query('#txtVisitSelSelectionDate')[0].setValue(nepaliDate);

    },

    onTxtVisitSelPanBlur: function(component, e, eOpts) {
        var me=this;
        var pan=Ext.ComponentQuery.query("#txtVisitSelPan")[0].value;
        var acctType='00';

        if(pan==='')
        {
            return;
        }
        if(pan.length!=9)
        {
            msg('INFO','* तपाईले भर्नु भएको प्यान ९ अंकको हुनुपर्छ। ');
            return;
        }


        //----------------------------------------------------------------
        //------------------VALIDATES AND LOADS TAXPAYER INFO-------------
        //----------------------------------------------------------------




        LoadTaxpayerInfoWithValidPan(pan,acctType,function(obj){
            if(obj.root.Message!==null)
            {
                var f=Ext.ComponentQuery.query('#txtPan')[0]; 
                msg('INFO',obj.root.Message,f);

                Ext.ComponentQuery.query("#txtVisitSelTaxpayerName")[0].setValue('');

            }
            else
            {
                var taxpayer=obj.root.Taxpayer;

                var office=taxpayer.Office;

                if(taxpayer.AcctStatus!='A')
                {
                    msg('INFO', '* यो प्यान सक्रिय छैन।');
                    return;
                }


                var userOffice=Ext.get('offCode').dom.innerHTML;    
                if(office.OfficeCode!=userOffice)
                {
                    msg('INFO', '* यो करदाता यो कार्यालामा दर्ता छैन।<BR><BR>  तपाईले यो करदाताको विवरण भर्न पाउनु हुन्न।');
                    Ext.ComponentQuery.query("#txtVisitSelTaxpayerName")[0].setValue('');


                    return;
                }



                Ext.ComponentQuery.query("#txtVisitSelTaxpayerName")[0].setValue(taxpayer.Name);

            }

        });





    },

    onBtnVisitSelAddVisitReasonClick: function(button, e, eOpts) {
        var store=Ext.getStore('VisitReasonStore');
        var grid=Ext.ComponentQuery.query('#grdVisSelVisitReason')[0];

        var PAN=Ext.ComponentQuery.query("#txtVisitSelPan")[0].getValue();
        var SelectionDate=Ext.ComponentQuery.query("#txtVisitSelSelectionDate")[0].getValue();

        strMsg='';
        if(PAN===''||PAN===null)
        {
            strMsg+='PAN Cannot Be Left Blank<BR>';
        }
        if(SelectionDate===''||SelectionDate===null)
        {
            strMsg+='Selection Date Cannot Be Left Blank<BR>';
        }

        if(strMsg!=='')
        {
            msg('INFO',strMsg);
            return;
        }

        var VisitType=Ext.ComponentQuery.query('#ddlVisSelVisitType')[0].getValue();
        var VisitTypeDesc=Ext.ComponentQuery.query('#ddlVisSelVisitType')[0].rawValue;
        var FromDate='';
        var ToDate='';




        //Add or Edit To Voucher Details Grid
        if (grid.getSelectionModel().hasSelection())
        {
            var r = grid.getSelectionModel().getSelection();
            r[0].set('PAN',PAN);
            r[0].set('SelectionDate',SelectionDate);
            r[0].set('VisitType',VisitType);
            r[0].set('VisitTypeDesc',VisitTypeDesc);
            r[0].set('FromDate',FromDate);
            r[0].set('ToDate',ToDate);


            var action=r[0].get('Action');
            if(action==='O' || action=='E')
            {
                alert(action);
                //r[0].set('SeqNo',);
                r[0].set('Action','E');
            }
            grid.getSelectionModel().select(null);
            return false;

        }
        else
        {
            store.add({'PAN': PAN,
                'SelectionDate': SelectionDate,
                'VisitType':VisitType,
                'VisitTypeDesc':VisitTypeDesc,
                'FromDate':FromDate,
                'ToDate':ToDate,
            'Action':'A'});
        }


        //Ext.ComponentQuery.query("#txtPaymentDate")[0].reset();

    },

    onBtnVisitSelectionSaveClick: function(button, e, eOpts) {
        var vsStatus=Ext.ComponentQuery.query('#hdnVisitSelAction')[0].getValue();
        if(vsStatus=='F')
        {
            msg('INFO','* यो भ्रमण सब्मिट भैसकेको छ। तपाईले यो भ्रमण फेरि सब्मिट गर्न सक्नु हुन्न।');
            return;
        }
        else
        {

            var errMsg='';

            var pan=Ext.ComponentQuery.query('#txtVisitSelPan')[0].getValue();
            var selectionDate=Ext.ComponentQuery.query('#txtVisitSelSelectionDate')[0].getValue();
            if(pan==='')
            {
                errMsg+='<BR>* तपाईले प्यान अनिवार्य रूपमा भर्नुपर्नेछ।';

            }
            if(selectionDate==='')
            {
                errMsg+='<BR>* तपाईले छनोट मिति अनिवार्य रूपमा भर्नुपर्नेछ।';
            }

            if(errMsg!=='')
            {
                msg('INFO',errMsg);
                return;
            }
            else
            {

                var me=this;
                var frm=Ext.getCmp('frmVisitSelection');

                var form = button.up('form').getForm();
                me.SaveVisitSelection('I',form);
            }
        }
    },

    onTxtVisitSelSelectionDateBlur: function(component, e, eOpts) {
        var me=this;
        if(field.getValue!=='')
        {
            validateFutureDate(field.getValue(),'Y',function(obj){
                if(obj=='ok')
                {
                    var form=(Ext.ComponentQuery.query('#frmVisitSelection')[0]).getForm();

                    //var form = button.up('form').getForm();
                    me.LoadVisitSelection(form);
                }
                else
                {
                    field.focus();
                }
            });
        }
    },

    onBtnAVOfficerAddClick: function(button, e, eOpts) {
        var pan=Ext.ComponentQuery.query('#txtVisitSelPan')[0];
        var selDate=Ext.ComponentQuery.query('#txtVisitSelSelectionDate')[0];
        var message='';
        if(pan.getValue()==='')
        {
            message+='<BR>* कृपया पहिला प्यान भर्नुहोला।';

        }

        if(selDate.getValue()==='')
        {
            message+='<BR>* कृपया पहिला छनोट मिति भर्नुहोला।';
        }

        if(message!=='')
        {
            msg('INFO',message);
            return;
        }
        else
        {
            var grd = Ext.ComponentQuery.query('#grdAVOfficer')[0];
            var rec={
                PAN:pan.getValue(),
                SelectionDate:selDate.getValue(),
                OfficerName:'',
                OfficerCode:'',
                Action:'A'
            };
            if(grd.store.add(rec))
            {
                var btnAVOfficer= Ext.ComponentQuery.query('#btnAVOfficerAdd')[0];
                btnAVOfficer.disable(true);
            }

            var col = grd.headerCt.getHeaderAtIndex(0);
            var recd = grd.store.data.items;
            var record = recd[recd.length-1];
            grd.getPlugin('plugInGrdAVOfficer').startEdit(record, col);		
        }
    },

    onBtnVisitSelectionSubmitClick: function(button, e, eOpts) {
        var vsStatus=Ext.ComponentQuery.query('#hdnVisitSelAction')[0].getValue();
        if(vsStatus=='F')
        {
            msg('INFO','* यो भ्रमण सब्मिट भैसकेको छ। तपाईले यो भ्रमण फेरि सब्मिट गर्न सक्नु हुन्न।');
            return;
        }
        else
        {
            var errMsg='';

            var pan=Ext.ComponentQuery.query('#txtVisitSelPan')[0].getValue();
            var selectionDate=Ext.ComponentQuery.query('#txtVisitSelSelectionDate')[0].getValue();
            var initiationDate=Ext.ComponentQuery.query('#txtVisitSelInitiationDate')[0].getValue();
            var visitType=Ext.ComponentQuery.query('#ddlVisSelVisitType')[0].getValue();

            var vat=Ext.ComponentQuery.query('#chkVisitSelVat')[0].getValue();
            var it=Ext.ComponentQuery.query('#chkVisitSelIT')[0].getValue();
            var ex=Ext.ComponentQuery.query('#chkVisitSelExcise')[0].getValue();



            if(pan==='')
            {
                errMsg+='<BR>* तपाईले प्यान अनिवार्य रूपमा भर्नुपर्नेछ।';
            }
            if(selectionDate==='')
            {
                errMsg+='<BR>* तपाईले छनोट मिति अनिवार्य रूपमा भर्नुपर्नेछ।';
            }
            if(initiationDate==='')
            {
                errMsg+='<BR>* तपाईले भ्रमण शुरू मिति अनिवार्य रूपमा भर्नुपर्नेछ।';
            }
            if(!visitType)
            {
                errMsg+='<BR>* तपाईले भ्रमणको किसिम अनिवार्य रूपमा भर्नुपर्नेछ।';
            }

            if(vat===false&&it===false&&ex===false)
            {
                errMsg+='<BR>* तपाईले कर, मू.अ.क. वा अन्त शुल्क मध्य एक अनिवार्य रूपमा छान्नुपर्नेछ।';
            }

            if(errMsg!=='')
            {
                msg('INFO',errMsg);
                return;
            }
            else
            {
                if(initiationDate<selectionDate)
                {
                    msg('INFO','* भ्रमण शुरू मिति भ्रमण छनोट मिति भन्दा अगाडि हुनु हुन्न।');
                    return;
                }
                else
                {
                    var me=this;
                    var frm=Ext.getCmp('frmVisitSelection');

                    var form = button.up('form').getForm();
                    me.SaveVisitSelection('F',form);
                }
            }
        }
    },

    onBtnVisitSelectionCancelClick: function(button, e, eOpts) {
        var form = button.up('form').getForm();
        var me=this;
        me.ClearControls(form);
    },

    onTxtVisitSelSelectionDateBlur: function(component, e, eOpts) {
        var me=this;
        if(field.getValue!=='')
        {
            validateFutureDateWithCallback(field.getValue(),'Y',function(obj){
                if(obj===true)
                {
                    var form=(Ext.ComponentQuery.query('#frmVisitSelection')[0]).getForm();

                    //var form = button.up('form').getForm();
                    me.LoadVisitSelection(form);
                }
                else
                {
                    field.focus();
                }
            });
        }


    },

    onTxtVisitSelInitiationDateBlur: function(component, e, eOpts) {
        if(field.getValue!=='')
        {
            validateFutureDate(field.getValue(),'N',function(obj){
                field.focus();
            });
        }
    },

    LoadVisitSelection: function(form) {
        var pan=Ext.ComponentQuery.query('#txtVisitSelPan')[0];
        var selectionDate=Ext.ComponentQuery.query('#txtVisitSelSelectionDate')[0];


        Ext.Ajax.request({
            url: '../Handlers/Common/Visit/VisitSelectionHandler.ashx',
            params: {method:'GetVisitSelection',pan: pan.getValue(),selectionDate:selectionDate.getValue() },
            success: function(response){
                var JSONResponse=Ext.decode(response.responseText);
                var visitSelection=JSONResponse.root;
                if(JSONResponse.success=='true')
                {  
                    if(visitSelection)
                    {
                        Ext.ComponentQuery.query('#ddlVisSelVisitType')[0].setValue(visitSelection.AVType);
                        Ext.ComponentQuery.query('#txtVisitSelInitiationDate')[0].setValue(visitSelection.VisitDate);
                        Ext.ComponentQuery.query('#hdnVisitSelAction')[0].setValue('E');


                        //Load Visit Officer
                        var avOfficer=visitSelection.VisitOfficers;
                        var strAVOfficer = Ext.getStore('VisitOfficerStore');
                        strAVOfficer.removeAll();
                        strAVOfficer.add(avOfficer);


                        if(visitSelection.SelForIT=='T')
                        {
                            Ext.ComponentQuery.query('#chkVisitSelIT')[0].setValue(true);
                        }
                        else
                        {
                            Ext.ComponentQuery.query('#chkVisitSelIT')[0].setValue(false);
                        }
                        if(visitSelection.SelForVat=='T')
                        {
                            Ext.ComponentQuery.query('#chkVisitSelVat')[0].setValue(true); 
                        }
                        else
                        {
                            Ext.ComponentQuery.query('#chkVisitSelVat')[0].setValue(false);
                        }
                        if(visitSelection.SelForExcise=='T')
                        {
                            Ext.ComponentQuery.query('#chkVisitSelExcise')[0].setValue(true);
                        }
                        else
                        {
                            Ext.ComponentQuery.query('#chkVisitSelExcise')[0].setValue(false);
                        }

                        if(visitSelection.Status=='F')
                        {
                            msg('INFO','* यो भ्रमण सब्मिट भैसकेको छ। तपाईले यो भ्रमण सच्याउन सक्नु हुन्न।');
                            Ext.ComponentQuery.query('#hdnVisitSelAction')[0].setValue('F');
                            //Convert All Fields To Read Only
                            fields = form.getFields();
                            Ext.each(fields.items, function (f) {
                                f.inputEl.dom.disabled = true;
                            });
                            //Ends Converting Fields To Read Only
                            return;
                        }
                    }
                    else
                    {
                        Ext.ComponentQuery.query('#hdnVisitSelAction')[0].setValue('A');
                    }

                }

            }
        });
    },

    SaveVisitSelection: function(action, form) {
        var me=this;
        var pan=Ext.ComponentQuery.query("#txtVisitSelPan")[0].getValue();
        var selectionDate=Ext.ComponentQuery.query("#txtVisitSelSelectionDate")[0].getValue();
        var visitSelInitiationDate=Ext.ComponentQuery.query('#txtVisitSelInitiationDate')[0].getValue();
        var selForVat=Ext.ComponentQuery.query('#chkVisitSelVat')[0].checked===true?'T':'F';
        var selForIT=Ext.ComponentQuery.query('#chkVisitSelIT')[0].checked===true?'T':'F';
        var selForExcise=Ext.ComponentQuery.query('#chkVisitSelExcise')[0].checked===true?'T':'F';
        var avType=Ext.ComponentQuery.query('#ddlVisSelVisitType')[0].getValue();

        strMsg='';
        if(pan===''||pan===null)
        {
            strMsg+='<BR>* तपाईले प्यान अनिवार्य रूपमा भर्नु पर्नेछ।';
        }
        else if(pan.length!=9)
        {
            strMsg+='<BR>* तपाईले भर्नु भएको प्यान ९ अंकको हुनुपर्छ।';
        }
        if(selectionDate===''||selectionDate===null)
        {
            strMsg+='<BR>* तपाईले छनोट मिति अनिवार्य रूपमा भर्नु पर्नेछ।';
        }

        if(strMsg!=='')
        {
            msg('INFO',strMsg);
            return;
        }


        var VisitOfficers=getJson(Ext.getStore('VisitOfficerStore'));

        var visitSelection={
            PAN:pan,
            SelectionDate:selectionDate,
            OffCode:Ext.get('offCode').dom.innerHTML,
            VisitDate:visitSelInitiationDate,
            SelectionOfficer:'',
            SelEntDate:Ext.get('nepDate').dom.innerHTML,
            SelForVat:selForVat,
            SelForIT:selForIT,
            SelForExcise:selForExcise,
            AVType:avType,
            UserIdSel:'',
            VisitOfficers:VisitOfficers,
            Status:action,
            Action:Ext.ComponentQuery.query('#hdnVisitSelAction')[0].getValue()
        };


        if(strMsg!=='')
        {
            msg('INFO',strMsg);
        }
        else
        {


            if(form)
            {
                //console.log(form);
            }


            //---------------------------------------------------------------------------------------
            //--------------------------  SAVE OR EDIT VISIT SELECTION------------------------------- 
            //---------------------------------------------------------------------------------------

            if(form.isValid()){

                form.submit({
                    url: '../Handlers/Common/Visit/VisitSelectionHandler.ashx',
                    waitMsg: 'Saving Visit Selection..',
                    params:{method:'SaveVisitSelection',
                    visitSelection:JSON.stringify(visitSelection)},
                    success: function(p1, o) {
                        var JSONResponse=Ext.decode(o.response.responseText);
                        if(JSONResponse.success=='True')
                        {  
                            Ext.Msg.show({
                                title:'INFO',
                                msg:action=='I'? 'भ्रमण छनोट सफलतापूर्वक सेभ भयो।':'भ्रमण छनोट सफलतापूर्वक सब्मिट भयो।',
                                buttons: Ext.Msg.OK,
                                fn: function (btn){
                                    if(btn=='ok'){
                                        //Ext.ComponentQuery.query('#lblSPAction')[0].setValue('');
                                        if(action=='I')
                                        Ext.ComponentQuery.query('#hdnVisitSelAction')[0].setValue('E');
                                        else
                                        Ext.ComponentQuery.query('#hdnVisitSelAction')[0].setValue('F');

                                        //me.ResetSpecialPenaltyControls();


                                    }
                                }
                            });
                        }
                        else
                        {
                            msg('INFO','Failed Saving Visit Selection');
                        }
                    },
                    failure:function(fp, o) {
                        alert("err");
                    }
                });

            }

            //---------------------------------------------------------------------------------------
            //-------------------------- END SAVE OR EDIT VISIT SELECTION----------------------------
            //---------------------------------------------------------------------------------------

        }

    },

    ClearControls: function(form) {
        Ext.ComponentQuery.query('#hdnVisitSelAction')[0].setValue('A');

        Ext.ComponentQuery.query('#txtVisitSelPan')[0].setValue('');
        Ext.ComponentQuery.query('#txtVisitSelTaxpayerName')[0].setValue('');
        Ext.ComponentQuery.query('#txtVisitSelSelectionDate')[0].setValue('');
        Ext.ComponentQuery.query('#txtVisitSelInitiationDate')[0].setValue('');
        Ext.ComponentQuery.query('#ddlVisSelVisitType')[0].setValue('');

        Ext.ComponentQuery.query('#chkVisitSelVat')[0].setValue(false);
        Ext.ComponentQuery.query('#chkVisitSelIT')[0].setValue(false);
        Ext.ComponentQuery.query('#chkVisitSelExcise')[0].setValue(false);

        Ext.ComponentQuery.query('#btnVisitSelectionSave')[0].enable(true);
        Ext.ComponentQuery.query('#btnVisitSelectionSubmit')[0].enable(true);
        Ext.ComponentQuery.query('#btnVisitSelectionCancel')[0].enable(true);


        var store=Ext.getStore('VisitOfficerStore');
        store.removeAll();

        var frm=Ext.getCmp('frmVisitSelection');


        fields = form.getFields();
        Ext.each(fields.items, function (f) {
            f.inputEl.dom.disabled = false;
        });


    },

    init: function(application) {
        this.control({
            "#VisitSelection": {
                afterrender: this.onVisitSelectionAfterRender
            },
            "#txtVisitSelPan": {
                blur: this.onTxtVisitSelPanBlur
            },
            "#btnVisitSelAddVisitReason": {
                click: this.onBtnVisitSelAddVisitReasonClick
            },
            "#btnVisitSelectionSave": {
                click: this.onBtnVisitSelectionSaveClick
            },
            "#txtVisitSelSelectionDate": {
                blur: this.onTxtVisitSelSelectionDateBlur,
                blur: this.onTxtVisitSelSelectionDateBlur
            },
            "#btnAVOfficerAdd": {
                click: this.onBtnAVOfficerAddClick
            },
            "#btnVisitSelectionSubmit": {
                click: this.onBtnVisitSelectionSubmitClick
            },
            "#btnVisitSelectionCancel": {
                click: this.onBtnVisitSelectionCancelClick
            },
            "#txtVisitSelInitiationDate": {
                blur: this.onTxtVisitSelInitiationDateBlur
            }
        });
    }

});