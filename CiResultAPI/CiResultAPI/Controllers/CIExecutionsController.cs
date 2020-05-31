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
    public class CIExecutionsController : Controller
    {
        private TrxResultsContext _db;
        public CIExecutionsController(TrxResultsContext db)
        {
            _db = db;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CIExecution>>> Get()
        {
            return await _db.CIExecutions.ToListAsync();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CIExecution>> Get(int id)
        {
            CIExecution cIExecution = await _db.CIExecutions.FirstOrDefaultAsync(f => f.Id == id);
            if (cIExecution == null)
            {
                return NotFound();
            }
            return cIExecution;
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<ActionResult<CIExecution>> Post(CIExecution value)
        {
            if (value == null)
            {
                BadRequest();
            }
            _db.CIExecutions.Add(value);
            await _db.SaveChangesAsync();
            return Ok();
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<CIExecution>> Put(int id, CIExecution value)
        {

            if (value == null)
            {
                BadRequest();
            }
            if (!_db.CIExecutions.Any(f => f.Id == id))
            {
                return NotFound();
            }
            _db.CIExecutions.Update(value);
            await _db.SaveChangesAsync();
            return Ok();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Feature>> Delete(int id)
        {
            CIExecution cIExecution = await _db.CIExecutions.FirstOrDefaultAsync(f => f.Id == id);
            if (cIExecution == null)
            {
                NotFound();
            }
            _db.CIExecutions.Remove(cIExecution);
            await _db.SaveChangesAsync();
            return Ok();
        }
    }
}
