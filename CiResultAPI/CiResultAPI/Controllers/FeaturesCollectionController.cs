using AutoMapper;
using CiResultAPI.Models;
using CiResultAPI.Models.DTOs;
using CiResultAPI.Models.Entities;
using CiResultAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CiResultAPI.Controllers
{
    [ApiController]
    [Route("api/featurescollection")]
    public class FeaturesCollectionController : Controller
    {
        private readonly ITrxResultsDbRepository _trxResultsDbRepository;
        private readonly IMapper _mapper;

        public FeaturesCollectionController(ITrxResultsDbRepository trxResultsDbRepository, IMapper mapper)
        {
            _trxResultsDbRepository = trxResultsDbRepository ?? throw new ArgumentException(nameof(trxResultsDbRepository));
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        }

        [HttpGet]
        public ActionResult<IEnumerable<FeatureDto>> GetFeatureCollection(IEnumerable<int> featuresIds)
        {
            if (featuresIds == null)
            {
                return BadRequest();
            }

            var features = _trxResultsDbRepository.GetFeatures(featuresIds);

            if (features.Count() != featuresIds.Count())
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<FeatureDto>>(features));
        }

        [HttpPost]
        public ActionResult<IEnumerable<FeatureDto>> CreateFeaturesCollection(IEnumerable<FeatureForCreatingDto> featuresCollection)
        {
            if (featuresCollection == null)
            {
                return BadRequest();
            }

            var features = _mapper.Map<IEnumerable<Feature>>(featuresCollection);
            foreach (var feature in features)
            {
                _trxResultsDbRepository.AddFeature(feature);
            }
            _trxResultsDbRepository.Save();

            return Ok();
        }
    }
}
