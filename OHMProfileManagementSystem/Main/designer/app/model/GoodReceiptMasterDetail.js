/*
 * File: app/model/GoodReceiptMasterDetail.js
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

Ext.define('MyApp.model.GoodReceiptMasterDetail', {
    extend: 'Ext.data.Model',

    requires: [
        'Ext.data.Field'
    ],

    fields: [
        {
            name: 'ReferenceNo'
        },
        {
            name: 'FiscalYear'
        },
        {
            name: 'SupplierCode'
        },
        {
            name: 'SupplierDesc'
        },
        {
            name: 'LocationCode'
        },
        {
            name: 'LocationDesc'
        },
        {
            name: 'TransactionDate'
        },
        {
            name: 'TransactionDateNep'
        },
        {
            name: 'Remarks'
        },
        {
            name: 'EmpId'
        },
        {
            name: 'EmpName'
        },
        {
            name: 'DeptCode'
        },
        {
            name: 'DeptName'
        },
        {
            name: 'TranOfficeCode'
        },
        {
            name: 'ParentRefNo'
        }
    ]
});