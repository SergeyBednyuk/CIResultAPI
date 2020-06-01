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
        [Route("")]
        [HttpGet]
        public ActionResult<IEnumerable<ResultDto>> GetAllResults()
        {
            var results = _trxResultsDbRepository.GetResults();

            if (results == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ResultDto>(results));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ActionResult<ResultDto> GetAuthorById(int id)
        {
            var result = _trxResultsDbRepository.GetResult(id);
            if (result == null)
            {
                NotFound();
            }
            return Ok(_mapper.Map<ResultDto>(result));
        }

        //TODO
        // GET api/<controller>/<action>/5
        [HttpGet("{date}")]
        public ActionResult<IEnumerable<ResultDto>> SearchByDate(string date)
        {
            ////DateTime parsedDate = DateTime.Parse(date);
            //DateTime parsedDate = new DateTime(2020, 3, 30);

            //IQueryable<Result> results = from r in _trxResultsDbRepository.Results
            //                             select r;
            //var resultsByDate = await results.Where(r => r.Date.Date.CompareTo(parsedDate.Date) == 0).ToListAsync();

            return NotFound();

        }
        // POST api/<controller>
        [HttpPost]
        public ActionResult<ResultDto> CreateResult(ResultDtoForCreationg result)
        {
            if (result == null)
            {
                BadRequest();
            }

            var resultEntity = _mapper.Map<Result>(result);
            _trxResultsDbRepository.AddResult(resultEntity);
            return Ok();
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ResultDto>> Put(int id, ResultDto value)
        {
            //if (value == null)
            //{
            //    BadRequest();
            //}
            //if (!_trxResultsDbRepository.Results.Any(r => r.Id == id))
            //{
            //    NotFound();
            //}
            //_trxResultsDbRepository.Results.Update(value);
            //await _trxResultsDbRepository.SaveChangesAsync();
            return Ok();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResultDto>> Delete(int id)
        {
            //Result result = await _trxResultsDbRepository.Results.FirstOrDefaultAsync(i => i.Id == id);
            //if (result == null)
            //{
            //    NotFound();
            //}
            //_trxResultsDbRepository.Results.Remove(result);
            //await _trxResultsDbRepository.SaveChangesAsync();
            return Ok();
        }
    }
}
