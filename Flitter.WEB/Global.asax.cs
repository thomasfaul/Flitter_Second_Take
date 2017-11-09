using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace Flitter.WEB
{
    public class MvcApplication : System.Web.HttpApplication
    {
        #region Application Start
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // log4net start logging!!!
            XmlConfigurator.Configure();
        }
        #endregion

        #region Session Start
        protected void Session_Start(Object sender, EventArgs e)
        {
            int temp = 45;
            HttpContext.Current.Session.Add("Usersession", temp);
        }
        #endregion

        #region Application_AuthenticateRequest
        /// <summary>
        /// TODO Comment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
            HttpCookie authCookie = Context.Request.Cookies[FormsAuthentication.FormsCookieName];

            if (authCookie == null || authCookie.Value == "")
                return;

            FormsAuthenticationTicket authTicket;

            try
            {
                authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                // Cookie wird entschlüsselt
            }
            catch (Exception)
            {

                return;
            }

            string[] roles = authTicket.UserData.Split(';');
            // Benuter kann mehrere Rollen besetzen

            Context.User = new GenericPrincipal(new GenericIdentity(authTicket.Name), roles);

            //Wir legen für unseren Benutzer ein neues Identifikationsobjekt an
        }

        #endregion
    }
}
