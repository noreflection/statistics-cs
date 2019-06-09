using System;

namespace Statistics.Shared
{
    public class Exercise
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Phase { get; set; }
        public string Weight { get; set; }
        public string Repetitions { get; set; }
        public string ShouldAddWeight { get; set; }
        public DateTime SubmitDate { get; set; }
        public string DayOfWeek { get; set; }
    }
}