Ext.SSL_SECURE_URL="s.gif"; 
Ext.BLANK_IMAGE_URL="s.gif";


LoginWindow = function (config) {
	this.width = 520;
	this.height = 330;
	this.closable  = false;
	this.title = "Administrator Login";
	
	Ext.apply(this,config);
	LoginWindow.superclass.constructor.call(this);
}

Ext.extend(LoginWindow,Ext.Window,{
	onActionComplete : function (f, a){
					if(a && a.result && a.result.success){
						var path = window.location.pathname,
							path = path.substring(0, path.lastIndexOf('/') + 1);
							alert(a.result.msg);
							window.location = path;  // Change this path to redirect to your path
						window.location.reload( false );
					 }
	},
	onActionFailed : function(f,a){
			this.onCapthaChange();
			var form = this.loginPanel.getForm();
			alert(a.result.errors.msg);
			if (a.result.errors.id){
				var f = form.findField(a.result.errors.id);
				if(f){
					f.focus();
				}
			}
			//Do Action when Login Failed
	},
	onCapthaChange : function(){
				var captchaURL = this.captchaURL;
				var curr = Ext.get('activateCodeImg');
				curr.slideOut('b', {callback: function(){
							Ext.get( 'activateCodeImg' ).dom.src= captchaURL+new Date().getTime();
							curr.slideIn('t');		
				}},this);
	},
	initComponent : function () {
				this.submitUrl = "login.php";
				this.captchaURL = "captcha/CaptchaSecurityImages.php?width=160&height=80&characters=4&t=";
				var boxCaptcha = new Ext.Component({
									columnWidth:.35,	
									autoEl: {
										tag:'img'
										,id: 'activateCodeImg'
										,title : 'Click to refresh code'
										,src:this.captchaURL+new Date().getTime()
									}
									,listeners : {
//											'click' : function () {
//												alert('test');
//											}
										}	
				});
				boxCaptcha.on('render',function (){
					var curr = Ext.get('activateCodeImg');
					curr.on('click',this.onCapthaChange,this);
				},this);
				this.loginPanel = new Ext.form.FormPanel({
						frame:true,
						height: 100,
						region : 'center',
						id: 'loginpanel',
						baseParams : {
							task : 'login'
						},
						bodyStyle:'padding:10px',
						buttons : [
							{
								text : 'Submit',
								handler: onSubmit
							}
							,
							{
								text : 'Cancel',
								handler : Ext.emptyFn
							}
						],
						items: [
								{
									layout : 'column',
									items : [
										{
											layout : 'form',
											columnWidth:.65,
											layoutConfig: {
												labelSeparator: ''
											}
											,items : [
														{
															fieldLabel: 'Email Address ',
															name: 'user',
															xtype : 'textfield',
															value: 'amemorablejourney@yahoo.com'
															,anchor:'90%'
														},
														{
															fieldLabel: 'Password		',
															xtype : 'textfield',
															inputType: 'password',
															name: 'pass',
															value : 'wahanailmu.wordpress.com',
															anchor:'90%'
														}
														,
														{
															fieldLabel: 'Security Code ',
															name: 'code',
															xtype : 'textfield'
															,anchor:'90%'											
														}
											]
									}
										,boxCaptcha
									]
								}
						]
						,listeners: {
							'actioncomplete': {
								fn: this.onActionComplete,
								scope: this
							},
							'actionfailed': {
								fn: this.onActionFailed,
								scope: this
							}
						}
						,url: this.submitUrl
					});		
			var form = this.loginPanel.getForm();
			function onSubmit() {
				form.submit({
					reset : true
				});
			};
		
			this.layout = "border";
			this.items = [
				{
					xtype:'panel',
					html : 'Logo',
					region : 'north',
					height: 140
				},
				this.loginPanel
			];
			LoginWindow.superclass.initComponent.call(this);
	}
});
Ext.onReady(function () {
	var loginwindow = new LoginWindow();
	loginwindow.show();
});