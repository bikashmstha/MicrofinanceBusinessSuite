/*
 * File: app/view/LoginSecurity.js
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

Ext.define('MyApp.view.LoginSecurity', {
    extend: 'Ext.panel.Panel',

    border: 0,
    padding: '',

    initComponent: function() {
        var me = this;

        Ext.applyIf(me, {
            items: [
                {
                    xtype: 'panel',
                    frame: true,
                    height: 800,
                    margin: '0 2 0 0',
                    maxHeight: 800,
                    title: '..:::Document Management System',
                    items: [
                        {
                            xtype: 'form',
                            frame: true,
                            itemId: 'pnlLoginSec',
                            style: 'margin:70px auto',
                            width: 350,
                            layout: {
                                type: 'fit'
                            },
                            bodyPadding: 10,
                            title: 'Login',
                            items: [
                                {
                                    xtype: 'fieldset',
                                    itemId: 'fldLoginSec',
                                    padding: '20 20 10 20',
                                    title: '',
                                    items: [
                                        {
                                            xtype: 'textfield',
                                            anchor: '100%',
                                            itemId: 'txtUserNameSec',
                                            maxHeight: 20,
                                            fieldLabel: 'User Name',
                                            msgTarget: 'side',
                                            allowBlank: false
                                        },
                                        {
                                            xtype: 'textfield',
                                            anchor: '100%',
                                            itemId: 'txtPasswordSec',
                                            maxHeight: 20,
                                            fieldLabel: 'Password',
                                            msgTarget: 'side',
                                            inputType: 'password',
                                            allowBlank: false
                                        },
                                        {
                                            xtype: 'container',
                                            height: 50,
                                            maxHeight: 50,
                                            style: 'padding-left:116px',
                                            items: [
                                                {
                                                    xtype: 'button',
                                                    itemId: 'btnLoginSec',
                                                    margin: '0 5 0 -12',
                                                    padding: 5,
                                                    iconCls: 'icon-ok',
                                                    text: 'Login'
                                                },
                                                {
                                                    xtype: 'button',
                                                    itemId: 'btnCancelSec',
                                                    padding: 5,
                                                    iconCls: 'icon-cancel',
                                                    text: 'Cancel'
                                                }
                                            ]
                                        }
                                    ]
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