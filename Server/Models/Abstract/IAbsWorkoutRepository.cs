using System.Linq;
using Statistics.Shared;
using static Statistics.Client.Utilities.RequestStatus;

namespace Statistics.Server.Models.Abstract
{
    public interface IAbsWorkoutRepository
    {
        IQueryable<AbsWorkout> AbsWorkouts { get; }
        Status AddAbsWorkout(AbsWorkout absWorkout);
        bool IsAlreadyInTable(AbsWorkout absWorkout);
    }
}