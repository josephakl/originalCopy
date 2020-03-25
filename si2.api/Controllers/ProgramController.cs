using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
//using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using si2.bll.Dtos.Requests.Program;
using si2.bll.Dtos.Results.Program;
using si2.bll.Helpers.ResourceParameters;
using si2.bll.Services;
using si2.common;
using System.Threading;
using si2.bll.ResourceParameters;
using System.Collections;

namespace si2.api.Controllers
{
    [ApiController]
    //[Route("api/program")]
    [Route("[controller]")]
    //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public class ProgramController : ControllerBase
    {
        // private readonly LinkGenerator _linkGenerator;
        private readonly Microsoft.Extensions.Logging.ILogger<ProgramController> _logger;
        // private readonly IProgramService _programService;
        private string [] currentPrograms = null;

        /*public ProgramController(LinkGenerator linkGenerator, Microsoft.Extensions.Logging.ILogger<ProgramController> logger, IProgramService programService)
        {
            _linkGenerator = linkGenerator;
            _logger = logger;
            _programService = programService;
        }*/

        public ProgramController(Microsoft.Extensions.Logging.ILogger<ProgramController> logger)
        {
            _logger = logger;
            currentPrograms = new [] {

                "Informatique Appliquée aux Entreprises",
                "Marketing et Publicité",
                "Management Hôtlier et Arts Culinaires"
           };
        }


        // Request list of current programs data 
       /* [HttpGet]
        public string Get()
        {
            Console.WriteLine("Current List of Programs :");

            /* for (int p = 0; p < currentPrograms.Count; p++)
             {

                  Console.WriteLine("-" + currentPrograms[p]);

              }
              return null;
            //return currentPrograms.ToArray().ToString();

            //PrintPrograms(currentPrograms);

            return currentPrograms.ToString();

        }*/

        [HttpGet]
        public IEnumerable<Programs> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 3).Select(index => new Programs
            {
                Date = DateTime.Now.AddDays(index),
                range = rng.Next(0, 10),
                title = currentPrograms[rng.Next(currentPrograms.Length)]
            })
            .ToArray();
        }



        /*[HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ProgramDto))]
        public async Task<ActionResult> CreateProgram([FromBody] CreateProgramDto createProgramDto, CancellationToken ct)
        {
            var programToReturn = await _programService.CreateProgramAsync(createProgramDto, ct);
            if (programToReturn == null)
                return BadRequest();

            return CreatedAtRoute("GetProgram", new { id = programToReturn.Id }, programToReturn);
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteProgram(Guid id, CancellationToken ct)
        {
            await _programService.DeleteProgramByIdAsync(id, ct);

            return NoContent();
        }

        [HttpGet("{id}", Name = "GetProgram")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProgramDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetProgram(Guid id, CancellationToken ct)
        {
            var programDto = await _programService.GetProgramByIdAsync(id, ct);

            if (programDto == null)
                return NotFound();

            return Ok(programDto);
        }

        [HttpGet(Name = "GetPrograms")]
        public async Task<ActionResult> GetPrograms([FromQuery]ProgramResourceParameters pagedResourceParameters, CancellationToken ct)
        {
            var programDtos = await _programService.GetProgramAsync(pagedResourceParameters, ct);

            var previousPageLink = programDtos.HasPrevious ? CreateProgramResourceUri(pagedResourceParameters, Enums.ResourceUriType.PreviousPage) : null;
            var nextPageLink = programDtos.HasNext ? CreateProgramResourceUri(pagedResourceParameters, Enums.ResourceUriType.NextPage) : null;

            var paginationMetadata = new
            {
                totalCount = programDtos.TotalCount,
                pageSize = programDtos.PageSize,
                currentPage = programDtos.CurrentPage,
                totalPages = programDtos.TotalPages,
                previousPageLink,
                nextPageLink
            };

            if (programDtos == null)
                return NotFound();

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(paginationMetadata));
            return Ok(programDtos);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProgramDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateProgram([FromRoute]Guid id, [FromBody] UpdateProgramDto updateProgramDto, CancellationToken ct)
        {
            if (!await _programService.ExistsAsync(id, ct))
                return NotFound();

            var programToReturn = await _programService.UpdateProgramAsync(id, updateProgramDto, ct);
            if (programToReturn == null)
                return BadRequest();

            return Ok(programToReturn);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateProgram([FromRoute]Guid id, [FromBody] JsonPatchDocument<UpdateProgramDto> patchDoc, CancellationToken ct)
        {
            if (!await _programService.ExistsAsync(id, ct))
                return NotFound();

            var programToPatch = await _programService.GetUpdateProgramDto(id, ct);
            patchDoc.ApplyTo(programToPatch, ModelState);

            TryValidateModel(programToPatch);

            if (!ModelState.IsValid)
                return new UnprocessableEntityObjectResult(ModelState);

            var programToReturn = await _programService.PartialUpdateProgramAsync(id, programToPatch, ct);
            if (programToReturn == null)
                return BadRequest();

            return Ok(programToReturn);
        }


        private string CreateProgramResourceUri(ProgramResourceParameters pagedResourceParameters, Enums.ResourceUriType type)
        {
            switch (type)
            {
                case Enums.ResourceUriType.PreviousPage:
                    return _linkGenerator.GetUriByName(this.HttpContext, "GetProgram",
                        new
                        {
                            status = pagedResourceParameters.Status,
                            searchQuery = pagedResourceParameters.SearchQuery,
                            pageNumber = pagedResourceParameters.PageNumber - 1,
                            pageSize = pagedResourceParameters.PageSize
                        });
                case Enums.ResourceUriType.NextPage:
                    return _linkGenerator.GetUriByName(this.HttpContext, "GetProgram",
                        new
                        {
                            status = pagedResourceParameters.Status,
                            searchQuery = pagedResourceParameters.SearchQuery,
                            pageNumber = pagedResourceParameters.PageNumber + 1,
                            pageSize = pagedResourceParameters.PageSize
                        });
                default:
                    return _linkGenerator.GetUriByName(this.HttpContext, "GetProgram",
                       new
                       {
                           status = pagedResourceParameters.Status,
                           searchQuery = pagedResourceParameters.SearchQuery,
                           pageNumber = pagedResourceParameters.PageNumber,
                           pageSize = pagedResourceParameters.PageSize
                       });
            }


        }
    }*/
    }
}
