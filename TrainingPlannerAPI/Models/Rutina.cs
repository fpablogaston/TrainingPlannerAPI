namespace TrainingPlannerAPI.Models
{
    public class Rutina
    {
        public int Id { get; set; }
        public string? NombreAlumno { get; set; }
        public List<Ejercicio>? Ejercicios { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

    }
}
