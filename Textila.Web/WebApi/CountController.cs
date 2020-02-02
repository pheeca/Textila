using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Textila.BL;
using Textila.Shared;

namespace Textila.Web.WebApi
{
    public class CountController : ApiController
    {

        BL_Manager BL = new BL_Manager();

        // GET api/<controller>
        public IEnumerable<CountEntity> Get()
        {
            return BL.getAllCounts();
        }

        // GET api/<controller>/5
        public CountEntity Get(int id)
        {
            return BL.getCountById(id);
        }

        // POST api/<controller>
        public void Post([FromBody]CountEntity value)
        {
            BL.saveCount(value);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]CountEntity value)
        {
            BL.updateCount(id, value);
        }

        // DELETE api/<controller>/5
        public void Delete(CountEntity value)
        {
            BL.deleteCount(value);
        }
    }
}