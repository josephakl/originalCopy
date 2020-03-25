using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace si2.bll.Dtos.Requests.Program
{

	public class CreateProgramDto
	{
		[Required]
		public string code { get; set; }

		[Required]
		public string name { get; set; }

		[Required]
		public string type { get; set; }
	}

}