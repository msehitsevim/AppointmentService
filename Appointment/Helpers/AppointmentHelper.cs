using Appointment.Context;
using Appointment.Models;
using Appointment.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appointment.Helpers
{
    public class AppointmentHelper
    {
        private readonly EsteContext _context;
        public AppointmentHelper(EsteContext context)
        {
            _context = context;
        }
        public void UpdateValidate(PatientControlModel patientControlModel)
        {
            if (patientControlModel.patientModel != null)
            {
                _context.PatientModel.Update(patientControlModel.patientModel);
            }
            if (patientControlModel.appointmentModel != null)
            {
                patientControlModel.appointmentModel.ForEach(f =>
                {
                    _context.AppointmentModel.Attach(f).State = EntityState.Modified;

                });
            }
            _context.SaveChanges();
        }

        public string DeleteAppointment(Guid Id)
        {
            var patientId = _context.AppointmentModel.Find(Id).PatientId;
            var identityNumber = _context.PatientModel.Where(w => w.Id == patientId).FirstOrDefault().IdentityNumber;
            var deletedAppointment = _context.AppointmentModel.Remove(_context.AppointmentModel.Find(Id));
            _context.SaveChanges();
            return identityNumber;
        }

        public AddAppointmentModel AddAppointment(Guid Id)
        {
            var docList = _context.DoctorModel.ToList();
            var medicalServicesList = _context.MedicalServicesModel.ToList();
            var patient = _context.PatientModel.Where(w => w.Id == Id).FirstOrDefault();
            AddAppointmentModel addAppointmentModel = new();
            addAppointmentModel.patientModel = patient;
            addAppointmentModel.doctorsModel = docList;
            addAppointmentModel.medicalServicesModel = medicalServicesList;
            return addAppointmentModel;
        }
        public PatientControlModel PatientControl(string IdentityNumber)
        {
         
            PatientControlModel patientControl = new();
            if (!string.IsNullOrEmpty(IdentityNumber))
            {
                PatientModel Patient = new();

                List<AppointmentModel> PatientAppointment = new();
              

                Patient = _context.PatientModel.Where(w => w.IdentityNumber == IdentityNumber).FirstOrDefault();

                if (Patient != null)
                {
                    PatientAppointment = _context.AppointmentModel.Where(w => w.PatientId == Patient.Id).ToList();
                    patientControl.appointmentModel = PatientAppointment;
                    patientControl.patientModel = Patient;

                 
                }
            }
            return patientControl;
        }
    }
}
