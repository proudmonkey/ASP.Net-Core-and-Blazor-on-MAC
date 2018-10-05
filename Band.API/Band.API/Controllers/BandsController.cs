
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Band.API.Models.Repository;
using BandModel = Band.API.Models; 

namespace Band.API.Controllers
{
    [Route("api/[controller]")]
    public class BandsController : Controller
    {
        private IDataRepository<BandModel.Band, int> _iRepo;
        public BandsController(IDataRepository<BandModel.Band, int> repo)
        {
            _iRepo = repo;
        }

        // GET: api/bands
        [HttpGet]
        public IEnumerable<BandModel.Band> Get()
        {
            return _iRepo.GetAll();
        }

        // GET api/bands/5
        [HttpGet("{id}")]
        public BandModel.Band Get(int id)
        {
            return _iRepo.Get(id);
        }

        // POST api/bands
        [HttpPost]
        public int Post([FromBody]BandModel.Band band)
        {
            return _iRepo.Add(band);
        }

        // POST api/bands
        [HttpPut]
        public int Put([FromBody]BandModel.Band band)
        {
            return _iRepo.Update(band.Id, band);
        }

        // DELETE api/bands/5
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return _iRepo.Delete(id);
        }
    }
}
