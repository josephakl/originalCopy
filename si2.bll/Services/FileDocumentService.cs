using AutoMapper;
using Microsoft.Extensions.Logging;
using si2.dal.Entities;
using si2.dal.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using System.Threading.Tasks;
using si2.bll.Helpers;
using si2.bll.Dtos.Requests.FileUpload;
using si2.bll.Helpers.AutoMapper;

namespace si2.bll.Services
{
    public class FileDocumentService : ServiceBase, IFileDocumentService
    {

         /*public FileDocumentService(IUnitOfWork uow, IAutoMapperService mapper, ILogger<FileDocumentService> logger) : base(uow, mapper, logger)
        {
        }*/

        public FileDocumentService(IUnitOfWork uow, IMapper mapper, ILogger<FileDocumentService> logger) : base(uow, mapper, logger)
        {
        }

        public async Task<bool> UploadFileAsync(FileUploadDto fileUpload, 
            byte[] fileDocumentData,
            string fileName,
            string contentType,
            string userName, 
            CancellationToken ct)
        {
            //FileDocument fileDocumentEntity = _mapper.Mapper.Map<FileDocument>(fileUpload);
            FileDocument fileDocumentEntity = _mapper.Map<FileDocument>(fileUpload);
            fileDocumentEntity.FileName = fileName;
            fileDocumentEntity.ContentType = contentType;
            fileDocumentEntity.Data = fileDocumentData;
            fileDocumentEntity.UploadedBy = userName;
            fileDocumentEntity.UploadedOn = DateTime.UtcNow;
            
            _uow.FileDocuments.Add(fileDocumentEntity);

            return await _uow.SaveChangesAsync(ct) > 0;


        }
        public List<FileDocument> GetDocuments()
        {
            return _uow.FileDocuments.GetAll().ToList();
         
        }
        public List<FileDocument> GetFile()
        {
            return _uow.FileDocuments.GetAll().ToList();
        }
        public async Task<bool> DeleteDocumentAsync(int id, CancellationToken ct)
        {
            _uow.FileDocuments.Remove(id);
            if (await _uow.SaveChangesAsync(ct) > 0)
                return true;
            else
                return false;
        }

    }


    }
