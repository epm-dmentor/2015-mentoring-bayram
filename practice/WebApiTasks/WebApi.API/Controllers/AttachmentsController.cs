using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.API.Controllers
{
    public class AttachmentsController : ApiController
    {
        private static List<Attachement> _attachements = new List<Attachement>
        {
            new Attachement {FileName = "test1", FileExtention = "txt", Id = 1, MailId = 1, Path = @"C:\drive\",StatusId = 1},
            new Attachement {FileName = "test2", FileExtention = "jpg", Id = 2, MailId = 2, Path = @"D:\drive\",StatusId = 2},
            new Attachement {FileName = "test3", FileExtention = "png", Id = 3, MailId = 3, Path = @"E:\drive\",StatusId = 3},
            new Attachement {FileName = "test4", FileExtention = "docx", Id = 4, MailId = 4, Path = @"F:\drive\",StatusId = 4}
        };
        // GET api/mail/{id}/attachments
        public IEnumerable<Attachement> GetByMailId(int id)
        {
            return _attachements.Where(x => x.MailId == id);
        }

        // GET api/mail/{id}/attachments/{attId}
        public Attachement GetByAttachmentId(int id, int attId)
        {
            return _attachements.FirstOrDefault(x => x.MailId == id && x.Id == attId);
        }

        // GET api/mail/{id}/attachments/{attId}?extension={ext}&status={status}

        public IEnumerable<Attachement> GetByStatus(int id, int attId, string extension, int status)
        {
            return _attachements.Where(x => x.MailId == id && x.Id == attId
               && x.FileExtention.Contains(extension) && x.StatusId == status);
        }
        public IEnumerable<Attachement> GetByExtension(int id, int attId, string extension)
        {
            return _attachements.Where(x => x.MailId == id && x.Id == attId
                && x.FileExtention.Contains(extension));
        }
        // POST 
        public void Post([FromBody]Attachement value)
        {
            _attachements.Add(value);
        }

        // PUT
        public void Put(int id, [FromBody]Attachement value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Value");
            }
            int index = _attachements.FindIndex(p => p.Id == value.Id);
            if (index == -1)
            {
                return;
            }
            _attachements.RemoveAt(index);
            _attachements.Add(value);
        }

        // DELETE 
        public void Delete(int id)
        {
            var item = _attachements.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _attachements.Remove(item);
        }
    }
}
