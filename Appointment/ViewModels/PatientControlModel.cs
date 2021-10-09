using Appointment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appointment.ViewModels
{
    public class PatientControlModel
    {
        public PatientModel patientModel { get; set; }
        public List<AppointmentModel> appointmentModel { get; set; }
    }
}
