using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Ajf.RideShare.Web.Api
{
    public class DashController : ApiController
        {
        // GET api/<controller>
            public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public StatResult Get(int id)
        {
            return new StatResult()
            {
                Sec = DateTime.Now.Second
            };
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }

    public class StatResult
    {
        public int Sec { get; set; }
    }
}