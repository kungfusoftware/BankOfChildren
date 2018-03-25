using BankOfChildrenAPI.Models;
using BankOfChildrenAPI.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace BankOfChildrenAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/BankofChildrenAPI")]
    [EnableCors("AllowAll")]
    public class ChildController : Controller
    {
        IDbCollectionOperationsRepository<ChildModel, string> _repo;
        public ChildController(IDbCollectionOperationsRepository<ChildModel,string> r)
        {
            _repo = r;
        }
        [Route("Account/All")]
        public IActionResult Get()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            // the code that you want to measure comes here
           
           

            var persons = _repo.GetItemsFromCollectionAsync().Result;

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            return Ok(persons);
        }
        [Route("Account/{id}")]
        public IActionResult Get(string id)
        {
            var person = _repo.GetItemFromCollectionAsync(id).Result;
            return Ok(person);
        }
        [Route("Account/Create")]
        public IActionResult Post([FromBody]ChildModel per)
        {
            var person = _repo.AddDocumentIntoCollectionAsync(per).Result;
            return Ok(person);
        }
        [Route("Account/Update/{id}")]
        public IActionResult Put(string id, [FromBody]ChildModel per)
        {
            var person = _repo.UpdateDocumentFromCollection(id,per);
            return Ok(person.Result);
        }
        [Route("Account/Delete/{id}")]
        public IActionResult Delete(string id)
        {
            var res = _repo.DeleteDocumentFromCollectionAsync(id);
            return Ok(res.Status);
        }

    }
}