using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace si2.dal.Entities
{
    [Table("FileDocument")]
    public class FileDocument
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string FileName { get; set; }

        public string ContentType { get; set; }

        public string NameAr { get; set; }

        public string NameEn { get; set; }

        public string NameFr { get; set; }

        public string Action { get; set; }

        public DateTime UploadedOn { get; set; }

        public string UploadedBy { get; set; }

        public byte[] Data { get; set; }

        public int? InstitutionId { get; set; }

    }

}
