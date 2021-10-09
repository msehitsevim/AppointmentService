using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Appointment.Models
{
    public class MedicalServicesModel
    {
        [Key]
        public Guid ID { get; set; }
        public string ServiceName { get; set; }
        public Guid DocId { get; set; }
    }
}
