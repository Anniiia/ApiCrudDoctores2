using ApiCrudDoctores2.Helpers;
using ApiCrudDoctores2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MvcClienteApiCrudDoctores2.Models;
using MvcCoreApiDoctores2.Models;
using MvcCoreApiDoctores2.Repositories;
using System.IdentityModel.Tokens.Jwt;

namespace ApiCrudDoctores2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctoresController : ControllerBase
    {
        private RepositoryDoctores repo;


        public DoctoresController(RepositoryDoctores repo) {
            this.repo = repo;

        }

        [HttpPost]
        [Route("[action]")]

        public async Task<ActionResult> InsertUsuario(RegistroModel model)
        {
            await this.repo.RegisterUsuarioAsync(model.Email, model.Password, model.Nombre);

            return Ok();

        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<Doctor>>> GetDoctores()
        {
            return await this.repo.GetDoctoresAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Doctor>> FindDoctor(int id)
        {
            Doctor doc = await this.repo.FindDoctorAsync(id);

            return doc;

        }

        [HttpPost]
        public async Task<ActionResult> PostDoctor(Doctor doctor)
        {
            await this.repo.InsertDoctorAsync(doctor);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDoctor(int id)
        {
            await this.repo.DeleteDoctor(id);

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> PutDoctor(Doctor doctor)
        {
            await this.repo.UpdateDoctorAsync(doctor.IdDoctor, doctor.IdHospital, doctor.Apellido, doctor.Especialidad, doctor.Salario);
            return Ok();
        }

        [HttpGet]
        [Route("[action]")]

        public async Task<ActionResult<List<string>>> GetEspecialidades()
        {
            List<string> especialidades = await this.repo.GetEspecialidadesAsync();

            return especialidades;
        }

        [HttpGet]
        [Route("[action]/{especialidad}")]

        public async Task<ActionResult<List<Doctor>>> GetDoctoresEspecialidad(string especialidad)
        {
            List<Doctor> doctores = await this.repo.GetDoctoresEspecialidadAsync(especialidad);

            return doctores;
        }
    }
}
