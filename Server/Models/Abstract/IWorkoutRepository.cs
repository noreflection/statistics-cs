using System.Linq;
using Statistics.Shared;
using static Statistics.Client.Utilities.RequestStatus;

namespace Statistics.Server.Models.Abstract
{
    public interface IWorkoutRepository
    {
        IQueryable<Workout> Workouts { get; }
        Status AddWorkout(Workout workout);
        Status UpdateWorkout(Workout workout);
        bool IsAlreadyInTable(Workout workout);
    }
}