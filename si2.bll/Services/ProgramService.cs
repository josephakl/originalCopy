using System;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Logging;
using si2.bll.Dtos.Requests.Program;
using si2.bll.Dtos.Results.Program;
using si2.bll.Helpers.PagedList;
using si2.bll.Helpers.ResourceParameters;
using si2.dal.Entities;
using si2.dal.UnitOfWork;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static si2.common.Enums;

namespace si2.bll.Services
{
    public class ProgramService : ServiceBase, IProgramService
    {
        public ProgramService(IUnitOfWork uow, IMapper mapper, ILogger<ProgramService> logger) : base(uow, mapper, logger)
        {
        }

        public async Task<ProgramDto> CreateProgramAsync(CreateProgramDto createProgramDto, CancellationToken ct)
        {
            ProgramDto programDto = null;
            try
            {
                var programEntity = _mapper.Map<Program>(createProgramDto);
                await _uow.Program.AddAsync(programEntity, ct);
                await _uow.SaveChangesAsync(ct);
                programDto = _mapper.Map<ProgramDto>(programEntity);
            }
            catch (AutoMapperMappingException ex)
            {
                _logger.LogError(ex, string.Empty);
            }
            return programDto;
        }


        public async Task<ProgramDto> UpdateProgramAsync(Guid id, UpdateProgramDto updateProgramDto, CancellationToken ct)
        {
            ProgramDto programDto = null;

            var updatedEntity = _mapper.Map<Program>(updateProgramDto);
            updatedEntity.Id = id;
            await _uow.Program.UpdateAsync(updatedEntity, id, ct, updatedEntity.RowVersion);
            await _uow.SaveChangesAsync(ct);
            var programEntity = await _uow.Program.GetAsync(id, ct);
            programDto = _mapper.Map<ProgramDto>(programEntity);

            return programDto;
        }


        public async Task<ProgramDto> PartialUpdateProgramAsync(Guid id, UpdateProgramDto updateProgramDto, CancellationToken ct)
        {
            var programEntity = await _uow.Program.GetAsync(id, ct);

            _mapper.Map(updateProgramDto, programEntity);

            await _uow.Program.UpdateAsync(programEntity, id, ct, programEntity.RowVersion);
            await _uow.SaveChangesAsync(ct);

            programEntity = await _uow.Program.GetAsync(id, ct);
            var programDto = _mapper.Map<ProgramDto>(programEntity);

            return programDto;
        }



        public async Task<UpdateProgramDto> GetUpdateProgramDto(Guid id, CancellationToken ct)
        {
            var programEntity = await _uow.Program.GetAsync(id, ct);
            var updateProgramDto = _mapper.Map<UpdateProgramDto>(programEntity);
            return updateProgramDto;
        }

        public async Task<ProgramDto> GetProgramByIdAsync(Guid id, CancellationToken ct)
        {
            ProgramDto programDto = null;

            var programEntity = await _uow.Program.GetAsync(id, ct);
            if (programEntity != null)
            {
                programDto = _mapper.Map<ProgramDto>(programEntity);
            }

            return programDto;
        }

        public async Task DeleteProgramByIdAsync(Guid id, CancellationToken ct)
        {
            try
            {
                var programEntity = await _uow.Program.FirstAsync(c => c.Id == id, ct);
                await _uow.Program.DeleteAsync(programEntity, ct);
                await _uow.SaveChangesAsync(ct);
            }
            catch (InvalidOperationException e)
            {
                _logger.LogError(e, string.Empty);
            }
        }

        public async Task<PagedList<ProgramDto>> GetProgramAsync(ResourceParameters.ProgramResourceParameters resourceParameters, CancellationToken ct)
        {
            var programEntities = _uow.Program.GetAll();

            if (!string.IsNullOrEmpty(resourceParameters.Status))
            {
                if (Enum.TryParse(resourceParameters.Status, true, out ProgramStatus status))
                {
                    programEntities = programEntities.Where(a => a.Status == status);
                }
            }

            if (!string.IsNullOrEmpty(resourceParameters.SearchQuery))
            {
                var searchQueryForWhereClause = resourceParameters.SearchQuery.Trim().ToLowerInvariant();
                programEntities = programEntities
                    .Where(a => a.code.ToLowerInvariant().Contains(searchQueryForWhereClause)
                            || a.name.ToLowerInvariant().Contains(searchQueryForWhereClause)
                            || a.type.ToLowerInvariant().Contains(searchQueryForWhereClause)
                            );
            }

            var pagedListEntities = await PagedList<Program>.CreateAsync(programEntities,
                resourceParameters.PageNumber, resourceParameters.PageSize, ct);

            var result = _mapper.Map<PagedList<ProgramDto>>(pagedListEntities);
            result.TotalCount = pagedListEntities.TotalCount;
            result.TotalPages = pagedListEntities.TotalPages;
            result.CurrentPage = pagedListEntities.CurrentPage;
            result.PageSize = pagedListEntities.PageSize;

            return result;
        }

        public async Task<bool> ExistsAsync(Guid id, CancellationToken ct)
        {
            if (await _uow.Program.GetAsync(id, ct) != null)
                return true;

            return false;
        }
    }
}
