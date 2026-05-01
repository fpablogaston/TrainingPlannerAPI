using System.ComponentModel.DataAnnotations;

namespace TrainingPlannerAPI.DTOs
{
    public class RutinaCreateDTO
    {
        [Required]
        public string NombreAlumno { get; set; } = string.Empty;

        [Required]
        [MinLength(1)]
        public List<EjercicioDTO> Ejercicios { get; set; } = new List<EjercicioDTO>();
    }
}
