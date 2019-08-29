namespace Statistics.Shared
{
    public class Exercise
    {
        public int Id { get; set; }
        public int UserId { get; set; } 
        public int? Number { get; set; }
        public string Name { get; set; }
        public string Weight { get; set; }
        public string Repetitions { get; set; }
        public string ShouldAddWeight { get; set; }
    }
}