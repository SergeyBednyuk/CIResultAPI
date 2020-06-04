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
    [Route("api/ciexecutions")]
    public class CIExecutionsController : Controller
    {
        private readonly ITrxResultsDbRepository _trxResultsDbRepository;
        private readonly IMapper _mapper;

        public CIExecutionsController(ITrxResultsDbRepository trxResultsDbRepository, IMapper mapper)
        {
            _trxResultsDbRepository = trxResultsDbRepository ?? throw new ArgumentException(nameof(trxResultsDbRepository));
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        }

        // GET: api/<controller>
        [HttpGet]
        public ActionResult<IEnumerable<CIExecutionDto>> GetAllCIExecutions()
        {
            var ciExecutions = _trxResultsDbRepository.GetCIExecutions();
            if (ciExecutions == null)
            {
                return BadRequest();
            }

            return Ok(_mapper.Map<IEnumerable<CIExecutionDto>>(ciExecutions));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ActionResult<CIExecutionDto> Get(int id)
        {
            var cIExecution = _trxResultsDbRepository.GetCIExecution(id);
            if (cIExecution == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CIExecutionDto>(cIExecution));
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult<CIExecutionDto> CreateCIExecution(CIExecutionForCreattingDto cIExecution)
        {
            if (cIExecution == null)
            {
                BadRequest();
            }
            var ciExecutionEntity = _mapper.Map<CIExecution>(cIExecution);
            _trxResultsDbRepository.AddCIExecution(ciExecutionEntity);
            _trxResultsDbRepository.Save();
            //TODO HTTP 201 created?
            return Ok();
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public ActionResult<CIExecutionDto> Put(int id, CIExecution value)
        {

            return Ok();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public  ActionResult<CIExecutionDto> Delete(int id)
        {
           
            return Ok();
        }
    }
}
