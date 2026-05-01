namespace TrainingPlannerAPI.Models
{
    public class Ejercicio
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }  
        public int Series {  get; set; }
        public int Repeticiones { get; set; }
        public int RutinaId { get; set; }
        public Rutina? Rutina { get; set; }

    }
}
