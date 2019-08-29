using System.Linq;
using Microsoft.EntityFrameworkCore;
using Statistics.Server.Models.Abstract;
using Statistics.Shared;
using static Statistics.Client.Utilities.RequestStatus;

namespace Statistics.Server.Models.Concrete
{
    public class WorkoutRepository : IWorkoutRepository
    {
        private readonly ApplicationDbContext _context;

        public WorkoutRepository(ApplicationDbContext context) => _context = context;

        public IQueryable<Workout> Workouts => 
            _context.Workouts.Include(workout => workout.Exercises);

        public Status AddWorkout(Workout workout)
        {
            _context.Workouts.Add(workout);
            return _context.SaveChanges() == 0 ? Status.Error : Status.Created;
        }
        //todo:include evaluation update
        public Status UpdateWorkout(Workout workout)
        {
            var initialWorkout = _context.Workouts
                .Include(w => w.Exercises)
                .SingleOrDefault(x =>
                x.SubmitDate == workout.SubmitDate);

            var incomingWorkoutExercise = workout?.Exercises?.SingleOrDefault();
            
            var incomingWorkoutExerciseNumber = incomingWorkoutExercise?.Number;
            
            var initialWorkoutExerciseToUpdate = initialWorkout?
                .Exercises
                .SingleOrDefault(x => 
                    x.Number == incomingWorkoutExerciseNumber);

            if (initialWorkoutExerciseToUpdate == null) {
                var exerciseToAdd = new Exercise
                {
                    Name = incomingWorkoutExercise?.Name,
                    Number = incomingWorkoutExercise?.Number,
                    Weight = incomingWorkoutExercise?.Weight,
                    Repetitions = incomingWorkoutExercise?.Repetitions,
                    ShouldAddWeight = incomingWorkoutExercise?.ShouldAddWeight,
                };

                initialWorkout?.Exercises.Add(exerciseToAdd);
                
                return _context.SaveChanges() == 0 ? Status.Error : Status.Created;
            }
            
            initialWorkoutExerciseToUpdate.Name = incomingWorkoutExercise?.Name;
            initialWorkoutExerciseToUpdate.Number = incomingWorkoutExercise?.Number;
            initialWorkoutExerciseToUpdate.Weight = incomingWorkoutExercise?.Weight;
            initialWorkoutExerciseToUpdate.Repetitions = incomingWorkoutExercise?.Repetitions;
            initialWorkoutExerciseToUpdate.ShouldAddWeight = incomingWorkoutExercise?.ShouldAddWeight;
            

            return _context.SaveChanges() == 0 ? Status.Error : Status.Updated;
        }

        public bool IsAlreadyInTable(Workout workout)
        {
            var isAlreadySubmitted =
                _context.Workouts.Any(x => x.SubmitDate == workout.SubmitDate);
            return isAlreadySubmitted;
        }
    }
}