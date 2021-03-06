/*
 * File: app/controller/FiscalYear.js
 *
 * This file was generated by Sencha Architect version 2.1.0.
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

Ext.define('MyApp.controller.FiscalYear', {
    extend: 'Ext.app.Controller',

    stores: [
        'FiscalYear'
    ],

    onGridpanelItemClick: function(tablepanel, record, item, index, e, options) {
        Ext.ComponentQuery.query('#txtFiscalYrFY')[0].setValue(record.data.fiscalYear);
        Ext.ComponentQuery.query('#txtStartDtFY')[0].setValue(record.data.startDate);
        Ext.ComponentQuery.query('#txtEndDateFY')[0].setValue(record.data.endDate);
        Ext.ComponentQuery.query('#txtLstFiscalYearFY')[0].setValue(record.data.lastFiscalYear);
        Ext.ComponentQuery.query('#txtCurrentFY')[0].setValue(record.data.currentFiscalYear);
        Ext.ComponentQuery.query('#txtTerminalFY')[0].setValue(record.data.terminal);
        Ext.ComponentQuery.query('#txtTransDateFY')[0].setValue(record.data.tranDate);
        Ext.ComponentQuery.query('#txtUsernameFY')[0].setValue(record.data.userName);
        Ext.ComponentQuery.query('#txtActiveYnFY')[0].setValue(record.data.activeYn);

        Ext.ComponentQuery.query('#btnFiscalYearSubmit')[0].setText('Update');
    },

    onBtnDocSubmitClick: function(button, e, options) {
        console.log("fired !!!");


        var txtDocTypeID = button.up('panel').down('textfield[itemId=txtDocTypeID]');
        var txtDocTypeDescEn = button.up('panel').down('textfield[itemId=txtDocTypeDescEn]');
        var txtDocTypeDescNp = button.up('panel').down('textfield[itemId=txtDocTypeDescNp]');
        var chkDocStatus = button.up('panel').down('checkboxfield[itemId=chkDocStatus]');


        var strDocTyp = Ext.getStore('DocType');

        var status = "";


        if(strDocTyp.checked)
        status = "Y";
        else
        status = "N";



        var postData = {option:'Save',
            DocId:txtDocTypeID.getValue(),
            DocTypeDecEn:txtDocTypeDescEn.getValue(),
            DocTypeDescNp:txtDocTypeDescNp.getValue(),
            Status:chkDocStatus
        } ;


        Ext.Ajax.request({
            url: '../Handlers/Common/DocTypeHandler.ashx',
            params: postData,
            success: function ( result, request ) {
                // var jsonData = Ext.JSON.decode(result.responseText);
                //console.log("res : " + result.responseText);
                //  console.log("jsonData1 : " + jsonData);
                // var resultMessage = jsonData.data.result;
                //   console.log("resultMessage1 : " + resultMessage);
                //this.fnAlertMsg(resultMessage, 'Success');
                //this.Msg('Successfully Saved.', 'Success');


                strAddrTyp.load();

                Ext.Msg.show({
                    title: 'Success',
                    msg: 'Successfully Saved.' ,
                    buttons: Ext.MessageBox.OK,
                    icon: Ext.MessageBox.INFO
                });

            },
            failure: function ( result, request ) {
                /* var jsonData = Ext.JSON.decode(result.responseText);

                console.log("jsonData2 : " + jsonData);
                var resultMessage = jsonData.data.result;
                console.log("resultMessage2 : " + resultMessage);
                this.fnAlertMsg(resultMessage, 'Error');*/
                this.fnAlertMsg('ERROR OCURRED !!!', 'Error');
            }

        });

        console.log("over");
    },

    init: function(application) {
        this.control({
            "#gridFiscalYear": {
                itemclick: this.onGridpanelItemClick
            },
            "#btnFiscalYearSubmit": {
                click: this.onBtnDocSubmitClick
            }
        });
    }

});
