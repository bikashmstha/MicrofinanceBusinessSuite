/*
 * File: app/controller/TDSOffVoucherInformation.js
 *
 * This file was generated by Sencha Architect version 3.0.4.
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

Ext.define('MyApp.controller.TDSOffVoucherInformation', {
    extend: 'Ext.app.Controller',

    models: [
        'TDSAccount',
        'TDSPayMode',
        'IROName',
        'TDSVouchInfo',
        'TDSTranList'
    ],
    stores: [
        'TDSAccount',
        'TDSPayMode',
        'IROName',
        'TDSVouchInfo',
        'TDSTranList'
    ],

    onFrmOffVITDSValidAfterRender: function(component, eOpts) {
        var cboBankCode = Ext.ComponentQuery.query("#cboOffVITDSBankCode")[0];
        cboBankCode.setVisible(false);
        var lblBankCode = Ext.ComponentQuery.query("#lblOffVITDSBankCode")[0];
        lblBankCode.setVisible(false);

        var tranNo = Ext.ComponentQuery.query("#dpfOffVITDSTran")[0];
        var vdate = Ext.ComponentQuery.query("#hdnOffVITDSvdate")[0];

        var str = Ext.getStore('TDSVouchInfo');

        str.load({
            params:{TranNo:tranNo.getValue()}
        });

        Ext.Ajax.request({
            url:"../Handlers/TDS/InsertTransactionHandler.ashx?method=GetTrans",

            params: {
                TranNo:tranNo.getValue(),vDate:vdate.getValue()
            },
            success: function( result, request){

                var obj = Ext.decode(result.responseText);
                var data = obj.root;
                var actTotal = Ext.ComponentQuery.query("#hdnOffVITDSAction")[0];

                var tTotal = 0;

                for(var j=0;j<obj.total;j++)
                {
                    tTotal = tTotal+data[j].TDSAmt;
                }

                actTotal.setValue(tTotal);
            },
            failure: function ( result, request ){

                waitSave.hide();

                msg("FAILURE","Login Failed !!!");
                return;
            }
        });
    },

    onCboOffVITDSPayModeChange: function(field, newValue, oldValue, eOpts) {
        var cboBankCode = Ext.ComponentQuery.query("#cboOffVITDSBankCode")[0];
        var cboCashCode = Ext.ComponentQuery.query("#cboOffVITDSIRDCode")[0];
        var lblBankCode = Ext.ComponentQuery.query("#lblOffVITDSBankCode")[0];
        var lblCashCode = Ext.ComponentQuery.query("#lblOffVITDSCashCode")[0];
        var txtBranchCode = Ext.ComponentQuery.query("#txtOffVITDSBranchCode")[0];

        if(newValue=="Cash")
        {
            cboCashCode.setVisible(true);
            lblCashCode.setVisible(true);
            cboBankCode.setVisible(false);
            lblBankCode.setVisible(false);
            txtBranchCode.setValue('999');
        }
        else if(newValue=="Bank")
        {
            cboBankCode.setVisible(true);
            lblBankCode.setVisible(true);
            cboCashCode.setVisible(false);
            lblCashCode.setVisible(false);
        }
    },

    onBtnOffVITDSVerifyClick: function(button, e, eOpts) {
        var valTotal = Ext.ComponentQuery.query("#hdnOffVITDSVal")[0].getValue();
        var actTotal = Ext.ComponentQuery.query("#hdnOffVITDSAction")[0].getValue();

        console.log("valTotal",valTotal);
        if(valTotal!==actTotal)
        {
            msg("WARNING","TDS amount doesn't match");
            return false;
        }

        var me = this;
        me.Verify();
    },

    onBtnOffVITDSTranInfoClick: function(button, e, eOpts) {
        var me = this;

        var tranNo = Ext.ComponentQuery.query("#dpfOffVITDSTran")[0];
        var whPan = Ext.ComponentQuery.query("#dpfOffVITDSWithPan")[0];
        var whName = Ext.ComponentQuery.query("#dpfOffVITDSWithName")[0];
        var offFrom = Ext.ComponentQuery.query("#dpfOffVITDSFrom")[0];
        var offTo = Ext.ComponentQuery.query("#dpfOffVITDSTo")[0];
        var type = Ext.ComponentQuery.query("#dpfOffVITDSType")[0];
        var vdate = Ext.ComponentQuery.query("#hdnOffVITDSvdate")[0];

        var username = Ext.ComponentQuery.query("#hdnOffVITDSuser")[0];
        var pwd = Ext.ComponentQuery.query("#hdnOffVITDSpwd")[0];
        var subdate = Ext.ComponentQuery.query("#hdnOffVITDSsubdate")[0];
        var mail = Ext.ComponentQuery.query("#hdnOffVITDSmail")[0];
        var phoneNo = Ext.ComponentQuery.query("#hdnOffVITDSphone")[0];
        var addr = Ext.ComponentQuery.query("#hdnOffVITDSadd")[0];
        var tso = Ext.ComponentQuery.query("#hdnOffVITDStso")[0];
        var ird = Ext.ComponentQuery.query("#hdnOffVITDSird")[0];

        me.getController('MyApp.controller.TDSOffInsertRecPage').init();
        me.getController('MyApp.controller.TDSOffInsertRecPage').ShowOffRec(tranNo.getValue(),whPan.getValue(),whName.getValue(),offFrom.getValue(),offTo.getValue(),type.getValue(),vdate.getValue(),username.getValue(),pwd.getValue(),subdate.getValue(),mail.getValue(),phoneNo.getValue(),addr.getValue(),tso.getValue(),ird.getValue());
    },

    ShowVoucherInfo: function(tran, pan, name, from, to, dateType, vouchDate, user, pass, subDate, mailID, phone, add, tsoCode, irdCode) {
        var pnlToRender = Ext.getCmp('cntOMTDS');
        var pnlDynamic = Ext.create('MyApp.view.TDSOffVoucherInformation');

        var tranNo = Ext.ComponentQuery.query("#dpfOffVITDSTran")[0];
        var whPan = Ext.ComponentQuery.query("#dpfOffVITDSWithPan")[0];
        var whName = Ext.ComponentQuery.query("#dpfOffVITDSWithName")[0];
        var offFrom = Ext.ComponentQuery.query("#dpfOffVITDSFrom")[0];
        var offTo = Ext.ComponentQuery.query("#dpfOffVITDSTo")[0];
        var type = Ext.ComponentQuery.query("#dpfOffVITDSType")[0];

        var vdate = Ext.ComponentQuery.query("#hdnOffVITDSvdate")[0];
        var username = Ext.ComponentQuery.query("#hdnOffVITDSuser")[0];
        var pwd = Ext.ComponentQuery.query("#hdnOffVITDSpwd")[0];
        var subdate = Ext.ComponentQuery.query("#hdnOffVITDSsubdate")[0];
        var mail = Ext.ComponentQuery.query("#hdnOffVITDSmail")[0];
        var phoneNo = Ext.ComponentQuery.query("#hdnOffVITDSphone")[0];
        var addr = Ext.ComponentQuery.query("#hdnOffVITDSadd")[0];
        var tso = Ext.ComponentQuery.query("#hdnOffVITDStso")[0];
        var ird = Ext.ComponentQuery.query("#hdnOffVITDSird")[0];

        tranNo.setValue(tran);
        whPan.setValue(pan);
        whName.setValue(name);
        offFrom.setValue(from);
        offTo.setValue(to);
        type.setValue(dateType);

        vdate.setValue(vouchDate);
        username.setValue(user);
        pwd.setValue(pass);
        subdate.setValue(subDate);
        mail.setValue(mailID);
        phoneNo.setValue(phone);
        addr.setValue(add);
        tso.setValue(tsoCode);
        ird.setValue(irdCode);

        pnlToRender.removeAll();
        pnlToRender.add(pnlDynamic);

        Ext.Ajax.request({
            url:"../Handlers/TDS/VoucherInformationHandler.ashx?method=GetVouchInfo",
            params: {
                TranNo:tranNo.getValue()
            },
            success: function( result, request){

                var obj = Ext.decode(result.responseText);
                var data = obj.root;
                var valTotal = Ext.ComponentQuery.query("#hdnOffVITDSVal")[0];
                var vTotal = 0;

                for(var k=0;k<obj.total;k++)
                {
                    vTotal = vTotal+data[k].Amt;
                }
                valTotal.setValue(vTotal);

            },
            failure: function ( result, request ){

                waitSave.hide();

                msg("FAILURE","Login Failed !!!");
                return;
            }
        });

        /*var store = Ext.getStore('TDSOffTranList');

        store.load({
        params:{TranNo:tranNo.getValue(),vDate:vdate.getValue()}
        });

        var total = 0;
        console.log("count",store.count());

        for(var j=0;j<store.count();j++)
        {
        var drow = store.getAt(j).data;
        total = total+drow.TDSAmt;
        console.log("total",total);
        }*/

        //var str = Ext.getStore('TDSVouchInfo');

        //str.load({
        //  params:{TranNo:tranNo.getValue()}
        //});
        //console.log("str",str.count());

        /*var vTotal = 0;

        var itm = Ext.getStore('TDSVouchInfo').data.items;
        console.log("itm",itm);

        for(var k=0;k<itm.length;k++)
        {
        console.log("tds amt",itm[k].data.Amt);
        vTotal = vTotal+itm[k].data.Amt;
        console.log("total",total);
        }*/
    },

    Clear: function() {
        var cboAcc = Ext.ComponentQuery.query("#cboOffVITDSAccNo")[0];
        var txtVouchNo = Ext.ComponentQuery.query("#txtOffVITDSVouchNo")[0];
        var cboPayMode = Ext.ComponentQuery.query("#cboOffVITDSPayMode")[0];
        var txtPayDate = Ext.ComponentQuery.query("#txtOffVITDSPayDate")[0];
        var cboIRDCode = Ext.ComponentQuery.query("#cboOffVITDSIRDCode")[0];
        var cboBankCode = Ext.ComponentQuery.query("#cboOffVITDSBankCode")[0];
        var txtBranchCode = Ext.ComponentQuery.query("#txtOffVITDSBranchCode")[0];
        var txtTDSAmt = Ext.ComponentQuery.query("#txtOffVITDSAmt")[0];
        var hdnAction = Ext.ComponentQuery.query("#hdnOffVITDSAction")[0];

        cboAcc.setValue('');
        txtVouchNo.setValue('');
        cboPayMode.setValue('');
        txtPayDate.setValue('');
        cboIRDCode.setValue('');
        cboBankCode.setValue('');
        txtBranchCode.setValue('');
        txtTDSAmt.setValue('');
        hdnAction.setValue('');
    },

    Verify: function() {
        var me = this;

        var tranNo = Ext.ComponentQuery.query("#dpfOffVITDSTran")[0];
        /*var whPan = Ext.ComponentQuery.query("#dpfOffVITDSWithPan")[0].getValue();
        var whName = Ext.ComponentQuery.query("#dpfOffVITDSWithName")[0].getValue();
        var offFrom = Ext.ComponentQuery.query("#dpfOffVITDSFrom")[0].getValue();
        var offTo = Ext.ComponentQuery.query("#dpfOffVITDSTo")[0].getValue();
        var type = Ext.ComponentQuery.query("#dpfOffVITDSType")[0].getValue();

        var vdate = Ext.ComponentQuery.query("#hdnOffVITDSvdate")[0];
        var username = Ext.ComponentQuery.query("#hdnOffVITDSuser")[0].getValue();
        var pwd = Ext.ComponentQuery.query("#hdnOffVITDSpwd")[0].getValue();
        var subdate = Ext.ComponentQuery.query("#hdnOffVITDSsubdate")[0].getValue();
        var mail = Ext.ComponentQuery.query("#hdnOffVITDSmail")[0].getValue();
        var phoneNo = Ext.ComponentQuery.query("#hdnOffVITDSphone")[0].getValue();
        var addr = Ext.ComponentQuery.query("#hdnOffVITDSadd")[0].getValue();
        var tso = Ext.ComponentQuery.query("#hdnOffVITDStso")[0].getValue();
        var ird = Ext.ComponentQuery.query("#hdnOffVITDSird")[0].getValue();
        console.log(ird);*/

        /*var detail ={
        TranNo:tranNo.getValue()
        Username:username,
        Password:pwd,
        WhPan:whPan,
        WhName:whName,
        IrdCode:ird,
        DateType:type,
        FromDate:offFrom,
        ToDate:offTo,
        Status:"V",
        EmailID:mail,
        PhoneNo:phoneNo,
        WhAddress:addr,
        TsoCode:tso,
        VoucherDate:vdate.getValue()
        };*/

        Ext.Ajax.request({
            url:"../Handlers/TDS/GetTransactionHandler.ashx?method=TransferData",
            params:{TranNo:tranNo.getValue()},
            success: function ( result, request ){

                //waitSave.hide();

                var obj = Ext.decode(result.responseText);
                var data = obj.root;

                /*var tran = data.TranNo;
                var user = data.Username;
                var withPan = data.WhPan;
                var withName = data.WhName;
                var iroName = data.IrdCode;
                var tsoName = data.TsoCode;
                var phone = data.PhoneNo;
                var add = data.WhAddress;
                var fromDate = data.FromDate;
                var toDate = data.ToDate;
                var dateType = data.DateType;
                var vouchDate = data.VoucherDate;
                var mailID = data.EmailID;
                var pass = data.Password;*/

                if(obj.success === "true")
                {
                    msg("SUCCESS","Successfully Verified");
                }
                else if(obj.success === "false")
                {
                    msg("FAILURE",obj.message);
                    return;
                }

            },

            failure: function ( result, request ){

                return;
            }

        });




        /*
        //SaveEdit

        var me = this;

        var dpfTran = Ext.ComponentQuery.query("#dpfOffVITDSTran")[0].getValue();
        var cboAcc = Ext.ComponentQuery.query("#cboOffVITDSAccNo")[0].getValue();
        var txtVouchNo = Ext.ComponentQuery.query("#txtOffVITDSVouchNo")[0].getValue();
        var cboPayMode = Ext.ComponentQuery.query("#cboOffVITDSPayMode")[0].getValue();
        var txtPayDate = Ext.ComponentQuery.query("#txtOffVITDSPayDate")[0].getValue();
        var cboIRDCode = Ext.ComponentQuery.query("#cboOffVITDSIRDCode")[0].getValue();
        var cboBankCode = Ext.ComponentQuery.query("#cboOffVITDSBankCode")[0].getValue();
        var txtBranchCode = Ext.ComponentQuery.query("#txtOffVITDSBranchCode")[0].getValue();
        var txtTDSAmt = Ext.ComponentQuery.query("#txtOffVITDSAmt")[0].getValue();
        var code = "";
        var enteredBy = "pcs";

        if(cboIRDCode!=="")
        {
            code = cboIRDCode;
        }
        else if(cboBankCode!=="")
        {
            code = cboBankCode;
        }

        var hdnAction = Ext.ComponentQuery.query("#hdnOffVITDSAction")[0].getValue();

        var param = {
            TranNo:dpfTran,
            TrAcctNo:cboAcc,
            VouchNo:txtVouchNo,
            PayMode:cboPayMode,
            PayDate:txtPayDate,
            BankCode:code,
            BranchCode:txtBranchCode,
            Amt:txtTDSAmt,
            DateType:"BS",
            RecStatus:value,
            Action:hdnAction,
            EnteredBy:enteredBy
        };

        Ext.Ajax.request({
            url:"../Handlers/TDS/VoucherInformationHandler.ashx?method=SaveVouchInfo",
            params:{objVouch:JSON.stringify(param)},
            success: function ( result, request ){

                var obj = Ext.decode(result.responseText);
                //var data = obj.root;

                console.log("tranno",dpfTran);
                if(obj.success === "true")
                {
                    msg("SUCCESS",obj.message);

                    var store = Ext.getStore('TDSVouchInfo');
                    store.load({
                        params:{TranNo:dpfTran}
                    });

                    var btnAdd = Ext.ComponentQuery.query("#btnOffVITDSAdd")[0];
                    btnAdd.setText('Add');
                    me.Clear();
                }
                else if(obj.success === "false")
                {
                    msg("FAILURE",obj.message);
                    return;
                }
            },

            failure: function ( result, request ){

                return;
            }

        });*/
    },

    init: function(application) {
        this.control({
            "#frmOffVITDSValid": {
                afterrender: this.onFrmOffVITDSValidAfterRender
            },
            "#cboOffVITDSPayMode": {
                change: this.onCboOffVITDSPayModeChange
            },
            "#btnOffVITDSVerify": {
                click: this.onBtnOffVITDSVerifyClick
            },
            "#btnOffVITDSTranInfo": {
                click: this.onBtnOffVITDSTranInfoClick
            }
        });
    }

});
