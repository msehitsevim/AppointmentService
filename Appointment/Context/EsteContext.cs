using Appointment.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appointment.Context
{
    public class EsteContext : DbContext
    {
        public EsteContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<AppointmentModel> AppointmentModel { get; set; }
        public DbSet<DoctorsModel> DoctorModel { get; set; }
        public DbSet<PatientModel> PatientModel { get; set; }
        public DbSet<MedicalServicesModel> MedicalServicesModel { get; set; }

    }
}
