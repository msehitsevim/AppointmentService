using Appointment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appointment.ViewModels
{
    public class AddAppointmentModel
    {

        public PatientModel patientModel { get; set; }
        public AppointmentModel appointmentModel { get; set; }
        public List<MedicalServicesModel> medicalServicesModel { get; set; }
        public List<DoctorsModel> doctorsModel { get; set; }
    }
}
