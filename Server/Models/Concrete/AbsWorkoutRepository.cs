using System.Linq;
using Statistics.Server.Models.Abstract;
using Statistics.Shared;
using static Statistics.Client.Utilities.RequestStatus;

namespace Statistics.Server.Models.Concrete
{
    //todo:add update capabilities to consistency with workout management workflow
    public class AbsWorkoutRepository : IAbsWorkoutRepository
    {
        private readonly ApplicationDbContext _context;

        public AbsWorkoutRepository(ApplicationDbContext context) => _context = context;

        public IQueryable<AbsWorkout> AbsWorkouts => _context.AbsWorkouts;

        public Status AddAbsWorkout(AbsWorkout absWorkout)
        {
            _context.AbsWorkouts.Add(absWorkout);
            return _context.SaveChanges() == 0 ? Status.Error : Status.Created;
        }

        public bool IsAlreadyInTable(AbsWorkout absWorkout)
        {
            var isAlreadySubmitted =
                _context.AbsWorkouts.Any(x => x.SubmitDate == absWorkout.SubmitDate);
            return isAlreadySubmitted;
        }
    }
}