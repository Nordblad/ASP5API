using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using ASP5API.Models;

namespace ASP5API.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        //Dependency injection!
        //https://davidzych.com/dependency-injection-in-asp-net-vnext/

        private DataEventRecordContext _context;

        public ValuesController(DataEventRecordContext context)
        {
            _context = context;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<DataEventRecord> Get()
        {
            //DataEventRecordContext db = new DataEventRecordContext();
            //_context.DataEventRecords.Add(new DataEventRecord { Description = "Nummer tre!", Id = 3, Name = "Trean!", Timestamp = DateTime.Now });
            //_context.DataEventRecords.Add(new DataEventRecord { Description = "Beskrivning", Id = 4, Name = "FOR REALS!", Timestamp = DateTime.Now.AddDays(-1) });
            //_context.SaveChanges();
            return _context.DataEventRecords.ToList();
            //return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public DataEventRecord Get(int id)
        {
            return _context.DataEventRecords.Where(d => d.Id == id).FirstOrDefault();
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
    }
}
