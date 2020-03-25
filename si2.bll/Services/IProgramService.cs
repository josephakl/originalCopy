using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.JsonPatch;
using si2.bll.Dtos.Requests.Program;
using si2.bll.Dtos.Results.Program;
using si2.bll.Helpers.PagedList;
using si2.bll.Helpers.ResourceParameters;
using System.Threading;
using System.Threading.Tasks;

namespace si2.bll.Services
{
   public interface IProgramService : IServiceBase
    {

        Task<ProgramDto> CreateProgramAsync(CreateProgramDto createProgramDto, CancellationToken ct);

        Task<ProgramDto> UpdateProgramAsync(Guid id, UpdateProgramDto updateProgramDto, CancellationToken ct);

        Task<ProgramDto> PartialUpdateProgramAsync(Guid id, UpdateProgramDto patchDoc, CancellationToken ct);

        Task<UpdateProgramDto> GetUpdateProgramDto(Guid id, CancellationToken ct);

        Task<ProgramDto> GetProgramByIdAsync(Guid id, CancellationToken ct);

        Task DeleteProgramByIdAsync(Guid id, CancellationToken ct);

        Task<PagedList<ProgramDto>> GetProgramAsync(ResourceParameters.ProgramResourceParameters pagedResourceParameters, CancellationToken ct);

        Task<bool> ExistsAsync(Guid id, CancellationToken ct);

    }
}
