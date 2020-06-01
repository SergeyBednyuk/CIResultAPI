using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CiResultAPI.Models;
using CiResultAPI.Models.DbContexts;
using CiResultAPI.Models.DTOs;
using CiResultAPI.Models.Entities;
using CiResultAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CiResultAPI.Controllers
{
    [ApiController]
    [Route("api/features")]
    public class FeaturesController : Controller
    {
        private readonly ITrxResultsDbRepository _trxResultsDbRepository;
        private readonly IMapper _mapper;

        public FeaturesController(ITrxResultsDbRepository trxResultsDbRepository, IMapper mapper)
        {
            _trxResultsDbRepository = trxResultsDbRepository ?? throw new ArgumentNullException(nameof(trxResultsDbRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // GET: api/<controller>
        [HttpGet]
        public ActionResult<IEnumerable<FeatureDto>> GetAllFeature()
        {
            var features = _trxResultsDbRepository.GetFeatures();

            if (features == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<FeatureDto>(features));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ActionResult<FeatureDto> GetFeatureById(int id)
        {
            var feature = _trxResultsDbRepository.GetFeature(id);
            if (feature == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<FeatureDto>(feature));
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult<FeatureDto> CreateFeature(FeatureDtoForCreating feature)
        {
            if (feature == null)
            {
                return BadRequest();
            }

            var featureEntity = _mapper.Map<Feature>(feature);
            _trxResultsDbRepository.AddFeature(featureEntity);
            _trxResultsDbRepository.Save();

            return Ok(_mapper.Map< FeatureDto>(featureEntity));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<FeatureDto>> Put(int id, FeatureDto feature)
        {
            //if (feature == null)
            //{
            //    BadRequest();
            //}
            //if (!_db.Features.Any(f=>f.Id == id))
            //{
            //    return NotFound();
            //}
            //_db.Features.Update(feature);
            //await _db.SaveChangesAsync();
            return Ok();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FeatureDto>> Delete(int id)
        {
            //Feature feature = await _db.Features.FirstOrDefaultAsync(f => f.Id == id);
            //if (feature == null)
            //{
            //    NotFound();
            //}
            //_db.Features.Remove(feature);
            //await _db.SaveChangesAsync();
            return Ok();
        }
    }
}
