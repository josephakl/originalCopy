using si2.bll.Dtos.Requests.FileUpload;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using si2.dal.Entities;

namespace si2.bll.Services
{
   public interface IFileDocumentService : IServiceBase
    {
        Task<bool> UploadFileAsync(FileUploadDto fileUpload,
           byte[] fileDocumentData,
           string fileName,
           string contentType,
           string userName,
           CancellationToken ct);

        List<FileDocument> GetDocuments();

        Task<bool> DeleteDocumentAsync(int id, CancellationToken ct);

    }
}
