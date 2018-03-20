/*
 * File: app/model/RegPermit.js
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

Ext.define('MyApp.model.RegPermit', {
    extend: 'Ext.data.Model',

    requires: [
        'Ext.data.Field',
        'Ext.data.association.HasMany'
    ],
    uses: [
        'MyApp.model.RegPermitActivity',
        'MyApp.model.ExcisableGood'
    ],

    fields: [
        {
            name: 'Office_Code'
        },
        {
            name: 'Request_No'
        },
        {
            name: 'PanNo'
        },
        {
            name: 'SubmissionNo'
        },
        {
            name: 'ItemCode'
        },
        {
            name: 'FromDate'
        },
        {
            name: 'PermitFrom'
        },
        {
            name: 'PermitTo'
        },
        {
            name: 'PermitStatus'
        },
        {
            name: 'ExciseRate'
        },
        {
            name: 'PermitNo'
        },
        {
            name: 'RegistrationFor'
        },
        {
            name: 'FinAmount'
        },
        {
            name: 'UnderPhyCtrl'
        },
        {
            name: 'ProdRepRequired'
        },
        {
            name: 'ApprovedBy'
        },
        {
            name: 'ApprovedDate'
        },
        {
            name: 'PenaltyAmount'
        },
        {
            name: 'Action'
        },
        {
            name: 'ActivityList'
        },
        {
            name: 'ItemNameEnglish'
        }
    ],

    hasMany: [
        {
            model: 'MyApp.model.RegPermitActivity',
            name: 'RegPermitActivities'
        },
        {
            model: 'MyApp.model.ExcisableGood',
            name: 'ExcisableGoods'
        }
    ]
});