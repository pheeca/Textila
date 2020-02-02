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
        public IEnumerable<BlendEntity> Get()
        {
            return BL.getAllBlends();
        }

        // GET api/<controller>/5
        public BlendEntity Get(int id)
        {
            return BL.getBlendById(id);
        }

        // POST api/<controller>
        public void Post([FromBody]BlendEntity value)
        {
            BL.saveBlend(value);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]BlendEntity value)
        {
            BL.updateBlend(id, value);
        }

        // DELETE api/<controller>/5
        public void Delete(BlendEntity value)
        {
           // BL.deleteCount(value);
        }
    }
}