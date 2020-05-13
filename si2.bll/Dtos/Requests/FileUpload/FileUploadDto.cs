using System;
using System.Collections.Generic;
using System.Text;

namespace si2.bll.Dtos.Requests.FileUpload
{
    public class FileUploadDto
    {

        public int? InstitutionId { get; set; }

        public string NameAr { get; set; }

        public string NameEn { get; set; }

        public string NameFr { get; set; }

        public string Action { get; set; }

    }
}
