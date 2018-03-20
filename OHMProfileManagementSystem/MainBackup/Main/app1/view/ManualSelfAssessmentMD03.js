/*
 * File: app/view/ManualSelfAssessmentMD03.js
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

Ext.define('MyApp.view.ManualSelfAssessmentMD03', {
    extend: 'Ext.panel.Panel',

    frame: true,
    height: 790,
    itemId: 'pnlSelfAssessmentMD03',
    width: 860,
    autoScroll: true,
    title: 'Manual Self Assessment D-03',

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'form',
                    frame: true,
                    itemId: 'frmSelfAssessmentMD03',
                    margin: 5,
                    bodyPadding: 10,
                    items: [
                        {
                            xtype: 'container',
                            itemId: 'cntHeaderDo3',
                            margin: '0 0 0 280',
                            items: [
                                {
                                    xtype: 'displayfield',
                                    itemId: 'lblSubmissionNoMD03',
                                    style: 'font-size:20px',
                                    fieldLabel: 'सब्मिशन नं.',
                                    labelStyle: 'font-weight:bold;color:red;font-size:16px',
                                    labelWidth: 90,
                                    fieldStyle: 'font-weight:bold;padding-top:8px;'
                                },
                                {
                                    xtype: 'label',
                                    style: 'font-weight:bold;\r\nfont-size:16;\r\ntext-align:center;',
                                    width: 148,
                                    text: 'फाराम-आयकर-डे-D-03-02-0364'
                                }
                            ]
                        },
                        {
                            xtype: 'label',
                            hidden: true,
                            itemId: 'lblActionMD03',
                            margin: '15 0 -5 0',
                            style: '{color:red;}',
                            text: 'Updating ...'
                        },
                        {
                            xtype: 'fieldset',
                            height: 92,
                            margin: '30 0 5 0 ',
                            title: '',
                            items: [
                                {
                                    xtype: 'container',
                                    itemId: 'cntSubmissionNoMD03',
                                    items: [
                                        {
                                            xtype: 'textfield',
                                            disabled: true,
                                            itemId: 'txtSubmissionNoMD03',
                                            margin: '5 0 0 0 ',
                                            fieldLabel: 'सब्मिशन नं.',
                                            labelWidth: 105,
                                            enableKeyEvents: true,
                                            enforceMaxLength: true,
                                            maskRe: /[0-9]/,
                                            maxLength: 12,
                                            minLength: 12
                                        }
                                    ]
                                },
                                {
                                    xtype: 'container',
                                    itemId: 'cntFiscalYearMD03',
                                    margin: '5 0 0 0 ',
                                    layout: {
                                        type: 'table'
                                    },
                                    items: [
                                        {
                                            xtype: 'combobox',
                                            itemId: 'cboFiscalYearMD03',
                                            fieldLabel: 'आर्थिक बर्ष *',
                                            labelWidth: 105,
                                            emptyText: 'Select ...',
                                            displayField: 'fiscalYear',
                                            store: 'FiscalYear',
                                            valueField: 'fiscalYear'
                                        },
                                        {
                                            xtype: 'label',
                                            colspan: 4,
                                            margin: '-15 0 0 5',
                                            width: 400,
                                            text: '( भर्ने उदाहरण २०६८.०६९ )'
                                        },
                                        {
                                            xtype: 'textfield',
                                            colspan: 2,
                                            itemId: 'txtPlaceMD03',
                                            margin: '0 0 5 50',
                                            width: 300,
                                            fieldLabel: 'आ रा का',
                                            labelWidth: 92,
                                            readOnly: true
                                        }
                                    ]
                                },
                                {
                                    xtype: 'container',
                                    layout: {
                                        type: 'table'
                                    },
                                    items: [
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtPanNoMD03',
                                            margin: '2 2 5 2',
                                            fieldLabel: 'स्थायी  लेखा  नम्बर *',
                                            labelWidth: 105,
                                            emptyText: '  |   |   |   |   |   |   |   |',
                                            enableKeyEvents: true,
                                            enforceMaxLength: true,
                                            maskRe: /[0-9]/,
                                            maxLength: 9,
                                            minLength: 9
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtFromDateMD03',
                                            margin: '0 0 0 15',
                                            width: 150,
                                            fieldLabel: 'शुरू मिति *',
                                            labelWidth: 70,
                                            enforceMaxLength: true,
                                            maxLength: 10,
                                            minLength: 10,
                                            listeners: {
                                                blur: {
                                                    fn: me.onTxtFromDateMD03Blur,
                                                    scope: me
                                                }
                                            }
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtToDateMD03',
                                            margin: '0 0 0 25',
                                            width: 170,
                                            fieldLabel: 'अन्तिम मिति *',
                                            labelWidth: 83,
                                            enforceMaxLength: true,
                                            maxLength: 10,
                                            minLength: 10,
                                            listeners: {
                                                blur: {
                                                    fn: me.onTxtToDateMD03Blur,
                                                    scope: me
                                                }
                                            }
                                        }
                                    ]
                                }
                            ]
                        },
                        {
                            xtype: 'panel',
                            frame: true,
                            height: 320,
                            margin: '0 0 5 0',
                            layout: {
                                columns: 6,
                                type: 'table'
                            },
                            bodyPadding: 10,
                            collapseFirst: false,
                            title: '२. फर्म सम्बन्धी विवरण',
                            items: [
                                {
                                    xtype: 'container',
                                    cls: 'extTbl',
                                    height: 300,
                                    width: 795,
                                    layout: {
                                        columns: 6,
                                        type: 'table'
                                    },
                                    items: [
                                        {
                                            xtype: 'textfield',
                                            colspan: 6,
                                            itemId: 'txtNameMD03',
                                            margin: '5px 0 0 0',
                                            width: 780,
                                            fieldLabel: 'नाम ',
                                            labelWidth: 73,
                                            readOnly: true
                                        },
                                        {
                                            xtype: 'label',
                                            colspan: 1,
                                            margin: '5px 0 0 0',
                                            text: 'ठेगाना '
                                        },
                                        {
                                            xtype: 'label',
                                            margin: '5px 0 0 0',
                                            style: 'margin-right:30px;',
                                            text: 'घर नं .'
                                        },
                                        {
                                            xtype: 'label',
                                            margin: '5px 0 0 0',
                                            style: 'margin-right:30px;',
                                            text: 'वार्ड नं .'
                                        },
                                        {
                                            xtype: 'label',
                                            margin: '5px 0 0 0',
                                            style: 'margin-right:30px;',
                                            text: 'गाउँ / टोल र बाटोको नाम'
                                        },
                                        {
                                            xtype: 'radiogroup',
                                            itemId: 'rbtnsLocationMD03',
                                            margin: '5px 0 0 0',
                                            width: 200,
                                            fieldLabel: '',
                                            columns: 2,
                                            items: [
                                                {
                                                    xtype: 'radiofield',
                                                    name: 'loc',
                                                    value: 'MM',
                                                    readOnly: true,
                                                    boxLabel: 'म. न. पा.',
                                                    inputValue: 'MM'
                                                },
                                                {
                                                    xtype: 'radiofield',
                                                    name: 'loc',
                                                    value: 'SM',
                                                    readOnly: true,
                                                    boxLabel: 'उ. म. न. पा.',
                                                    inputValue: 'SM'
                                                },
                                                {
                                                    xtype: 'radiofield',
                                                    name: 'loc',
                                                    value: 'MN',
                                                    readOnly: true,
                                                    boxLabel: 'न. पा.',
                                                    inputValue: 'MN'
                                                },
                                                {
                                                    xtype: 'radiofield',
                                                    name: 'loc',
                                                    value: 'VD',
                                                    readOnly: true,
                                                    boxLabel: 'गा. वि. स.',
                                                    inputValue: 'VD'
                                                }
                                            ]
                                        },
                                        {
                                            xtype: 'label',
                                            margin: '5px 0 0 0',
                                            style: 'margin-right:50px;',
                                            text: 'जिल्ला'
                                        },
                                        {
                                            xtype: 'textfield',
                                            colspan: 2,
                                            itemId: 'txtHouseNoMD03',
                                            margin: '5 0 0 80',
                                            width: 50,
                                            readOnly: true
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtWardNoMD03',
                                            margin: '',
                                            width: 50,
                                            readOnly: true
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtToleNameMD03',
                                            margin: '',
                                            width: 140,
                                            readOnly: true
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtVDCNameMD03',
                                            margin: '',
                                            width: 200,
                                            readOnly: true
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtDistrictNameMD03',
                                            margin: '',
                                            width: 125,
                                            readOnly: true
                                        },
                                        {
                                            xtype: 'textfield',
                                            colspan: 2,
                                            itemId: 'txtPhoneMD03',
                                            margin: '5px 0 0 0',
                                            width: 150,
                                            fieldLabel: 'फोन ',
                                            labelWidth: 75,
                                            readOnly: true,
                                            enforceMaxLength: false
                                        },
                                        {
                                            xtype: 'textfield',
                                            colspan: 2,
                                            itemId: 'txtMobileMD03',
                                            margin: '5px 0 0 0',
                                            width: 207,
                                            fieldLabel: 'मोबाइल ',
                                            labelWidth: 62,
                                            readOnly: true
                                        },
                                        {
                                            xtype: 'textfield',
                                            colspan: 2,
                                            itemId: 'txtEmailMD03',
                                            margin: '5px 0 0 0',
                                            width: 360,
                                            fieldLabel: 'इमेल ',
                                            labelWidth: 60,
                                            readOnly: true
                                        },
                                        {
                                            xtype: 'combobox',
                                            colspan: 4,
                                            itemId: 'cboTaxPayerTypeMD03',
                                            margin: '5 5 5 0',
                                            width: 380,
                                            fieldLabel: 'करदाताको किसिम',
                                            msgTarget: 'side',
                                            allowBlank: false,
                                            emptyText: 'Select ...',
                                            displayField: 'TaxDescNep',
                                            forceSelection: true,
                                            queryMode: 'local',
                                            store: 'TaxPayerTypeD03',
                                            valueField: 'TaxCatID'
                                        }
                                    ]
                                }
                            ]
                        },
                        {
                            xtype: 'panel',
                            frame: true,
                            itemId: 'pnlTaxPayerSelectionDetailMD03',
                            margin: '0 0 5 0',
                            title: '३. करदाताको छनौट सम्बन्धी विवरण',
                            items: [
                                {
                                    xtype: 'label',
                                    margin: '0 0 0 500',
                                    style: 'text-align:center;\r\nfont-weight:bold;',
                                    text: '(प्राकृतिक व्यक्तिको लागि मात्र)'
                                },
                                {
                                    xtype: 'container',
                                    frame: true,
                                    layout: {
                                        type: 'table'
                                    },
                                    items: [
                                        {
                                            xtype: 'container',
                                            itemId: 'cntClubbedMD03',
                                            margin: '-15 0 0 0',
                                            width: 500,
                                            items: [
                                                {
                                                    xtype: 'radiogroup',
                                                    itemId: 'rgbtnClubbedMD03',
                                                    width: 280,
                                                    fieldLabel: '',
                                                    items: [
                                                        {
                                                            xtype: 'radiofield',
                                                            name: 'status',
                                                            readOnly: true,
                                                            boxLabel: 'एक्लो प्राकृतिक व्यक्ति',
                                                            checked: true,
                                                            inputValue: 'N'
                                                        },
                                                        {
                                                            xtype: 'radiofield',
                                                            name: 'status',
                                                            readOnly: true,
                                                            boxLabel: 'दम्पत्ति',
                                                            inputValue: 'Y'
                                                        }
                                                    ]
                                                }
                                            ]
                                        },
                                        {
                                            xtype: 'container',
                                            hidden: true,
                                            itemId: 'cntClubbedPanMD03',
                                            layout: {
                                                columns: 1,
                                                type: 'table'
                                            },
                                            items: [
                                                {
                                                    xtype: 'radiogroup',
                                                    itemId: 'rgbtnClubbedPanMD03',
                                                    width: 350,
                                                    fieldLabel: 'दम्पत्ति भए पति / पत्निको स्था.ले.नं.',
                                                    labelWidth: 209,
                                                    items: [
                                                        {
                                                            xtype: 'radiofield',
                                                            name: 'pan',
                                                            boxLabel: 'भएको',
                                                            inputValue: 'Y'
                                                        },
                                                        {
                                                            xtype: 'radiofield',
                                                            name: 'pan',
                                                            boxLabel: 'नभएको',
                                                            checked: true,
                                                            inputValue: 'N'
                                                        }
                                                    ]
                                                },
                                                {
                                                    xtype: 'textfield',
                                                    itemId: 'txtClubbedPanNoMD03',
                                                    margin: '2 2 5 2',
                                                    fieldLabel: 'स्था.ले.नं. भए, सो स्था.ले.नं. उल्लेख गर्ने ',
                                                    labelWidth: 205,
                                                    readOnly: true,
                                                    emptyText: '  |   |   |   |   |   |   |   |',
                                                    enableKeyEvents: true,
                                                    enforceMaxLength: true,
                                                    maxLength: 9,
                                                    minLength: 9,
                                                    listeners: {
                                                        blur: {
                                                            fn: me.onTxtClubbedPanNoMD03Blur,
                                                            scope: me
                                                        }
                                                    }
                                                }
                                            ]
                                        }
                                    ]
                                },
                                {
                                    xtype: 'label',
                                    text: 'मेरो पति / पत्नीले दाखिला गरेको यो आयविवरणमा कायम हुने कर दायित्व सम्बन्धमा म पनि पुर्ण रूपले जिम्मेवार हुन मन्जुर गर्दछु ।'
                                },
                                {
                                    xtype: 'container',
                                    margin: '20 0 0 0 ',
                                    layout: {
                                        type: 'table'
                                    },
                                    items: [
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtClubbedNameMD03',
                                            margin: '0 10 0 5',
                                            width: 480,
                                            fieldLabel: 'पति / पत्नीको नाम',
                                            readOnly: true
                                        },
                                        {
                                            xtype: 'label',
                                            margin: '0 0 0 10',
                                            text: 'दस्तखत ______________________________________________'
                                        }
                                    ]
                                }
                            ]
                        },
                        {
                            xtype: 'panel',
                            frame: true,
                            height: 320,
                            itemId: 'pnlAuditorVerificationMD03',
                            layout: {
                                type: 'vbox'
                            },
                            title: '४. लेखाप्ररिक्षण प्रमाणीकरण',
                            items: [
                                {
                                    xtype: 'label',
                                    height: 30,
                                    margin: '20 0 0 5',
                                    width: 950,
                                    text: '.............................ले आयकर ऐन २०५८ को दफा ८१ बमोजिम राखेका कागजहरू जाँच गरेको छु । प्राप्त विवरण तथा जानकारीले कारोवारको  स्थितिको यथार्थ छु / छौ । प्राप्त विवरण तथा जानकारीले कारोवारको स्थितिको यथार्थ चित्रण गरेको व्यहोरा प्रमाणित गर्दछु । यो आय विवरण प्रमाणित गर्ने सम्बन्धमा मेरा र हाम्रा टिप्पणीहरू यसै साथ संग्लन छन् ।'
                                },
                                {
                                    xtype: 'label',
                                    margins: '55 0 50 5',
                                    text: 'लेखापरिक्षको दस्तखत'
                                },
                                {
                                    xtype: 'textfield',
                                    flex: 1,
                                    margins: '0 0 0 5',
                                    height: 27,
                                    itemId: 'txtAuditorPanNoMD03',
                                    maxHeight: 27,
                                    fieldLabel: 'स्था.ले.नं. *',
                                    labelWidth: 110,
                                    msgTarget: 'side',
                                    allowBlank: false,
                                    enableKeyEvents: true,
                                    enforceMaxLength: true,
                                    maxLength: 9,
                                    minLength: 9
                                },
                                {
                                    xtype: 'textfield',
                                    height: 26,
                                    itemId: 'txtAuditorNameMD03',
                                    margin: '0 0 3 3',
                                    width: 400,
                                    fieldLabel: 'लेखापरिक्षकको नाम *',
                                    labelWidth: 110,
                                    msgTarget: 'side',
                                    readOnly: true
                                },
                                {
                                    xtype: 'textfield',
                                    flex: 1,
                                    margins: '0 0 0 5',
                                    height: 27,
                                    itemId: 'txtAuditorLicenseNoMD03',
                                    maxHeight: 27,
                                    fieldLabel: 'व्य.ले. प्र.प.नं.',
                                    labelWidth: 110,
                                    msgTarget: 'side',
                                    maxLength: 20
                                }
                            ]
                        },
                        {
                            xtype: 'container',
                            itemId: 'cntButtonsMD03',
                            margin: '5 0 0 5',
                            padding: '0 0 0 320',
                            layout: {
                                type: 'table'
                            },
                            items: [
                                {
                                    xtype: 'button',
                                    itemId: 'btnRegisterMD03',
                                    margin: '0 5 0 0',
                                    padding: 5,
                                    iconCls: 'icon-save',
                                    text: 'Register'
                                },
                                {
                                    xtype: 'button',
                                    itemId: 'btnEditMD03',
                                    margin: '0 5 0 5',
                                    padding: 5,
                                    iconCls: 'icon-edit',
                                    text: 'Edit'
                                },
                                {
                                    xtype: 'button',
                                    hidden: true,
                                    itemId: 'btnUpdateMD03',
                                    margin: '0 5 0 0',
                                    padding: 5,
                                    iconCls: 'icon-save',
                                    text: 'Update'
                                },
                                {
                                    xtype: 'button',
                                    hidden: true,
                                    itemId: 'btnEnterAnnexMD03',
                                    padding: 5,
                                    iconCls: 'icon-annex',
                                    text: 'Enter Annex',
                                    listeners: {
                                        click: {
                                            fn: me.onBtnEnterAnnexMD03Click,
                                            scope: me
                                        }
                                    }
                                }
                            ]
                        },
                        {
                            xtype: 'hiddenfield',
                            anchor: '100%',
                            itemId: 'hdnTaxPayrCatIDMD03',
                            fieldLabel: 'Label'
                        },
                        {
                            xtype: 'hiddenfield',
                            anchor: '100%',
                            itemId: 'hdnAssmtTypeMD03',
                            fieldLabel: 'Label'
                        },
                        {
                            xtype: 'hiddenfield',
                            anchor: '100%',
                            itemId: 'hdnRecordStatusMD03',
                            fieldLabel: 'Label'
                        }
                    ]
                }
            ]
        });

        me.callParent(arguments);
    },

    onTxtFromDateMD03Blur: function(component, e, eOpts) {
        return validateFutureDate(field.getValue(),"Y",function(){ field.focus();});
    },

    onTxtToDateMD03Blur: function(component, e, eOpts) {
        return validateFutureDate(field.getValue(),"N",function(){ field.focus();});
    },

    onTxtClubbedPanNoMD03Blur: function(component, e, eOpts) {
        var me = this;

        if(field.getValue !== "")
        {
            return ValidatePan(field.getValue(),"10",function(){field.focus();});
        }

        return true;
    },

    onBtnEnterAnnexMD03Click: function(button, e, eOpts) {
        var from = "";
        var requestNo = "";
        var offCodeAU = "";

        var view = Ext.ComponentQuery.query('#pnlSelfAssessmentMD03')[0];

        if(view === undefined)
        {
            return;
        }

        //-------------------------------------------------------------------------
        // NB: For Verification Preview
        //-------------------------------------------------------------------------
        if(view.extraParam)
        {    
            var arg = view.extraParam.params;

            if(arg.from)
            {        
                from = arg.from;  

                if(from === "AU")
                {
                    requestNo = arg.requestNo;
                    offCodeAU = arg.offCode;
                }
            }
        } 

        if(from === "OV")
        {
            from = "MV";
        }


        var uiConfig = {menuLink:'SetAnnexD03',pageTitle:'Set Annex'};

        var submissionNo = Ext.ComponentQuery.query('#txtSubmissionNoMD03')[0].getValue();
        var pan = Ext.ComponentQuery.query('#txtPanNoMD03')[0].getValue();
        var fiscalYear =  Ext.ComponentQuery.query('#cboFiscalYearMD03')[0].getValue();
        var name = Ext.ComponentQuery.query('#txtNameMD03')[0].getValue();
        var cat  = Ext.ComponentQuery.query('#cboTaxPayerTypeMD03')[0].getValue();
        var taxPayerCatID =  Ext.ComponentQuery.query('#hdnTaxPayrCatIDMD03')[0].getValue();
        var recStatus =  Ext.ComponentQuery.query('#hdnRecordStatusMD03')[0].getValue();
        var offCode = Ext.get('offCode').dom.innerHTML;

        var hdnAssmtType = Ext.ComponentQuery.query('#hdnAssmtTypeMD03')[0];
        var moduleID = "M-SA-D03";

        switch(hdnAssmtType.getValue())
        {
            case "SA":       
            moduleID = "M-SA-D03";
            break;
            case "JA":
            moduleID = "M-JA";
            break;
            case "BH":
            moduleID = "M-BH";
            break;
            case "CB":
            moduleID = "M-CB";
            break;
        }


        var params = {  submissionNo:submissionNo,
                pan:pan,
                taxPayerCatID:taxPayerCatID,
                name:name,
                offCode:offCode,
                fiscalYear:fiscalYear,
                taxpayerCat:cat,
                action:"",
                recStatus:recStatus,
                moduleID:moduleID,
                from :from,
                requestNo:requestNo,
                offCodeAU:offCodeAU

            };

        if(from === "MV")
        {
            Ext.getCmp("PopupWindow").close();
            //dynamicPopUp("SetAnnexD03",{params:params});
            dynamicPopUp("SetAnnexD03",params);    
            Ext.getCmp("PopupWindow").setWidth(1140);
        }
        else
        {
            DynamicUI(uiConfig,null,params);
        }




    }

});