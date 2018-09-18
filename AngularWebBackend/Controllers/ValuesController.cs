using AngularWebBackend.Models;
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
        //palautetaan numeroarvo
        [HttpGet] //mahdollistaa GET-pyynnöt
        [Route("api/Values/OrderCount")] //reitin määritys
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

        //palautetaan lista asiakkaista
        [HttpGet] //mahdollistaa GET-pyynnöt
        [Route("api/Values/LastNOrders/{id:int}")] //reitin määritys
        public List<string> LastNOrders(int id) //käytetään parametrina int, koska AppStart/WebApiConfigissa routeTemplate: "api/{controller}/{id}",
        {
            //tietokantayhteys alustaminen
            NorthwindEntities entities = new NorthwindEntities();
            //muuttujan alustus
            int numberOfOrdersToReturn = id;
            //lista-muuttuja, joka lajittelee tulokset tilauspäivän mukaan laskevasti 
            //Orders -taulusta ja palauttaa niistä 5 Take-funktiolla
            
            List<Orders> lastOrders = (from o in entities.Orders
                                       orderby o.OrderDate descending
                                       select o).Take(numberOfOrdersToReturn).ToList();

            //pyydetään Orders-taulun tiedoista pelkästään CompanyName asiakastaulun kautta
            List<string> customerNames = lastOrders.Select(o => o.Customers.CompanyName).ToList();

            //vapautetaan muisti, tietokantayhteyden sulkeminen
            entities.Dispose();
            //palautetaan tulos
            return customerNames;
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
