using System.Collections.Generic;
using System.Linq;
using Statistics.Shared;

namespace Statistics.Server.Models
{
    public class ExerciseRepository : IExerciseRepository
    {
        private ApplicationDbContext context { get; }
        public IEnumerable<Exercise> Exercises => context.Exercises;

        public ExerciseRepository(ApplicationDbContext context) => this.context = context;

        public void AddExercise(Exercise exercise)
        {
            context.Exercises.Add(exercise);
            var res = context.SaveChanges();
        }

        public bool IsAlreadyInTable(Exercise exercise)
        {
            var isAlreadySubmitted = context.Exercises.Any(x => x.SubmitDate == exercise.SubmitDate && x.Name == exercise.Name);
            return isAlreadySubmitted;
        }

        public int UpdateExercise(Exercise exercise)
        {
            var initialRow = context.Exercises.SingleOrDefault(x => 
                x.SubmitDate == exercise.SubmitDate &&
                x.Name == exercise.Name);

            initialRow.DayOfWeek = exercise.DayOfWeek;
            initialRow.Name = exercise.Name;
            initialRow.Phase = exercise.Phase;
            initialRow.Weight = exercise.Weight;
            initialRow.Repetitions = exercise.Repetitions;
            initialRow.ShouldAddWeight = exercise.ShouldAddWeight;
                        
            return context.SaveChanges();
        }

    }
}
