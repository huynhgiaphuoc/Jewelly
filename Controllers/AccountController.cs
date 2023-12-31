﻿using Jewelly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace Jewelly.Controllers
{
    public class AccountController : Controller
    { 
        jewellyEntities db = new jewellyEntities();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login( string password,string username)
        {
           
            if (ModelState.IsValid)
            {
               
                var f_password = GetMD5(password);
                var data_cus = db.UserRegMsts.Where(s => s.Username == username && s.password.Equals(f_password));
                var data_ad= db.AdminLoginMsts.Where(s => s.userName == username && s.Password.Equals(f_password));

                if (data_cus.Count() > 0)
                {
                    //add session
                    Session["userFname"] = data_cus.FirstOrDefault().userFname;
                    Session["userLname"] = data_cus.FirstOrDefault().userLname;
                    Session["address"] = data_cus.FirstOrDefault().address;
                    Session["city"] = data_cus.FirstOrDefault().city;
                    Session["state"] = data_cus.FirstOrDefault().state;
                    Session["mobNo"] = data_cus.FirstOrDefault().mobNo;
                    Session["emailID"] = data_cus.FirstOrDefault().emailID;
                    Session["dob"] = data_cus.FirstOrDefault().dob;
                    Session["cdate"] = data_cus.FirstOrDefault().cdate;
                    Session["password"] = data_cus.FirstOrDefault().password;
                    Session["photo"] = data_cus.FirstOrDefault().photo;
                    Session["Username"] = data_cus.FirstOrDefault().photo;
                    Session["Path_photo"] = data_cus.FirstOrDefault().Path_photo;
                    return RedirectToAction("Index", "Home");
                }
                else if (data_ad.Count()>0)
                { 
                    //add session
                    Session["Name_employee"] = data_ad.FirstOrDefault().Name_employee;
                    Session["Avatar"] = data_ad.FirstOrDefault().Avatar;
                    Session["Path_avt"] = data_ad.FirstOrDefault().Path_avt;
                    Session["Birthday"] = data_ad.FirstOrDefault().Birthday;
                    Session["Email"] = data_ad.FirstOrDefault().Email;
                    Session["Phone"] = data_ad.FirstOrDefault().Phone;
                    Session["Address"] = data_ad.FirstOrDefault().Address;
                    Session["PasswordAd"] = f_password;
                    Session["userName"] = data_ad.FirstOrDefault().userName;
                    //return View("~/Areas/Admin/Views/HomeAdmin/Index.cshtml");
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                else
                {
                    return RedirectToAction("Login");
                }
            }
            return RedirectToAction("Index", "Home");

        }
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(FormCollection form,UserRegMst user,string Username)
        {
            if (ModelState.IsValid)
            {
                var check = db.UserRegMsts.FirstOrDefault(s => s.Username == Username);
                if (check == null)
                {  
                    
                    user.userLname = form["userLname"];
                    user.userFname = form["userFname"];
                    user.address = form["address"];
                    user.city = form["city"];
                    user.state = "Online";
                    user.mobNo = form["mobNo"];
                    user.emailID = form["emailID"];
                    user.dob = form["dob"];
                    user.cdate = DateTime.Now.ToString();
                    user.password = GetMD5(form["password"]);
                    user.Username = form["Username"];
                    db.UserRegMsts.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Login","Account");
                    
                   
                   

                }
                else
                {
                    ViewBag.error = "Username already exists";
                    return View();
                }
            }
            return View();
        }

        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }
       
    }
}