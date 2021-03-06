/*
 * File: app/controller/LastMonthVoucher.js
 *
 * This file was generated by Sencha Architect version 4.2.2.
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

Ext.define('MyApp.controller.LastMonthVoucher', {
    extend: 'Ext.app.Controller',

    stores: [
        'FiscaYearStore',
        'RecVoucParticularStore',
        'DestinationFormatStore',
        'RecVoucherSearchStore',
        'RecVoucherLoadStore'
    ],

    onFrmLastMonthVoucherAfterRender: function(component, eOpts) {
        Ext.ComponentQuery.query('#txtTransactionDateBS')[0].setValue(getMisDateBS());
        Ext.ComponentQuery.query('#txtTransactionDateAD')[0].setValue(getMisDateAD());

        Ext.Ajax.request({
              url: '../Handlers/Common/FiscalYearHandler.ashx',
              params: {
                  method:'GetLastFiscalYearList',
                  OfficeCode:getOfficeCode()
              },
              success: function(response){
                  var data=Ext.decode(response.responseText);
                  var fiscaYearStore=Ext.getStore('FiscaYearStore');
                  fiscaYearStore.removeAll();
                  fiscaYearStore.add(data.root);
              }
          });

        var storeRecVoucParticular =Ext.getStore('RecVoucParticularStore');
        getParticularsLov('',function(data){
            storeRecVoucParticular.removeAll();
            storeRecVoucParticular.add(data.root);
        });

        var destinationFormatStore=Ext.getStore('DestinationFormatStore');
        getReferences('REPORTS_DESFORMAT',function(data){
            destinationFormatStore.removeAll();
            destinationFormatStore.add(data.root);
        });


         Ext.Ajax.request({
                      url: '../Handlers/Finance/AccountTransaction/JvSearchVoucherHandler.ashx',
                      params: {
                          method:'GetJvSearchVoucher',
                          OfficeCode:getOfficeCode(),VoucherNo:''
                      },
                      success: function(response){
                          var data=Ext.decode(response.responseText);
                          var recVoucherSearchStore=Ext.getStore('RecVoucherSearchStore');
                          recVoucherSearchStore.removeAll();
                          recVoucherSearchStore.add(data.root);
                      }
                  });


        Ext.Ajax.request({
                      url: '../Handlers/Finance/AccountTransaction/VoucherAccountHandler.ashx',
                      params: {
                          method:'GetVoucherAcc',
                          OfficeCode:getOfficeCode(),VoucherNo:''
                      },
                      success: function(response){
                          var data=Ext.decode(response.responseText);
                          var recVoucherSearchStore=Ext.getStore('RecVoucherSearchStore');
                          recVoucherSearchStore.removeAll();
                          recVoucherSearchStore.add(data.root);
                      }
                  });





    },

    onBtnSaveClick: function(button, e, eOpts) {
        //ReceiveVoucherDetails
        var grdRecVouDetails = Ext.ComponentQuery.query('#grdRecVouDetails')[0];
        var storeVoucherDetailsRecStore = Ext.getStore('VoucherDetailsRecStore');
        var selectionT = grdRecVouDetails.getSelectionModel().getSelection()[0];
        var selectedIndxT= grdRecVouDetails.getStore().indexOf(selectionT);
        var utStore1 =grdRecVouDetails.getStore();
        var crAmount=utStore1.getAt(selectedIndxT).data.CrAmount;
        console.log(crAmount);




        var grdVoucherLoad = Ext.ComponentQuery.query('#grdVoucherCollection')[0];
        var storeVoucherLoad = Ext.getStore('RecVoucherLoadStore');
        var selectionT = grdVoucherLoad.getSelectionModel().getSelection()[0];
        var selectedIndxT= grdVoucherLoad.getStore().indexOf(selectionT);
        var utStore =grdVoucherLoad.getStore();
        var approvedBy=utStore.getAt(selectedIndxT).data.ApprovedBy;




        var p_FiscalYear = Ext.ComponentQuery.query('#txtFiscalYear')[0];
        var p_TransactionDate = Ext.ComponentQuery.query('#txtTransactionDateBS')[0];
        var p_Particulars = Ext.ComponentQuery.query('#ddlParticulars')[0];
        var p_ModifiedFlag = 'N';
        var p_AuditedFlag = 'N';
        var p_AuditedDate = null;
        var p_AuditedBy = null;
        var p_Remarks = Ext.ComponentQuery.query('#txtRemarks')[0];
        var p_ApprovedNo = null;
        var p_ApprovedFlag = 'N';
        var p_PostedYN = 'N';
        var p_ReferenceNo =null;
        var p_CreatedBy = Ext.get('user').dom.innerHTML;
        var p_CreatedOn = Ext.get('date').dom.innerHTML;
        var p_TranOfficeCode = Ext.get('offCode').dom.innerHTML;
        var p_VoucherType ='J';
        var p_CloseFlag = 'N';
        var p_VoucherNoAgainst =null;
        var p_ChequeBillNo = Ext.ComponentQuery.query('#txtChequeBillNo')[0];
        var p_VoucherNoReference =null;
        var p_VoucherSeqNo = '';
        var p_ApprovedDate = null;
        var p_ApprovedDateBs = null;
        var p_ApprovedBy = utStore.getAt(selectedIndxT).data.ApprovedBy===null?null:utStore.getAt(selectedIndxT).data.ApprovedBy;
        var p_TotalDrAmount = Ext.ComponentQuery.query('#TotalDrAmount')[0];
        var p_InsertUpdate = Ext.ComponentQuery.query('#InsertUpdate')[0];
        var p_OutVoucherNo = Ext.ComponentQuery.query('#txtVoucherNo')[0];
        var p_OutHistSeq_No = Ext.ComponentQuery.query('#OutHistSeq_No')[0];



        var glTransactionDetail=
            {
                voucherNo:'',
                TransactionDate:p_TransactionDate.getValue(),
                TransactionId:TransactionId,
                TranOfficeCode:TranOfficeCode,
                AccountCode:AccountCode,
                Particulars:p_Particulars.getValue(),
                Amount:utStore.getAt(selectedIndxT).data.Amount===null?null:utStore.getAt(selectedIndxT).data.Amount,
                DrCrFlag:'',
                Remarks:p_Remarks.getValue(),
                CurrencyCode:'',
                TranType:'',
                DmlType:''
            };
        var objglTransactionMaster ={
                        FiscalYear : p_FiscalYear.getValue(),
                        TransactionDate : p_TransactionDate.getValue(),
                        Particulars : p_Particulars.getValue(),
                        ModifiedFlag : p_ModifiedFlag.getValue(),
                        AuditedFlag : p_AuditedFlag.getValue(),
                        AuditedDate : p_AuditedDate.getValue(),
                        AuditedBy : p_AuditedBy.getValue(),
                        Remarks : p_Remarks.getValue(),
                        ApprovedNo : p_ApprovedNo,
                        ApprovedFlag : p_ApprovedFlag,
                        PostedYN : p_PostedYN.getValue(),
                        ReferenceNo : p_ReferenceNo.getValue(),
                        CreatedBy : p_CreatedBy,
                        CreatedOn : p_CreatedOn,
                        TranOfficeCode : p_TranOfficeCode,
                        VoucherType : p_VoucherType.getValue(),
                        CloseFlag : p_CloseFlag.getValue(),
                        VoucherNoAgainst : p_VoucherNoAgainst.getValue(),
                        ChequeBillNo : p_ChequeBillNo.getValue(),
                        VoucherNoReference : p_VoucherNoReference.getValue(),
                        VoucherSeqNo : p_VoucherSeqNo.getValue(),
                        ApprovedDate : p_ApprovedDate,
                        ApprovedDateBs : p_ApprovedDateBs,
                        ApprovedBy : p_ApprovedBy,
                        TotalDrAmount : p_TotalDrAmount.getValue(),
                        InsertUpdate : 'A',
                        OutVoucherNo : p_OutVoucherNo.getValue(),
                        OutHistSeq_No : '',
                        GlTransactionDetail:glTransactionDetail
        };

        //start Code for Save
        var waitSave = watiMsg('Please wait ...');
        Ext.Ajax.request({
             url:'../Handlers/Finance/AccountTransaction/GlTransactionMasterHandler.ashx',
             params:{method:'SaveGlTransactionMaster',glTransactionMaster:JSON.stringify(objglTransactionMaster)},
             success: function ( result, request ) {
        waitSave.hide();
                  var obj = Ext.decode(result.responseText);
                  if(obj.success === 'true'){
         msg('SUCCESS',out.message,function(){
        var grd = Ext.ComponentQuery.query('#grdGlTransactionMaster')[0];
        var record = grd.getSelectionModel().getSelection()[0];
        record.set('Action','U');
        });
        }
                  else{msg('FAILURE',out.message);


                  }
             },
             failure: function(form, action) {
        waitSave.hide();
        var out=Ext.decode(response.responseText);
        msg('FAILURE',out.message);     }
        });

    },

    onBtnSearchClick: function(button, e, eOpts) {
        var officeCode =Ext.get('offCode').dom.innerHTML;
        var voucherNo = Ext.ComponentQuery.query('#ddlJVoucherNo')[0].getValue();
        var fromDate = '';
        var toDate = '';


        Ext.Ajax.request
        ({
            url:'../Handlers/Finance/AccountTransaction/JvMasterDetailHandler.ashx?method=GetJvMstDetail',
                            params:{OfficeCode:officeCode,VoucherNo:voucherNo,FromDate:fromDate,ToDate:toDate},
                            success: function(result, request) {
                                var obj = Ext.decode(result.responseText);
                                console.log('obj',obj.root);
                                if (obj.success != "true")
                                {
                                    showMessage('ERROR OCURRED !!!',obj.message);
                                }
                                else
                                {
                                    var recVoucherLoadStore =Ext.getStore('RecVoucherLoadStore');
                                    recVoucherLoadStore.removeAll();
                                    recVoucherLoadStore.add(obj.root);

                                }
                            },
                            failure: function(result, request) {
                                var obj = Ext.decode(result.responseText);

                                msg("FAILURE","Generated Failed");
                                return;
                            }
                        });
    },

    init: function(application) {
        this.control({
            "#frmLastMonthVoucher": {
                afterrender: this.onFrmLastMonthVoucherAfterRender
            },
            "#btnSave": {
                click: this.onBtnSaveClick
            },
            "#btnSearch": {
                click: this.onBtnSearchClick
            }
        });
    }

});
