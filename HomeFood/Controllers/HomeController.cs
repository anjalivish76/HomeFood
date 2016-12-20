using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeFood.Models;
using BusinessLayer;
using System.IO;

namespace HomeFood.Controllers
{
    public class HomeController : Controller
    {
        AreaBusinessLayer areaBusinessLayer = new AreaBusinessLayer();
        CountryBusinessLayer countryBusinessLayer = new CountryBusinessLayer();
        StateBusinessLayer stateBusinessLayer = new StateBusinessLayer();
        CityBusinessLayer cityBusinessLayer = new CityBusinessLayer();

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            if (TempData["result"] != null)
            {
                ViewBag.Result = TempData["result"].ToString();
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult FindRestaurants()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult RegisterRest()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FillState(int countryId)
        {
            var states = stateBusinessLayer.GetStates().Where(c => c.CountryId == countryId);

            return Json(states, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult FillCity(int stateId)
        {
            var cities = cityBusinessLayer.GetCities().Where(c => c.StateId == stateId);
            return Json(cities, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult FillArea(int cityId)
        {
            var areas = areaBusinessLayer.GetAreasList().Where(c => c.CityId == cityId);
            return Json(areas, JsonRequestBehavior.AllowGet);
        }

        //collection for city
        public List<City> GetAllCity()
        {
            List<City> objcity = new List<City>();
            objcity.Add(new City { CityId = 1, StateId = 1, CityName = "City1-1" });
            objcity.Add(new City { CityId = 2, StateId = 2, CityName = "City2-1" });
            objcity.Add(new City { CityId = 3, StateId = 4, CityName = "City4-1" });
            objcity.Add(new City { CityId = 4, StateId = 1, CityName = "City1-2" });
            objcity.Add(new City { CityId = 5, StateId = 1, CityName = "City1-3" });
            objcity.Add(new City { CityId = 6, StateId = 4, CityName = "City4-2" });
            return objcity;
        }

        //Action result for ajax call
        [HttpPost]
        public ActionResult GetCityByStaeId(int stateid)
        {
            List<City> objcity = new List<City>();
            objcity = GetAllCity().Where(m => m.StateId == stateid).ToList();
            SelectList obgcity = new SelectList(objcity, "Id", "CityName", 0);
            return Json(obgcity);
        }

        // Collection for state
        public List<State> GetAllState()
        {
            List<State> objstate = new List<State>();
            objstate.Add(new State { StateId = 0, StateName = "Select State" });
            objstate.Add(new State { StateId = 1, StateName = "State 1" });
            objstate.Add(new State { StateId = 2, StateName = "State 2" });
            objstate.Add(new State { StateId = 3, StateName = "State 3" });
            objstate.Add(new State { StateId = 4, StateName = "State 4" });
            return objstate;
        }

        public ActionResult AddRestaurantNew()
        {

            //List<AreaDetails> lstAreas = areaBusinessLayer.GetAreasList();
            //ViewBag.Areas = new SelectList(lstAreas, "AreaId", "AreaName");

            //List<Country> lstCountries = countryBusinessLayer.GetCountryList();
            //ViewBag.Countries = new SelectList(lstCountries,"CountryId","CountryName");

            CountryModel objcountrymodel = new CountryModel();
            objcountrymodel.StateModel = new List<State>();
            objcountrymodel.StateModel = GetAllState();
            return View(objcountrymodel);

            //return View("AddRestaurantNew");
        }

        public ActionResult AddRestaurantImages(int idRest)
        {
            Restaurant model = new Restaurant();
            model.RestId = idRest;
            return View(model);
        }

        [HttpPost]
        public ActionResult AddRestaurantImages(HttpPostedFileBase MainImagePath, int RestId,HttpPostedFileBase CoverImageFile,HttpPostedFileBase Image1,
                                                HttpPostedFileBase Image2, HttpPostedFileBase Image3, HttpPostedFileBase Image4, HttpPostedFileBase Image5,
                                                HttpPostedFileBase Image6)
        {

            if (MainImagePath != null && MainImagePath.ContentLength > 0)
                try 
                {
                    string path = Path.Combine(Server.MapPath("~/Content/files"),
                    Path.GetFileName(MainImagePath.FileName));
                    MainImagePath.SaveAs(path);
                    
                    string coverimagepath = Path.Combine(Server.MapPath("~/Content/files"),
                    Path.GetFileName(CoverImageFile.FileName));
                    CoverImageFile.SaveAs(coverimagepath);
                    
                    string image1path = Path.Combine(Server.MapPath("~/Content/files"),
                    Path.GetFileName(Image1.FileName));
                    Image1.SaveAs(image1path);

                    string image2path = Path.Combine(Server.MapPath("~/Content/files"),
                    Path.GetFileName(Image2.FileName));
                    Image2.SaveAs(image2path);

                    string image3path = Path.Combine(Server.MapPath("~/Content/files"),
                    Path.GetFileName(Image3.FileName));
                    Image3.SaveAs(image3path);

                    string image4path = Path.Combine(Server.MapPath("~/Content/files"),
                    Path.GetFileName(Image4.FileName));
                    Image4.SaveAs(image4path);

                    string image5path = Path.Combine(Server.MapPath("~/Content/files"),
                    Path.GetFileName(Image5.FileName));
                    Image5.SaveAs(image5path);

                    string image6path = Path.Combine(Server.MapPath("~/Content/files"),
                    Path.GetFileName(Image6.FileName));
                    Image6.SaveAs(image6path);

                    RestaurantBusinessLayer restaurantBusinessLayer = new RestaurantBusinessLayer();
                    Restaurant model = new Restaurant();
                    model.RestId = RestId;
                    model.MainImagePath = Path.GetFileName(MainImagePath.FileName);
                    model.CoverImagePath = Path.GetFileName(CoverImageFile.FileName);

                    model.Image1 = Path.GetFileName(Image1.FileName);
                    model.Image2 = Path.GetFileName(Image2.FileName);
                    model.Image3 = Path.GetFileName(Image3.FileName);
                    model.Image4 = Path.GetFileName(Image4.FileName);
                    model.Image5 = Path.GetFileName(Image5.FileName);
                    model.Image6 = Path.GetFileName(Image6.FileName);

                    restaurantBusinessLayer.AddRestaurantImages(model);
                    return RedirectToAction("RestaurantDetails", "Home", new { idRest = RestId });

                    
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }
            //return View();  
            return RedirectToAction("RestaurantDetails", "Home", new { idRest = RestId });
        }

        public ActionResult AddRestaurant()
        {
            if (Session["UserDisplayName"] != null)
            {
                List<AreaDetails> lstAreas = areaBusinessLayer.GetAreasList();
                ViewBag.Areas = new SelectList(lstAreas, "AreaId", "AreaName");

                List<Country> lstCountries = countryBusinessLayer.GetCountryList();
                ViewBag.Countries = new SelectList(lstCountries, "CountryId", "CountryName");

                //CountryModel objcountrymodel = new CountryModel();
                //objcountrymodel.StateModel = new List<State>();
                //objcountrymodel.StateModel = GetAllState();
                //return View(objcountrymodel);

                IEnumerable<HomeDelivery> HomeDeliveryTypes = Enum.GetValues(typeof(HomeDelivery))
                                                       .Cast<HomeDelivery>();
                //ViewBag.HomeDelivery = from homedelivery in HomeDeliveryTypes
                //                       select new SelectListItem
                //                       {
                //                           Text = homedelivery.ToString(),
                //                           Value = ((int)homedelivery).ToString()
                //                       };

                Restaurant model = new Restaurant();

                model.HomeDeliveryList = from homedelivery in HomeDeliveryTypes
                                    select new SelectListItem
                                    {
                                        Text = homedelivery.ToString(),
                                        Value = ((int)homedelivery).ToString()
                                    };


                return View(model);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddRestaurant(Restaurant model)
        {
            if (Session["UserDisplayName"] != null)
            {
                //model.HomeDelivery = Convert.ToBoolean(model.HomeDelivery);

                
                if (ModelState.IsValid)
                {
                    //try
                    //{
                    RestaurantBusinessLayer restaurantBusinessLayer = new RestaurantBusinessLayer();
                    Restaurant restaurant = new Restaurant();

                    int restId = restaurantBusinessLayer.AddRestaurant(model);
                    return RedirectToAction("AddRestaurantImages", "Home", new { idRest = restId });

                    //}
                    //catch (MembershipCreateUserException e)
                    //{
                    //    ModelState.AddModelError("", ErrorCodeToString(e.StatusCode));
                    //}
                }

                // If we got this far, something failed, redisplay form
                List<Country> lstCountries = countryBusinessLayer.GetCountryList();
                ViewBag.Countries = new SelectList(lstCountries, "CountryId", "CountryName");

                IEnumerable<HomeDelivery> HomeDeliveryTypes = Enum.GetValues(typeof(HomeDelivery))
                                                       .Cast<HomeDelivery>();
                model.HomeDeliveryList = from homedelivery in HomeDeliveryTypes
                                         select new SelectListItem
                                         {
                                             Text = homedelivery.ToString(),
                                             Value = ((int)homedelivery).ToString()
                                         };
                return View(model);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult Search(string AreaName, string CityName, string StateName, string CountryName)
        {
            
            AreaDetails areaDetails = areaBusinessLayer.AreaCoordinates(AreaName, CityName, StateName, CountryName);
            RestaurantBusinessLayer restBusinessLayer = new RestaurantBusinessLayer();
            List<Restaurant> allrestaurants = restBusinessLayer.AllRestaurants();
            List<Restaurant> closerestaurants = new List<Restaurant>();
            foreach (var rest in allrestaurants)
            {
                double distanceinkms = Distance.Calculate(Convert.ToDouble(areaDetails.Latitude), Convert.ToDouble(areaDetails.Longitude), Convert.ToDouble(rest.Latitude), Convert.ToDouble(rest.Longitude));
                if (distanceinkms <= 5)
                {
                    closerestaurants.Add(rest);
                }

            }
            return View(closerestaurants);
        }

        public ActionResult Calculate(string Lat1, string Lang1, string Lat2,string Lang2)
        {
            double FromLatitude = Convert.ToDouble(Lat1);
            double FromLongitude = Convert.ToDouble(Lang1);
            double ToLatitude = Convert.ToDouble(Lat2);
            double ToLongitude = Convert.ToDouble(Lang2);

            TempData["result"] = Distance.Calculate(FromLatitude, FromLongitude, ToLatitude, ToLongitude);

            return RedirectToAction("Index");
        }

        public ActionResult RestaurantDetails(string idRest)
        {
            RestaurantBusinessLayer restBusinessLayer = new RestaurantBusinessLayer();
            Restaurant restDetails = new Restaurant();
            restDetails = restBusinessLayer.GetRestaurantDetails(idRest);
            return View(restDetails);
        }

    }
}
