using RentACar.Entity;
using RentACar.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentACar.Controllers
{
    public class AdminController : Controller
    {
        RentACarEntities db = new RentACarEntities();


     






           
        #region CarCrud

        // GET: Admin
        public ActionResult Index()
        {
            var result = db.Cars.ToList();
            return View(result);
        }
        public JsonResult Create(CarBlog entity)
        {

            Cars Cr = new Cars();
            Cr.Id = entity.Id;
            Cr.Brand = entity.Brand;
            Cr.Model = entity.Model;
            Cr.MaksSpeed = entity.MaksSpeed;
            Cr.Gear = entity.Gear;
            Cr.image = entity.image;
            Cr.TenantScore = entity.TenantScore;
            Cr.explanation = entity.explanation;

            if (Request.Files.Count > 0)
            {
                var file = Request.Files["cvfile"];

                if (file != null && file.ContentLength > 0)
                {
                    string rootPath = Server.MapPath("~");

                    var fileName = Path.GetFileName(file.FileName);
                    string filepath = "Carimage/" + fileName;
                    string fileUrl = Path.Combine(rootPath + "Carimage");
                    if (!Directory.Exists(fileUrl))
                        Directory.CreateDirectory(fileUrl);

                    string sourcePath = Path.GetFullPath(fileUrl + "/" + fileName);

                    file.SaveAs(sourcePath);
                    Cr.image = fileName;
                }
            }
            var item = db.Cars.Add(Cr);
            db.SaveChanges();

            var Cars = db.Cars.FirstOrDefault(c => c.Id == item.Id);
            Cars result = new Cars();
            result.Id = Cars.Id;
            result.Brand = !string.IsNullOrEmpty(Cars.Brand) ? Cars.Brand.ToUpper() : "";
            result.Model = !string.IsNullOrEmpty(Cars.Model) ? Cars.Model.ToUpper():"";
            result.Gear = Cars.Gear;
            result.TenantScore = Cars.TenantScore;
            result.image = Cars.image;
            result.MaksSpeed = Cars.MaksSpeed;
            result.explanation = Cars.explanation;

            CarImage crı = new CarImage();
            crı.Id = entity.Id;
            crı.Detailimage = entity.Detailimage;
            crı.CarsId = Cr.Id;

            if (Request.Files.Count > 0)
            {
                var file1 = Request.Files["cvfiles1"];

                if (file1 != null && file1.ContentLength > 0)
                {
                    string rootPath = Server.MapPath("~");

                    var fileName = Path.GetFileName(file1.FileName);
                    string filepath = "Detailimage/" + fileName;
                    string fileUrl = Path.Combine(rootPath + "Detailimage");
                    if (!Directory.Exists(fileUrl))
                        Directory.CreateDirectory(fileUrl);

                    string sourcePath = Path.GetFullPath(fileUrl + "/" + fileName);

                    file1.SaveAs(sourcePath);
                    crı.Detailimage = fileName;
                }
            }
            if (Request.Files.Count > 0)
            {
                var file2 = Request.Files["cvfiles2"];

                if (file2 != null && file2.ContentLength > 0)
                {
                    string rootPath = Server.MapPath("~");

                    var fileName = Path.GetFileName(file2.FileName);
                    string filepath = "Detailimage/" + fileName;
                    string fileUrl = Path.Combine(rootPath + "Detailimage");
                    if (!Directory.Exists(fileUrl))
                        Directory.CreateDirectory(fileUrl);

                    string sourcePath = Path.GetFullPath(fileUrl + "/" + fileName);

                    file2.SaveAs(sourcePath);
                    crı.Detailimage = fileName;
                }
            }
            if (Request.Files.Count > 0)
            {
                var file3 = Request.Files["cvfiles3"];

                if (file3 != null && file3.ContentLength > 0)
                {
                    string rootPath = Server.MapPath("~");

                    var fileName = Path.GetFileName(file3.FileName);
                    string filepath = "Detailimage/" + fileName;
                    string fileUrl = Path.Combine(rootPath + "Detailimage");
                    if (!Directory.Exists(fileUrl))
                        Directory.CreateDirectory(fileUrl);

                    string sourcePath = Path.GetFullPath(fileUrl + "/" + fileName);

                    file3.SaveAs(sourcePath);
                    crı.Detailimage = fileName;
                }
            }
            var detailImage = db.CarImage.Add(crı);
            db.SaveChanges();
            return Json("", JsonRequestBehavior.AllowGet);
        }


        public ActionResult Edit(int Id)
        {
            Cars cs = db.Cars.Find(Id);
            return View(cs);
        }

        public ActionResult EditBlog(CarBlog entity)
        {
            Cars cg = db.Cars.Find(entity.Id);
            cg.Id = entity.Id;
            cg.Brand = entity.Brand;
            cg.Model = entity.Model;
            cg.Gear = entity.Gear;
            cg.explanation = entity.explanation;
            cg.image = entity.image;
            cg.MaksSpeed = entity.MaksSpeed;
            cg.TenantScore = entity.TenantScore;
            if (Request.Files.Count > 0)
            {
                var file = Request.Files["cvfile4"];

                if (file != null && file.ContentLength > 0)
                {
                    string rootPath = Server.MapPath("~");

                    var fileName = Path.GetFileName(file.FileName);
                    string filepath = "Carimage/" + fileName;
                    string fileUrl = Path.Combine(rootPath + "Carimage");
                    if (!Directory.Exists(fileUrl))
                        Directory.CreateDirectory(fileUrl);

                    string sourcePath = Path.GetFullPath(fileUrl + "/" + fileName);

                    file.SaveAs(sourcePath);
                    cg.image = fileName;
                }
            }
            db.Entry(cg).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public JsonResult Delete(int Id)
        {
            int number = 0;
            Cars ca = db.Cars.Find(Id);
            if (ca != null)
            {
                db.Cars.Remove(ca);
                db.SaveChanges();
                number = 1;
            }
            return Json(number, JsonRequestBehavior.AllowGet);
        }

        public JsonResult MovieSearch(CarBlog entity)
        {
            var result = db.Cars.ToList();

            if (!string.IsNullOrEmpty(entity.Brand))
            {
                entity.Brand = entity.Brand.ToUpper();
                result = result.Where(c => c.Brand.Contains(entity.Brand)).ToList();
            }
            if (entity.Gear != null && entity.Gear != null)
            {
                result = result.Where(c => c.Gear == entity.Gear).ToList();
            }
            var list1 = result.Select(c => new Cars
            {
                Id = c.Id,
                Brand = c.Brand,
                Gear = c.Gear,
                Model = c.Model,
            }).ToList();


            return Json(list1, JsonRequestBehavior.AllowGet);
        }
        #endregion



        public ActionResult Default()
        {
            ViewBag.Cars = db.Cars.ToList();
            ViewBag.Roles = db.Roles.ToList();
            var result = db.Tenant.ToList();
            return View();
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
            tn.IsApprove = true;
            var item = db.Tenant.Add(tn);

            db.SaveChanges();

            return Json("", JsonRequestBehavior.AllowGet);
        }
    }
}