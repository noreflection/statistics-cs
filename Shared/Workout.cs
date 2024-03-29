﻿using System;
using System.Collections.Generic;

namespace Statistics.Shared
{
    public class Workout
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<Exercise> Exercises { get; set; }

        public string DayOfWeek { get; set; }
        public string Phase { get; set; }
        public DateTime SubmitDate { get; set; }
        public string Evaluation { get; set; }
    }
}