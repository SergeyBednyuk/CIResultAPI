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
    [Route("api/errorimages")]
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
        public ActionResult<IEnumerable<ErrorImage>> GetAllErrorImages()
        {
            var errorimages = _trxResultsDbRepository.GetErrorImages();
            if (errorimages == null)
            {
                return BadRequest();
            }

            return Ok(_mapper.Map<IEnumerable<ErrorImageDto>>(errorimages));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ActionResult<ErrorImage> GetErrorImageById(int id)
        {
            var errorImage = _trxResultsDbRepository.GetErrorImage(id);
            if (errorImage == null)
            {
                NotFound();
            }
            return Ok(_mapper.Map<ErrorImageDto>(errorImage));
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult<ErrorImage> CreateErrorImage(ErrorImageDtoForCreationg errorImage)
        {
            if (errorImage == null)
            {
                BadRequest();
            }

            var errorImageEntity = _mapper.Map<ErrorImage>(errorImage);
            _trxResultsDbRepository.AddErrorImage(errorImageEntity);
            _trxResultsDbRepository.Save();
            //DOTO ????
            //return Created();
            return Ok(_mapper.Map<ErrorImageDto>(errorImageEntity));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public ActionResult<ErrorImage> Put(int id, ErrorImage value)
        {
            //if (value == null)
            //{
            //    BadRequest();
            //}
            //if (!_db.ErrorImages.Any(i => i.Id == id))
            //{
            //    NotFound();
            //}
            //_db.ErrorImages.Update(value);
            //await _db.SaveChangesAsync();
            return Ok();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public ActionResult<ErrorImage> Delete(int id)
        {
            //ErrorImage errorImage = await _db.ErrorImages.FirstOrDefaultAsync(i => i.Id == id);
            //if (errorImage == null)
            //{
            //    NotFound();
            //}
            //_db.ErrorImages.Remove(errorImage);
            //await _db.SaveChangesAsync();
            return Ok();
        }
    }
}
