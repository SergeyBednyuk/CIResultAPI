using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.XPath;
using AutoMapper;
using CiResultAPI.Models;
using CiResultAPI.Models.DbContexts;
using CiResultAPI.Models.DTOs;
using CiResultAPI.Models.Entities;
using CiResultAPI.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CiResultAPI.Controllers
{
    [ApiController]
    [Route("api/results")]
    public class ResultsController : Controller
    {
        private readonly ITrxResultsDbRepository _trxResultsDbRepository;
        private readonly IMapper _mapper;
        public ResultsController(ITrxResultsDbRepository trxResultsDbRepository, IMapper mapper)
        {
            _trxResultsDbRepository = trxResultsDbRepository ?? throw new ArgumentNullException(nameof(trxResultsDbRepository));

            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        // GET: api/<controller>
        [HttpGet]
        public ActionResult<IEnumerable<ResultDto>> GetAllResults()
        {
            var results = _trxResultsDbRepository.GetResults();

            if (results == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<ResultDto>>(results));
        }

        // GET api/<controller>/5
        [HttpGet("{resultId}", Name = "GetAuthorById")]
        public ActionResult<ResultDto> GetAuthorById(int resultId)
        {
            var result = _trxResultsDbRepository.GetResult(resultId);
            if (result == null)
            {
                NotFound();
            }
            return Ok(_mapper.Map<ResultDto>(result));
        }

        //TODO ?
        // GET api/<controller>/<action>/5
        [HttpGet("{date}")]
        public ActionResult<IEnumerable<ResultDto>> SearchByDate(string date)
        {
            ////DateTime parsedDate = DateTime.Parse(date);
            //DateTime parsedDate = new DateTime(2020, 3, 30);

            //IQueryable<Result> results = from r in _trxResultsDbRepository.Results
            //                             select r;
            //var resultsByDate = await results.Where(r => r.Date.Date.CompareTo(parsedDate.Date) == 0).ToListAsync();

            throw new NotImplementedException();
            //return Ok();

        }
        // POST api/<controller>
        [HttpPost]
        public ActionResult<ResultDto> CreateResult(ResultForCreatingDto result)
        {
            if (result == null)
            {
                BadRequest();
            }

            var resultEntity = _mapper.Map<Result>(result);
            _trxResultsDbRepository.AddResult(resultEntity);
            _trxResultsDbRepository.Save();

            var resultDto = _mapper.Map<ResultDto>(resultEntity);
            return CreatedAtRoute("GetAuthorById", new { resultId = resultEntity.Id }, resultDto);
        }

        // PUT api/<controller>/5
        [HttpPut("{resultId}")]
        public ActionResult UpdateResult(int resultId, ResultForUpdatingDto result)
        {
            if (!_trxResultsDbRepository.ResultExist(resultId))
            {
                return NotFound();
            }

            var resultFromRepo = _trxResultsDbRepository.GetResult(resultId);

            _mapper.Map(resultFromRepo, result);

            _trxResultsDbRepository.UpdateResult(resultFromRepo);
            _trxResultsDbRepository.Save();

            return NoContent();
        }

        [HttpPatch("{resultId}")]
        public ActionResult PartialUpdateOfResult(int resultId, [FromBody]JsonPatchDocument<ResultForUpdatingDto> patchDocument)
        {
            if (!_trxResultsDbRepository.ResultExist(resultId))
            {
                return NotFound();
            }

            var resultFromRepo = _trxResultsDbRepository.GetResult(resultId);
            var resultToPatch = _mapper.Map<ResultForUpdatingDto>(resultFromRepo);

            patchDocument.ApplyTo(resultToPatch);

            if (!TryValidateModel(resultToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(resultFromRepo, resultToPatch);

            //TODO ?
            //_trxResultsDbRepository.UpdateResult(resultFromRepo);
            _trxResultsDbRepository.Save();

            return NoContent();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{resultId}")]
        public ActionResult DeleteResult(int resultId)
        {
            if (!_trxResultsDbRepository.ResultExist(resultId))
            {
                return NotFound();
            }

            var resultFromRepo = _trxResultsDbRepository.GetResult(resultId);
            _trxResultsDbRepository.DeleteResult(resultFromRepo);
            _trxResultsDbRepository.Save();

            return NoContent();
        }
    }
}
