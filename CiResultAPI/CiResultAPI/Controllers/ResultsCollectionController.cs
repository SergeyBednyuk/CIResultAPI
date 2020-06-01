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
    [Route("api/resultscollection")]
    public class ResultsCollectionController : Controller
    {
        private readonly ITrxResultsDbRepository _trxResultsDbRepository;
        private readonly IMapper _mapper;

        public ResultsCollectionController(ITrxResultsDbRepository trxResultsDbRepository, IMapper mapper)
        {
            _trxResultsDbRepository = trxResultsDbRepository ?? throw new ArgumentNullException(nameof(trxResultsDbRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public ActionResult GetResultsCollection(IEnumerable<int> resultsIds)
        {
            if (resultsIds == null)
            {
                return BadRequest();
            }

            var results = _trxResultsDbRepository.GetResults(resultsIds);

            if (results.Count() != results.Count())
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<ResultDto>>(results));
        }

        //TODO? add support 201 Created status
        [HttpPost]
        public ActionResult CreateResultsCollection(IEnumerable<ResultDtoForCreationg> resultsCollection)
        {
            var results = _mapper.Map<IEnumerable<Result>>(resultsCollection);

            foreach (var result in results)
            {
                _trxResultsDbRepository.AddResult(result);
            }

            _trxResultsDbRepository.Save();

            return Ok();
            //return CreatedAtRoute();
        }
    }
}
