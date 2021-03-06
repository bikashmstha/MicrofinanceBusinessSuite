/*
 * File: app/view/GetGeneralizedSubmissionNo.js
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

Ext.define('MyApp.view.GetGeneralizedSubmissionNo', {
    extend: 'Ext.panel.Panel',

    frame: true,
    height: 358,
    id: 'GetGeneralizedSubmissionNo',
    itemId: 'pnlGetGeneralizedSubmissionNo',
    title: 'सब्मिशन नम्बर लिने फाराम ',

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'form',
                    frame: true,
                    height: 323,
                    id: 'frmVatReturnsSubNo',
                    bodyPadding: 10,
                    title: '',
                    items: [
                        {
                            xtype: 'hiddenfield',
                            anchor: '100%',
                            itemId: 'hdnGenLoginModule',
                            fieldLabel: 'Label'
                        },
                        {
                            xtype: 'hiddenfield',
                            anchor: '100%',
                            itemId: 'hdnGenLoginLeaf',
                            fieldLabel: 'Label'
                        },
                        {
                            xtype: 'container',
                            layout: {
                                columns: 2,
                                type: 'table'
                            },
                            items: [
                                {
                                    xtype: 'container',
                                    padding: 5,
                                    width: 286,
                                    layout: {
                                        columns: 1,
                                        type: 'table'
                                    },
                                    items: [
                                        {
                                            xtype: 'textfield',
                                            id: 'txtVatUsername',
                                            itemId: 'txtVatUsername',
                                            name: 'txtVatUsername',
                                            fieldLabel: 'प्रयोगकर्ताको नाम  *',
                                            labelWidth: 120,
                                            allowBlank: false,
                                            blankText: 'Username Can\'t Be Left Blank',
                                            maxLength: 25,
                                            minLength: 5
                                        },
                                        {
                                            xtype: 'textfield',
                                            id: '',
                                            itemId: 'txtVatPassword',
                                            inputType: 'password',
                                            name: 'txtVatPassword',
                                            fieldLabel: 'पासवर्ड *',
                                            labelWidth: 120,
                                            allowBlank: false,
                                            minLength: 5
                                        },
                                        {
                                            xtype: 'textfield',
                                            id: '',
                                            itemId: 'txtVatReTypePassword',
                                            inputType: 'password',
                                            name: 'txtVatReTypePassword',
                                            fieldLabel: 'पुनः पासवर्ड *',
                                            labelWidth: 120,
                                            allowBlank: false
                                        },
                                        {
                                            xtype: 'textfield',
                                            id: 'txtVATPANNo',
                                            itemId: 'txtVATPANNo',
                                            name: 'txtVATPANNo',
                                            fieldLabel: 'स्थायी लेखा नम्बर *',
                                            labelWidth: 120,
                                            allowBlank: false,
                                            enforceMaxLength: true,
                                            maskRe: /[0-9]/,
                                            maxLength: 9,
                                            minLength: 9,
                                            size: 9
                                        },
                                        {
                                            xtype: 'combobox',
                                            hidden: false,
                                            itemId: 'ddlVatretFysicalyr',
                                            fieldLabel: 'आर्थिक बर्ष  *',
                                            labelWidth: 120,
                                            emptyText: '.. छान्नुहोस् ..',
                                            displayField: 'fiscalYear',
                                            forceSelection: true,
                                            store: 'FiscalYear',
                                            typeAhead: true,
                                            valueField: 'fiscalYear'
                                        },
                                        {
                                            xtype: 'textfield',
                                            id: 'txtVatEmailId',
                                            name: 'txtVatEmailId',
                                            fieldLabel: 'इमेल ठेगाना ',
                                            labelWidth: 120,
                                            vtype: 'email'
                                        },
                                        {
                                            xtype: 'textfield',
                                            itemId: 'txtVatPhoneNo',
                                            fieldLabel: 'सम्पर्क नम्बर *',
                                            labelWidth: 120,
                                            enforceMaxLength: true,
                                            maskRe: /[0-9-]/,
                                            maxLength: 20
                                        }
                                    ]
                                },
                                {
                                    xtype: 'container',
                                    items: [
                                        {
                                            xtype: 'container',
                                            id: 'cntSelfAssessmentInstruction',
                                            itemId: 'cntSelfAssessmentInstruction',
                                            margin: '0 20 0 20',
                                            layout: {
                                                columns: 1,
                                                type: 'table'
                                            },
                                            items: [
                                                {
                                                    xtype: 'label',
                                                    margin: '0 0 0 20',
                                                    text: 'ई-फाइलिङ्ग भर्ने प्रकृया:'
                                                },
                                                {
                                                    xtype: 'label',
                                                    margin: '5 0 5 0',
                                                    text: '१  सब्मिशन नं. लिनुहोस ।'
                                                },
                                                {
                                                    xtype: 'label',
                                                    margin: '5 0 5 0',
                                                    width: 310,
                                                    text: '२  Enter Self Assessment मा क्लिक गरी आफ्नो अभिलेख राख्नुहोस् । स्क्रिनमा डे-०१ फाराम देखिनेछ । कृपया सो फाराम भर्नुहोस् र \'सबमिट\'मा क्लिक गर्नुहोस् । '
                                                },
                                                {
                                                    xtype: 'label',
                                                    margin: '5 0 5 0',
                                                    text: '३  यदि तपाईले यस आर्थिक वर्षको निम्ति सब्मिशन नम्बर लिई सक्नु भएको छ भने \'मेनु\' मा भएको  '
                                                },
                                                {
                                                    xtype: 'button',
                                                    disabled: false,
                                                    height: 20,
                                                    itemId: 'btnGenLogin',
                                                    text: 'Income Tax Login '
                                                },
                                                {
                                                    xtype: 'label',
                                                    margin: '',
                                                    text: 'मा क्लिक गर्नुहोस् । त्यसपछि सब्मिशन नम्बर प्रयोगकर्ताको नाम र पासवर्ड राखेर लगइन भइ आय विवरण भर्न , प्रविष्टि र रुजु गर्न सक्नु हुन्छ । रुजु नगरेसम्म तपाईंको विवरण आन्तरिक राजस्व विभागमा दर्ता भएको मानिदैन । '
                                                },
                                                {
                                                    xtype: 'label',
                                                    margin: '5 0 5 0',
                                                    text: '४  एक पटक आय विवरण बुझाइसकेपछि कर दाखिला विवरणको फाराम देखिनेछ र तपाईले विवरण भर्न सक्नु हुनेछ । पृष्‍ठमा रहेको Print Preview मा क्लिक गरी हेर्न वा प्रिन्ट गर्न सक्नु हुनेछ । '
                                                },
                                                {
                                                    xtype: 'label',
                                                    margin: '5 0 5 0',
                                                    text: '५  रुजु गर्न भरेको फाराम प्रिन्ट गर्नुहोस् र सम्बन्धीत आ.रा.का. मा गई बुझाउनुहोस् ।'
                                                }
                                            ]
                                        },
                                        {
                                            xtype: 'container',
                                            id: 'cntVatEstRet',
                                            itemId: 'cntVatEstRet',
                                            margin: '-50 20 0 20',
                                            layout: {
                                                columns: 1,
                                                type: 'table'
                                            },
                                            items: [
                                                {
                                                    xtype: 'label',
                                                    margin: '5 0 5 10',
                                                    text: 'ई-फाइलिङ्ग भर्ने प्रकृया:'
                                                },
                                                {
                                                    xtype: 'label',
                                                    margin: '5 0 5 0',
                                                    text: '१.  प्रयोगकर्ताको नाम भर्नुहोस् '
                                                },
                                                {
                                                    xtype: 'label',
                                                    margin: '5 0 5 0',
                                                    width: 310,
                                                    text: '२ .  पासवर्ड भर्नुहोस्'
                                                },
                                                {
                                                    xtype: 'label',
                                                    margin: '5 0 5 0',
                                                    text: '३.  कृपया पुन: पासवर्ड भर्नुहोस्'
                                                },
                                                {
                                                    xtype: 'label',
                                                    margin: '5 0 5 0',
                                                    text: '४ . स्थायी लेखा नम्बर भर्नुहोस्'
                                                },
                                                {
                                                    xtype: 'label',
                                                    margin: '5 0 5 0',
                                                    text: '५ .  इमेल ठेगाना भर्नुहोस्'
                                                },
                                                {
                                                    xtype: 'label',
                                                    margin: '5 0 5 0',
                                                    text: '६.  सम्पर्क नम्बर भर्नुहोस्'
                                                },
                                                {
                                                    xtype: 'label',
                                                    margin: '5 0 5 0',
                                                    text: '७ .  Register  बटनमा क्लिक गर्नुहोस्'
                                                }
                                            ]
                                        }
                                    ]
                                }
                            ]
                        },
                        {
                            xtype: 'container',
                            padding: '0 0 0 150',
                            layout: {
                                type: 'column'
                            },
                            items: [
                                {
                                    xtype: 'button',
                                    id: '',
                                    itemId: 'btnRegister',
                                    icon: '',
                                    iconCls: 'icon-ok',
                                    text: 'Register '
                                },
                                {
                                    xtype: 'button',
                                    id: 'btnReset',
                                    icon: '',
                                    iconCls: 'icon-cancel',
                                    text: 'Reset'
                                },
                                {
                                    xtype: 'label',
                                    margin: '10  20 0 10',
                                    text: '* चिन्ह भएको सबै कोष्ठहरु भर्न जरुरी छ ।'
                                }
                            ]
                        }
                    ]
                }
            ]
        });

        me.callParent(arguments);
    }

});