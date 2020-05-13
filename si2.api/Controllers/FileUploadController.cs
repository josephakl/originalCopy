using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using si2.bll.Dtos.Requests.FileUpload;
using si2.bll.Services;

namespace si2.api.Controllers
{

    [ApiController]
    [Route("api/fileUpload")]
    //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public class FileUploadController : ControllerBase
    {

        private readonly ILogger<FileUploadController> _logger;
        private readonly IFileDocumentService _fileDocumentService;

        public FileUploadController(ILogger<FileUploadController> logger, IFileDocumentService fileDocumentService)
        {
            _logger = logger;
            _fileDocumentService = fileDocumentService;
        }

        [HttpGet]
        public IActionResult GetDocuments()
        {
            _logger.LogInformation("GetDocuments method has been called");
            var docs = _fileDocumentService.GetDocuments();
            return Ok(docs);
        }

        [HttpGet("{id}")]
        public ActionResult DownloadDocument(int id)
        {

            for (int i = 0; i < _fileDocumentService.GetDocuments().Count; i++)
            {
                if (id == _fileDocumentService.GetDocuments()[i].Id)
                {
                    string fileName = _fileDocumentService.GetDocuments()[i].FileName;

                    byte[] fileBytes = _fileDocumentService.GetDocuments()[i].Data;

                    return File(fileBytes, "APPLICATION/octet-stream", fileName);
                }

            }
            return null;
        }

      
        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file, [FromForm] string fileInfoText, CancellationToken ct)
        {
            _logger.LogInformation("Upload method has been called");
            byte[] fileBytesArray = null;

            using (var fileMemoryStream = new MemoryStream())
            {
                await file.CopyToAsync(fileMemoryStream, ct);
                fileBytesArray = fileMemoryStream.ToArray();
            }

            await _fileDocumentService.UploadFileAsync(
                JsonConvert.DeserializeObject<FileUploadDto>(fileInfoText),
                fileBytesArray,
                file.FileName,
                file.ContentType,
                User?.Identity?.Name,
                ct);

            return Ok();
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteDocument(int id, CancellationToken ct)
        {
            var action = await _fileDocumentService.DeleteDocumentAsync(id, ct);
            return Ok(action);
        }
       
    }
}
