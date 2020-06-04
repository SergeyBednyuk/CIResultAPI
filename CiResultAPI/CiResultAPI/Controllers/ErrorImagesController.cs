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
    [Route("api/results/{resultId}/errorimages")]
    public class ErrorImagesController : Controller
    {
        private readonly ITrxResultsDbRepository _trxResultsDbRepository;
        private readonly IMapper _mapper;

        public ErrorImagesController(ITrxResultsDbRepository trxResultsDbRepository, IMapper mapper)
        {
            _trxResultsDbRepository = trxResultsDbRepository ?? throw new ArgumentException(nameof(trxResultsDbRepository));
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        }

        // GET: api/<controller>
        [HttpGet]
        public ActionResult<IEnumerable<ErrorImage>> GetAllErrorImagesForResult(int resultId)
        {
            if (!_trxResultsDbRepository.ResultExist(resultId))
            {
                return BadRequest();
            }

            var errorimages = _trxResultsDbRepository.GetErrorImages(resultId);
            if (errorimages == null)
            {
                return BadRequest();
            }

            return Ok(_mapper.Map<IEnumerable<ErrorImageDto>>(errorimages));
        }

        // GET api/<controller>/5
        [HttpGet("{errorImageId}", Name = "GetErrorImageById")]
        public ActionResult<ErrorImage> GetErrorImageById(int errorImageId)
        {
            var errorImage = _trxResultsDbRepository.GetErrorImage(errorImageId);
            if (errorImage == null)
            {
                NotFound();
            }
            return Ok(_mapper.Map<ErrorImageDto>(errorImage));
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult<ErrorImage> CreateErrorImage(int resultId, ErrorImageForCreationgDto errorImage)
        {
            if (!_trxResultsDbRepository.ResultExist(resultId))
            {
                return NotFound();
            }

            if (errorImage == null)
            {
                return BadRequest();
            }

            var errorImageEntity = _mapper.Map<ErrorImage>(errorImage);

            _trxResultsDbRepository.AddErrorImage(resultId, errorImageEntity);
            _trxResultsDbRepository.Save();

            var errorimageDto = _mapper.Map<ErrorImageDto>(errorImageEntity);

            return CreatedAtRoute("GetErrorImageById", new { errorImageId = errorImageEntity.Id }, errorimageDto);
        }

        // PUT api/<controller>/5
        [HttpPut("{errorImageId}")]
        public ActionResult UpdateErrorImage(int errorImageId, ErrorImageForUpdatingDto errorImage)
        {
            var errorImageFromRepo = _trxResultsDbRepository.GetErrorImage(errorImageId);

            if (errorImageFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(errorImageFromRepo, errorImage);

            _trxResultsDbRepository.UpdateErrorImage(errorImageFromRepo);
            _trxResultsDbRepository.Save();

            return NoContent();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{errorImageId}")]
        public ActionResult Delete(int errorImageId)
        {
            var errorImageFromRepo = _trxResultsDbRepository.GetErrorImage(errorImageId);

            if (errorImageFromRepo == null)
            {
                return NotFound();
            }

            _trxResultsDbRepository.DeleteErrorImage(errorImageFromRepo);
            _trxResultsDbRepository.Save();

            return NoContent();
        }
    }
}
