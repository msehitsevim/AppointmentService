using Appointment.Context;
using Appointment.Models;
using Appointment.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appointment.Api
{
    [Route("api")]
    [ApiController]
    public class EsteApi : ControllerBase
    {
        private readonly EsteContext _context;
        public EsteApi(EsteContext context)
        {
            _context = context;
        }

        [Route("AddApp")]
        public string AddApp(AppointmentRecord appointmentRecord)
        {
            AppointmentModel appointment = new();
            appointment.PatientId = appointmentRecord.PatientId;
            appointment.BeginTime = Convert.ToDateTime(appointmentRecord.BeginTime);
            appointment.EndTime = Convert.ToDateTime(appointmentRecord.EndTime);
            appointment.AppointmentDate = Convert.ToDateTime(appointmentRecord.AppointmentDate);
            foreach (var item in appointmentRecord.ServicesList)
            {
                appointment.MedicalServicesId += item + ",";
            }

            _context.AppointmentModel.Add(appointment);
            _context.SaveChanges();

            var IdentityNumber = _context.PatientModel.Where(w => w.Id == appointmentRecord.PatientId).Select(s => s.IdentityNumber).FirstOrDefault();

            return IdentityNumber;

        }

        [Route("Record")]
        public string Record(PatientModel patientModel)
        {
           
                _context.PatientModel.Add(patientModel);
                _context.SaveChanges();
          

            return patientModel.IdentityNumber;

        }

        //[Route("UpdatePatient")]
        //public string UpdatePatient(PatientModel patientModel)
        //{
        //    PatientModel checkRecord = new();
        //    checkRecord = _context.PatientModel.Find(patientModel.Id);

        //    checkRecord.IdentityNumber = patientModel.IdentityNumber;
        //    checkRecord.Name = patientModel.Name;
        //    checkRecord.Surname = patientModel.Surname;
        //    checkRecord.Age = patientModel.Age;
        //    checkRecord.Address = patientModel.Address;
        //    checkRecord.Telephone = patientModel.Telephone;


        //    _context.SaveChanges();
       
         
        //    return patientModel.IdentityNumber;
        //}

        //[Route("UpdateAppointment")]
        //public string UpdateAppointment(AppointmentModel appointmentModel) {

        //    AppointmentModel checkAppointment = new();
        //    checkAppointment = _context.AppointmentModel.Find(appointmentModel.Id);

        //    checkAppointment.MedicalServicesId = appointmentModel.MedicalServicesId;
        //    checkAppointment.EndTime = appointmentModel.EndTime;
        //    checkAppointment.BeginTime = appointmentModel.BeginTime;
        //    checkAppointment.AppointmentDate = appointmentModel.AppointmentDate;
            
        //    _context.SaveChanges();

        //    var IdentityNumber = _context.PatientModel.Where(w => w.Id == appointmentModel.PatientId).Select(s => s.IdentityNumber).FirstOrDefault();

        //    string url = "/Home/PatientControl?IdentityNumber="+ IdentityNumber;

        //    return url;
        //}
        //[Route("AddServiceList")]
        //public void AddServices(List<MedicalServicesModel> serviceModel)
        //{
        //    _context.AddRange(serviceModel);
        //    _context.SaveChanges();

        //}

        //[Route("GetPatients")]
        //public PatientModel GetPatients(string IdentityNumber)
        //{
        //    return _context.PatientModel
        //        .Where(w => w.IdentityNumber == IdentityNumber)
        //        .First();
        //}
        //[Route("GetPatientDetail")]
        //public PatientModel GetPatientDetail(Guid Id)
        //{
        //    return _context.PatientModel.Find(Id);
        //}

    }
}
