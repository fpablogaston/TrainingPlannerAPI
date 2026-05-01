namespace TrainingPlannerAPI.DTOs
{
    public class RutinaResponseDTO
    {
        public int Id { get; set; }
        public string? NombreAlumno { get; set; }
        public List<EjercicioDTO>? Ejercicios { get; set; }
        
    }
}
