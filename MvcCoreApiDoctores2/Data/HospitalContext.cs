using ApiCrudDoctores2.Models;
using Microsoft.EntityFrameworkCore;
using MvcCoreApiDoctores2.Models;

namespace MvcCoreApiDoctores2.Data
{
    public class HospitalContext: DbContext
    {
        public HospitalContext(DbContextOptions<HospitalContext> options): base(options) { }

        public DbSet<Doctor> Doctores { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
