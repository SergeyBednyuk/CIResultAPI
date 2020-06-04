using AutoMapper;
using CiResultAPI.Models;
using CiResultAPI.Models.DTOs;
using CiResultAPI.Models.Entities;
using CiResultAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.TeamFoundation.WorkItemTracking.Process.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CiResultAPI.Controllers
{
    [ApiController]
    [Route("api/errorimagescollection")]
    public class ErrorImagesCollectionController : Controller
    {
        private readonly ITrxResultsDbRepository _trxResultsDbRepository;
        private readonly IMapper _mapper;

        public ErrorImagesCollectionController(ITrxResultsDbRepository trxResultsDbRepository, IMapper mapper)
        {
            _trxResultsDbRepository = trxResultsDbRepository ?? throw new ArgumentException(nameof(trxResultsDbRepository));
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        }

        [HttpGet("{errorImagesIds}")]
        public ActionResult<IEnumerable<ErrorImageDto>> GetErrorImagesCollection(IEnumerable<int> errorImagesIds)
        {
            if (errorImagesIds == null)
            {
                return BadRequest();
            }

            var errorImages = _trxResultsDbRepository.GetErrorImages(errorImagesIds);
            if (errorImages.Count() != errorImages.Count())
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<ErrorImageDto>>(errorImages));
        }

        [HttpPost("{resultId}")]
        public ActionResult<IEnumerable<ErrorImageDto>> CreateErrorImagesCollection(int resultId,[FromBody] IEnumerable<ErrorImageForCreationgDto> errorImagesCollection)
        {
            if (errorImagesCollection == null)
            {
                return BadRequest();
            }

            if (!_trxResultsDbRepository.ResultExist(resultId))
            {
                return NotFound();
            }

            var errorImages = _mapper.Map<IEnumerable<ErrorImage>>(errorImagesCollection);
            foreach (var errorImage in errorImages)
            {
                _trxResultsDbRepository.AddErrorImage(resultId, errorImage);
            }
            _trxResultsDbRepository.Save();

            return Ok();
        }
    }
}
