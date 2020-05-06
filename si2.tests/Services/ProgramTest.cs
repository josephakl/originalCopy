using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using si2.bll.Dtos.Requests.Program;
using si2.bll.Dtos.Results.Program;
using si2.bll.Helpers.PagedList;
using si2.bll.ResourceParameters;
using si2.bll.Services;
using si2.tests.Exceptions;

namespace si2.tests
{

    public class ProgramTest
    {

        private readonly List<ProgramDto> _programDto;

        public ProgramTest()
        {
            _programDto = new List<ProgramDto>()
            {
                new ProgramDto() { 

                    Id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c010"),
                    code = "010", 
                    name = "C# with .Net core", 
                    type = "Info",
                    RowVersion = null
                },

                new ProgramDto() {

                    Id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c020"),
                    code = "020",
                    name = "Postman",
                    type = "Info",
                    RowVersion = null
                },


                 new ProgramDto() {

                    Id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c030"),
                    code = "030",
                    name = "Git",
                    type = "Info",
                    RowVersion = null
                },
            };
        }


        public ProgramDto CreateProgram(ProgramDto newProgram)
        {

            //Console.WriteLine("testssssssss " + newProgram.code + " ; " + newProgram.name + " ; " + newProgram.type);
            if (newProgram.code == null || newProgram.name == null || newProgram.type == null)
            {
                //throw new Exception("Program's code, name and type cannot be empty !");
                throw new InvalidNullException();
            }

            if (newProgram.code.Length > 5)
            {
                //throw new Exception("Program code must be at least 3 characters long !");
                throw new InvalidLengthException();
            }

            newProgram.Id = Guid.NewGuid();
           
            _programDto.Add(newProgram);

            return newProgram;
        }


        public void DeleteProgram(Guid id)
        {
            var aProgram = _programDto.First(a => a.Id == id);
            _programDto.Remove(aProgram);
        }


        public ProgramDto GetProgram(Guid id)
        {
            return _programDto.Where(a => a.Id == id).FirstOrDefault();
        }



        public List<ProgramDto> GetPrograms()
        {
            return _programDto;
        }



      
    }
}
