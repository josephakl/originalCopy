using System;
using System.Collections.Generic;
using System.Text;
using si2.dal.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static si2.common.Enums;

namespace si2.dal.Entities
{
    [Table("Program")]
    public class Program : Si2BaseDataEntity<Guid>, IAuditable
    {

        [Required]
        public string code { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string type { get; set; }

        [Required]
        public ProgramStatus Status { get; set; }

    }
}
