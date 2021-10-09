using Appointment.Context;
using Appointment.Helpers;
using Appointment.Models;
using Appointment.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Appointment.Controllers
{
    public class HomeController : Controller
    {

        private readonly EsteContext _context;
        private readonly AppointmentHelper _appointmentHelper;
        public HomeController(EsteContext context)
        {
            _context = context;
            _appointmentHelper = new AppointmentHelper(_context);
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult PatientControl(string IdentityNumber)
        {

            if (string.IsNullOrEmpty(IdentityNumber))
            { 
                return RedirectToAction("Index");
            }

            var patientControl = _appointmentHelper.PatientControl(IdentityNumber);
            if (patientControl != null)
            {
                return View(patientControl);
            }
            else
            {
                return RedirectToAction("SavePatient");
            }

        }
        [HttpPost]
        public IActionResult PatientControl(PatientControlModel patientControlModel)
        {
            _appointmentHelper.UpdateValidate(patientControlModel);
            return View(patientControlModel);
        }
        [HttpGet]
        public IActionResult DeleteAppointment(Guid Id)
        {

            var identityNumber = _appointmentHelper.DeleteAppointment(Id);
            return RedirectToAction("PatientControl", new { IdentityNumber = identityNumber });
        }
        public IActionResult SavePatient()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddAppointment(Guid Id)
        {
            var addAppointmentModel = _appointmentHelper.AddAppointment(Id);
            return View(addAppointmentModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
