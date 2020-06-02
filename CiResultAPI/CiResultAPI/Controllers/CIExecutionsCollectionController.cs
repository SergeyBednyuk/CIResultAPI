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
    [Route("api/ciexecutionscollection")]
    public class CIExecutionsCollectionController : Controller
    {
        private readonly ITrxResultsDbRepository _trxResultsDbRepository;
        private readonly IMapper _mapper;

        public CIExecutionsCollectionController(ITrxResultsDbRepository trxResultsDbRepository, IMapper mapper)
        {
            _trxResultsDbRepository = trxResultsDbRepository ?? throw new ArgumentException(nameof(trxResultsDbRepository));
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        }

        [HttpGet]
        public ActionResult<IEnumerable<CIExecutionDto>> GetCIExecutionsCollection(IEnumerable<int> ciExecutionsIds)
        {
            if (ciExecutionsIds == null)
            {
                return BadRequest();
            }

            var ciExecutions = _trxResultsDbRepository.GetCIExecutions(ciExecutionsIds);
            if (ciExecutions.Count() != ciExecutionsIds.Count())
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<CIExecutionDto>>(ciExecutions));
        }

        [HttpPost]
        public ActionResult<IEnumerable<CIExecutionDto>> CreateCIExecutionsCollection(IEnumerable<CIExecutionDtoForCreatting> ciExecutionsCollection)
        {
            if (ciExecutionsCollection == null)
            {
                return BadRequest();
            }

            var ciExecutions = _mapper.Map<IEnumerable<CIExecution>>(ciExecutionsCollection);
            foreach (var ciExecution in ciExecutions)
            {
                _trxResultsDbRepository.AddCIExecution(ciExecution);
            }
            _trxResultsDbRepository.Save();

            return Ok();
        }
    }
}
