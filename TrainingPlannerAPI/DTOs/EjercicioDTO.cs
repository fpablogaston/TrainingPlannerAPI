using System.ComponentModel.DataAnnotations;

namespace TrainingPlannerAPI.DTOs
{
    public class EjercicioDTO
    {
        [Required]
        public string Nombre { get; set; } = string.Empty;

        [Range(1, int.MaxValue)]
        public int Series { get; set; }

        [Range(1, int.MaxValue)]
        public int Repeticiones { get; set; }

    }
}
