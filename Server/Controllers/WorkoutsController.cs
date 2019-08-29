using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Statistics.Server.Models;
using Statistics.Server.Models.Abstract;
using Statistics.Shared;
using static Statistics.Client.Utilities.RequestStatus;

namespace Statistics.Server.Controllers
{
    [Route("api/[controller]")]
    public class WorkoutsController : Controller
    {
        private readonly IWorkoutRepository _repository;

        public WorkoutsController(IWorkoutRepository repository)
        {
            this._repository = repository;
        }

        [HttpGet]
        public IQueryable<Workout> Get()
        {
            return _repository.Workouts;
        }
        

        [HttpPost]
        public ActionResult<Status> Post([FromBody] Workout workout)
        {
            return !_repository.IsAlreadyInTable(workout)
                ? _repository.AddWorkout(workout)
                : _repository.UpdateWorkout(workout);
        }
        

        [HttpGet("count")]
        public int GetCount()
        {
            return _repository.Workouts.Count();
        }
    }
}