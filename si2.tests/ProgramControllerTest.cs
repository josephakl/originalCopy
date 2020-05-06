using NUnit.Framework;
using si2.bll.Dtos.Results.Program;
using si2.tests.Exceptions;
using System;
using System.Collections.Generic;

namespace si2.tests
{
    //[TestClass]
    public class ProgramControllerTest
    {

        private ProgramTest _programTest;
        private List<ProgramDto> _programDto;

        [SetUp]
        public void Setup()
        {
             _programTest = new ProgramTest();
        }

        [Test]
        public void Test_CreateProgram()
        {
            // Arrange
            var testItem = new ProgramDto()
            {
                code = "040",
                name = "test040",
                type = "info",
                RowVersion = null
            };

            var testItem2 = new ProgramDto()
            {
                code = "050",
                name = "test050",
                type = "info5",
                RowVersion = null
            };


            // Act
            _programDto = _programTest.GetPrograms();

            var createdResponse = _programTest.CreateProgram(testItem);
            var item = createdResponse.code;

            // Assert
            Assert.IsTrue(_programDto.Contains(testItem), "New value added !");
            Assert.IsFalse(_programDto.Contains(testItem2));
            Assert.AreEqual(item, testItem.code);
        }


        [Test]
        public void Test_DeleteProgram()
        {
            // Arrange
            var testItem = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c030");

            // Act
            //var createdResponse = _programTest.GetProgram(testItem);
            // var item = createdResponse.Id;

            List<ProgramDto> _programDto;
            _programDto = _programTest.GetPrograms();

            _programTest.DeleteProgram(testItem);

            // Assert
            Assert.AreEqual(2, _programDto.Count);
            Assert.That(-1, Is.EqualTo(_programDto.FindIndex(a => a.Id == testItem)));

        }


        [Test]
        public void Test_GetProgram()
        {
            // Arrange
            var testItem = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c020");

            // Act
            var createdResponse = _programTest.GetProgram(testItem);
            var item = createdResponse.Id;

            // Assert
            Assert.AreEqual(testItem, item);
        }


        [Test]
        public void Test_GetPrograms()
        {
            // Act
            List<ProgramDto> _programDto;
            _programDto = _programTest.GetPrograms();
           
            // Assert
            Assert.AreEqual(3, _programDto.Count);
   
        }


        [Test]
        //[ExpectedException(typeof(ArgumentException),"Program code cannot be null")]
        public void Test_ProgramNullCode()
        {
            // Arrange
            var testItem = new ProgramDto()
            {
                code = null,
                name = "test090",
                type = "info",
                RowVersion = null
            };

            //ProgramDto aprog;

            // Act and Assert
             Assert.Throws<InvalidNullException>(delegate { _programTest.CreateProgram(testItem); });

            //Assert.That(() => _programTest.CreateProgram(testItem),Throws.TypeOf<InvalidNullException>());
        }


        [Test]
        public void Test_ProgramNullName()
        {
            // Arrange
            var testItem = new ProgramDto()
            {
                code = "test101",
                name = null,
                type = "info",
                RowVersion = null
            };

            // Act and Assert
            //Assert.Throws<InvalidNullException>(delegate { _programTest.CreateProgram(testItem); ; });

            Assert.That(() => _programTest.CreateProgram(testItem),Throws.TypeOf<InvalidNullException>());

        }

        [Test]
        public void Test_ProgramNullType()
        {
            // Arrange
            var testItem = new ProgramDto()
            {
                code = "test101",
                name = "test",
                type = null,
                RowVersion = null
            };

            // Act and Assert
            Assert.Throws<InvalidNullException>(delegate { _programTest.CreateProgram(testItem); ; });

            //Assert.That(() => _programTest.CreateProgram(testItem), Throws.TypeOf<InvalidNullException>());

        }


        [Test]
        public void Test_ProgramCodeLength()
        {
            // Arrange
            var testItem = new ProgramDto()
            {
                code = "test01234",
                name = "test",
                type = "test",
                RowVersion = null
            };

            // Act and Assert
            Assert.Throws<InvalidLengthException>(delegate { _programTest.CreateProgram(testItem); ; });
        }

    }



}