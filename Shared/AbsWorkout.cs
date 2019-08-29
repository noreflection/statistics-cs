using System;

namespace Statistics.Shared
{
    public class AbsWorkout
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string DayOfWeek { get; set; }
        public DateTime SubmitDate { get; set; }
        public string Evaluation { get; set; }
        public string AbsType { get; set; }
    }
}