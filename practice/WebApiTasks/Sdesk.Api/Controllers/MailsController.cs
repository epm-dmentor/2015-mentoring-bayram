using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using Epam.Sdesk.Model;

namespace Sdesk.Api.Controllers
{
    public class MailsController : ApiController
    {
        private static List<Mail> _mails = new List<Mail>
            {
                new Mail
                {
                    AttachementId = 1,
                    Body = "TestBody",
                    Cc = "test@email.com",
                    Id = 1,
                    Priority = Priority.Critical,
                    Received = DateTime.Now,
                    Saved = DateTime.Now.AddHours(1),
                    Sender = "bayram@bayram.com",
                    Subject = "Test1",
                    To = "testing@email.com"
                },
                new Mail
                {
                    AttachementId = 2,
                    Body = "TestBody2",
                    Cc = "test@email.com",
                    Id = 2,
                    Priority = Priority.Critical,
                    Received = DateTime.Now,
                    Saved = DateTime.Now.AddHours(1),
                    Sender = "bayram@bayram.com",
                    Subject = "Test2",
                    To = "testing@email.com"
                },
                new Mail
                {
                    AttachementId = 3,
                    Body = "TestBody3",
                    Cc = "test@email.com",
                    Id = 3,
                    Priority = Priority.Critical,
                    Received = DateTime.Now,
                    Saved = DateTime.Now.AddHours(1),
                    Sender = "bayram@bayram.com",
                    Subject = "Test3",
                    To = "testing@email.com"
                },
                new Mail
                {
                    AttachementId = 4,
                    Body = "TestBody4",
                    Cc = "test@email.com",
                    Id = 4,
                    Priority = Priority.Critical,
                    Received = DateTime.Now,
                    Saved = DateTime.Now.AddHours(1),
                    Sender = "bayram@bayram.com",
                    Subject = "Test4",
                    To = "testing@email.com"
                }

            };

       
        // GET api/mails
        public IEnumerable<Mail> Get()
        {
            return _mails.ToList();
        }

        // GET api/mails/5
        public Mail Get(int id)
        {
            var item = _mails.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        // POST api/mails
        public void Post([FromBody]Mail value)
        {
            _mails.Add(value);
        }

        // PUT api/mails/5
        public void Put(int id, [FromBody]Mail value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Value");
            }
            int index = _mails.FindIndex(p => p.Id == value.Id);
            if (index == -1)
            {
                return;
            }
            _mails.RemoveAt(index);
            _mails.Add(value);
        }

        // DELETE api/mails/5
        public void Delete(int id)
        {
            var item = _mails.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _mails.Remove(item);
        }
    }
}
