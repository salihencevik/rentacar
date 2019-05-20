using RentACar.Entity;
using RentACar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentACar.Controllers
{
    public class HomeController : Controller
    {
        RentACarEntities db = new RentACarEntities();

        public ActionResult Index()
        {
            var carlist = db.Cars.ToList();
            return View(carlist);
        }
        public ActionResult Default()
        {
            return View();
        }
        public ActionResult CarDetailt(int Id)
        {
            ViewBag.Cars = db.Cars.ToList();
            var cardetail = db.Cars.FirstOrDefault(f => f.Id == Id);
            return View(cardetail);
        }

        public JsonResult TenantCreate(TenantBlog entity)
        {

            Users users = new Users();
            users.Name = entity.Name;
            users.SurName = entity.SurName;
            users.Email = entity.Email;
            users.TelNumber = entity.TelNumber;
            users.RolesId = 1;
            users.Password = "123";
            var useritem = db.Users.Add(users);
            db.SaveChanges();

            Tenant tn = new Tenant();
            tn.UsersId = useritem.Id;
            foreach (var itemId in db.Cars)
            {
                tn.CarsId = itemId.Id;
            }
            tn.BuyDate = entity.BuyDate;
            tn.ReturnDate = entity.ReturnDate;
            tn.DayCount = entity.DayCount;
            tn.BuyAdress = entity.BuyAdress;
            tn.ReturnAdress = entity.ReturnAdress;
            var item = db.Tenant.Add(tn);

            db.SaveChanges();

            return Json("", JsonRequestBehavior.AllowGet);
        }
    }
}