/*
 * File: app/controller/MemberEntry.js
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

Ext.define('MyApp.controller.MemberEntry', {
    extend: 'Ext.app.Controller',

    stores: [
        'SearchGroupStore',
        'CasteCodeStore',
        'InsuranceCodeStore',
        'ReligionCodeStore',
        'InsuranceCompanyStore',
        'SearchMemberStore',
        'MemberCodeStore',
        'OccupationCodeStore',
        'CenterCodeStore'
    ],

    onBtnCreateMemberClick: function(button, e, eOpts) {

        /*
        var member ={
                        FiscalYear : 'AA',
                        ClientNo : '01020000005',
                        ClientCode : '010200480113',
                        GroupCode : '0102003501',
                        MembershipDate : '20-mar-2017',
                        Address : 'AA',
                        MaritalStatus : 'AA',
                        FatherName : 'AA',
                        SpouseName : 'AA',
                        BirthYear : 1,
                        NoBoyChild : 1,
                        NoGirlChild : 1,
                        NomineeName : 'AA',
                        NomineeRelation : 'AA',
                        IdDocumentType : 'AA',
                        IdDocumentNo : 'AA',
                        LoanYear : 1,
                        MemberType : 'AA',
                        EmployeeId : 'AA',
                        CasteCode : '17',
                        Fname : 'AA',
                        Lname : 'AA',
                        MembershipCloseDate : '20-mar-2017',
                        PostalAddress : 'AA',
                        Gender : 'F',
                        OccupationCode : '1',
                        EducationCode : '4',
                        Active : 'Y',
                        ChildrenNo : 1,
                        FieldAssistantId : 'AA',
                        ReasonForInactive : 'AA',
                        Signature3 : 'AA',
                        Signature2 : 'AA',
                        Signature1 : 'AA',
                        ImagePath : 'AA',
                        TranOfficeCode : 'AA',
                        CreatedOn : 'AA',
                        CreatedBy : 'AA',
                        ModifiedOn : 'AA',
                        ModifiedBy : 'AA',
                        LastChangeDate : 'AA',
                        TransferDate : 'AA',
                        FixedCollectionAmount : 1,
                        CenterCode : 'AA',
                        ThirdPartyData : 'AA',
                        Dob : '20-mar-2017',
                        TelephoneNo : '9841256987',
                        MobileNo : '9841256987',
                        FaxNo : 'AA',
                        JointImagePath : 'AA',
                        GrandFatherName : 'AA',
                        MinorYN : 'AA',
                        MinorName : 'AA',
                        MinorRelation : 'AA',
                        EmailAddress : 'AA',
                        FingerPrintLeft : 'AA',
                        FingerPrintRight : 'AA',
                        IdIssueDistrictCode : 'AA',
                        FatherInlawName : 'AA',
                        HusbandName : 'AA',
                        IdentityOwnBy : 'AA',
                        ReasonCode : 'AA',
                        RefClientNo : 'AA',
                        MemIdentityIssueDate : '20-mar-2017',
                        HusIdentityType : 'AA',
                        HusIdentityNo : 'AA',
                        HusIdentityIssueDistrict : 'AA',
                        HusIdentityIssueDate : '20-mar-2017',
                        Address1Type : 'AA',
                        Address1Line2 : 'AA',
                        Address1Line3 : 'AA',
                        Address1District : 'AA',
                        Address2Type : 'AA',
                        Address2Line1 : 'AA',
                        Address2Line2 : 'AA',
                        Address2Line3 : 'AA',
                        Address2District : 'AA',
                        ReligionCode : 'AA',
        				Action : 'I'
        };
        */

        var objMem ={
                       // FiscalYear : 'AA',
                     // ClientNo : '',
                     // ClientCode : '',
                        GroupCode : Ext.ComponentQuery.query('#txtGroup')[0].getValue(),
                        MembershipDate :Ext.ComponentQuery.query('#txtMemberDateAD')[0].getValue() ,
        				Address : Ext.ComponentQuery.query('#txtStreetAddress')[0].getValue(),
                        MaritalStatus : Ext.ComponentQuery.query('#ddlMaritalStatus')[0].getValue(),
                        FatherName : Ext.ComponentQuery.query('#txtFatherName')[0].getValue(),
                        SpouseName : Ext.ComponentQuery.query('#txtSpouseName')[0].getValue(),
                        //BirthYear : 1,
                        NoBoyChild : Ext.ComponentQuery.query('#txtBoyNo')[0].getValue(),
                        NoGirlChild : Ext.ComponentQuery.query('#txtGirlNo')[0].getValue(),
                        NomineeName : Ext.ComponentQuery.query('#txtNomineeName')[0].getValue(),
                        NomineeRelation : Ext.ComponentQuery.query('#ddlNomineeRelation')[0].getValue(),
                        IdDocumentType : Ext.ComponentQuery.query('#ddlMemberIdentityType')[0].getValue(),
                        IdDocumentNo : Ext.ComponentQuery.query('#txtCitizenshipNo')[0].getValue(),
                       // LoanYear : 1,
                        MemberType : Ext.ComponentQuery.query('#ddlMemberType')[0].getValue(),
                     //   EmployeeId : 'AA',
                        CasteCode : Ext.ComponentQuery.query('#txtCasteCode')[0].getValue(),
                        Fname : Ext.ComponentQuery.query('#txtFirstName')[0].getValue(),
                        Lname : Ext.ComponentQuery.query('#txtLastName')[0].getValue(),
                        MembershipCloseDate : Ext.ComponentQuery.query('#txtClosedDateAD')[0].getValue(),
                        PostalAddress : Ext.ComponentQuery.query('#txtPostalAddress')[0].getValue(),
                        Gender : Ext.ComponentQuery.query('#ddlGender')[0].getValue(),//'F',
                        OccupationCode : Ext.ComponentQuery.query('#ddlOccupation')[0].getValue(),
                        EducationCode : Ext.ComponentQuery.query('#ddlEducation')[0].getValue(),
                        Active : 'Y',
                        ChildrenNo : Ext.ComponentQuery.query('#txtChildrenNo')[0].getValue(),
                        FieldAssistantId : Ext.ComponentQuery.query('#txtFieldAssistant')[0].getValue(),
                      //  ReasonForInactive : 'AA',
                      //  Signature3 : 'AA',
                      //  Signature2 : 'AA',
                      //  Signature1 : 'AA',
                     //   ImagePath : Ext.ComponentQuery.query('#imgMember')[0].getValue(),
                        TranOfficeCode : '01020',
                      //  CreatedOn : 'AA',
                      //  CreatedBy : 'AA',
                     //   ModifiedOn : 'AA',
                     //   ModifiedBy : 'AA',
                      //  LastChangeDate : 'AA',
                      //  TransferDate : 'AA',
                        FixedCollectionAmount : Ext.ComponentQuery.query('#txtPensionFixedAmt')[0].getValue(),
        				//InsuranceNumber: Ext.ComponentQuery.query('#txtInsuranceNo')[0];,
        				//InsuranceDate: Ext.ComponentQuery.query('#txtInsuranceDate')[0];,
                    //    CenterCode : 'AA',
                    //    ThirdPartyData : 'AA',
                        Dob : Ext.ComponentQuery.query('#txtDateOfBirthAD')[0].getValue(),
                        TelephoneNo : Ext.ComponentQuery.query('#txtTelephoneNo')[0].getValue(),
                        MobileNo : Ext.ComponentQuery.query('#txtMobileNo')[0].getValue(),
                        FaxNo : Ext.ComponentQuery.query('#txtFaxNo')[0].getValue(),
                    //    JointImagePath : 'AA',
                        GrandFatherName : Ext.ComponentQuery.query('#txtGrandfatherName')[0].getValue(),
                    //    MinorYN : 'AA',
                    //    MinorName : 'AA',
                    //    MinorRelation : 'AA',
                        EmailAddress : Ext.ComponentQuery.query('#txtEmail')[0].getValue(),
                   //     FingerPrintLeft : 'AA',
                    //    FingerPrintRight : 'AA',
                        IdIssueDistrictCode : Ext.ComponentQuery.query('#txtCitizenshipIssuedDistrict')[0].getValue(),
                        FatherInlawName : Ext.ComponentQuery.query('#txtFatherInLawName')[0].getValue(),
                        HusbandName : Ext.ComponentQuery.query('#txtHusbandName')[0].getValue(),
                    //    IdentityOwnBy : 'AA',
                   //     ReasonCode : 'AA',
                   //     RefClientNo : 'AA',
                        MemIdentityIssueDate : Ext.ComponentQuery.query('#txtCitizenshipIssuedDateAD')[0].getValue(),
                        HusIdentityType : Ext.ComponentQuery.query('#ddlHusbandIdentityType')[0].getValue(),
                        HusIdentityNo : Ext.ComponentQuery.query('#txtHusbandIdentityNo')[0].getValue(),
                        HusIdentityIssueDistrict : Ext.ComponentQuery.query('#txtHusbandIdIssuedDistrict')[0].getValue(),
                        HusIdentityIssueDate : Ext.ComponentQuery.query('#txtHusbandIdIssuedDateAD')[0].getValue(),
                        Address1Type : Ext.ComponentQuery.query('#ddlAddressType')[0].getValue(),
                        Address1Line2 : Ext.ComponentQuery.query('#txtWardNo')[0].getValue(),
                        Address1Line3 : Ext.ComponentQuery.query('#txtVdcMuni')[0].getValue(),
                        Address1District : Ext.ComponentQuery.query('#txtDistrict')[0].getValue(),
                        Address2Type : Ext.ComponentQuery.query('#ddlAddressType1')[0].getValue(),
                        Address2Line1 : Ext.ComponentQuery.query('#txtStreetAddress1')[0].getValue(),
                        Address2Line2 : Ext.ComponentQuery.query('#txtWardNo1')[0].getValue(),
                        Address2Line3 : Ext.ComponentQuery.query('#txtVdcMuni1')[0].getValue(),
                        Address2District :  Ext.ComponentQuery.query('#txtDistrict1')[0].getValue(),
                        ReligionCode : Ext.ComponentQuery.query('#txtReligionCode')[0].getValue(),
        				Action : 'I'
        };
        var waitSave = watiMsg("Saving Member. Please wait ...");
        Ext.Ajax.request({
            url: '../Handlers/GeneralMasterParameters/Member/MemberHandler.ashx',
            params: {
                method:'Save',
                member:JSON.stringify(objMem)
            },
            success: function(response){
               waitSave.hide();

                var obj = Ext.decode(response.responseText);

                console.log(obj);



                msg('INFO','Member Saved Successfully');





            }
        });






    },

    onTxtGroupAfterRender: function(component, eOpts) {

        component.getEl().on('dblclick', function(){

            var winPopup = Ext.create('MyApp.view.PopupSelectGroup',{

                width:700,
                height:500,


            });

            winPopup.extraParam={param:null};
            winPopup.show();
        });




    },

    onTxtCasteCodeAfterRender: function(component, eOpts) {

        component.getEl().on('dblclick', function(){

            var winPopup = Ext.create('MyApp.view.PopupCasteCode',{

                width:700,
                height:500,


            });

            winPopup.extraParam={param:null};
            winPopup.show();
        });




    },

    onTxtInsuranceCodeAfterRender: function(component, eOpts) {
        component.getEl().on('dblclick', function(){

            var winPopup = Ext.create('MyApp.view.PopupSelectInsuranceCode',{

                width:700,
                height:500,


            });

            winPopup.extraParam={param:null};
            winPopup.show();
        });

    },

    onTxtReligionCodeAfterRender: function(component, eOpts) {
        component.getEl().on('dblclick', function(){

            var winPopup = Ext.create('MyApp.view.PopupSelectReligion',{

                width:700,
                height:500,


            });

            winPopup.extraParam={param:null};
            winPopup.show();
        });
    },

    onTxtCompanyCodeAfterRender: function(component, eOpts) {
        component.getEl().on('dblclick', function(){

            var winPopup = Ext.create('MyApp.view.PopupSelectInsuranceCompany',{

                width:700,
                height:500,


            });

            winPopup.extraParam={param:null};
            winPopup.show();
        });
    },

    onTxtCenterCodeAfterRender: function(component, eOpts) {
        component.getEl().on('dblclick', function(){

            var winPopup = Ext.create('MyApp.view.PopupSelectCenterCode',{

                width:700,
                height:500,


            });

            winPopup.extraParam={param:null};
            winPopup.show();
        });
    },

    onBtnSearchClick: function(button, e, eOpts) {
        var obj={
            MembershipDateFrom : Ext.ComponentQuery.query('#txtMembershipDateFromBS')[0].getValue(),
            MembershipDateTo : Ext.ComponentQuery.query('#txtMembershipDateToBS')[0].getValue(),
            TelephoneNo: Ext.ComponentQuery.query('#txtPhoneNo')[0].getValue(),
            IdDocumentNo : Ext.ComponentQuery.query('#txtCitizenshipNo')[0].getValue(),
            TranOfficeCode : Ext.ComponentQuery.query('#txtOfficeCode')[0].getValue(),
            CenterCode :Ext.ComponentQuery.query('#txtCenterCode')[0].getValue(),
            MemberCode: Ext.ComponentQuery.query('#txtClientCode')[0].getValue(),
            IdDocumentType :Ext.ComponentQuery.query('#ddlMemberIdentityType')[0].getValue()


        };

        Ext.Ajax.request({
            url:'../Handlers/GeneralMasterParameters/Member/MemberHandler.ashx',
            params:{method:'Search',member:JSON.stringify(obj)},
            success: function ( result, request ) {

                var obj = Ext.decode(result.responseText);
                if(obj.success === 'true'){
                    console.log("Resu",obj.root);
                    var store =Ext.getStore('SearchMemberStore');
                    store.removeAll();
                    store.add(obj.root);


                }else{msg('FAILURE','Could Not Load Data');}
            },
            failure: function(form, action) {
                msg("FAILURE","Could Not Load Data");    }
        });
    },

    onBtnUpdateMemberClick: function(button, e, eOpts) {
        var objMem ={
                        //FiscalYear : Ext.ComponentQuery.query('#')[0].getValue(),
                        //ClientNo : Ext.ComponentQuery.query('#')[0].getValue(),
                        ClientCode : Ext.ComponentQuery.query('#txtMemberCode')[0].getValue(),
                        GroupCode : Ext.ComponentQuery.query('#txtGroup')[0].getValue(),
                        MembershipDate :Ext.ComponentQuery.query('#txtMemberDateAD')[0].getValue() ,
        				Address : Ext.ComponentQuery.query('#txtStreetAddress')[0].getValue(),
                        MaritalStatus : Ext.ComponentQuery.query('#ddlMaritalStatus')[0].getValue(),
                        FatherName : Ext.ComponentQuery.query('#txtFatherName')[0].getValue(),
                        SpouseName : Ext.ComponentQuery.query('#txtSpouseName')[0].getValue(),
                        BirthYear : 1,
                        NoBoyChild : Ext.ComponentQuery.query('#txtBoyNo')[0].getValue(),//1,
                        NoGirlChild : Ext.ComponentQuery.query('#txtGirlNo')[0].getValue(),//1,
                        NomineeName : Ext.ComponentQuery.query('#txtNomineeName')[0].getValue(),//'AA',
                        NomineeRelation : Ext.ComponentQuery.query('#ddlNomineeRelation')[0].getValue(),//'AA',
                        IdDocumentType : Ext.ComponentQuery.query('#ddlMemberIdentityType')[0].getValue(),//'AA',
                        IdDocumentNo : Ext.ComponentQuery.query('#txtCitizenshipNo')[0].getValue(),//'AA',
                        LoanYear : 1,
                        MemberType : Ext.ComponentQuery.query('#ddlMemberType')[0].getValue(),//'AA',
                        EmployeeId : 'AA',
                        CasteCode : Ext.ComponentQuery.query('#txtCasteCode')[0].getValue(),//'17',
                        Fname : Ext.ComponentQuery.query('#txtFirstName')[0].getValue(),//'AA',
                        Lname : Ext.ComponentQuery.query('#txtLastName')[0].getValue(),//'AA',
                        MembershipCloseDate : Ext.ComponentQuery.query('#txtClosedDateAD')[0].getValue(),//'20-mar-2017',
                        PostalAddress : Ext.ComponentQuery.query('#txtPostalAddress')[0].getValue(),//'AA',
                        Gender : Ext.ComponentQuery.query('#ddlGender')[0].getValue(),//'F',
                        OccupationCode : Ext.ComponentQuery.query('#ddlOccupation')[0].getValue(),//'1',
                        EducationCode : Ext.ComponentQuery.query('#ddlEducation')[0].getValue(),//'4',
                        Active : 'Y',
                        ChildrenNo : Ext.ComponentQuery.query('#txtChildrenNo')[0].getValue(),//1,
                        FieldAssistantId : Ext.ComponentQuery.query('#txtFieldAssistant')[0].getValue(),// 'AA',
                        ReasonForInactive : 'AA',
                        Signature3 : 'AA',
                        Signature2 : 'AA',
                        Signature1 : 'AA',
                        ImagePath : Ext.ComponentQuery.query('#imgMember')[0].getValue(),//'AA',
                        TranOfficeCode : '01020',
                        CreatedOn : 'AA',
                        CreatedBy : 'AA',
                        ModifiedOn : 'AA',
                        ModifiedBy : 'AA',
                        LastChangeDate : 'AA',
                        TransferDate : 'AA',
                        FixedCollectionAmount : Ext.ComponentQuery.query('#txtPensionFixedAmt')[0].getValue(),//1,
        				//InsuranceNumber: Ext.ComponentQuery.query('#txtInsuranceNo')[0];,
        				//InsuranceDate: Ext.ComponentQuery.query('#txtInsuranceDate')[0];,
                        CenterCode : 'AA',
                        ThirdPartyData : 'AA',
                        Dob : Ext.ComponentQuery.query('#txtDateOfBirthAD')[0].getValue(),//'20-mar-2017',
                        TelephoneNo : Ext.ComponentQuery.query('#txtTelephoneNo')[0].getValue(),//'9841256987',
                        MobileNo : Ext.ComponentQuery.query('#txtMobileNo')[0].getValue(),//'9841256987',
                        FaxNo : Ext.ComponentQuery.query('#txtFaxNo')[0].getValue(),//'AA',
                        JointImagePath : 'AA',
                        GrandFatherName : Ext.ComponentQuery.query('#txtGrandfatherName')[0].getValue(),//'AA',
                        MinorYN : 'AA',
                        MinorName : 'AA',
                        MinorRelation : 'AA',
                        EmailAddress : Ext.ComponentQuery.query('#txtEmail')[0].getValue(),//'AA',
                        FingerPrintLeft : 'AA',
                        FingerPrintRight : 'AA',
                        IdIssueDistrictCode : Ext.ComponentQuery.query('#txtCitizenshipIssuedDistrict')[0].getValue(),//'AA',
                        FatherInlawName : Ext.ComponentQuery.query('#txtFatherInLawName')[0].getValue(),//'AA',
                        HusbandName : Ext.ComponentQuery.query('#txtHusbandName')[0].getValue(),//'AA',
                        IdentityOwnBy : 'AA',
                        ReasonCode : 'AA',
                        RefClientNo : 'AA',
                        MemIdentityIssueDate : Ext.ComponentQuery.query('#txtCitizenshipIssuedDateAD')[0].getValue(),//'20-mar-2017',
                        HusIdentityType : Ext.ComponentQuery.query('#ddlHusbandIdentityType')[0].getValue(),//'AA',
                        HusIdentityNo : Ext.ComponentQuery.query('#txtHusbandIdentityNo')[0].getValue(),//'AA',
                        HusIdentityIssueDistrict : Ext.ComponentQuery.query('#txtHusbandIdIssuedDistrict')[0].getValue(),//'AA',
                        HusIdentityIssueDate : Ext.ComponentQuery.query('#txtHusbandIdIssuedDateAD')[0].getValue(),//'20-mar-2017',
                        Address1Type : Ext.ComponentQuery.query('#ddlAddressType')[0].getValue(),//'AA',
                        Address1Line2 : Ext.ComponentQuery.query('#txtWardNo')[0].getValue(),//'AA',
                        Address1Line3 : Ext.ComponentQuery.query('#txtVdcMuni')[0].getValue(),//'AA',
                        Address1District : Ext.ComponentQuery.query('#txtDistrict')[0].getValue(),//'AA',
                        Address2Type : Ext.ComponentQuery.query('#ddlAddressType1')[0].getValue(),//'AA',
                        Address2Line1 : Ext.ComponentQuery.query('#txtStreetAddress1')[0].getValue(),//'AA',
                        Address2Line2 : Ext.ComponentQuery.query('#txtWardNo1')[0].getValue(),//'AA',
                        Address2Line3 : Ext.ComponentQuery.query('#txtVdcMuni1')[0].getValue(),//'AA',
                        Address2District :  Ext.ComponentQuery.query('#txtDistrict1')[0].getValue(),//'AA',
                        ReligionCode : Ext.ComponentQuery.query('#txtReligionCode')[0].getValue(),//'AA',
        				Action : 'U'
        };
        var waitSave = watiMsg("Saving Member. Please wait ...");
        Ext.Ajax.request({
            url: '../Handlers/GeneralMasterParameters/Member/MemberHandler.ashx',
            params: {
                method:'Save',
                member:JSON.stringify(objMem)
            },
            success: function(response){
               waitSave.hide();

                var obj = Ext.decode(response.responseText);

                console.log(obj);



                msg('INFO','Member Updated Successfully');





            }
        });

    },

    onTxtClientCodeAfterRender: function(component, eOpts) {
        component.getEl().on('dblclick', function(){

            var winPopup = Ext.create('MyApp.view.PopupSelectMemberCode',{

                width:700,
                height:500,


            });

            winPopup.extraParam={param:null};
            winPopup.show();
        });
    },

    init: function(application) {
        this.control({
            "#btnCreateMember": {
                click: this.onBtnCreateMemberClick
            },
            "#txtGroup": {
                afterrender: this.onTxtGroupAfterRender
            },
            "#txtCasteCode": {
                afterrender: this.onTxtCasteCodeAfterRender
            },
            "#txtInsuranceCode": {
                afterrender: this.onTxtInsuranceCodeAfterRender
            },
            "#txtReligionCode": {
                afterrender: this.onTxtReligionCodeAfterRender
            },
            "#txtCompanyCode": {
                afterrender: this.onTxtCompanyCodeAfterRender
            },
            "#txtCenterCode": {
                afterrender: this.onTxtCenterCodeAfterRender
            },
            "#btnSearch": {
                click: this.onBtnSearchClick
            },
            "#btnUpdateMember": {
                click: this.onBtnUpdateMemberClick
            },
            "#txtClientCode": {
                afterrender: this.onTxtClientCodeAfterRender
            }
        });
    }

});
