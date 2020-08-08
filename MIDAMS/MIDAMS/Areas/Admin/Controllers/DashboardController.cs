﻿using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using MIDAMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MIDAMS.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleName.Admin)]
    public class DashboardController : Controller
    {        
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

            var baseUrl = Request.Url.Scheme + "://" + Request.Url.Authority;
            var url = baseUrl + "/Account/Login";
            return Redirect(url);
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
    }
}