using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using textila.shared;
using Textila.BL;

namespace Textila.Web.WebApi
{
    public class BlendController : ApiController
    {
        BL_Manager BL = new BL_Manager();
        // GET api/<controller>
        public IEnumerable<BlendEntity> Get(string search=null)
        {
            return BL.getAllBlends(search);
        }

        // GET api/<controller>/5
        public BlendEntity Get(int id)
        {
            return BL.getBlendById(id);
        }

        // POST api/<controller>
        public bool Post([FromBody]BlendEntity value)
        {
           return BL.saveBlend(value);
        }

        // PUT api/<controller>/5
        public bool Put(int id, [FromBody]BlendEntity value)
        {
          return  BL.updateBlend(id, value);
        }

        // DELETE api/<controller>/5
        public void Delete(BlendEntity value)
        {
           // BL.deleteCount(value);
        }
    }
}