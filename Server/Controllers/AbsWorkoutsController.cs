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
    public class AbsWorkoutsController : Controller
    {
        private readonly IAbsWorkoutRepository _repository;

        public AbsWorkoutsController(IAbsWorkoutRepository repository)
        {
            this._repository = repository;
        }

        [HttpGet]
        public IQueryable<AbsWorkout> Get()
        {
            return _repository.AbsWorkouts;
        }
        
        [HttpPost]
        public ActionResult<Status> Post([FromBody] AbsWorkout absWorkout)
        {
            return !_repository.IsAlreadyInTable(absWorkout) ? _repository.AddAbsWorkout(absWorkout) : Status.Error;
        }


        [HttpGet("count")]
        public int GetCount()
        {
            return _repository.AbsWorkouts.Count();
        }
    }
}