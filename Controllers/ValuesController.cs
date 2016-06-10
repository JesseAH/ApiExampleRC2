using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ApiExampleRC2.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


        /// <summary>
        /// New example api endpoint that returns a int.
        /// </summary>
        /// <remarks>Pass in a int and this method will add 10 to it and then return it.</remarks>
        /// <param name="valueA"></param>
        /// <returns></returns>
        [HttpGet("ExampleGet/{valueA:int}")]    //inline constraints - route matching does NOT happen if valueA is not a int.
        [Produces(typeof(int))]                 //adds model and schema to swaggerm very helpful for passing around objects. 
        [Consumes("application/json")]          //Tell this action to only accecpt json objects
        public IActionResult ExampleGet(int valueA)
        {
            try
            {
                valueA = valueA + 10;
                return this.Ok(valueA);
            }
            catch (Exception)
            {
                return this.BadRequest("Fail!");
            }
        }
    }
}
