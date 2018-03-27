using BAH.API.BAHEvents.Models;
using BankOfChildrenAPI.Models;
using BankOfChildrenAPI.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.Collections.Generic;

namespace BankOfChildrenAPI.Controllers
{
    [Produces("application/json")]
    [Route("api")]
    [EnableCors("AllowAll")]
    public class EventController : Controller
    {
        IDbCollectionEventRepository<Event, string> _repo;
        public EventController(IDbCollectionEventRepository<Event,string> r)
        {
            _repo = r;
        }
        [Route("Events/All")]
        public IActionResult Get()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var events = _repo.GetItemsFromCollectionAsync().Result;
            List<Event> evnts = events.ToList();
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            return Ok(events);
        }
        [Route("Events/{id}")]
        public IActionResult Get(string id)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var person = _repo.GetItemFromCollectionAsync(id).Result;
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            return Ok(person);
        }
        [Route("Events/Create")]
        public IActionResult Post([FromBody]Event per)
        {
            var person = _repo.AddDocumentIntoCollectionAsync(per).Result;
            return Ok(person);
        }
        [Route("Events/Update/{id}")]
        public IActionResult Put(string id, [FromBody]Event per)
        {
            var person = _repo.UpdateDocumentFromCollection(id,per);
            return Ok(person.Result);
        }
        [Route("Events/Delete/{id}")]
        public IActionResult Delete(string id)
        {
            var res = _repo.DeleteDocumentFromCollectionAsync(id);
            return Ok(res.Status);
        }

    }
}