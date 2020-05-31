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
    public class ErrorImagesController : Controller
    {
        private TrxResultsContext _db;
        public ErrorImagesController(TrxResultsContext db)
        {
            _db = db;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ErrorImage>>> Get()
        {
            return await _db.ErrorImages.ToListAsync();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ErrorImage>> Get(int id)
        {
            ErrorImage errorImage = await _db.ErrorImages.FirstOrDefaultAsync(i => i.Id == id);
            if (errorImage == null)
            {
                NotFound();
            }
            return errorImage;
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<ActionResult<ErrorImage>> Post(ErrorImage value)
        {
            if (value == null)
            {
                BadRequest();
            }
            _db.ErrorImages.Add(value);
            await _db.SaveChangesAsync();
            return Ok();
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ErrorImage>> Put(int id, ErrorImage value)
        {
            if (value == null)
            {
                BadRequest();
            }
            if (!_db.ErrorImages.Any(i => i.Id == id))
            {
                NotFound();
            }
            _db.ErrorImages.Update(value);
            await _db.SaveChangesAsync();
            return Ok();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ErrorImage>> Delete(int id)
        {
            ErrorImage errorImage = await _db.ErrorImages.FirstOrDefaultAsync(i => i.Id == id);
            if (errorImage == null)
            {
                NotFound();
            }
            _db.ErrorImages.Remove(errorImage);
            await _db.SaveChangesAsync();
            return Ok();
        }
    }
}
