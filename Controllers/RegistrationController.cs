using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcvalid.Models;
using System.IO;

namespace mvcvalid.Controllers
{
    public class RegistrationController : Controller
    {
        DatabaseContext _db = new DatabaseContext();
        [HttpGet]
        public ActionResult Registrationform(int A = 0)
        {

            tblregistration obj = new tblregistration();
            if (A > 0)
            {
                var data = (from R in _db.tblregistrations where R.rid == A select R).ToList();
                obj.rid = data[0].rid;
                obj.rname = data[0].rname;
                obj.remail = data[0].remail;
                obj.rpassword = data[0].rpassword;
                obj.rimg = data[0].rimg;
                ViewBag.BT = "Update Data";
            }

            return View(obj);
        }
        [HttpPost]
        public ActionResult InsertUser(tblregistration _reg, HttpPostedFileBase file)
        {
            if (_reg.rid > 0)
            {
                if (file != null)
                {
                    string FN = Path.GetFileName(file.FileName);
                    file.SaveAs(Path.Combine(Server.MapPath("~/PICS/"), FN));
                    System.IO.File.Delete(Server.MapPath(_reg.rimg));
                    _reg.rimg = "~/PICS/" + FN;
                }
                _db.Entry(_reg).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
            }
            else
            {
                string FN = DateTime.Now.Ticks.ToString() + Path.GetFileName(file.FileName);
                file.SaveAs(Path.Combine(Server.MapPath("~/PICS/"), FN));
                _reg.rimg = "~/PICS/" + FN;
                _db.tblregistrations.Add(_reg);
                _db.SaveChanges();

            }

            return RedirectToAction("ShowUser");

        }
        public ActionResult DeleteUser(int A = 0)
        {
            var data = _db.tblregistrations.Find(A);
            System.IO.File.Delete(Server.MapPath(data.rimg));
            _db.tblregistrations.Remove(data);
            _db.SaveChanges();
            return RedirectToAction("ShowUser");
        }
        public ActionResult ShowUser()
        {
            var data = _db.tblregistrations.ToList();
            return View(data);


        }
    }
}