using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainingPlannerAPI.Data;
using TrainingPlannerAPI.DTOs;
using TrainingPlannerAPI.Models;

namespace TrainingPlannerAPI.Controllers
    {
        [Authorize]
        [ApiController]
        [Route("api/[controller]")]
        public class RutinasController : ControllerBase
        {

        private readonly AppDbContext _context;
        public RutinasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
            public IActionResult Get()
            {
            var rutinas = _context.Rutinas
                .Include(r => r.Ejercicios)
                .Select(r => new RutinaResponseDTO
                {
                    Id = r.Id,
                    NombreAlumno = r.NombreAlumno,  
                    Ejercicios = r.Ejercicios.Select(e => new EjercicioDTO
                    {
                        Nombre = e.Nombre,
                        Series = e.Series,
                        Repeticiones = e.Repeticiones
                    }).ToList()
                })
                .ToList();

            return Ok(rutinas);
            }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var rutina = _context.Rutinas
                .Include(r => r.Ejercicios)
                .FirstOrDefault(r => r.Id == id);

            if (rutina == null)
                return NotFound();

            return Ok(new RutinaResponseDTO
            {
                Id = rutina.Id,
                NombreAlumno = rutina?.NombreAlumno,
                Ejercicios = rutina?.Ejercicios?.Select(e => new EjercicioDTO
                {
                    Nombre = e.Nombre,
                    Series = e.Series,
                    Repeticiones = e.Repeticiones,
                }).ToList()
            });
        }

        [HttpPost]
            public IActionResult Post(RutinaCreateDTO dto)
            {
            var rutina = new Rutina 
            {
                NombreAlumno = dto.NombreAlumno,
                Ejercicios = dto?.Ejercicios?.Select(e => new Ejercicio
                {
                    Nombre = e.Nombre,
                    Series = e.Series,
                    Repeticiones = e.Repeticiones
                }).ToList()
            };
            try
            {
                _context.Rutinas.Add(rutina);
                _context.SaveChanges();

            }
            catch (Exception)
            {
                return StatusCode(500, "Ocurrio un error inesperado");
            }

            return Ok(new RutinaResponseDTO
                {
                    Id = rutina.Id,
                    NombreAlumno = rutina.NombreAlumno,
                    Ejercicios = rutina?.Ejercicios?.Select(e => new EjercicioDTO
                    {
                        Nombre = e.Nombre,
                        Series = e.Series,
                        Repeticiones= e.Repeticiones
                    }).ToList(),
                });
            }


        [HttpPut("{id}")]
        // Cambiarlo por:
        public IActionResult Put(int id, RutinaCreateDTO dto)
        {
            var rutinaExistente = _context.Rutinas
                .Include(r => r.Ejercicios)
                .FirstOrDefault(r => r.Id == id);

            if (rutinaExistente == null)
                return NotFound();

            rutinaExistente.NombreAlumno = dto.NombreAlumno;

            rutinaExistente.Ejercicios = dto.Ejercicios?.Select(e => new Ejercicio
            {
                Nombre = e.Nombre,
                Series = e.Series,
                Repeticiones = e.Repeticiones,
                RutinaId = rutinaExistente.Id
            }).ToList();

            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocurrio un error inesperado");
            }

            return Ok(new RutinaResponseDTO
            {
                Id = rutinaExistente.Id,
                NombreAlumno = rutinaExistente.NombreAlumno,
                Ejercicios = rutinaExistente.Ejercicios?.Select(e => new EjercicioDTO
                {
                    Nombre = e.Nombre,
                    Series = e.Series,
                    Repeticiones= e.Repeticiones,
                }).ToList()
            });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var rutina = _context.Rutinas
                .Include(r => r.Ejercicios)
                .FirstOrDefault(r => r.Id == id);

            if (rutina == null)
                return NotFound();

            try
            {
                _context.Rutinas.Remove(rutina);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocurrio un error inesperado");
            }

            return Ok();
        }
       } 
    }

