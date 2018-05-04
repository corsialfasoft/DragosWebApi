using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DragosWebApi.Models;

namespace DragosWebApi.Controllers {
    public class ProdottiController : ApiController {
        
        DomainModel dm = new DomainModel();
        // GET api/<controller>
        public IEnumerable<Prodotto> Get() {
            return dm.Search("");
        }

        // GET api/<controller>/5
        public Prodotto Get(int id) {
            return dm.Search(id);
        }

        // POST api/<controller>
        public void Post([FromBody]Prodotto nuovo) {
            dm.Add(nuovo);
        }

        // PUT api/<controller>/5
        public void Put(int id,[FromBody]string value) {
        }

        // DELETE api/<controller>/5
        public void Delete(int id) {
            dm.Del(id);
        }
    }
}