[
{ text: "Central Function", id: 'R0001', expanded: false,  iconCls: 'ico-test',link:'NULL',
                                                                                children: [
																				{ text: "Search",iconCls: 'ico-test', id: 'CS000001', expanded: true,link:'NULL',
                                                                                                 children: [
																								  {text: "PAN Search Criteria", id: 'CS0000011', leaf: true, link:'PANSearchCriteria',qtip: "Central Function >>Search>> PAN Search Criteria"}
																								 ]
																								 },
                                                                                       { text: "Look Up Maintenance",iconCls: 'ico-test', id: 'C000001', expanded: true,link:'NULL',
                                                                                                 children: [
																											{ text: "Districts", id: 'C000003', leaf: true,link:'DistrictType', qtip: "Central Function >> Look Up Maintenance >> Districts"},
                                                                                                            { text: "Offices", id: 'C000004', leaf: true,link:'Office', qtip: "Central Function >> Look Up Maintenance >> Offices"},
                                                                                                            { text: "Banks", id: 'C000006', leaf: true,link:'Bank', qtip: "Central Function >> Look Up Maintenance >> Banks"},
                                                                                                            { text: "Business Category", id: 'C000008',leaf: true,link:'BusinessCategories', qtip: "Central Function >> Look Up Maintenance >> Business Category"},
                                                                                                            
													{ text: "Designation", id: 'C0000013', leaf: true, link: 'Designation', qtip: "Central Function >> Look Up Maintenance >> Designation"},
													{ text: "Fiscal Year", id: 'C0000014', leaf: true, link: 'FiscalYear', qtip: "Central Function >> Look Up Maintenance >> Fiscal Year"},
													{ text: "Holiday", id: 'C0000015', leaf: true, link: 'Holiday', qtip: "Central Function >> Look Up Maintenance >> Holiday"},
													{ text: "Address Type", id: 'C0000016', leaf: true, link: 'AddressType', qtip: "Central Function >> Look Up Maintenance >> Address Type"},
													{ text: "Document Type", id: 'C0000017', leaf: true, link: 'DocumentType', qtip: "Central Function >> Look Up Maintenance >> Document Type"},
													{ text: "Taxpayer Type", id: 'C0000018', leaf: true, link: 'TaxPayerType', qtip: "Central Function >> Look Up Maintenance >> Taxpayer Type"},
													{ text: "Business Personnel Type", id: 'C0000019', leaf: true, link: 'BusinessPersonnelTypes', qtip: "Central Function >> Look Up Maintenance >> Business Personnel Type"},
													{ text: "TaxPayer Categories", id: 'C0000020', leaf: true, link: 'TaxPayerCategories', qtip: "Central Function >> Look Up Maintenance >> TaxPayer Categories"},
													{ text: "Revenue Account", id: 'C0000021', leaf: true, link: 'RevenueAccount', qtip: "Central Function >> Look Up Maintenance >> Revenue Account"},
													{ text: "Business SubCategories", id: 'C00000101', leaf: true, link: 'BusSubCategories', qtip: "Central Function >> Look Up Maintenance >> Business SubCategories"},
													{text:"Vat Reason",id:'C00000104',leaf: true,link: 'VatReason', qtip: "Central Function >> Look Up Maintenance >> Vat Reason"},
													{text:"Sticker Type",id:'C00000105',leaf: true,link:'StickerType', qtip: "Central Function >> Look Up Maintenance >> Sticker Type"},
													
													
													
                                                                                                           ]
																										   
                                                                                            },
																							{ text: "Bank Office Assignment (bank codes needs to be harmonized)", id: 'C0000011', leaf: true, qtip: "Central Function >> Bank Office Assignment",link:'BankOffice'},
																							{ text: "Holiday Entry", id: 'C0000022', leaf: true, link: 'Holiday',qtip: "Central Function >> Holiday Entry"},
                                                                                            { text: "Nepali calendar", id: 'C0000033', leaf: true, qtip: "Central Function >> Nepali calendar"},
                                                                                            { text: "Change Office", id: 'C0000056', leaf: true,link: 'ChangeOffice', qtip: "Central Function >> Change Office"},
																							{ text: "Change Taxpayer LoginUser Password", id: 'C0000057', leaf: true,link: 'ChangeTaxpayerLoginUserPassword', qtip: "Central Function >> Change Taxpayer Login User Password"},
																							{ text: "Create Taxpayer LoginUser", id: 'C0000058', leaf: true,link: 'CreateTaxpayerLoginUser', qtip: "Central Function >> Create Taxpayer Login User"},
																							{ text: "TaxPayerLoginWithPan", id: 'C0000059', leaf: true,link: 'TaxPayerLoginWithPan', qtip: "Central Function >> TaxPayerLoginWithPan"},
																							{ text: "Authorized Update", id: 'C0000060', leaf: true,link: 'AuthorizedUpdate', qtip: "Central Function >> Authorized Update"}
                                                                                           ]
                                                     },

                                                                      { text: "Joint TaxPayer registration system", id: 'R000200',expanded: false,  iconCls: 'ico-test',link:'NULL',
                                                                                 children:[
                                                                                            {text:"Registration",id:'R000201',expanded: true,  iconCls: 'ico-test',link:'NULL',
                                                                                                children:[
                                                                                            { text: "Application Entry", id: 'C0000020000', leaf: true,iconCls:'tree-file-image', qtip: "Joint TaxPayer registration system >> Registration >> Application Entry"},
                                                                                            { text: "Submit Application", id: 'C0000020001', leaf: true,iconCls:'tree-file-image', qtip: "Joint TaxPayer registration system >> Registration >> Submit Application"},
                                                                                            { text: "Application Vetting", id: 'C0000020002', leaf: true,iconCls:'tree-file-image', qtip: "Joint TaxPayer registration system >> Registration >> Application Vetting"},
                                                                                            { text: "Application Approval", id: 'C0000020004', leaf: true,iconCls:'tree-file-image', qtip: "Joint TaxPayer registration system >> Registration >> Application Approval"},
                                                                                            { text: "Certificate Print", id: 'C0000020005', leaf: true,iconCls:'tree-file-image', qtip: "Joint TaxPayer registration system >> Registration >> Certificate Print"},
                                                                                            { text: "PAN Card Print", id: 'C0000020006', leaf: true,iconCls:'tree-file-image', qtip: "Joint TaxPayer registration system >> Registration >> PAN Card Print"},
												{ text: "Show Submission No", id: 'C00000200078', leaf: true,iconCls:'tree-file-image',link:'ShowSubmissionNo', qtip: "Joint TaxPayer registration system >> Registration >> Show Submission No"},
											{ text: "Personal EPAN", id: 'C00000200079', leaf: true, iconCls: 'tree-file-image', link: 'PersonRegistration', qtip: "Joint TaxPayer registration system >> Registration >> Personal EPAN"},
                                                                                            { text: "Login EPAN", id: 'C00000200080', leaf: true,iconCls:'tree-file-image',link:'EpanLoginBox', qtip: "Joint TaxPayer registration system >> Registration >> Login EPAN"}
                                                                                                         ]
                                                                                             },
											      {text:"Get Submition No",id:'R0002011',leaf: true,iconCls:'x-tree-icon-leaf',link:'GetSubmitionNo', qtip: "Joint TaxPayer registration system >> Get Submition No"},
                                                                                              {text:"Change of Office",id:'R000202',leaf: true,iconCls:'x-tree-icon-leaf', qtip: "Joint TaxPayer registration system >> Change of Office"},
                                                                                              {text:"Search facility",id:'R000203',leaf: true,iconCls:'x-tree-icon-leaf', qtip: "Joint TaxPayer registration system >> Search facility"},
                                                                                              {text:"Deregistration",id:'R000204',leaf: true,link:'DeRegistration',iconCls:'tree-file-image', qtip: "Joint TaxPayer registration system >> Deregistration"},
                                                                                              {text:"Re-registration",id:'R000205',leaf: true,iconCls:'tree-file-image', qtip: "Joint TaxPayer registration system >> Re-registration"},
                                                                                              {text:"Marking",id:'R000206',leaf: true,link:'Marking',iconCls:'tree-file-image', qtip: "Joint TaxPayer registration system >> Marking"},
                                                                                              {text:"Authorized Update ",id:'R000207',leaf: true,iconCls:'tree-file-image', qtip: "Joint TaxPayer registration system >> Authorized Update"},
                                                                                              {text:"Supervisory Functions",id:'R000208',leaf: true,iconCls:'tree-file-image', qtip: "Joint TaxPayer registration system >> Supervisory Functions"},
                                                                                              {text:"Reports",id:'R0002096',leaf: true,iconCls:'tree-file-image', qtip: "Joint TaxPayer registration system >> Reports"}
                                                                                          ]
                                                                           },
                                                                         { text: "Value Added Tax System", id: 'R000300',expanded: false,  iconCls: 'ico-test',link:'NULL',
                                                                                 children:[
                                                                                              
                                                                                              {text:"Vat Returns Login",id:'R000301',leaf: true, link: 'GeneralizedLogin', qtip: "Value Added Tax System >> Close Of Business Login"},
																							  {text:"Close Of Business Login",id:'R000328',leaf: true, link: 'GeneralizedLogin', qtip: "Value Added Tax System >> Vat Returns Login"},
																							  {text: "E-Vat Return Entry", id: 'R000302', leaf: true, link: 'GetGeneralizedSubmissionNo', qtip: "Value Added Tax System >> E-Vat Return Entry"},
																							  {text: "E-Close Of Business Entry", id: 'R000327', leaf: true, link: 'GetGeneralizedSubmissionNo', qtip: "Value Added Tax System >> E-Close Of Business Entry"},
                                                                                              { text: "Manual Vat Return Entry", id: 'R000303', leaf: true, link: 'ManualVatReturns', qtip: "Value Added Tax System >> Manual Vat Return Entry" },
                                                                                              
                                                                                              {text:"Manual Close Of Business",id:'R000305',leaf: true,link:'ManualCloseOfBusiness', qtip: "Value Added Tax System >> Manual Close Of Business"},
                                                                                              {text:"Refund",id:'R000306',leaf: true, qtip: "Value Added Tax System >> Refund"},
                                                                                              {text:"Refund Payments",id:'R000307',leaf: true,link:'RefundPayments', qtip: "Value Added Tax System >> Refund Payments"},
                                                                                              {text:"Rebate",id:'R000308',leaf: true , link: 'Rebate', qtip: "Value Added Tax System >> Rebate"},
                                                                                              {text:"Special Penalty",id:'R000309',leaf: true,link:'SpecialPenalty', qtip: "Value Added Tax System >> Special Penalty"},
                                                                                              {text:"Computer Assessment",id:'R000310',leaf: true, qtip: "Value Added Tax System >> Computer Assessment"},
                                                                                              {text:"VAT Visit Modules",id:'R000311',leaf: true, qtip: "Value Added Tax System >> VAT Visit Modules"},
                                                                                              
                                                                                              {text:"Sundry Transaction",id:'R000313',leaf: true, link:'SundryTransaction',qtip: "Value Added Tax System >> Sundry Transaction"},
                                                                                              {text:"Authorized Updates",id:'R000314',leaf: true, qtip: "Value Added Tax System >> Authorized Updates"},
                                                                                              {text:"Diplomatic Refund",id:'R000315',leaf: true, qtip: "Value Added Tax System >> Diplomatic Refund"},
                                                                                              {text:"Supervisor Functions",id:'R000317',leaf: true, qtip: "Value Added Tax System >> Supervisor Functions"},
                                                                                              {text:"Reports",id:'R0003018',leaf: true, qtip: "Value Added Tax System >> Reports"},
																							  {text:"AuditTrial",id:'R0003019',leaf: true,link:'AuditTrial', qtip: "Value Added Tax System >> AuditTrial"},
                                 
											{text:"Preliminary Assessment",id:'R000320', leaf: true,link:'VatPreAssmnt',qtip: "Value Added Tax System >> Preliminary Assessment"},
											{text:"Final Assessment",id:'R000321', leaf: true,link:'VatFinalAssmnt',qtip: "Value Added Tax System >> Final Assessment"},
												
												{text:"Appeal Entry",id:'R000323',leaf: true,link:'AppealEntry', qtip: "Value Added Tax System >> Appeal Entry"},
												{text:"Appeal decision",id:'R000324',leaf: true,link:'AppealDecision', qtip: "Value Added Tax System >> Appeal decision"},
												{text: "Notification", id: 'R000325', leaf: true, link: 'Notification', qtip: "Value Added Tax System >> Notification"},
												{text: "ReceiptPayments", id: 'R000326', leaf: true, link: 'ReceiptPayments', qtip: "Value Added Tax System >> ReceiptPayments"}												    
																							  
                                                                                          ]
                                                                           },
                                                                         { text: "Income Tax System", id: 'R000400',expanded: false,  iconCls: 'ico-test',link:'NULL',
                                                                                 children:[
																							  
                                                                                              {text:"Income Tax Login",id:'R000401',leaf: true,link:'GeneralizedLogin', qtip: "Income Tax System >> Income Tax Login"},
                                                                                              {text:"E-Estimate Return/Estimate Revision Return/Estimate Revision Notice",id:'R000402',leaf: true,link:'GetGeneralizedSubmissionNo',qtip: "Income Tax System >> E-Estimate Return/Estimate Revision Return/Estimate Revision Notice"},
                                                                                              {text:"Manual Estimate Return/Estimate Revision Return",id:'R000403',leaf: true,link:'EstimatedReturn', qtip: "Income Tax System >> Manual Estimate Return/Estimate Revision Return/Estimate Revision Notice"},
																							   {text:"Manual Estimate Revision Notice",id:'R0004033',leaf: true,link:'EstimateReturnRevisionNotice', qtip: "Income Tax System >> Manual Estimate Return/Estimate Revision Return/Estimate Revision Notice"},
                                                                                              {text:"Extension of filling date",id:'R000404',leaf: true,link:'ExtensionFillingDate', qtip: "Income Tax System >> Extension of filling date"},
                                                                                             
                                                                                              {text:"Primary Amended Assessment",id:'R000408',leaf: true, qtip: "Income Tax System >> Primary Amended Assessment"},
                                                                                              {text:"Final Amended Assessment",id:'R000409',leaf: true, qtip: "Income Tax System >> Final Amended Assessment"},
                                                                                              {text:"Transfer of credit",id:'R000410',leaf: true,link:'TransferOfCredit',qtip: "Income Tax System >> Transfer of credit"},
                                                                                              {text:"Refund ",id:'R000411',leaf: true, qtip: "Income Tax System >> Refund"},
                                                                                              {text:"Remission",id:'R000412',leaf: true,link:'Remission', qtip: "Income Tax System >> Remission"},
                                                                                              {text:"Charges",id:'R000413',leaf: true, qtip: "Income Tax System >> Charges"},
                                                                                              {text:"Charge Assessment",id:'R000414',leaf: true, qtip: "Income Tax System >> Charge Assessment"},
                                                                                              {text:"Amended Charge Assessment",id:'R000415',leaf: true, qtip: "Income Tax System >> Amended Charge Assessment"},
                                                                                              {text:"Review/Appeal Application",id:'R000416',leaf: true, link:'ReviewAppealApplication',qtip: "Income Tax System >> Review/Appeal Application"},
                                                                                              {text:"Review/Appeal Decision",id:'R000417',leaf: true,
																								link:'ReviewAppealDecision', qtip: "Income Tax System >> Review/Appeal Decision"},
                                                                                              {text:"Medical Tax Credit Claim",id:'R0004018',leaf: true,link:'MedicalCreditClaim', qtip: "Income Tax System >> Medical Tax Credit Claim"},
                                                                                              {text:"Foreign Tax Credit Claim",id:'R000419',leaf: true,link:'ForeignTaxCreditClaim', qtip: "Income Tax System >> Foreign Tax Credit Claim"},
                                                                                              {text:"Medical Tax Credit Amendment",id:'R000420',leaf: true, qtip: "Income Tax System >> Medical Tax Credit Amendment"},
                                                                                              {text:"Foreign Tax Credit Amendment",id:'R000421',leaf: true, qtip: "Income Tax System >> Foreign Tax Credit Amendment"},
                                                                                              {text:"Credit Claim",id:'R000422',leaf: true,link:'CreditClaim', qtip: "Income Tax System >> Credit Claim"},
                                                                                              {text:"Deposit Refund Claim",id:'R000423',leaf: true, qtip: "Income Tax System >> Deposit Refund Claim"},
                                                                                              {text:"Statistics/Reports",id:'R000424',leaf: true, qtip: "Income Tax System >> Statistics/Reports"},
                                                                                              {text:"Use Case Diagram of Income Tax",id:'R000425',leaf: true, qtip: "Income Tax System >> Use Case Diagram of Income Tax"},
																							  {text:"E-Self Assessment D01",id:'R000426',leaf: true, qtip: "Income Tax System >> SelfAssessmentD01",link:"GetGeneralizedSubmissionNo"},
																							 {text:"Manual-Self Assessment D01",id:'R000427',leaf: true, qtip: "Income Tax System >> Manual-SelfAssessmentD01",link:"SelfAssessmentD01"},																																			  
																						     
																							 {text:"E-Self Assessment D03",id:'R000428',leaf: true, qtip: "Income Tax System >> e-IncomeTax Self-Assessment",link:"eIncomeTaxSelfAssessment"},
										
                                                                                              {text:"Jeopardy Assessment",id:'R000429',leaf: true, qtip: "Income Tax System >> Jeopardy Assessment",link:"JeopardyAssessment"},	 											 {text:"Close off Business",id:'R000406',leaf: true, qtip: "Income Tax System >> Close off Business",link:"CloseOffBusiness"},
                                                                                              {text:"Change of Control",id:'R000430',leaf: true, qtip: "Income Tax System >> Change of Control" ,link:"ChangeOfControl"},																			{text:"Manual Self Assessment",id:'R000437',leaf: true, qtip: "Income Tax System >> Manual Self-Assessment",link:"ManualSelfAssessmentMD03"}, 									  {text:"Manual Jeopardy Assessment",id:'R000438',leaf: true, qtip: "Income Tax System >> Manual Jeopardy Assessment",link:"ManualSelfAssessmentMD03"}, 							 {text:"Manual Change of Control",id:'R000439',leaf: true, qtip: "Income Tax System >> Manual Change of Control",link:"ManualSelfAssessmentMD03"}, 									 {text:"Manual Close Off Business",id:'R000440',leaf: true, qtip: "Income Tax System >> Manual Close Off Business",link:"ManualSelfAssessmentMD03"}, 							   {text:"Amended Assessment",id:'R000441',leaf: true, qtip: "Income Tax System >> Amended Assessment",link:"AmendedAssmnt"}                                                                                                                                          ]
                                                                           },
                                                                        { text: "Excise Automation System (EASy)", id: 'R000500',expanded: false,  iconCls: 'ico-test',link:'NULL',
                                                                                 children:[
                                                                                            {text:"Excise Registration",id:'R000501',leaf: true, qtip: "Excise Automation System (EASy) >> Excise Registration"},
                                                                                              {text:"Use Case of Registration Module",id:'R000502',leaf: true, qtip: "Excise Automation System (EASy) >> Use Case of Registration Module"},
                                                                                              {text:"Activity Recording",id:'R000503',leaf: true, qtip: "Excise Automation System (EASy) >> Activity Recording"},
                                                                                              {text:"Request for raw material purchase",id:'R000504',leaf: true,link:'RequestForRawMaterialPurchase', qtip: "Excise Automation System (EASy) >> Request for raw material purchase"},
                                                                                              {text:"Raw material entry",id:'R000505',leaf: true, qtip: "Excise Automation System (EASy) >> Raw material entry"},
                                                                                              {text:"Request for production",id:'R000506',leaf: true, qtip: "Excise Automation System (EASy) >> Request for production"},
                                                                                              {text:"Production entry",id:'R000507',leaf: true, qtip: "Excise Automation System (EASy) >> Production entry"},
                                                                                              {text:"Sales Request",id:'R000508',leaf: true, qtip: "Excise Automation System (EASy) >> Sales Request"},
                                                                                              {text:"Credit Approval",id:'R000509',leaf: true, qtip: "Excise Automation System (EASy) >> Credit Approval"},
                                                                                              {text:"Deposit Approval",id:'R000510',leaf: true, qtip: "Excise Automation System (EASy) >> Deposit Approval"},
                                                                                              {text:"Sales Entry ",id:'R000511',leaf: true, qtip: "Excise Automation System (EASy) >> Sales Entry"},
                                                                                              {text:"Chalan Entry",id:'R000512',leaf: true, qtip: "Excise Automation System (EASy) >> Chalan Entry"},
                                                                                              {text:"Chalan Request Approval",id:'R000513',leaf: true, qtip: "Excise Automation System (EASy) >> Chalan Request Approval"},
                                                                                              {text:"Stored goods Transaction Request",id:'R000514',leaf: true, qtip: "Excise Automation System (EASy) >> Stored goods Transaction Request"},
                                                                                              {text:"Door Lock",id:'R000515',leaf: true, qtip: "Excise Automation System (EASy) >> Door Lock"},
                                                                                              {text:"Reports",id:'R000516',leaf: true, qtip: "Excise Automation System (EASy) >> Reports"},
                                                                                              {text:"Use Case of Activity Recording Module",id:'R000517',leaf: true, qtip: "Excise Automation System (EASy) >> Use Case of Activity Recording Module"},
                                                                                              {text:"Sticker Management System",id:'R0005018',leaf: true, qtip: "Excise Automation System (EASy) >> Sticker Management System"},
                                                                                              {text:"Sticker Order Placement",id:'R000519',leaf: true,link:'StickerOrderPlacement', qtip: "Excise Automation System (EASy) >> Sticker order placement"},
                                                                                              {text:"Sticker Delivery",id:'R000520',leaf: true,link:'StickerDelivery', qtip: "Excise Automation System (EASy) >> Sticker Delivery"},
                                                                                              {text:"Sticker Request",id:'R000521',leaf: true,link:'StickerRequest', qtip: "Excise Automation System (EASy) >> Sticker Request"},
                                                                                              {text:"Sticker Transaction",id:'R000522',leaf: true,link:'StickerTransaction', qtip: "Excise Automation System (EASy) >> Sticker Transaction"},
                                                                                              {text:"Sticker Stock Adjustment",id:'R000523',leaf: true,link:'StickerStockAdjustment', qtip: "Excise Automation System (EASy) >> Sticker Stock Adjustmen"},
                                                                                              {text:"Sticker Location Management",id:'R000524',leaf: true, qtip: "Excise Automation System (EASy) >> Sticker Location Management"},
                                                                                              {text:"Sticker Report",id:'R000525',leaf: true, qtip: "Excise Automation System (EASy) >> Sticker Report"},
                                                                                              {text:"Use Case diagram of Sticker ",id:'R000526',leaf: true, qtip: "Excise Automation System (EASy) >> Use Case diagram of Sticker"},
																							  {text:"Return entry",id:'R000533',leaf: true, qtip: "Excise Automation System (EASy) >> Return entry"},
                                                                                              {text:"Management System",id:'R000528',leaf: true, qtip: "Excise Automation System (EASy) >> Management System"},
                                                                                              {text:"Appeal",id:'R000529',leaf: true, qtip: "Excise Automation System (EASy) >> Appeal"},
                                                                                              {text:"Appeal decision",id:'R000530',leaf: true, qtip: "Excise Automation System (EASy) >> Appeal decision"},
                                                                                              {text:"Payments",id:'R000531',leaf: true, qtip: "Excise Automation System (EASy) >> Payments"},
                                                                                              {text:"Authorized Updates",id:'R000532',leaf: true, qtip: "Excise Automation System (EASy) >> Authorized Updates"},
																							  {text:"Request For Chalan",id:'R000534',leaf: true,link:'RequestForChalan',qtip: "Excise Automation System (EASy) >> Request For Chalan"}
																							  

                                                                                          ]
                                                                           },
                                                                       { text: "Revenue Accounting System (e-RAS)", id: 'R000600',expanded: false,  iconCls: 'ico-test',link:'NULL',
                                                                                 children:[
                                                                                            {text:"Amdani Rasid Entry",id:'R000601',leaf: true, qtip: "Revenue Accounting System (e-RAS) >> Amdani Rasid Entry"},
                                                                                              {text:"Bank Dakhila Entry",id:'R000602',leaf: true, qtip: "Revenue Accounting System (e-RAS) >> Bank Dakhila Entry"},
                                                                                              {text:"DTCO Entry",id:'R000603',leaf: true, qtip: "Revenue Accounting System (e-RAS) >> DTCO Entry"},
                                                                                              {text:"Posted Data Change Request (PDCR)",id:'R000604',leaf: true, qtip: "Revenue Accounting System (e-RAS) >> Posted Data Change Request (PDCR)"},
                                                                                              {text:"Day End",id:'R000605',leaf: true, qtip: "Revenue Accounting System (e-RAS) >> Day End"},
                                                                                              {text:"Uploading Data",id:'R000606',leaf: true, qtip: "Revenue Accounting System (e-RAS) >> Uploading Data"},
                                                                                              {text:"Reports",id:'R000607',leaf: true, qtip: "Revenue Accounting System (e-RAS) >> Reports"},
                                                                                              {text:"Use Case of e-RAS",id:'R000608',leaf: true, qtip: "Revenue Accounting System (e-RAS) >> Use Case of e-RAS"}
                                                                                          ]
                                                                           },
                                                                       { text: "Security", id: 'R000700',expanded: false,  iconCls: 'ico-test',link:'NULL',
                                                                                 children:[
                                                                                            {text:"Role",id:'R000701',leaf: true,link:'Role', qtip: "Security >> Role"},
                                                                                            {text:"User",id:'R000702',leaf: true,link:'User', qtip: "Security >> User"},
                                                                                           
											{ text: "ModuleMachine", id: 'R000705', leaf: true, link: 'ModuleMachine', qtip: "Security >> ModuleMachine"},
                                                                                            { text: "ChangePassword", id: 'R000706', leaf: true, link: 'ChangePassword', qtip: "Security >> ChangePassword"}
                                                                                          ]
                                                                             },
                                                                        { text: "Verification", id: 'R000800',expanded: false,  iconCls: 'ico-test',link:'NULL',
                                                                                 children:[
                                                                                           {text:"Verification Module",id:'R000801',leaf: true,link:'SelectionOfVerificationModule', qtip: "Verification >> Verification Module"},
                                                                                            {text:"UserVerification",id:'R000802',leaf: true,link:'UserVerification', qtip: "Verification >> UserVerification"},
                                                                                            { text: "ModuleVerification", id: 'R000803', leaf: true, link: 'ModuleVerification', qtip: "Verification >> ModuleVerification"},
																							{ text: "Officer Verification", id: 'R000804', leaf: true, link: 'OfficerVerification', qtip: "Verification >> Officer Verification"}
                                                                                          ]
                                                                           }
]