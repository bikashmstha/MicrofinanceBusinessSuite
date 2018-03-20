/// <reference path="ext-all-debug-w-comments.js" />
Ext.ns('IRD.SM.Control');
Ext.ns('IRD.Utilities');

IRD.Utilities.AddRemoveButton = Ext.extend(Ext.BoxComponent, {
    initComponent: function () {
        this.autoEl = {
            tag: 'div',
            cls: 'addNewCls',
            cn: [{
                tag: 'div',
                cn: [{
                    tag: 'a',
                    html: this.text,
                    href: '#',
                    style: 'margin-left:5px;'
                }]
            }]
        };
        IRD.Utilities.AddRemoveButton.superclass.initComponent.apply(this, arguments);
        this.addEvents('click');
    },
    onRender: function () {
        IRD.Utilities.AddRemoveButton.superclass.onRender.apply(this, arguments);
        //  this.el.setWidth(220);
        this.el.on('click', this.onClick, this);
    },
    afterRender: function () {
        IRD.Utilities.AddRemoveButton.superclass.afterRender.apply(this, arguments);
        if (this.minusType) {
            this.el.replaceClass('addNewCls', 'minusNewCls');
        }
    },
    onClick: function () {
        this.fireEvent('click', this);
    }
});
Ext.reg("addRemBtn", IRD.Utilities.AddRemoveButton);

