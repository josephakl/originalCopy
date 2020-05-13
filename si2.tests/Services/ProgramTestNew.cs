using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using si2.bll.Dtos.Results.Program;
using si2.bll.Helpers;
using si2.bll.Services;
using si2.dal.Entities;
using si2.dal.UnitOfWork;
using System;
using System.Threading;
using System.Threading.Tasks;
using static si2.common.Enums;

namespace si2.tests.Services
{
    public class ProgramTestNew
    {

        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<ILogger<ProgramService>> _mockLogger;
        private readonly IMapper _mapper;

        private ProgramDto mockProgramDto = new ProgramDto()
        {
            Id = new Guid("31B389D0-4A20-4978-DDCB-08D7C432FC14"),
            name = "java",
            type = "info",
            RowVersion = Convert.FromBase64String("AAAAAAAAB94=")
        };

       /* private ProgramDto mockProgram = new Program()
        {
            code = "7" ,
            name = "asp",
            type = "info",
            RowVersion = Convert.FromBase64String("AAAAAAAAB94=")
        };*/

        public IProgramService _programService;

        public ProgramTestNew()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockLogger = new Mock<ILogger<ProgramService>>();
            _mapper = new MapperConfiguration(mc => { mc.AddProfile(new MappingProfile()); }).CreateMapper();

            _programService = new ProgramService(_mockUnitOfWork.Object, _mapper, _mockLogger.Object);
        }

        [Test]
        public void GetDataflowByIdAsync_WhenMatching()
        {
            // Arrange
           // _mockUnitOfWork.Setup(_mockUnitOfWork => _mockUnitOfWork.Program.GetAsync(mockProgramDto.Id, It.IsAny<CancellationToken>())).Returns(Task.FromResult(mockProgram));

            // Act
            var expected = _programService.GetProgramByIdAsync(mockProgramDto.Id, It.IsAny<CancellationToken>()).Result;

            // Assert
            Assert.AreEqual(expected, mockProgramDto);
        }
    }


}

