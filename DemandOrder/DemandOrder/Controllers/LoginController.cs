using DemandOrder.Models;
using DemandOrder.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DemandOrder.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel loginModel)
        {
            UserDBService db = new UserDBService();

            if (!ModelState.IsValid)
            {
                return View();
            }

            // 登入的密碼（以 SHA1 加密）
            var Password = FormsAuthentication.HashPasswordForStoringInConfigFile(loginModel.Password, "SHA1");

            //這一條是去資料庫抓取輸入的帳號密碼的方法請自行實做
            var r = db.GetSingleAccount(loginModel.Account, loginModel.Password);

            if (r == null)
            {
                TempData["Error"] = "您輸入的帳號不存在或者密碼錯誤!";
                return View();
            }

            // 登入時清空所有 Session 資料
            Session.RemoveAll();

            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
              r.UserName,//你想要存放在 User.Identy.Name 的值，通常是使用者帳號
              DateTime.Now,
              DateTime.Now.AddMinutes(30),
              false,//將管理者登入的 Cookie 設定成 Session Cookie
              r.Rank.ToString(),//userdata看你想存放啥
              FormsAuthentication.FormsCookiePath);

            string encTicket = FormsAuthentication.Encrypt(ticket);

            Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));

            return RedirectToAction("Index", "DemandOrder");
        }
    }
}