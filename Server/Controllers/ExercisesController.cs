using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Statistics.Server.Models;
using Statistics.Shared;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Statistics.Server.Controllers
{
    [Route("api/[controller]")]
    public class ExercisesController : Controller
    {
        private readonly IExerciseRepository repository;

        public ExercisesController(IExerciseRepository repository)
        {
            this.repository = repository;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Exercise> Get()
        {
            return this.repository.Exercises;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            Debug.WriteLine("fuck");
            return "value";
        }

        [HttpPost]
        //public void Post([FromBody]string value)
        public ActionResult<int> Post([FromBody]Exercise exercise)
        {
            if (!repository.IsAlreadyInTable(exercise))
            {
                repository.AddExercise(exercise);
                return 1;                
            }

            var queryUpdateResult = repository.UpdateExercise(exercise);
            if (queryUpdateResult == 1) 
            {
                return 2;
            }

            return 0;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
