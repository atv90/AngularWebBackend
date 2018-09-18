﻿using AngularWebBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AngularWebBackend.Controllers
{
    public class ValuesController : ApiController
    {
        [HttpGet] //mahdollistaa GET-pyynnöt
        public int OrderCount()
        {
            //tietokantayhteys alustaminen
            NorthwindEntities entities = new NorthwindEntities();
            //paikallinen muuttuja, joka laskee tilausten lkm:n Orders-taulusta
            int orderCount = entities.Orders.Count();
            //vapautetaan muisti, tietokantayhteyden sulkeminen
            entities.Dispose();
            //palautetaan tulos
            return orderCount;
        }



        //// GET api/values
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/values/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //public void Delete(int id)
        //{
        //}
    }
}
