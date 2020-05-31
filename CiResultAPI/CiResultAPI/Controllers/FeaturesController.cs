using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CiResultAPI.Models;
using CiResultAPI.Models.DbContexts;
using CiResultAPI.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CiResultAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeaturesController : Controller
    {
        private TrxResultsContext _db;
        public FeaturesController(TrxResultsContext db)
        {
            _db = db;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Feature>>> Get()
        {
            return await _db.Features.ToListAsync();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Feature>> Get(int id)
        {
            Feature feature = await _db.Features.FirstOrDefaultAsync(f => f.Id == id);
            if (feature == null)
            {
                return NotFound();
            }
            return feature;
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<ActionResult<Feature>> Post(Feature feature)
        {
            if (feature == null)
            {
                BadRequest();
            }
            _db.Features.Add(feature);
            await _db.SaveChangesAsync();
            return Ok();
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Feature>> Put(int id, Feature feature)
        {
            if (feature == null)
            {
                BadRequest();
            }
            if (!_db.Features.Any(f=>f.Id == id))
            {
                return NotFound();
            }
            _db.Features.Update(feature);
            await _db.SaveChangesAsync();
            return Ok();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Feature>> Delete(int id)
        {
            Feature feature = await _db.Features.FirstOrDefaultAsync(f => f.Id == id);
            if (feature == null)
            {
                NotFound();
            }
            _db.Features.Remove(feature);
            await _db.SaveChangesAsync();
            return Ok();
        }
    }
}
