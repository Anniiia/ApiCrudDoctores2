using Microsoft.EntityFrameworkCore;
using MvcCoreApiDoctores2.Data;
using MvcCoreApiDoctores2.Models;

namespace MvcCoreApiDoctores2.Repositories
{
    public class RepositoryDoctores
    {
        private HospitalContext context;

        public RepositoryDoctores(HospitalContext context)
        {
            this.context = context;
        }

        public async Task<List<Doctor>> GetDoctoresAsync()
        { 
            List<Doctor> doctores = await this.context.Doctores.ToListAsync();

            return doctores;
        }

        public async Task<Doctor> FindDoctorAsync(int idDoctor)
        {
            return await this.context.Doctores.FirstOrDefaultAsync(Z => Z.IdDoctor == idDoctor);
        }
        public async Task InsertDoctorAsync(Doctor doctor)
        { 
            Doctor doc = new Doctor();
            doc.IdHospital = doctor.IdHospital;
            doc.IdDoctor = doctor.IdDoctor;
            doc.Apellido = doctor.Apellido;
            doc.Especialidad = doctor.Especialidad;
            doc.Salario = doctor.Salario;
            this.context.Doctores.Add(doc);
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteDoctor(int idDoctor)
        { 
            Doctor doc = await this.FindDoctorAsync(idDoctor);
            this.context.Doctores.Remove(doc);
            await this.context.SaveChangesAsync();

        }

        public async Task UpdateDoctorAsync(int id, int idhospital, string apellido, string especialidad, int salario)
        {
            Doctor doc = await this.FindDoctorAsync(id);
            doc.IdHospital = idhospital;
            doc.Apellido = apellido;
            doc.Especialidad = especialidad;
            doc.Salario = salario;
            await this.context.SaveChangesAsync();
        }


        public async Task<List<string>> GetEspecialidadesAsync()
        { 
            List<string> especialidades = await this.context.Doctores.Select(x=>x.Especialidad).Distinct().ToListAsync();

            return especialidades;
        }

        public async Task<List<Doctor>> GetDoctoresEspecialidadAsync(string especialidad)
        { 
            List<Doctor> doctores = await this.context.Doctores.Where(x=>x.Especialidad==especialidad).ToListAsync();

            return doctores;
        }
    }
}
