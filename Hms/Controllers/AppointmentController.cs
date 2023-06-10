using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hms.Models;

namespace Hms.Controllers
{
    public class AppointmentController : Controller
    {
        // GET: Appointment
        // 1. *************RETRIEVE ALL Appointment DETAILS ******************
        

        public ActionResult Index()
        {
            AppointmentDbHandle dbhandle = new AppointmentDbHandle();
            ModelState.Clear();
            return View(dbhandle.GetAppointment());

        }

        

        // GET: Appointment/Create
        //******************Add new Appointment

        public ActionResult Create()
        {
            return View();
        }

        // POST: Appointment/Create
        [HttpPost]
        public ActionResult Create(Appointment amodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    AppointmentDbHandle adb = new AppointmentDbHandle();
                    if (adb.AddAppointment(amodel))
                    {
                        ViewBag.Message = "Appointment Details Added Successfully";
                        ModelState.Clear();
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }


        // GET: Appointment/Edit/5
       
        // 3. ************* EDIT Appointment DETAILS ******************
        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            AppointmentDbHandle adb = new AppointmentDbHandle();
            return View(adb.GetAppointment().Find(amodel => amodel.Pid == id));
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Appointment amodel)
        {
            try
            {
                AppointmentDbHandle adb = new AppointmentDbHandle();
                adb.UpdateDetails(amodel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Appointment/Delete/5

        public ActionResult Delete(int id)
        {
           
            try
            {
                AppointmentDbHandle adb = new AppointmentDbHandle();
                if (adb.DeleteAppointment(id))
                {
                    ViewBag.AlertMsg = "Appointment Deleted Successfully";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
