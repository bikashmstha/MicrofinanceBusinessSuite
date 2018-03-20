using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using System.ComponentModel;


using MicrofinanceBusinessSuite.Utility;
using MicrofinanceBusinessSuite.Controllers;
using BusinessObjects.Security;
using BusinessObjects.Messages;
using BusinessObjects.MessageBase;
using DataObjects.Security;
using DataObjects;

namespace IntegratedTaxSystem.Controllers.Security
{
    public class LoginController : ControllerBase
    {
        private static ILoginDao loginDao = DataAccess.LoginDao;
        public ExtJSResponse Login(GenericUser user)
        {
            LoginRequest request = new LoginRequest();
            request.User = user;

            ExtJSResponse extResp = new ExtJSResponse();
            extResp.Obj = null;
            extResp.Total = 0;

            GenericUser response;
            try
            {
                response = loginDao.LogIn(user);

                //if (response.Acknowledge == AcknowledgeType.Success)
                //{
                if (response.LoggedIn)
                {
                    //ClearSession();              
                    System.Web.HttpContext.Current.Session["User"] = response;
                    extResp.Success = "true";

                    //  extResp.Obj = GetMenuData((response.User as User).Menus);
                    //((IntegratedTaxSystem.BusinessObjectsReference.User)(response.User)).Menus
                    //(response.User)
                    extResp.Obj = response;
                    extResp.MenuObj = GetMenuData((response as User).Menus);
                    extResp.Total = 1;
                    extResp.Message = "User Login Succcessful.";
                }
                else
                {
                    extResp.Success = "false";
                    extResp.Message = "User Login Failed !";
                }
                //}
                //else
                //{
                //    extResp.Success = "false";
                //    extResp.Message = response.Message;
                //}


            }
            catch (Exception ex)
            {
                extResp.Success = "false";
                extResp.Message = ex.Message;
                extResp.Obj = null;
                extResp.Total = 0;

            }

            return extResp;

        }
        public MenuData GetMenuData(List<Menu> menuList)
        {
            MenuData menudata = new MenuData();
            menudata.text = "MicroFinance";
            bool hasSubModule = false;

            string applicationId = string.Empty;

            foreach (Menu menu in menuList)
            {
                if (menu.AppDesc != applicationId)
                {
                    applicationId = menu.AppDesc;
                    Node application = new Node();
                    application.appId = menu.AppID;
                    application.text = menu.AppDesc;
                    application.id = Guid.NewGuid().ToString();
                    application.expanded = false;
                    application.iconCls = "ico-test";
                    application.link = null;

                    hasSubModule = !string.IsNullOrEmpty(menu.SubModuleDesc);

                    List<Menu> modules = menuList.FindAll(delegate(Menu mnu) { return mnu.AppDesc == applicationId; });
                    string moduleId = string.Empty;

                    if (!hasSubModule)
                    {
                        foreach (Menu mdl in modules)
                        {
                            if (mdl.ModuleID != moduleId)
                            {
                                moduleId = mdl.ModuleID;
                                Node module = new Node();
                                module.text = mdl.ModuleDesc;
                                module.id = Guid.NewGuid().ToString();
                                module.link = mdl.MenuName;

                                module.leaf = false;
                                List<Menu> forms = menuList.FindAll(delegate(Menu mnu) { return mnu.ModuleID == moduleId && mnu.AppDesc == applicationId; });
                                string formID = string.Empty;
                                if (modules.Count > 0)
                                {
                                    foreach (Menu form in forms)
                                    {
                                        Node mnu = new Node();
                                        mnu.text = form.MenuName;
                                        mnu.id = Guid.NewGuid().ToString();
                                        mnu.link = form.MenuName;
                                        mnu.leaf = true;
                                        module.children.Add(mnu);
                                    }
                                }
                                application.children.Add(module);

                            }
                        }
                    }
                    else
                    {
                        string subModId = string.Empty;

                        foreach (Menu mdl in modules)
                        {
                            if (mdl.ModuleID != moduleId)
                            {

                                moduleId = mdl.ModuleID;
                                Node module = new Node();
                                module.text = mdl.ModuleDesc;
                                module.id = Guid.NewGuid().ToString();
                                module.link = mdl.MenuName;

                                module.leaf = false;

                                List<Menu> subModules = menuList.FindAll(delegate(Menu mnu) { return mnu.AppDesc == applicationId && mnu.ModuleID == moduleId; });

                                foreach (var sModule in subModules)
                                {
                                    if (sModule.SubModuleID != subModId)
                                    {
                                        subModId = sModule.SubModuleID;
                                        Node subModule = new Node();
                                        subModule.text = sModule.SubModuleDesc;
                                        subModule.id = Guid.NewGuid().ToString();
                                        subModule.link = sModule.SubModuleDesc;

                                        subModule.leaf = false;

                                        List<Menu> forms = menuList.FindAll(delegate(Menu mnu) { return mnu.ModuleID == moduleId && mnu.AppDesc == applicationId && mnu.SubModuleID == subModId; });
                                        string formID = string.Empty;
                                        if (modules.Count > 0)
                                        {
                                            foreach (Menu form in forms)
                                            {
                                                Node mnu = new Node();
                                                mnu.text = form.MenuName;
                                                mnu.id = Guid.NewGuid().ToString();
                                                mnu.link = form.MenuName;
                                                mnu.leaf = true;
                                                subModule.children.Add(mnu);
                                            }
                                        }

                                        module.children.Add(subModule);
                                    }
                                }
                                //list<menu> forms = menulist.findall(delegate(menu mnu) { return mnu.moduleid == moduleid && mnu.appdesc == applicationid; });
                                //string formid = string.empty;
                                //if (modules.count > 0)
                                //{
                                //    foreach (menu form in forms)
                                //    {
                                //        node mnu = new node();
                                //        mnu.text = form.menuname;
                                //        mnu.id = guid.newguid().tostring();
                                //        mnu.link = form.menuname;
                                //        mnu.leaf = true;
                                //        module.children.add(mnu);
                                //    }
                                //}
                                application.children.Add(module);

                            }
                        }
                    }
                    menudata.children.Add(application);
                }
            }
            return menudata;
        }

        //public MenuData GetMenuData(List<Menu> menuList)
        //{
        //    MenuData menudata = new MenuData();
        //    menudata.text = "MicroFinance";

        //    string applicationId = string.Empty;

        //    foreach (Menu menu in menuList)
        //    {
        //        if (menu.AppDesc != applicationId)
        //        {
        //            applicationId = menu.AppDesc;

        //            Node application = new Node();
        //            application.appId = menu.AppID;
        //            application.text = menu.AppDesc;
        //            application.id = Guid.NewGuid().ToString();
        //            application.expanded = false;
        //            application.iconCls = "ico-test";
        //            application.link = null;

        //            List<Menu> modules = menuList.FindAll(delegate(Menu mnu) { return mnu.AppDesc == applicationId; });
        //            string moduleId = string.Empty;
        //            if (modules.Count > 0)
        //            {
        //                foreach (Menu mdl in modules)
        //                {
        //                    if (mdl.ModuleID != moduleId)
        //                    {
        //                        moduleId = mdl.ModuleID;

        //                        Node module = new Node();

        //                        module.text = mdl.ModuleDesc;
        //                        module.id = Guid.NewGuid().ToString();
        //                        module.leaf = true;
        //                        module.link = mdl.MenuName;
        //                        application.children.Add(module);
        //                    }
        //                }
        //            }
        //            menudata.children.Add(application);
        //        }
        //    }
        //    return menudata;
        //}

        //private string GetMenuData(List<Menu> menuList)
        //{
        //    StringBuilder menuData = new StringBuilder();

        //    menuData.Append("[");

        //    string applicationId = string.Empty;

        //    foreach (Menu menu in menuList)
        //    {
        //        if (menu.ApplicationID != applicationId)
        //        {
        //            applicationId = menu.ApplicationID;
        //            menuData.Append("{");
        //            menuData.AppendFormat(" text: \"{0}\", id: \"{1}\", expanded: false,  iconCls: \"ico-test\",link:\"NULL\" ", applicationId, Guid.NewGuid().ToString());

        //            List<Menu> modules = menuList.FindAll(delegate(Menu mnu) { return mnu.ApplicationID == applicationId; });
        //            string moduleId = string.Empty;
        //            if (modules.Count > 0)
        //            {
        //                menuData.Append(",children: [");

        //                foreach (Menu mdl in modules)
        //                {
        //                    if (mdl.ModuleID != moduleId)
        //                    {
        //                        moduleId = mdl.ModuleID;
        //                        menuData.Append("{");
        //                        menuData.AppendFormat(" text: \"{0}\", id: \"{1}\", leaf: true, link: \"{2}\" ", mdl.ModuleID, Guid.NewGuid().ToString(), mdl.ModuleID);
        //                        menuData.Append("},");
        //                    }

        //                }
        //                menuData.Remove(menuData.Length - 1, 1);
        //                menuData.Append("]");
        //            }

        //            menuData.Append("},");
        //        }
        //    }

        //    menuData.Remove(menuData.Length - 1, 1);
        //    menuData.Append("]");

        //    return menuData.ToString();
        //}


        public ExtJSResponse Logout()
        {
            ExtJSResponse extResp = new ExtJSResponse();

            try
            {
                ClearSession();

                extResp.Success = "true";
                extResp.Message = "User Logged Out";
                extResp.Obj = null;
                extResp.Total = 0;
            }
            catch (Exception ex)
            {
                extResp.Success = "false";
                extResp.Message = ex.Message;
                extResp.Obj = null;
                extResp.Total = 0;

            }

            return extResp;
        }

        public void ClearSession()
        {
            System.Web.HttpContext.Current.Session["User"] = null;
            var httpSession = System.Web.HttpContext.Current.Session;
            System.Web.HttpContext.Current.Session.Clear();
            System.Web.HttpContext.Current.Session.Abandon();

            System.Web.HttpContext.Current.Response.Clear();
            System.Web.HttpContext.Current.Response.ClearContent();
            System.Web.HttpContext.Current.Response.ClearHeaders();
        }

        public ExtJSResponse GetUserFromSession()
        {
            ExtJSResponse extResp = new ExtJSResponse();

            extResp.Obj = System.Web.HttpContext.Current.Session["User"];
            extResp.MenuObj = GetMenuData((System.Web.HttpContext.Current.Session["User"] as User).Menus);
            extResp.Total = 1;
            extResp.Message = "User Login Succcessful.";

            return extResp;
        }
    }
}