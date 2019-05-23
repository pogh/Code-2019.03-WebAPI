using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        readonly IPeople _people;

        public ValuesController(IPeople people)
        {
            _people = people;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
            return JsonConvert.SerializeObject(_people.EveryOne);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            try
            {
                return JsonConvert.SerializeObject(
                    _people.EveryOne.Where(x => x.Id == id
                    ));
            }
            catch
            {
                return new NotFoundResult();
            }
        }

        /*
        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}
