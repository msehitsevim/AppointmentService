using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appointment.ViewModels
{
    public class AppointmentRecord
    {
        public Guid PatientId { get; set; }
        public string AppointmentDate { get; set; }
        public string BeginTime { get; set; }
        public string EndTime { get; set; }
        public List<string> ServicesList { get; set; }

    }
}
