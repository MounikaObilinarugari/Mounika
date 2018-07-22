using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentingVehicles.Models;
using System.Web.Security;
namespace RentingVehicles.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        mydbcontext dc = new mydbcontext();
        // GET: User
        
     
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
      public ActionResult Login(LoginModel model)
        {
            bool status = Membership.ValidateUser(model.LoginID, model.Password);
            if(status==true)
            {
                FormsAuthentication.SetAuthCookie(model.LoginID, model.RememberMe);
                return RedirectToAction("AddVehicle", "User");
            }
            ViewBag.msg = "Invalid user or Password";
            return View();
        }
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult NewUser()
        {
            return View();
        }
    
        [HttpPost]
        [AllowAnonymous]
        public ActionResult NewUser(NewUserModel model)
        {
            if(ModelState.IsValid)
            {
                int count = dc.NewUsers.Where((c) => c.UserID == model.UserID).Count();
                if(count>0)
                {
                    ViewBag.msg = "User Already Exists";
                }
                else
                {
                    MembershipCreateStatus status;
                    Membership.CreateUser(model.UserID, model.Password, model.UserID, "a", "b",true, out status);
                    if (status == MembershipCreateStatus.Success)
                    {
                        Roles.AddUserToRole(model.UserID, "Users");
                        dc.NewUsers.Add(model);
                        dc.SaveChanges();
                        ViewBag.msg = "UserAdded"+status;
                    }
                  
                }
            }
            else
            {
                ViewBag.msg = "Invalid Model";
            }
            return View();
           
        }
        [AllowAnonymous]
        public ActionResult AddVehicle()
        {
            List<SelectListItem> Cities = new List<SelectListItem>();
            Cities.Add(new SelectListItem { Text = "Select", Value = "" });
            Cities.Add(new SelectListItem { Text = "Hydrabad", Value = "1" });
            Cities.Add(new SelectListItem { Text = "Banglore", Value = "2" });
            Cities.Add(new SelectListItem { Text = "Pune", Value = "3" });
            Cities.Add(new SelectListItem { Text = "Kadapa", Value = "4" });
            Cities.Add(new SelectListItem { Text = "Vijaz", Value = "5" });
            ViewBag.types = Cities;

            List<SelectListItem> Categories = new List<SelectListItem>();
            Categories.Add(new SelectListItem { Text = "Select", Value = "" });
            Categories.Add(new SelectListItem { Text = "Two Wheeller", Value = "1" });
            Categories.Add(new SelectListItem { Text = "SUV", Value = "2" });
            Categories.Add(new SelectListItem { Text = "Hatch Bag", Value = "3" });
            Categories.Add(new SelectListItem { Text = "Sidan", Value = "4" });

            ViewBag.types1 = Categories;
            return View();
        }
        [HttpPost]
  
        public ActionResult AddVehicle(AddVehicleModel model, HttpPostedFileBase file1)
        {

            List<SelectListItem> Cities = new List<SelectListItem>();
            Cities.Add(new SelectListItem { Text = "Select", Value = "" });
            Cities.Add(new SelectListItem { Text = "Hydrabad", Value = "1" });
            Cities.Add(new SelectListItem { Text = "Banglore", Value = "2" });
            Cities.Add(new SelectListItem { Text = "Pune", Value = "3" });
            Cities.Add(new SelectListItem { Text = "Kadapa", Value = "4" });
            Cities.Add(new SelectListItem { Text = "Vijaz", Value = "5" });
            ViewBag.types = Cities;

            List<SelectListItem> Categories = new List<SelectListItem>();
            Categories.Add(new SelectListItem { Text = "Select", Value = "" });
            Categories.Add(new SelectListItem { Text = "Two Wheeller", Value = "1" });
            Categories.Add(new SelectListItem { Text = "SUV", Value = "2" });
            Categories.Add(new SelectListItem { Text = "Hatch Bag", Value = "3" });
            Categories.Add(new SelectListItem { Text = "Sidan", Value = "4" });
            ViewBag.types1 = Categories;

            model.UserID = User.Identity.Name;
            if(ModelState.IsValid)
            {
                int count=dc.Vehicles.Where((c) => c.VehicleID == model.VehicleID).Count();
                if (count > 0)
                {
                    ViewBag.msg = "VehicleID Already Exist";
                }
                else
                {
                    if (file1 != null)
                    {
                        string UserID = User.Identity.Name;
                        model.VehicleImageAddress = "/Images/" + model.VehicleID + ".jpg";
                        dc.Vehicles.Add(model);
                        dc.SaveChanges();

                        file1.SaveAs(Server.MapPath(model.VehicleImageAddress));

                        ViewBag.msg = "VehicleAddedSuccessfully";
                    }
                    else
                    {
                        ViewBag.msg = "Upload an Image";
                    }
                }
                    
            }
            return View();
        }

       
        public ActionResult ViewMyVehicle()
        {
            string userid = User.Identity.Name;
            var list = dc.Vehicles.Where((v) => v.UserID==userid).ToList();
            return View(list);
        }


        public ActionResult SearchVehicle()
        {
            List<SelectListItem> Cities = new List<SelectListItem>();
            Cities.Add(new SelectListItem { Text = "Select", Value = "" });
            Cities.Add(new SelectListItem { Text = "Hydrabad", Value = "1" });
            Cities.Add(new SelectListItem { Text = "Banglore", Value = "2" });
            Cities.Add(new SelectListItem { Text = "Pune", Value = "3" });
            Cities.Add(new SelectListItem { Text = "Kadapa", Value = "4" });
        
            ViewBag.types = Cities;

            List<SelectListItem> Categories = new List<SelectListItem>();
            Categories.Add(new SelectListItem { Text = "Select", Value = "" });
            Categories.Add(new SelectListItem { Text = "Two Wheeller", Value = "1" });
            Categories.Add(new SelectListItem { Text = "SUV", Value = "2" });
            Categories.Add(new SelectListItem { Text = "Hatch Bag", Value = "3" });
            Categories.Add(new SelectListItem { Text = "Sidan", Value = "4" });
            ViewBag.types1 = Categories;

            return View();
        }

        [HttpPost]

        public ActionResult SearchVehicle(SearchModel model)
        {
            List<SelectListItem> Cities = new List<SelectListItem>();
            Cities.Add(new SelectListItem { Text = "Select", Value = "" });
            Cities.Add(new SelectListItem { Text = "Hydrabad", Value = "1" });
            Cities.Add(new SelectListItem { Text = "Banglore", Value = "2" });
            Cities.Add(new SelectListItem { Text = "Pune", Value = "3" });
            Cities.Add(new SelectListItem { Text = "Kadapa", Value = "4" });
          
            ViewBag.types = Cities;

            List<SelectListItem> Categories = new List<SelectListItem>();
            Categories.Add(new SelectListItem { Text = "Select", Value = "" });
            Categories.Add(new SelectListItem { Text = "Two Wheeller", Value = "1" });
            Categories.Add(new SelectListItem { Text = "SUV", Value = "2" });
            Categories.Add(new SelectListItem { Text = "Hatch Bag", Value = "3" });
            Categories.Add(new SelectListItem { Text = "Sidan", Value = "4" });
            ViewBag.types1 = Categories;
            string userid = User.Identity.Name;
            Session["searchdata"] = model;
            var list = dc.Vehicles.Where((v) => v.UserID != userid && v.City == model.City && v.VehicleCategory == model.Category).ToList();
            if (list.Count > 0)
            {
                return View("searchresult", list);
            }
            else
            {
                ViewBag.msg = "Not found";
                return View();
            }
        }

        public ActionResult BackToSearchResult()
        {
            if (Session["searchdata"] != null)
            {

                string userid = User.Identity.Name;
                SearchModel model = Session["searchdata"] as SearchModel;
                var list = dc.Vehicles.Where((v) => v.UserID != userid && v.City == model.City && v.VehicleCategory == model.Category).ToList();
                if (list.Count > 0)
                {
                    return View("searchresult", list);
                }
                else
                {
                    ViewBag.msg = "Not found";
                    return View();
                }
            }
            ViewBag.msg = "Not found";
            return View("SearchVehicle");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "User");
        }

       
        public ActionResult Messages(string vid)
        {
            Session["vid"] = vid;
            return View();
        }
        [HttpPost]
        public ActionResult Messages(MessagesModel model)
        {

            model.UserID = User.Identity.Name;
            model.VehicleID = Session["vid"].ToString();
           
            
                dc.messages.Add(model);

                dc.SaveChanges();



                ViewBag.msg = "SendMessageSuccessfully";
            


            return View();
        }

        public ActionResult wishlist(string vid)
        {
            int count = dc.wishlist.Where((e) => e.VehicleID == vid && e.UserID == User.Identity.Name).Count();
            if (count > 0)
            {
                ViewBag.msg = "Already in the wishlist";
                return View("wishlistadded");
            }
            else
            {
                wishlistmodel model = new Models.wishlistmodel();
                model.UserID = User.Identity.Name;
                model.VehicleID = vid;
                dc.wishlist.Add(model);
                dc.SaveChanges();

                ViewBag.msg = "Successfully Added";
                return View("wishlistadded");
            }
        }
        

        public ActionResult ViewMyWishlist()
        {
            string userid = User.Identity.Name;

            var list =
                dc.Vehicles.Join(dc.wishlist, v => v.VehicleID, w => w.VehicleID, (v, w) => new {v,w }).Where((x)=>x.w.UserID==User.Identity.Name).ToList();
           
            return View(list.Select((x)=>x.v).ToList());
        }


        public ActionResult viewdetails(string uid)
        {
           // string userid = User.Identity.Name;
            var obj = dc.NewUsers.Where((e) => e.UserID== uid).FirstOrDefault();
            
                return View(obj);
            
           
            }
        public ActionResult Removeitem(string vid)
        {
            var obj = dc.wishlist.Where((e) => e.VehicleID == vid).FirstOrDefault();

            dc.wishlist.Remove(obj);
            dc.SaveChanges();
            ViewBag.msg = "item remove succefully";
            return View();
        }

        }
    }







