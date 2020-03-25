using System;

namespace si2.bll.Dtos.Results.Program 
{

	public class ProgramDto
	{
        public Guid Id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public byte[] RowVersion { get; set; }
    }
   
}
