using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Statistics.Shared;

namespace Statistics.Server.Models
{
    public interface IExerciseRepository
    {
        IEnumerable<Exercise> Exercises { get; }
        void AddExercise(Exercise exercise);
        int UpdateExercise(Exercise exercise);
        bool IsAlreadyInTable(Exercise exercise);
    }
}
