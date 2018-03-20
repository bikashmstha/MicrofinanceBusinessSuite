/*
 * File: app/model/RentAddress.js
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

Ext.define('MyApp.model.RentAddress', {
    extend: 'Ext.data.Model',

    requires: [
        'Ext.data.Field',
        'Ext.data.association.HasOne'
    ],
    uses: [
        'MyApp.model.Address'
    ],

    fields: [
        {
            name: 'PAN'
        },
        {
            name: 'Office_Code'
        },
        {
            name: 'Request_No'
        },
        {
            name: 'SubmissionNo'
        },
        {
            name: 'Business_SNO'
        },
        {
            name: 'AddressSNO'
        },
        {
            name: 'Action'
        }
    ],

    hasOne: {
        model: 'MyApp.model.Address',
        getterName: 'Address',
        setterName: 'Address'
    }
});